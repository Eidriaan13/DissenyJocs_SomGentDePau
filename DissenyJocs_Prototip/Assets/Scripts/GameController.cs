using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
    public GameObject police;

    public GameObject policeSpawn_1;
    public GameObject policeSpawn_2;
    public GameObject policeSpawn_3;
    public GameObject policeSpawn_4;
    GameObject[] policeSpawn;

    public GameObject megamapCanvas;
    public GameObject caosCanvas;

    public int actualRound = 1;
    private bool startNewRound = false;

    public float caosCounter;
    public float maxCaosCounter;



    // Start is called before the first frame update
    void Start()
    {
        policeSpawn = new GameObject[4] { policeSpawn_1, policeSpawn_2, policeSpawn_3, policeSpawn_4 };
        int rnd = Random.Range(0, policeSpawn.Length);
        Instantiate(police,policeSpawn[rnd].transform.position,policeSpawn[rnd].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (caosCounter >= maxCaosCounter)
        {
            FinishRound();
        }
    }

    public void StartRound()
    {
        
        megamapCanvas.SetActive(false);
        caosCanvas.SetActive(true);

    }
    public void FinishRound()
    {
        caosCounter = 0;
        actualRound++;
        megamapCanvas.SetActive(true);
        caosCanvas.SetActive(false);
        int rnd = Random.Range(0, policeSpawn.Length);
        GameObject[] polices = GameObject.FindGameObjectsWithTag("police");
        for (int i = 0; i < polices.Length; i++)
        {
            Destroy(polices[i]);
        }
        for (int i = 0; i <= actualRound; i++)
        {
            Instantiate(police, policeSpawn[rnd].transform.position, policeSpawn[rnd].transform.rotation);
        }

    }
    public void IncrementCaos()
    {
        caosCounter += 10;
    }
}
