using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;



public class DrawNavMeshPath : MonoBehaviour
{
    public  GameObject[] path;
    public  GameObject carriage;
    private SphereCollider carriageSphereCollider;
    public NavMeshAgent carriageNavAgent;


    
    // Start is called before the first frame update
    public void Start()
    {

        
        carriageSphereCollider = carriage.GetComponent<SphereCollider>();
        carriageNavAgent.Warp(path[0].transform.position);
        CarriageToPos(path[1].transform.position);
        

    }
    public void CarriageToPos(Vector3 ObjDestination)
    {
        //Vector3 carriageDest = new Vector3(ObjDestination.x, ObjDestination.y + 5.00f, ObjDestination.z);
        //Vector3 dir = (ObjDestination - carriage.transform.position).normalized;
        //carriage.transform.position += dir * Time.deltaTime * carriageNavAgent.speed;
        //Quaternion targetRotation = Quaternion.LookRotation(ObjDestination -carriage.transform.position);
        //carriage.transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 1.00f * carriageNavAgent.speed);
        LeanTween.init(2000);
        carriage.transform.LookAt(ObjDestination, Vector3.up);
        carriage.transform.LeanMove(new Vector3(ObjDestination.x, 33.33126f, ObjDestination.z), 10.0f);

    }


    // Update is called once per frame
    public void FixedUpdate()
    {
        
        if (carriageSphereCollider.bounds.Contains(path[1].transform.position))
        {
            CarriageToPos(path[2].transform.position);
            
        }
        else if (carriageSphereCollider.bounds.Contains(path[2].transform.position))
        {
            CarriageToPos(path[3].transform.position);
            
        }
        else if (carriageSphereCollider.bounds.Contains(path[3].transform.position))
        {
            CarriageToPos(path[4].transform.position);
            
        }

        else if (carriageSphereCollider.bounds.Contains(path[4].transform.position))
        {
            CarriageToPos(path[5].transform.position);
            
        }
        else if (carriageSphereCollider.bounds.Contains(path[5].transform.position))
        {
            CarriageToPos(path[6].transform.position);
            
        }
        else if (carriageSphereCollider.bounds.Contains(path[6].transform.position))
        {
            CarriageToPos(path[7].transform.position);
          
        }
        else if (carriageSphereCollider.bounds.Contains(path[7].transform.position))
        {
            CarriageToPos(path[8].transform.position);
            
        }
        else if (carriageSphereCollider.bounds.Contains(path[8].transform.position))
        {
            CarriageToPos(path[9].transform.position);
            
        }
        else if (carriageSphereCollider.bounds.Contains(path[9].transform.position))
        {
            CarriageToPos(path[10].transform.position);
           
        }
        else if (carriageSphereCollider.bounds.Contains(path[10].transform.position))
        {
            CarriageToPos(path[11].transform.position);
            
        }
        else if (carriageSphereCollider.bounds.Contains(path[11].transform.position))
        {

            CarriageToPos(path[12].transform.position);
            
        }

        else if (carriageSphereCollider.bounds.Contains(path[12].transform.position))
        {
            CarriageToPos(path[13].transform.position);
            
        }
        else if (carriageSphereCollider.bounds.Contains(path[13].transform.position))
        {
            CarriageToPos(path[14].transform.position);
           
        }
        else if (carriageSphereCollider.bounds.Contains(path[14].transform.position))
        {
            CarriageToPos(path[15].transform.position);
           
        }
        else if (carriageSphereCollider.bounds.Contains(path[15].transform.position))
        {
            CarriageToPos(path[16].transform.position);
            
        }
        else if (carriageSphereCollider.bounds.Contains(path[16].transform.position))
        {
            CarriageToPos(path[17].transform.position);
            
        }
        else if (carriageSphereCollider.bounds.Contains(path[17].transform.position))
        {
            CarriageToPos(path[18].transform.position);
           
        }
        else if (carriageSphereCollider.bounds.Contains(path[18].transform.position))
        {
            CarriageToPos(path[19].transform.position);
            
        }
        else if (carriageSphereCollider.bounds.Contains(path[19].transform.position))
        {
            CarriageToPos(path[20].transform.position);
           
        }
        else if (carriageSphereCollider.bounds.Contains(path[20].transform.position))
        {
            SceneManager.LoadScene("Results", LoadSceneMode.Single);

        }
    }
}
