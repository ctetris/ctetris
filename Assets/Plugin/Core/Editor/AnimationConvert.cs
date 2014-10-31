using UnityEngine;
using System.Collections;
using UnityEditor;

public class AnimationConvert  {


    [MenuItem("Assets/AnimationConv/ConvertGe", false, 0)]
    static public void ConvertGe()
    {
        Debug.Log("Create map ");
        // AssetDatabase.CreateAsset();
        foreach (Object o in Selection.objects)
        {
            Debug.Log(o.name+" "+o.GetType().Name);
            if (o is AnimationClip)
            {
              // ((AnimationClip)o).t
                AnimationClip t = o as AnimationClip;
                //t.a
            }
        }
    }

    [MenuItem("Assets/AnimationConv/ConvertLeg", false, 1)]
    static public void ConvertLeg()
    {
        Debug.Log("Create map ");
        // AssetDatabase.CreateAsset();
        foreach (Object o in Selection.objects)
        {
            Debug.Log(o.name+" "+o.GetType().Name);
            if (o is AnimationClip)
            {
              // ((AnimationClip)o).t

            }
        }
    }

}
