using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Quaternion {

  public static void CreateMetaTableToLua(LuaState L) {

       LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.Quaternion).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.Quaternion).AssemblyQualifiedName);
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
          System.Type superT = typeof(UnityEngine.Quaternion).BaseType;
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
          LuaDLL.lua_pushstring(L,"get_Item");
          luafn_get_Item= new LuaCSFunction(get_Item);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_Item);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_Item");
          luafn_set_Item= new LuaCSFunction(set_Item);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_Item);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Set");
          luafn_Set= new LuaCSFunction(Set);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Set);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ToAngleAxis");
          luafn_ToAngleAxis= new LuaCSFunction(ToAngleAxis);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ToAngleAxis);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SetFromToRotation");
          luafn_SetFromToRotation= new LuaCSFunction(SetFromToRotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SetFromToRotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SetLookRotation");
          luafn_SetLookRotation= new LuaCSFunction(SetLookRotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SetLookRotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ToString");
          luafn_ToString= new LuaCSFunction(ToString);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ToString);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_eulerAngles");
          luafn_get_eulerAngles= new LuaCSFunction(get_eulerAngles);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_eulerAngles);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_eulerAngles");
          luafn_set_eulerAngles= new LuaCSFunction(set_eulerAngles);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_eulerAngles);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetHashCode");
          luafn_GetHashCode= new LuaCSFunction(GetHashCode);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetHashCode);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Equals");
          luafn_Equals= new LuaCSFunction(Equals);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Equals);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"GetType");
          luafn_GetType= new LuaCSFunction(GetType);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_GetType);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_x");
          luafn_get_x= new LuaCSFunction(get_x);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_x);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_x");
          luafn_set_x= new LuaCSFunction(set_x);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_x);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_y");
          luafn_get_y= new LuaCSFunction(get_y);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_y);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_y");
          luafn_set_y= new LuaCSFunction(set_y);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_y);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_z");
          luafn_get_z= new LuaCSFunction(get_z);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_z);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_z");
          luafn_set_z= new LuaCSFunction(set_z);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_z);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_w");
          luafn_get_w= new LuaCSFunction(get_w);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_w);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_w");
          luafn_set_w= new LuaCSFunction(set_w);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_w);
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
    
          string[] names = typeof(UnityEngine.Quaternion).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(UnityEngine.Quaternion).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"get_identity");
          luafn_get_identity= new LuaCSFunction(get_identity);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_identity);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Dot");
          luafn_Dot= new LuaCSFunction(Dot);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Dot);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"AngleAxis");
          luafn_AngleAxis= new LuaCSFunction(AngleAxis);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_AngleAxis);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"FromToRotation");
          luafn_FromToRotation= new LuaCSFunction(FromToRotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_FromToRotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"LookRotation");
          luafn_LookRotation= new LuaCSFunction(LookRotation);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_LookRotation);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Slerp");
          luafn_Slerp= new LuaCSFunction(Slerp);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Slerp);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Lerp");
          luafn_Lerp= new LuaCSFunction(Lerp);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Lerp);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RotateTowards");
          luafn_RotateTowards= new LuaCSFunction(RotateTowards);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RotateTowards);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Inverse");
          luafn_Inverse= new LuaCSFunction(Inverse);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Inverse);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Angle");
          luafn_Angle= new LuaCSFunction(Angle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Angle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Euler");
          luafn_Euler= new LuaCSFunction(Euler);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Euler);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_kEpsilon");
          luafn_get_kEpsilon= new LuaCSFunction(get_kEpsilon);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_kEpsilon);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"set_kEpsilon");
          luafn_set_kEpsilon= new LuaCSFunction(set_kEpsilon);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_set_kEpsilon);
          LuaDLL.lua_rawset(L, -3);

