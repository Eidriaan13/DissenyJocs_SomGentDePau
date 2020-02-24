using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasuraScript : MonoBehaviour
{
    // Start is called before the first frame update

        public TrashLEFTSide m_TLeftS;
        public TrashRIGHTSide m_TRightS;

        public bool ContactOnLeft;
        public bool ContactOnRight;
        public GameObject Shield1;
        public bool PutShield1;

         public GameObject Shield2;
        public bool PutShield2;
        public GameObject Shield3;
        public bool PutShield3;

        public bool Shield3IsONFIRE;

        
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        //////////////ES LA BORSA DEL MIG////////////
        if(m_TLeftS.ContactTrash == true && m_TRightS.ContactTrash == true)
        {
            Shield3IsONFIRE = true;

            if(PutShield3 == false)
            {
                Instantiate(Shield3, this.transform.position, this.transform.rotation);
                PutShield3 = true;
            }  
        }
        ////////////////TOCA AMB UN PER UN DELS DOS COSTATS////////////////
        if(m_TRightS.ContactTrash == true && m_TLeftS.ContactBuild == false && Shield3IsONFIRE == false)
        {
            if(PutShield2 == false)
            {
                Instantiate(Shield2, m_TRightS.transform.position, m_TRightS.transform.rotation);
                PutShield2 = true;
            }   
        }
        if(m_TLeftS.ContactTrash == true && m_TRightS.ContactBuild == false && Shield3IsONFIRE == false)
        {
            if(PutShield2 == false)
            {
                Instantiate(Shield2, m_TLeftS.transform.position, m_TLeftS.transform.rotation);
                PutShield2 = true;
            }  
        }
        //////////NO TOCA AMB NINGU////////////
        if(m_TRightS.ContactTrash == false && m_TLeftS.ContactTrash == false)
        {
            if(PutShield1 == false)
            {       
                Instantiate(Shield1, this.transform.position,Quaternion.identity);
                PutShield1 = true;
            }
        }   
    }   
}
