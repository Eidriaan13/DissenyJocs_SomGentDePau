using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaosController : MonoBehaviour
{
    public GameController gameController;

    public Text actualRoundsText;
    public Image caosCounter;

    // Start is called before the first frame update
    void Start()
    {
        actualRoundsText.text = "ACTUAL ROUND: " + gameController.actualRound.ToString();
        caosCounter.rectTransform.localScale = new Vector3(gameController.caosCounter / gameController.maxCaosCounter,1,1);
    }

    // Update is called once per frame
    void Update()
    {
        actualRoundsText.text = "ACTUAL ROUND: " + gameController.actualRound.ToString();
        caosCounter.rectTransform.localScale = new Vector3(gameController.caosCounter / gameController.maxCaosCounter, 1, 1);
    }
}
