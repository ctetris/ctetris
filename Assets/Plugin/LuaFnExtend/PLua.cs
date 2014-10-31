using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using System;
#if Nlua
using NLua;
using Lua = NLua.Lua;
#else
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;
#endif

public class PLua :MonoBehaviour {

    public string enterLua = "main";
    //public LuaFunction fixedUpdateFn;
    //public LuaFunction lateUpdateFn;
    public LuaFunction onDestroyFn;

    public bool isDebug = true;
//    public bool openUpdate = true;
    //public bool openFixedUpdate = true;
    //public bool openLateUpdate = true;

    public Lua lua;
    public LNet net;
	public LNet ChatNet;
    public LuaState luaState;

  	public static string package_path {private set;get;}

    private string luaMain = "";

    public static bool isNlua { private set; get; }

	private const string assemblyname= "assemblyname";
	private LuaCSFunction requireFunction;
	private LuaCSFunction delayFunction;
	/// <summary>
	/// lua xiecheng The co.
	/// </summary>
	private LuaThread co = null;

	private LuaFunction _updateFn;
    #region mono

	public LuaFunction updateFn{
		get{ return _updateFn;}
		set
		{
			if(value!=null)
			{
				_updateFn=value;
				co=new LuaThread(lua,_updateFn);
				co.Start();
			}else
				co=null;
		}
	}

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
#if Nlua
        lua = new Lua();
        isNlua = true;
#else
        lua = new Lua();
        isNlua = false;
        luaState = lua.L;
#endif
        ToLuaCS.lua = lua;
        _instance = this;
        LoadScript();
        //Profiler.BeginSample("LuaRegister");
        //LuaRegister.Start();
        //Profiler.EndSample();

    }

    void Start()
    {
        net = LNet.instance;
		ChatNet = LNet.ChatInstance;
		lua.DoString(this.luaMain);
		updateFn=lua.GetFunction("update");
    }

    void Update()
    {
        if(net!=null) net.Update();
		if(ChatNet!=null) ChatNet.Update();
        //if (_updateFn != null) _updateFn.Call();
        if (co != null && !co.IsDead())
        {
            co.Resume();
        }
        else
        {
            // In order to destroy a coroutine (but not the function in lua, just the coroutine stack instance) simply allow C# to clean up the wrapped object
            co = null;
        }

        Timer.Update();
    }

   void OnApplicationPause(bool pauseStatus)
   {
       //net.OnApplicationPause(pauseStatus);
   }

   void  OnDestroy() {
       if (onDestroyFn != null) onDestroyFn.Call();
        updateFn=null;
        lua.Close();
        lua = null;
        _instance = null;
        net.Dispose();
        net = null;
		ChatNet.Dispose();
		ChatNet = null;
    }

    #endregion

    private void SetLuaPath()
    {
        System.Text.StringBuilder luaBegin = new System.Text.StringBuilder();
        string lua_data_path=UnityEngine.Application.dataPath+"/Lua/";
        string lua_persistent_path = string.Format("{0}/{1}/", UnityEngine.Application.persistentDataPath, Common.LUACFOLDER);
        string lua_streaming_Path = string.Format("{0}/{1}/", UnityEngine.Application.streamingAssetsPath, Common.LUACFOLDER);
#if UNITY_EDITOR
        if (isDebug)
        {
			package_path = lua_data_path + "?.lua";
            //luaBegin.Append("package.path=\"" + lua_data_path + "?.lua \" \n ");
        }else
        {
			package_path = lua_streaming_Path + "?." + Common.LUA_LC_SUFFIX ;
            //luaBegin.Append("package.path=\"" + lua_streaming_Path + "?." + Common.LUA_LC_SUFFIX + " \" \n ");
        }
#else
		package_path =  lua_persistent_path + "?." + Common.LUA_LC_SUFFIX + ";" + lua_streaming_Path + "?." + Common.LUA_LC_SUFFIX ;
        //luaBegin.Append("package.path=\"" + lua_persistent_path + "?." + Common.LUA_LC_SUFFIX + ";" + lua_streaming_Path + "?." + Common.LUA_LC_SUFFIX + " \" \n ");
#endif

		luaBegin.Append("package.path=\""+package_path+" \" \n");
		luaBegin.Append("return require(\""+this.enterLua+"\") \n");
		this.luaMain = luaBegin.ToString();
        Debug.Log(luaMain);
    }

	private void LoadScript()
	{
		SetLuaPath();

		RegisterFunc();

		Assembly assb=Assembly.GetExecutingAssembly();
		string assemblyname=assb.GetName().Name;
		lua["assemblyname"]=assemblyname;
    }

    #region toolMethod

    public void RegisterFunc()
    {
	#if UNITY_EDITOR_OSX || UNITY_IPHONE
		//lua.RegisterFunction("require",this,this.GetType().GetMethod("Require"));
		requireFunction = new LuaCSFunction(RequireLua);
		LuaDLL.lua_pushstdcallcfunction(luaState, requireFunction);
		LuaDLL.lua_setfield(luaState, LuaIndexes.LUA_GLOBALSINDEX, "require");
	#endif
//		delayFunction= new LuaCSFunction(DelayLua); 
//		LuaDLL.lua_pushstdcallcfunction(luaState, delayFunction);
//		LuaDLL.lua_setfield(luaState, LuaIndexes.LUA_GLOBALSINDEX, "delay");

        lua.RegisterFunction("delay", this, this.GetType().GetMethod("Delay"));
        lua.RegisterFunction("stopDelay", this, this.GetType().GetMethod("StopDelay"));

    }

	#if UNITY_EDITOR_OSX || UNITY_IPHONE
	private static char[] split=new char[]{';'};
	public object Require(string modle)
	{
		string path=modle.Replace(".","/");
		object[] re=null;
		string paths=package_path.Replace("?",path);
		string[] lua_paths = paths.Split(split);
		foreach(string iPath in lua_paths)
		{
			if(File.Exists(iPath)){
				re = lua.DoFile(iPath);
				if(re!=null && re.Length==1) return re[0];
				return re;
			}
		}
		return null;
	}

	/// <summary>
	/// Require the specified L.
	/// </summary>
	/// <param name="L">L.</param>
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))] 
	public static int RequireLua(LuaState L)
	{
		string modle=LuaDLL.lua_tostring(L,1);
		string path=modle.Replace(".","/");
		object[] re=null;
		string paths=package_path.Replace("?",path);
		string[] lua_paths = paths.Split(split);
		LuaDLL.lua_pop(L,1);
		foreach(string iPath in lua_paths)
		{
			if(File.Exists(iPath)){

				int oldTop=LuaDLL.lua_gettop(L);

				if( LuaDLL.luaL_loadfile(L,iPath) == 0 )
				{

					if (LuaDLL.lua_pcall(L, 0, -1, -2) == 0)
					{
						int i =LuaDLL.lua_gettop(L);
						return i;
					}
				}

//				re = lua.DoFile(iPath);
//				if(re!=null && re.Length==1) return re[0];
//				return re;
			}
		}
		return 0;
	}
	#endif

	public static void Log(object msg)
	{
		Debug.Log(msg);
	}

    public static void Delay(LuaFunction luafun, float time,object args=null)
    {
        _instance.StartCoroutine(DelayDo(luafun, args, time));
    }

    public static void StopDelay(string methodName = "DelayDo")
    {
        _instance.StopCoroutine(methodName);
    }

    private static IEnumerator DelayDo(LuaFunction luafun, object arg, float time)
    {
        yield return new WaitForSeconds(time);
        luafun.Call(arg);
    }

    #endregion

	#region lua bind
	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))] 
	public static int DelayLua(LuaState L)
	{
		_instance.StartCoroutine(DelayDo(L));
		return 0;
	}

	private static IEnumerator DelayDo(LuaState L)
	{
		float time=(float)LuaDLL.lua_tonumber(L,2);
		Debug.Log(time);
		LuaDLL.lua_remove(L,2);
		Debug.Log(LuaDLL.lua_gettop(L));
		Debug.Log(LuaDLL.lua_type(L,1));
		yield return new WaitForSeconds(time);
		Debug.Log(LuaDLL.lua_gettop(L));
		Debug.Log(LuaDLL.lua_type(L,1));
		Debug.Log(LuaDLL.lua_type(L,2));

		if(LuaDLL.lua_type(L,1)== LuaTypes.LUA_TFUNCTION)
		{
			LuaDLL.lua_pcall(L,0,0,0);
		}
	}

	#endregion

    #region static
    private static PLua _instance;
	
	public static PLua instance
	{
		get{
			return _instance;
		}
	}
	#endregion

}
