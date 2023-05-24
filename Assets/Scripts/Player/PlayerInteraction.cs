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
    public bool canFinish;
    public bool notebook;
    public bool notebookLab;

    private Interactables currentInteractable;
    private Vector3 originPosition;
    private Quaternion originRotation;

    private SFXItens sfxItens;

    public static PlayerInteraction instance;
    private void Awake()
    {
        sfxItens= GetComponent<SFXItens>();
        instance = this;
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

    public void CheckInteractables()
    {
        if (isViewing)
        {
            if (currentInteractable.item.grabbable && Input.GetMouseButton(0))
            {
                RotateObject();
            }
            if(canFinish && Input.GetKeyDown(KeyCode.E))
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
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (interactable.isMoving)
                    {
                        return;
                    }

                    Debug.Log("Aq tá pegando");
                    OnView.Invoke();

                    currentInteractable = interactable;

                    isViewing = true;

                    Invoke("CanFinish", 1f);

                    CameraController.instance.CantMoveCamera();

                    if (hit.transform.tag == "HouseNotebook")
                    {
                        if (LiberarNot.instance.playerHasThePassword == true)
                        {
                            LiberarNot.instance.OpenPanel();
                            notebook = true;
                        } else
                        { Interact(currentInteractable.item); }

                    }else { Interact(currentInteractable.item); }

                    if(hit.transform.tag == "LabNotebook")
                    {
                        Interact(currentInteractable.item);
                        StartCoroutine("rotinaText");
                        LabNot.instance.OpenPanelLab();
                        notebookLab = true;
                    }

                    if(interactable.isClue == true && interactable.alredyInteract == false)
                    {
                        Analyze.instance.PistaObjeto();
                        interactable.alredyInteract= true;
                    }

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

    IEnumerator rotinaText()
    {
        yield return new WaitForSeconds(2f);
        UiManager.instance.SetCaptions("");
    }

    void Interact(Item item)
    {
        if (item.panelInterection != null)
        {
            UiManager.instance.showPanelLevels();
            Debug.Log("Clicou no quadro");
            Cursor.lockState = CursorLockMode.None;
        }
        if (item.image != null)
        {
            UiManager.instance.SetImage(item.image);
        }
        sfxItens.PlayAudio(item.audioClip);
        UiManager.instance.SetCaptions(item.text);
        Invoke("CanFinish" , 1f);
    }

    void CanFinish()
    {
        canFinish = true;
        UiManager.instance.SetBackImage(true);
    }

    void FinishView()
    {
        canFinish = false;
        isViewing = false;
        UiManager.instance.SetCaptions("");
        UiManager.instance.SetBackImage(false);
        if (currentInteractable.item.grabbable)
        {
            currentInteractable.transform.rotation = originRotation;
            StartCoroutine(MovingObject(currentInteractable, originPosition));
        }
        if(notebook == true)
        {
            LiberarNot.instance.ClosePanel();
        }
        if (notebookLab == true) { LabNot.instance.ClosePanelLab(); }
        UiManager.instance.hidePanelLevels();
        Cursor.lockState = CursorLockMode.Locked;
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
