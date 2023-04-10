using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[System.Serializable]

public class Interactables : MonoBehaviour
{
    public Item item;

    /*
        public UnityEvent OnInteract;
        public UnityEvent CollectItem;
    */
    [HideInInspector]
    public bool isMoving;

}