using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneEnemy : MonoBehaviour {

NavMeshAgent m_NavMeshAgent;
 public bool Cop1;

 public bool Cop2;

 public bool Cop3;

public enum TState
{
	WAITING,
	MOVING,
	SHOOT,
	DIE
}
public TState m_State;

public GameObject Itaca;

public ActivaOrdos m_AOs;

public bool IhaveFoundTrash;

public GameObject RightWay;

public GameObject LeftWay;

public bool GoingLeft;

public bool GoingRight;

public float BuildCount;

public FrontColliderCopScript m_FCCS;

public UnidadPolicialScript m_UPS;

public float m_rotationSpeed = 30;
//public List<Transform> m_PatrolPositions;
public float m_CurrentTime=0.0f;
//int m_CurrentPatrolPositionId=-1;
//float m_StartAlertRotation=0.0f;
//float m_CurrentAlertRotation=0.0f;
public GameController m_GameController;
//public float m_MinDistanceToAlert=5.0f;
public LayerMask m_CollisionLayerMask;
//public float m_MinDistanceToAttack=3.0f;
//public float m_MaxDistanceToAttack=7.0f;
//public float m_MaxDistanceToPatrol=15.0f;
//public float m_ConeAngle=60.0f;

public float EnemyLife = 40;
//public float m_LerpAttackRotation=0.6f;
//const float m_MaxLife=100.0f;
//float m_Life = m_MaxLife;

[Range(0.0f, 1.0f)]

//float maxDist = 20.0f;
//float minDist = 7.0f;

//public float dist;

//int value;

public Animator m_animator;

//public bool death;

//public float numOfShoots;


//public float DeathSpeed = -2;

//public float deatCount;



public float m_ShootAccuracy=0.3f;
	// Use this for initialization
	void Start () 
	{
		m_NavMeshAgent = GetComponent<NavMeshAgent>();
		//value = Random.Range(1, 13);
		m_animator = GetComponent<Animator>();
		SetWaitingState();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//dist = Vector3.Distance(transform.position, m_GameController.m_PlayerController.transform.position);
		switch(m_State)
		{
			case TState.WAITING:UpdateWaitingState();
			break;

			case TState.DIE: UpdateDieState();
			break;

			case TState.SHOOT: UpdateShootState();
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
		m_CurrentTime=0.0f;
		m_NavMeshAgent.isStopped=false;
		m_NavMeshAgent.SetDestination(Itaca.transform.position);
	}
	void SetShootState()
	{

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
		if(IAmTouchingTrash() == true)
		{
			NumBuilds();

			if(GoingLeft == true)
			{
				m_NavMeshAgent.SetDestination(LeftWay.transform.position);
			}
			if(GoingRight == true)
			{
				m_NavMeshAgent.SetDestination(RightWay.transform.position);
			}	
		}
		else 
		{
			m_NavMeshAgent.SetDestination(Itaca.transform.position);

			if(GoingLeft == true)
			{
				m_UPS.RealLeft = true;
			}
			if(GoingRight == true)
			{
				m_UPS.RealRight = true;
			}
		}
		if(Cop1 == true)
		{
			if(IhaveFoundTrash == true)
			{
				m_NavMeshAgent.isStopped = true;
			}
		}
		
	}
	void UpdateShootState()
	{

	}
	void UpdateDieState()
	{

	}

	public void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Trash1")
		{
			IhaveFoundTrash = true;	
		}
		if(other.tag == "Build")
		{
			if(GoingLeft == true)
			{
				BuildCount = BuildCount +1;
				GoingLeft = false;
				GoingRight = true;
				
			}
			else if (GoingRight == true)
			{
				GoingLeft = true;
				GoingRight = false;
				BuildCount = BuildCount +1;
				
			}	
		}
	}
	
	private void OnTriggerExit(Collider other) 
	{
		if(other.tag == "Trash1")
		{	
			IhaveFoundTrash = false;
		}
	}
	public void StopCop()
	{
		m_NavMeshAgent.isStopped=true;
		
	}
	public void ReDirect()
	{
		if(GoingLeft == true)
		{		
			GoingLeft = false;
			GoingRight = true;
		}
		else if (GoingRight == true)
		{
			GoingLeft = true;
			GoingRight = false;		
		}
	}

	public bool IAmTouchingTrash()
	{	
		
		if(Cop2 == true && m_FCCS.ColisionTrash == true)
		{
			return true;
		}
		if(Cop2 == true && m_FCCS.ColisionTrash == false)
		{
			return false;
		}
		else
		{
			return false;
		}
	}
	public void NumBuilds()
	{
		if(m_FCCS.ColisionBuild == true)
		{
			BuildCount = BuildCount +1;
			m_FCCS.ColisionBuild = false;
		}
	}

	public void GoFuckingCops()
	{
		
	}
	
}
