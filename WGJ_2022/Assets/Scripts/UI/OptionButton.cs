using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    public Accessory accessory;
    public GameObject accessoryObj;
    public GameObject accessoryObjBack;
    public SelectionController selectionController;
    [SerializeField]
    private Accessory grisHeadBand;


    public void SelectAccessory()
    {
        if (selectionController.activeCat.isSmaller && accessory.type == AccessoryType.Headband)
            accessory = grisHeadBand;
        if(accessory.type == AccessoryType.DuctTape)
        {
            selectionController.catObject.GetComponent<Image>().sprite = selectionController.activeCat.earlessSprite;
            accessoryObj.SetActive(false);
            accessoryObjBack.SetActive(false);
            return;
        }
        selectionController.catObject.GetComponent<Image>().sprite = selectionController.activeCat.neutralSprite;
        accessoryObj.GetComponent<Image>().sprite = accessory.objectSprite;
        if (accessory.hasBack)
        {
            accessoryObjBack.GetComponent<Image>().sprite = accessory.backSprite;
            accessoryObjBack.SetActive(true);
        }
        else
            accessoryObjBack.SetActive(false);
        accessoryObj.SetActive(true);

        selectionController.selectedAccessory = accessory.type;
        
    }
}
