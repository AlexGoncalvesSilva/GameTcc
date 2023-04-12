using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepWhenLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
