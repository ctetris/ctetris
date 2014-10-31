using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToToLuaCSTest {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(ToLuaCSTest).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(ToLuaCSTest).AssemblyQualifiedName);
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
          System.Type superT = typeof(ToLuaCSTest).BaseType;
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
          LuaDLL.lua_pushstring(L,"Ins_Add");
          luafn_Ins_Add= new LuaCSFunction(Ins_Add);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Ins_Add);
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
    
          string[] names = typeof(ToLuaCSTest).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(ToLuaCSTest).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"Add");
          luafn_Add= new LuaCSFunction(Add);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Add);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_Ins_Add;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_Add;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Ins_Add(LuaState L)
          {
                  System.Single a_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single b_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  ToLuaCSTest target= (ToLuaCSTest) original ;
                  System.Single ins_add= target.Ins_Add( a_, b_);
                  ToLuaCS.push(L,ins_add); 
                  return 1;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Add(LuaState L)
          {
                  System.Single a_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single b_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  System.Single add= ToLuaCSTest.Add( a_, b_);
                  ToLuaCS.push(L,add); 
                  return 1;

          }
  #endregion       
}

