using System.Collections;
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
using MonoPInvokeCallbackAttribute = LuaInterface.MonoPInvokeCallbackAttribute;
using LuaCSFunction = LuaInterface.LuaCSFunction;

public static class LuaToUnityEngine_Vector3 {

  public static void CreateMetaTableToLua(LuaState L) {

      LuaDLL.luaL_getmetatable(L, typeof(UnityEngine.Vector3).AssemblyQualifiedName);
      if (LuaDLL.lua_isnil(L, -1))
      {
          //LuaDLL.lua_settop(L, -2);
          //LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.Vector3).AssemblyQualifiedName);
          //LuaDLL.lua_pushlightuserdata(L, LuaDLL.luanet_gettag());
          //LuaDLL.lua_pushnumber(L, 1);
          //LuaDLL.lua_rawset(L, -3);
          //LuaDLL.lua_pushstring(L, "__gc");
          //LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.gcFunction);
          //LuaDLL.lua_rawset(L, -3);
          //LuaDLL.lua_pushstring(L, "__tostring");
          //LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.toStringFunction);
          //LuaDLL.lua_rawset(L, -3);

          //LuaDLL.lua_pushstring(L, "__index");
          //LuaDLL.lua_dostring(L, ToLuaCS.InstanceIndex);
          //LuaDLL.lua_rawset(L, -3);

          //LuaDLL.lua_pushstring(L, "__newindex");
          //LuaDLL.lua_dostring(L, ToLuaCS.InstanceNewIndex);
          //LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_settop(L, -2);
          LuaDLL.luaL_newmetatable(L, typeof(UnityEngine.Vector3).AssemblyQualifiedName);
          LuaDLL.lua_pushstring(L, "cache");
          LuaDLL.lua_newtable(L);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushlightuserdata(L, LuaDLL.luanet_gettag());
          LuaDLL.lua_pushnumber(L, 1);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_pushstring(L, "luaNet_indexfunction");
          LuaDLL.lua_rawget(L, (int)LuaIndexes.LUA_REGISTRYINDEX);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__gc");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.gcFunction);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__tostring");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.toStringFunction);
          LuaDLL.lua_rawset(L, -3);
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_pushstdcallcfunction(L, ToLuaCS.metaFunctions.newindexFunction);
          LuaDLL.lua_rawset(L, -3);

      //#region 判断父类
      //    System.Type superT = typeof(UnityEngine.Vector3).BaseType;
      //    if (superT != null)
      //    {
      //        LuaDLL.luaL_getmetatable(L, superT.AssemblyQualifiedName);
      //        if (!LuaDLL.lua_isnil(L, -1))
      //        {
      //            LuaDLL.lua_setmetatable(L, -2);
      //        }
      //        else
      //        {
      //            LuaDLL.lua_remove(L, -1);
      //        }
      //    }
      //#endregion

  
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
    
          string[] names = typeof(UnityEngine.Vector3).FullName.Split(new char[] { '.' });
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
          LuaDLL.lua_pushstring(L, typeof(UnityEngine.Vector3).FullName);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__index");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushstring(L, "__newindex");
          LuaDLL.lua_dostring(L, ToLuaCS.StaticNewIndex);
          LuaDLL.lua_rawset(L, -3);
          
          LuaDLL.lua_pushvalue(L, -1);
          LuaDLL.lua_setmetatable(L, -2);
            
