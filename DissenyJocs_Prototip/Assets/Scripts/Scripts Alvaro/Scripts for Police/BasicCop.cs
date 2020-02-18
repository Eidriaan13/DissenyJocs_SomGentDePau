using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicCop : MonoBehaviour, IAmAFuckingCop
{
    // Start is called before the first frame update

    public string TagFormacion;
    public bool ImGonnaTry;

    public PoliceInteligent m_PoliceInteligent;

    public bool YouSonOfBitchImIn;

    public GameObject Itaca;
    NavMeshAgent m_NavMeshAgent;
    public enum TState
    {
	WAITING,
	MOVING,
	THINKING,
	DIE
    }
    public TState m_State;

    public ActivaOrdos m_AOs;

    public bool IhaveFoundTrash;

    public bool IhaveFoundBuild;

    public GameObject RightWay;

    public GameObject LeftWay;

    public bool GoingLeft;

    public bool GoingRight;

    public bool Agujeraco;

	public bool PArat;

    
    void Start()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {
      AddThisFuckingCopToTheList();
        switch(m_State)
		{
			case TState.WAITING:UpdateWaitingState();
			break;

			case TState.DIE: UpdateDieState();
			break;

			case TState.THINKING: UpdateThinkingState();
			break;

			case TState.MOVING: UpdateMovingState();
			break;
		}	
    }
    void SetWaitingState()
	{
		m_State = TState.WAITING;
		m_NavMeshAgent.isStopped=true;
	}
	void SetMovingState()
	{
		m_State = TState.MOVING;
		m_NavMeshAgent.isStopped=false;
		m_NavMeshAgent.SetDestination(Itaca.transform.position);
	}
	void SetThinkingState()
	{
		m_State = TState.THINKING;
        IhaveFoundBuild = false;
	}
	void SetDieState()
	{

	}
	void UpdateWaitingState()
	{
		if(m_AOs.atack == true)
		{
			SetMovingState();
		}
	}
	void UpdateMovingState()
	{		
		FindTrash();	
	}
	void UpdateThinkingState()
	{
        
	}
	void UpdateDieState()
	{

	}

	public void FindTrash()
	{
		PArat = false;

		if(IhaveFoundTrash)
		{
           StopNow();
		   //SetThinkingState();
		}
	}
	public void WichSideIDecide()
	{
		if(GoingRight == false && GoingLeft == false)
		{
			GoRight();
		}
		if(GoingLeft == true)
		{
			GoLeft();		
		}
		if(GoingRight == true)
		{
			GoRight();	
		}
		if(GoingRight == true && GoingLeft == true)
		{
			GoLeft();
		}	
	}
	public void WichDirection(bool R, bool L)
	{

		if(R == true)
        {
            m_NavMeshAgent.isStopped=false;
            GoRight();
        }
        if(L == true)
        {
            m_NavMeshAgent.isStopped=false;
            GoLeft();
        }
	}
	
	public void GoLeft()
	{
		m_NavMeshAgent.SetDestination(LeftWay.transform.position);
		GoingLeft = true;
		GoingRight = false;
	}
	public void GoRight()
	{
		m_NavMeshAgent.SetDestination(RightWay.transform.position);
		GoingRight = true;
		GoingLeft = false;
	}

    
    public void OnTriggerEnter(Collider other) 
    {
        if(other.tag == TagFormacion)
        {
            ImGonnaTry = true;
        }
        if(other.tag == "Trash1")
        {
            IhaveFoundTrash = true;
        }
        if(other.tag == "Build")
        {
            IhaveFoundBuild = true;
        }
    }

    public void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Trash1")
        {
            IhaveFoundTrash = false;
        }
        if(other.tag == "Build")
        {
            IhaveFoundBuild = false;
        }
    }
    public void AddThisFuckingCopToTheList()
    {
        if(ImGonnaTry == true)
        {
            m_PoliceInteligent.AddAStupidCop(this);
            YouSonOfBitchImIn = true;

        }
    }
    public void HayUnHueco(Vector3 VenPaka)
    {
	
		if(IhaveFoundTrash == true)
		{
			m_NavMeshAgent.isStopped=false;
      		m_NavMeshAgent.SetDestination(VenPaka);
			  
       		Invoke("SetMovingState", 2.5f);
		}
		else
		{
			SetMovingState();
		}
       
       
    }
    public void AvoidTrash()
	{
		if(IhaveFoundTrash == true)
		{	
			if(IhaveFoundBuild == true)
			{
				m_NavMeshAgent.isStopped=true;
				//ChangeDirection();
				if(GoingLeft == true)
				{
					GoingRight = true;
					GoingLeft = false;
					SetThinkingState();	
				}
				else
				{
					GoingLeft = true;
					GoingRight = false;
					SetThinkingState();	
				}
				//Invoke("SetThinkingState", 0.1f); 
			 IhaveFoundBuild = false;
			}
		}
		else 
		{		
			
		}
	}

    public void StopNow()
    {
		//Debug.Log("EOEOEOEO");
		PArat = true;
        m_NavMeshAgent.isStopped = true;
    }

    
}
