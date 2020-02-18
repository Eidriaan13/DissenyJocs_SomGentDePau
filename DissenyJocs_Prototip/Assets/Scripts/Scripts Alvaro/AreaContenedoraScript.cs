using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaContenedoraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float HowManyTrashIHave;

    public Vector3 TrashSide;

    public GameObject Shield1;

    public bool HaveCreateTheshield;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HaveCreateTheshield == false)
        {
            Instantiate(Shield1, TrashSide, Quaternion.identity);
            HaveCreateTheshield = true;
        }

       
    }

    public void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Trash")
        {
            HowManyTrashIHave += 1;

            //TrashSide = other.gameObject.transform.position;
        }
    }
    public void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Trash")
		{
		    HowManyTrashIHave += 1;
		}
    
        
    }
}
