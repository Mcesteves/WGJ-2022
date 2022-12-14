using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccessorySelection : MonoBehaviour
{
    public List<Accessory> accessories;
    public List<GameObject> options;

    private int _index;

    void Start()
    {
        _index = 0;
        options[0].GetComponent<OptionButton>().accessory = accessories[_index];
        options[1].GetComponent<OptionButton>().accessory = accessories[_index + 1];
        options[2].GetComponent<OptionButton>().accessory = accessories[_index + 2];
    }

    public void ChangeOptionsUp()
    {
        if(_index >= accessories.Count - 3)
            _index = 0;
        else
            _index += 3;

        ChangeSprite(_index);
    }

    public void ChangeOptionsDown()
    {
        if (_index == 0)
            _index = accessories.Count - 3;
        else
            _index -= 3;

        ChangeSprite(_index);  
    }

    public void ChangeSprite(int index)
    {
        options[0].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = accessories[index].sprite;
        options[0].GetComponent<OptionButton>().accessory = accessories[index];
        options[1].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = accessories[index + 1].sprite;
        options[1].GetComponent<OptionButton>().accessory = accessories[index + 1];
        options[2].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = accessories[index + 2].sprite;
        options[2].GetComponent<OptionButton>().accessory = accessories[index + 2];
    }
}
