using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashLEFTSide : MonoBehaviour
{
    // Start is called before the first frame update
     public bool ContactBuild;
    public bool ContactTrash;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Trash")
		{
		    ContactTrash = true;
		}
        if(other.tag == "Build")
		{
		    ContactBuild = true;
		}
    }
    public void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Trash")
		{
		    ContactTrash = false;
		}
        if(other.tag == "Build")
		{
		    ContactBuild = false;
		}
    }
}
