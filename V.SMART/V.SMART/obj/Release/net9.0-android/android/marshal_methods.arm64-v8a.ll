; ModuleID = 'marshal_methods.arm64-v8a.ll'
source_filename = "marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [335 x ptr] zeroinitializer, align 8

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [1005 x i64] [
	i64 u0x001e58127c546039, ; 0: lib_System.Globalization.dll.so => 252
	i64 u0x0071cf2d27b7d61e, ; 1: lib_Xamarin.AndroidX.SwipeRefreshLayout.dll.so => 217
	i64 u0x01109b0e4d99e61f, ; 2: System.ComponentModel.Annotations.dll => 237
	i64 u0x018390303da74873, ; 3: pt-BR/Microsoft.CodeAnalysis.VisualBasic.resources => 34
	i64 u0x02123411c4e01926, ; 4: lib_Xamarin.AndroidX.Navigation.Runtime.dll.so => 213
	i64 u0x022f31be406de945, ; 5: Microsoft.Extensions.Options.ConfigurationExtensions => 155
	i64 u0x02827b47e97f2378, ; 6: System.Security.Cryptography.Pkcs.dll => 189
	i64 u0x02a4c5a44384f885, ; 7: Microsoft.Extensions.Caching.Memory => 131
	i64 u0x02abedc11addc1ed, ; 8: lib_Mono.Android.Runtime.dll.so => 333
	i64 u0x032267b2a94db371, ; 9: lib_Xamarin.AndroidX.AppCompat.dll.so => 195
	i64 u0x033a1d0324ba06bd, ; 10: Microsoft.IO.RecyclableMemoryStream.dll => 165
	i64 u0x03621c804933a890, ; 11: System.Buffers => 231
	i64 u0x0399610510a38a38, ; 12: lib_System.Private.DataContractSerialization.dll.so => 279
	i64 u0x043032f1d071fae0, ; 13: ru/Microsoft.Maui.Controls.resources => 63
	i64 u0x044440a55165631e, ; 14: lib-cs-Microsoft.Maui.Controls.resources.dll.so => 41
	i64 u0x046eb1581a80c6b0, ; 15: vi/Microsoft.Maui.Controls.resources => 69
	i64 u0x0470607fd33c32db, ; 16: Microsoft.IdentityModel.Abstractions.dll => 159
	i64 u0x04d8009984d4ef21, ; 17: FastReport.OpenSource.Export.PdfSimple.dll => 91
	i64 u0x0517ef04e06e9f76, ; 18: System.Net.Primitives => 269
	i64 u0x0565d18c6da3de38, ; 19: Xamarin.AndroidX.RecyclerView => 215
	i64 u0x0581db89237110e9, ; 20: lib_System.Collections.dll.so => 236
	i64 u0x05989cb940b225a9, ; 21: Microsoft.Maui.dll => 169
	i64 u0x05a1c25e78e22d87, ; 22: lib_System.Runtime.CompilerServices.Unsafe.dll.so => 289
	i64 u0x06076b5d2b581f08, ; 23: zh-HK/Microsoft.Maui.Controls.resources => 70
	i64 u0x06388ffe9f6c161a, ; 24: System.Xml.Linq.dll => 324
	i64 u0x0680a433c781bb3d, ; 25: Xamarin.AndroidX.Collection.Jvm => 199
	i64 u0x0690533f9fc14683, ; 26: lib_Microsoft.AspNetCore.Components.dll.so => 107
	i64 u0x07c57877c7ba78ad, ; 27: ru/Microsoft.Maui.Controls.resources.dll => 63
	i64 u0x07dcdc7460a0c5e4, ; 28: System.Collections.NonGeneric => 234
	i64 u0x08881a0a9768df86, ; 29: lib_Azure.Core.dll.so => 75
	i64 u0x08a7c865576bbde7, ; 30: System.Reflection.Primitives => 287
	i64 u0x08f3c9788ee2153c, ; 31: Xamarin.AndroidX.DrawerLayout => 204
	i64 u0x090a04c5180cf016, ; 32: itext.styledxmlparser => 101
	i64 u0x09138715c92dba90, ; 33: lib_System.ComponentModel.Annotations.dll.so => 237
	i64 u0x0919c28b89381a0b, ; 34: lib_Microsoft.Extensions.Options.dll.so => 154
	i64 u0x092266563089ae3e, ; 35: lib_System.Collections.NonGeneric.dll.so => 234
	i64 u0x095cacaf6b6a32e4, ; 36: System.Memory.Data => 187
	i64 u0x09d144a7e214d457, ; 37: System.Security.Cryptography => 309
	i64 u0x09e2b9f743db21a8, ; 38: lib_System.Reflection.Metadata.dll.so => 286
	i64 u0x0a805f95d98f597b, ; 39: lib_Microsoft.Extensions.Caching.Abstractions.dll.so => 130
	i64 u0x0a980941fa112bc4, ; 40: System.Security.Cryptography.Xml => 191
	i64 u0x0abb3e2b271edc45, ; 41: System.Threading.Channels.dll => 314
	i64 u0x0add38f5cf8f3bef, ; 42: ExcelDataReader.DataSet => 87
	i64 u0x0adeb6c0f5699d33, ; 43: Microsoft.Data.SqlClient.dll => 124
	i64 u0x0b3b632c3bbee20c, ; 44: sk/Microsoft.Maui.Controls.resources => 64
	i64 u0x0b6aff547b84fbe9, ; 45: Xamarin.KotlinX.Serialization.Core.Jvm => 223
	i64 u0x0be1e582d0d8ef1a, ; 46: lib_Microsoft.AspNetCore.Cryptography.KeyDerivation.dll.so => 115
	i64 u0x0be2e1f8ce4064ed, ; 47: Xamarin.AndroidX.ViewPager => 218
	i64 u0x0c3ca6cc978e2aae, ; 48: pt-BR/Microsoft.Maui.Controls.resources => 60
	i64 u0x0c59ad9fbbd43abe, ; 49: Mono.Android => 334
	i64 u0x0c7790f60165fc06, ; 50: lib_Microsoft.Maui.Essentials.dll.so => 170
	i64 u0x0cf6a95dadccbb9c, ; 51: zh-Hant/Microsoft.CodeAnalysis.resources.dll => 12
	i64 u0x0d34fb076d8103ae, ; 52: Microsoft.Extensions.Identity.Core.dll => 148
	i64 u0x0d3b5ab8b2766190, ; 53: lib_Microsoft.Bcl.AsyncInterfaces.dll.so => 120
	i64 u0x0e14e73a54dda68e, ; 54: lib_System.Net.NameResolution.dll.so => 267
	i64 u0x0e7acf675d09f75a, ; 55: it/Microsoft.CodeAnalysis.resources => 4
	i64 u0x0ebd6d1168be0395, ; 56: tr/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 36
	i64 u0x0ec47e16319c99d9, ; 57: lib-de-Microsoft.CodeAnalysis.resources.dll.so => 1
	i64 u0x102861e4055f511a, ; 58: Microsoft.Bcl.AsyncInterfaces.dll => 120
	i64 u0x102a31b45304b1da, ; 59: Xamarin.AndroidX.CustomView => 203
	i64 u0x105b053cfbaba1f0, ; 60: lib_Microsoft.CodeAnalysis.dll.so => 121
	i64 u0x10a579e648829775, ; 61: Microsoft.CodeAnalysis => 121
	i64 u0x10f6cfcbcf801616, ; 62: System.IO.Compression.Brotli => 253
	i64 u0x111e7120c198511e, ; 63: DocumentFormat.OpenXml.Framework.dll => 83
	i64 u0x114443cdcf2091f1, ; 64: System.Security.Cryptography.Primitives => 307
	i64 u0x114df3ff11650a65, ; 65: ru/Microsoft.CodeAnalysis.CSharp.resources => 22
	i64 u0x11a70d0e1009fb11, ; 66: System.Net.WebSockets.dll => 276
	i64 u0x1208da3842d90ff3, ; 67: lib-ko-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 19
	i64 u0x123639456fb056da, ; 68: System.Reflection.Emit.Lightweight.dll => 284
	i64 u0x125b7f94acb989db, ; 69: Xamarin.AndroidX.RecyclerView.dll => 215
	i64 u0x126ee4b0de53cbfd, ; 70: Microsoft.IdentityModel.Protocols.OpenIdConnect.dll => 163
	i64 u0x12f215a8ddd21946, ; 71: FastReport.Data.MsSql.dll => 225
	i64 u0x131463e9417f52d4, ; 72: de/Microsoft.CodeAnalysis.CSharp.resources => 14
	i64 u0x137b34d6751da129, ; 73: System.Drawing.Common => 183
	i64 u0x138567fa954faa55, ; 74: Xamarin.AndroidX.Browser => 197
	i64 u0x1393617ead22674a, ; 75: zh-Hant/Microsoft.CodeAnalysis.resources => 12
	i64 u0x13a01de0cbc3f06c, ; 76: lib-fr-Microsoft.Maui.Controls.resources.dll.so => 47
	i64 u0x13f1e5e209e91af4, ; 77: lib_Java.Interop.dll.so => 332
	i64 u0x13f1e880c25d96d1, ; 78: he/Microsoft.Maui.Controls.resources => 48
	i64 u0x143a1f6e62b82b56, ; 79: Microsoft.IdentityModel.Protocols.OpenIdConnect => 163
	i64 u0x143d8ea60a6a4011, ; 80: Microsoft.Extensions.DependencyInjection.Abstractions => 138
	i64 u0x1446c7a06695f3ea, ; 81: ko/Microsoft.CodeAnalysis.CSharp.resources.dll => 19
	i64 u0x1497051b917530bd, ; 82: lib_System.Net.WebSockets.dll.so => 276
	i64 u0x14b0660e629937d5, ; 83: itext.pdfua => 99
	i64 u0x1506378c0000a92a, ; 84: lib-tr-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 23
	i64 u0x152a448bd1e745a7, ; 85: Microsoft.Win32.Primitives => 229
	i64 u0x15bdc156ed462f2f, ; 86: lib_System.IO.FileSystem.dll.so => 257
	i64 u0x16054fdcb6b3098b, ; 87: Microsoft.Extensions.DependencyModel.dll => 139
	i64 u0x16bf2a22df043a09, ; 88: System.IO.Pipes.dll => 259
	i64 u0x16ea2b318ad2d830, ; 89: System.Security.Cryptography.Algorithms => 303
	i64 u0x17125c9a85b4929f, ; 90: lib_netstandard.dll.so => 330
	i64 u0x1716866f7416792e, ; 91: lib_System.Security.AccessControl.dll.so => 301
	i64 u0x17b56e25558a5d36, ; 92: lib-hu-Microsoft.Maui.Controls.resources.dll.so => 51
	i64 u0x17f9358913beb16a, ; 93: System.Text.Encodings.Web => 192
	i64 u0x18402a709e357f3b, ; 94: lib_Xamarin.KotlinX.Serialization.Core.Jvm.dll.so => 223
	i64 u0x18950fae1c2bc98e, ; 95: lib-cs-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 13
	i64 u0x18a9befae51bb361, ; 96: System.Net.WebClient => 274
	i64 u0x18f0ce884e87d89a, ; 97: nb/Microsoft.Maui.Controls.resources.dll => 57
	i64 u0x192712eaa333180f, ; 98: lib-zh-Hant-Microsoft.CodeAnalysis.resources.dll.so => 12
	i64 u0x19a4c090f14ebb66, ; 99: System.Security.Claims => 302
	i64 u0x19cc755c2ef2727f, ; 100: itext.bouncy-castle-adapter.dll => 103
	i64 u0x1a6dd36f1bb02813, ; 101: V.SMART.dll => 227
	i64 u0x1a6fceea64859810, ; 102: Azure.Identity => 76
	i64 u0x1a761daba47c6ad5, ; 103: ja/Microsoft.CodeAnalysis.resources.dll => 5
	i64 u0x1a91866a319e9259, ; 104: lib_System.Collections.Concurrent.dll.so => 232
	i64 u0x1a9e139e4762aaf8, ; 105: es/Microsoft.CodeAnalysis.CSharp.resources.dll => 15
	i64 u0x1aac34d1917ba5d3, ; 106: lib_System.dll.so => 329
	i64 u0x1aad60783ffa3e5b, ; 107: lib-th-Microsoft.Maui.Controls.resources.dll.so => 66
	i64 u0x1b8700ce6e547c0b, ; 108: lib_Microsoft.AspNetCore.Components.Forms.dll.so => 110
	i64 u0x1c074bdeeae2e1c9, ; 109: lib-pl-Microsoft.CodeAnalysis.resources.dll.so => 7
	i64 u0x1c292b1598348d77, ; 110: Microsoft.Extensions.Diagnostics.dll => 140
	i64 u0x1c5217a9e4973753, ; 111: lib_Microsoft.Extensions.FileProviders.Physical.dll.so => 145
	i64 u0x1c753b5ff15bce1b, ; 112: Mono.Android.Runtime.dll => 333
	i64 u0x1cd47467799d8250, ; 113: System.Threading.Tasks.dll => 317
	i64 u0x1db6820994506bf5, ; 114: System.IO.FileSystem.AccessControl.dll => 255
	i64 u0x1dbb0c2c6a999acb, ; 115: System.Diagnostics.StackTrace => 245
	i64 u0x1e3d87657e9659bc, ; 116: Xamarin.AndroidX.Navigation.UI => 214
	i64 u0x1e71143913d56c10, ; 117: lib-ko-Microsoft.Maui.Controls.resources.dll.so => 55
	i64 u0x1e7c31185e2fb266, ; 118: lib_System.Threading.Tasks.Parallel.dll.so => 316
	i64 u0x1e996098b37c14fb, ; 119: V.SMART => 227
	i64 u0x1ed8fcce5e9b50a0, ; 120: Microsoft.Extensions.Options.dll => 154
	i64 u0x1f055d15d807e1b2, ; 121: System.Xml.XmlSerializer => 328
	i64 u0x1f198ea93d5594b5, ; 122: Microsoft.Extensions.Identity.Core => 148
	i64 u0x20237ea48006d7a8, ; 123: lib_System.Net.WebClient.dll.so => 274
	i64 u0x209375905fcc1bad, ; 124: lib_System.IO.Compression.Brotli.dll.so => 253
	i64 u0x20d435a6f3f1221d, ; 125: pl/Microsoft.CodeAnalysis.VisualBasic.resources => 33
	i64 u0x20fab3cf2dfbc8df, ; 126: lib_System.Diagnostics.Process.dll.so => 244
	i64 u0x2110167c128cba15, ; 127: System.Globalization => 252
	i64 u0x212dabedfbeb018b, ; 128: lib_EPPlus.dll.so => 84
	i64 u0x2174319c0d835bc9, ; 129: System.Runtime => 300
	i64 u0x2199f06354c82d3b, ; 130: System.ClientModel.dll => 179
	i64 u0x21cc7e445dcd5469, ; 131: System.Reflection.Emit.ILGeneration => 283
	i64 u0x220fd4f2e7c48170, ; 132: th/Microsoft.Maui.Controls.resources => 66
	i64 u0x224538d85ed15a82, ; 133: System.IO.Pipes => 259
	i64 u0x22908438c6bed1af, ; 134: lib_System.Threading.Timer.dll.so => 320
	i64 u0x22fe1aafc4641617, ; 135: itext.bouncy-castle-connector => 93
	i64 u0x235fb4941dc174e1, ; 136: DocumentFormat.OpenXml => 82
	i64 u0x237be844f1f812c7, ; 137: System.Threading.Thread.dll => 318
	i64 u0x23807c59646ec4f3, ; 138: lib_Microsoft.EntityFrameworkCore.dll.so => 126
	i64 u0x23852b3bdc9f7096, ; 139: System.Resources.ResourceManager => 288
	i64 u0x2407aef2bbe8fadf, ; 140: System.Console => 241
	i64 u0x240abe014b27e7d3, ; 141: Xamarin.AndroidX.Core.dll => 201
	i64 u0x245ebc45bf698558, ; 142: ru/Microsoft.CodeAnalysis.resources.dll => 9
	i64 u0x247619fe4413f8bf, ; 143: System.Runtime.Serialization.Primitives.dll => 298
	i64 u0x252073cc3caa62c2, ; 144: fr/Microsoft.Maui.Controls.resources.dll => 47
	i64 u0x262ca6354d7e784c, ; 145: lib_FastReport.OpenSource.Export.PdfSimple.dll.so => 91
	i64 u0x2662c629b96b0b30, ; 146: lib_Xamarin.Kotlin.StdLib.dll.so => 221
	i64 u0x268c1439f13bcc29, ; 147: lib_Microsoft.Extensions.Primitives.dll.so => 156
	i64 u0x270a44600c921861, ; 148: System.IdentityModel.Tokens.Jwt => 184
	i64 u0x272377f9edc266a2, ; 149: tr/Microsoft.CodeAnalysis.resources => 10
	i64 u0x273f3515de5faf0d, ; 150: id/Microsoft.Maui.Controls.resources.dll => 52
	i64 u0x2742545f9094896d, ; 151: hr/Microsoft.Maui.Controls.resources => 50
	i64 u0x2759af78ab94d39b, ; 152: System.Net.WebSockets => 276
	i64 u0x27b410442fad6cf1, ; 153: Java.Interop.dll => 332
	i64 u0x27b97e0d52c3034a, ; 154: System.Diagnostics.Debug => 243
	i64 u0x2801845a2c71fbfb, ; 155: System.Net.Primitives.dll => 269
	i64 u0x28e52865585a1ebe, ; 156: Microsoft.Extensions.Diagnostics.Abstractions.dll => 141
	i64 u0x2a128783efe70ba0, ; 157: uk/Microsoft.Maui.Controls.resources.dll => 68
	i64 u0x2a3b095612184159, ; 158: lib_System.Net.NetworkInformation.dll.so => 268
	i64 u0x2a6507a5ffabdf28, ; 159: System.Diagnostics.TraceSource.dll => 247
	i64 u0x2a8556742ffd34ef, ; 160: itext.sign => 100
	i64 u0x2ad156c8e1354139, ; 161: fi/Microsoft.Maui.Controls.resources => 46
	i64 u0x2af298f63581d886, ; 162: System.Text.RegularExpressions.dll => 313
	i64 u0x2af615542f04da50, ; 163: System.IdentityModel.Tokens.Jwt.dll => 184
	i64 u0x2afc1c4f898552ee, ; 164: lib_System.Formats.Asn1.dll.so => 251
	i64 u0x2b148910ed40fbf9, ; 165: zh-Hant/Microsoft.Maui.Controls.resources.dll => 72
	i64 u0x2b4d4904cebfa4e9, ; 166: Microsoft.Extensions.FileSystemGlobbing => 146
	i64 u0x2b56eeab97412d7a, ; 167: itext.pdfa.dll => 98
	i64 u0x2b73dc6bb40edd58, ; 168: EPPlus.Interfaces.dll => 85
	i64 u0x2c8bd14bb93a7d82, ; 169: lib-pl-Microsoft.Maui.Controls.resources.dll.so => 59
	i64 u0x2cbd9262ca785540, ; 170: lib_System.Text.Encoding.CodePages.dll.so => 311
	i64 u0x2cc9e1fed6257257, ; 171: lib_System.Reflection.Emit.Lightweight.dll.so => 284
	i64 u0x2cd723e9fe623c7c, ; 172: lib_System.Private.Xml.Linq.dll.so => 281
	i64 u0x2d169d318a968379, ; 173: System.Threading.dll => 321
	i64 u0x2d47774b7d993f59, ; 174: sv/Microsoft.Maui.Controls.resources.dll => 65
	i64 u0x2db915caf23548d2, ; 175: System.Text.Json.dll => 193
	i64 u0x2e4d2e03e610a6e9, ; 176: pl/Microsoft.CodeAnalysis.resources => 7
	i64 u0x2e5a40c319acb800, ; 177: System.IO.FileSystem => 257
	i64 u0x2e6f1f226821322a, ; 178: el/Microsoft.Maui.Controls.resources.dll => 44
	i64 u0x2e8ff3fae87a8245, ; 179: lib_Microsoft.JSInterop.dll.so => 166
	i64 u0x2ef0c22aee1f75b2, ; 180: lib_AutoMapper.dll.so => 74
	i64 u0x2f02f94df3200fe5, ; 181: System.Diagnostics.Process => 244
	i64 u0x2f2e98e1c89b1aff, ; 182: System.Xml.ReaderWriter => 325
	i64 u0x2f40b2521deba305, ; 183: lib_Microsoft.SqlServer.Server.dll.so => 172
	i64 u0x2f5911d9ba814e4e, ; 184: System.Diagnostics.Tracing => 248
	i64 u0x2f68fb2b18bd1ddd, ; 185: lib-zh-Hans-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 37
	i64 u0x2feb4d2fcda05cfd, ; 186: Microsoft.Extensions.Caching.Abstractions.dll => 130
	i64 u0x2ff49de6a71764a1, ; 187: lib_Microsoft.Extensions.Http.dll.so => 147
	i64 u0x309ee9eeec09a71e, ; 188: lib_Xamarin.AndroidX.Fragment.dll.so => 205
	i64 u0x309f2bedefa9a318, ; 189: Microsoft.IdentityModel.Abstractions => 159
	i64 u0x30edd425fdfe0be9, ; 190: MimeKit => 173
	i64 u0x310d9651ec86c411, ; 191: Microsoft.Extensions.FileProviders.Embedded => 144
	i64 u0x31134f735ae5cc3f, ; 192: lib-it-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 30
	i64 u0x31195fef5d8fb552, ; 193: _Microsoft.Android.Resource.Designer.dll => 73
	i64 u0x32243413e774362a, ; 194: Xamarin.AndroidX.CardView.dll => 198
	i64 u0x3235427f8d12dae1, ; 195: lib_System.Drawing.Primitives.dll.so => 249
	i64 u0x324622a9fd95b0c8, ; 196: lib-cs-Microsoft.CodeAnalysis.resources.dll.so => 0
	i64 u0x32524ae1e229f098, ; 197: itext.svg.dll => 102
	i64 u0x3272b3962f12ea25, ; 198: Microsoft.AspNetCore.Components.DataAnnotations.Validation => 109
	i64 u0x329753a17a517811, ; 199: fr/Microsoft.Maui.Controls.resources => 47
	i64 u0x32aa989ff07a84ff, ; 200: lib_System.Xml.ReaderWriter.dll.so => 325
	i64 u0x33642d5508314e46, ; 201: Microsoft.Extensions.FileSystemGlobbing.dll => 146
	i64 u0x33829542f112d59b, ; 202: System.Collections.Immutable => 233
	i64 u0x33a31443733849fe, ; 203: lib-es-Microsoft.Maui.Controls.resources.dll.so => 45
	i64 u0x341abc357fbb4ebf, ; 204: lib_System.Net.Sockets.dll.so => 273
	i64 u0x348d598f4054415e, ; 205: Microsoft.SqlServer.Server => 172
	i64 u0x34bd01fd4be06ee3, ; 206: lib_Microsoft.Extensions.FileProviders.Composite.dll.so => 143
	i64 u0x34dfd74fe2afcf37, ; 207: Microsoft.Maui => 169
	i64 u0x34e292762d9615df, ; 208: cs/Microsoft.Maui.Controls.resources.dll => 41
	i64 u0x34ef56e1435b2843, ; 209: pl/Microsoft.CodeAnalysis.CSharp.resources.dll => 20
	i64 u0x3508234247f48404, ; 210: Microsoft.Maui.Controls => 167
	i64 u0x353590da528c9d22, ; 211: System.ComponentModel.Annotations => 237
	i64 u0x3549870798b4cd30, ; 212: lib_Xamarin.AndroidX.ViewPager2.dll.so => 219
	i64 u0x355282fc1c909694, ; 213: Microsoft.Extensions.Configuration => 132
	i64 u0x355c649948d55d97, ; 214: lib_System.Runtime.Intrinsics.dll.so => 293
	i64 u0x35766456ffb7a7b4, ; 215: fr/Microsoft.CodeAnalysis.CSharp.resources.dll => 16
	i64 u0x3628ab68db23a01a, ; 216: lib_System.Diagnostics.Tools.dll.so => 246
	i64 u0x3673b042508f5b6b, ; 217: lib_System.Runtime.Extensions.dll.so => 290
	i64 u0x36b2b50fdf589ae2, ; 218: System.Reflection.Emit.Lightweight => 284
	i64 u0x36cada77dc79928b, ; 219: System.IO.MemoryMappedFiles => 258
	i64 u0x374ef46b06791af6, ; 220: System.Reflection.Primitives.dll => 287
	i64 u0x380134e03b1e160a, ; 221: System.Collections.Immutable.dll => 233
	i64 u0x38049b5c59b39324, ; 222: System.Runtime.CompilerServices.Unsafe => 289
	i64 u0x385c17636bb6fe6e, ; 223: Xamarin.AndroidX.CustomView.dll => 203
	i64 u0x38869c811d74050e, ; 224: System.Net.NameResolution.dll => 267
	i64 u0x38e93ec1c057cdf6, ; 225: Microsoft.IdentityModel.Protocols => 162
	i64 u0x39251dccb84bdcaa, ; 226: lib_System.Configuration.ConfigurationManager.dll.so => 180
	i64 u0x393c226616977fdb, ; 227: lib_Xamarin.AndroidX.ViewPager.dll.so => 218
	i64 u0x395e37c3334cf82a, ; 228: lib-ca-Microsoft.Maui.Controls.resources.dll.so => 40
	i64 u0x39aa39fda111d9d3, ; 229: Newtonsoft.Json => 175
	i64 u0x39c3107c28752af1, ; 230: lib_Microsoft.Extensions.FileProviders.Abstractions.dll.so => 142
	i64 u0x3a67fa982ce4abf0, ; 231: RBush => 177
	i64 u0x3a76a7a156f3d989, ; 232: System.IO.Packaging => 185
	i64 u0x3a9ae914a83b6050, ; 233: itext.barcodes.dll => 92
	i64 u0x3ab5859054645f72, ; 234: System.Security.Cryptography.Primitives.dll => 307
	i64 u0x3ad31bc4ddf45918, ; 235: ClosedXML.dll => 80
	i64 u0x3b7c0852ff8fece4, ; 236: cs/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 26
	i64 u0x3b860f9932505633, ; 237: lib_System.Text.Encoding.Extensions.dll.so => 312
	i64 u0x3be6248c2bc7dc8c, ; 238: Microsoft.JSInterop.dll => 166
	i64 u0x3bea9ebe8c027c01, ; 239: lib_Microsoft.IdentityModel.Tokens.dll.so => 164
	i64 u0x3bf9acabbf4eef1f, ; 240: lib_MimeKit.dll.so => 173
	i64 u0x3c3aafb6b3a00bf6, ; 241: lib_System.Security.Cryptography.X509Certificates.dll.so => 308
	i64 u0x3c5f19e4acdcebd8, ; 242: lib_Microsoft.Data.SqlClient.dll.so => 124
	i64 u0x3c7c495f58ac5ee9, ; 243: Xamarin.Kotlin.StdLib => 221
	i64 u0x3cd9d281d402eb9b, ; 244: Xamarin.AndroidX.Browser.dll => 197
	i64 u0x3d196e782ed8c01a, ; 245: System.Data.SqlClient => 181
	i64 u0x3d2b1913edfc08d7, ; 246: lib_System.Threading.ThreadPool.dll.so => 319
	i64 u0x3d46f0b995082740, ; 247: System.Xml.Linq => 324
	i64 u0x3d551d0efdd24596, ; 248: System.IO.Packaging.dll => 185
	i64 u0x3d9c2a242b040a50, ; 249: lib_Xamarin.AndroidX.Core.dll.so => 201
	i64 u0x3db495de2204755c, ; 250: Microsoft.Extensions.Configuration.FileExtensions => 135
	i64 u0x3e7f8912b96e5065, ; 251: Microsoft.AspNetCore.Components.WebView.dll => 113
	i64 u0x3f3c8f45ab6f28c7, ; 252: Microsoft.Identity.Client.Extensions.Msal.dll => 158
	i64 u0x3f510adf788828dd, ; 253: System.Threading.Tasks.Extensions => 315
	i64 u0x407a10bb4bf95829, ; 254: lib_Xamarin.AndroidX.Navigation.Common.dll.so => 211
	i64 u0x407ac43dee26bd5a, ; 255: lib_Azure.Identity.dll.so => 76
	i64 u0x415c502eb40e7418, ; 256: es/Microsoft.CodeAnalysis.resources.dll => 2
	i64 u0x415e36f6b13ff6f3, ; 257: System.Configuration.ConfigurationManager.dll => 180
	i64 u0x41cab042be111c34, ; 258: lib_Xamarin.AndroidX.AppCompat.AppCompatResources.dll.so => 196
	i64 u0x41f93add55d80a27, ; 259: lib_Microsoft.Extensions.Localization.dll.so => 150
	i64 u0x4202b91ac01ad789, ; 260: itext.barcodes => 92
	i64 u0x423a9ecc4d905a88, ; 261: lib_System.Resources.ResourceManager.dll.so => 288
	i64 u0x424fa9fe9db3e96c, ; 262: lib-pt-BR-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 34
	i64 u0x42e31da9a7a44ec5, ; 263: es/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 28
	i64 u0x42ec0b444cd277cb, ; 264: Blazored.LocalStorage.dll => 78
	i64 u0x430e95b891249788, ; 265: lib_System.Reflection.Emit.dll.so => 285
	i64 u0x43375950ec7c1b6a, ; 266: netstandard.dll => 330
	i64 u0x434c4e1d9284cdae, ; 267: Mono.Android.dll => 334
	i64 u0x43950f84de7cc79a, ; 268: pl/Microsoft.Maui.Controls.resources.dll => 59
	i64 u0x44390bf51172cd08, ; 269: lib_Microsoft.AspNetCore.Components.Authorization.dll.so => 108
	i64 u0x448bd33429269b19, ; 270: Microsoft.CSharp => 228
	i64 u0x4499fa3c8e494654, ; 271: lib_System.Runtime.Serialization.Primitives.dll.so => 298
	i64 u0x4515080865a951a5, ; 272: Xamarin.Kotlin.StdLib.dll => 221
	i64 u0x453c1277f85cf368, ; 273: lib_Microsoft.EntityFrameworkCore.Abstractions.dll.so => 127
	i64 u0x458d2df79ac57c1d, ; 274: lib_System.IdentityModel.Tokens.Jwt.dll.so => 184
	i64 u0x45c40276a42e283e, ; 275: System.Diagnostics.TraceSource => 247
	i64 u0x45d443f2a29adc37, ; 276: System.AppContext.dll => 230
	i64 u0x45fcc9fd66f25095, ; 277: Microsoft.Extensions.DependencyModel => 139
	i64 u0x463d680a1dec0810, ; 278: System.Security.Cryptography.Xml.dll => 191
	i64 u0x4648b079f360842e, ; 279: itext.bouncy-castle-adapter => 103
	i64 u0x46a4213bc97fe5ae, ; 280: lib-ru-Microsoft.Maui.Controls.resources.dll.so => 63
	i64 u0x47358bd471172e1d, ; 281: lib_System.Xml.Linq.dll.so => 324
	i64 u0x475461b41cd2bae5, ; 282: lib-zh-Hant-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 25
	i64 u0x4787a936949fcac2, ; 283: System.Memory.Data.dll => 187
	i64 u0x47daf4e1afbada10, ; 284: pt/Microsoft.Maui.Controls.resources => 61
	i64 u0x47e8117e59d06a85, ; 285: ru/Microsoft.CodeAnalysis.VisualBasic.resources => 35
	i64 u0x480c0a47dd42dd81, ; 286: lib_System.IO.MemoryMappedFiles.dll.so => 258
	i64 u0x48e9c8e5d5e8555a, ; 287: DocumentFormat.OpenXml.dll => 82
	i64 u0x49e952f19a4e2022, ; 288: System.ObjectModel => 278
	i64 u0x49f61f655a6a21de, ; 289: Microsoft.Extensions.Localization.Abstractions.dll => 151
	i64 u0x4a11cac2f67d0c05, ; 290: Blazored.LocalStorage => 78
	i64 u0x4a1afd3bf9c69c98, ; 291: fr/Microsoft.CodeAnalysis.resources => 3
	i64 u0x4a5667b2462a664b, ; 292: lib_Xamarin.AndroidX.Navigation.UI.dll.so => 214
	i64 u0x4ab74cf6fbc69f3b, ; 293: Microsoft.AspNetCore.Components.QuickGrid => 111
	i64 u0x4b07a0ed0ab33ff4, ; 294: System.Runtime.Extensions.dll => 290
	i64 u0x4b484a0d637947d7, ; 295: lib-zh-Hans-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 24
	i64 u0x4b558744a6e1abe0, ; 296: lib-de-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 14
	i64 u0x4b576d47ac054f3c, ; 297: System.IO.FileSystem.AccessControl => 255
	i64 u0x4b7b6532ded934b7, ; 298: System.Text.Json => 193
	i64 u0x4b8f8ea3c2df6bb0, ; 299: System.ClientModel => 179
	i64 u0x4c30c8a4317f8c2f, ; 300: lib-fr-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 29
	i64 u0x4c69a4a1b905a70e, ; 301: ClosedXML.Parser.dll => 81
	i64 u0x4c7755cf07ad2d5f, ; 302: System.Net.Http.Json.dll => 265
	i64 u0x4ca014ceac582c86, ; 303: Microsoft.EntityFrameworkCore.Relational.dll => 128
	i64 u0x4cc5f15266470798, ; 304: lib_Xamarin.AndroidX.Loader.dll.so => 210
	i64 u0x4cf6f67dc77aacd2, ; 305: System.Net.NetworkInformation.dll => 268
	i64 u0x4d343a9e3a12e594, ; 306: AutoMapper.dll => 74
	i64 u0x4d479f968a05e504, ; 307: System.Linq.Expressions.dll => 260
	i64 u0x4d55a010ffc4faff, ; 308: System.Private.Xml => 282
	i64 u0x4d6001db23f8cd87, ; 309: lib_System.ClientModel.dll.so => 179
	i64 u0x4d95fccc1f67c7ca, ; 310: System.Runtime.Loader.dll => 294
	i64 u0x4dcf44c3c9b076a2, ; 311: it/Microsoft.Maui.Controls.resources.dll => 53
	i64 u0x4dd9247f1d2c3235, ; 312: Xamarin.AndroidX.Loader.dll => 210
	i64 u0x4df510084e2a0bae, ; 313: Microsoft.JSInterop => 166
	i64 u0x4e32f00cb0937401, ; 314: Mono.Android.Runtime => 333
	i64 u0x4e3369190c3dcd08, ; 315: Microsoft.Extensions.Identity.Stores => 149
	i64 u0x4e5eea4668ac2b18, ; 316: System.Text.Encoding.CodePages => 311
	i64 u0x4e84220084ab2d20, ; 317: cs/Microsoft.CodeAnalysis.CSharp.resources.dll => 13
	i64 u0x4e982534d67b56ba, ; 318: lib_itext.io.dll.so => 95
	i64 u0x4ebd0c4b82c5eefc, ; 319: lib_System.Threading.Channels.dll.so => 314
	i64 u0x4ef2a044e31c8432, ; 320: QRCoder.dll => 176
	i64 u0x4f21ee6ef9eb527e, ; 321: ca/Microsoft.Maui.Controls.resources => 40
	i64 u0x4fbc57e20df1874a, ; 322: itext.io.dll => 95
	i64 u0x4fdc964ec1888e25, ; 323: lib_Microsoft.Extensions.Configuration.Binder.dll.so => 134
	i64 u0x4ffd65baff757598, ; 324: Microsoft.IdentityModel.Tokens => 164
	i64 u0x5037f0be3c28c7a3, ; 325: lib_Microsoft.Maui.Controls.dll.so => 167
	i64 u0x50c3a29b21050d45, ; 326: System.Linq.Parallel.dll => 261
	i64 u0x5116b21580ae6eb0, ; 327: Microsoft.Extensions.Configuration.Binder.dll => 134
	i64 u0x512c33621dd468cb, ; 328: lib_itext.kernel.dll.so => 96
	i64 u0x5131bbe80989093f, ; 329: Xamarin.AndroidX.Lifecycle.ViewModel.Android.dll => 208
	i64 u0x51b504c7121b6136, ; 330: lib_Microsoft.CodeAnalysis.VisualBasic.dll.so => 123
	i64 u0x51bb8a2afe774e32, ; 331: System.Drawing => 250
	i64 u0x526ce79eb8e90527, ; 332: lib_System.Net.Primitives.dll.so => 269
	i64 u0x527497f521875686, ; 333: Microsoft.AspNetCore.Http.Abstractions => 116
	i64 u0x52829f00b4467c38, ; 334: lib_System.Data.Common.dll.so => 242
	i64 u0x529e5a460e733af4, ; 335: lib_itext.sign.dll.so => 100
	i64 u0x529ffe06f39ab8db, ; 336: Xamarin.AndroidX.Core => 201
	i64 u0x52ff996554dbf352, ; 337: Microsoft.Maui.Graphics => 171
	i64 u0x533514f6711b299b, ; 338: ko/Microsoft.CodeAnalysis.CSharp.resources => 19
	i64 u0x535ac0178e8b896d, ; 339: it/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 30
	i64 u0x535f7e40e8fef8af, ; 340: lib-sk-Microsoft.Maui.Controls.resources.dll.so => 64
	i64 u0x53978aac584c666e, ; 341: lib_System.Security.Cryptography.Cng.dll.so => 304
	i64 u0x53a96d5c86c9e194, ; 342: System.Net.NetworkInformation => 268
	i64 u0x53be1038a61e8d44, ; 343: System.Runtime.InteropServices.RuntimeInformation.dll => 291
	i64 u0x53c3014b9437e684, ; 344: lib-zh-HK-Microsoft.Maui.Controls.resources.dll.so => 70
	i64 u0x53d666fa678b6cea, ; 345: Microsoft.DotNet.PlatformAbstractions => 125
	i64 u0x5435e6f049e9bc37, ; 346: System.Security.Claims.dll => 302
	i64 u0x54795225dd1587af, ; 347: lib_System.Runtime.dll.so => 300
	i64 u0x54d75f85d6578cff, ; 348: lib-fr-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 16
	i64 u0x5569d981ec423b61, ; 349: lib_FastReport.Compat.dll.so => 89
	i64 u0x556e8b63b660ab8b, ; 350: Xamarin.AndroidX.Lifecycle.Common.Jvm.dll => 206
	i64 u0x5588627c9a108ec9, ; 351: System.Collections.Specialized => 235
	i64 u0x56442b99bc64bb47, ; 352: System.Runtime.Serialization.Xml.dll => 299
	i64 u0x56706494835116c0, ; 353: FastReport => 90
	i64 u0x57100d2f2e14b56d, ; 354: MudBlazor => 174
	i64 u0x571c5cfbec5ae8e2, ; 355: System.Private.Uri => 280
	i64 u0x5724fbe6b45b7f07, ; 356: lib-pt-BR-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 21
	i64 u0x579a06fed6eec900, ; 357: System.Private.CoreLib.dll => 331
	i64 u0x57c542c14049b66d, ; 358: System.Diagnostics.DiagnosticSource => 182
	i64 u0x581a8bd5cfda563e, ; 359: System.Threading.Timer => 320
	i64 u0x584ac38e21d2fde1, ; 360: Microsoft.Extensions.Configuration.Binder => 134
	i64 u0x58601b2dda4a27b9, ; 361: lib-ja-Microsoft.Maui.Controls.resources.dll.so => 54
	i64 u0x58688d9af496b168, ; 362: Microsoft.Extensions.DependencyInjection.dll => 137
	i64 u0x58ef0576630aa114, ; 363: fr/Microsoft.CodeAnalysis.CSharp.resources => 16
	i64 u0x595a356d23e8da9a, ; 364: lib_Microsoft.CSharp.dll.so => 228
	i64 u0x59fdf9beef2adee8, ; 365: lib_Blazored.LocalStorage.dll.so => 78
	i64 u0x5a70033ca9d003cb, ; 366: lib_System.Memory.Data.dll.so => 187
	i64 u0x5a89a886ae30258d, ; 367: lib_Xamarin.AndroidX.CoordinatorLayout.dll.so => 200
	i64 u0x5a8f6699f4a1caa9, ; 368: lib_System.Threading.dll.so => 321
	i64 u0x5ae9cd33b15841bf, ; 369: System.ComponentModel => 240
	i64 u0x5b54391bdc6fcfe6, ; 370: System.Private.DataContractSerialization => 279
	i64 u0x5b5f0e240a06a2a2, ; 371: da/Microsoft.Maui.Controls.resources.dll => 42
	i64 u0x5bb93c3ef9525c89, ; 372: es/Microsoft.CodeAnalysis.resources => 2
	i64 u0x5be34cb3cc2ff949, ; 373: tr/Microsoft.CodeAnalysis.CSharp.resources => 23
	i64 u0x5bf46332cc09e9b2, ; 374: lib_System.Data.SqlClient.dll.so => 181
	i64 u0x5c393624b8176517, ; 375: lib_Microsoft.Extensions.Logging.dll.so => 152
	i64 u0x5c6724284a5e7317, ; 376: lib-tr-Microsoft.CodeAnalysis.resources.dll.so => 10
	i64 u0x5d0a4a29b02d9d3c, ; 377: System.Net.WebHeaderCollection.dll => 275
	i64 u0x5d25ef991dd9a85c, ; 378: Microsoft.AspNetCore.Components.WebView.Maui.dll => 114
	i64 u0x5d7ec76c1c703055, ; 379: System.Threading.Tasks.Parallel => 316
	i64 u0x5db0cbbd1028510e, ; 380: lib_System.Runtime.InteropServices.dll.so => 292
	i64 u0x5db30905d3e5013b, ; 381: Xamarin.AndroidX.Collection.Jvm.dll => 199
	i64 u0x5e467bc8f09ad026, ; 382: System.Collections.Specialized.dll => 235
	i64 u0x5ea92fdb19ec8c4c, ; 383: System.Text.Encodings.Web.dll => 192
	i64 u0x5eb8046dd40e9ac3, ; 384: System.ComponentModel.Primitives => 238
	i64 u0x5ec272d219c9aba4, ; 385: System.Security.Cryptography.Csp.dll => 305
	i64 u0x5f36ccf5c6a57e24, ; 386: System.Xml.ReaderWriter.dll => 325
	i64 u0x5f4294b9b63cb842, ; 387: System.Data.Common => 242
	i64 u0x5f9a2d823f664957, ; 388: lib-el-Microsoft.Maui.Controls.resources.dll.so => 44
	i64 u0x5fac98e0b37a5b9d, ; 389: System.Runtime.CompilerServices.Unsafe.dll => 289
	i64 u0x609f4b7b63d802d4, ; 390: lib_Microsoft.Extensions.DependencyInjection.dll.so => 137
	i64 u0x60cd4e33d7e60134, ; 391: Xamarin.KotlinX.Coroutines.Core.Jvm => 222
	i64 u0x60f62d786afcf130, ; 392: System.Memory => 264
	i64 u0x61a3b9f0f15a3269, ; 393: lib_SixLabors.Fonts.dll.so => 178
	i64 u0x61be8d1299194243, ; 394: Microsoft.Maui.Controls.Xaml => 168
	i64 u0x61d2cba29557038f, ; 395: de/Microsoft.Maui.Controls.resources => 43
	i64 u0x61d88f399afb2f45, ; 396: lib_System.Runtime.Loader.dll.so => 294
	i64 u0x622eef6f9e59068d, ; 397: System.Private.CoreLib => 331
	i64 u0x624bd1ffe017c7dd, ; 398: ja/Microsoft.CodeAnalysis.VisualBasic.resources => 31
	i64 u0x636a5a6ff01a6ab1, ; 399: Blazor-ApexCharts.dll => 77
	i64 u0x637320c71840c561, ; 400: lib_itext.pdfa.dll.so => 98
	i64 u0x63f1f6883c1e23c2, ; 401: lib_System.Collections.Immutable.dll.so => 233
	i64 u0x6400f68068c1e9f1, ; 402: Xamarin.Google.Android.Material.dll => 220
	i64 u0x640e3b14dbd325c2, ; 403: System.Security.Cryptography.Algorithms.dll => 303
	i64 u0x65d8ddec9a3de89e, ; 404: ru/Microsoft.CodeAnalysis.resources => 9
	i64 u0x65ecac39144dd3cc, ; 405: Microsoft.Maui.Controls.dll => 167
	i64 u0x65ece51227bfa724, ; 406: lib_System.Runtime.Numerics.dll.so => 295
	i64 u0x65f3d03bf2e2a81c, ; 407: MailKit => 105
	i64 u0x6668e5c50e448662, ; 408: EPPlus => 84
	i64 u0x6692e924eade1b29, ; 409: lib_System.Console.dll.so => 241
	i64 u0x66a4e5c6a3fb0bae, ; 410: lib_Xamarin.AndroidX.Lifecycle.ViewModel.Android.dll.so => 208
	i64 u0x66ad21286ac74b9d, ; 411: lib_System.Drawing.Common.dll.so => 183
	i64 u0x66d13304ce1a3efa, ; 412: Xamarin.AndroidX.CursorAdapter => 202
	i64 u0x66e4cefe10a944cb, ; 413: lib-cs-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 26
	i64 u0x677805927d4b2e9f, ; 414: Microsoft.AspNetCore.Components.Authorization.dll => 108
	i64 u0x68558ec653afa616, ; 415: lib-da-Microsoft.Maui.Controls.resources.dll.so => 42
	i64 u0x6857d56b8e8b4bb6, ; 416: lib_Microsoft.AspNetCore.Metadata.dll.so => 119
	i64 u0x6872ec7a2e36b1ac, ; 417: System.Drawing.Primitives.dll => 249
	i64 u0x68fbbbe2eb455198, ; 418: System.Formats.Asn1 => 251
	i64 u0x69063fc0ba8e6bdd, ; 419: he/Microsoft.Maui.Controls.resources.dll => 48
	i64 u0x69c43767b6624bb2, ; 420: pl/Microsoft.CodeAnalysis.CSharp.resources => 20
	i64 u0x6a4d7577b2317255, ; 421: System.Runtime.InteropServices.dll => 292
	i64 u0x6abfbfb2796f4e84, ; 422: Microsoft.CodeAnalysis.CSharp => 122
	i64 u0x6ace3b74b15ee4a4, ; 423: nb/Microsoft.Maui.Controls.resources => 57
	i64 u0x6c46bd19605219e3, ; 424: Microsoft.Extensions.Localization => 150
	i64 u0x6cd97f370311a542, ; 425: Microsoft.EntityFrameworkCore.SqlServer => 129
	i64 u0x6d0a12b2adba20d8, ; 426: System.Security.Cryptography.ProtectedData.dll => 190
	i64 u0x6d12bfaa99c72b1f, ; 427: lib_Microsoft.Maui.Graphics.dll.so => 171
	i64 u0x6d79993361e10ef2, ; 428: Microsoft.Extensions.Primitives => 156
	i64 u0x6d7e435d96a16ed3, ; 429: lib-ja-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 31
	i64 u0x6d86d56b84c8eb71, ; 430: lib_Xamarin.AndroidX.CursorAdapter.dll.so => 202
	i64 u0x6d9bea6b3e895cf7, ; 431: Microsoft.Extensions.Primitives.dll => 156
	i64 u0x6e25a02c3833319a, ; 432: lib_Xamarin.AndroidX.Navigation.Fragment.dll.so => 212
	i64 u0x6e2fb2ace98ab808, ; 433: zh-Hant/Microsoft.CodeAnalysis.CSharp.resources => 25
	i64 u0x6e511d2129714cb7, ; 434: lib_FastReport.dll.so => 90
	i64 u0x6fd2265da78b93a4, ; 435: lib_Microsoft.Maui.dll.so => 169
	i64 u0x6fdfc7de82c33008, ; 436: cs/Microsoft.Maui.Controls.resources => 41
	i64 u0x6ffc4967cc47ba57, ; 437: System.IO.FileSystem.Watcher.dll => 256
	i64 u0x701cd46a1c25a5fe, ; 438: System.IO.FileSystem.dll => 257
	i64 u0x7078c940a89ab2ee, ; 439: ja/Microsoft.CodeAnalysis.CSharp.resources => 18
	i64 u0x70e99f48c05cb921, ; 440: tr/Microsoft.Maui.Controls.resources.dll => 67
	i64 u0x70fd3deda22442d2, ; 441: lib-nb-Microsoft.Maui.Controls.resources.dll.so => 57
	i64 u0x717530326f808838, ; 442: lib_Microsoft.Extensions.Diagnostics.Abstractions.dll.so => 141
	i64 u0x71a495ea3761dde8, ; 443: lib-it-Microsoft.Maui.Controls.resources.dll.so => 53
	i64 u0x71ad672adbe48f35, ; 444: System.ComponentModel.Primitives.dll => 238
	i64 u0x71bc142d620e986a, ; 445: lib_System.Security.Cryptography.Pkcs.dll.so => 189
	i64 u0x725f5a9e82a45c81, ; 446: System.Security.Cryptography.Encoding => 306
	i64 u0x72b1fb4109e08d7b, ; 447: lib-hr-Microsoft.Maui.Controls.resources.dll.so => 50
	i64 u0x72e0300099accce1, ; 448: System.Xml.XPath.XDocument => 327
	i64 u0x73a2b85f84dcec96, ; 449: lib_DocumentFormat.OpenXml.dll.so => 82
	i64 u0x73e4ce94e2eb6ffc, ; 450: lib_System.Memory.dll.so => 264
	i64 u0x7465c42afc9ef57e, ; 451: Microsoft.AspNetCore.Identity.EntityFrameworkCore => 118
	i64 u0x746cf89b511b4d40, ; 452: lib_Microsoft.Extensions.Diagnostics.dll.so => 140
	i64 u0x755a91767330b3d4, ; 453: lib_Microsoft.Extensions.Configuration.dll.so => 132
	i64 u0x75f59536ad2b55b1, ; 454: SixLabors.Fonts => 178
	i64 u0x76012e7334db86e5, ; 455: lib_Xamarin.AndroidX.SavedState.dll.so => 216
	i64 u0x76ca07b878f44da0, ; 456: System.Runtime.Numerics.dll => 295
	i64 u0x778a805e625329ef, ; 457: System.Linq.Parallel => 261
	i64 u0x779f67ad3b8efbd5, ; 458: Microsoft.Extensions.Configuration.Json.dll => 136
	i64 u0x77f8a4acc2fdc449, ; 459: System.Security.Cryptography.Cng.dll => 304
	i64 u0x780bc73597a503a9, ; 460: lib-ms-Microsoft.Maui.Controls.resources.dll.so => 56
	i64 u0x783606d1e53e7a1a, ; 461: th/Microsoft.Maui.Controls.resources.dll => 66
	i64 u0x7888c8518f32343b, ; 462: tr/Microsoft.CodeAnalysis.resources.dll => 10
	i64 u0x78a45e51311409b6, ; 463: Xamarin.AndroidX.Fragment.dll => 205
	i64 u0x7996e32deaf72986, ; 464: Microsoft.CodeAnalysis.CSharp.dll => 122
	i64 u0x7a25bdb29108c6e7, ; 465: Microsoft.Extensions.Http => 147
	i64 u0x7a316882bd085c35, ; 466: ExcelNumberFormat.dll => 88
	i64 u0x7a71889545dcdb00, ; 467: lib_Microsoft.AspNetCore.Components.WebView.dll.so => 113
	i64 u0x7a9a57d43b0845fa, ; 468: System.AppContext => 230
	i64 u0x7ac0a81f520b3f87, ; 469: ja/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 31
	i64 u0x7adb8da2ac89b647, ; 470: fi/Microsoft.Maui.Controls.resources.dll => 46
	i64 u0x7b4927e421291c41, ; 471: Microsoft.IdentityModel.JsonWebTokens.dll => 160
	i64 u0x7bef86a4335c4870, ; 472: System.ComponentModel.TypeConverter => 239
	i64 u0x7c0820144cd34d6a, ; 473: sk/Microsoft.Maui.Controls.resources.dll => 64
	i64 u0x7c2a0bd1e0f988fc, ; 474: lib-de-Microsoft.Maui.Controls.resources.dll.so => 43
	i64 u0x7c41d387501568ba, ; 475: System.Net.WebClient.dll => 274
	i64 u0x7c4867f3cb880d2f, ; 476: Microsoft.AspNetCore.Metadata => 119
	i64 u0x7d4d18569897ec74, ; 477: lib-ru-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 35
	i64 u0x7d649b75d580bb42, ; 478: ms/Microsoft.Maui.Controls.resources.dll => 56
	i64 u0x7d8b5821548f89e7, ; 479: Microsoft.AspNetCore.Components.Forms => 110
	i64 u0x7d8ee2bdc8e3aad1, ; 480: System.Numerics.Vectors => 277
	i64 u0x7dc2a070ce60a1e2, ; 481: itext.bouncy-castle-connector.dll => 93
	i64 u0x7dfc3d6d9d8d7b70, ; 482: System.Collections => 236
	i64 u0x7e1f8f575a3599cb, ; 483: BouncyCastle.Cryptography.dll => 79
	i64 u0x7e2e564fa2f76c65, ; 484: lib_System.Diagnostics.Tracing.dll.so => 248
	i64 u0x7e302e110e1e1346, ; 485: lib_System.Security.Claims.dll.so => 302
	i64 u0x7e4084a672f9c30e, ; 486: lib_System.Security.Cryptography.Xml.dll.so => 191
	i64 u0x7e946809d6008ef2, ; 487: lib_System.ObjectModel.dll.so => 278
	i64 u0x7ebe6126501e1198, ; 488: Microsoft.AspNetCore.Cryptography.KeyDerivation.dll => 115
	i64 u0x7ecc13347c8fd849, ; 489: lib_System.ComponentModel.dll.so => 240
	i64 u0x7eff369f2e01cf95, ; 490: Microsoft.AspNetCore.Http.Features => 117
	i64 u0x7f00ddd9b9ca5a13, ; 491: Xamarin.AndroidX.ViewPager.dll => 218
	i64 u0x7f79b1b43252ead7, ; 492: ko/Microsoft.CodeAnalysis.VisualBasic.resources => 32
	i64 u0x7f9351cd44b1273f, ; 493: Microsoft.Extensions.Configuration.Abstractions => 133
	i64 u0x7fae0ef4dc4770fe, ; 494: Microsoft.Identity.Client => 157
	i64 u0x7fbd557c99b3ce6f, ; 495: lib_Xamarin.AndroidX.Lifecycle.LiveData.Core.dll.so => 207
	i64 u0x8052dc0289c3c90a, ; 496: lib_ClosedXML.dll.so => 80
	i64 u0x80da183a87731838, ; 497: System.Reflection.Metadata => 286
	i64 u0x80ee53ea610b3f78, ; 498: zh-Hans/Microsoft.CodeAnalysis.CSharp.resources => 24
	i64 u0x8101a73bd4533440, ; 499: Microsoft.AspNetCore.Components.Web => 112
	i64 u0x812c069d5cdecc17, ; 500: System.dll => 329
	i64 u0x8148a1fb34fceb7c, ; 501: Microsoft.Extensions.Localization.Abstractions => 151
	i64 u0x81ab745f6c0f5ce6, ; 502: zh-Hant/Microsoft.Maui.Controls.resources => 72
	i64 u0x825325aa3aca4199, ; 503: lib_Microsoft.AspNetCore.Components.DataAnnotations.Validation.dll.so => 109
	i64 u0x8277f2be6b5ce05f, ; 504: Xamarin.AndroidX.AppCompat => 195
	i64 u0x828f06563b30bc50, ; 505: lib_Xamarin.AndroidX.CardView.dll.so => 198
	i64 u0x82df8f5532a10c59, ; 506: lib_System.Drawing.dll.so => 250
	i64 u0x82f6403342e12049, ; 507: uk/Microsoft.Maui.Controls.resources => 68
	i64 u0x833edc738697d898, ; 508: itext.layout.dll => 97
	i64 u0x8350268f9d350eec, ; 509: itext.commons => 104
	i64 u0x83a7afd2c49adc86, ; 510: lib_Microsoft.IdentityModel.Abstractions.dll.so => 159
	i64 u0x83c14ba66c8e2b8c, ; 511: zh-Hans/Microsoft.Maui.Controls.resources => 71
	i64 u0x83de69860da6cbdd, ; 512: Microsoft.Extensions.FileProviders.Composite => 143
	i64 u0x846ce984efea52c7, ; 513: System.Threading.Tasks.Parallel.dll => 316
	i64 u0x84ae73148a4557d2, ; 514: lib_System.IO.Pipes.dll.so => 259
	i64 u0x84b01102c12a9232, ; 515: System.Runtime.Serialization.Json.dll => 297
	i64 u0x84cd5cdec0f54bcc, ; 516: lib_Microsoft.EntityFrameworkCore.Relational.dll.so => 128
	i64 u0x85c9e4faac2839af, ; 517: Blazor-ApexCharts => 77
	i64 u0x86a909228dc7657b, ; 518: lib-zh-Hant-Microsoft.Maui.Controls.resources.dll.so => 72
	i64 u0x86b3e00c36b84509, ; 519: Microsoft.Extensions.Configuration.dll => 132
	i64 u0x86b62cb077ec4fd7, ; 520: System.Runtime.Serialization.Xml => 299
	i64 u0x8704193f462e892e, ; 521: lib_Microsoft.Extensions.FileSystemGlobbing.dll.so => 146
	i64 u0x87c4b8a492b176ad, ; 522: Microsoft.EntityFrameworkCore.Abstractions => 127
	i64 u0x87c69b87d9283884, ; 523: lib_System.Threading.Thread.dll.so => 318
	i64 u0x87d6cb5c641c5f07, ; 524: Microsoft.AspNetCore.Http.Abstractions.dll => 116
	i64 u0x87f6569b25707834, ; 525: System.IO.Compression.Brotli.dll => 253
	i64 u0x8842b3a5d2d3fb36, ; 526: Microsoft.Maui.Essentials => 170
	i64 u0x88826e51a5d4a3d0, ; 527: de/Microsoft.CodeAnalysis.resources.dll => 1
	i64 u0x88bda98e0cffb7a9, ; 528: lib_Xamarin.KotlinX.Coroutines.Core.Jvm.dll.so => 222
	i64 u0x8930322c7bd8f768, ; 529: netstandard => 330
	i64 u0x897a606c9e39c75f, ; 530: lib_System.ComponentModel.Primitives.dll.so => 238
	i64 u0x89a43fbe4c711c49, ; 531: lib_Microsoft.AspNetCore.Components.QuickGrid.dll.so => 111
	i64 u0x89c5188089ec2cd5, ; 532: lib_System.Runtime.InteropServices.RuntimeInformation.dll.so => 291
	i64 u0x8a14bf4400a024af, ; 533: lib_Microsoft.AspNetCore.Http.Features.dll.so => 117
	i64 u0x8a399a706fcbce4b, ; 534: Microsoft.Extensions.Caching.Abstractions => 130
	i64 u0x8ad229ea26432ee2, ; 535: Xamarin.AndroidX.Loader => 210
	i64 u0x8aed8bcfab24aa6d, ; 536: itext.svg => 102
	i64 u0x8b4ff5d0fdd5faa1, ; 537: lib_System.Diagnostics.DiagnosticSource.dll.so => 182
	i64 u0x8b541d476eb3774c, ; 538: System.Security.Principal.Windows => 310
	i64 u0x8b8d01333a96d0b5, ; 539: System.Diagnostics.Process.dll => 244
	i64 u0x8b9ceca7acae3451, ; 540: lib-he-Microsoft.Maui.Controls.resources.dll.so => 48
	i64 u0x8bad44d94f1833df, ; 541: V.SMART.Shared.dll => 226
	i64 u0x8c39b02ed181787b, ; 542: pt-BR/Microsoft.CodeAnalysis.CSharp.resources => 21
	i64 u0x8c53ae18581b14f0, ; 543: Azure.Core => 75
	i64 u0x8c575135aa1ccef4, ; 544: Microsoft.Extensions.FileProviders.Abstractions => 142
	i64 u0x8cdfdb4ce85fb925, ; 545: lib_System.Security.Principal.Windows.dll.so => 310
	i64 u0x8cf51f1eb9e90658, ; 546: lib_Microsoft.EntityFrameworkCore.SqlServer.dll.so => 129
	i64 u0x8d0f420977c2c1c7, ; 547: Xamarin.AndroidX.CursorAdapter.dll => 202
	i64 u0x8d51b8b8077b45db, ; 548: FastReport.Compat => 89
	i64 u0x8d7b8ab4b3310ead, ; 549: System.Threading => 321
	i64 u0x8da188285aadfe8e, ; 550: System.Collections.Concurrent => 232
	i64 u0x8e10aa836d236cb3, ; 551: RBush.dll => 177
	i64 u0x8e937db395a74375, ; 552: lib_Microsoft.Identity.Client.dll.so => 157
	i64 u0x8ec6e06a61c1baeb, ; 553: lib_Newtonsoft.Json.dll.so => 175
	i64 u0x8ed807bfe9858dfc, ; 554: Xamarin.AndroidX.Navigation.Common => 211
	i64 u0x8ee08b8194a30f48, ; 555: lib-hi-Microsoft.Maui.Controls.resources.dll.so => 49
	i64 u0x8ef7601039857a44, ; 556: lib-ro-Microsoft.Maui.Controls.resources.dll.so => 62
	i64 u0x8f32c6f611f6ffab, ; 557: pt/Microsoft.Maui.Controls.resources.dll => 61
	i64 u0x8f8829d21c8985a4, ; 558: lib-pt-BR-Microsoft.Maui.Controls.resources.dll.so => 60
	i64 u0x8f8b0f07edd7b3b6, ; 559: cs/Microsoft.CodeAnalysis.resources.dll => 0
	i64 u0x8fa404e6277d0694, ; 560: zh-Hans/Microsoft.CodeAnalysis.CSharp.resources.dll => 24
	i64 u0x8fbf5b0114c6dcef, ; 561: System.Globalization.dll => 252
	i64 u0x90263f8448b8f572, ; 562: lib_System.Diagnostics.TraceSource.dll.so => 247
	i64 u0x903101b46fb73a04, ; 563: _Microsoft.Android.Resource.Designer => 73
	i64 u0x90393bd4865292f3, ; 564: lib_System.IO.Compression.dll.so => 254
	i64 u0x905e2b8e7ae91ae6, ; 565: System.Threading.Tasks.Extensions.dll => 315
	i64 u0x90634f86c5ebe2b5, ; 566: Xamarin.AndroidX.Lifecycle.ViewModel.Android => 208
	i64 u0x907b636704ad79ef, ; 567: lib_Microsoft.Maui.Controls.Xaml.dll.so => 168
	i64 u0x90f95fc914407a17, ; 568: lib-pl-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 20
	i64 u0x91418dc638b29e68, ; 569: lib_Xamarin.AndroidX.CustomView.dll.so => 203
	i64 u0x914647982e998267, ; 570: Microsoft.Extensions.Configuration.Json => 136
	i64 u0x9157bd523cd7ed36, ; 571: lib_System.Text.Json.dll.so => 193
	i64 u0x91a74f07b30d37e2, ; 572: System.Linq.dll => 263
	i64 u0x91fa41a87223399f, ; 573: ca/Microsoft.Maui.Controls.resources.dll => 40
	i64 u0x926c3cf189fe2e18, ; 574: zh-Hans/Microsoft.CodeAnalysis.resources.dll => 11
	i64 u0x928614058c40c4cd, ; 575: lib_System.Xml.XPath.XDocument.dll.so => 327
	i64 u0x92c3fb36dbfb5378, ; 576: es/Microsoft.CodeAnalysis.VisualBasic.resources => 28
	i64 u0x93ba953181e66fd2, ; 577: lib-ru-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 22
	i64 u0x93cfa73ab28d6e35, ; 578: ms/Microsoft.Maui.Controls.resources => 56
	i64 u0x9412cedebc45df89, ; 579: lib-zh-Hant-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 38
	i64 u0x944077d8ca3c6580, ; 580: System.IO.Compression.dll => 254
	i64 u0x948d746a7702861f, ; 581: Microsoft.IdentityModel.Logging.dll => 161
	i64 u0x9502fd818eed2359, ; 582: lib_Microsoft.IdentityModel.Protocols.OpenIdConnect.dll.so => 163
	i64 u0x955d5f410b453499, ; 583: V.SMART.Shared => 226
	i64 u0x9564283c37ed59a9, ; 584: lib_Microsoft.IdentityModel.Logging.dll.so => 161
	i64 u0x95b1b6bca39c83f0, ; 585: MudBlazor.dll => 174
	i64 u0x962135b79468ba63, ; 586: zh-Hant/Microsoft.CodeAnalysis.VisualBasic.resources => 38
	i64 u0x967fc325e09bfa8c, ; 587: es/Microsoft.Maui.Controls.resources => 45
	i64 u0x96e49b31fe33d427, ; 588: Microsoft.Identity.Client.Extensions.Msal => 158
	i64 u0x9732d8dbddea3d9a, ; 589: id/Microsoft.Maui.Controls.resources => 52
	i64 u0x978be80e5210d31b, ; 590: Microsoft.Maui.Graphics.dll => 171
	i64 u0x97b8c771ea3e4220, ; 591: System.ComponentModel.dll => 240
	i64 u0x97e144c9d3c6976e, ; 592: System.Collections.Concurrent.dll => 232
	i64 u0x98270c46908e26f7, ; 593: zh-Hant/Microsoft.CodeAnalysis.CSharp.resources.dll => 25
	i64 u0x991d510397f92d9d, ; 594: System.Linq.Expressions => 260
	i64 u0x99a00ca5270c6878, ; 595: Xamarin.AndroidX.Navigation.Runtime => 213
	i64 u0x99a891b860c3d03b, ; 596: lib-ko-Microsoft.CodeAnalysis.resources.dll.so => 6
	i64 u0x99cdc6d1f2d3a72f, ; 597: ko/Microsoft.Maui.Controls.resources.dll => 55
	i64 u0x9a0cc42c6f36dfc9, ; 598: lib_Microsoft.IdentityModel.Protocols.dll.so => 162
	i64 u0x9a102e560c6efe86, ; 599: lib-pt-BR-Microsoft.CodeAnalysis.resources.dll.so => 8
	i64 u0x9a816d9654deff7c, ; 600: Microsoft.IO.RecyclableMemoryStream => 165
	i64 u0x9b211a749105beac, ; 601: System.Transactions.Local => 322
	i64 u0x9b5c51b5fc1356d8, ; 602: ru/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 35
	i64 u0x9ba8c32873c681c1, ; 603: it/Microsoft.CodeAnalysis.CSharp.resources.dll => 17
	i64 u0x9be4124ffc84e7ee, ; 604: pl/Microsoft.CodeAnalysis.resources.dll => 7
	i64 u0x9c244ac7cda32d26, ; 605: System.Security.Cryptography.X509Certificates.dll => 308
	i64 u0x9c69fdfa9a154b28, ; 606: tr/Microsoft.CodeAnalysis.CSharp.resources.dll => 23
	i64 u0x9c8f6872beab6408, ; 607: System.Xml.XPath.XDocument.dll => 327
	i64 u0x9d5dbcf5a48583fe, ; 608: lib_Xamarin.AndroidX.Activity.dll.so => 194
	i64 u0x9d74dee1a7725f34, ; 609: Microsoft.Extensions.Configuration.Abstractions.dll => 133
	i64 u0x9dcb570d9792d506, ; 610: lib-ru-Microsoft.CodeAnalysis.resources.dll.so => 9
	i64 u0x9e4534b6adaf6e84, ; 611: nl/Microsoft.Maui.Controls.resources => 58
	i64 u0x9e4b95dec42769f7, ; 612: System.Diagnostics.Debug.dll => 243
	i64 u0x9e5a208afd9d15a6, ; 613: it/Microsoft.CodeAnalysis.CSharp.resources => 17
	i64 u0x9e78e97e330a0086, ; 614: Microsoft.AspNetCore.Components.Authorization => 108
	i64 u0x9eaf1efdf6f7267e, ; 615: Xamarin.AndroidX.Navigation.Common.dll => 211
	i64 u0x9ef542cf1f78c506, ; 616: Xamarin.AndroidX.Lifecycle.LiveData.Core => 207
	i64 u0x9fbb2961ca18e5c2, ; 617: Microsoft.Extensions.FileProviders.Physical.dll => 145
	i64 u0x9ffbb6b1434ad2df, ; 618: Microsoft.Identity.Client.dll => 157
	i64 u0xa02132c49d08d9c8, ; 619: pt-BR/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 34
	i64 u0xa033e501b291e851, ; 620: itext.kernel => 96
	i64 u0xa0d8259f4cc284ec, ; 621: lib_System.Security.Cryptography.dll.so => 309
	i64 u0xa12fbfb4da97d9f3, ; 622: System.Threading.Timer.dll => 320
	i64 u0xa1440773ee9d341e, ; 623: Xamarin.Google.Android.Material => 220
	i64 u0xa1b9d7c27f47219f, ; 624: Xamarin.AndroidX.Navigation.UI.dll => 214
	i64 u0xa2572680829d2c7c, ; 625: System.IO.Pipelines.dll => 186
	i64 u0xa29741ccbc6eddf7, ; 626: lib_V.SMART.Shared.dll.so => 226
	i64 u0xa2ee39ed5e65d696, ; 627: MailKit.dll => 105
	i64 u0xa33334cc3aa07b6b, ; 628: lib-tr-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 36
	i64 u0xa3b8104115a36bf6, ; 629: lib_Microsoft.Extensions.FileProviders.Embedded.dll.so => 144
	i64 u0xa3c64c49e90a9987, ; 630: System.Security.Cryptography.Pkcs => 189
	i64 u0xa3d089b150e18d27, ; 631: pt-BR/Microsoft.CodeAnalysis.resources.dll => 8
	i64 u0xa46aa1eaa214539b, ; 632: ko/Microsoft.Maui.Controls.resources => 55
	i64 u0xa4a372eecb9e4df0, ; 633: Microsoft.Extensions.Diagnostics => 140
	i64 u0xa4e62983cf1e3674, ; 634: Microsoft.AspNetCore.Components.Forms.dll => 110
	i64 u0xa4edc8f2ceae241a, ; 635: System.Data.Common.dll => 242
	i64 u0xa526fadd66308051, ; 636: Microsoft.EntityFrameworkCore.SqlServer.dll => 129
	i64 u0xa5494f40f128ce6a, ; 637: System.Runtime.Serialization.Formatters.dll => 296
	i64 u0xa57cee8b878a32c9, ; 638: lib_FastReport.Data.MsSql.dll.so => 225
	i64 u0xa5b7152421ed6d98, ; 639: lib_System.IO.FileSystem.Watcher.dll.so => 256
	i64 u0xa5c3844f17b822db, ; 640: lib_System.Linq.Parallel.dll.so => 261
	i64 u0xa5ce5c755bde8cb8, ; 641: lib_System.Security.Cryptography.Csp.dll.so => 305
	i64 u0xa5e599d1e0524750, ; 642: System.Numerics.Vectors.dll => 277
	i64 u0xa5f1ba49b85dd355, ; 643: System.Security.Cryptography.dll => 309
	i64 u0xa60fdaa9af524b6a, ; 644: Microsoft.DotNet.PlatformAbstractions.dll => 125
	i64 u0xa61975a5a37873ea, ; 645: lib_System.Xml.XmlSerializer.dll.so => 328
	i64 u0xa62ef7f6672f2481, ; 646: de/Microsoft.CodeAnalysis.VisualBasic.resources => 27
	i64 u0xa67dbee13e1df9ca, ; 647: Xamarin.AndroidX.SavedState.dll => 216
	i64 u0xa68a420042bb9b1f, ; 648: Xamarin.AndroidX.DrawerLayout.dll => 204
	i64 u0xa6e1e2de92c957d0, ; 649: MimeKit.dll => 173
	i64 u0xa71fe7d6f6f93efd, ; 650: Microsoft.Data.SqlClient => 124
	i64 u0xa75cf331ee476318, ; 651: lib_Microsoft.AspNetCore.Http.Abstractions.dll.so => 116
	i64 u0xa763fbb98df8d9fb, ; 652: lib_Microsoft.Win32.Primitives.dll.so => 229
	i64 u0xa78ce3745383236a, ; 653: Xamarin.AndroidX.Lifecycle.Common.Jvm => 206
	i64 u0xa7c31b56b4dc7b33, ; 654: hu/Microsoft.Maui.Controls.resources => 51
	i64 u0xa82fd211eef00a5b, ; 655: Microsoft.Extensions.FileProviders.Physical => 145
	i64 u0xa8adea9b1f260c23, ; 656: lib-it-Microsoft.CodeAnalysis.resources.dll.so => 4
	i64 u0xa8e6320dd07580ef, ; 657: lib_Microsoft.IdentityModel.JsonWebTokens.dll.so => 160
	i64 u0xaa2219c8e3449ff5, ; 658: Microsoft.Extensions.Logging.Abstractions => 153
	i64 u0xaa443ac34067eeef, ; 659: System.Private.Xml.dll => 282
	i64 u0xaa52de307ef5d1dd, ; 660: System.Net.Http => 266
	i64 u0xaa9a7b0214a5cc5c, ; 661: System.Diagnostics.StackTrace.dll => 245
	i64 u0xaaaf86367285a918, ; 662: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 138
	i64 u0xaae72bd80754669a, ; 663: lib-es-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 15
	i64 u0xaaf22ea2d6123a3f, ; 664: lib_ExcelDataReader.dll.so => 86
	i64 u0xaaf84bb3f052a265, ; 665: el/Microsoft.Maui.Controls.resources => 44
	i64 u0xab9c1b2687d86b0b, ; 666: lib_System.Linq.Expressions.dll.so => 260
	i64 u0xac2af3fa195a15ce, ; 667: System.Runtime.Numerics => 295
	i64 u0xac5376a2a538dc10, ; 668: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 207
	i64 u0xac5acae88f60357e, ; 669: System.Diagnostics.Tools.dll => 246
	i64 u0xac79c7e46047ad98, ; 670: System.Security.Principal.Windows.dll => 310
	i64 u0xac98d31068e24591, ; 671: System.Xml.XDocument => 326
	i64 u0xacd46e002c3ccb97, ; 672: ro/Microsoft.Maui.Controls.resources => 62
	i64 u0xacf42eea7ef9cd12, ; 673: System.Threading.Channels => 314
	i64 u0xacf6fdf873a3ce67, ; 674: lib_itext.bouncy-castle-connector.dll.so => 93
	i64 u0xad89c07347f1bad6, ; 675: nl/Microsoft.Maui.Controls.resources.dll => 58
	i64 u0xadbb53caf78a79d2, ; 676: System.Web.HttpUtility => 323
	i64 u0xadc90ab061a9e6e4, ; 677: System.ComponentModel.TypeConverter.dll => 239
	i64 u0xadf4cf30debbeb9a, ; 678: System.Net.ServicePoint.dll => 272
	i64 u0xadf511667bef3595, ; 679: System.Net.Security => 271
	i64 u0xae031e1cb05086cb, ; 680: lib_EPPlus.Interfaces.dll.so => 85
	i64 u0xae282bcd03739de7, ; 681: Java.Interop => 332
	i64 u0xae53579c90db1107, ; 682: System.ObjectModel.dll => 278
	i64 u0xaeafff290ccb288d, ; 683: cs/Microsoft.CodeAnalysis.CSharp.resources => 13
	i64 u0xaf2e760f9c91cb86, ; 684: itext.layout => 97
	i64 u0xafe29f45095518e7, ; 685: lib_Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll.so => 209
	i64 u0xb05b6f0a6cc8ddbb, ; 686: lib_Microsoft.IO.RecyclableMemoryStream.dll.so => 165
	i64 u0xb05cc42cd94c6d9d, ; 687: lib-sv-Microsoft.Maui.Controls.resources.dll.so => 65
	i64 u0xb08b36d9a6003fae, ; 688: FastReport.dll => 90
	i64 u0xb0bb43dc52ea59f9, ; 689: System.Diagnostics.Tracing.dll => 248
	i64 u0xb0c6678edfb08a6d, ; 690: lib-es-Microsoft.CodeAnalysis.resources.dll.so => 2
	i64 u0xb110d64b6c9fbe46, ; 691: lib_Microsoft.Extensions.Identity.Core.dll.so => 148
	i64 u0xb1ccbf6243328d1c, ; 692: Microsoft.AspNetCore.Components => 107
	i64 u0xb1dd05401aa8ee63, ; 693: System.Security.AccessControl => 301
	i64 u0xb1eef5a679d400a6, ; 694: lib_ExcelDataReader.DataSet.dll.so => 87
	i64 u0xb220631954820169, ; 695: System.Text.RegularExpressions => 313
	i64 u0xb2376e1dbf8b4ed7, ; 696: System.Security.Cryptography.Csp => 305
	i64 u0xb27d64a740cc8c9c, ; 697: lib_itext.styledxmlparser.dll.so => 101
	i64 u0xb2a3f67f3bf29fce, ; 698: da/Microsoft.Maui.Controls.resources => 42
	i64 u0xb31efb7ff1c40e7a, ; 699: EPPlus.dll => 84
	i64 u0xb343b35350be6ef3, ; 700: DocumentFormat.OpenXml.Framework => 83
	i64 u0xb398860d6ed7ba2f, ; 701: System.Security.Cryptography.ProtectedData => 190
	i64 u0xb3d5b1cf730ea936, ; 702: pt-BR/Microsoft.CodeAnalysis.resources => 8
	i64 u0xb3f0a0fcda8d3ebc, ; 703: Xamarin.AndroidX.CardView => 198
	i64 u0xb46be1aa6d4fff93, ; 704: hi/Microsoft.Maui.Controls.resources => 49
	i64 u0xb477491be13109d8, ; 705: ar/Microsoft.Maui.Controls.resources => 39
	i64 u0xb4b3092fd37a579a, ; 706: ja/Microsoft.CodeAnalysis.CSharp.resources.dll => 18
	i64 u0xb4bd7015ecee9d86, ; 707: System.IO.Pipelines => 186
	i64 u0xb4c53d9749c5f226, ; 708: lib_System.IO.FileSystem.AccessControl.dll.so => 255
	i64 u0xb4c8142c581fa7a2, ; 709: itext.forms.dll => 94
	i64 u0xb50d9ae4eea71e97, ; 710: lib_Microsoft.DotNet.PlatformAbstractions.dll.so => 125
	i64 u0xb5c38bf497a4cfe2, ; 711: lib_System.Threading.Tasks.dll.so => 317
	i64 u0xb5c7fcdafbc67ee4, ; 712: Microsoft.Extensions.Logging.Abstractions.dll => 153
	i64 u0xb5ea31d5244c6626, ; 713: System.Threading.ThreadPool.dll => 319
	i64 u0xb6daa312e893d3c4, ; 714: lib-ja-Microsoft.CodeAnalysis.resources.dll.so => 5
	i64 u0xb71e58d502bd29dc, ; 715: itext.styledxmlparser.dll => 101
	i64 u0xb7212c4683a94afe, ; 716: System.Drawing.Primitives => 249
	i64 u0xb7b7753d1f319409, ; 717: sv/Microsoft.Maui.Controls.resources => 65
	i64 u0xb81a2c6e0aee50fe, ; 718: lib_System.Private.CoreLib.dll.so => 331
	i64 u0xb872c26142d22aa9, ; 719: Microsoft.Extensions.Http.dll => 147
	i64 u0xb8c60af47c08d4da, ; 720: System.Net.ServicePoint => 272
	i64 u0xb9185c33a1643eed, ; 721: Microsoft.CSharp.dll => 228
	i64 u0xb9f64d3b230def68, ; 722: lib-pt-Microsoft.Maui.Controls.resources.dll.so => 61
	i64 u0xb9fc3c8a556e3691, ; 723: ja/Microsoft.Maui.Controls.resources => 54
	i64 u0xba0f52acac7e7a84, ; 724: itext.kernel.dll => 96
	i64 u0xba4670aa94a2b3c6, ; 725: lib_System.Xml.XDocument.dll.so => 326
	i64 u0xba48785529705af9, ; 726: System.Collections.dll => 236
	i64 u0xbaf762c4825c14e9, ; 727: Microsoft.AspNetCore.Components.WebView => 113
	i64 u0xbb65706fde942ce3, ; 728: System.Net.Sockets => 273
	i64 u0xbb822a624c99bd72, ; 729: lib-zh-Hans-Microsoft.CodeAnalysis.resources.dll.so => 11
	i64 u0xbb8c8d165ef11460, ; 730: lib_Microsoft.Identity.Client.Extensions.Msal.dll.so => 158
	i64 u0xbba8707b914a6755, ; 731: AutoMapper => 74
	i64 u0xbbd180354b67271a, ; 732: System.Runtime.Serialization.Formatters => 296
	i64 u0xbc0ad520c3be6d31, ; 733: ja/Microsoft.CodeAnalysis.resources => 5
	i64 u0xbc3c4e8dffea9d4e, ; 734: Microsoft.AspNetCore.Metadata.dll => 119
	i64 u0xbc41034a90e7d095, ; 735: lib_itext.forms.dll.so => 94
	i64 u0xbcd36316d29f27b4, ; 736: lib_Microsoft.AspNetCore.Authorization.dll.so => 106
	i64 u0xbcfa7c134d2089f3, ; 737: System.Runtime.Caching => 188
	i64 u0xbd0e2c0d55246576, ; 738: System.Net.Http.dll => 266
	i64 u0xbd437a2cdb333d0d, ; 739: Xamarin.AndroidX.ViewPager2 => 219
	i64 u0xbd5d0b88d3d647a5, ; 740: lib_Xamarin.AndroidX.Browser.dll.so => 197
	i64 u0xbd7d91e34beaf455, ; 741: itext.sign.dll => 100
	i64 u0xbd877b14d0b56392, ; 742: System.Runtime.Intrinsics.dll => 293
	i64 u0xbe65a49036345cf4, ; 743: lib_System.Buffers.dll.so => 231
	i64 u0xbee1b395605474f1, ; 744: System.Drawing.Common.dll => 183
	i64 u0xbee38d4a88835966, ; 745: Xamarin.AndroidX.AppCompat.AppCompatResources => 196
	i64 u0xbf361d6b43a23bf6, ; 746: FastReport.Compat.dll => 89
	i64 u0xbfc1e1fb3095f2b3, ; 747: lib_System.Net.Http.Json.dll.so => 265
	i64 u0xbfd57e7eba42c6c7, ; 748: de/Microsoft.CodeAnalysis.CSharp.resources.dll => 14
	i64 u0xc040a4ab55817f58, ; 749: ar/Microsoft.Maui.Controls.resources.dll => 39
	i64 u0xc0d928351ab5ca77, ; 750: System.Console.dll => 241
	i64 u0xc0e73ff4e946af82, ; 751: Microsoft.CodeAnalysis.VisualBasic.dll => 123
	i64 u0xc0f5a221a9383aea, ; 752: System.Runtime.Intrinsics => 293
	i64 u0xc12b8b3afa48329c, ; 753: lib_System.Linq.dll.so => 263
	i64 u0xc1afcc0a4309f4e3, ; 754: ko/Microsoft.CodeAnalysis.resources.dll => 6
	i64 u0xc1c2cb7af77b8858, ; 755: Microsoft.EntityFrameworkCore => 126
	i64 u0xc1c31278326566f4, ; 756: lib_Blazor-ApexCharts.dll.so => 77
	i64 u0xc1d2d5e987094943, ; 757: ClosedXML => 80
	i64 u0xc1ebdc7e6a943450, ; 758: Microsoft.AspNetCore.Authorization.dll => 106
	i64 u0xc1ff9ae3cdb6e1e6, ; 759: Xamarin.AndroidX.Activity.dll => 194
	i64 u0xc2054e3663642113, ; 760: lib_ExcelNumberFormat.dll.so => 88
	i64 u0xc2260e1da1054ac1, ; 761: lib_BouncyCastle.Cryptography.dll.so => 79
	i64 u0xc256638aedbc4a74, ; 762: EPPlus.Interfaces => 85
	i64 u0xc2654c6e949f22d9, ; 763: Microsoft.AspNetCore.Identity.EntityFrameworkCore.dll => 118
	i64 u0xc26c064effb1dea9, ; 764: System.Buffers.dll => 231
	i64 u0xc278de356ad8a9e3, ; 765: Microsoft.IdentityModel.Logging => 161
	i64 u0xc28c50f32f81cc73, ; 766: ja/Microsoft.Maui.Controls.resources.dll => 54
	i64 u0xc2a3bca55b573141, ; 767: System.IO.FileSystem.Watcher => 256
	i64 u0xc2bcfec99f69365e, ; 768: Xamarin.AndroidX.ViewPager2.dll => 219
	i64 u0xc30b52815b58ac2c, ; 769: lib_System.Runtime.Serialization.Xml.dll.so => 299
	i64 u0xc3492f8f90f96ce4, ; 770: lib_Microsoft.Extensions.DependencyModel.dll.so => 139
	i64 u0xc35eda9c4f706d64, ; 771: fr/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 29
	i64 u0xc3e74964279d65e6, ; 772: zh-Hans/Microsoft.CodeAnalysis.resources => 11
	i64 u0xc3f0e03e56ce7b69, ; 773: zxing => 224
	i64 u0xc463e077917aa21d, ; 774: System.Runtime.Serialization.Json => 297
	i64 u0xc472ce300460ccb6, ; 775: Microsoft.EntityFrameworkCore.dll => 126
	i64 u0xc4d3858ed4d08512, ; 776: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 209
	i64 u0xc4d69851fe06342f, ; 777: lib_Microsoft.Extensions.Caching.Memory.dll.so => 131
	i64 u0xc50fded0ded1418c, ; 778: lib_System.ComponentModel.TypeConverter.dll.so => 239
	i64 u0xc519125d6bc8fb11, ; 779: lib_System.Net.Requests.dll.so => 270
	i64 u0xc5293b19e4dc230e, ; 780: Xamarin.AndroidX.Navigation.Fragment => 212
	i64 u0xc5325b2fcb37446f, ; 781: lib_System.Private.Xml.dll.so => 282
	i64 u0xc56a2c97d45a1f87, ; 782: it/Microsoft.CodeAnalysis.VisualBasic.resources => 30
	i64 u0xc5a0f4b95a699af7, ; 783: lib_System.Private.Uri.dll.so => 280
	i64 u0xc5cdcd5b6277579e, ; 784: lib_System.Security.Cryptography.Algorithms.dll.so => 303
	i64 u0xc659b586d4c229e2, ; 785: Microsoft.Extensions.Configuration.FileExtensions.dll => 135
	i64 u0xc6c65ca6318f6fde, ; 786: lib_System.IO.Packaging.dll.so => 185
	i64 u0xc7aa88580f6120f0, ; 787: Microsoft.CodeAnalysis.VisualBasic => 123
	i64 u0xc7c01e7d7c93a110, ; 788: System.Text.Encoding.Extensions.dll => 312
	i64 u0xc7ce851898a4548e, ; 789: lib_System.Web.HttpUtility.dll.so => 323
	i64 u0xc858a28d9ee5a6c5, ; 790: lib_System.Collections.Specialized.dll.so => 235
	i64 u0xc8629a6f7ae4f577, ; 791: ExcelDataReader.dll => 86
	i64 u0xc8f9da29a1cf7d98, ; 792: pl/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 33
	i64 u0xc99ccc413e3ce0d4, ; 793: lib_Microsoft.AspNetCore.Identity.EntityFrameworkCore.dll.so => 118
	i64 u0xca3110fea81c8916, ; 794: Microsoft.AspNetCore.Components.Web.dll => 112
	i64 u0xca32340d8d54dcd5, ; 795: Microsoft.Extensions.Caching.Memory.dll => 131
	i64 u0xca3a723e7342c5b6, ; 796: lib-tr-Microsoft.Maui.Controls.resources.dll.so => 67
	i64 u0xca52d1fc0d79af1f, ; 797: Microsoft.AspNetCore.Components.QuickGrid.dll => 111
	i64 u0xcab3493c70141c2d, ; 798: pl/Microsoft.Maui.Controls.resources => 59
	i64 u0xcacfddc9f7c6de76, ; 799: ro/Microsoft.Maui.Controls.resources.dll => 62
	i64 u0xcb45618372c47127, ; 800: Microsoft.EntityFrameworkCore.Relational => 128
	i64 u0xcb63c799ecf0cf72, ; 801: QRCoder => 176
	i64 u0xcbd4fdd9cef4a294, ; 802: lib__Microsoft.Android.Resource.Designer.dll.so => 73
	i64 u0xcc182c3afdc374d6, ; 803: Microsoft.Bcl.AsyncInterfaces => 120
	i64 u0xcc263933dd08cfd8, ; 804: ExcelDataReader.DataSet.dll => 87
	i64 u0xcc2876b32ef2794c, ; 805: lib_System.Text.RegularExpressions.dll.so => 313
	i64 u0xcc5c3bb714c4561e, ; 806: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 222
	i64 u0xcc76886e09b88260, ; 807: Xamarin.KotlinX.Serialization.Core.Jvm.dll => 223
	i64 u0xccf25c4b634ccd3a, ; 808: zh-Hans/Microsoft.Maui.Controls.resources.dll => 71
	i64 u0xcd10a42808629144, ; 809: System.Net.Requests => 270
	i64 u0xcd235365bb1cf97f, ; 810: lib_itext.svg.dll.so => 102
	i64 u0xcd3586b93136841e, ; 811: lib_System.Runtime.Caching.dll.so => 188
	i64 u0xcd8adade68221379, ; 812: lib-de-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 27
	i64 u0xcdd0c48b6937b21c, ; 813: Xamarin.AndroidX.SwipeRefreshLayout => 217
	i64 u0xceb28d385f84f441, ; 814: Azure.Core.dll => 75
	i64 u0xcf140ed700bc8e66, ; 815: Microsoft.SqlServer.Server.dll => 172
	i64 u0xcf23d8093f3ceadf, ; 816: System.Diagnostics.DiagnosticSource.dll => 182
	i64 u0xcf8fc898f98b0d34, ; 817: System.Private.Xml.Linq => 281
	i64 u0xd04b5f59ed596e31, ; 818: System.Reflection.Metadata.dll => 286
	i64 u0xd063299fcfc0c93f, ; 819: lib_System.Runtime.Serialization.Json.dll.so => 297
	i64 u0xd07a7cf02bbd9a8c, ; 820: lib_QRCoder.dll.so => 176
	i64 u0xd0af5414344dd23a, ; 821: itext.io => 95
	i64 u0xd0fc33d5ae5d4cb8, ; 822: System.Runtime.Extensions => 290
	i64 u0xd118cf03aa687fdf, ; 823: cs/Microsoft.CodeAnalysis.resources => 0
	i64 u0xd1194e1d8a8de83c, ; 824: lib_Xamarin.AndroidX.Lifecycle.Common.Jvm.dll.so => 206
	i64 u0xd16fd7fb9bbcd43e, ; 825: Microsoft.Extensions.Diagnostics.Abstractions => 141
	i64 u0xd1dcf65a5c5b2e92, ; 826: itext.pdfa => 98
	i64 u0xd22a0c4630f2fe66, ; 827: lib_System.Security.Cryptography.ProtectedData.dll.so => 190
	i64 u0xd2505d8abeed6983, ; 828: lib_Microsoft.AspNetCore.Components.Web.dll.so => 112
	i64 u0xd2d7ebaf4c12e35f, ; 829: lib_RBush.dll.so => 177
	i64 u0xd333d0af9e423810, ; 830: System.Runtime.InteropServices => 292
	i64 u0xd33a415cb4278969, ; 831: System.Security.Cryptography.Encoding.dll => 306
	i64 u0xd3426d966bb704f5, ; 832: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 196
	i64 u0xd3651b6fc3125825, ; 833: System.Private.Uri.dll => 280
	i64 u0xd373685349b1fe8b, ; 834: Microsoft.Extensions.Logging.dll => 152
	i64 u0xd3801faafafb7698, ; 835: System.Private.DataContractSerialization.dll => 279
	i64 u0xd3e4c8d6a2d5d470, ; 836: it/Microsoft.Maui.Controls.resources => 53
	i64 u0xd3edcc1f25459a50, ; 837: System.Reflection.Emit => 285
	i64 u0xd42655883bb8c19f, ; 838: Microsoft.EntityFrameworkCore.Abstractions.dll => 127
	i64 u0xd42c5e61f624b295, ; 839: ExcelNumberFormat => 88
	i64 u0xd4645626dffec99d, ; 840: lib_Microsoft.Extensions.DependencyInjection.Abstractions.dll.so => 138
	i64 u0xd46b4a8758d1f3ee, ; 841: Microsoft.Extensions.FileProviders.Composite.dll => 143
	i64 u0xd4920ac8d8d3ebf2, ; 842: lib_V.SMART.dll.so => 227
	i64 u0xd5507e11a2b2839f, ; 843: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 209
	i64 u0xd561e0267e659d4d, ; 844: ExcelDataReader => 86
	i64 u0xd567f168deeeaf3c, ; 845: lib_zxing.dll.so => 224
	i64 u0xd58b917bd3362c49, ; 846: lib-ko-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 32
	i64 u0xd58bc1ebb62d59be, ; 847: de/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 27
	i64 u0xd63b432ec9306914, ; 848: zxing.dll => 224
	i64 u0xd6694f8359737e4e, ; 849: Xamarin.AndroidX.SavedState => 216
	i64 u0xd6d21782156bc35b, ; 850: Xamarin.AndroidX.SwipeRefreshLayout.dll => 217
	i64 u0xd71fa7ed9848efec, ; 851: lib_itext.bouncy-castle-adapter.dll.so => 103
	i64 u0xd72329819cbbbc44, ; 852: lib_Microsoft.Extensions.Configuration.Abstractions.dll.so => 133
	i64 u0xd72c760af136e863, ; 853: System.Xml.XmlSerializer.dll => 328
	i64 u0xd7b3764ada9d341d, ; 854: lib_Microsoft.Extensions.Logging.Abstractions.dll.so => 153
	i64 u0xd9d25da70e7f7445, ; 855: fr/Microsoft.CodeAnalysis.VisualBasic.resources => 29
	i64 u0xd9e245a1762ddad5, ; 856: BouncyCastle.Cryptography => 79
	i64 u0xd9fc7e791253de8f, ; 857: lib_itext.commons.dll.so => 104
	i64 u0xda1dfa4c534a9251, ; 858: Microsoft.Extensions.DependencyInjection => 137
	i64 u0xdad05a11827959a3, ; 859: System.Collections.NonGeneric.dll => 234
	i64 u0xdb5383ab5865c007, ; 860: lib-vi-Microsoft.Maui.Controls.resources.dll.so => 69
	i64 u0xdb58816721c02a59, ; 861: lib_System.Reflection.Emit.ILGeneration.dll.so => 283
	i64 u0xdb9f2880a64da6d6, ; 862: Microsoft.Extensions.Identity.Stores.dll => 149
	i64 u0xdbeda89f832aa805, ; 863: vi/Microsoft.Maui.Controls.resources.dll => 69
	i64 u0xdbf2a779fbc3ac31, ; 864: System.Transactions.Local.dll => 322
	i64 u0xdbf9607a441b4505, ; 865: System.Linq => 263
	i64 u0xdc75032002d1a212, ; 866: lib_System.Transactions.Local.dll.so => 322
	i64 u0xdca8be7403f92d4f, ; 867: lib_System.Linq.Queryable.dll.so => 262
	i64 u0xdcbf1e32b739302e, ; 868: de/Microsoft.CodeAnalysis.resources => 1
	i64 u0xdce2c53525640bf3, ; 869: Microsoft.Extensions.Logging => 152
	i64 u0xdd14049e4243731e, ; 870: lib-it-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 17
	i64 u0xdd2b722d78ef5f43, ; 871: System.Runtime.dll => 300
	i64 u0xdd67031857c72f96, ; 872: lib_System.Text.Encodings.Web.dll.so => 192
	i64 u0xdde30e6b77aa6f6c, ; 873: lib-zh-Hans-Microsoft.Maui.Controls.resources.dll.so => 71
	i64 u0xde110ae80fa7c2e2, ; 874: System.Xml.XDocument.dll => 326
	i64 u0xde572c2b2fb32f93, ; 875: lib_System.Threading.Tasks.Extensions.dll.so => 315
	i64 u0xde8769ebda7d8647, ; 876: hr/Microsoft.Maui.Controls.resources.dll => 50
	i64 u0xdf5820c64c84eafc, ; 877: ClosedXML.Parser => 81
	i64 u0xdfe60c16084f6d57, ; 878: itext.pdfua.dll => 99
	i64 u0xe0142572c095a480, ; 879: Xamarin.AndroidX.AppCompat.dll => 195
	i64 u0xe02f89350ec78051, ; 880: Xamarin.AndroidX.CoordinatorLayout.dll => 200
	i64 u0xe044b6951dc0673a, ; 881: lib-pl-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 33
	i64 u0xe0795bb97a23143a, ; 882: lib-es-Microsoft.CodeAnalysis.VisualBasic.resources.dll.so => 28
	i64 u0xe10b760bb1462e7a, ; 883: lib_System.Security.Cryptography.Primitives.dll.so => 307
	i64 u0xe192a588d4410686, ; 884: lib_System.IO.Pipelines.dll.so => 186
	i64 u0xe1a08bd3fa539e0d, ; 885: System.Runtime.Loader => 294
	i64 u0xe1b52f9f816c70ef, ; 886: System.Private.Xml.Linq.dll => 281
	i64 u0xe1e852de9692e4b8, ; 887: es/Microsoft.CodeAnalysis.CSharp.resources => 15
	i64 u0xe1ecfdb7fff86067, ; 888: System.Net.Security.dll => 271
	i64 u0xe2420585aeceb728, ; 889: System.Net.Requests.dll => 270
	i64 u0xe27532f50ce5b0b1, ; 890: Microsoft.Extensions.Localization.dll => 150
	i64 u0xe29b73bc11392966, ; 891: lib-id-Microsoft.Maui.Controls.resources.dll.so => 52
	i64 u0xe2e426c7714fa0bc, ; 892: Microsoft.Win32.Primitives.dll => 229
	i64 u0xe31089e70e4e84ee, ; 893: Microsoft.AspNetCore.Components.WebView.Maui => 114
	i64 u0xe3811d68d4fe8463, ; 894: pt-BR/Microsoft.Maui.Controls.resources.dll => 60
	i64 u0xe3b7cbae5ad66c75, ; 895: lib_System.Security.Cryptography.Encoding.dll.so => 306
	i64 u0xe494f7ced4ecd10a, ; 896: hu/Microsoft.Maui.Controls.resources.dll => 51
	i64 u0xe4a9b1e40d1e8917, ; 897: lib-fi-Microsoft.Maui.Controls.resources.dll.so => 46
	i64 u0xe4f74a0b5bf9703f, ; 898: System.Runtime.Serialization.Primitives => 298
	i64 u0xe51aadb833ed7eb1, ; 899: lib_Microsoft.CodeAnalysis.CSharp.dll.so => 122
	i64 u0xe529964b351f8a52, ; 900: pt-BR/Microsoft.CodeAnalysis.CSharp.resources.dll => 21
	i64 u0xe5434e8a119ceb69, ; 901: lib_Mono.Android.dll.so => 334
	i64 u0xe55703b9ce5c038a, ; 902: System.Diagnostics.Tools => 246
	i64 u0xe57d22ca4aeb4900, ; 903: System.Configuration.ConfigurationManager => 180
	i64 u0xe67854c7d1583a34, ; 904: zh-Hans/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 37
	i64 u0xe79d45aa815dab7f, ; 905: System.Runtime.Caching.dll => 188
	i64 u0xe7b916eaefda3b00, ; 906: fr/Microsoft.CodeAnalysis.resources.dll => 3
	i64 u0xe7dd1e7ea292e8bc, ; 907: ko/Microsoft.CodeAnalysis.resources => 6
	i64 u0xe7e03cc18dcdeb49, ; 908: lib_System.Diagnostics.StackTrace.dll.so => 245
	i64 u0xe8159f0f339a522f, ; 909: lib_itext.barcodes.dll.so => 92
	i64 u0xe8397cf3948e7cb7, ; 910: lib_Microsoft.Extensions.Options.ConfigurationExtensions.dll.so => 155
	i64 u0xe896622fe0902957, ; 911: System.Reflection.Emit.dll => 285
	i64 u0xe89a2a9ef110899b, ; 912: System.Drawing.dll => 250
	i64 u0xe8ba752753127ac1, ; 913: zh-Hant/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 38
	i64 u0xe8c35a466559994c, ; 914: lib_Microsoft.Extensions.Identity.Stores.dll.so => 149
	i64 u0xe975d06779bc7baf, ; 915: SixLabors.Fonts.dll => 178
	i64 u0xe9772100456fb4b4, ; 916: Microsoft.AspNetCore.Components.dll => 107
	i64 u0xea154e342c6ac70f, ; 917: Microsoft.Extensions.FileProviders.Embedded.dll => 144
	i64 u0xea60bffa6001dd80, ; 918: Microsoft.AspNetCore.Components.DataAnnotations.Validation.dll => 109
	i64 u0xeb131f024640a977, ; 919: lib_MailKit.dll.so => 105
	i64 u0xec8abb68d340aac6, ; 920: Microsoft.AspNetCore.Authorization => 106
	i64 u0xedc4817167106c23, ; 921: System.Net.Sockets.dll => 273
	i64 u0xedc632067fb20ff3, ; 922: System.Memory.dll => 264
	i64 u0xedc8e4ca71a02a8b, ; 923: Xamarin.AndroidX.Navigation.Runtime.dll => 213
	i64 u0xee25c2570ce19192, ; 924: lib_Microsoft.Extensions.Localization.Abstractions.dll.so => 151
	i64 u0xee81f5b3f1c4f83b, ; 925: System.Threading.ThreadPool => 319
	i64 u0xeeb7ebb80150501b, ; 926: lib_Xamarin.AndroidX.Collection.Jvm.dll.so => 199
	i64 u0xeefc635595ef57f0, ; 927: System.Security.Cryptography.Cng => 304
	i64 u0xef03b1b5a04e9709, ; 928: System.Text.Encoding.CodePages.dll => 311
	i64 u0xef6e6d3ed7611955, ; 929: itext.forms => 94
	i64 u0xef72742e1bcca27a, ; 930: Microsoft.Maui.Essentials.dll => 170
	i64 u0xefd1e0c4e5c9b371, ; 931: System.Resources.ResourceManager.dll => 288
	i64 u0xefec0b7fdc57ec42, ; 932: Xamarin.AndroidX.Activity => 194
	i64 u0xf00c29406ea45e19, ; 933: es/Microsoft.Maui.Controls.resources.dll => 45
	i64 u0xf06d7b238f0af088, ; 934: cs/Microsoft.CodeAnalysis.VisualBasic.resources => 26
	i64 u0xf09e47b6ae914f6e, ; 935: System.Net.NameResolution => 267
	i64 u0xf0ac2b489fed2e35, ; 936: lib_System.Diagnostics.Debug.dll.so => 243
	i64 u0xf0bb49dadd3a1fe1, ; 937: lib_System.Net.ServicePoint.dll.so => 272
	i64 u0xf0de2537ee19c6ca, ; 938: lib_System.Net.WebHeaderCollection.dll.so => 275
	i64 u0xf11b621fc87b983f, ; 939: Microsoft.Maui.Controls.Xaml.dll => 168
	i64 u0xf1624296ce223787, ; 940: lib_ClosedXML.Parser.dll.so => 81
	i64 u0xf1c4b4005493d871, ; 941: System.Formats.Asn1.dll => 251
	i64 u0xf238bd79489d3a96, ; 942: lib-nl-Microsoft.Maui.Controls.resources.dll.so => 58
	i64 u0xf24f9a931c04fd2a, ; 943: ko/Microsoft.CodeAnalysis.VisualBasic.resources.dll => 32
	i64 u0xf27ac96c4a2c11ce, ; 944: lib-fr-Microsoft.CodeAnalysis.resources.dll.so => 3
	i64 u0xf37221fda4ef8830, ; 945: lib_Xamarin.Google.Android.Material.dll.so => 220
	i64 u0xf3cafa464e6dd7c0, ; 946: FastReport.Data.MsSql => 225
	i64 u0xf3ddfe05336abf29, ; 947: System => 329
	i64 u0xf408654b2a135055, ; 948: System.Reflection.Emit.ILGeneration.dll => 283
	i64 u0xf4103170a1de5bd0, ; 949: System.Linq.Queryable.dll => 262
	i64 u0xf41b241c82f75cde, ; 950: ru/Microsoft.CodeAnalysis.CSharp.resources.dll => 22
	i64 u0xf41eebf9fb91e2a1, ; 951: it/Microsoft.CodeAnalysis.resources.dll => 4
	i64 u0xf4c1dd70a5496a17, ; 952: System.IO.Compression => 254
	i64 u0xf518f63ead11fcd1, ; 953: System.Threading.Tasks => 317
	i64 u0xf5967aac376787d7, ; 954: Microsoft.CodeAnalysis.dll => 121
	i64 u0xf5e59d7ac34b50aa, ; 955: Microsoft.IdentityModel.Protocols.dll => 162
	i64 u0xf5fc7602fe27b333, ; 956: System.Net.WebHeaderCollection => 275
	i64 u0xf6077741019d7428, ; 957: Xamarin.AndroidX.CoordinatorLayout => 200
	i64 u0xf61ade9836ad4692, ; 958: Microsoft.IdentityModel.Tokens.dll => 164
	i64 u0xf64aa85b130b0651, ; 959: lib_DocumentFormat.OpenXml.Framework.dll.so => 83
	i64 u0xf6c0e7d55a7a4e4f, ; 960: Microsoft.IdentityModel.JsonWebTokens => 160
	i64 u0xf6de7fa3776f8927, ; 961: lib_Microsoft.Extensions.Configuration.Json.dll.so => 136
	i64 u0xf6f893f692f8cb43, ; 962: Microsoft.Extensions.Options.ConfigurationExtensions.dll => 155
	i64 u0xf7166e040fdf96f5, ; 963: lib_itext.pdfua.dll.so => 99
	i64 u0xf74bbd7c3ec878ce, ; 964: tr/Microsoft.CodeAnalysis.VisualBasic.resources => 36
	i64 u0xf77b20923f07c667, ; 965: de/Microsoft.Maui.Controls.resources.dll => 43
	i64 u0xf7be38c7938ad857, ; 966: Microsoft.AspNetCore.Cryptography.KeyDerivation => 115
	i64 u0xf7e2cac4c45067b3, ; 967: lib_System.Numerics.Vectors.dll.so => 277
	i64 u0xf7e74930e0e3d214, ; 968: zh-HK/Microsoft.Maui.Controls.resources.dll => 70
	i64 u0xf7fa0bf77fe677cc, ; 969: Newtonsoft.Json.dll => 175
	i64 u0xf84773b5c81e3cef, ; 970: lib-uk-Microsoft.Maui.Controls.resources.dll.so => 68
	i64 u0xf8aac5ea82de1348, ; 971: System.Linq.Queryable => 262
	i64 u0xf8b77539b362d3ba, ; 972: lib_System.Reflection.Primitives.dll.so => 287
	i64 u0xf8e045dc345b2ea3, ; 973: lib_Xamarin.AndroidX.RecyclerView.dll.so => 215
	i64 u0xf915dc29808193a1, ; 974: System.Web.HttpUtility.dll => 323
	i64 u0xf95306fe01fadbd0, ; 975: itext.commons.dll => 104
	i64 u0xf96c777a2a0686f4, ; 976: hi/Microsoft.Maui.Controls.resources.dll => 49
	i64 u0xf9be54c8bcf8ff3b, ; 977: System.Security.AccessControl.dll => 301
	i64 u0xf9eec5bb3a6aedc6, ; 978: Microsoft.Extensions.Options => 154
	i64 u0xfa0e82300e67f913, ; 979: lib_System.AppContext.dll.so => 230
	i64 u0xfa16a911a6d79b7f, ; 980: lib_MudBlazor.dll.so => 174
	i64 u0xfa3f278f288b0e84, ; 981: lib_System.Net.Security.dll.so => 271
	i64 u0xfa504dfa0f097d72, ; 982: Microsoft.Extensions.FileProviders.Abstractions.dll => 142
	i64 u0xfa5ed7226d978949, ; 983: lib-ar-Microsoft.Maui.Controls.resources.dll.so => 39
	i64 u0xfa645d91e9fc4cba, ; 984: System.Threading.Thread => 318
	i64 u0xfae3bcd3a0b1572a, ; 985: lib_itext.layout.dll.so => 97
	i64 u0xfbad3e4ce4b98145, ; 986: System.Security.Cryptography.X509Certificates => 308
	i64 u0xfbd71978549ea473, ; 987: Microsoft.AspNetCore.Http.Features.dll => 117
	i64 u0xfbf0a31c9fc34bc4, ; 988: lib_System.Net.Http.dll.so => 266
	i64 u0xfc6b7527cc280b3f, ; 989: lib_System.Runtime.Serialization.Formatters.dll.so => 296
	i64 u0xfc719aec26adf9d9, ; 990: Xamarin.AndroidX.Navigation.Fragment.dll => 212
	i64 u0xfcd302092ada6328, ; 991: System.IO.MemoryMappedFiles.dll => 258
	i64 u0xfcd5b90cf101e36b, ; 992: System.Data.SqlClient.dll => 181
	i64 u0xfd22f00870e40ae0, ; 993: lib_Xamarin.AndroidX.DrawerLayout.dll.so => 204
	i64 u0xfd2e866c678cac90, ; 994: lib_Microsoft.AspNetCore.Components.WebView.Maui.dll.so => 114
	i64 u0xfd49b3c1a76e2748, ; 995: System.Runtime.InteropServices.RuntimeInformation => 291
	i64 u0xfd536c702f64dc47, ; 996: System.Text.Encoding.Extensions => 312
	i64 u0xfd583f7657b6a1cb, ; 997: Xamarin.AndroidX.Fragment => 205
	i64 u0xfdd5f1451cd60110, ; 998: zh-Hans/Microsoft.CodeAnalysis.VisualBasic.resources => 37
	i64 u0xfe9856c3af9365ab, ; 999: lib_Microsoft.Extensions.Configuration.FileExtensions.dll.so => 135
	i64 u0xfeae9952cf03b8cb, ; 1000: tr/Microsoft.Maui.Controls.resources => 67
	i64 u0xfec8e01187d0178c, ; 1001: lib-ja-Microsoft.CodeAnalysis.CSharp.resources.dll.so => 18
	i64 u0xff5a9018a265ea33, ; 1002: FastReport.OpenSource.Export.PdfSimple => 91
	i64 u0xff9b54613e0d2cc8, ; 1003: System.Net.Http.Json => 265
	i64 u0xfff40914e0b38d3d ; 1004: Azure.Identity.dll => 76
], align 8

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [1005 x i32] [
	i32 252, i32 217, i32 237, i32 34, i32 213, i32 155, i32 189, i32 131,
	i32 333, i32 195, i32 165, i32 231, i32 279, i32 63, i32 41, i32 69,
	i32 159, i32 91, i32 269, i32 215, i32 236, i32 169, i32 289, i32 70,
	i32 324, i32 199, i32 107, i32 63, i32 234, i32 75, i32 287, i32 204,
	i32 101, i32 237, i32 154, i32 234, i32 187, i32 309, i32 286, i32 130,
	i32 191, i32 314, i32 87, i32 124, i32 64, i32 223, i32 115, i32 218,
	i32 60, i32 334, i32 170, i32 12, i32 148, i32 120, i32 267, i32 4,
	i32 36, i32 1, i32 120, i32 203, i32 121, i32 121, i32 253, i32 83,
	i32 307, i32 22, i32 276, i32 19, i32 284, i32 215, i32 163, i32 225,
	i32 14, i32 183, i32 197, i32 12, i32 47, i32 332, i32 48, i32 163,
	i32 138, i32 19, i32 276, i32 99, i32 23, i32 229, i32 257, i32 139,
	i32 259, i32 303, i32 330, i32 301, i32 51, i32 192, i32 223, i32 13,
	i32 274, i32 57, i32 12, i32 302, i32 103, i32 227, i32 76, i32 5,
	i32 232, i32 15, i32 329, i32 66, i32 110, i32 7, i32 140, i32 145,
	i32 333, i32 317, i32 255, i32 245, i32 214, i32 55, i32 316, i32 227,
	i32 154, i32 328, i32 148, i32 274, i32 253, i32 33, i32 244, i32 252,
	i32 84, i32 300, i32 179, i32 283, i32 66, i32 259, i32 320, i32 93,
	i32 82, i32 318, i32 126, i32 288, i32 241, i32 201, i32 9, i32 298,
	i32 47, i32 91, i32 221, i32 156, i32 184, i32 10, i32 52, i32 50,
	i32 276, i32 332, i32 243, i32 269, i32 141, i32 68, i32 268, i32 247,
	i32 100, i32 46, i32 313, i32 184, i32 251, i32 72, i32 146, i32 98,
	i32 85, i32 59, i32 311, i32 284, i32 281, i32 321, i32 65, i32 193,
	i32 7, i32 257, i32 44, i32 166, i32 74, i32 244, i32 325, i32 172,
	i32 248, i32 37, i32 130, i32 147, i32 205, i32 159, i32 173, i32 144,
	i32 30, i32 73, i32 198, i32 249, i32 0, i32 102, i32 109, i32 47,
	i32 325, i32 146, i32 233, i32 45, i32 273, i32 172, i32 143, i32 169,
	i32 41, i32 20, i32 167, i32 237, i32 219, i32 132, i32 293, i32 16,
	i32 246, i32 290, i32 284, i32 258, i32 287, i32 233, i32 289, i32 203,
	i32 267, i32 162, i32 180, i32 218, i32 40, i32 175, i32 142, i32 177,
	i32 185, i32 92, i32 307, i32 80, i32 26, i32 312, i32 166, i32 164,
	i32 173, i32 308, i32 124, i32 221, i32 197, i32 181, i32 319, i32 324,
	i32 185, i32 201, i32 135, i32 113, i32 158, i32 315, i32 211, i32 76,
	i32 2, i32 180, i32 196, i32 150, i32 92, i32 288, i32 34, i32 28,
	i32 78, i32 285, i32 330, i32 334, i32 59, i32 108, i32 228, i32 298,
	i32 221, i32 127, i32 184, i32 247, i32 230, i32 139, i32 191, i32 103,
	i32 63, i32 324, i32 25, i32 187, i32 61, i32 35, i32 258, i32 82,
	i32 278, i32 151, i32 78, i32 3, i32 214, i32 111, i32 290, i32 24,
	i32 14, i32 255, i32 193, i32 179, i32 29, i32 81, i32 265, i32 128,
	i32 210, i32 268, i32 74, i32 260, i32 282, i32 179, i32 294, i32 53,
	i32 210, i32 166, i32 333, i32 149, i32 311, i32 13, i32 95, i32 314,
	i32 176, i32 40, i32 95, i32 134, i32 164, i32 167, i32 261, i32 134,
	i32 96, i32 208, i32 123, i32 250, i32 269, i32 116, i32 242, i32 100,
	i32 201, i32 171, i32 19, i32 30, i32 64, i32 304, i32 268, i32 291,
	i32 70, i32 125, i32 302, i32 300, i32 16, i32 89, i32 206, i32 235,
	i32 299, i32 90, i32 174, i32 280, i32 21, i32 331, i32 182, i32 320,
	i32 134, i32 54, i32 137, i32 16, i32 228, i32 78, i32 187, i32 200,
	i32 321, i32 240, i32 279, i32 42, i32 2, i32 23, i32 181, i32 152,
	i32 10, i32 275, i32 114, i32 316, i32 292, i32 199, i32 235, i32 192,
	i32 238, i32 305, i32 325, i32 242, i32 44, i32 289, i32 137, i32 222,
	i32 264, i32 178, i32 168, i32 43, i32 294, i32 331, i32 31, i32 77,
	i32 98, i32 233, i32 220, i32 303, i32 9, i32 167, i32 295, i32 105,
	i32 84, i32 241, i32 208, i32 183, i32 202, i32 26, i32 108, i32 42,
	i32 119, i32 249, i32 251, i32 48, i32 20, i32 292, i32 122, i32 57,
	i32 150, i32 129, i32 190, i32 171, i32 156, i32 31, i32 202, i32 156,
	i32 212, i32 25, i32 90, i32 169, i32 41, i32 256, i32 257, i32 18,
	i32 67, i32 57, i32 141, i32 53, i32 238, i32 189, i32 306, i32 50,
	i32 327, i32 82, i32 264, i32 118, i32 140, i32 132, i32 178, i32 216,
	i32 295, i32 261, i32 136, i32 304, i32 56, i32 66, i32 10, i32 205,
	i32 122, i32 147, i32 88, i32 113, i32 230, i32 31, i32 46, i32 160,
	i32 239, i32 64, i32 43, i32 274, i32 119, i32 35, i32 56, i32 110,
	i32 277, i32 93, i32 236, i32 79, i32 248, i32 302, i32 191, i32 278,
	i32 115, i32 240, i32 117, i32 218, i32 32, i32 133, i32 157, i32 207,
	i32 80, i32 286, i32 24, i32 112, i32 329, i32 151, i32 72, i32 109,
	i32 195, i32 198, i32 250, i32 68, i32 97, i32 104, i32 159, i32 71,
	i32 143, i32 316, i32 259, i32 297, i32 128, i32 77, i32 72, i32 132,
	i32 299, i32 146, i32 127, i32 318, i32 116, i32 253, i32 170, i32 1,
	i32 222, i32 330, i32 238, i32 111, i32 291, i32 117, i32 130, i32 210,
	i32 102, i32 182, i32 310, i32 244, i32 48, i32 226, i32 21, i32 75,
	i32 142, i32 310, i32 129, i32 202, i32 89, i32 321, i32 232, i32 177,
	i32 157, i32 175, i32 211, i32 49, i32 62, i32 61, i32 60, i32 0,
	i32 24, i32 252, i32 247, i32 73, i32 254, i32 315, i32 208, i32 168,
	i32 20, i32 203, i32 136, i32 193, i32 263, i32 40, i32 11, i32 327,
	i32 28, i32 22, i32 56, i32 38, i32 254, i32 161, i32 163, i32 226,
	i32 161, i32 174, i32 38, i32 45, i32 158, i32 52, i32 171, i32 240,
	i32 232, i32 25, i32 260, i32 213, i32 6, i32 55, i32 162, i32 8,
	i32 165, i32 322, i32 35, i32 17, i32 7, i32 308, i32 23, i32 327,
	i32 194, i32 133, i32 9, i32 58, i32 243, i32 17, i32 108, i32 211,
	i32 207, i32 145, i32 157, i32 34, i32 96, i32 309, i32 320, i32 220,
	i32 214, i32 186, i32 226, i32 105, i32 36, i32 144, i32 189, i32 8,
	i32 55, i32 140, i32 110, i32 242, i32 129, i32 296, i32 225, i32 256,
	i32 261, i32 305, i32 277, i32 309, i32 125, i32 328, i32 27, i32 216,
	i32 204, i32 173, i32 124, i32 116, i32 229, i32 206, i32 51, i32 145,
	i32 4, i32 160, i32 153, i32 282, i32 266, i32 245, i32 138, i32 15,
	i32 86, i32 44, i32 260, i32 295, i32 207, i32 246, i32 310, i32 326,
	i32 62, i32 314, i32 93, i32 58, i32 323, i32 239, i32 272, i32 271,
	i32 85, i32 332, i32 278, i32 13, i32 97, i32 209, i32 165, i32 65,
	i32 90, i32 248, i32 2, i32 148, i32 107, i32 301, i32 87, i32 313,
	i32 305, i32 101, i32 42, i32 84, i32 83, i32 190, i32 8, i32 198,
	i32 49, i32 39, i32 18, i32 186, i32 255, i32 94, i32 125, i32 317,
	i32 153, i32 319, i32 5, i32 101, i32 249, i32 65, i32 331, i32 147,
	i32 272, i32 228, i32 61, i32 54, i32 96, i32 326, i32 236, i32 113,
	i32 273, i32 11, i32 158, i32 74, i32 296, i32 5, i32 119, i32 94,
	i32 106, i32 188, i32 266, i32 219, i32 197, i32 100, i32 293, i32 231,
	i32 183, i32 196, i32 89, i32 265, i32 14, i32 39, i32 241, i32 123,
	i32 293, i32 263, i32 6, i32 126, i32 77, i32 80, i32 106, i32 194,
	i32 88, i32 79, i32 85, i32 118, i32 231, i32 161, i32 54, i32 256,
	i32 219, i32 299, i32 139, i32 29, i32 11, i32 224, i32 297, i32 126,
	i32 209, i32 131, i32 239, i32 270, i32 212, i32 282, i32 30, i32 280,
	i32 303, i32 135, i32 185, i32 123, i32 312, i32 323, i32 235, i32 86,
	i32 33, i32 118, i32 112, i32 131, i32 67, i32 111, i32 59, i32 62,
	i32 128, i32 176, i32 73, i32 120, i32 87, i32 313, i32 222, i32 223,
	i32 71, i32 270, i32 102, i32 188, i32 27, i32 217, i32 75, i32 172,
	i32 182, i32 281, i32 286, i32 297, i32 176, i32 95, i32 290, i32 0,
	i32 206, i32 141, i32 98, i32 190, i32 112, i32 177, i32 292, i32 306,
	i32 196, i32 280, i32 152, i32 279, i32 53, i32 285, i32 127, i32 88,
	i32 138, i32 143, i32 227, i32 209, i32 86, i32 224, i32 32, i32 27,
	i32 224, i32 216, i32 217, i32 103, i32 133, i32 328, i32 153, i32 29,
	i32 79, i32 104, i32 137, i32 234, i32 69, i32 283, i32 149, i32 69,
	i32 322, i32 263, i32 322, i32 262, i32 1, i32 152, i32 17, i32 300,
	i32 192, i32 71, i32 326, i32 315, i32 50, i32 81, i32 99, i32 195,
	i32 200, i32 33, i32 28, i32 307, i32 186, i32 294, i32 281, i32 15,
	i32 271, i32 270, i32 150, i32 52, i32 229, i32 114, i32 60, i32 306,
	i32 51, i32 46, i32 298, i32 122, i32 21, i32 334, i32 246, i32 180,
	i32 37, i32 188, i32 3, i32 6, i32 245, i32 92, i32 155, i32 285,
	i32 250, i32 38, i32 149, i32 178, i32 107, i32 144, i32 109, i32 105,
	i32 106, i32 273, i32 264, i32 213, i32 151, i32 319, i32 199, i32 304,
	i32 311, i32 94, i32 170, i32 288, i32 194, i32 45, i32 26, i32 267,
	i32 243, i32 272, i32 275, i32 168, i32 81, i32 251, i32 58, i32 32,
	i32 3, i32 220, i32 225, i32 329, i32 283, i32 262, i32 22, i32 4,
	i32 254, i32 317, i32 121, i32 162, i32 275, i32 200, i32 164, i32 83,
	i32 160, i32 136, i32 155, i32 99, i32 36, i32 43, i32 115, i32 277,
	i32 70, i32 175, i32 68, i32 262, i32 287, i32 215, i32 323, i32 104,
	i32 49, i32 301, i32 154, i32 230, i32 174, i32 271, i32 142, i32 39,
	i32 318, i32 97, i32 308, i32 117, i32 266, i32 296, i32 212, i32 258,
	i32 181, i32 204, i32 114, i32 291, i32 312, i32 205, i32 37, i32 135,
	i32 67, i32 18, i32 91, i32 265, i32 76
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 8

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 8

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 u0x0000000000000000, ; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 8

; Functions

; Function attributes: memory(write, argmem: none, inaccessiblemem: none) "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 8, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { memory(write, argmem: none, inaccessiblemem: none) "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+fix-cortex-a53-835769,+neon,+outline-atomics,+v8a" }

; Metadata
!llvm.module.flags = !{!0, !1, !7, !8, !9, !10}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!".NET for Android remotes/origin/release/9.0.1xx @ 9abff7703206541fdb83ffa80fe2c2753ad1997b"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"branch-target-enforcement", i32 0}
!8 = !{i32 1, !"sign-return-address", i32 0}
!9 = !{i32 1, !"sign-return-address-all", i32 0}
!10 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