#endregion       
         }
}
  #region instances declaration       
          private static LuaCSFunction luafn_get_Item;
          private static LuaCSFunction luafn_set_Item;
          private static LuaCSFunction luafn_Set;
          private static LuaCSFunction luafn_ToAngleAxis;
          private static LuaCSFunction luafn_SetFromToRotation;
          private static LuaCSFunction luafn_SetLookRotation;
          private static LuaCSFunction luafn_ToString;
          private static LuaCSFunction luafn_get_eulerAngles;
          private static LuaCSFunction luafn_set_eulerAngles;
          private static LuaCSFunction luafn_GetHashCode;
          private static LuaCSFunction luafn_Equals;
          private static LuaCSFunction luafn_GetType;
          private static LuaCSFunction luafn_get_x;
          private static LuaCSFunction luafn_set_x;
          private static LuaCSFunction luafn_get_y;
          private static LuaCSFunction luafn_set_y;
          private static LuaCSFunction luafn_get_z;
          private static LuaCSFunction luafn_set_z;
          private static LuaCSFunction luafn_get_w;
          private static LuaCSFunction luafn_set_w;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_get_identity;
          private static LuaCSFunction luafn_Dot;
          private static LuaCSFunction luafn_AngleAxis;
          private static LuaCSFunction luafn_FromToRotation;
          private static LuaCSFunction luafn_LookRotation;
          private static LuaCSFunction luafn_Slerp;
          private static LuaCSFunction luafn_Lerp;
          private static LuaCSFunction luafn_RotateTowards;
          private static LuaCSFunction luafn_Inverse;
          private static LuaCSFunction luafn_Angle;
          private static LuaCSFunction luafn_Euler;
          private static LuaCSFunction luafn_get_kEpsilon;
          private static LuaCSFunction luafn_set_kEpsilon;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Item(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  System.Single Item= target[ index_];
                  ToLuaCS.push(L,Item); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_Item(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);
                  System.Single value_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target[  index_]= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Set(LuaState L)
          {
                  System.Single new_x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single new_y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single new_z_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single new_w_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target.Set( new_x_, new_y_, new_z_, new_w_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToAngleAxis(LuaState L)
          {
                  System.Single angle_ = (System.Single)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  //target.ToAngleAxis( ref angle_, ref axis_);

                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetFromToRotation(LuaState L)
          {
                  UnityEngine.Vector3 fromDirection_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 toDirection_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target.SetFromToRotation( fromDirection_, toDirection_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SetLookRotation(LuaState L)
          {
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 view_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 up_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target.SetLookRotation( view_, up_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 2) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 view_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target.SetLookRotation( view_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String format_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  System.String tostring= target.ToString( format_);
                  ToLuaCS.push(L,tostring); 
                  return 1;

              }
              if(true)
              {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_eulerAngles(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  UnityEngine.Vector3 eulerAngles= target.eulerAngles;
                  ToLuaCS.push(L,eulerAngles); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_eulerAngles(LuaState L)
          {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  target.eulerAngles= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object other_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  System.Boolean equals= target.Equals( other_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_x(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  var val=  target.x;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_x(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original;
                  target.x= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_y(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  var val=  target.y;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_y(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original;
                  target.y= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_z(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  var val=  target.z;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_z(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original;
                  target.z= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_w(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original ;
                  var val=  target.w;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_w(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Quaternion target= (UnityEngine.Quaternion) original;
                  target.w= (System.Single)LuaDLL.lua_tonumber(L,2);
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_identity(LuaState L)
          {

                  UnityEngine.Quaternion identity= UnityEngine.Quaternion.identity;
                  ToLuaCS.push(L,identity); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Dot(LuaState L)
          {
                  UnityEngine.Quaternion a_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,1);
                  UnityEngine.Quaternion b_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,2);

                  System.Single dot= UnityEngine.Quaternion.Dot( a_, b_);
                  ToLuaCS.push(L,dot); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int AngleAxis(LuaState L)
          {
                  System.Single angle_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  UnityEngine.Vector3 axis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.Quaternion angleaxis= UnityEngine.Quaternion.AngleAxis( angle_, axis_);
                  ToLuaCS.push(L,angleaxis); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int FromToRotation(LuaState L)
          {
                  UnityEngine.Vector3 fromDirection_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 toDirection_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.Quaternion fromtorotation= UnityEngine.Quaternion.FromToRotation( fromDirection_, toDirection_);
                  ToLuaCS.push(L,fromtorotation); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int LookRotation(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 forward_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 upwards_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.Quaternion lookrotation= UnityEngine.Quaternion.LookRotation( forward_, upwards_);
                  ToLuaCS.push(L,lookrotation); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 forward_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);

                  UnityEngine.Quaternion lookrotation= UnityEngine.Quaternion.LookRotation( forward_);
                  ToLuaCS.push(L,lookrotation); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Slerp(LuaState L)
          {
                  UnityEngine.Quaternion from_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,1);
                  UnityEngine.Quaternion to_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,2);
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Quaternion slerp= UnityEngine.Quaternion.Slerp( from_, to_, t_);
                  ToLuaCS.push(L,slerp); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Lerp(LuaState L)
          {
                  UnityEngine.Quaternion from_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,1);
                  UnityEngine.Quaternion to_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,2);
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Quaternion lerp= UnityEngine.Quaternion.Lerp( from_, to_, t_);
                  ToLuaCS.push(L,lerp); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateTowards(LuaState L)
          {
                  UnityEngine.Quaternion from_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,1);
                  UnityEngine.Quaternion to_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,2);
                  System.Single maxDegreesDelta_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Quaternion rotatetowards= UnityEngine.Quaternion.RotateTowards( from_, to_, maxDegreesDelta_);
                  ToLuaCS.push(L,rotatetowards); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Inverse(LuaState L)
          {
                  UnityEngine.Quaternion rotation_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,1);

                  UnityEngine.Quaternion inverse= UnityEngine.Quaternion.Inverse( rotation_);
                  ToLuaCS.push(L,inverse); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Angle(LuaState L)
          {
                  UnityEngine.Quaternion a_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,1);
                  UnityEngine.Quaternion b_ = (UnityEngine.Quaternion)ToLuaCS.getObject(L,2);

                  System.Single angle= UnityEngine.Quaternion.Angle( a_, b_);
                  ToLuaCS.push(L,angle); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Euler(LuaState L)
          {
              if( LuaDLL.lua_type(L,1)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,2)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,3)==LuaTypes.LUA_TNUMBER )
              {
                  System.Single x_ = (System.Single)LuaDLL.lua_tonumber(L,1);
                  System.Single y_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single z_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Quaternion euler= UnityEngine.Quaternion.Euler( x_, y_, z_);
                  ToLuaCS.push(L,euler); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 euler_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);

                  UnityEngine.Quaternion euler= UnityEngine.Quaternion.Euler( euler_);
                  ToLuaCS.push(L,euler); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_kEpsilon(LuaState L)
          {
                  var val=   UnityEngine.Quaternion.kEpsilon;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_kEpsilon(LuaState L)
          {
                  //UnityEngine.Quaternion.kEpsilon= (System.Single)LuaDLL.lua_tonumber(L,1);
                  return 0;

          }
  #endregion       
}

