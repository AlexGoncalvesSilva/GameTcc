using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    
    [Header("Enemy Vision")]    
    public float visionRange;
    public float visionLarge;
    public Transform target;
    public Transform visionStart;

    [Header("Enemy Movement")]
    public List<GameObject> waypoints;
    public float speed;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vision();
        movement();
    }

    void vision()
    {
        float distance = Vector3.Distance(target.position, visionStart.position);


        if (distance <= visionRange)
        {
            Debug.Log("Viu o player, reiniciar fase");
            callReset();
        }
    }

    void movement()
    {
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05) 
        {
            if(index < waypoints.Count - 1) 
            { 
                index++;
                transform.eulerAngles = new Vector3(0f, 90f, 0f);
            }
            else 
            { 
                index = 0;
                transform.eulerAngles = new Vector3(0f, -90f , 0f);
                
            }
             
        }    
    }

    void callReset()
    {
        //reiniciar fase

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(visionStart.position, new Vector3(visionLarge, 2f, visionRange + 5f));
    }
}


