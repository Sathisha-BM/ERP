using V.SMART.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace V.SMART.Services
//{

//    public class DesktopPathProvider : IPathProvider
//    {
//        public string GetReportTemplatePath()
//        {
//            // ✅ 1. Runtime (Published/Desktop)
//            var runtimePath = Path.Combine(AppContext.BaseDirectory, "templates");
//            if (Directory.Exists(runtimePath))
//                return runtimePath;

//            // ✅ 2. DEV (Find solution root dynamically)
//            var current = AppContext.BaseDirectory;
//            DirectoryInfo dir = new DirectoryInfo(current);

//            while (dir != null && !Directory.Exists(Path.Combine(dir.FullName, "V.SMART.Shared")))
//            {
//                dir = dir.Parent;
//            }

//            if (dir == null)
//                throw new DirectoryNotFoundException("Solution root not found.");

//            var devPath = Path.Combine(dir.FullName, "V.SMART.Shared", "wwwroot", "templates");

//            if (Directory.Exists(devPath))
//                return devPath;

//            throw new DirectoryNotFoundException($"Template folder not found.\nChecked:\n{runtimePath}\n{devPath}");
//        }
//    }

//}


namespace V.SMART.Services
{
    public class DesktopPathProvider : IPathProvider
    {
        public string GetReportTemplatePath()
        {
            // =========================================================
            // 1. DESKTOP / OFFLINE / PUBLISHED
            // =========================================================
            var desktopPath = Path.Combine(AppContext.BaseDirectory,
                "templates"
            );

            if (Directory.Exists(desktopPath))
            {
                return desktopPath;
            }


            // =========================================================
            // 2. WEB / ONLINE / PUBLISHED
            // =========================================================
            var webPath = Path.Combine(AppContext.BaseDirectory,"wwwroot","_content","V.SMART.Shared","templates");

            if (Directory.Exists(webPath))
            {
                return webPath;
            }


            // =========================================================
            // 3. DEVELOPMENT
            // =========================================================
            var current = new DirectoryInfo(AppContext.BaseDirectory);

            while (current != null)
            {
                var devPath = Path.Combine(current.FullName,"V.SMART.Shared","wwwroot","templates"
                );

                if (Directory.Exists(devPath))
                {
                    return devPath;
                }

                current = current.Parent;
            }


            // =========================================================
            // NOTHING FOUND
            // =========================================================
            throw new DirectoryNotFoundException(
                "Report template folder not found.\n\n" +
                $"Desktop Path:\n{desktopPath}\n\n" +
                $"Web Path:\n{webPath}\n\n" +
                $"Base Directory:\n{AppContext.BaseDirectory}"
            );
        }
    }
}
