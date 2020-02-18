using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasController : MonoBehaviour
{
    public Canvas minimapCanvas;
    public Canvas megamapCanvas;
    public Canvas shopCanvas;
    public Canvas inventoryCanvas;
    public Canvas roundsCanvas;


    // Start is called before the first frame update
    void Start()
    {
        megamapCanvas.gameObject.SetActive(false);
        shopCanvas.gameObject.SetActive(false);
        minimapCanvas.gameObject.SetActive(true);
        inventoryCanvas.gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateMegamap()
    {
        megamapCanvas.gameObject.SetActive(true);
        minimapCanvas.gameObject.SetActive(false);
    }
    public void DesactivateMegamap()
    {
        megamapCanvas.gameObject.SetActive(false);
        minimapCanvas.gameObject.SetActive(true);
    }
    public void ActivateShopCanvas()
    {
        shopCanvas.gameObject.SetActive(true);
    }
    public void DesactivateShopCanvas()
    {
        shopCanvas.gameObject.SetActive(false);
    }


}
