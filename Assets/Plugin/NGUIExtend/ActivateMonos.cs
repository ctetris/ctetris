﻿using UnityEngine;
using System.Collections.Generic;

public class ActivateMonos : MonoBehaviour {

	#region pulic member
    public List<MonoBehaviour> monos;
    //public List<MonoBehaviour> deactivate;

    public List<GameObject> activateGameObj;
    //public List<GameObject> deactivateObj;
	#endregion

	#region mono

    void OnEnable()
    {
        for (int i = 0; i < monos.Count; ++i)
            monos[i].enabled = true;

        for (int i = 0; i < activateGameObj.Count; ++i)
            activateGameObj[i].SetActive(true);
    }

    void OnDisable()
    {
        for (int i = 0; i < monos.Count; ++i)
            monos[i].enabled = false;

        for (int i = 0; i < activateGameObj.Count; ++i)
            activateGameObj[i].SetActive(false);
    }
	#endregion
}
