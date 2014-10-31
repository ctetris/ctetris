using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

public class ExportResources{
	
	#region public p
	
	public const string OutLuaPath="/StreamingAssets/"+Common.LUACFOLDER;
	public static string outConfigPath=Application.streamingAssetsPath+"/config.tz";
	//public const string zipPassword="hugula@pl@";
	public static string outAndroidZipt4f=Application.streamingAssetsPath+"/data.zip";
#if Nlua 
    #if UNITY_EDITOR_OSX
	    public static string luacPath=Application.dataPath+"/../tools/luaTools/luac";
    #else
        public static string luacPath = Application.dataPath + "/../tools/luaTools/win/luac.exe";
    #endif
#else
#if UNITY_EDITOR_OSX
	    public static string luacPath=Application.dataPath+"/../tools/luaTools/luajit";
#else
    public static string luacPath = Application.dataPath + "/../tools/luaTools/win/luajit.exe";
    #endif
#endif
	#endregion


    #region export
    [MenuItem("Pu Game/", false, 11)]
    static void Breaker() { }

	[MenuItem("Pu Game/export lua [Assets\\Lua]",false,12)]
	public static void exportLua()
	{
		checkLuaExportPath();

         string  path= Application.dataPath+"/Lua"; //AssetDatabase.GetAssetPath(obj).Replace("Assets","");
		
         List<string> files =getAllChildFiles(path);// Directory.GetFiles(Application.dataPath + path);
		
		IList<string> childrens = new List<string>();
		
		foreach (string file in files)
         {
             if (file.EndsWith("lua")) 
			 {
                 childrens.Add(file);
             }
         }
        Debug.Log("luajit path = "+luacPath);
		string crypName="",fileName="",outfilePath="",arg="";
		System.Text.StringBuilder sb=new System.Text.StringBuilder();
		 foreach (string filePath in childrens)
         {
			fileName=CUtils.GetURLFileName(filePath);
			//crypName=CryptographHelper.CrypfString(fileName);
            crypName = filePath.Replace(path,"").Replace(".lua","."+Common.LUA_LC_SUFFIX).Replace("\\","/");
			outfilePath=Application.dataPath+OutLuaPath+crypName;
            checkLuaChildDirectory(outfilePath);
#if Nlua 
             arg="-o "+outfilePath+" "+filePath;
#else
            arg = "-b " + filePath + " " + outfilePath; //for jit
#endif
            Debug.Log(arg);
            sb.Append(fileName);
            sb.Append("=");
            sb.Append(crypName);
            sb.Append("\n");
            System.Diagnostics.Process.Start(luacPath, arg);//arg -b hello1.lua hello1.out
		 }
		Debug.Log(sb.ToString());
		 Debug.Log("lua:"+path+"files="+files.Count+" completed");
	}

    [MenuItem("Pu Game/export config [Assets\\Config]", false, 13)]
	public static void exportConfig()
	{
		string  path= Application.dataPath+"/Config"; //AssetDatabase.GetAssetPath(obj).Replace("Assets","");
		FastZip f=new FastZip();
        f.Password = Common.CONFIG_ZIP_PWD; //CryptographHelper.CrypfString(zipPassword,"");
		f.CreateZip(outConfigPath,path,false,"^.*(.csv)$");
		Debug.Log(" export config done: "+outConfigPath+" !");
	}

    [MenuItem("Pu Game/export language [Assets\\Lan]", false, 14)]
    public static void exportLanguage()
    {
        string assetPath = "Assets/Lan/";
        string path = Application.dataPath + "/Lan/"; //AssetDatabase.GetAssetPath(obj).Replace("Assets","");

        List<string> files = getAllChildFiles(path,"csv");

        foreach (string name in files)
        {
            string abPath = assetPath+name.Replace(path, "");
           // Debug.Log(abPath);
            ExportAssetBundles.BuildTextAsset(abPath);
        }
    }

    [MenuItem("Pu Game/", false, 15)]
    static void Breaker1() { }

    [MenuItem("Pu Game/android export one key ", false,15)]
	public static void exporAndroid()
	{
		exportLua();
		
		exportConfig();

        exportLanguage();

        autoVerAdd();
		
		string  path= Application.streamingAssetsPath+""; //AssetDatabase.GetAssetPath(obj).Replace("Assets","");
		FastZip f=new FastZip();
		f.CreateZip(outAndroidZipt4f,path,true,"(^.*(."+Common.LUA_LC_SUFFIX+")$|ver.t$)");//[^.*(.t4f)$|Ver.txt|t4f]
		Debug.Log(" export android done: "+outConfigPath+" !");

       // Directory.Delete(Application.streamingAssetsPath + "/" + Common.LUACFOLDER, true);
	}

    [MenuItem("Pu Game/other platform export one key ", false, 16)]
	public static void exportIphone()
	{
		exportLua();
		
		exportConfig();

        exportLanguage();

        autoVerAdd();

		if(File.Exists(outAndroidZipt4f))
			File.Delete(outAndroidZipt4f);
	}
	
	#endregion
	
	#region private
    /// <summary>
    /// 资源版本号自动加一
    /// </summary>
    private static void autoVerAdd()
    {
        string curr = "";
        string path=Application.streamingAssetsPath + "/Ver.t";

         using (FileStream fs = File.Open(path,FileMode.OpenOrCreate,FileAccess.Read))
        {
            StreamReader sr = new StreamReader(fs);
             curr = sr.ReadToEnd();
             Debug.Log("current ver is " + curr);
             if (curr=="")curr="0";
             curr = (int.Parse(curr)+1).ToString();
        }

         using (StreamWriter sr = new StreamWriter(path, false))
         {
             Debug.Log("new ver is " + curr);
             sr.WriteLine(curr);
         }
    }

    private static void checkLuaChildDirectory(string fullpath)
    {
        DirectoryInfo info = Directory.GetParent(fullpath);
        string Dir = info.FullName; 
        if (!Directory.Exists(Dir))
        {
            Directory.CreateDirectory(Dir);
        }
    }
	
	private static void checkLuaExportPath()
	{
		string dircAssert=Application.dataPath+OutLuaPath;
		if(!Directory.Exists(dircAssert))
		{
			Directory.CreateDirectory(dircAssert);
		}
	}
	
	public static List<string> getAllChildFiles(string path,string suffix="lua",List<string> files=null)
	{
		if(files==null)files=new List<string>();
		addFiles(path,suffix,files);
		string[] dires=Directory.GetDirectories(path);
		foreach(string dirp in dires)
		{
//            Debug.Log(dirp);
			getAllChildFiles(dirp,suffix,files);
		}
		return files;
	}
	
    public static void addFiles(string direPath,string suffix,List<string> files)
	{
		string[] fileMys=Directory.GetFiles(direPath);
		foreach(string f in fileMys)
		{
			if(f.ToLower().EndsWith(suffix.ToLower())) 
			{
				files.Add(f);
			}
		}
	}
	#endregion
}
