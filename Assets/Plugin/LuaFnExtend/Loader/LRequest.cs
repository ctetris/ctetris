using UnityEngine;
using System.Collections;
#if Nlua
using NLua;
#else
using LuaInterface;
#endif

public class LRequest : CRequest {

    public  LRequest(string url, int priority = 0, string key = "", string type = "") :base(url,priority,key,type)
    {
        this.OnComplete += OnCompHandler;
        this.OnEnd += OnEndHandler;
    }

    private void OnCompHandler(CRequest req)
    {
        if (onCompleteFn != null)
            onCompleteFn.Call(req);
    }

    private void OnEndHandler(CRequest req)
    {
        if (onEndFn != null)
            onEndFn.Call(req);
    }

    public LuaFunction onCompleteFn;

    public LuaFunction onEndFn;

}
