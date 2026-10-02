using iText.Bouncycastle.X509;
using iText.Commons.Bouncycastle.Cert;
using iText.Kernel.Crypto;
using iText.Kernel.Geom;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf;
using iText.Signatures;
using iText.Signatures;
using Org.BouncyCastle.Tls;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.X509;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Threading.Tasks;


public class DigitalSignatureService
{
   

    public async Task<byte[]> SignPdfAsync(byte[] pdfBytes,string reason = "Digitally Signed", string location = "India")
    {
        try
        {
            if (pdfBytes == null || pdfBytes.Length == 0)
            {
                throw new ArgumentException("PDF data is empty.");
            }

            return await Task.Run(() =>
            {


                X509Certificate2 certificate = GetValidDigitalSignatureCertificate();

                if (certificate == null)
                {
                    throw new Exception(
                        "No valid Digital Signature Certificate " +
                        "with RSA private key was found.");
                }



                using (RSA rsa = certificate.GetRSAPrivateKey())
                {
                    if (rsa == null)
                    {
                        throw new Exception(
                            "Unable to access the RSA private key " +
                            "of the selected DSC.");
                    }
                }

                DateTime now = DateTime.Now;

                if (now < certificate.NotBefore)
                {
                    throw new Exception("The Digital Signature Certificate " + "is not yet valid.");
                }

                if (now > certificate.NotAfter)
                {
                    throw new Exception("The Digital Signature Certificate has expired.");
                }
                return SignPdf(pdfBytes, certificate, reason, location);
            });
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    private bool IsDscCertificate(X509Certificate2 certificate)
    {
        try
        {
            foreach (X509Extension extension in certificate.Extensions)
            {
                if (extension is X509EnhancedKeyUsageExtension eku)
                {
                    foreach (Oid oid in eku.EnhancedKeyUsages)
                    {
                        // Client Authentication
                        if (oid.Value == "1.3.6.1.5.5.7.3.2")
                            continue;

                        // Document Signing
                        if (oid.Value == "1.3.6.1.4.1.311.10.3.12")
                            return true;

                        // Code Signing
                        if (oid.Value == "1.3.6.1.5.5.7.3.3")
                            return true;

                        // Email Protection
                        if (oid.Value == "1.3.6.1.5.5.7.3.4")
                            continue;
                    }
                }
            }

            return false;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public X509Certificate2 GetValidDigitalSignatureCertificate()
    {
        List<X509Certificate2> certificates = GetDigitalSignatureCertificates();

        DateTime now = DateTime.Now;



        var candidates = certificates
            .Where(c => c != null)
            .Where(c => c.HasPrivateKey)
            .Where(c => c.NotBefore <= now)
            .Where(c => c.NotAfter >= now)
            .Where(c => IsDigitalSignatureCertificate(c))
            .ToList();

        if (candidates.Count == 0)
        {
            throw new Exception(
                "No valid Digital Signature Certificate with " +
                "private key was found.");
        }

        List<X509Certificate2> signingCertificates = new List<X509Certificate2>();

        foreach (X509Certificate2 certificate in candidates)
        {
            try
            {
                using (RSA rsa = certificate.GetRSAPrivateKey())
                {
                    if (rsa == null)
                        continue;



                    if (certificate.Subject.Contains("localhost", StringComparison.OrdinalIgnoreCase) ||
                        certificate.Issuer.Contains("localhost", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }



                    if (certificate.Subject.Contains("CN=Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }


                    if (string.Equals(
                            certificate.Subject,
                            certificate.Issuer,
                            StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    signingCertificates.Add(certificate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Private key error: " + ex.Message);
            }
        }

        if (signingCertificates.Count == 0)
        {
            throw new Exception(
                "No usable Digital Signature Certificate was found. " +
                "Please connect the USB DSC token.");
        }
        if (signingCertificates.Count == 1)
        {
            return signingCertificates[0];
        }

        var caCertificates =
            signingCertificates
                .Where(c =>
                    !c.Subject.Equals(
                        c.Issuer,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();


        if (caCertificates.Count == 1)
        {
            return caCertificates[0];
        }


        var dscCertificates =
            signingCertificates
                .Where(IsDscCertificate)
                .ToList();


        if (dscCertificates.Count == 1)
        {
            return dscCertificates[0];
        }

        throw new Exception("Multiple valid signing certificates were found. " +
            "Please connect only the required USB DSC token.");
    }




    public List<X509Certificate2> GetDigitalSignatureCertificates()
    {
        try
        {
            List<X509Certificate2> certificates = new List<X509Certificate2>();


            GetCertificatesFromStore(StoreLocation.CurrentUser, certificates);


            GetCertificatesFromStore(StoreLocation.LocalMachine, certificates);

            return certificates
                .Where(c => c != null)
                .GroupBy(c =>
                    string.IsNullOrWhiteSpace(c.Thumbprint)
                        ? c.RawData.Length.ToString()
                        : c.Thumbprint
                            .Replace(" ", "")
                            .ToUpperInvariant())
                .Select(g => g.First())
                .ToList();
        }
        catch (Exception ex)
        {

            throw;
        }
    }


   

    private void GetCertificatesFromStore(StoreLocation storeLocation, List<X509Certificate2> certificates)
    {
        try
        {
            using (X509Store store =new X509Store( StoreName.My,storeLocation))
            {
                store.Open( OpenFlags.ReadOnly |   OpenFlags.OpenExistingOnly);

          

                foreach (X509Certificate2 cert   in store.Certificates)
                {
                    try
                    {
                      

                        if (!cert.HasPrivateKey)
                        {
                           
                            continue;
                        }

                   

                        using (RSA rsa =
                            cert.GetRSAPrivateKey())
                        {
                            if (rsa == null)
                            {
                              
                                continue;
                            }

                     
                        }

                        DateTime now = DateTime.Now;

                        if (cert.NotBefore > now)
                        {
                           

                            continue;
                        }

                        if (cert.NotAfter < now)
                        {
                           

                            continue;
                        }


                        if (!IsDigitalSignatureCertificate(cert))
                        {
                          

                            continue;
                        }

                    
                        certificates.Add(cert);

                  
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(
                            "Certificate Error: " +
                            ex.Message);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine("Certificate Store Error (" + storeLocation + "): " + ex.Message);
        }
    }

    private bool IsDigitalSignatureCertificate(X509Certificate2 certificate)
    {
        try
        {
            bool hasKeyUsage = false;
            bool digitalSignature = false;
            bool nonRepudiation = false;

            bool hasEku = false;
            bool clientAuth = false;
            bool documentSigning = false;
            bool codeSigning = false;
            bool emailProtection = false;

            foreach (X509Extension extension in certificate.Extensions)
            {

                if (extension
                    is X509KeyUsageExtension keyUsage)
                {
                    hasKeyUsage = true;

                    if ((keyUsage.KeyUsages &
                        X509KeyUsageFlags.DigitalSignature) != 0)
                    {
                        digitalSignature = true;
                    }

                    if ((keyUsage.KeyUsages &
                        X509KeyUsageFlags.NonRepudiation) != 0)
                    {
                        nonRepudiation = true;
                    }
                }



                if (extension
                    is X509EnhancedKeyUsageExtension eku)
                {
                    hasEku = true;

                    foreach (Oid oid in eku.EnhancedKeyUsages)
                    {
                        if (oid.Value ==
                            "1.3.6.1.5.5.7.3.2")
                        {
                            // Client Authentication
                            clientAuth = true;
                        }

                        if (oid.Value ==
                            "1.3.6.1.4.1.311.10.3.12")
                        {
                            // Microsoft Document Signing
                            documentSigning = true;
                        }

                        if (oid.Value ==
                            "1.3.6.1.5.5.7.3.3")
                        {
                            // Code Signing
                            codeSigning = true;
                        }

                        if (oid.Value ==
                            "1.3.6.1.5.5.7.3.4")
                        {
                            // Email Protection
                            emailProtection = true;
                        }
                    }
                }
            }


            if (hasKeyUsage)
            {
                if (!digitalSignature &&
                    !nonRepudiation)
                {
                    return false;
                }
            }


            if (hasEku)
            {
                if (!digitalSignature &&
                    !nonRepudiation &&
                    !documentSigning)
                {

                    Console.WriteLine(
                        "EKU does not explicitly indicate document signing.");
                }
            }

            return true;
        }
        catch (Exception ex)
        {

            throw;
        }
    }


    public List<string> ShowCertificates()
    {
        try
        {

            List<string> result =
                new List<string>();

            List<X509Certificate2> certificates =
                GetDigitalSignatureCertificates();

            foreach (X509Certificate2 cert in certificates)
            {
                string information =
                    "Subject: " +
                    cert.Subject +
                    Environment.NewLine +

                    "Issuer: " +
                    cert.Issuer +
                    Environment.NewLine +

                    "Thumbprint: " +
                    cert.Thumbprint +
                    Environment.NewLine +

                    "Valid From: " +
                    cert.NotBefore +
                    Environment.NewLine +

                    "Valid To: " +
                    cert.NotAfter +
                    Environment.NewLine +

                    "Has Private Key: " +
                    cert.HasPrivateKey;

                result.Add(information);


            }

            return result;
        }
        catch (Exception ex)
        {

            throw;
        }
    }


    private byte[] SignPdf(byte[] pdfBytes,X509Certificate2 certificate,string reason,string location)
    {
        try
        {
            using (MemoryStream inputStream = new MemoryStream(pdfBytes))
            using (MemoryStream outputStream = new MemoryStream())
            using (PdfReader reader = new PdfReader(inputStream))
            {

                SignerProperties signerProperties =
                    new SignerProperties().SetFieldName("DigitalSignature")
                        .SetReason(string.IsNullOrWhiteSpace(reason) ? "Digitally Signed" : reason)
                        .SetLocation(string.IsNullOrWhiteSpace(location) ? "India" : location)
                        .SetPageNumber(1)
                        .SetPageRect(new Rectangle(400, 50, 150, 70));

                PdfSigner signer = new PdfSigner(reader, outputStream, new StampingProperties().UseAppendMode());
                signer.SetSignerProperties(signerProperties);

                IX509Certificate[] chain = BuildCertificateChain(certificate);
                IExternalSignature externalSignature = new X509Certificate2Signature(certificate, DigestAlgorithms.SHA256);
                signer.SignDetached(externalSignature, chain, null, null, null, 0, PdfSigner.CryptoStandard.CMS);
                return outputStream.ToArray();
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }



    private IX509Certificate[] BuildCertificateChain(X509Certificate2 certificate)
    {
        try
        {
            List<IX509Certificate> result = new List<IX509Certificate>();

            using (X509Chain chain = new X509Chain())
            {
                chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;

                bool built =chain.Build(certificate);

                Console.WriteLine("Certificate chain built: " + built);

                foreach (X509ChainElement element in chain.ChainElements)
                {
                    X509Certificate2 cert = element.Certificate;

                    Console.WriteLine( "Chain Certificate: " +  cert.Subject);

                    X509CertificateParser parser = new X509CertificateParser();

                    Org.BouncyCastle.X509.X509Certificate bcCert = parser.ReadCertificate(cert.RawData);

                    result.Add(new X509CertificateBC(bcCert));
                }
            }
            if (result.Count == 0)
            {
                X509CertificateParser parser = new X509CertificateParser();
                Org.BouncyCastle.X509.X509Certificate bcCert = parser.ReadCertificate( certificate.RawData);
                result.Add(new X509CertificateBC(bcCert));
            }
            return result.ToArray();
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public string GetCertificateInformation()
    {
        try
        {
            X509Certificate2 certificate = GetValidDigitalSignatureCertificate();

            if (certificate == null)
            {
                return "No valid Digital Signature Certificate found.";
            }

            string provider = "Unknown";

            try
            {
                using (RSA rsa = certificate.GetRSAPrivateKey())
                {
                    if (rsa != null)
                    {
                        provider =rsa.GetType().FullName;
                    }
                }
            }
            catch (Exception ex)
            {
                provider ="Unable to access provider: " + ex.Message;
            }


            return
                "Subject: " +
                certificate.Subject +
                Environment.NewLine +

                "Issuer: " +
                certificate.Issuer +
                Environment.NewLine +

                "Thumbprint: " +
                certificate.Thumbprint +
                Environment.NewLine +

                "Valid From: " +
                certificate.NotBefore +
                Environment.NewLine +

                "Valid To: " +
                certificate.NotAfter +
                Environment.NewLine +

                "Has Private Key: " +
                certificate.HasPrivateKey +
                Environment.NewLine +

                "RSA Provider: " +
                provider;
        }
        catch (Exception ex)
        {
            return
                "Certificate Error: " +
                ex.Message;
        }
    }
    public Task<string> Cetificatereturnasync()
    {
        X509Certificate2 certificate = GetValidDigitalSignatureCertificate();

        if (certificate == null)
        {
            throw new Exception("No valid Digital Signature Certificate with RSA private key was found.");
        }

        using (RSA rsa = certificate.GetRSAPrivateKey())
        {
            if (rsa == null)
            {
                throw new Exception("Unable to access the RSA private key of the selected DSC.");
            }
        }

        DateTime now = DateTime.Now;

        if (now < certificate.NotBefore)
            throw new Exception("The Digital Signature Certificate is not yet valid.");

        if (now > certificate.NotAfter)
            throw new Exception("The Digital Signature Certificate has expired.");

        string certificateName = certificate.GetNameInfo(X509NameType.SimpleName,false);

        string result ="Digitally signed by" + Environment.NewLine + certificateName +  Environment.NewLine + "Date: " + now.ToString("dd/MM/yyyy hh:mm:ss tt");

        return Task.FromResult(result);
    }
}



public class X509Certificate2Signature : IExternalSignature
{
    private readonly X509Certificate2 certificate;

    private readonly string hashAlgorithm;

    public X509Certificate2Signature(X509Certificate2 certificate,string hashAlgorithm)
    {
        if (certificate == null)
        {
            throw new ArgumentNullException(nameof(certificate));
        }

        if (!certificate.HasPrivateKey)
        {
            throw new ArgumentException("Certificate does not contain a private key.",nameof(certificate));
        }

        this.certificate =certificate;

        this.hashAlgorithm =NormalizeHashAlgorithm(hashAlgorithm);
    }

    public string GetHashAlgorithm()
    {
        return hashAlgorithm;
    }


    public string GetEncryptionAlgorithm()
    {
        using (RSA rsa =certificate.GetRSAPrivateKey())
        {
            if (rsa != null)
            {
                return "RSA";
            }
        }

        throw new InvalidOperationException("The DSC certificate does not contain " +"an RSA private key.");
    }



    public string GetDigestAlgorithmName()
    {
        return hashAlgorithm;
    }

    public string GetSignatureAlgorithmName()
    {
        return "RSA";
    }



    public ISignatureMechanismParams
        GetSignatureMechanismParameters()
    {
        return null;
    }



    public byte[] Sign(byte[] message)
    {
        if (message == null || message.Length == 0)
        {
            throw new ArgumentException("Message to sign is empty.");
        }

        using (RSA rsa = certificate.GetRSAPrivateKey())
        {
            if (rsa == null)
            {
                throw new InvalidOperationException("Unable to access the DSC RSA private key.");
            }

            byte[] signature = rsa.SignData( message, new HashAlgorithmName(hashAlgorithm),RSASignaturePadding.Pkcs1);

            if (signature == null || signature.Length == 0)
            {
                throw new CryptographicException("USB DSC returned an empty signature.");
            }

            Console.WriteLine("Signature generated successfully.");
            return signature;
        }
    }


    private string NormalizeHashAlgorithm(string algorithm)
    {
        if (string.IsNullOrWhiteSpace(algorithm))
        {
            return "SHA256";
        }

        string value = algorithm.Replace("-", "").Replace(" ", "").ToUpperInvariant();

        switch (value)
        {
            case "SHA1":
                return "SHA1";

            case "SHA256":
                return "SHA256";

            case "SHA384":
                return "SHA384";

            case "SHA512":
                return "SHA512";

            default:
                throw new ArgumentException("Unsupported hash algorithm: " + algorithm);
        }
    }


    
}

