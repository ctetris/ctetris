using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLocalization {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(Localization).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(Localization).AssemblyQualifiedName);
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
          System.Type superT = typeof(Localization).BaseType;
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
    
          string[] names = typeof(Localization).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(Localization).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"get_dictionary");
          luafn_get_dictionary= new LuaCSFunction(get_dictionary);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_dictionary);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_dictionary");
          luafn_set_dictionary= new LuaCSFunction(set_dictionary);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_dictionary);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_knownLanguages");
          luafn_get_knownLanguages= new LuaCSFunction(get_knownLanguages);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_knownLanguages);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_language");
          luafn_get_language= new LuaCSFunction(get_language);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_language);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_language");
          luafn_set_language= new LuaCSFunction(set_language);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_language);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Load");
          luafn_Load= new LuaCSFunction(Load);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Load);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Get");
          luafn_Get= new LuaCSFunction(Get);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Get);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Exists");
          luafn_Exists= new LuaCSFunction(Exists);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Exists);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_localizationHasBeenSet");
          luafn_get_localizationHasBeenSet= new LuaCSFunction(get_localizationHasBeenSet);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_localizationHasBeenSet);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_localizationHasBeenSet");
          luafn_set_localizationHasBeenSet= new LuaCSFunction(set_localizationHasBeenSet);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_localizationHasBeenSet);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_get_dictionary;
          private static LuaCSFunction luafn_set_dictionary;
          private static LuaCSFunction luafn_get_knownLanguages;
          private static LuaCSFunction luafn_get_language;
          private static LuaCSFunction luafn_set_language;
          private static LuaCSFunction luafn_Load;
          private static LuaCSFunction luafn_Get;
          private static LuaCSFunction luafn_Exists;
          private static LuaCSFunction luafn_get_localizationHasBeenSet;
          private static LuaCSFunction luafn_set_localizationHasBeenSet;
 #endregion        
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_dictionary(LuaState L)
          {

                  System.Collections.Generic.Dictionary<System.String,System.String> dictionary= Localization.dictionary;
                  ToLuaCS.push(L,dictionary); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_dictionary(LuaState L)
          {
              System.Collections.Generic.Dictionary<System.String, System.String> value_ = (System.Collections.Generic.Dictionary<System.String, System.String>)ToLuaCS.getObject(L, 1);

                  Localization.dictionary= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_knownLanguages(LuaState L)
          {

                  System.String[] knownLanguages= Localization.knownLanguages;
                  ToLuaCS.push(L,knownLanguages); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_language(LuaState L)
          {

                  System.String language= Localization.language;
                  ToLuaCS.push(L,language); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_language(LuaState L)
          {
                  System.String value_ =  LuaDLL.lua_tostring(L,1); 


                  Localization.language= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Load(LuaState L)
          {
                  System.Byte[] asset_ = (System.Byte[])ToLuaCS.getObject(L,1);

                  Localization.Load( asset_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Get(LuaState L)
          {
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 


                  System.String get= Localization.Get( key_);
                  ToLuaCS.push(L,get); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Exists(LuaState L)
          {
                  System.String key_ =  LuaDLL.lua_tostring(L,1); 


                  System.Boolean exists= Localization.Exists( key_);
                  ToLuaCS.push(L,exists); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_localizationHasBeenSet(LuaState L)
          {
                  var val=   Localization.localizationHasBeenSet;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_localizationHasBeenSet(LuaState L)
          {
                  Localization.localizationHasBeenSet= LuaDLL.lua_toboolean(L,1);
                  return 0;

          }
  #endregion       
}

