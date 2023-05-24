using UnityEngine;

public class CellohoneTripleD : MonoBehaviour
{
    public GameObject objectToActivate;

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}
