using UnityEngine;
using System.Collections;
#if Nlua
using NLua;
using Lua = NLua.Lua;
#else
using LuaInterface;
using Lua = LuaInterface.LuaState;
using LuaDLL = LuaInterface.LuaDLL;
using LuaState = System.IntPtr;
#endif

public class ToLuaCS
{

    #region 
    /// <summary>
    /// Global table name 存放 static方法
    /// </summary>
    public const string GlobalTableName = "toluacs";

    /// <summary>
    ///  静态方法获取值
    /// </summary>
    public const string StaticIndex = @"
local function index(obj,name)
        local getstr=""get_""..name
        local fn=rawget(obj,getstr)
        if type(fn)==""function"" then
            return fn()
        else
            return fn
        end     
 end
    return index
";

    /// <summary>
    /// 静态方法设置值
    /// </summary>
    public static string StaticNewIndex = @"
local function newindex(obj,name,value)
        local setstr=""set_""..name
        local fn=rawget(obj,setstr)
        if type(fn)==""function"" then
            return fn(value)
        end         
 end
    return newindex
";

    /// <summary>
    /// 实例方法获取值
    /// </summary>
    public const string InstanceIndex = @"
local function index(obj,name,meta1)
        local meta=getmetatable(meta1 or obj)
        if meta==nil then return nil end
        local fn=rawget(meta,name)
        if  fn~=nil then
            return fn
        elseif fn==nil then
            local getstr=""get_""..name
            fn= rawget(meta,getstr)
            if type(fn)==""function"" then
                return fn(obj)
            else
                return index(obj,name,meta)
            end
        end
 end
    return index
";

    /// <summary>
    /// 实例方法设置值
    /// </summary>
    public const string InstanceNewIndex = @"
local function newindex(obj,name,value,meta1)
        local meta=getmetatable(meta1 or obj)
        if meta==nil then return end
        local fn=rawget(meta,name)
        if  type(fn)==""function"" then
            fn(obj,value)
        elseif fn==nil then
          local setstr=""set_""..name
            fn=rawget(meta,setstr)
            if  type(fn)==""function"" then
                fn(obj,value)
            else
                newindex(obj,name,value,meta)
            end   
        end
 end
    return newindex
";

    #endregion

    public static Lua lua
    {
        get{ return _lua;}
        set
        {
            _lua = value;
            translator = _lua.translator;
            metaFunctions = translator.metaFunctions;
        }
    }

    private static Lua _lua;
    private static ObjectTranslator translator;
    public static MetaFunctions metaFunctions;
    /// <summary>
    /// 获取指定索引位置的值
    /// </summary>
    /// <param name="L"></param>
    /// <param name="i"></param>
    /// <returns></returns>
  public static object getObject(LuaState L,int i)
  {
      return translator.getObject(L,i);
  }

    /// <summary>
    /// 入栈
    /// </summary>
    /// <param name="L"></param>
    /// <param name="v"></param>
  public static void push(LuaState L, object v)
  {
      translator.push(L, v);
  }
}
