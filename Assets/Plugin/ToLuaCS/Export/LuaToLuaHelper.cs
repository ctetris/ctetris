using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLuaHelper {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(LuaHelper).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(LuaHelper).AssemblyQualifiedName);
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
          System.Type superT = typeof(LuaHelper).BaseType;
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
    
          string[] names = typeof(LuaHelper).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(LuaHelper).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"Destroy");
          luafn_Destroy= new LuaCSFunction(Destroy);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Destroy);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Instantiate");
          luafn_Instantiate= new LuaCSFunction(Instantiate);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Instantiate);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"InstantiateLocal");
          luafn_InstantiateLocal= new LuaCSFunction(InstantiateLocal);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_InstantiateLocal);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"InstantiateGlobal");
          luafn_InstantiateGlobal= new LuaCSFunction(InstantiateGlobal);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_InstantiateGlobal);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SetParent");
          luafn_SetParent= new LuaCSFunction(SetParent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SetParent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetType");
          luafn_GetType= new LuaCSFunction(GetType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Find");
          luafn_Find= new LuaCSFunction(Find);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Find);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentInChildren");
          luafn_GetComponentInChildren= new LuaCSFunction(GetComponentInChildren);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentInChildren);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponent");
          luafn_GetComponent= new LuaCSFunction(GetComponent);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponent);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponents");
          luafn_GetComponents= new LuaCSFunction(GetComponents);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponents);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetComponentsInChildren");
          luafn_GetComponentsInChildren= new LuaCSFunction(GetComponentsInChildren);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetComponentsInChildren);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetAllChild");
          luafn_GetAllChild= new LuaCSFunction(GetAllChild);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetAllChild);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ForeachChild");
          luafn_ForeachChild= new LuaCSFunction(ForeachChild);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ForeachChild);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Raycast");
          luafn_Raycast= new LuaCSFunction(Raycast);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Raycast);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RefreshShader");
          luafn_RefreshShader= new LuaCSFunction(RefreshShader);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RefreshShader);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_Destroy;
          private static LuaCSFunction luafn_Instantiate;
          private static LuaCSFunction luafn_InstantiateLocal;
          private static LuaCSFunction luafn_InstantiateGlobal;
          private static LuaCSFunction luafn_SetParent;
          private static LuaCSFunction luafn_GetType;
          private static LuaCSFunction luafn_Find;
          private static LuaCSFunction luafn_GetComponentInChildren;
          private static LuaCSFunction luafn_GetComponent;
          private static LuaCSFunction luafn_GetComponents;
          private static LuaCSFunction luafn_GetComponentsInChildren;
          private static LuaCSFunction luafn_GetAllChild;
          private static LuaCSFunction luafn_ForeachChild;
          private static LuaCSFunction luafn_Raycast;
          private static LuaCSFunction luafn_RefreshShader;
 #endregion        
  #region  instances method       
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Destroy(LuaState L)
          {
                  UnityEngine.Object original_ = (UnityEngine.Object)ToLuaCS.getObject(L,1);

                  LuaHelper.Destroy( original_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Instantiate(LuaState L)
          {
                  UnityEngine.Object original_ = (UnityEngine.Object)ToLuaCS.getObject(L,1);

                  UnityEngine.Object instantiate= LuaHelper.Instantiate( original_);
                  ToLuaCS.push(L,instantiate); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InstantiateLocal(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.GameObject && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3)
              {
                  UnityEngine.GameObject original_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 pos_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);

                  UnityEngine.GameObject instantiatelocal= LuaHelper.InstantiateLocal( original_, parent_, pos_);
                  ToLuaCS.push(L,instantiatelocal); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3)
              {
                  UnityEngine.GameObject original_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 pos_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.GameObject instantiatelocal= LuaHelper.InstantiateLocal( original_, pos_);
                  ToLuaCS.push(L,instantiatelocal); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is UnityEngine.GameObject)
              {
                  UnityEngine.GameObject original_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,2);

                  UnityEngine.GameObject instantiatelocal= LuaHelper.InstantiateLocal( original_, parent_);
                  ToLuaCS.push(L,instantiatelocal); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject)
              {
                  UnityEngine.GameObject original_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);

                  UnityEngine.GameObject instantiatelocal= LuaHelper.InstantiateLocal( original_);
                  ToLuaCS.push(L,instantiatelocal); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int InstantiateGlobal(LuaState L)
          {
                  UnityEngine.GameObject original_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,2);

                  UnityEngine.GameObject instantiateglobal= LuaHelper.InstantiateGlobal( original_, parent_);
                  ToLuaCS.push(L,instantiateglobal); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetParent(LuaState L)
          {
                  UnityEngine.GameObject child_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,2);

                  LuaHelper.SetParent( child_, parent_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is System.Object)
              {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L,1);

                  System.Type gettype= LuaHelper.GetType( obj_);
                  ToLuaCS.push(L,gettype); 
                  return 1;

              }
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TSTRING )
              {
                  System.String classname_ =  LuaDLL.lua_tostring(L,1); 


                  System.Type gettype= LuaHelper.GetType( classname_);
                  ToLuaCS.push(L,gettype); 
                  return 1;

              }
              if(true)
              {

                  object original = ToLuaCS.getObject(L, 1);
                  LuaHelper target= (LuaHelper) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Find(LuaState L)
          {
                  System.String name_ =  LuaDLL.lua_tostring(L,1); 


                  UnityEngine.GameObject find= LuaHelper.Find( name_);
                  ToLuaCS.push(L,find); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentInChildren(LuaState L)
          {
                  UnityEngine.GameObject obj_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.String classname_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.Component getcomponentinchildren= LuaHelper.GetComponentInChildren( obj_, classname_);
                  ToLuaCS.push(L,getcomponentinchildren); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponent(LuaState L)
          {
                  UnityEngine.GameObject obj_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.String classname_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.Component getcomponent= LuaHelper.GetComponent( obj_, classname_);
                  ToLuaCS.push(L,getcomponent); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponents(LuaState L)
          {
                  UnityEngine.GameObject obj_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.String classname_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.Component[] getcomponents= LuaHelper.GetComponents( obj_, classname_);
                  ToLuaCS.push(L,getcomponents); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetComponentsInChildren(LuaState L)
          {
                  UnityEngine.GameObject obj_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  System.String classname_ =  LuaDLL.lua_tostring(L,2); 


                  UnityEngine.Component[] getcomponentsinchildren= LuaHelper.GetComponentsInChildren( obj_, classname_);
                  ToLuaCS.push(L,getcomponentsinchildren); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetAllChild(LuaState L)
          {
                  UnityEngine.GameObject obj_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);

                  UnityEngine.Transform[] getallchild= LuaHelper.GetAllChild( obj_);
                  ToLuaCS.push(L,getallchild); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ForeachChild(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is ReferGameObjects && ToLuaCS.getObject(L, 2) is LuaInterface.LuaFunction)
              {
                  ReferGameObjects parent_ = (ReferGameObjects)ToLuaCS.getObject(L,1);
                  LuaInterface.LuaFunction eachFn_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L,2);

                  LuaHelper.ForeachChild( parent_, eachFn_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.GameObject && ToLuaCS.getObject(L, 2) is LuaInterface.LuaFunction)
              {
                  UnityEngine.GameObject parent_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,1);
                  LuaInterface.LuaFunction eachFn_ = (LuaInterface.LuaFunction)ToLuaCS.getObject(L,2);

                  LuaHelper.ForeachChild( parent_, eachFn_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Raycast(LuaState L)
          {
                  UnityEngine.Ray ray_ = (UnityEngine.Ray)ToLuaCS.getObject(L,1);

                  System.Object raycast= LuaHelper.Raycast( ray_);
                  ToLuaCS.push(L,raycast); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RefreshShader(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.WWW)
              {
                  UnityEngine.WWW www_ = (UnityEngine.WWW)ToLuaCS.getObject(L,1);

                  LuaHelper.RefreshShader( www_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.AssetBundle)
              {
                  UnityEngine.AssetBundle assetBundle_ = (UnityEngine.AssetBundle)ToLuaCS.getObject(L,1);

                  LuaHelper.RefreshShader( assetBundle_);
                 return 0;

              }
          return 0;
          }
  #endregion       
}

