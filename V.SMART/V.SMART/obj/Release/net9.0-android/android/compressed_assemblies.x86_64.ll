; ModuleID = 'compressed_assemblies.x86_64.ll'
source_filename = "compressed_assemblies.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android21"

%struct.CompressedAssemblies = type {
	i32, ; uint32_t count
	ptr ; CompressedAssemblyDescriptor descriptors
}

%struct.CompressedAssemblyDescriptor = type {
	i32, ; uint32_t uncompressed_file_size
	i1, ; bool loaded
	ptr ; uint8_t data
}

@compressed_assemblies = dso_local local_unnamed_addr global %struct.CompressedAssemblies {
	i32 335, ; uint32_t count
	ptr @compressed_assembly_descriptors; CompressedAssemblyDescriptor* descriptors
}, align 8

@compressed_assembly_descriptors = internal dso_local global [335 x %struct.CompressedAssemblyDescriptor] [
	%struct.CompressedAssemblyDescriptor {
		i32 43648, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_0; uint8_t* data
	}, ; 0: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 45696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_1; uint8_t* data
	}, ; 1: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 45184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_2; uint8_t* data
	}, ; 2: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 45696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_3; uint8_t* data
	}, ; 3: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 45696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_4; uint8_t* data
	}, ; 4: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 48768, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_5; uint8_t* data
	}, ; 5: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 45696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_6; uint8_t* data
	}, ; 6: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 45696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_7; uint8_t* data
	}, ; 7: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 44672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_8; uint8_t* data
	}, ; 8: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 54912, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_9; uint8_t* data
	}, ; 9: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 44160, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_10; uint8_t* data
	}, ; 10: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 41088, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_11; uint8_t* data
	}, ; 11: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 41088, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_12; uint8_t* data
	}, ; 12: Microsoft.CodeAnalysis.resources
	%struct.CompressedAssemblyDescriptor {
		i32 364656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_13; uint8_t* data
	}, ; 13: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 388224, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_14; uint8_t* data
	}, ; 14: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 379520, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_15; uint8_t* data
	}, ; 15: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 388224, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_16; uint8_t* data
	}, ; 16: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 385664, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_17; uint8_t* data
	}, ; 17: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 424560, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_18; uint8_t* data
	}, ; 18: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 391272, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_19; uint8_t* data
	}, ; 19: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 391808, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_20; uint8_t* data
	}, ; 20: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 373888, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_21; uint8_t* data
	}, ; 21: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 513664, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_22; uint8_t* data
	}, ; 22: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 370816, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_23; uint8_t* data
	}, ; 23: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 330368, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_24; uint8_t* data
	}, ; 24: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 330368, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_25; uint8_t* data
	}, ; 25: Microsoft.CodeAnalysis.CSharp.resources
	%struct.CompressedAssemblyDescriptor {
		i32 297064, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_26; uint8_t* data
	}, ; 26: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 312944, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_27; uint8_t* data
	}, ; 27: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 307816, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_28; uint8_t* data
	}, ; 28: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 314984, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_29; uint8_t* data
	}, ; 29: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 312424, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_30; uint8_t* data
	}, ; 30: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 347248, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_31; uint8_t* data
	}, ; 31: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 317544, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_32; uint8_t* data
	}, ; 32: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 322656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_33; uint8_t* data
	}, ; 33: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 302192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_34; uint8_t* data
	}, ; 34: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 403048, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_35; uint8_t* data
	}, ; 35: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 298088, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_36; uint8_t* data
	}, ; 36: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 272496, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_37; uint8_t* data
	}, ; 37: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 271984, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_38; uint8_t* data
	}, ; 38: Microsoft.CodeAnalysis.VisualBasic.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_39; uint8_t* data
	}, ; 39: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_40; uint8_t* data
	}, ; 40: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_41; uint8_t* data
	}, ; 41: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_42; uint8_t* data
	}, ; 42: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15664, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_43; uint8_t* data
	}, ; 43: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_44; uint8_t* data
	}, ; 44: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_45; uint8_t* data
	}, ; 45: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15648, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_46; uint8_t* data
	}, ; 46: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_47; uint8_t* data
	}, ; 47: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_48; uint8_t* data
	}, ; 48: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15640, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_49; uint8_t* data
	}, ; 49: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15664, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_50; uint8_t* data
	}, ; 50: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_51; uint8_t* data
	}, ; 51: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_52; uint8_t* data
	}, ; 52: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15664, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_53; uint8_t* data
	}, ; 53: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_54; uint8_t* data
	}, ; 54: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_55; uint8_t* data
	}, ; 55: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_56; uint8_t* data
	}, ; 56: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_57; uint8_t* data
	}, ; 57: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_58; uint8_t* data
	}, ; 58: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15664, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_59; uint8_t* data
	}, ; 59: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_60; uint8_t* data
	}, ; 60: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_61; uint8_t* data
	}, ; 61: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_62; uint8_t* data
	}, ; 62: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_63; uint8_t* data
	}, ; 63: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15664, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_64; uint8_t* data
	}, ; 64: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_65; uint8_t* data
	}, ; 65: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_66; uint8_t* data
	}, ; 66: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_67; uint8_t* data
	}, ; 67: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_68; uint8_t* data
	}, ; 68: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_69; uint8_t* data
	}, ; 69: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_70; uint8_t* data
	}, ; 70: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_71; uint8_t* data
	}, ; 71: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_72; uint8_t* data
	}, ; 72: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 6144, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_73; uint8_t* data
	}, ; 73: _Microsoft.Android.Resource.Designer
	%struct.CompressedAssemblyDescriptor {
		i32 301056, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_74; uint8_t* data
	}, ; 74: AutoMapper
	%struct.CompressedAssemblyDescriptor {
		i32 400936, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_75; uint8_t* data
	}, ; 75: Azure.Core
	%struct.CompressedAssemblyDescriptor {
		i32 342960, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_76; uint8_t* data
	}, ; 76: Azure.Identity
	%struct.CompressedAssemblyDescriptor {
		i32 253440, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_77; uint8_t* data
	}, ; 77: Blazor-ApexCharts
	%struct.CompressedAssemblyDescriptor {
		i32 32256, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_78; uint8_t* data
	}, ; 78: Blazored.LocalStorage
	%struct.CompressedAssemblyDescriptor {
		i32 4924576, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_79; uint8_t* data
	}, ; 79: BouncyCastle.Cryptography
	%struct.CompressedAssemblyDescriptor {
		i32 1691136, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_80; uint8_t* data
	}, ; 80: ClosedXML
	%struct.CompressedAssemblyDescriptor {
		i32 192000, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_81; uint8_t* data
	}, ; 81: ClosedXML.Parser
	%struct.CompressedAssemblyDescriptor {
		i32 4191232, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_82; uint8_t* data
	}, ; 82: DocumentFormat.OpenXml
	%struct.CompressedAssemblyDescriptor {
		i32 369152, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_83; uint8_t* data
	}, ; 83: DocumentFormat.OpenXml.Framework
	%struct.CompressedAssemblyDescriptor {
		i32 4501008, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_84; uint8_t* data
	}, ; 84: EPPlus
	%struct.CompressedAssemblyDescriptor {
		i32 19984, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_85; uint8_t* data
	}, ; 85: EPPlus.Interfaces
	%struct.CompressedAssemblyDescriptor {
		i32 181760, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_86; uint8_t* data
	}, ; 86: ExcelDataReader
	%struct.CompressedAssemblyDescriptor {
		i32 11264, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_87; uint8_t* data
	}, ; 87: ExcelDataReader.DataSet
	%struct.CompressedAssemblyDescriptor {
		i32 30720, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_88; uint8_t* data
	}, ; 88: ExcelNumberFormat
	%struct.CompressedAssemblyDescriptor {
		i32 90624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_89; uint8_t* data
	}, ; 89: FastReport.Compat
	%struct.CompressedAssemblyDescriptor {
		i32 1739776, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_90; uint8_t* data
	}, ; 90: FastReport
	%struct.CompressedAssemblyDescriptor {
		i32 28672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_91; uint8_t* data
	}, ; 91: FastReport.OpenSource.Export.PdfSimple
	%struct.CompressedAssemblyDescriptor {
		i32 165584, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_92; uint8_t* data
	}, ; 92: itext.barcodes
	%struct.CompressedAssemblyDescriptor {
		i32 34000, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_93; uint8_t* data
	}, ; 93: itext.bouncy-castle-connector
	%struct.CompressedAssemblyDescriptor {
		i32 206032, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_94; uint8_t* data
	}, ; 94: itext.forms
	%struct.CompressedAssemblyDescriptor {
		i32 1819344, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_95; uint8_t* data
	}, ; 95: itext.io
	%struct.CompressedAssemblyDescriptor {
		i32 1136848, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_96; uint8_t* data
	}, ; 96: itext.kernel
	%struct.CompressedAssemblyDescriptor {
		i32 516816, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_97; uint8_t* data
	}, ; 97: itext.layout
	%struct.CompressedAssemblyDescriptor {
		i32 124624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_98; uint8_t* data
	}, ; 98: itext.pdfa
	%struct.CompressedAssemblyDescriptor {
		i32 118992, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_99; uint8_t* data
	}, ; 99: itext.pdfua
	%struct.CompressedAssemblyDescriptor {
		i32 494288, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_100; uint8_t* data
	}, ; 100: itext.sign
	%struct.CompressedAssemblyDescriptor {
		i32 422608, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_101; uint8_t* data
	}, ; 101: itext.styledxmlparser
	%struct.CompressedAssemblyDescriptor {
		i32 150224, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_102; uint8_t* data
	}, ; 102: itext.svg
	%struct.CompressedAssemblyDescriptor {
		i32 98000, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_103; uint8_t* data
	}, ; 103: itext.bouncy-castle-adapter
	%struct.CompressedAssemblyDescriptor {
		i32 192208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_104; uint8_t* data
	}, ; 104: itext.commons
	%struct.CompressedAssemblyDescriptor {
		i32 142336, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_105; uint8_t* data
	}, ; 105: MailKit
	%struct.CompressedAssemblyDescriptor {
		i32 26624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_106; uint8_t* data
	}, ; 106: Microsoft.AspNetCore.Authorization
	%struct.CompressedAssemblyDescriptor {
		i32 249344, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_107; uint8_t* data
	}, ; 107: Microsoft.AspNetCore.Components
	%struct.CompressedAssemblyDescriptor {
		i32 18944, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_108; uint8_t* data
	}, ; 108: Microsoft.AspNetCore.Components.Authorization
	%struct.CompressedAssemblyDescriptor {
		i32 19336, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_109; uint8_t* data
	}, ; 109: Microsoft.AspNetCore.Components.DataAnnotations.Validation
	%struct.CompressedAssemblyDescriptor {
		i32 30208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_110; uint8_t* data
	}, ; 110: Microsoft.AspNetCore.Components.Forms
	%struct.CompressedAssemblyDescriptor {
		i32 48640, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_111; uint8_t* data
	}, ; 111: Microsoft.AspNetCore.Components.QuickGrid
	%struct.CompressedAssemblyDescriptor {
		i32 123904, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_112; uint8_t* data
	}, ; 112: Microsoft.AspNetCore.Components.Web
	%struct.CompressedAssemblyDescriptor {
		i32 162056, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_113; uint8_t* data
	}, ; 113: Microsoft.AspNetCore.Components.WebView
	%struct.CompressedAssemblyDescriptor {
		i32 71208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_114; uint8_t* data
	}, ; 114: Microsoft.AspNetCore.Components.WebView.Maui
	%struct.CompressedAssemblyDescriptor {
		i32 7168, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_115; uint8_t* data
	}, ; 115: Microsoft.AspNetCore.Cryptography.KeyDerivation
	%struct.CompressedAssemblyDescriptor {
		i32 76856, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_116; uint8_t* data
	}, ; 116: Microsoft.AspNetCore.Http.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 33344, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_117; uint8_t* data
	}, ; 117: Microsoft.AspNetCore.Http.Features
	%struct.CompressedAssemblyDescriptor {
		i32 108824, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_118; uint8_t* data
	}, ; 118: Microsoft.AspNetCore.Identity.EntityFrameworkCore
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_119; uint8_t* data
	}, ; 119: Microsoft.AspNetCore.Metadata
	%struct.CompressedAssemblyDescriptor {
		i32 14720, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_120; uint8_t* data
	}, ; 120: Microsoft.Bcl.AsyncInterfaces
	%struct.CompressedAssemblyDescriptor {
		i32 2643072, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_121; uint8_t* data
	}, ; 121: Microsoft.CodeAnalysis
	%struct.CompressedAssemblyDescriptor {
		i32 5824128, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_122; uint8_t* data
	}, ; 122: Microsoft.CodeAnalysis.CSharp
	%struct.CompressedAssemblyDescriptor {
		i32 4877416, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_123; uint8_t* data
	}, ; 123: Microsoft.CodeAnalysis.VisualBasic
	%struct.CompressedAssemblyDescriptor {
		i32 1559184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_124; uint8_t* data
	}, ; 124: Microsoft.Data.SqlClient
	%struct.CompressedAssemblyDescriptor {
		i32 21488, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_125; uint8_t* data
	}, ; 125: Microsoft.DotNet.PlatformAbstractions
	%struct.CompressedAssemblyDescriptor {
		i32 2692152, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_126; uint8_t* data
	}, ; 126: Microsoft.EntityFrameworkCore
	%struct.CompressedAssemblyDescriptor {
		i32 18432, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_127; uint8_t* data
	}, ; 127: Microsoft.EntityFrameworkCore.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 2141752, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_128; uint8_t* data
	}, ; 128: Microsoft.EntityFrameworkCore.Relational
	%struct.CompressedAssemblyDescriptor {
		i32 613944, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_129; uint8_t* data
	}, ; 129: Microsoft.EntityFrameworkCore.SqlServer
	%struct.CompressedAssemblyDescriptor {
		i32 11264, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_130; uint8_t* data
	}, ; 130: Microsoft.Extensions.Caching.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 26112, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_131; uint8_t* data
	}, ; 131: Microsoft.Extensions.Caching.Memory
	%struct.CompressedAssemblyDescriptor {
		i32 21504, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_132; uint8_t* data
	}, ; 132: Microsoft.Extensions.Configuration
	%struct.CompressedAssemblyDescriptor {
		i32 8192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_133; uint8_t* data
	}, ; 133: Microsoft.Extensions.Configuration.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 24064, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_134; uint8_t* data
	}, ; 134: Microsoft.Extensions.Configuration.Binder
	%struct.CompressedAssemblyDescriptor {
		i32 13312, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_135; uint8_t* data
	}, ; 135: Microsoft.Extensions.Configuration.FileExtensions
	%struct.CompressedAssemblyDescriptor {
		i32 11776, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_136; uint8_t* data
	}, ; 136: Microsoft.Extensions.Configuration.Json
	%struct.CompressedAssemblyDescriptor {
		i32 46592, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_137; uint8_t* data
	}, ; 137: Microsoft.Extensions.DependencyInjection
	%struct.CompressedAssemblyDescriptor {
		i32 34304, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_138; uint8_t* data
	}, ; 138: Microsoft.Extensions.DependencyInjection.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 40960, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_139; uint8_t* data
	}, ; 139: Microsoft.Extensions.DependencyModel
	%struct.CompressedAssemblyDescriptor {
		i32 15360, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_140; uint8_t* data
	}, ; 140: Microsoft.Extensions.Diagnostics
	%struct.CompressedAssemblyDescriptor {
		i32 8704, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_141; uint8_t* data
	}, ; 141: Microsoft.Extensions.Diagnostics.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 9216, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_142; uint8_t* data
	}, ; 142: Microsoft.Extensions.FileProviders.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 8192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_143; uint8_t* data
	}, ; 143: Microsoft.Extensions.FileProviders.Composite
	%struct.CompressedAssemblyDescriptor {
		i32 18432, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_144; uint8_t* data
	}, ; 144: Microsoft.Extensions.FileProviders.Embedded
	%struct.CompressedAssemblyDescriptor {
		i32 27136, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_145; uint8_t* data
	}, ; 145: Microsoft.Extensions.FileProviders.Physical
	%struct.CompressedAssemblyDescriptor {
		i32 28672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_146; uint8_t* data
	}, ; 146: Microsoft.Extensions.FileSystemGlobbing
	%struct.CompressedAssemblyDescriptor {
		i32 45056, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_147; uint8_t* data
	}, ; 147: Microsoft.Extensions.Http
	%struct.CompressedAssemblyDescriptor {
		i32 26112, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_148; uint8_t* data
	}, ; 148: Microsoft.Extensions.Identity.Core
	%struct.CompressedAssemblyDescriptor {
		i32 17920, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_149; uint8_t* data
	}, ; 149: Microsoft.Extensions.Identity.Stores
	%struct.CompressedAssemblyDescriptor {
		i32 32040, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_150; uint8_t* data
	}, ; 150: Microsoft.Extensions.Localization
	%struct.CompressedAssemblyDescriptor {
		i32 7680, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_151; uint8_t* data
	}, ; 151: Microsoft.Extensions.Localization.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 19968, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_152; uint8_t* data
	}, ; 152: Microsoft.Extensions.Logging
	%struct.CompressedAssemblyDescriptor {
		i32 39424, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_153; uint8_t* data
	}, ; 153: Microsoft.Extensions.Logging.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 21504, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_154; uint8_t* data
	}, ; 154: Microsoft.Extensions.Options
	%struct.CompressedAssemblyDescriptor {
		i32 8704, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_155; uint8_t* data
	}, ; 155: Microsoft.Extensions.Options.ConfigurationExtensions
	%struct.CompressedAssemblyDescriptor {
		i32 23040, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_156; uint8_t* data
	}, ; 156: Microsoft.Extensions.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 1624064, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_157; uint8_t* data
	}, ; 157: Microsoft.Identity.Client
	%struct.CompressedAssemblyDescriptor {
		i32 66592, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_158; uint8_t* data
	}, ; 158: Microsoft.Identity.Client.Extensions.Msal
	%struct.CompressedAssemblyDescriptor {
		i32 7168, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_159; uint8_t* data
	}, ; 159: Microsoft.IdentityModel.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 93696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_160; uint8_t* data
	}, ; 160: Microsoft.IdentityModel.JsonWebTokens
	%struct.CompressedAssemblyDescriptor {
		i32 16896, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_161; uint8_t* data
	}, ; 161: Microsoft.IdentityModel.Logging
	%struct.CompressedAssemblyDescriptor {
		i32 39864, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_162; uint8_t* data
	}, ; 162: Microsoft.IdentityModel.Protocols
	%struct.CompressedAssemblyDescriptor {
		i32 114104, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_163; uint8_t* data
	}, ; 163: Microsoft.IdentityModel.Protocols.OpenIdConnect
	%struct.CompressedAssemblyDescriptor {
		i32 182272, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_164; uint8_t* data
	}, ; 164: Microsoft.IdentityModel.Tokens
	%struct.CompressedAssemblyDescriptor {
		i32 65968, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_165; uint8_t* data
	}, ; 165: Microsoft.IO.RecyclableMemoryStream
	%struct.CompressedAssemblyDescriptor {
		i32 44032, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_166; uint8_t* data
	}, ; 166: Microsoft.JSInterop
	%struct.CompressedAssemblyDescriptor {
		i32 1876792, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_167; uint8_t* data
	}, ; 167: Microsoft.Maui.Controls
	%struct.CompressedAssemblyDescriptor {
		i32 128312, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_168; uint8_t* data
	}, ; 168: Microsoft.Maui.Controls.Xaml
	%struct.CompressedAssemblyDescriptor {
		i32 801064, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_169; uint8_t* data
	}, ; 169: Microsoft.Maui
	%struct.CompressedAssemblyDescriptor {
		i32 62976, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_170; uint8_t* data
	}, ; 170: Microsoft.Maui.Essentials
	%struct.CompressedAssemblyDescriptor {
		i32 207656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_171; uint8_t* data
	}, ; 171: Microsoft.Maui.Graphics
	%struct.CompressedAssemblyDescriptor {
		i32 23976, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_172; uint8_t* data
	}, ; 172: Microsoft.SqlServer.Server
	%struct.CompressedAssemblyDescriptor {
		i32 221184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_173; uint8_t* data
	}, ; 173: MimeKit
	%struct.CompressedAssemblyDescriptor {
		i32 995328, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_174; uint8_t* data
	}, ; 174: MudBlazor
	%struct.CompressedAssemblyDescriptor {
		i32 723368, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_175; uint8_t* data
	}, ; 175: Newtonsoft.Json
	%struct.CompressedAssemblyDescriptor {
		i32 53248, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_176; uint8_t* data
	}, ; 176: QRCoder
	%struct.CompressedAssemblyDescriptor {
		i32 34816, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_177; uint8_t* data
	}, ; 177: RBush
	%struct.CompressedAssemblyDescriptor {
		i32 1135616, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_178; uint8_t* data
	}, ; 178: SixLabors.Fonts
	%struct.CompressedAssemblyDescriptor {
		i32 28608, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_179; uint8_t* data
	}, ; 179: System.ClientModel
	%struct.CompressedAssemblyDescriptor {
		i32 396424, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_180; uint8_t* data
	}, ; 180: System.Configuration.ConfigurationManager
	%struct.CompressedAssemblyDescriptor {
		i32 957472, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_181; uint8_t* data
	}, ; 181: System.Data.SqlClient
	%struct.CompressedAssemblyDescriptor {
		i32 82432, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_182; uint8_t* data
	}, ; 182: System.Diagnostics.DiagnosticSource
	%struct.CompressedAssemblyDescriptor {
		i32 146944, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_183; uint8_t* data
	}, ; 183: System.Drawing.Common
	%struct.CompressedAssemblyDescriptor {
		i32 77344, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_184; uint8_t* data
	}, ; 184: System.IdentityModel.Tokens.Jwt
	%struct.CompressedAssemblyDescriptor {
		i32 77312, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_185; uint8_t* data
	}, ; 185: System.IO.Packaging
	%struct.CompressedAssemblyDescriptor {
		i32 28160, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_186; uint8_t* data
	}, ; 186: System.IO.Pipelines
	%struct.CompressedAssemblyDescriptor {
		i32 21368, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_187; uint8_t* data
	}, ; 187: System.Memory.Data
	%struct.CompressedAssemblyDescriptor {
		i32 55296, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_188; uint8_t* data
	}, ; 188: System.Runtime.Caching
	%struct.CompressedAssemblyDescriptor {
		i32 43520, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_189; uint8_t* data
	}, ; 189: System.Security.Cryptography.Pkcs
	%struct.CompressedAssemblyDescriptor {
		i32 7168, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_190; uint8_t* data
	}, ; 190: System.Security.Cryptography.ProtectedData
	%struct.CompressedAssemblyDescriptor {
		i32 116224, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_191; uint8_t* data
	}, ; 191: System.Security.Cryptography.Xml
	%struct.CompressedAssemblyDescriptor {
		i32 32768, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_192; uint8_t* data
	}, ; 192: System.Text.Encodings.Web
	%struct.CompressedAssemblyDescriptor {
		i32 431616, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_193; uint8_t* data
	}, ; 193: System.Text.Json
	%struct.CompressedAssemblyDescriptor {
		i32 59392, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_194; uint8_t* data
	}, ; 194: Xamarin.AndroidX.Activity
	%struct.CompressedAssemblyDescriptor {
		i32 515584, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_195; uint8_t* data
	}, ; 195: Xamarin.AndroidX.AppCompat
	%struct.CompressedAssemblyDescriptor {
		i32 15872, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_196; uint8_t* data
	}, ; 196: Xamarin.AndroidX.AppCompat.AppCompatResources
	%struct.CompressedAssemblyDescriptor {
		i32 49664, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_197; uint8_t* data
	}, ; 197: Xamarin.AndroidX.Browser
	%struct.CompressedAssemblyDescriptor {
		i32 16384, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_198; uint8_t* data
	}, ; 198: Xamarin.AndroidX.CardView
	%struct.CompressedAssemblyDescriptor {
		i32 19456, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_199; uint8_t* data
	}, ; 199: Xamarin.AndroidX.Collection.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 71680, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_200; uint8_t* data
	}, ; 200: Xamarin.AndroidX.CoordinatorLayout
	%struct.CompressedAssemblyDescriptor {
		i32 541696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_201; uint8_t* data
	}, ; 201: Xamarin.AndroidX.Core
	%struct.CompressedAssemblyDescriptor {
		i32 24576, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_202; uint8_t* data
	}, ; 202: Xamarin.AndroidX.CursorAdapter
	%struct.CompressedAssemblyDescriptor {
		i32 9728, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_203; uint8_t* data
	}, ; 203: Xamarin.AndroidX.CustomView
	%struct.CompressedAssemblyDescriptor {
		i32 42496, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_204; uint8_t* data
	}, ; 204: Xamarin.AndroidX.DrawerLayout
	%struct.CompressedAssemblyDescriptor {
		i32 209920, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_205; uint8_t* data
	}, ; 205: Xamarin.AndroidX.Fragment
	%struct.CompressedAssemblyDescriptor {
		i32 21504, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_206; uint8_t* data
	}, ; 206: Xamarin.AndroidX.Lifecycle.Common.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 17408, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_207; uint8_t* data
	}, ; 207: Xamarin.AndroidX.Lifecycle.LiveData.Core
	%struct.CompressedAssemblyDescriptor {
		i32 32256, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_208; uint8_t* data
	}, ; 208: Xamarin.AndroidX.Lifecycle.ViewModel.Android
	%struct.CompressedAssemblyDescriptor {
		i32 12800, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_209; uint8_t* data
	}, ; 209: Xamarin.AndroidX.Lifecycle.ViewModelSavedState
	%struct.CompressedAssemblyDescriptor {
		i32 36352, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_210; uint8_t* data
	}, ; 210: Xamarin.AndroidX.Loader
	%struct.CompressedAssemblyDescriptor {
		i32 90112, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_211; uint8_t* data
	}, ; 211: Xamarin.AndroidX.Navigation.Common
	%struct.CompressedAssemblyDescriptor {
		i32 18432, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_212; uint8_t* data
	}, ; 212: Xamarin.AndroidX.Navigation.Fragment
	%struct.CompressedAssemblyDescriptor {
		i32 58880, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_213; uint8_t* data
	}, ; 213: Xamarin.AndroidX.Navigation.Runtime
	%struct.CompressedAssemblyDescriptor {
		i32 28160, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_214; uint8_t* data
	}, ; 214: Xamarin.AndroidX.Navigation.UI
	%struct.CompressedAssemblyDescriptor {
		i32 405504, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_215; uint8_t* data
	}, ; 215: Xamarin.AndroidX.RecyclerView
	%struct.CompressedAssemblyDescriptor {
		i32 11264, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_216; uint8_t* data
	}, ; 216: Xamarin.AndroidX.SavedState
	%struct.CompressedAssemblyDescriptor {
		i32 37888, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_217; uint8_t* data
	}, ; 217: Xamarin.AndroidX.SwipeRefreshLayout
	%struct.CompressedAssemblyDescriptor {
		i32 57344, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_218; uint8_t* data
	}, ; 218: Xamarin.AndroidX.ViewPager
	%struct.CompressedAssemblyDescriptor {
		i32 38400, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_219; uint8_t* data
	}, ; 219: Xamarin.AndroidX.ViewPager2
	%struct.CompressedAssemblyDescriptor {
		i32 583168, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_220; uint8_t* data
	}, ; 220: Xamarin.Google.Android.Material
	%struct.CompressedAssemblyDescriptor {
		i32 86016, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_221; uint8_t* data
	}, ; 221: Xamarin.Kotlin.StdLib
	%struct.CompressedAssemblyDescriptor {
		i32 18432, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_222; uint8_t* data
	}, ; 222: Xamarin.KotlinX.Coroutines.Core.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 89600, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_223; uint8_t* data
	}, ; 223: Xamarin.KotlinX.Serialization.Core.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 516096, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_224; uint8_t* data
	}, ; 224: zxing
	%struct.CompressedAssemblyDescriptor {
		i32 10240, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_225; uint8_t* data
	}, ; 225: FastReport.Data.MsSql
	%struct.CompressedAssemblyDescriptor {
		i32 59998208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_226; uint8_t* data
	}, ; 226: V.SMART.Shared
	%struct.CompressedAssemblyDescriptor {
		i32 57344, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_227; uint8_t* data
	}, ; 227: V.SMART
	%struct.CompressedAssemblyDescriptor {
		i32 255488, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_228; uint8_t* data
	}, ; 228: Microsoft.CSharp
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_229; uint8_t* data
	}, ; 229: Microsoft.Win32.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 4608, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_230; uint8_t* data
	}, ; 230: System.AppContext
	%struct.CompressedAssemblyDescriptor {
		i32 4608, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_231; uint8_t* data
	}, ; 231: System.Buffers
	%struct.CompressedAssemblyDescriptor {
		i32 35840, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_232; uint8_t* data
	}, ; 232: System.Collections.Concurrent
	%struct.CompressedAssemblyDescriptor {
		i32 165888, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_233; uint8_t* data
	}, ; 233: System.Collections.Immutable
	%struct.CompressedAssemblyDescriptor {
		i32 22016, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_234; uint8_t* data
	}, ; 234: System.Collections.NonGeneric
	%struct.CompressedAssemblyDescriptor {
		i32 26112, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_235; uint8_t* data
	}, ; 235: System.Collections.Specialized
	%struct.CompressedAssemblyDescriptor {
		i32 80896, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_236; uint8_t* data
	}, ; 236: System.Collections
	%struct.CompressedAssemblyDescriptor {
		i32 39936, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_237; uint8_t* data
	}, ; 237: System.ComponentModel.Annotations
	%struct.CompressedAssemblyDescriptor {
		i32 19968, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_238; uint8_t* data
	}, ; 238: System.ComponentModel.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 170496, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_239; uint8_t* data
	}, ; 239: System.ComponentModel.TypeConverter
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_240; uint8_t* data
	}, ; 240: System.ComponentModel
	%struct.CompressedAssemblyDescriptor {
		i32 13824, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_241; uint8_t* data
	}, ; 241: System.Console
	%struct.CompressedAssemblyDescriptor {
		i32 676864, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_242; uint8_t* data
	}, ; 242: System.Data.Common
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_243; uint8_t* data
	}, ; 243: System.Diagnostics.Debug
	%struct.CompressedAssemblyDescriptor {
		i32 65536, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_244; uint8_t* data
	}, ; 244: System.Diagnostics.Process
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_245; uint8_t* data
	}, ; 245: System.Diagnostics.StackTrace
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_246; uint8_t* data
	}, ; 246: System.Diagnostics.Tools
	%struct.CompressedAssemblyDescriptor {
		i32 26112, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_247; uint8_t* data
	}, ; 247: System.Diagnostics.TraceSource
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_248; uint8_t* data
	}, ; 248: System.Diagnostics.Tracing
	%struct.CompressedAssemblyDescriptor {
		i32 48128, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_249; uint8_t* data
	}, ; 249: System.Drawing.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_250; uint8_t* data
	}, ; 250: System.Drawing
	%struct.CompressedAssemblyDescriptor {
		i32 62464, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_251; uint8_t* data
	}, ; 251: System.Formats.Asn1
	%struct.CompressedAssemblyDescriptor {
		i32 4608, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_252; uint8_t* data
	}, ; 252: System.Globalization
	%struct.CompressedAssemblyDescriptor {
		i32 22016, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_253; uint8_t* data
	}, ; 253: System.IO.Compression.Brotli
	%struct.CompressedAssemblyDescriptor {
		i32 79872, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_254; uint8_t* data
	}, ; 254: System.IO.Compression
	%struct.CompressedAssemblyDescriptor {
		i32 7168, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_255; uint8_t* data
	}, ; 255: System.IO.FileSystem.AccessControl
	%struct.CompressedAssemblyDescriptor {
		i32 31232, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_256; uint8_t* data
	}, ; 256: System.IO.FileSystem.Watcher
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_257; uint8_t* data
	}, ; 257: System.IO.FileSystem
	%struct.CompressedAssemblyDescriptor {
		i32 24576, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_258; uint8_t* data
	}, ; 258: System.IO.MemoryMappedFiles
	%struct.CompressedAssemblyDescriptor {
		i32 27648, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_259; uint8_t* data
	}, ; 259: System.IO.Pipes
	%struct.CompressedAssemblyDescriptor {
		i32 478208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_260; uint8_t* data
	}, ; 260: System.Linq.Expressions
	%struct.CompressedAssemblyDescriptor {
		i32 7168, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_261; uint8_t* data
	}, ; 261: System.Linq.Parallel
	%struct.CompressedAssemblyDescriptor {
		i32 53248, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_262; uint8_t* data
	}, ; 262: System.Linq.Queryable
	%struct.CompressedAssemblyDescriptor {
		i32 128000, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_263; uint8_t* data
	}, ; 263: System.Linq
	%struct.CompressedAssemblyDescriptor {
		i32 18944, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_264; uint8_t* data
	}, ; 264: System.Memory
	%struct.CompressedAssemblyDescriptor {
		i32 19456, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_265; uint8_t* data
	}, ; 265: System.Net.Http.Json
	%struct.CompressedAssemblyDescriptor {
		i32 399360, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_266; uint8_t* data
	}, ; 266: System.Net.Http
	%struct.CompressedAssemblyDescriptor {
		i32 28672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_267; uint8_t* data
	}, ; 267: System.Net.NameResolution
	%struct.CompressedAssemblyDescriptor {
		i32 29184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_268; uint8_t* data
	}, ; 268: System.Net.NetworkInformation
	%struct.CompressedAssemblyDescriptor {
		i32 69632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_269; uint8_t* data
	}, ; 269: System.Net.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 110080, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_270; uint8_t* data
	}, ; 270: System.Net.Requests
	%struct.CompressedAssemblyDescriptor {
		i32 151552, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_271; uint8_t* data
	}, ; 271: System.Net.Security
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_272; uint8_t* data
	}, ; 272: System.Net.ServicePoint
	%struct.CompressedAssemblyDescriptor {
		i32 122368, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_273; uint8_t* data
	}, ; 273: System.Net.Sockets
	%struct.CompressedAssemblyDescriptor {
		i32 12288, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_274; uint8_t* data
	}, ; 274: System.Net.WebClient
	%struct.CompressedAssemblyDescriptor {
		i32 16384, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_275; uint8_t* data
	}, ; 275: System.Net.WebHeaderCollection
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_276; uint8_t* data
	}, ; 276: System.Net.WebSockets
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_277; uint8_t* data
	}, ; 277: System.Numerics.Vectors
	%struct.CompressedAssemblyDescriptor {
		i32 20992, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_278; uint8_t* data
	}, ; 278: System.ObjectModel
	%struct.CompressedAssemblyDescriptor {
		i32 416256, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_279; uint8_t* data
	}, ; 279: System.Private.DataContractSerialization
	%struct.CompressedAssemblyDescriptor {
		i32 82432, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_280; uint8_t* data
	}, ; 280: System.Private.Uri
	%struct.CompressedAssemblyDescriptor {
		i32 73728, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_281; uint8_t* data
	}, ; 281: System.Private.Xml.Linq
	%struct.CompressedAssemblyDescriptor {
		i32 2336768, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_282; uint8_t* data
	}, ; 282: System.Private.Xml
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_283; uint8_t* data
	}, ; 283: System.Reflection.Emit.ILGeneration
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_284; uint8_t* data
	}, ; 284: System.Reflection.Emit.Lightweight
	%struct.CompressedAssemblyDescriptor {
		i32 14848, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_285; uint8_t* data
	}, ; 285: System.Reflection.Emit
	%struct.CompressedAssemblyDescriptor {
		i32 280064, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_286; uint8_t* data
	}, ; 286: System.Reflection.Metadata
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_287; uint8_t* data
	}, ; 287: System.Reflection.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_288; uint8_t* data
	}, ; 288: System.Resources.ResourceManager
	%struct.CompressedAssemblyDescriptor {
		i32 4608, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_289; uint8_t* data
	}, ; 289: System.Runtime.CompilerServices.Unsafe
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_290; uint8_t* data
	}, ; 290: System.Runtime.Extensions
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_291; uint8_t* data
	}, ; 291: System.Runtime.InteropServices.RuntimeInformation
	%struct.CompressedAssemblyDescriptor {
		i32 10240, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_292; uint8_t* data
	}, ; 292: System.Runtime.InteropServices
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_293; uint8_t* data
	}, ; 293: System.Runtime.Intrinsics
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_294; uint8_t* data
	}, ; 294: System.Runtime.Loader
	%struct.CompressedAssemblyDescriptor {
		i32 107008, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_295; uint8_t* data
	}, ; 295: System.Runtime.Numerics
	%struct.CompressedAssemblyDescriptor {
		i32 8192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_296; uint8_t* data
	}, ; 296: System.Runtime.Serialization.Formatters
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_297; uint8_t* data
	}, ; 297: System.Runtime.Serialization.Json
	%struct.CompressedAssemblyDescriptor {
		i32 8192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_298; uint8_t* data
	}, ; 298: System.Runtime.Serialization.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_299; uint8_t* data
	}, ; 299: System.Runtime.Serialization.Xml
	%struct.CompressedAssemblyDescriptor {
		i32 20480, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_300; uint8_t* data
	}, ; 300: System.Runtime
	%struct.CompressedAssemblyDescriptor {
		i32 6656, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_301; uint8_t* data
	}, ; 301: System.Security.AccessControl
	%struct.CompressedAssemblyDescriptor {
		i32 16384, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_302; uint8_t* data
	}, ; 302: System.Security.Claims
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_303; uint8_t* data
	}, ; 303: System.Security.Cryptography.Algorithms
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_304; uint8_t* data
	}, ; 304: System.Security.Cryptography.Cng
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_305; uint8_t* data
	}, ; 305: System.Security.Cryptography.Csp
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_306; uint8_t* data
	}, ; 306: System.Security.Cryptography.Encoding
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_307; uint8_t* data
	}, ; 307: System.Security.Cryptography.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_308; uint8_t* data
	}, ; 308: System.Security.Cryptography.X509Certificates
	%struct.CompressedAssemblyDescriptor {
		i32 338432, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_309; uint8_t* data
	}, ; 309: System.Security.Cryptography
	%struct.CompressedAssemblyDescriptor {
		i32 5632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_310; uint8_t* data
	}, ; 310: System.Security.Principal.Windows
	%struct.CompressedAssemblyDescriptor {
		i32 700928, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_311; uint8_t* data
	}, ; 311: System.Text.Encoding.CodePages
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_312; uint8_t* data
	}, ; 312: System.Text.Encoding.Extensions
	%struct.CompressedAssemblyDescriptor {
		i32 324096, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_313; uint8_t* data
	}, ; 313: System.Text.RegularExpressions
	%struct.CompressedAssemblyDescriptor {
		i32 20992, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_314; uint8_t* data
	}, ; 314: System.Threading.Channels
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_315; uint8_t* data
	}, ; 315: System.Threading.Tasks.Extensions
	%struct.CompressedAssemblyDescriptor {
		i32 15360, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_316; uint8_t* data
	}, ; 316: System.Threading.Tasks.Parallel
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_317; uint8_t* data
	}, ; 317: System.Threading.Tasks
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_318; uint8_t* data
	}, ; 318: System.Threading.Thread
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_319; uint8_t* data
	}, ; 319: System.Threading.ThreadPool
	%struct.CompressedAssemblyDescriptor {
		i32 4608, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_320; uint8_t* data
	}, ; 320: System.Threading.Timer
	%struct.CompressedAssemblyDescriptor {
		i32 11264, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_321; uint8_t* data
	}, ; 321: System.Threading
	%struct.CompressedAssemblyDescriptor {
		i32 66560, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_322; uint8_t* data
	}, ; 322: System.Transactions.Local
	%struct.CompressedAssemblyDescriptor {
		i32 11264, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_323; uint8_t* data
	}, ; 323: System.Web.HttpUtility
	%struct.CompressedAssemblyDescriptor {
		i32 4608, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_324; uint8_t* data
	}, ; 324: System.Xml.Linq
	%struct.CompressedAssemblyDescriptor {
		i32 6144, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_325; uint8_t* data
	}, ; 325: System.Xml.ReaderWriter
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_326; uint8_t* data
	}, ; 326: System.Xml.XDocument
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_327; uint8_t* data
	}, ; 327: System.Xml.XPath.XDocument
	%struct.CompressedAssemblyDescriptor {
		i32 5120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_328; uint8_t* data
	}, ; 328: System.Xml.XmlSerializer
	%struct.CompressedAssemblyDescriptor {
		i32 4608, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_329; uint8_t* data
	}, ; 329: System
	%struct.CompressedAssemblyDescriptor {
		i32 20992, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_330; uint8_t* data
	}, ; 330: netstandard
	%struct.CompressedAssemblyDescriptor {
		i32 2711040, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_331; uint8_t* data
	}, ; 331: System.Private.CoreLib
	%struct.CompressedAssemblyDescriptor {
		i32 166912, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_332; uint8_t* data
	}, ; 332: Java.Interop
	%struct.CompressedAssemblyDescriptor {
		i32 19008, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_333; uint8_t* data
	}, ; 333: Mono.Android.Runtime
	%struct.CompressedAssemblyDescriptor {
		i32 1919488, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		ptr @__compressedAssemblyData_334; uint8_t* data
	} ; 334: Mono.Android
], align 16

