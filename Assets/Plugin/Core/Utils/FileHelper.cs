using UnityEngine;
using System.Collections;
using System.IO;
using System;

using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

public partial class FileHelper  {

	public static void UnZipFile(string path,string outPath)
	{
		if(File.Exists(path))
		{
			using (ZipInputStream s = new ZipInputStream(File.OpenRead(path))) {
			
				ZipEntry theEntry;
				while ((theEntry = s.GetNextEntry()) != null) {
					
					Debug.Log("file name"+theEntry.Name);
					
					string directoryName = Path.GetDirectoryName(theEntry.Name);
					string fileName      = Path.GetFileName(theEntry.Name);
					//Debug.Log(string.Format("directoryName:{0},fileName:{1}",directoryName,fileName));
					// create directory
					if ( directoryName.Length > 0 ) {
						Directory.CreateDirectory(directoryName);
					}
					
					if (fileName != String.Empty) {
						using (FileStream streamWriter = File.Create(theEntry.Name)) {
							int size = 2048;
							byte[] data = new byte[2048];
							while (true) {
								size = s.Read(data, 0, data.Length);
								if (size > 0) {
									streamWriter.Write(data, 0, size);
								} else {
									break;
								}
							}
						}
					}
				}
			}
		}else
		{
			Debug.Log("path :"+path+" is not exists "+outPath);
		}
	}
	
	public static void UnZipFile(Stream stream,string outPath)
	{
		using (ZipInputStream s = new ZipInputStream(stream)) 
		{
			ZipEntry theEntry;
			while ((theEntry = s.GetNextEntry()) != null) 
			{
				string directoryName = Path.GetDirectoryName(theEntry.Name);
				string fileName      = Path.GetFileName(theEntry.Name);
				//Debug.Log(string.Format("directoryName:{0},fileName:{1}",directoryName,fileName));
				// create directory
				if ( directoryName.Length > 0 ) {
					Directory.CreateDirectory(outPath+"/"+directoryName);
				}
					
				if (fileName != String.Empty) 
				{
                    Debug.Log(outPath + "/" + theEntry.Name);
					using (FileStream streamWriter = File.Create(outPath+"/"+theEntry.Name)) 
					{
						int size = 2048;
						byte[] data = new byte[2048];
						while (true) 
						{
							size = s.Read(data, 0, data.Length);
							if (size > 0) 
							{
								streamWriter.Write(data, 0, size);
							} else {
								break;
							}
						}
					}
				}
			}
		}
	}

    public static void UnZipFile(byte[] bytes,string outPath)
    {
         using (MemoryStream m = new MemoryStream(bytes))
        {
            UnZipFile(m,outPath);
        }
    }
    /// <summary>
    /// Unpacks the text zip.
    /// </summary>
    /// <param name='strem'>
    /// Strem.
    /// </param>
    /// <param name='ontz'>
    /// Ontz.
    /// </param>
    public static void UnpackConfigZip(byte[] bytes, onTxtUnZip ontz)
    {
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
                        if (ontz != null)
                            ontz(ze.Name, conext);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Save context in persistentDataPath
    /// </summary>
    /// <param name="context"></param>
    /// <param name="fileName"></param>
    public static void PersistentUTF8File(string context, string fileName)
    {
        string path = Application.persistentDataPath + "/" + fileName;
       // byte[] id = System.Text.ASCIIEncoding.UTF8.GetBytes(context);
        //using (FileStream streamWriter = File.Open(path,FileMode.OpenOrCreate,FileAccess.ReadWrite))
        //{
        //    streamWriter.Write(id, 0, id.Length);
        //}
        using (StreamWriter sr = new StreamWriter(path, false))
        {
            sr.WriteLine(context);
        }
    }
}

public delegate void onTxtUnZip(string name, string conext);
