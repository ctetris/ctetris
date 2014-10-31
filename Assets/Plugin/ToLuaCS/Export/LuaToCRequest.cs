using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToCRequest {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(CRequest).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(CRequest).AssemblyQualifiedName);
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
          System.Type superT = typeof(CRequest).BaseType;
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

          LuaDLL.lua_pushstring(L,"get_suffix");
          luafn_get_suffix= new LuaCSFunction(get_suffix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_suffix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_suffix");
          luafn_set_suffix= new LuaCSFunction(set_suffix);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_suffix);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_head");
          luafn_get_head= new LuaCSFunction(get_head);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_head);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_head");
          luafn_set_head= new LuaCSFunction(set_head);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_head);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_data");
          luafn_get_data= new LuaCSFunction(get_data);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_data);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_data");
          luafn_set_data= new LuaCSFunction(set_data);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_data);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"DispatchComplete");
          luafn_DispatchComplete= new LuaCSFunction(DispatchComplete);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_DispatchComplete);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"DispatchEnd");
          luafn_DispatchEnd= new LuaCSFunction(DispatchEnd);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_DispatchEnd);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_isShared");
          luafn_get_isShared= new LuaCSFunction(get_isShared);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_isShared);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_isShared");
          luafn_set_isShared= new LuaCSFunction(set_isShared);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_isShared);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_url");
          luafn_get_url= new LuaCSFunction(get_url);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_url);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_url");
          luafn_set_url= new LuaCSFunction(set_url);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_url);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_key");
          luafn_get_key= new LuaCSFunction(get_key);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_key);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_key");
          luafn_set_key= new LuaCSFunction(set_key);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_key);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_udKey");
          luafn_get_udKey= new LuaCSFunction(get_udKey);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_udKey);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_udKey");
          luafn_set_udKey= new LuaCSFunction(set_udKey);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_udKey);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_relative");
          luafn_get_relative= new LuaCSFunction(get_relative);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_relative);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_relative");
          luafn_set_relative= new LuaCSFunction(set_relative);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_relative);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_domain");
          luafn_get_domain= new LuaCSFunction(get_domain);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_domain);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_cache");
          luafn_get_cache= new LuaCSFunction(get_cache);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_cache);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_cache");
          luafn_set_cache= new LuaCSFunction(set_cache);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_cache);
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

          LuaDLL.lua_pushstring(L,"get_userData");
          luafn_get_userData= new LuaCSFunction(get_userData);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_userData);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_userData");
          luafn_set_userData= new LuaCSFunction(set_userData);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_userData);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_priority");
          luafn_get_priority= new LuaCSFunction(get_priority);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_priority);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_priority");
          luafn_set_priority= new LuaCSFunction(set_priority);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_priority);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_times");
          luafn_get_times= new LuaCSFunction(get_times);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_times);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_times");
          luafn_set_times= new LuaCSFunction(set_times);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_times);
          LuaDLL.lua_rawset(L, -3);

      #endregion

         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_Dispose;
          private static LuaCSFunction luafn_get_suffix;
          private static LuaCSFunction luafn_set_suffix;
          private static LuaCSFunction luafn_get_head;
          private static LuaCSFunction luafn_set_head;
          private static LuaCSFunction luafn_get_data;
          private static LuaCSFunction luafn_set_data;
          private static LuaCSFunction luafn_DispatchComplete;
          private static LuaCSFunction luafn_DispatchEnd;
          private static LuaCSFunction luafn_get_isShared;
          private static LuaCSFunction luafn_set_isShared;
          private static LuaCSFunction luafn_get_url;
          private static LuaCSFunction luafn_set_url;
          private static LuaCSFunction luafn_get_key;
          private static LuaCSFunction luafn_set_key;
          private static LuaCSFunction luafn_get_udKey;
          private static LuaCSFunction luafn_set_udKey;
          private static LuaCSFunction luafn_get_relative;
          private static LuaCSFunction luafn_set_relative;
          private static LuaCSFunction luafn_get_domain;
          private static LuaCSFunction luafn_get_cache;
          private static LuaCSFunction luafn_set_cache;
          private static LuaCSFunction luafn_Equals;
          private static LuaCSFunction luafn_GetHashCode;
          private static LuaCSFunction luafn_GetType;
          private static LuaCSFunction luafn_ToString;
          private static LuaCSFunction luafn_get_userData;
          private static LuaCSFunction luafn_set_userData;
          private static LuaCSFunction luafn_get_priority;
          private static LuaCSFunction luafn_set_priority;
          private static LuaCSFunction luafn_get_times;
          private static LuaCSFunction luafn_set_times;
 #endregion        
  #region statics declaration       
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Dispose(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.Dispose();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_suffix(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String suffix= target.suffix;
                  ToLuaCS.push(L,suffix); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_suffix(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.suffix= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_head(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.Object head= target.head;
                  ToLuaCS.push(L,head); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_head(LuaState L)
          {
                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.head= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_data(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.Object data= target.data;
                  ToLuaCS.push(L,data); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_data(LuaState L)
          {
                  System.Object value_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.data= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DispatchComplete(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.DispatchComplete();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int DispatchEnd(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.DispatchEnd();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isShared(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.Boolean isShared= target.isShared;
                  ToLuaCS.push(L,isShared); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_isShared(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.isShared= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_url(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String url= target.url;
                  ToLuaCS.push(L,url); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_url(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.url= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_key(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String key= target.key;
                  ToLuaCS.push(L,key); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_key(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.key= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_udKey(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String udKey= target.udKey;
                  ToLuaCS.push(L,udKey); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_udKey(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.udKey= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_relative(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String relative= target.relative;
                  ToLuaCS.push(L,relative); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_relative(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.relative= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_domain(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String domain= target.domain;
                  ToLuaCS.push(L,domain); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_cache(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.Boolean cache= target.cache;
                  ToLuaCS.push(L,cache); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_cache(LuaState L)
          {
                  System.Boolean value_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  target.cache= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.Boolean equals= target.Equals( obj_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_userData(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  var val=  target.userData;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_userData(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.userData= (System.Object)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_priority(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  var val=  target.priority;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_priority(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original;
                  target.priority= (System.Int32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_times(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original ;
                  var val=  target.times;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_times(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  CRequest target= (CRequest) original;
                  target.times= (System.Int32)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
  #endregion       
}

