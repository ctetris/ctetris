using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

public class BeginSample : MonoBehaviour {
	
	public bool editorDebug=false;
    public bool openUpdate = true;
    //public bool openFixedUpdate = true;
    //public bool openLateUpdate = true;
    public string enterLua = "main";

    private static BeginSample _instance;
    public const string VERSION_FILE_NAME = "Ver.t";

    private int persistentVersion = 0;
    private int streamingVersion = 1;

    public static BeginSample instance
    {
        get
        {
            return _instance;
        }
    }

    private LMultipleLoader multipleLoader;

    void Awake()
    {
        multipleLoader = LMultipleLoader.instance;
        _instance = this;
    }

	// Use this for initialization
	void Start () 
	{
        PlatformInit();
	}

	#region platform init
	
	void AndroidInit()
    {
       StartCoroutine(CompareAndroidVersion());
	}
	
	void IphoneInit()
	{
        LuaBegin();
	}
	
	void Wp8Init()
	{
        LuaBegin();
	}
	
	void WindowsPlayerInit()
	{
        LuaBegin();
	}
	
	void WindowsEditorInit()
	{
       LuaBegin();
	}
	
	void OsxEditorInit()
	{
        LuaBegin();
	}
	
	void LuaBegin()
    {
        //Debug.Log("LuaBegin");
		PLua luab=this.gameObject.GetComponent<PLua>();
		if(luab==null)
		{
            PLua p=gameObject.AddComponent<PLua>();
            p.isDebug = editorDebug;
            p.enterLua = this.enterLua;
        }
        else if (luab.enabled == false)
        {
            luab.enabled = true;
        }
	}
	
	void PlatformInit()
	{
		if(Application.platform==RuntimePlatform.Android)
		{
			AndroidInit();
		}else if(Application.platform==RuntimePlatform.IPhonePlayer)
		{
			IphoneInit();
		}else if(Application.platform==RuntimePlatform.WP8Player)
		{
			Wp8Init();
		}else if(Application.platform==RuntimePlatform.WindowsPlayer)
		{
			WindowsPlayerInit();
		}else if(Application.platform==RuntimePlatform.OSXEditor)
		{
			OsxEditorInit();
        }
        else if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            WindowsEditorInit();
        }
        else
        {
            LuaBegin();
        }
	}
	#endregion

    #region protected

    private IEnumerator CompareAndroidVersion()
    {
        ReadPersistentVersion();
        string path = Application.streamingAssetsPath + "/" + VERSION_FILE_NAME;
        WWW www = new WWW(path);
        yield return www;
        this.streamingVersion = int.Parse(www.text.Trim());
        Debug.Log(string.Format(" persistentVersion= {0},streamingVersion = {1}", this.persistentVersion, this.streamingVersion));
        if (this.persistentVersion < this.streamingVersion)// copy streaming to persistent
        {
            string fileName = Application.streamingAssetsPath + "/data.zip";//  --System.IO.Path.ChangeExtension(Application.streamingAssetsPath,".zip");
            CRequest req = new CRequest(fileName);
            req.OnComplete += delegate(CRequest r)
            {
                byte[] bytes = null;
                if (r.data is WWW)
                {
                    WWW www1 = r.data as WWW;
                    bytes = www1.bytes;
                }
                FileHelper.UnZipFile(bytes, Application.persistentDataPath);
                LuaBegin();
            };
            this.multipleLoader.LoadReq(req);
        }
        else
        {
            LuaBegin();
        }
    }

    private void ReadPersistentVersion()
    {
        string path = Application.persistentDataPath + "/" + VERSION_FILE_NAME; 
        if (File.Exists(path))//if exists version file
        {
            using(StreamReader sr=File.OpenText(path))
            {
                this.persistentVersion =int.Parse(sr.ReadToEnd());
            }
        }
    }

    #endregion
}
