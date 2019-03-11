using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class FPCSupport : MonoBehaviour
{
    public GameObject playerCam;
    // effet de flou derriere
    private UnityStandardAssets.ImageEffects.Blur blur;

    [Header("Buttons' List")]
    public string inventoryButton;
    

    // variable qui permet d'accéder à l'inventaire
    [Header("Inventory's Datas")]
    public GameObject inventoryCanvas;
    [HideInInspector] public bool inventoryOn = false;




    // Start is called before the first frame update
    void Start()
    {
        // si il trouve pas la camera du joueur
        if(playerCam == null)
        {
             playerCam = GameObject.FindWithTag("MainCamera");
        }
        blur = playerCam.GetComponent<UnityStandardAssets.ImageEffects.Blur>();
        blur.enabled = false;

         // si il trouve pas la canvas de l'inventaire
        if(inventoryCanvas == null)
        {
            inventoryCanvas = GameObject.Find("Inventory Panel");
        }
        inventoryCanvas.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        // si on presse 'i'
        if(Input.GetButtonDown(inventoryButton))
        {
            ShowOrHideInventory();
        }
    }

    void ShowOrHideInventory()
    {
        inventoryCanvas.SetActive(!inventoryOn);
        blur.enabled = !inventoryOn;

        inventoryOn = !inventoryOn;
    }
}
