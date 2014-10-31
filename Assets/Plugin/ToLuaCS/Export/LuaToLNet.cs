using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToLNet {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(LNet).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(LNet).AssemblyQualifiedName);
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
          System.Type superT = typeof(LNet).BaseType;
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
          LuaDLL.lua_pushstring(L,"get_isConnectCall");
          luafn_get_isConnectCall= new LuaCSFunction(get_isConnectCall);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_isConnectCall);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Connect");
          luafn_Connect= new LuaCSFunction(Connect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Connect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ReConnect");
          luafn_ReConnect= new LuaCSFunction(ReConnect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ReConnect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Close");
          luafn_Close= new LuaCSFunction(Close);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Close);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Send");
          luafn_Send= new LuaCSFunction(Send);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Send);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_IsConnected");
          luafn_get_IsConnected= new LuaCSFunction(get_IsConnected);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_IsConnected);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Update");
          luafn_Update= new LuaCSFunction(Update);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Update);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"OnApplicationPause");
          luafn_OnApplicationPause= new LuaCSFunction(OnApplicationPause);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_OnApplicationPause);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Receive");
          luafn_Receive= new LuaCSFunction(Receive);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Receive);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_Host");
          luafn_get_Host= new LuaCSFunction(get_Host);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_Host);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_Port");
          luafn_get_Port= new LuaCSFunction(get_Port);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_Port);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SendErro");
          luafn_SendErro= new LuaCSFunction(SendErro);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SendErro);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Dispose");
          luafn_Dispose= new LuaCSFunction(Dispose);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Dispose);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_pingDelay");
          luafn_get_pingDelay= new LuaCSFunction(get_pingDelay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_pingDelay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_pingDelay");
          luafn_set_pingDelay= new LuaCSFunction(set_pingDelay);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_pingDelay);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_timeoutMiliSecond");
          luafn_get_timeoutMiliSecond= new LuaCSFunction(get_timeoutMiliSecond);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_timeoutMiliSecond);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_timeoutMiliSecond");
          luafn_set_timeoutMiliSecond= new LuaCSFunction(set_timeoutMiliSecond);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_timeoutMiliSecond);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onAppErrorFn");
          luafn_get_onAppErrorFn= new LuaCSFunction(get_onAppErrorFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onAppErrorFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onAppErrorFn");
          luafn_set_onAppErrorFn= new LuaCSFunction(set_onAppErrorFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onAppErrorFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onConnectionCloseFn");
          luafn_get_onConnectionCloseFn= new LuaCSFunction(get_onConnectionCloseFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onConnectionCloseFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onConnectionCloseFn");
          luafn_set_onConnectionCloseFn= new LuaCSFunction(set_onConnectionCloseFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onConnectionCloseFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onConnectionFn");
          luafn_get_onConnectionFn= new LuaCSFunction(get_onConnectionFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onConnectionFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onConnectionFn");
          luafn_set_onConnectionFn= new LuaCSFunction(set_onConnectionFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onConnectionFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onMessageReceiveFn");
          luafn_get_onMessageReceiveFn= new LuaCSFunction(get_onMessageReceiveFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onMessageReceiveFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onMessageReceiveFn");
          luafn_set_onMessageReceiveFn= new LuaCSFunction(set_onMessageReceiveFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onMessageReceiveFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onConnectionTimeoutFn");
          luafn_get_onConnectionTimeoutFn= new LuaCSFunction(get_onConnectionTimeoutFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onConnectionTimeoutFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onConnectionTimeoutFn");
          luafn_set_onConnectionTimeoutFn= new LuaCSFunction(set_onConnectionTimeoutFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onConnectionTimeoutFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onReConnectFn");
          luafn_get_onReConnectFn= new LuaCSFunction(get_onReConnectFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onReConnectFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onReConnectFn");
          luafn_set_onReConnectFn= new LuaCSFunction(set_onReConnectFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onReConnectFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onAppPauseFn");
          luafn_get_onAppPauseFn= new LuaCSFunction(get_onAppPauseFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onAppPauseFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onAppPauseFn");
          luafn_set_onAppPauseFn= new LuaCSFunction(set_onAppPauseFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onAppPauseFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_onIntervalFn");
          luafn_get_onIntervalFn= new LuaCSFunction(get_onIntervalFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_onIntervalFn);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_onIntervalFn");
          luafn_set_onIntervalFn= new LuaCSFunction(set_onIntervalFn);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_onIntervalFn);
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
    
          string[] names = typeof(LNet).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(LNet).FullName);
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
          private static LuaCSFunction luafn_get_isConnectCall;
          private static LuaCSFunction luafn_Connect;
          private static LuaCSFunction luafn_ReConnect;
          private static LuaCSFunction luafn_Close;
          private static LuaCSFunction luafn_Send;
          private static LuaCSFunction luafn_get_IsConnected;
          private static LuaCSFunction luafn_Update;
          private static LuaCSFunction luafn_OnApplicationPause;
          private static LuaCSFunction luafn_Receive;
          private static LuaCSFunction luafn_get_Host;
          private static LuaCSFunction luafn_get_Port;
          private static LuaCSFunction luafn_SendErro;
          private static LuaCSFunction luafn_Dispose;
          private static LuaCSFunction luafn_get_pingDelay;
          private static LuaCSFunction luafn_set_pingDelay;
          private static LuaCSFunction luafn_get_timeoutMiliSecond;
          private static LuaCSFunction luafn_set_timeoutMiliSecond;
          private static LuaCSFunction luafn_get_onAppErrorFn;
          private static LuaCSFunction luafn_set_onAppErrorFn;
          private static LuaCSFunction luafn_get_onConnectionCloseFn;
          private static LuaCSFunction luafn_set_onConnectionCloseFn;
          private static LuaCSFunction luafn_get_onConnectionFn;
          private static LuaCSFunction luafn_set_onConnectionFn;
          private static LuaCSFunction luafn_get_onMessageReceiveFn;
          private static LuaCSFunction luafn_set_onMessageReceiveFn;
          private static LuaCSFunction luafn_get_onConnectionTimeoutFn;
          private static LuaCSFunction luafn_set_onConnectionTimeoutFn;
          private static LuaCSFunction luafn_get_onReConnectFn;
          private static LuaCSFunction luafn_set_onReConnectFn;
          private static LuaCSFunction luafn_get_onAppPauseFn;
          private static LuaCSFunction luafn_set_onAppPauseFn;
          private static LuaCSFunction luafn_get_onIntervalFn;
          private static LuaCSFunction luafn_set_onIntervalFn;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_get_instance;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_isConnectCall(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  System.Boolean isConnectCall= target.isConnectCall;
                  ToLuaCS.push(L,isConnectCall); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Connect(LuaState L)
          {
                  System.String host_ =  LuaDLL.lua_tostring(L,2); 

                  System.Int32 port_ = (System.Int32)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Connect( host_, port_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ReConnect(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.ReConnect();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Close(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Close();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Send(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is Msg)
              {
                  Msg msg_ = (Msg)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Send( msg_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is System.Byte[])
              {
                  System.Byte[] bytes_ = (System.Byte[])ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Send( bytes_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_IsConnected(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  System.Boolean IsConnected= target.IsConnected;
                  ToLuaCS.push(L,IsConnected); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Update(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Update();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OnApplicationPause(LuaState L)
          {
                  System.Boolean pauseStatus_ =  LuaDLL.lua_toboolean(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.OnApplicationPause( pauseStatus_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Receive(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Receive();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Host(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  System.String Host= target.Host;
                  ToLuaCS.push(L,Host); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Port(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  System.Int32 Port= target.Port;
                  ToLuaCS.push(L,Port); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SendErro(LuaState L)
          {
                  System.String type_ =  LuaDLL.lua_tostring(L,2); 

                  System.String desc_ =  LuaDLL.lua_tostring(L,3); 


                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.SendErro( type_, desc_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Dispose(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  target.Dispose();
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_pingDelay(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.pingDelay;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_pingDelay(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.pingDelay= (System.Single)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_timeoutMiliSecond(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.timeoutMiliSecond;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_timeoutMiliSecond(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.timeoutMiliSecond= (System.Int32)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onAppErrorFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onAppErrorFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onAppErrorFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onAppErrorFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onConnectionCloseFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onConnectionCloseFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onConnectionCloseFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onConnectionCloseFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onConnectionFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onConnectionFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onConnectionFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onConnectionFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onMessageReceiveFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onMessageReceiveFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onMessageReceiveFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onMessageReceiveFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onConnectionTimeoutFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onConnectionTimeoutFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onConnectionTimeoutFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onConnectionTimeoutFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onReConnectFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onReConnectFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onReConnectFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onReConnectFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onAppPauseFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onAppPauseFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onAppPauseFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onAppPauseFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_onIntervalFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original ;
                  var val=  target.onIntervalFn;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_onIntervalFn(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  LNet target= (LNet) original;
                  var val= ToLuaCS.getObject(L, 2);
                  target.onIntervalFn= (LuaInterface.LuaFunction)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_instance(LuaState L)
          {

                  LNet instance= LNet.instance;
                  ToLuaCS.push(L,instance); 
                  return 1;

          }
  #endregion       
}

