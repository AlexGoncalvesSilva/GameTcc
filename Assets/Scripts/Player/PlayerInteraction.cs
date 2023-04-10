using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteraction : MonoBehaviour
{
    public float rayDistance = 2f;
    public float rotateSpeed = 200f;

    public float velocidadeDoObj = 5f;

    public Transform objectViwer;

    public UnityEvent OnView;
    public UnityEvent OnFinishView;

    private Camera myCam;

    private bool isViewing;
    private bool canFinish;

    private Interactables currentInteractable;
    private Vector3 originPosition;
    private Quaternion originRotation;

    private SFXItens sfxItens;

    private void Awake()
    {
        sfxItens= GetComponent<SFXItens>();
    }

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractables();
    }

    void CheckInteractables()
    {
        if (isViewing)
        {
            if (currentInteractable.item.grabbable && Input.GetMouseButton(0))
            {
                RotateObject();
            }
            if(canFinish && Input.GetMouseButtonDown(1))
            {
                FinishView();
            }

            return;
        }

        RaycastHit hit;
        var rayOrigin = myCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayOrigin, out hit, rayDistance))
        {
            Interactables interactable = hit.collider.GetComponent<Interactables>();
            if (interactable != null)//aq ele ta colidindo com um objeto que interage
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (interactable.isMoving)
                    {
                        return;
                    }

                    Debug.Log("Aq tá pegando");
                    OnView.Invoke();

                    currentInteractable = interactable;

                    isViewing = true;

                    CameraController.instance.CantMoveCamera();

                    Interact(currentInteractable.item);

                    if (currentInteractable.item.grabbable)
                    {
                        originPosition = currentInteractable.transform.position;
                        originRotation = currentInteractable.transform.rotation;
                        StartCoroutine(MovingObject(currentInteractable, objectViwer.position));
                    }
                }

            }
            else
            {
                //aq ele nn ta colidindo com um objeto que interage
            }
        }
        else
        {
            //n se colidiu com nd
        }
    }

    void Interact(Item item)
    {
        sfxItens.PlayAudio(item.audioClip);
        UiManager.Instance.SetCaptions(item.text);
        Invoke("CanFinish" , item.audioClip.length + 0.7f);
    }

    void CanFinish()
    {
        canFinish = true;
        UiManager.Instance.SetCaptions("");
    }

    void FinishView()
    {
        canFinish = false;
        isViewing = false;
        if (currentInteractable.item.grabbable)
        {
            currentInteractable.transform.rotation = originRotation;
            StartCoroutine(MovingObject(currentInteractable, originPosition));
        }

        OnFinishView.Invoke();
        CameraController.instance.CanMoveCamera();
    }

    IEnumerator MovingObject(Interactables obj, Vector3 position)
    {
        obj.isMoving = true;
        float timer = 0;
        while (timer < 1)
        {
            obj.transform.position = Vector3.Lerp(obj.transform.position, position, Time.deltaTime * velocidadeDoObj);
            timer += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = position;

        obj.isMoving = false;
    }

    void RotateObject()
    {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");
        currentInteractable.transform.Rotate(myCam.transform.right, -Mathf.Deg2Rad * y * rotateSpeed, Space.World);
        currentInteractable.transform.Rotate(myCam.transform.up, -Mathf.Deg2Rad * x * rotateSpeed, Space.World);
    }
}