          LuaDLL.lua_pushstring(L,"Lerp");
          luafn_Lerp= new LuaCSFunction(Lerp);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Lerp);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Slerp");
          luafn_Slerp= new LuaCSFunction(Slerp);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Slerp);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"OrthoNormalize");
          luafn_OrthoNormalize= new LuaCSFunction(OrthoNormalize);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_OrthoNormalize);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"MoveTowards");
          luafn_MoveTowards= new LuaCSFunction(MoveTowards);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_MoveTowards);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"RotateTowards");
          luafn_RotateTowards= new LuaCSFunction(RotateTowards);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_RotateTowards);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SmoothDamp");
          luafn_SmoothDamp= new LuaCSFunction(SmoothDamp);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SmoothDamp);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Scale");
          luafn_Scale= new LuaCSFunction(Scale);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Scale);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Cross");
          luafn_Cross= new LuaCSFunction(Cross);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Cross);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Reflect");
          luafn_Reflect= new LuaCSFunction(Reflect);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Reflect);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Normalize");
          luafn_Normalize= new LuaCSFunction(Normalize);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Normalize);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Dot");
          luafn_Dot= new LuaCSFunction(Dot);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Dot);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Project");
          luafn_Project= new LuaCSFunction(Project);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Project);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Exclude");
          luafn_Exclude= new LuaCSFunction(Exclude);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Exclude);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Angle");
          luafn_Angle= new LuaCSFunction(Angle);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Angle);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Distance");
          luafn_Distance= new LuaCSFunction(Distance);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Distance);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"ClampMagnitude");
          luafn_ClampMagnitude= new LuaCSFunction(ClampMagnitude);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_ClampMagnitude);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Magnitude");
          luafn_Magnitude= new LuaCSFunction(Magnitude);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Magnitude);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"SqrMagnitude");
          luafn_SqrMagnitude= new LuaCSFunction(SqrMagnitude);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_SqrMagnitude);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Min");
          luafn_Min= new LuaCSFunction(Min);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Min);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"Max");
          luafn_Max= new LuaCSFunction(Max);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_Max);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_zero");
          luafn_get_zero= new LuaCSFunction(get_zero);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_zero);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_one");
          luafn_get_one= new LuaCSFunction(get_one);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_one);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_forward");
          luafn_get_forward= new LuaCSFunction(get_forward);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_forward);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_back");
          luafn_get_back= new LuaCSFunction(get_back);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_back);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_up");
          luafn_get_up= new LuaCSFunction(get_up);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_up);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_down");
          luafn_get_down= new LuaCSFunction(get_down);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_down);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_left");
          luafn_get_left= new LuaCSFunction(get_left);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_left);
          LuaDLL.lua_rawset(L, -3);

          LuaDLL.lua_pushstring(L,"get_right");
          luafn_get_right= new LuaCSFunction(get_right);
          LuaDLL.lua_pushstdcallcfunction(L, luafn_get_right);
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
          private static LuaCSFunction luafn_GetHashCode;
          private static LuaCSFunction luafn_Equals;
          private static LuaCSFunction luafn_get_normalized;
          private static LuaCSFunction luafn_ToString;
          private static LuaCSFunction luafn_get_magnitude;
          private static LuaCSFunction luafn_get_sqrMagnitude;
          private static LuaCSFunction luafn_GetType;
          private static LuaCSFunction luafn_get_x;
          private static LuaCSFunction luafn_set_x;
          private static LuaCSFunction luafn_get_y;
          private static LuaCSFunction luafn_set_y;
          private static LuaCSFunction luafn_get_z;
          private static LuaCSFunction luafn_set_z;
 #endregion        
  #region statics declaration       
          private static LuaCSFunction luafn_Lerp;
          private static LuaCSFunction luafn_Slerp;
          private static LuaCSFunction luafn_OrthoNormalize;
          private static LuaCSFunction luafn_MoveTowards;
          private static LuaCSFunction luafn_RotateTowards;
          private static LuaCSFunction luafn_SmoothDamp;
          private static LuaCSFunction luafn_Scale;
          private static LuaCSFunction luafn_Cross;
          private static LuaCSFunction luafn_Reflect;
          private static LuaCSFunction luafn_Normalize;
          private static LuaCSFunction luafn_Dot;
          private static LuaCSFunction luafn_Project;
          private static LuaCSFunction luafn_Exclude;
          private static LuaCSFunction luafn_Angle;
          private static LuaCSFunction luafn_Distance;
          private static LuaCSFunction luafn_ClampMagnitude;
          private static LuaCSFunction luafn_Magnitude;
          private static LuaCSFunction luafn_SqrMagnitude;
          private static LuaCSFunction luafn_Min;
          private static LuaCSFunction luafn_Max;
          private static LuaCSFunction luafn_get_zero;
          private static LuaCSFunction luafn_get_one;
          private static LuaCSFunction luafn_get_forward;
          private static LuaCSFunction luafn_get_back;
          private static LuaCSFunction luafn_get_up;
          private static LuaCSFunction luafn_get_down;
          private static LuaCSFunction luafn_get_left;
          private static LuaCSFunction luafn_get_right;
          private static LuaCSFunction luafn_get_kEpsilon;
          private static LuaCSFunction luafn_set_kEpsilon;
 #endregion        
  #region  instances method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_Item(LuaState L)
          {
                  System.Int32 index_ = (System.Int32)LuaDLL.lua_tonumber(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
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
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  target[  index_]= value_;
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Set(LuaState L)
          {
                  System.Single new_x_ = (System.Single)LuaDLL.lua_tonumber(L,2);
                  System.Single new_y_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single new_z_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  target.Set( new_x_, new_y_, new_z_);
                 return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetHashCode(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.Int32 gethashcode= target.GetHashCode();
                  ToLuaCS.push(L,gethashcode); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Equals(LuaState L)
          {
                  System.Object other_ = (System.Object)ToLuaCS.getObject(L,2);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.Boolean equals= target.Equals( other_);
                  ToLuaCS.push(L,equals); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_normalized(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  UnityEngine.Vector3 normalized= target.normalized;
                  ToLuaCS.push(L,normalized); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ToString(LuaState L)
          {
              if( LuaDLL.lua_type(L,2)==LuaTypes.LUA_TSTRING )
              {
                  System.String format_ =  LuaDLL.lua_tostring(L,2); 


                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.String tostring= target.ToString( format_);
                  ToLuaCS.push(L,tostring); 
                  return 1;

              }
              if(true)
              {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.String tostring= target.ToString();
                  ToLuaCS.push(L,tostring); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_magnitude(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.Single magnitude= target.magnitude;
                  ToLuaCS.push(L,magnitude); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_sqrMagnitude(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.Single sqrMagnitude= target.sqrMagnitude;
                  ToLuaCS.push(L,sqrMagnitude); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int GetType(LuaState L)
          {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  System.Type gettype= target.GetType();
                  ToLuaCS.push(L,gettype); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_x(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  var val=  target.x;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_x(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original;
                  var val = LuaDLL.lua_tonumber(L, 2);
                  target.x = (System.Single)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_y(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  var val=  target.y;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_y(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original;
                  var val = LuaDLL.lua_tonumber(L, 2);
                  target.y = (System.Single)val;// (System.Single)val;
                  return 0;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_z(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  var val=  target.z;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_z(LuaState L)
          {
                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original;
                  var val = LuaDLL.lua_tonumber(L, 2);
                  target.z = (System.Single)val;
                  return 0;

          }
  #endregion       
  #region  static method       
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Lerp(LuaState L)
          {
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector3 lerp= UnityEngine.Vector3.Lerp( from_, to_, t_);
                  ToLuaCS.push(L,lerp); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Slerp(LuaState L)
          {
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single t_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector3 slerp= UnityEngine.Vector3.Slerp( from_, to_, t_);
                  ToLuaCS.push(L,slerp); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int OrthoNormalize(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 normal_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 tangent_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 binormal_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);

                  UnityEngine.Vector3.OrthoNormalize( ref normal_, ref tangent_, ref binormal_);
                 return 0;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 normal_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 tangent_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.Vector3.OrthoNormalize( ref normal_, ref tangent_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int MoveTowards(LuaState L)
          {
                  UnityEngine.Vector3 current_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 target_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single maxDistanceDelta_ = (System.Single)LuaDLL.lua_tonumber(L,3);

                  UnityEngine.Vector3 movetowards= UnityEngine.Vector3.MoveTowards( current_, target_, maxDistanceDelta_);
                  ToLuaCS.push(L,movetowards); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int RotateTowards(LuaState L)
          {
                  UnityEngine.Vector3 current_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 target_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  System.Single maxRadiansDelta_ = (System.Single)LuaDLL.lua_tonumber(L,3);
                  System.Single maxMagnitudeDelta_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  UnityEngine.Vector3 rotatetowards= UnityEngine.Vector3.RotateTowards( current_, target_, maxRadiansDelta_, maxMagnitudeDelta_);
                  ToLuaCS.push(L,rotatetowards); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SmoothDamp(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3 && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,6)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.Vector3 current_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 target_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 currentVelocity_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);
                  System.Single smoothTime_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single maxSpeed_ = (System.Single)LuaDLL.lua_tonumber(L,5);
                  System.Single deltaTime_ = (System.Single)LuaDLL.lua_tonumber(L,6);

                  UnityEngine.Vector3 smoothdamp= UnityEngine.Vector3.SmoothDamp( current_, target_, ref currentVelocity_, smoothTime_, maxSpeed_, deltaTime_);
                  ToLuaCS.push(L,smoothdamp); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3 && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER  && LuaDLL.lua_type(L,5)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.Vector3 current_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 target_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 currentVelocity_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);
                  System.Single smoothTime_ = (System.Single)LuaDLL.lua_tonumber(L,4);
                  System.Single maxSpeed_ = (System.Single)LuaDLL.lua_tonumber(L,5);

                  UnityEngine.Vector3 smoothdamp= UnityEngine.Vector3.SmoothDamp( current_, target_, ref currentVelocity_, smoothTime_, maxSpeed_);
                  ToLuaCS.push(L,smoothdamp); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 3) is UnityEngine.Vector3 && LuaDLL.lua_type(L,4)==LuaTypes.LUA_TNUMBER )
              {
                  UnityEngine.Vector3 current_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 target_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);
                  UnityEngine.Vector3 currentVelocity_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,3);
                  System.Single smoothTime_ = (System.Single)LuaDLL.lua_tonumber(L,4);

                  UnityEngine.Vector3 smoothdamp= UnityEngine.Vector3.SmoothDamp( current_, target_, ref currentVelocity_, smoothTime_);
                  ToLuaCS.push(L,smoothdamp); 
                  return 1;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Scale(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3 && ToLuaCS.getObject(L, 2) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 a_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 b_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.Vector3 scale= UnityEngine.Vector3.Scale( a_, b_);
                  ToLuaCS.push(L,scale); 
                  return 1;

              }
              if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 scale_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  target.Scale( scale_);
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Cross(LuaState L)
          {
                  UnityEngine.Vector3 lhs_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 rhs_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.Vector3 cross= UnityEngine.Vector3.Cross( lhs_, rhs_);
                  ToLuaCS.push(L,cross); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Reflect(LuaState L)
          {
                  UnityEngine.Vector3 inDirection_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 inNormal_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.Vector3 reflect= UnityEngine.Vector3.Reflect( inDirection_, inNormal_);
                  ToLuaCS.push(L,reflect); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Normalize(LuaState L)
          {
              if( ToLuaCS.getObject(L, 1) is UnityEngine.Vector3)
              {
                  UnityEngine.Vector3 value_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);

                  UnityEngine.Vector3 normalize= UnityEngine.Vector3.Normalize( value_);
                  ToLuaCS.push(L,normalize); 
                  return 1;

              }
              if(true)
              {

                  object original = ToLuaCS.getObject(L, 1);
                  UnityEngine.Vector3 target= (UnityEngine.Vector3) original ;
                  target.Normalize();
                 return 0;

              }
          return 0;
          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Dot(LuaState L)
          {
                  UnityEngine.Vector3 lhs_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 rhs_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  System.Single dot= UnityEngine.Vector3.Dot( lhs_, rhs_);
                  ToLuaCS.push(L,dot); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Project(LuaState L)
          {
                  UnityEngine.Vector3 vector_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 onNormal_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.Vector3 project= UnityEngine.Vector3.Project( vector_, onNormal_);
                  ToLuaCS.push(L,project); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Exclude(LuaState L)
          {
                  UnityEngine.Vector3 excludeThis_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 fromThat_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.Vector3 exclude= UnityEngine.Vector3.Exclude( excludeThis_, fromThat_);
                  ToLuaCS.push(L,exclude); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Angle(LuaState L)
          {
                  UnityEngine.Vector3 from_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 to_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  System.Single angle= UnityEngine.Vector3.Angle( from_, to_);
                  ToLuaCS.push(L,angle); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Distance(LuaState L)
          {
                  UnityEngine.Vector3 a_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 b_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  System.Single distance= UnityEngine.Vector3.Distance( a_, b_);
                  ToLuaCS.push(L,distance); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int ClampMagnitude(LuaState L)
          {
                  UnityEngine.Vector3 vector_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  System.Single maxLength_ = (System.Single)LuaDLL.lua_tonumber(L,2);

                  UnityEngine.Vector3 clampmagnitude= UnityEngine.Vector3.ClampMagnitude( vector_, maxLength_);
                  ToLuaCS.push(L,clampmagnitude); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Magnitude(LuaState L)
          {
                  UnityEngine.Vector3 a_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);

                  System.Single magnitude= UnityEngine.Vector3.Magnitude( a_);
                  ToLuaCS.push(L,magnitude); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int SqrMagnitude(LuaState L)
          {
                  UnityEngine.Vector3 a_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);

                  System.Single sqrmagnitude= UnityEngine.Vector3.SqrMagnitude( a_);
                  ToLuaCS.push(L,sqrmagnitude); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Min(LuaState L)
          {
                  UnityEngine.Vector3 lhs_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 rhs_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.Vector3 min= UnityEngine.Vector3.Min( lhs_, rhs_);
                  ToLuaCS.push(L,min); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int Max(LuaState L)
          {
                  UnityEngine.Vector3 lhs_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,1);
                  UnityEngine.Vector3 rhs_ = (UnityEngine.Vector3)ToLuaCS.getObject(L,2);

                  UnityEngine.Vector3 max= UnityEngine.Vector3.Max( lhs_, rhs_);
                  ToLuaCS.push(L,max); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_zero(LuaState L)
          {

                  UnityEngine.Vector3 zero= UnityEngine.Vector3.zero;
                  ToLuaCS.push(L,zero); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_one(LuaState L)
          {

                  UnityEngine.Vector3 one= UnityEngine.Vector3.one;
                  ToLuaCS.push(L,one); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_forward(LuaState L)
          {

                  UnityEngine.Vector3 forward= UnityEngine.Vector3.forward;
                  ToLuaCS.push(L,forward); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_back(LuaState L)
          {

                  UnityEngine.Vector3 back= UnityEngine.Vector3.back;
                  ToLuaCS.push(L,back); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_up(LuaState L)
          {

                  UnityEngine.Vector3 up= UnityEngine.Vector3.up;
                  ToLuaCS.push(L,up); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_down(LuaState L)
          {

                  UnityEngine.Vector3 down= UnityEngine.Vector3.down;
                  ToLuaCS.push(L,down); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_left(LuaState L)
          {

                  UnityEngine.Vector3 left= UnityEngine.Vector3.left;
                  ToLuaCS.push(L,left); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_right(LuaState L)
          {

                  UnityEngine.Vector3 right= UnityEngine.Vector3.right;
                  ToLuaCS.push(L,right); 
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int get_kEpsilon(LuaState L)
          {
                  var val=   UnityEngine.Vector3.kEpsilon;
                  ToLuaCS.push(L,val);
                  return 1;

          }
          
          [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
          public static int set_kEpsilon(LuaState L)
          {
                   //var val= ToLuaCS.getObject(L, 1);
                  //UnityEngine.Vector3.kEpsilon= (System.Single)val;
                  return 0;

          }
  #endregion       
}

