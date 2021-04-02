using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskIconController : MonoBehaviour
{
    TrayForm trayform;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_STANDALONE_WIN && !UNITY_EDITOR 
        trayform = new TrayForm();
#endif
    }

    private void OnApplicationFocus(bool focus)
    {
        Debug.Log("OnApplicationFocus : " + focus);

#if UNITY_STANDALONE_WIN && !UNITY_EDITOR
        trayform.OnApplicationFocusChange(focus);
#endif
    }
}
