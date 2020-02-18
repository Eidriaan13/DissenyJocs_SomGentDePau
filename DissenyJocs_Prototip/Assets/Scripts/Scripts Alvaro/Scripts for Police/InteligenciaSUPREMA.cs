
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteligenciaSUPREMA : MonoBehaviour {

	public interface IAmAFuckingCop
    {
        //void RestartGame();
    }

public class PoliceInteligent : MonoBehaviour
{
    List<IAmAFuckingCop> m_RestartGameElements=new List<IAmAFuckingCop>();
	
	void RestartGame()
    {
        foreach(IAmAFuckingCop l_RestartGameElement in m_RestartGameElements)
        {
            
        }
            //l_RestartGameElement.RestartGame();
    }
    public void AddRestartGameElement(IAmAFuckingCop RestartGameElement)
    {
        
        m_RestartGameElements.Add(RestartGameElement);
    }
}

}

