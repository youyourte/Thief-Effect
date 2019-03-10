using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPCsupport : MonoBehaviour
{
    public GameObject PlayerCam;

    // effet de flou derriere
    private UnityStandardAssets.ImageEffects.Blur blur;

    [Header("Button list")]
    public string InventoryButton;
    

    public GameObject InventoryCanvas;
 
    private bool inventoryOn = false;




    // Start is called before the first frame update
    void Start()
    {
        // si il trouve pas la camera du joueur
        if(PlayerCam == null)
        {
             PlayerCam = GameObject.FindwithTag("Main Camera");
        }
        blur = PlayerCam.GetComponent<UnityStandardAssets.ImageEffects.Blur>();
        blur.enabled = false;

         // si il trouve pas la canvas de l'inventaire
        if(InventoryCanvas == null)
        {
            InventoryCanvas = GameObject.Find("Inventory Panel");
        }
        InventoryCanvas.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        // si on presse 'i'
        if(Input.GetButtonDown(InventoryButton))
        {
            ShowOrHideInventory();
        }
    }

    void ShowOrHideInventory()
    {
        InventoryCanvas.SetActive(!inventoryOn);
        blur.enabled = !inventoryOn;

        inventoryOn = !inventoryOn;
    }
}
