using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BASICCop : MonoBehaviour
{
    // Start is called before the first frame update
    
    NavMeshAgent m_NavMeshAgent;
    public enum TState
    {
		INITIAL,
		MOVE_TO_CENTER,
		WAITING_ORDER		
    }
    public TState m_State;
 
    public FrontColliderCopScript m_FCCS;

    public string SideTag;
    public string ItacaTag;

    public bool InPlace;

    public GameObject PositionInFormation;

    public Vector3 Target;
    public bool stop;

    GameObject LEAD;

    void Start()
    {
        m_State = TState.INITIAL;
        m_NavMeshAgent = GetComponent<NavMeshAgent>();     
    }

    // Update is called once per frame
    void Update()
    {
        switch(m_State)
		{
			case TState.INITIAL:UpdateINITIALState();
			break;

			case TState.MOVE_TO_CENTER: UpdateMOVING_TO_CENTERState();
			break;

			case TState.WAITING_ORDER: UpateWAITINGState();
			break;

			
		}	
        stop = IHaveFoundTrash();
        
    }
    public void SetINITIALState()
    {
        m_State = TState.INITIAL;
        Stop();
    }
    public void UpdateINITIALState()
    {
        
    }
    public void SetMOVING_TO_CENTERState()
    {
        m_State = TState.MOVE_TO_CENTER;
        m_NavMeshAgent.isStopped=false;
        GameObject newItaca;
        newItaca = GameObject.FindGameObjectWithTag(ItacaTag);
        m_NavMeshAgent.SetDestination(newItaca.transform.position);
    }
    void UpdateMOVING_TO_CENTERState()
    {
        //Debug.Log(IHaveFoundTrash());
        //Debug.Log(SideTag + "    " + IHaveFoundTrash());
        
    }
    public void SetWAITINGState()
    {
        m_State = TState.WAITING_ORDER;
        m_NavMeshAgent.isStopped = true;
    }
    void UpateWAITINGState()
    {
        m_NavMeshAgent.isStopped = true;
        
    }

    public bool IAmOnSide()
    {
        GameObject Side;
        float Dist;
        Side = GameObject.FindGameObjectWithTag(SideTag);
        Dist = Vector3.Distance(this.transform.position, Side.transform.position);
       

        if(Dist <= 1.5f)
        {
            
            return true;
        }
        else
        {
            
            return false;
        }   
    }
    public bool IHaveFoundTrash()
    {
       if(m_FCCS.ColisionTrash == true)
       { 
            return true;   
       }
       else
       {
            return false;
       }
       
    }
    public bool IHaveFoundSuperTrash()
    {
       if(m_FCCS.Colision3Trash == true)
       { 
            return true;   
       }
       else
       {
            return false;
       }
    }
    public Vector3 TargetFormation()
    {
        GameObject Side;
        Side = GameObject.FindGameObjectWithTag(SideTag);
        return  Side.transform.position;
    }
    public void GoToTarget(Vector3 Target)
    {
        
        m_NavMeshAgent.isStopped=false;
		m_NavMeshAgent.SetDestination(Target);
        
        
    }
    public void GoToYourFormationSide()
    {   
 	    GoToTarget(TargetFormation());
    }
    public void Stop() 
    {   
        m_NavMeshAgent.isStopped = true;
    }
    public bool IAmOnTarget(string tag)
    {
        GameObject target;
        bool result;
        float dist;
        target = GameObject.FindGameObjectWithTag(tag);
        dist = Vector3.Distance(this.transform.position, target.transform.position);
        if(dist >= 2)
        {
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }
    
    
  
 
}