@__compressedAssemblyData_0 = internal dso_local global [43648 x i8] zeroinitializer, align 16
@__compressedAssemblyData_1 = internal dso_local global [45696 x i8] zeroinitializer, align 16
@__compressedAssemblyData_2 = internal dso_local global [45184 x i8] zeroinitializer, align 16
@__compressedAssemblyData_3 = internal dso_local global [45696 x i8] zeroinitializer, align 16
@__compressedAssemblyData_4 = internal dso_local global [45696 x i8] zeroinitializer, align 16
@__compressedAssemblyData_5 = internal dso_local global [48768 x i8] zeroinitializer, align 16
@__compressedAssemblyData_6 = internal dso_local global [45696 x i8] zeroinitializer, align 16
@__compressedAssemblyData_7 = internal dso_local global [45696 x i8] zeroinitializer, align 16
@__compressedAssemblyData_8 = internal dso_local global [44672 x i8] zeroinitializer, align 16
@__compressedAssemblyData_9 = internal dso_local global [54912 x i8] zeroinitializer, align 16
@__compressedAssemblyData_10 = internal dso_local global [44160 x i8] zeroinitializer, align 16
@__compressedAssemblyData_11 = internal dso_local global [41088 x i8] zeroinitializer, align 16
@__compressedAssemblyData_12 = internal dso_local global [41088 x i8] zeroinitializer, align 16
@__compressedAssemblyData_13 = internal dso_local global [364656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_14 = internal dso_local global [388224 x i8] zeroinitializer, align 16
@__compressedAssemblyData_15 = internal dso_local global [379520 x i8] zeroinitializer, align 16
@__compressedAssemblyData_16 = internal dso_local global [388224 x i8] zeroinitializer, align 16
@__compressedAssemblyData_17 = internal dso_local global [385664 x i8] zeroinitializer, align 16
@__compressedAssemblyData_18 = internal dso_local global [424560 x i8] zeroinitializer, align 16
@__compressedAssemblyData_19 = internal dso_local global [391272 x i8] zeroinitializer, align 16
@__compressedAssemblyData_20 = internal dso_local global [391808 x i8] zeroinitializer, align 16
@__compressedAssemblyData_21 = internal dso_local global [373888 x i8] zeroinitializer, align 16
@__compressedAssemblyData_22 = internal dso_local global [513664 x i8] zeroinitializer, align 16
@__compressedAssemblyData_23 = internal dso_local global [370816 x i8] zeroinitializer, align 16
@__compressedAssemblyData_24 = internal dso_local global [330368 x i8] zeroinitializer, align 16
@__compressedAssemblyData_25 = internal dso_local global [330368 x i8] zeroinitializer, align 16
@__compressedAssemblyData_26 = internal dso_local global [297064 x i8] zeroinitializer, align 16
@__compressedAssemblyData_27 = internal dso_local global [312944 x i8] zeroinitializer, align 16
@__compressedAssemblyData_28 = internal dso_local global [307816 x i8] zeroinitializer, align 16
@__compressedAssemblyData_29 = internal dso_local global [314984 x i8] zeroinitializer, align 16
@__compressedAssemblyData_30 = internal dso_local global [312424 x i8] zeroinitializer, align 16
@__compressedAssemblyData_31 = internal dso_local global [347248 x i8] zeroinitializer, align 16
@__compressedAssemblyData_32 = internal dso_local global [317544 x i8] zeroinitializer, align 16
@__compressedAssemblyData_33 = internal dso_local global [322656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_34 = internal dso_local global [302192 x i8] zeroinitializer, align 16
@__compressedAssemblyData_35 = internal dso_local global [403048 x i8] zeroinitializer, align 16
@__compressedAssemblyData_36 = internal dso_local global [298088 x i8] zeroinitializer, align 16
@__compressedAssemblyData_37 = internal dso_local global [272496 x i8] zeroinitializer, align 16
@__compressedAssemblyData_38 = internal dso_local global [271984 x i8] zeroinitializer, align 16
@__compressedAssemblyData_39 = internal dso_local global [15672 x i8] zeroinitializer, align 16
@__compressedAssemblyData_40 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_41 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_42 = internal dso_local global [15624 x i8] zeroinitializer, align 16
@__compressedAssemblyData_43 = internal dso_local global [15664 x i8] zeroinitializer, align 16
@__compressedAssemblyData_44 = internal dso_local global [15672 x i8] zeroinitializer, align 16
@__compressedAssemblyData_45 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_46 = internal dso_local global [15648 x i8] zeroinitializer, align 16
@__compressedAssemblyData_47 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_48 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_49 = internal dso_local global [15640 x i8] zeroinitializer, align 16
@__compressedAssemblyData_50 = internal dso_local global [15664 x i8] zeroinitializer, align 16
@__compressedAssemblyData_51 = internal dso_local global [15672 x i8] zeroinitializer, align 16
@__compressedAssemblyData_52 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_53 = internal dso_local global [15664 x i8] zeroinitializer, align 16
@__compressedAssemblyData_54 = internal dso_local global [15672 x i8] zeroinitializer, align 16
@__compressedAssemblyData_55 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_56 = internal dso_local global [15632 x i8] zeroinitializer, align 16
@__compressedAssemblyData_57 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_58 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_59 = internal dso_local global [15664 x i8] zeroinitializer, align 16
@__compressedAssemblyData_60 = internal dso_local global [15672 x i8] zeroinitializer, align 16
@__compressedAssemblyData_61 = internal dso_local global [15672 x i8] zeroinitializer, align 16
@__compressedAssemblyData_62 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_63 = internal dso_local global [15624 x i8] zeroinitializer, align 16
@__compressedAssemblyData_64 = internal dso_local global [15664 x i8] zeroinitializer, align 16
@__compressedAssemblyData_65 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_66 = internal dso_local global [15632 x i8] zeroinitializer, align 16
@__compressedAssemblyData_67 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_68 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_69 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_70 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_71 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_72 = internal dso_local global [15656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_73 = internal dso_local global [6144 x i8] zeroinitializer, align 16
@__compressedAssemblyData_74 = internal dso_local global [301056 x i8] zeroinitializer, align 16
@__compressedAssemblyData_75 = internal dso_local global [400936 x i8] zeroinitializer, align 16
@__compressedAssemblyData_76 = internal dso_local global [342960 x i8] zeroinitializer, align 16
@__compressedAssemblyData_77 = internal dso_local global [253440 x i8] zeroinitializer, align 16
@__compressedAssemblyData_78 = internal dso_local global [32256 x i8] zeroinitializer, align 16
@__compressedAssemblyData_79 = internal dso_local global [4924576 x i8] zeroinitializer, align 16
@__compressedAssemblyData_80 = internal dso_local global [1691136 x i8] zeroinitializer, align 16
@__compressedAssemblyData_81 = internal dso_local global [192000 x i8] zeroinitializer, align 16
@__compressedAssemblyData_82 = internal dso_local global [4191232 x i8] zeroinitializer, align 16
@__compressedAssemblyData_83 = internal dso_local global [369152 x i8] zeroinitializer, align 16
@__compressedAssemblyData_84 = internal dso_local global [4501008 x i8] zeroinitializer, align 16
@__compressedAssemblyData_85 = internal dso_local global [19984 x i8] zeroinitializer, align 16
@__compressedAssemblyData_86 = internal dso_local global [181760 x i8] zeroinitializer, align 16
@__compressedAssemblyData_87 = internal dso_local global [11264 x i8] zeroinitializer, align 16
@__compressedAssemblyData_88 = internal dso_local global [30720 x i8] zeroinitializer, align 16
@__compressedAssemblyData_89 = internal dso_local global [90624 x i8] zeroinitializer, align 16
@__compressedAssemblyData_90 = internal dso_local global [1739776 x i8] zeroinitializer, align 16
@__compressedAssemblyData_91 = internal dso_local global [28672 x i8] zeroinitializer, align 16
@__compressedAssemblyData_92 = internal dso_local global [165584 x i8] zeroinitializer, align 16
@__compressedAssemblyData_93 = internal dso_local global [34000 x i8] zeroinitializer, align 16
@__compressedAssemblyData_94 = internal dso_local global [206032 x i8] zeroinitializer, align 16
@__compressedAssemblyData_95 = internal dso_local global [1819344 x i8] zeroinitializer, align 16
@__compressedAssemblyData_96 = internal dso_local global [1136848 x i8] zeroinitializer, align 16
@__compressedAssemblyData_97 = internal dso_local global [516816 x i8] zeroinitializer, align 16
@__compressedAssemblyData_98 = internal dso_local global [124624 x i8] zeroinitializer, align 16
@__compressedAssemblyData_99 = internal dso_local global [118992 x i8] zeroinitializer, align 16
@__compressedAssemblyData_100 = internal dso_local global [494288 x i8] zeroinitializer, align 16
@__compressedAssemblyData_101 = internal dso_local global [422608 x i8] zeroinitializer, align 16
@__compressedAssemblyData_102 = internal dso_local global [150224 x i8] zeroinitializer, align 16
@__compressedAssemblyData_103 = internal dso_local global [98000 x i8] zeroinitializer, align 16
@__compressedAssemblyData_104 = internal dso_local global [192208 x i8] zeroinitializer, align 16
@__compressedAssemblyData_105 = internal dso_local global [142336 x i8] zeroinitializer, align 16
@__compressedAssemblyData_106 = internal dso_local global [26624 x i8] zeroinitializer, align 16
@__compressedAssemblyData_107 = internal dso_local global [249344 x i8] zeroinitializer, align 16
@__compressedAssemblyData_108 = internal dso_local global [18944 x i8] zeroinitializer, align 16
@__compressedAssemblyData_109 = internal dso_local global [19336 x i8] zeroinitializer, align 16
@__compressedAssemblyData_110 = internal dso_local global [30208 x i8] zeroinitializer, align 16
@__compressedAssemblyData_111 = internal dso_local global [48640 x i8] zeroinitializer, align 16
@__compressedAssemblyData_112 = internal dso_local global [123904 x i8] zeroinitializer, align 16
@__compressedAssemblyData_113 = internal dso_local global [162056 x i8] zeroinitializer, align 16
@__compressedAssemblyData_114 = internal dso_local global [71208 x i8] zeroinitializer, align 16
@__compressedAssemblyData_115 = internal dso_local global [7168 x i8] zeroinitializer, align 16
@__compressedAssemblyData_116 = internal dso_local global [76856 x i8] zeroinitializer, align 16
@__compressedAssemblyData_117 = internal dso_local global [33344 x i8] zeroinitializer, align 16
@__compressedAssemblyData_118 = internal dso_local global [108824 x i8] zeroinitializer, align 16
@__compressedAssemblyData_119 = internal dso_local global [5632 x i8] zeroinitializer, align 16
@__compressedAssemblyData_120 = internal dso_local global [14720 x i8] zeroinitializer, align 16
@__compressedAssemblyData_121 = internal dso_local global [2643072 x i8] zeroinitializer, align 16
@__compressedAssemblyData_122 = internal dso_local global [5824128 x i8] zeroinitializer, align 16
@__compressedAssemblyData_123 = internal dso_local global [4877416 x i8] zeroinitializer, align 16
@__compressedAssemblyData_124 = internal dso_local global [1559184 x i8] zeroinitializer, align 16
@__compressedAssemblyData_125 = internal dso_local global [21488 x i8] zeroinitializer, align 16
@__compressedAssemblyData_126 = internal dso_local global [2692152 x i8] zeroinitializer, align 16
@__compressedAssemblyData_127 = internal dso_local global [18432 x i8] zeroinitializer, align 16
@__compressedAssemblyData_128 = internal dso_local global [2141752 x i8] zeroinitializer, align 16
@__compressedAssemblyData_129 = internal dso_local global [613944 x i8] zeroinitializer, align 16
@__compressedAssemblyData_130 = internal dso_local global [11264 x i8] zeroinitializer, align 16
@__compressedAssemblyData_131 = internal dso_local global [26112 x i8] zeroinitializer, align 16
@__compressedAssemblyData_132 = internal dso_local global [21504 x i8] zeroinitializer, align 16
@__compressedAssemblyData_133 = internal dso_local global [8192 x i8] zeroinitializer, align 16
@__compressedAssemblyData_134 = internal dso_local global [24064 x i8] zeroinitializer, align 16
@__compressedAssemblyData_135 = internal dso_local global [13312 x i8] zeroinitializer, align 16
@__compressedAssemblyData_136 = internal dso_local global [11776 x i8] zeroinitializer, align 16
@__compressedAssemblyData_137 = internal dso_local global [46592 x i8] zeroinitializer, align 16
@__compressedAssemblyData_138 = internal dso_local global [34304 x i8] zeroinitializer, align 16
@__compressedAssemblyData_139 = internal dso_local global [40960 x i8] zeroinitializer, align 16
@__compressedAssemblyData_140 = internal dso_local global [15360 x i8] zeroinitializer, align 16
@__compressedAssemblyData_141 = internal dso_local global [8704 x i8] zeroinitializer, align 16
@__compressedAssemblyData_142 = internal dso_local global [9216 x i8] zeroinitializer, align 16
@__compressedAssemblyData_143 = internal dso_local global [8192 x i8] zeroinitializer, align 16
@__compressedAssemblyData_144 = internal dso_local global [18432 x i8] zeroinitializer, align 16
@__compressedAssemblyData_145 = internal dso_local global [27136 x i8] zeroinitializer, align 16
@__compressedAssemblyData_146 = internal dso_local global [28672 x i8] zeroinitializer, align 16
@__compressedAssemblyData_147 = internal dso_local global [45056 x i8] zeroinitializer, align 16
@__compressedAssemblyData_148 = internal dso_local global [26112 x i8] zeroinitializer, align 16
@__compressedAssemblyData_149 = internal dso_local global [17920 x i8] zeroinitializer, align 16
@__compressedAssemblyData_150 = internal dso_local global [32040 x i8] zeroinitializer, align 16
@__compressedAssemblyData_151 = internal dso_local global [7680 x i8] zeroinitializer, align 16
@__compressedAssemblyData_152 = internal dso_local global [19968 x i8] zeroinitializer, align 16
@__compressedAssemblyData_153 = internal dso_local global [39424 x i8] zeroinitializer, align 16
@__compressedAssemblyData_154 = internal dso_local global [21504 x i8] zeroinitializer, align 16
@__compressedAssemblyData_155 = internal dso_local global [8704 x i8] zeroinitializer, align 16
@__compressedAssemblyData_156 = internal dso_local global [23040 x i8] zeroinitializer, align 16
@__compressedAssemblyData_157 = internal dso_local global [1624064 x i8] zeroinitializer, align 16
@__compressedAssemblyData_158 = internal dso_local global [66592 x i8] zeroinitializer, align 16
@__compressedAssemblyData_159 = internal dso_local global [7168 x i8] zeroinitializer, align 16
@__compressedAssemblyData_160 = internal dso_local global [93696 x i8] zeroinitializer, align 16
@__compressedAssemblyData_161 = internal dso_local global [16896 x i8] zeroinitializer, align 16
@__compressedAssemblyData_162 = internal dso_local global [39864 x i8] zeroinitializer, align 16
@__compressedAssemblyData_163 = internal dso_local global [114104 x i8] zeroinitializer, align 16
@__compressedAssemblyData_164 = internal dso_local global [182272 x i8] zeroinitializer, align 16
@__compressedAssemblyData_165 = internal dso_local global [65968 x i8] zeroinitializer, align 16
@__compressedAssemblyData_166 = internal dso_local global [44032 x i8] zeroinitializer, align 16
@__compressedAssemblyData_167 = internal dso_local global [1876792 x i8] zeroinitializer, align 16
@__compressedAssemblyData_168 = internal dso_local global [128312 x i8] zeroinitializer, align 16
@__compressedAssemblyData_169 = internal dso_local global [801064 x i8] zeroinitializer, align 16
@__compressedAssemblyData_170 = internal dso_local global [62976 x i8] zeroinitializer, align 16
@__compressedAssemblyData_171 = internal dso_local global [207656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_172 = internal dso_local global [23976 x i8] zeroinitializer, align 16
@__compressedAssemblyData_173 = internal dso_local global [221184 x i8] zeroinitializer, align 16
@__compressedAssemblyData_174 = internal dso_local global [995328 x i8] zeroinitializer, align 16
@__compressedAssemblyData_175 = internal dso_local global [723368 x i8] zeroinitializer, align 16
@__compressedAssemblyData_176 = internal dso_local global [53248 x i8] zeroinitializer, align 16
@__compressedAssemblyData_177 = internal dso_local global [34816 x i8] zeroinitializer, align 16
@__compressedAssemblyData_178 = internal dso_local global [1135616 x i8] zeroinitializer, align 16
@__compressedAssemblyData_179 = internal dso_local global [28608 x i8] zeroinitializer, align 16
@__compressedAssemblyData_180 = internal dso_local global [396424 x i8] zeroinitializer, align 16
@__compressedAssemblyData_181 = internal dso_local global [957472 x i8] zeroinitializer, align 16
@__compressedAssemblyData_182 = internal dso_local global [82432 x i8] zeroinitializer, align 16
@__compressedAssemblyData_183 = internal dso_local global [146944 x i8] zeroinitializer, align 16
@__compressedAssemblyData_184 = internal dso_local global [77344 x i8] zeroinitializer, align 16
@__compressedAssemblyData_185 = internal dso_local global [77312 x i8] zeroinitializer, align 16
@__compressedAssemblyData_186 = internal dso_local global [28160 x i8] zeroinitializer, align 16
@__compressedAssemblyData_187 = internal dso_local global [21368 x i8] zeroinitializer, align 16
@__compressedAssemblyData_188 = internal dso_local global [55296 x i8] zeroinitializer, align 16
@__compressedAssemblyData_189 = internal dso_local global [43520 x i8] zeroinitializer, align 16
@__compressedAssemblyData_190 = internal dso_local global [7168 x i8] zeroinitializer, align 16
@__compressedAssemblyData_191 = internal dso_local global [116224 x i8] zeroinitializer, align 16
@__compressedAssemblyData_192 = internal dso_local global [32768 x i8] zeroinitializer, align 16
@__compressedAssemblyData_193 = internal dso_local global [431616 x i8] zeroinitializer, align 16
@__compressedAssemblyData_194 = internal dso_local global [59392 x i8] zeroinitializer, align 16
@__compressedAssemblyData_195 = internal dso_local global [515584 x i8] zeroinitializer, align 16
@__compressedAssemblyData_196 = internal dso_local global [15872 x i8] zeroinitializer, align 16
@__compressedAssemblyData_197 = internal dso_local global [49664 x i8] zeroinitializer, align 16
@__compressedAssemblyData_198 = internal dso_local global [16384 x i8] zeroinitializer, align 16
@__compressedAssemblyData_199 = internal dso_local global [19456 x i8] zeroinitializer, align 16
@__compressedAssemblyData_200 = internal dso_local global [71680 x i8] zeroinitializer, align 16
@__compressedAssemblyData_201 = internal dso_local global [541696 x i8] zeroinitializer, align 16
@__compressedAssemblyData_202 = internal dso_local global [24576 x i8] zeroinitializer, align 16
@__compressedAssemblyData_203 = internal dso_local global [9728 x i8] zeroinitializer, align 16
@__compressedAssemblyData_204 = internal dso_local global [42496 x i8] zeroinitializer, align 16
@__compressedAssemblyData_205 = internal dso_local global [209920 x i8] zeroinitializer, align 16
@__compressedAssemblyData_206 = internal dso_local global [21504 x i8] zeroinitializer, align 16
@__compressedAssemblyData_207 = internal dso_local global [17408 x i8] zeroinitializer, align 16
@__compressedAssemblyData_208 = internal dso_local global [32256 x i8] zeroinitializer, align 16
@__compressedAssemblyData_209 = internal dso_local global [12800 x i8] zeroinitializer, align 16
@__compressedAssemblyData_210 = internal dso_local global [36352 x i8] zeroinitializer, align 16
@__compressedAssemblyData_211 = internal dso_local global [90112 x i8] zeroinitializer, align 16
@__compressedAssemblyData_212 = internal dso_local global [18432 x i8] zeroinitializer, align 16
@__compressedAssemblyData_213 = internal dso_local global [58880 x i8] zeroinitializer, align 16
@__compressedAssemblyData_214 = internal dso_local global [28160 x i8] zeroinitializer, align 16
@__compressedAssemblyData_215 = internal dso_local global [405504 x i8] zeroinitializer, align 16
@__compressedAssemblyData_216 = internal dso_local global [11264 x i8] zeroinitializer, align 16
@__compressedAssemblyData_217 = internal dso_local global [37888 x i8] zeroinitializer, align 16
@__compressedAssemblyData_218 = internal dso_local global [57344 x i8] zeroinitializer, align 16
@__compressedAssemblyData_219 = internal dso_local global [38400 x i8] zeroinitializer, align 16
@__compressedAssemblyData_220 = internal dso_local global [583168 x i8] zeroinitializer, align 16
@__compressedAssemblyData_221 = internal dso_local global [86016 x i8] zeroinitializer, align 16
@__compressedAssemblyData_222 = internal dso_local global [18432 x i8] zeroinitializer, align 16
@__compressedAssemblyData_223 = internal dso_local global [89600 x i8] zeroinitializer, align 16
@__compressedAssemblyData_224 = internal dso_local global [516096 x i8] zeroinitializer, align 16
@__compressedAssemblyData_225 = internal dso_local global [10240 x i8] zeroinitializer, align 16
@__compressedAssemblyData_226 = internal dso_local global [59998208 x i8] zeroinitializer, align 16
@__compressedAssemblyData_227 = internal dso_local global [57344 x i8] zeroinitializer, align 16
@__compressedAssemblyData_228 = internal dso_local global [255488 x i8] zeroinitializer, align 16
@__compressedAssemblyData_229 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_230 = internal dso_local global [4608 x i8] zeroinitializer, align 16
@__compressedAssemblyData_231 = internal dso_local global [4608 x i8] zeroinitializer, align 16
@__compressedAssemblyData_232 = internal dso_local global [35840 x i8] zeroinitializer, align 16
@__compressedAssemblyData_233 = internal dso_local global [165888 x i8] zeroinitializer, align 16
@__compressedAssemblyData_234 = internal dso_local global [22016 x i8] zeroinitializer, align 16
@__compressedAssemblyData_235 = internal dso_local global [26112 x i8] zeroinitializer, align 16
@__compressedAssemblyData_236 = internal dso_local global [80896 x i8] zeroinitializer, align 16
@__compressedAssemblyData_237 = internal dso_local global [39936 x i8] zeroinitializer, align 16
@__compressedAssemblyData_238 = internal dso_local global [19968 x i8] zeroinitializer, align 16
@__compressedAssemblyData_239 = internal dso_local global [170496 x i8] zeroinitializer, align 16
@__compressedAssemblyData_240 = internal dso_local global [5632 x i8] zeroinitializer, align 16
@__compressedAssemblyData_241 = internal dso_local global [13824 x i8] zeroinitializer, align 16
@__compressedAssemblyData_242 = internal dso_local global [676864 x i8] zeroinitializer, align 16
@__compressedAssemblyData_243 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_244 = internal dso_local global [65536 x i8] zeroinitializer, align 16
@__compressedAssemblyData_245 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_246 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_247 = internal dso_local global [26112 x i8] zeroinitializer, align 16
@__compressedAssemblyData_248 = internal dso_local global [5632 x i8] zeroinitializer, align 16
@__compressedAssemblyData_249 = internal dso_local global [48128 x i8] zeroinitializer, align 16
@__compressedAssemblyData_250 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_251 = internal dso_local global [62464 x i8] zeroinitializer, align 16
@__compressedAssemblyData_252 = internal dso_local global [4608 x i8] zeroinitializer, align 16
@__compressedAssemblyData_253 = internal dso_local global [22016 x i8] zeroinitializer, align 16
@__compressedAssemblyData_254 = internal dso_local global [79872 x i8] zeroinitializer, align 16
@__compressedAssemblyData_255 = internal dso_local global [7168 x i8] zeroinitializer, align 16
@__compressedAssemblyData_256 = internal dso_local global [31232 x i8] zeroinitializer, align 16
@__compressedAssemblyData_257 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_258 = internal dso_local global [24576 x i8] zeroinitializer, align 16
@__compressedAssemblyData_259 = internal dso_local global [27648 x i8] zeroinitializer, align 16
@__compressedAssemblyData_260 = internal dso_local global [478208 x i8] zeroinitializer, align 16
@__compressedAssemblyData_261 = internal dso_local global [7168 x i8] zeroinitializer, align 16
@__compressedAssemblyData_262 = internal dso_local global [53248 x i8] zeroinitializer, align 16
@__compressedAssemblyData_263 = internal dso_local global [128000 x i8] zeroinitializer, align 16
@__compressedAssemblyData_264 = internal dso_local global [18944 x i8] zeroinitializer, align 16
@__compressedAssemblyData_265 = internal dso_local global [19456 x i8] zeroinitializer, align 16
@__compressedAssemblyData_266 = internal dso_local global [399360 x i8] zeroinitializer, align 16
@__compressedAssemblyData_267 = internal dso_local global [28672 x i8] zeroinitializer, align 16
@__compressedAssemblyData_268 = internal dso_local global [29184 x i8] zeroinitializer, align 16
@__compressedAssemblyData_269 = internal dso_local global [69632 x i8] zeroinitializer, align 16
@__compressedAssemblyData_270 = internal dso_local global [110080 x i8] zeroinitializer, align 16
@__compressedAssemblyData_271 = internal dso_local global [151552 x i8] zeroinitializer, align 16
@__compressedAssemblyData_272 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_273 = internal dso_local global [122368 x i8] zeroinitializer, align 16
@__compressedAssemblyData_274 = internal dso_local global [12288 x i8] zeroinitializer, align 16
@__compressedAssemblyData_275 = internal dso_local global [16384 x i8] zeroinitializer, align 16
@__compressedAssemblyData_276 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_277 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_278 = internal dso_local global [20992 x i8] zeroinitializer, align 16
@__compressedAssemblyData_279 = internal dso_local global [416256 x i8] zeroinitializer, align 16
@__compressedAssemblyData_280 = internal dso_local global [82432 x i8] zeroinitializer, align 16
@__compressedAssemblyData_281 = internal dso_local global [73728 x i8] zeroinitializer, align 16
@__compressedAssemblyData_282 = internal dso_local global [2336768 x i8] zeroinitializer, align 16
@__compressedAssemblyData_283 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_284 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_285 = internal dso_local global [14848 x i8] zeroinitializer, align 16
@__compressedAssemblyData_286 = internal dso_local global [280064 x i8] zeroinitializer, align 16
@__compressedAssemblyData_287 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_288 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_289 = internal dso_local global [4608 x i8] zeroinitializer, align 16
@__compressedAssemblyData_290 = internal dso_local global [5632 x i8] zeroinitializer, align 16
@__compressedAssemblyData_291 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_292 = internal dso_local global [10240 x i8] zeroinitializer, align 16
@__compressedAssemblyData_293 = internal dso_local global [5632 x i8] zeroinitializer, align 16
@__compressedAssemblyData_294 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_295 = internal dso_local global [107008 x i8] zeroinitializer, align 16
@__compressedAssemblyData_296 = internal dso_local global [8192 x i8] zeroinitializer, align 16
@__compressedAssemblyData_297 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_298 = internal dso_local global [8192 x i8] zeroinitializer, align 16
@__compressedAssemblyData_299 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_300 = internal dso_local global [20480 x i8] zeroinitializer, align 16
@__compressedAssemblyData_301 = internal dso_local global [6656 x i8] zeroinitializer, align 16
@__compressedAssemblyData_302 = internal dso_local global [16384 x i8] zeroinitializer, align 16
@__compressedAssemblyData_303 = internal dso_local global [5632 x i8] zeroinitializer, align 16
@__compressedAssemblyData_304 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_305 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_306 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_307 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_308 = internal dso_local global [5632 x i8] zeroinitializer, align 16
@__compressedAssemblyData_309 = internal dso_local global [338432 x i8] zeroinitializer, align 16
@__compressedAssemblyData_310 = internal dso_local global [5632 x i8] zeroinitializer, align 16
@__compressedAssemblyData_311 = internal dso_local global [700928 x i8] zeroinitializer, align 16
@__compressedAssemblyData_312 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_313 = internal dso_local global [324096 x i8] zeroinitializer, align 16
@__compressedAssemblyData_314 = internal dso_local global [20992 x i8] zeroinitializer, align 16
@__compressedAssemblyData_315 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_316 = internal dso_local global [15360 x i8] zeroinitializer, align 16
@__compressedAssemblyData_317 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_318 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_319 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_320 = internal dso_local global [4608 x i8] zeroinitializer, align 16
@__compressedAssemblyData_321 = internal dso_local global [11264 x i8] zeroinitializer, align 16
@__compressedAssemblyData_322 = internal dso_local global [66560 x i8] zeroinitializer, align 16
@__compressedAssemblyData_323 = internal dso_local global [11264 x i8] zeroinitializer, align 16
@__compressedAssemblyData_324 = internal dso_local global [4608 x i8] zeroinitializer, align 16
@__compressedAssemblyData_325 = internal dso_local global [6144 x i8] zeroinitializer, align 16
@__compressedAssemblyData_326 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_327 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_328 = internal dso_local global [5120 x i8] zeroinitializer, align 16
@__compressedAssemblyData_329 = internal dso_local global [4608 x i8] zeroinitializer, align 16
@__compressedAssemblyData_330 = internal dso_local global [20992 x i8] zeroinitializer, align 16
@__compressedAssemblyData_331 = internal dso_local global [2711040 x i8] zeroinitializer, align 16
@__compressedAssemblyData_332 = internal dso_local global [166912 x i8] zeroinitializer, align 16
@__compressedAssemblyData_333 = internal dso_local global [19008 x i8] zeroinitializer, align 16
@__compressedAssemblyData_334 = internal dso_local global [1919488 x i8] zeroinitializer, align 16

; Metadata
!llvm.module.flags = !{!0, !1}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!".NET for Android remotes/origin/release/9.0.1xx @ 9abff7703206541fdb83ffa80fe2c2753ad1997b"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
