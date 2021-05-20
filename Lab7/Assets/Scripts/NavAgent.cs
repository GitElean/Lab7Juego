using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour
{
    NavMeshAgent agent;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(mouseRay, out hitInfo))
            {
                NavMeshHit navhit;
                if(NavMesh.SamplePosition(hitInfo.point, out navhit, 0.2f, NavMesh.AllAreas))
                {
                    agent.SetDestination(navhit.position);
                    print(navhit.position);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("mob"))
            Destroy(gameObject);
    }
}
