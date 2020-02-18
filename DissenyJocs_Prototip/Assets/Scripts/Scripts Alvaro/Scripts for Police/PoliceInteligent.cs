using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IAmAFuckingCop
{
    //void RestartGame();
    void HayUnHueco(Vector3 PayaNOPaya);
    void StopNow();
}

public class PoliceInteligent : MonoBehaviour {
        
    List<IAmAFuckingCop> m_StupidCopsList = new List<IAmAFuckingCop>();   
    public SmartCop m_SC; 

    public void Start()
    {
        //SetLives();
    }

    private void Update() 
    {
       if(m_SC.Agujeraco == true)
       {
           
            foreach (IAmAFuckingCop l_RestartGameElement in m_StupidCopsList)
            {
                l_RestartGameElement.HayUnHueco(m_SC.AquiEstaElHueco);
            }
       }
       if(m_SC.StopTRASH == true)
       {
           Debug.Log("Funcionaka");
           foreach (IAmAFuckingCop l_RestartGameElement in m_StupidCopsList)
            {
                l_RestartGameElement.StopNow();
            }
       }
        
            
    }

    public void RestartGame()
    {    
        foreach (IAmAFuckingCop l_RestartGameElement in m_StupidCopsList)
        {
            //l_RestartGameElement.RestartGame();
        }
       

    }
    public void AddAStupidCop(IAmAFuckingCop OneStupidCop)
    {
        m_StupidCopsList.Add(OneStupidCop);
    }
    

    

    
}