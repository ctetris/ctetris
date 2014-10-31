using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToNGUIEvent {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(NGUIEvent).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(NGUIEvent).AssemblyQualifiedName);
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
          System.Type superT = typeof(NGUIEvent).BaseType;
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
          LuaDLL.lua_pushstring(L,"OnCustomer");
          luafn_OnCustomer= new LuaCSFunction(OnCustomer);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_OnCustomer);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"onCustomerHandle");
          luafn_onCustomerHandle= new LuaCSFunction(onCustomerHandle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_onCustomerHandle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"onPressHandle");
          luafn_onPressHandle= new LuaCSFunction(onPressHandle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_onPressHandle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"onClickHandle");
          luafn_onClickHandle= new LuaCSFunction(onClickHandle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_onClickHandle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"onDragHandle");
          luafn_onDragHandle= new LuaCSFunction(onDragHandle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_onDragHandle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"onDropHandle");
          luafn_onDropHandle= new LuaCSFunction(onDropHandle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_onDropHandle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"onSelectHandle");
          luafn_onSelectHandle= new LuaCSFunction(onSelectHandle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_onSelectHandle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"onDoubleClickHandle");
          luafn_onDoubleClickHandle= new LuaCSFunction(onDoubleClickHandle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_onDoubleClickHandle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onCustomerFn");
          luafn_get_onCustomerFn= new LuaCSFunction(get_onCustomerFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onCustomerFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onCustomerFn");
          luafn_set_onCustomerFn= new LuaCSFunction(set_onCustomerFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onCustomerFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onPressFn");
          luafn_get_onPressFn= new LuaCSFunction(get_onPressFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onPressFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onPressFn");
          luafn_set_onPressFn= new LuaCSFunction(set_onPressFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onPressFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onClickFn");
          luafn_get_onClickFn= new LuaCSFunction(get_onClickFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onClickFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onClickFn");
          luafn_set_onClickFn= new LuaCSFunction(set_onClickFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onClickFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onDragFn");
          luafn_get_onDragFn= new LuaCSFunction(get_onDragFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onDragFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onDragFn");
          luafn_set_onDragFn= new LuaCSFunction(set_onDragFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onDragFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onDropFn");
          luafn_get_onDropFn= new LuaCSFunction(get_onDropFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onDropFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onDropFn");
          luafn_set_onDropFn= new LuaCSFunction(set_onDropFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onDropFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onSelectFn");
          luafn_get_onSelectFn= new LuaCSFunction(get_onSelectFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onSelectFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onSelectFn");
          luafn_set_onSelectFn= new LuaCSFunction(set_onSelectFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onSelectFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onDoubleFn");
          luafn_get_onDoubleFn= new LuaCSFunction(get_onDoubleFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onDoubleFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onDoubleFn");
          luafn_set_onDoubleFn= new LuaCSFunction(set_onDoubleFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onDoubleFn);
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
    
          string[] names = typeof(NGUIEvent).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(NGUIEvent).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"get_instance");
          luafn_get_instance= new LuaCSFunction(get_instance);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_instance);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_OnCustomer;
          private static LuaCSFunction luafn_onCustomerHandle;
          private static LuaCSFunction luafn_onPressHandle;
          private static LuaCSFunction luafn_onClickHandle;
          private static LuaCSFunction luafn_onDragHandle;
          private static LuaCSFunction luafn_onDropHandle;
          private static LuaCSFunction luafn_onSelectHandle;
          private static LuaCSFunction luafn_onDoubleClickHandle;
          private static LuaCSFunction luafn_get_onCustomerFn;
          private static LuaCSFunction luafn_set_onCustomerFn;
          private static LuaCSFunction luafn_get_onPressFn;
          private static LuaCSFunction luafn_set_onPressFn;
          private static LuaCSFunction luafn_get_onClickFn;
          private static LuaCSFunction luafn_set_onClickFn;
          private static LuaCSFunction luafn_get_onDragFn;
          private static LuaCSFunction luafn_set_onDragFn;
          private static LuaCSFunction luafn_get_onDropFn;
          private static LuaCSFunction luafn_set_onDropFn;
          private static LuaCSFunction luafn_get_onSelectFn;
          private static LuaCSFunction luafn_set_onSelectFn;
          private static LuaCSFunction luafn_get_onDoubleFn;
          private static LuaCSFunction luafn_set_onDoubleFn;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_get_instance;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnCustomer(LuaState L)
          {
                  System.Object obj_ = (System.Object)ToLuaCS.getObject(L,2);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  target.OnCustomer( obj_, arg_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onCustomerHandle(LuaState L)
          {
                  System.Object sender_ = (System.Object)ToLuaCS.getObject(L,2);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  target.onCustomerHandle( sender_, arg_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onPressHandle(LuaState L)
          {
                  UnityEngine.GameObject sender_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,2);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  target.onPressHandle( sender_, arg_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onClickHandle(LuaState L)
          {
                  UnityEngine.GameObject sender_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,2);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  target.onClickHandle( sender_, arg_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onDragHandle(LuaState L)
          {
                  UnityEngine.GameObject sender_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,2);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  target.onDragHandle( sender_, arg_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onDropHandle(LuaState L)
          {
                  UnityEngine.GameObject sender_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,2);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  target.onDropHandle( sender_, arg_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onSelectHandle(LuaState L)
          {
                  UnityEngine.GameObject sender_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,2);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  target.onSelectHandle( sender_, arg_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int onDoubleClickHandle(LuaState L)
          {
                  UnityEngine.GameObject sender_ = (UnityEngine.GameObject)ToLuaCS.getObject(L,2);
                  System.Object arg_ = (System.Object)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  target.onDoubleClickHandle( sender_, arg_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onCustomerFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  var val=  target.onCustomerFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onCustomerFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onCustomerFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onPressFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  var val=  target.onPressFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onPressFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onPressFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onClickFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  var val=  target.onClickFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onClickFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onClickFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onDragFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  var val=  target.onDragFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onDragFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onDragFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onDropFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  var val=  target.onDropFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onDropFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onDropFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onSelectFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  var val=  target.onSelectFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onSelectFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onSelectFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onDoubleFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original ;
                  var val=  target.onDoubleFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onDoubleFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  NGUIEvent target= (NGUIEvent) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onDoubleFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_instance(LuaState L)
          {

                  NGUIEvent instance= NGUIEvent.instance;
                  ToLuaCS.push(L,instance); 
                  return 1;

          }
  #endregion       
}

