using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class FPCSupport : MonoBehaviour
{
    public GameObject playerCam;
    // effet de flou derriere
    private UnityStandardAssets.ImageEffects.Blur blur;

    public float pickupRange = 3.0f;
    private GameObject objectInteract;

    [Header("Buttons' List")]
    public string inventoryButton;
    public string interactButton;

    [Header("Tags' List")]
    public string itemTag = "Item";
    

    // variable qui permet d'accéder à l'inventaire
    [Header("Inventory's Datas")]
    public GameObject inventoryCanvas;
    [HideInInspector] public bool inventoryOn = false;
    public Transform  itemPrefab;
    public Transform inventorySlots;
    public int slotsCount = 10;

    // variables de l'ath
    [Header("ATH's Datas")]
    public GameObject ATHCanvas;
    public bool ATHOn = false;


    



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

         // si il trouve pas le canva ATH
        if(ATHCanvas == null)
        {
            ATHCanvas = GameObject.Find("ATH");
        }
        ATHCanvas.SetActive(false);
        

    }

    // Update is called once per frame
    void Update()
    {
        // si on presse 'i'
        if(Input.GetButtonDown(inventoryButton))
        {
            ShowOrHideInventory();
        }

        if(Input.GetButtonDown(interactButton))
        {
            TryToInteract();
        }

        if(ATHOn == true)
        {
            ShowATH();
        }
    }

    void TryToInteract()
    {
        Ray ray = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, pickupRange))
        {
            objectInteract = hit.collider.gameObject;

            if (objectInteract.tag == itemTag)
            {
                // pick up
                // chek if inventory is full
                if(inventorySlots.childCount == slotsCount)
                {
                    Debug.Log("inventory is full");
                }
                else
                {
                    // faire disparaitre l'item
                    objectInteract.SetActive(false);


                    // intégrer l'item dans l'inventaire
                    Transform newItem;
                    newItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity) as Transform;
                    newItem.SetParent(inventorySlots, false);

                    // transférer les données de l'item
                    ItemSlots itemInventory = newItem.GetComponent<ItemSlots>();
                    ItemVariables itemScene = objectInteract.GetComponent<ItemVariables>();
                    itemInventory.itemType = itemScene.itemType;
                    itemInventory.itemID = itemScene.itemID;
                    itemInventory.itemSprite = itemScene.itemSprite;
                    itemInventory.itemDescription = itemScene.itemDescription;

                    
                }

                
            }
        }

    }



    void ShowOrHideInventory()
    {
        inventoryCanvas.SetActive(!inventoryOn);
        blur.enabled = !inventoryOn;

        inventoryOn = !inventoryOn;
    }

    void ShowATH()
    {
        ATHCanvas.SetActive(true);

       
    }
}
