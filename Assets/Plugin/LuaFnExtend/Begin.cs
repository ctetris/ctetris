using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

public class Begin : MonoBehaviour {
	
	public bool Editor_Debug=false;
	public string ResourceURL ="http://121.199.51.39:8080/client_update?v_id={0}&platform={1}&code={2}";

	private UILabel progressBarTxt;
	private string update_id="";
    private static Begin _instance;

    public const string FRIST_VIEW = "Frist.u3d";
    public const string VIDEO_NAME = "Loading.mp4";
    public const string VERSION_FILE_NAME = "Ver.t";

    public static string resVersion = "0";
    public static Begin instance
    {
        get
        {
            return _instance;
        }
    }

    public LMultipleLoader multipleLoader;
	public GameObject fristView;

    void Awake()
    {
        _instance = this;
    }

	// Use this for initialization
	void Start () 
	{
    #if UNITY_ANDROID || UNITY_IOS || UNITY_WP8
		StartCoroutine(PlayVideoCoroutine());
    #else
        LoadFrist();
    #endif
	}

#if UNITY_ANDROID || UNITY_IOS || UNITY_WP8
	/// <summary>
	/// 播放视频
	/// </summary>
	/// <returns></returns>
	IEnumerator PlayVideoCoroutine()
	{
        Handheld.PlayFullScreenMovie(VIDEO_NAME, Color.black, FullScreenMovieControlMode.Hidden); 
		yield return new WaitForEndOfFrame();
        multipleLoader = LMultipleLoader.instance;
        LoadFrist();
	}
#endif
    /// <summary>
	/// 加载第一幕
	/// </summary>
	private void LoadFrist()
	{
        string url = CUtils.GetFileFullPath(CUtils.GetAssetPath(FRIST_VIEW));
		CRequest req=new CRequest(url);	
		req.OnComplete+=delegate(CRequest r){

			Application.targetFrameRate=45;

			WWW www=r.data as WWW;
            fristView = Instantiate(www.assetBundle.mainAsset) as GameObject;
            progressBarTxt = fristView.GetComponentInChildren<UILabel>();
            StartCoroutine(StartGame(1f));
            www.assetBundle.Unload(false);
            www.Dispose();
		};

        multipleLoader.LoadReq(req);
	}
    /// <summary>
    /// 开始检测资源
    /// </summary>
    /// <param name="sec"></param>
    /// <returns></returns>
	IEnumerator StartGame( float sec)
	{
		yield return new WaitForSeconds(sec);
		CheckResourceVer();
	}
	
	#region platform init
	
	void AndroidInit()
	{
		if(CUtils.currPersistentExist==false)// nothing 
		{
			string fileName=Application.streamingAssetsPath+"/data.zip";//  --System.IO.Path.ChangeExtension(Application.streamingAssetsPath,".zip");
			Debug.Log("unpack :"+fileName);
			CRequest req=new CRequest(fileName);	
			req.OnComplete+=delegate(CRequest r){
				Debug.Log("loaded  :"+r.url);
				byte[] bytes=null;
				if(r.data is WWW)
				{
					WWW www=r.data as WWW;
					bytes=www.bytes;
				}
				MemoryStream m=new MemoryStream(bytes);
				FileHelper.UnZipFile(m,Application.persistentDataPath);
				Debug.Log("local data zip file to:"+Application.persistentDataPath);
                CheckRes();
			};
			this.multipleLoader.LoadReq(req);
		}else
		{
			CheckRes();
		}
	}
	
	void IphoneInit()
	{
		CheckRes();
	}
	
	void Wp8Init()
	{
		CheckRes();
	}
	
	void WindowsPlayerInit()
	{
		CheckRes();
	}
	
	void WindowsEditorInit()
	{
		CheckRes();
	}
	
	void OsxEditorInit()
	{
		CheckRes();
	}
	
	void CheckRes()
	{
#if UNITY_EDITOR
        SendMessage("LuaBegin", SendMessageOptions.DontRequireReceiver);
#else
		string url=string.Format(ResourceURL,resVersion,Application.platform,Version.VERSION);
		Debug.Log(" update url = "+url);
		CRequest req=new CRequest(url);	
		req.OnComplete+=OnUpdateResComp;
		req.OnEnd+=OnUpdateResComp;
        this.multipleLoader.LoadReq(req);
#endif
	}
	
