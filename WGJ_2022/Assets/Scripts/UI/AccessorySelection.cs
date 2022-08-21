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
    }

    public void ChangeOptionsUp()
    {
        if(_index >= accessories.Count - 3)
            _index = 0;
        else
            _index += 3;

        options[0].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = accessories[_index].sprite;
        options[1].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = accessories[_index + 1].sprite;
        options[2].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = accessories[_index + 2].sprite;
    }

    public void ChangeOptionsDown()
    {
        if (_index == 0)
            _index = accessories.Count - 3;
        else
            _index -= 3;

        options[0].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = accessories[_index].sprite;
        options[1].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = accessories[_index + 1].sprite;
        options[2].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = accessories[_index + 2].sprite;
    }
}
