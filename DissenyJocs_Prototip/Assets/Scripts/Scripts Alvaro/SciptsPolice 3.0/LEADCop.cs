using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class LEADCop : MonoBehaviour
{
    GameObject BasicCopObject;
    public GameObject[] CopsInMyPower;
    public string CopTag;
    public string ItacaTag;
    NavMeshAgent m_NavMeshAgent;
    public enum TState
    {
		INITIAL,
		MOVETOCENTER,
		THINKING		
    }
    public TState m_State;
    //public FrontColliderCopScript m_FCCS;
    
    public ActivaOrdos m_AOs;

    public string TargetTag;
   
    public GameObject Target;

    public float WichWay;

    public bool TheresWay;

    public float Timer;
    public float TimerforForming;

    public GameObject FRONT;
    public GameObject FRONTR;
    public GameObject FRONTL;
    public GameObject RIGHT;
    public GameObject LEFT;
    public GameObject CENTER;







    // Start is called before the first frame update
    void Start()
    {
        CopsInMyPower = GameObject.FindGameObjectsWithTag(CopTag);           
        m_NavMeshAgent = GetComponent<NavMeshAgent>();     
        m_State = TState.INITIAL;
    }

    // Update is called once per frame
    void Update()
    {
       switch(m_State)
		{
			case TState.INITIAL:UpdateINITIALState();
			break;

			case TState.MOVETOCENTER: UpdateMOVING_TO_CENTERState();
			break;

			case TState.THINKING: UpateTHINKINGState();
			break;	
		}	
        
    }
    void SetINITIALState()
    {
        m_State = TState.INITIAL;
        m_NavMeshAgent.isStopped = true;
        TargetTag = null;
        Target = null;

    }
    void UpdateINITIALState()
    {
        //Debug.Log(IsEveryoneInSide());

        if(m_AOs.atack == true && IsEveryoneInSide() == true)
        {     
            foreach(GameObject Cop in CopsInMyPower)
            {
                Cop.GetComponent<BASICCop>().SetMOVING_TO_CENTERState();  
            }  
            SetMOVING_TO_CENTERState();
        }   
        else
        {
            Stop();
            foreach(GameObject Cop in CopsInMyPower)
            {
                Cop.GetComponent<BASICCop>().Stop();        
            }
            GoToYourSide();
        }  
        //Debug.Log(IsEveryoneInSide());
    }
    void SetMOVING_TO_CENTERState()
    {
        m_State = TState.MOVETOCENTER;
        m_NavMeshAgent.isStopped=false;
        GameObject newItaca;
        newItaca = GameObject.FindGameObjectWithTag(ItacaTag);
        m_NavMeshAgent.SetDestination(newItaca.transform.position);
        Timer = 0;
        
    }
    void UpdateMOVING_TO_CENTERState()
    {
        if(SomeoneHaveFoundTrash() == true)
        {
            foreach(GameObject Cop in CopsInMyPower)
            {
                Cop.GetComponent<BASICCop>().Stop();
            }
            SetTHINKINGState();
        }
        if(SomeoneHaveFoundSuperTrash() == true)
        {
            foreach(GameObject Cop in CopsInMyPower)
            {
                Cop.GetComponent<BASICCop>().Stop();     
            }
            Stop();
        }

        //TimerforForming = TimerforForming +1 *Time.deltaTime;
        if(IsEveryoneInSide() == false)
        {
            Stop();
            foreach(GameObject Cop in CopsInMyPower)
            {
                Cop.GetComponent<BASICCop>().Stop();        
            }

            SetINITIALState();
        }

    }
    void SetTHINKINGState()
    {
        m_NavMeshAgent.isStopped=true;
        m_State = TState.THINKING;
       
    }

    public void StopCops()
    {
        foreach(GameObject Cop in CopsInMyPower)
        {
            Cop.GetComponent<BASICCop>().Stop(); 
            Stop();
        }
        
    }
    void UpateTHINKINGState()
    {
        
        if(SomeoneHaveFoundTrash() == true && TheresWay == false)
        {
           //FindTheWaySecondFunction(WichWay);
            WichWay = FindTheWay(FindTheSideTag());
            //Debug.Log(WichWay);
            foreach(GameObject Cop in CopsInMyPower)
            {
                if(FindTheSideTag() == "NO Hay CAMINO")
                {
                    Cop.GetComponent<BASICCop>().Stop();
                }
                else
                {
                    Cop.GetComponent<BASICCop>().GoToTarget(ConvertTagToVector3(FindTheSideTag()));
                }
                
            }
            
            TheresWay = true;  

        }
        if(TheresWay == true)
        {
            Timer += 1*Time.deltaTime;  
        }
        
        /*
        if(TheresWay == true)
        {
            GoToWay(WichWay); 
            
            
        }
        
        if(AreYouInTheWay(WichWay) == true)
        {
            Debug.Log(AreYouInTheWay(WichWay));
            foreach(GameObject Cop in CopsInMyPower)
            {
                //Cop.GetComponent<BASICCop>().SetMOVING_TO_CENTERState();
            }
            //SetMOVING_TO_CENTERState();     
        }
        */
        if(Timer >= 5)
        {
            foreach(GameObject Cop in CopsInMyPower)
            {
                Cop.GetComponent<BASICCop>().SetMOVING_TO_CENTERState();
            }
            //SetMOVING_TO_CENTERState(); 
            GameObject newItaca;
            newItaca = GameObject.FindGameObjectWithTag(ItacaTag);   
            GoToTarget(newItaca.transform.position);
            TheresWay = false;
            Invoke("SetMOVING_TO_CENTERState", 4);
        }
        
    }

    public bool IsEveryoneInSide()
    {
        bool result = true; 

        foreach(GameObject Cop in CopsInMyPower)
        {
            if(Cop.GetComponent<BASICCop>().IAmOnSide() == false)
            {
                result = false;
                
            }
        }
        
        return result;
    }
    public void GoToYourSide()
    {
        if(IsEveryoneInSide()==false)
        {
            foreach(GameObject Cop in CopsInMyPower)
            {
                Cop.GetComponent<BASICCop>().GoToYourFormationSide(); 
            }
        }
        else
        {
            foreach(GameObject Cop in CopsInMyPower)
            {
                Cop.GetComponent<BASICCop>().Stop();  
            }     
        }
    }
    public bool AreYouInTheWay(float numWay)
    {
        bool result = false; 
        if(numWay == 1)
        {
            foreach(GameObject Cop in CopsInMyPower)
        {
            if(Cop.GetComponent<BASICCop>().IAmOnTarget("FRONTR") == true)
            {
                result = true;
            }
        }
        }
        else if(numWay == 0)
        {
            foreach(GameObject Cop in CopsInMyPower)
        {
            if(Cop.GetComponent<BASICCop>().IAmOnTarget("FRONT") == true)
            {
                result = true;
            }
        }
        }
        else if(numWay == -1)
        {
            foreach(GameObject Cop in CopsInMyPower)
        {
            if(Cop.GetComponent<BASICCop>().IAmOnTarget("FRONTL") == true)
            {
                result = true;
            }
        }
        }
        
        
        return result;
    }

    public bool SomeoneHaveFoundTrash()
    {
        bool result = false; 

        foreach(GameObject Cop in CopsInMyPower)
        {
            if(Cop.GetComponent<BASICCop>().IHaveFoundTrash() == true)
            {        
                
                result = true;    
            }   
        } 
        
        return result;
        
    }
    public bool SomeoneHaveFoundSuperTrash()
    {
        bool result = false; 

        foreach(GameObject Cop in CopsInMyPower)
        {
            if(Cop.GetComponent<BASICCop>().IHaveFoundSuperTrash() == true)
            {        
                
                result = true;    
            }   
        } 
        
        return result;
        
    }
    public bool SomeoneHaveNotFoundTrash()
    {
        bool result = false; 

        foreach(GameObject Cop in CopsInMyPower)
        {
            if(Cop.GetComponent<BASICCop>().IHaveFoundTrash() == false)
            {
                result = true;
            }
        }
        

        return result;
    }
    public float FindTheWay(string TargetTag)
    {
        
        if(TargetTag == "FRONTL")
        {
            Debug.Log("Esquerra");
            return -1;
          
        }
        else if(TargetTag == "FRONTR")
        {
            Debug.Log("Dreta");
            return 1;
           
        }
        else if(TargetTag == "FRONT")
        {
            Debug.Log("Centre");
            return 0;
           
        }
        return 4;
   
    }

    public void  GoToWay(float WichWayis)
    {
        if(WichWayis == 1)
        {
            foreach(GameObject Cop in CopsInMyPower)
            {
                //if(Cop.GetComponent<BASICCop>().IHaveFoundTrash() == true)
                //{   
                    Cop.GetComponent<BASICCop>().GoToTarget(FRONTR.transform.position);
                //}
            }
        }
        else if(WichWayis == -1)
        {
            foreach(GameObject Cop in CopsInMyPower)
            {
                //if(Cop.GetComponent<BASICCop>().IHaveFoundTrash() == true)
                //{   
                    //Debug.Log("PALANCE");
                    Cop.GetComponent<BASICCop>().GoToTarget(FRONTL.transform.position);
                //}
            }
        }
        else if(WichWayis == 0)
        {
            foreach(GameObject Cop in CopsInMyPower)
            {
                //if(Cop.GetComponent<BASICCop>().IHaveFoundTrash() == true)
                //{   
                    Cop.GetComponent<BASICCop>().GoToTarget(FRONT.transform.position);
                //}
            }
        }
    }
    public void GoToTarget(Vector3 Target)
    {
        m_NavMeshAgent.isStopped=false;
		m_NavMeshAgent.SetDestination(Target);
    }
    public void Stop()
    {
        m_NavMeshAgent.isStopped=true;
    }
    public string FindTheSideTag()
    {
        foreach(GameObject Cop in CopsInMyPower)
        {
            
            if( Cop.GetComponent<BASICCop>().IHaveFoundTrash() == false)
            {
                return Cop.GetComponent<BASICCop>().SideTag;

            }            
        }
        return "NO Hay CAMINO";

    }
    public Vector3 ConvertTagToVector3(string tag)
    {
        GameObject target;
        target = GameObject.FindGameObjectWithTag(tag);
        return target.transform.position;

    }
    

    
}
