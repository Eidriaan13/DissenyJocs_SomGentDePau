using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivaOrdos : MonoBehaviour
{
    public bool atack;
     public KeyCode m_ActivateOrdasButton = KeyCode.E;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(m_ActivateOrdasButton))
        {
            atack = true;
        }
    }
}
