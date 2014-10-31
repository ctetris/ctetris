using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_AssetBundle {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.AssetBundle).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.AssetBundle).AssemblyQualifiedName);
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
          System.Type superT = typeof(UnityEngine.AssetBundle).BaseType;
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
          LuaDLL.lua_pushstring(L,"get_mainAsset");
          luafn_get_mainAsset= new LuaCSFunction(get_mainAsset);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_mainAsset);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Contains");
          luafn_Contains= new LuaCSFunction(Contains);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Contains);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Load");
          luafn_Load= new LuaCSFunction(Load);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Load);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LoadAsync");
          luafn_LoadAsync= new LuaCSFunction(LoadAsync);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LoadAsync);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LoadAll");
          luafn_LoadAll= new LuaCSFunction(LoadAll);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LoadAll);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Unload");
          luafn_Unload= new LuaCSFunction(Unload);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Unload);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Equals");
          luafn_Equals= new LuaCSFunction(Equals);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Equals);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetHashCode");
          luafn_GetHashCode= new LuaCSFunction(GetHashCode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetHashCode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetInstanceID");
          luafn_GetInstanceID= new LuaCSFunction(GetInstanceID);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetInstanceID);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_name");
          luafn_get_name= new LuaCSFunction(get_name);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_name);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_name");
          luafn_set_name= new LuaCSFunction(set_name);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_name);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_hideFlags");
          luafn_get_hideFlags= new LuaCSFunction(get_hideFlags);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_hideFlags);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_hideFlags");
          luafn_set_hideFlags= new LuaCSFunction(set_hideFlags);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_hideFlags);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ToString");
          luafn_ToString= new LuaCSFunction(ToString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ToString);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetType");
          luafn_GetType= new LuaCSFunction(GetType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetType);
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
    
          string[] names = typeof(UnityEngine.AssetBundle).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(UnityEngine.AssetBundle).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"CreateFromMemory");
          luafn_CreateFromMemory= new LuaCSFunction(CreateFromMemory);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CreateFromMemory);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"CreateFromFile");
          luafn_CreateFromFile= new LuaCSFunction(CreateFromFile);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_CreateFromFile);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_get_mainAsset;
          private static LuaCSFunction luafn_Contains;
          private static LuaCSFunction luafn_Load;
          private static LuaCSFunction luafn_LoadAsync;
          private static LuaCSFunction luafn_LoadAll;
          private static LuaCSFunction luafn_Unload;
          private static LuaCSFunction luafn_Equals;
          private static LuaCSFunction luafn_GetHashCode;
          private static LuaCSFunction luafn_GetInstanceID;
          private static LuaCSFunction luafn_get_name;
          private static LuaCSFunction luafn_set_name;
          private static LuaCSFunction luafn_get_hideFlags;
          private static LuaCSFunction luafn_set_hideFlags;
          private static LuaCSFunction luafn_ToString;
          private static LuaCSFunction luafn_GetType;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_CreateFromMemory;
          private static LuaCSFunction luafn_CreateFromFile;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_mainAsset(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.Object mainAsset= target.mainAsset;
                  ToLuaCS.push(L,mainAsset); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Contains(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.Boolean contains= target.Contains( name_);
                  ToLuaCS.push(L,contains); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Load(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING  && ToLuaCS.getObject(L, 3) is System.Type)
              {
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 

                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.Object load= target.Load( name_, type_);
                  ToLuaCS.push(L,load); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.Object load= target.Load( name_);
                  ToLuaCS.push(L,load); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadAsync(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,2); 

                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.AssetBundleRequest loadasync= target.LoadAsync( name_, type_);
                  ToLuaCS.push(L,loadasync); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LoadAll(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is System.Type)
              {
                  System.Type type_ = (System.Type)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.Object[] loadall= target.LoadAll( type_);
                  ToLuaCS.push(L,loadall); 
                  return 1;

              }
              if(true)
              {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.Object[] loadall= target.LoadAll();
                  ToLuaCS.push(L,loadall); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Unload(LuaState L)
          {
                  System.Boolean unloadAllLoadedObjects_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  target.Unload( unloadAllLoadedObjects_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object o_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.Boolean equals= target.Equals( o_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetInstanceID(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.Int32 getinstanceid= target.GetInstanceID();
                  ToLuaCS.push(L,getinstanceid); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_name(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.String name= target.name;
                  ToLuaCS.push(L,name); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_name(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  target.name= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_hideFlags(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  UnityEngine.HideFlags hideFlags= target.hideFlags;
                  ToLuaCS.push(L,hideFlags); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_hideFlags(LuaState L)
          {
                  UnityEngine.HideFlags value_ = (UnityEngine.HideFlags)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  target.hideFlags= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.AssetBundle target= (UnityEngine.AssetBundle) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CreateFromMemory(LuaState L)
          {
                  System.Byte[] binary_ = (System.Byte[])ToLuaCS.getObject(L,1);

                  UnityEngine.AssetBundleCreateRequest createfrommemory= UnityEngine.AssetBundle.CreateFromMemory( binary_);
                  ToLuaCS.push(L,createfrommemory); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int CreateFromFile(LuaState L)
          {
                  System.String path_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.AssetBundle createfromfile= UnityEngine.AssetBundle.CreateFromFile( path_);
                  ToLuaCS.push(L,createfromfile); 
                  return 1;

          }
  #endregion       
}

