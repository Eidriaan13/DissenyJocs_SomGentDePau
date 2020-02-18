using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontColliderCopScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool ColisionBuild;

    public bool ColisionTrash;

    public bool ColisionCop;

    public bool Colision3Trash;

    

   

    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Build")
		{
		    ColisionBuild = true;
		}
        if(other.tag == "Trash1")
		{
		    ColisionTrash = true;
		}
        if(other.tag == "Trash2")
		{
		    Colision3Trash = true;
		}
         if(other.tag == "Cop")
		{
		    ColisionCop = true;
		}
        
    }
    public void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Build")
		{
		    ColisionBuild = false;
		}
        if(other.tag == "Trash1")
		{
		    ColisionTrash = false;
		}
         if(other.tag == "Trash2")
		{
		    Colision3Trash = false;
		}
        if(other.tag == "Cop")
		{
		    ColisionCop = true;
		}
        
    }


}
