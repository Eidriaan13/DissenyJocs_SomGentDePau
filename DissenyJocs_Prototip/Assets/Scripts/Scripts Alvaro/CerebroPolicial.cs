using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CerebroPolicial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;
    public bool Go;
    NavMeshAgent m_NavMeshAgent;

    void Start()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Go == true)
        {
            m_NavMeshAgent.isStopped=true;
        }
        
    }
}
