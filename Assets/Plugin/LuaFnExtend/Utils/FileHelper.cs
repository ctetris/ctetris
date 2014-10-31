using UnityEngine;
using System.Collections;
using System.IO;
using System;

using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

#if Nlua
using NLua;
#else
using LuaInterface;
#endif

public partial class FileHelper  {

	private static LuaFunction callBackFn;

	public static void UnpackConfigZipFn(byte[] bytes, LuaFunction luaFn)
	{
		callBackFn = luaFn;
		using (MemoryStream m = new MemoryStream(bytes))
		{
			ZipFile z = new ZipFile(m);
			z.Password = Common.CONFIG_ZIP_PWD;
			foreach (ZipEntry ze in z)
			{
				if (ze.IsFile)
				{
					Stream str = z.GetInputStream(ze);
					using (StreamReader sr = new StreamReader(str))
					{
						string conext = sr.ReadToEnd();
						if (callBackFn != null)
							callBackFn.Call(ze.Name,conext);
					}
				}
			}
			callBackFn= null;
		}
	}
}
