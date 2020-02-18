using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmartCop : MonoBehaviour, IAmAFuckingCop
{
    // Start is called before the first frame update

    public PoliceInteligent m_InteligentCop;
    NavMeshAgent m_NavMeshAgent;
    public enum TState
    {
		WAITING,
		MOVING,
		THINKING,
		DIE
    }
    public TState m_State;

    public GameObject Itaca;

    public ActivaOrdos m_AOs;

    public bool IhaveFoundTrash;

    public GameObject RightWay;

    public GameObject LeftWay;

	public Vector3 R;

	public Vector3 L;

    public bool GoingLeft;

    public bool GoingRight;

    public float BuildCount;

    public FrontColliderCopScript m_FCCS;

	public bool Agujeraco;

	public bool AhoraHayUnHueco;

	public float m_HuecoTimer;

	public Vector3 AquiEstaElHueco;

	public bool StopTRASH;



    void Start()
    {
        m_InteligentCop.AddAStupidCop(this);
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
		//SetWaitingState();
    }

    // Update is called once per frame
    void Update()
    {
		R = new Vector3(this.transform.position.x- 30,this.transform.position.y,this.transform.position.z);
		L = new Vector3(this.transform.position.x + 30,this.transform.position.y,this.transform.position.z);

		if(AhoraHayUnHueco == true)
		{
			
			m_HuecoTimer = m_HuecoTimer + 1*Time.deltaTime;
		}

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
		m_NavMeshAgent.isStopped = false;
		
		WichSideIDecide();	
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
		AvoidTrash();
		NoHaySalida();

	}
	void UpdateDieState()
	{

	}

	public void FindTrash()
	{
		if(m_FCCS.ColisionTrash)
		{
			StopTRASH = true;
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
	public void AvoidTrash()
	{
		if(m_FCCS.ColisionTrash == true)
		{
			Agujeraco = false;
			m_HuecoTimer = 0;
			AhoraHayUnHueco = false;

			if(m_FCCS.ColisionBuild == true)
			{
				m_NavMeshAgent.isStopped=true;
				
				if(GoingLeft == true)
				{
					GoingRight = true;
					GoingLeft = false;
					SetThinkingState();	
					BuildCount++;
				}
				else
				{
					GoingLeft = true;
					GoingRight = false;
					SetThinkingState();	
					BuildCount++;
				}
				//Invoke("SetThinkingState", 0.1f); 
				m_FCCS.ColisionBuild = false;
			}
		}
		else 
		{		
			AhoraHayUnHueco = true;
			//SetMovingState();
			
			
			if(m_HuecoTimer >= 1.5f)
			{
				m_NavMeshAgent.isStopped=true;
				AquiEstaElHueco = this.transform.position;
				BuildCount = 0;
				Agujeraco = true;
				StopTRASH = false;
				Invoke("SetMovingState", 1);
			}
		}
	}
	
	public void GoLeft()
	{
		
		//L = transform.TransformPoint(this.transform.position.x + 30,this.transform.position.y,this.transform.position.z);
		m_NavMeshAgent.SetDestination(LeftWay.transform.position);
		GoingLeft = true;
		GoingRight = false;
	}
	public void GoRight()
	{
		//R = transform.TransformPoint(this.transform.position.x - 30,this.transform.position.y,this.transform.position.z);
		m_NavMeshAgent.SetDestination(RightWay.transform.position);
		GoingRight = true;
		GoingLeft = false;
	}
	public void HayUnHueco(Vector3 jaj)
    {
       AvoidTrash();
    }
	public void StopNow()
	{
		
		//Invoke("SetThinkingState",object.1);
		SetThinkingState();
		
	}
	public void NoHaySalida()
	{
		if(BuildCount >= 2)
		{
			Invoke("pStop", 1.5f);
		}
	}
	public void pStop() 
	{
		m_NavMeshAgent.isStopped=true;
	}

	



}
