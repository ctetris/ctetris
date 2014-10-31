using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_WWW {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.WWW).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.WWW).AssemblyQualifiedName);
          LuaDLL.lua_pushlightuserdata(L, LuaDLL.luanet_gettag());
          LuaDLL.lua_pushnumber(L, 1);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__gc");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.gcFunction);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__tostring");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.toStringFunction);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceIndex);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.InstanceNewIndex);
          LuaDLL.lua_rawset(L, -3);

      #region 判断父类
          System.Type superT = typeof(UnityEngine.WWW).BaseType;
          if (superT != null)
          {
              LuaDLL.luaL_getmetatable(L, superT.AssemblyQualifiedName);
              if (!LuaDLL.lua_isnil(L, -1))
              {
                  LuaDLL.lua_setmetatable(L, -2);
              }
              else
              {
                  LuaDLL.lua_remove(L, -1);
              }
          }
      #endregion

      #region  注册实例luameta
          LuaDLL.lua_pushstring(L,"Dispose");
          luafn_Dispose= new LuaCSFunction(Dispose);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Dispose);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"InitWWW");
          luafn_InitWWW= new LuaCSFunction(InitWWW);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_InitWWW);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_responseHeaders");
          luafn_get_responseHeaders= new LuaCSFunction(get_responseHeaders);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_responseHeaders);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_text");
          luafn_get_text= new LuaCSFunction(get_text);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_text);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_bytes");
          luafn_get_bytes= new LuaCSFunction(get_bytes);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_bytes);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_size");
          luafn_get_size= new LuaCSFunction(get_size);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_size);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_error");
          luafn_get_error= new LuaCSFunction(get_error);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_error);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_texture");
          luafn_get_texture= new LuaCSFunction(get_texture);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_texture);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_textureNonReadable");
          luafn_get_textureNonReadable= new LuaCSFunction(get_textureNonReadable);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_textureNonReadable);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_audioClip");
          luafn_get_audioClip= new LuaCSFunction(get_audioClip);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_audioClip);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetAudioClip");
          luafn_GetAudioClip= new LuaCSFunction(GetAudioClip);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetAudioClip);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_movie");
          luafn_get_movie= new LuaCSFunction(get_movie);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_movie);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LoadImageIntoTexture");
          luafn_LoadImageIntoTexture= new LuaCSFunction(LoadImageIntoTexture);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LoadImageIntoTexture);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_isDone");
          luafn_get_isDone= new LuaCSFunction(get_isDone);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_isDone);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_progress");
          luafn_get_progress= new LuaCSFunction(get_progress);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_progress);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_uploadProgress");
          luafn_get_uploadProgress= new LuaCSFunction(get_uploadProgress);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_uploadProgress);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_bytesDownloaded");
          luafn_get_bytesDownloaded= new LuaCSFunction(get_bytesDownloaded);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_bytesDownloaded);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LoadUnityWeb");
          luafn_LoadUnityWeb= new LuaCSFunction(LoadUnityWeb);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LoadUnityWeb);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_url");
          luafn_get_url= new LuaCSFunction(get_url);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_url);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_assetBundle");
          luafn_get_assetBundle= new LuaCSFunction(get_assetBundle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_assetBundle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_threadPriority");
          luafn_get_threadPriority= new LuaCSFunction(get_threadPriority);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_threadPriority);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_threadPriority");
          luafn_set_threadPriority= new LuaCSFunction(set_threadPriority);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_threadPriority);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Equals");
          luafn_Equals= new LuaCSFunction(Equals);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Equals);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetHashCode");
          luafn_GetHashCode= new LuaCSFunction(GetHashCode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetHashCode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetType");
          luafn_GetType= new LuaCSFunction(GetType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ToString");
          luafn_ToString= new LuaCSFunction(ToString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ToString);
          LuaDLL.lua_rawset(L, -3);

      #endregion

  #region  static method       
          //static    
          LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));
          LuaDLL.lua_getglobal(L,ToLuaCS.GlobalTableName);
          if (LuaDLL.lua_isnil(L, -1))
          {
             LuaDLL.lua_newtable(L);//table
             LuaDLL.lua_setglobal(L, ToLuaCS.GlobalTableName);//pop table
             LuaDLL.lua_pop(L, LuaDLL.lua_gettop(L));
             LuaDLL.lua_getglobal(L, ToLuaCS.GlobalTableName);
          }
    
          string[] names = typeof(UnityEngine.WWW).FullName.Split(new char[] { '.' });
          foreach (string name in names)
          {
              LuaDLL.lua_getfield(L, -1, name);
              if (LuaDLL.lua_isnil(L, -1))
              {
                  LuaDLL.lua_pop(L, 1);
                  LuaDLL.lua_pushstring(L, name);
                  LuaDLL.lua_newtable(L);
                  LuaDLL.lua_rawset(L, -3);
                  LuaDLL.lua_getfield(L, -1, name);
              }   
    
              LuaDLL.lua_remove(L, -2);
          }
          LuaDLL.lua_pushstring(L, "name");
          LuaDLL.lua_pushstring(L, typeof(UnityEngine.WWW).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"EscapeURL");
          luafn_EscapeURL= new LuaCSFunction(EscapeURL);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_EscapeURL);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"UnEscapeURL");
          luafn_UnEscapeURL= new LuaCSFunction(UnEscapeURL);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_UnEscapeURL);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LoadFromCacheOrDownload");
          luafn_LoadFromCacheOrDownload= new LuaCSFunction(LoadFromCacheOrDownload);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LoadFromCacheOrDownload);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_Dispose;
          private static LuaCSFunction luafn_InitWWW;
          private static LuaCSFunction luafn_get_responseHeaders;
          private static LuaCSFunction luafn_get_text;
          private static LuaCSFunction luafn_get_bytes;
          private static LuaCSFunction luafn_get_size;
          private static LuaCSFunction luafn_get_error;
          private static LuaCSFunction luafn_get_texture;
          private static LuaCSFunction luafn_get_textureNonReadable;
          private static LuaCSFunction luafn_get_audioClip;
          private static LuaCSFunction luafn_GetAudioClip;
          private static LuaCSFunction luafn_get_movie;
          private static LuaCSFunction luafn_LoadImageIntoTexture;
          private static LuaCSFunction luafn_get_isDone;
          private static LuaCSFunction luafn_get_progress;
          private static LuaCSFunction luafn_get_uploadProgress;
          private static LuaCSFunction luafn_get_bytesDownloaded;
          private static LuaCSFunction luafn_LoadUnityWeb;
          private static LuaCSFunction luafn_get_url;
          private static LuaCSFunction luafn_get_assetBundle;
          private static LuaCSFunction luafn_get_threadPriority;
          private static LuaCSFunction luafn_set_threadPriority;
          private static LuaCSFunction luafn_Equals;
          private static LuaCSFunction luafn_GetHashCode;
          private static LuaCSFunction luafn_GetType;
          private static LuaCSFunction luafn_ToString;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_EscapeURL;
          private static LuaCSFunction luafn_UnEscapeURL;
          private static LuaCSFunction luafn_LoadFromCacheOrDownload;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Dispose(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  target.Dispose();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InitWWW(LuaState L)
          {
                  System.String url_ =  LuaDLL.lua_tostring(L,2); 

                  System.Byte[] postData_ = (System.Byte[])ToLuaCS.getObject(L,3);
                  System.String[] iHeaders_ = (System.String[])ToLuaCS.getObject(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  target.InitWWW( url_, postData_, iHeaders_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_responseHeaders(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Collections.Generic.Dictionary<System.String,System.String> responseHeaders= target.responseHeaders;
                  ToLuaCS.push(L,responseHeaders); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_text(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.String text= target.text;
                  ToLuaCS.push(L,text); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_bytes(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Byte[] bytes= target.bytes;
                  ToLuaCS.push(L,bytes); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_size(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Int32 size= target.size;
                  ToLuaCS.push(L,size); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_error(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.String error= target.error;
                  ToLuaCS.push(L,error); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_texture(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.Texture2D texture= target.texture;
                  ToLuaCS.push(L,texture); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_textureNonReadable(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.Texture2D textureNonReadable= target.textureNonReadable;
                  ToLuaCS.push(L,textureNonReadable); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_audioClip(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.AudioClip audioClip= target.audioClip;
                  ToLuaCS.push(L,audioClip); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetAudioClip(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER  && ToLuaCS.getObject(L, 4) is UnityEngine.AudioType)
              {
                  System.Boolean threeD_ =  LuaDLL.lua_toboolean(L,2);
                  System.Boolean stream_ =  LuaDLL.lua_toboolean(L,3);
                  UnityEngine.AudioType audioType_ = (UnityEngine.AudioType)ToLuaCS.getObject(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.AudioClip getaudioclip= target.GetAudioClip( threeD_, stream_, audioType_);
                  ToLuaCS.push(L,getaudioclip); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Boolean threeD_ =  LuaDLL.lua_toboolean(L,2);
                  System.Boolean stream_ =  LuaDLL.lua_toboolean(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.AudioClip getaudioclip= target.GetAudioClip( threeD_, stream_);
                  ToLuaCS.push(L,getaudioclip); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER )
              {
                  System.Boolean threeD_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.AudioClip getaudioclip= target.GetAudioClip( threeD_);
                  ToLuaCS.push(L,getaudioclip); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_movie(LuaState L)
          {

                  //object original = ToLuaCS.getObject(L, 1);
                  //UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  //UnityEngine.MovieTexture movie= target.movie;
                  //ToLuaCS.push(L,movie); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadImageIntoTexture(LuaState L)
          {
                  UnityEngine.Texture2D tex_ = (UnityEngine.Texture2D)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  target.LoadImageIntoTexture( tex_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isDone(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Boolean isDone= target.isDone;
                  ToLuaCS.push(L,isDone); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_progress(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Single progress= target.progress;
                  ToLuaCS.push(L,progress); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_uploadProgress(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Single uploadProgress= target.uploadProgress;
                  ToLuaCS.push(L,uploadProgress); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_bytesDownloaded(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Int32 bytesDownloaded= target.bytesDownloaded;
                  ToLuaCS.push(L,bytesDownloaded); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadUnityWeb(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  target.LoadUnityWeb();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_url(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.String url= target.url;
                  ToLuaCS.push(L,url); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_assetBundle(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.AssetBundle assetBundle= target.assetBundle;
                  ToLuaCS.push(L,assetBundle); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_threadPriority(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  UnityEngine.ThreadPriority threadPriority= target.threadPriority;
                  ToLuaCS.push(L,threadPriority); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_threadPriority(LuaState L)
          {
                  UnityEngine.ThreadPriority value_ = (UnityEngine.ThreadPriority)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  target.threadPriority= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Boolean equals= target.Equals( obj_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.WWW target= (UnityEngine.WWW) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int EscapeURL(LuaState L)
          {
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 2) is System.Text.Encoding)
              {
                  System.String s_ =  LuaDLL.lua_tostring(L,1); 

                  System.Text.Encoding e_ = (System.Text.Encoding)ToLuaCS.getObject(L,2);

                  System.String escapeurl= UnityEngine.WWW.EscapeURL( s_, e_);
                  ToLuaCS.push(L,escapeurl); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING )
              {
                  System.String s_ =  LuaDLL.lua_tostring(L,1); 


                  System.String escapeurl= UnityEngine.WWW.EscapeURL( s_);
                  ToLuaCS.push(L,escapeurl); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int UnEscapeURL(LuaState L)
          {
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 2) is System.Text.Encoding)
              {
                  System.String s_ =  LuaDLL.lua_tostring(L,1); 

                  System.Text.Encoding e_ = (System.Text.Encoding)ToLuaCS.getObject(L,2);

                  System.String unescapeurl= UnityEngine.WWW.UnEscapeURL( s_, e_);
                  ToLuaCS.push(L,unescapeurl); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING )
              {
                  System.String s_ =  LuaDLL.lua_tostring(L,1); 


                  System.String unescapeurl= UnityEngine.WWW.UnEscapeURL( s_);
                  ToLuaCS.push(L,unescapeurl); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadFromCacheOrDownload(LuaState L)
          {
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 

                  System.Int32 version_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.UInt32 crc_ = (System.UInt32)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.WWW loadfromcacheordownload= UnityEngine.WWW.LoadFromCacheOrDownload( url_, version_, crc_);
                  ToLuaCS.push(L,loadfromcacheordownload); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER )
              {
                  System.String url_ =  LuaDLL.lua_tostring(L,1); 

                  System.Int32 version_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.WWW loadfromcacheordownload= UnityEngine.WWW.LoadFromCacheOrDownload( url_, version_);
                  ToLuaCS.push(L,loadfromcacheordownload); 
                  return 1;

              }
          return 0;
          }
  #endregion       
}