	void LuaBegin()
	{
		PLua luab=this.gameObject.GetComponent<PLua>();
		if(luab==null)
		{
            PLua p=gameObject.AddComponent<PLua>();
            p.isDebug = Editor_Debug;
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
		}else if(Application.platform==RuntimePlatform.WindowsEditor)
		{
			WindowsEditorInit();
		}
	}
	#endregion
	
	#region check resouce version
    /// <summary>
    /// 检测资源版本号
    /// </summary>
	public void CheckResourceVer()
	{
		Debug.Log("checkVer");
		
		string verPath=CUtils.GetFileFullPath(VERSION_FILE_NAME);
		CRequest req=new CRequest(verPath);	
		req.OnComplete+=OnURLComp;
		req.OnEnd+=OnURLComp;
        this.multipleLoader.LoadReq(req);
	}
	
	void OnURLComp(CRequest req)
	{
		if (req.data is WWW)
		{
			WWW www=req.data as WWW;
			resVersion=www.text;
		}				
		Debug.Log("  Version="+resVersion+" platform="+Application.platform);
		
		PlatformInit();
	}	
	
	void OnUpdateResComp(CRequest req)
	{
        WWW www=(WWW)req.data;
		if(www!=null)
		{
			string txt=www.text;
			Debug.Log("response :"+txt);
            Dictionary<string, object> res = new Dictionary<string, object>();//(Dictionary<string,object>)MiniJSON.Json.Deserialize(txt);
			if(res.ContainsKey("error"))
			{
				SendMessage("LuaBegin",SendMessageOptions.DontRequireReceiver);
			}
			else if(res.ContainsKey("update_url"))
			{
				List<object> upList=(List<object>)res["update_url"]; 
				Debug.Log(upList.GetType());
				List<CRequest> reqs=new List<CRequest>();
				foreach(object kvp in upList)
				{
                    if (!string.IsNullOrEmpty(kvp.ToString())){
					CRequest reqItem=new CRequest(kvp.ToString());
					reqItem.OnComplete+=OnUpdateItemComp;
					reqs.Add(reqItem);}
				}
				update_id=res["update_id"].ToString();
                this.multipleLoader.OnAllComplete += OnAllUpdateResComp;
                this.multipleLoader.OnProgress += OnProccess;
                this.multipleLoader.LoadReq(reqs);

			}else
			{
				SendMessage("LuaBegin",SendMessageOptions.DontRequireReceiver);
			}
		}else
		{
			SendMessage("LuaBegin",SendMessageOptions.DontRequireReceiver);
			Debug.Log(" could not open     "+req.url);
		}

    }
	
	void OnProccess(object loader,LoaderEventArg arg)
	{
		float p=((float)arg.current)/(float)arg.total;
		p=p*100;
		SetProgressTxt(p+"%");
	}
	
	void OnAllUpdateResComp(object loader)
	{
		SetProgressTxt("wait start...");
        multipleLoader.OnAllComplete -= OnAllUpdateResComp;
        multipleLoader.OnProgress -= OnProccess;
        multipleLoader.InitProgressState();
		SendMessage("LuaBegin",SendMessageOptions.DontRequireReceiver);
		SeveVersion();
	}
	
	void SeveVersion()
	{
		string path=Application.persistentDataPath+"/"+ VERSION_FILE_NAME;			
		byte[] id=System.Text.ASCIIEncoding.UTF8.GetBytes(update_id);
		resVersion=update_id;
		using (FileStream streamWriter = File.Create(path)) 
		{
			streamWriter.Write(id,0,id.Length);
		}
		Debug.Log("new version saved "+update_id+" at "+path);
	}
	
	void OnUpdateItemComp(CRequest req)
	{
		Debug.Log(req.url+" complete");
		byte[] bytes=null;
		if(req.data is WWW)
		{
			bytes=((WWW)req.data).bytes;
		}

		if(bytes!=null)
		{
			MemoryStream m=new MemoryStream(bytes);
			FileHelper.UnZipFile(m,Application.persistentDataPath);
		}
	}
	
	#endregion
	
	#region txt

	void SetProgressTxt(string txt)
	{
		if(progressBarTxt!=null)
			progressBarTxt.text=txt;
	}

	public void ClearFrist()
	{
		NGUITools.Destroy(progressBarTxt);
		progressBarTxt=null;
		NGUITools.Destroy(this.fristView);
        fristView = null;
	}
	#endregion
	
}
