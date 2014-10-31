using UnityEngine;
using System.Collections.Generic;
#if Nlua
using NLua;
#else
using LuaInterface;
#endif


public class LMultipleLoader : MultipleLoader {

    public LMultipleLoader()
        : base()
    {
        base.OnAllComplete += LMultipleLoader_onAllComplete;
        base.OnProgress += LMultipleLoader_onProgress;
    }

    public void LoadLuaTable(LuaTable reqs)
    {
        foreach (CRequest reqi in reqs.Values)
        {
            AddReqToQueue(reqi);
        }
        BeginQueue();
    }

    protected override void WaitDependencies(CLoader loader, IList<CRequest> reqs)
    {
       // CRequest req = loader.req;
        object key = "";
        IList<CRequest> reqsAdd = new List<CRequest>();
        LuaTable resdic = _cache;// req.cache as LuaTable;
        object cache = null;
        foreach (CRequest item in reqs)
        {
            key = item.key;
            cache = resdic[key];
            if (cache != null)//.ContainsKey(key))
            {
                item.data = cache;
                item.DispatchComplete();
                continue;
            }
            reqsAdd.Add(item);
        }

        loader.isWait = true;
        _currentLoading--;
        this.LoadReq(reqsAdd);
    }

    protected override void LoadComplete(CLoader loader)
    {
        CRequest req = loader.req;
//#if UNITY_EDITOR
//        if (req.isShared)
//            Debug.Log("_______loadComplete  <<" + req.key + ">> is dependencyItem  thread=  now:");
//        else
//            Debug.Log("______loadComplete  <<" + req.key + ">> now:");
//#endif
        if (loader.isWait == false)
            _currentLoading--;

        currentLoaded++;

        object data = req.data;

        if (onCacheFn!=null && (req.cache || req.isShared))
        {
            onCacheFn.Call(req);
        }

        IList<CRequest> callbacklist = requestCallBackList[req.udKey];
        if (callbacklist != null)
        {
            requestCallBackList.Remove(req.udKey);
            int count = callbacklist.Count;
            CRequest reqitem;
            for (int i = 0; i < count; i++)// reqitem in  callbacklist)
            {
                reqitem = callbacklist[i];
                reqitem.data = data;
                reqitem.DispatchComplete();
            }
        }

        RemoveRequest(req);

        BeginQueue();

        CheckAllComplete();

        if (req.isShared) LMultipleLoader_onSharedComplete(req);

    }

    void LMultipleLoader_onSharedComplete(CRequest req)
    {
        if (onSharedCompleteFn != null)
            onSharedCompleteFn.Call(req);
    }

    void LMultipleLoader_onProgress(MultipleLoader loader, LoaderEventArg arg)
    {
        if (onProgressFn != null)
            onProgressFn.Call(loader, arg);
    }

    void LMultipleLoader_onAllComplete(MultipleLoader loader)
    {
        if (onAllCompleteFn != null)
            onAllCompleteFn.Call(loader);
    }

    private LuaTable _cache;

    public override object cache
    {
        get { return _cache; }
        set
        {
            if (value is LuaTable)
                _cache = (LuaTable)value;
        }
    }

    #region  delegate and event

    public LuaFunction onAllCompleteFn;
    public LuaFunction onProgressFn;
    public LuaFunction onSharedCompleteFn;
    public LuaFunction onCacheFn;
    #endregion

    private static LMultipleLoader _instance;

    public static LMultipleLoader instance
    {
        get
        {
            if (_instance == null)
                _instance = new LMultipleLoader();
            return _instance;
        }
    }

}
