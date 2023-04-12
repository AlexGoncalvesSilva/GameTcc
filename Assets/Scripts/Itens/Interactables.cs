using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//[System.Serializable]

public class Interactables : MonoBehaviour
{
    [SerializeField] private GameObject interactContainer;
    [SerializeField] private PlayerInteraction playerInteraction;
    public Item item;

    public bool isClue;

    public bool alredyInteract;
    /*
        public UnityEvent OnInteract;
        public UnityEvent CollectItem;
    */
    [HideInInspector]
    public bool isMoving;

    private void Update()
    {
       
    }
    private void Show()
    {
        interactContainer.SetActive(true);
    }
    private void Hide()
    {
        interactContainer.SetActive(false);
    }
}