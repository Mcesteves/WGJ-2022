using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionController : MonoBehaviour
{
    // Start is called before the first frame update

    public Cat activeCat;
    public Situation activeSituation;
    public GameObject catObject;

    public List<Cat> cats;
    public List<Situation> situations;
    [HideInInspector]public AccessoryType selectedAccessory;

    void Start()
    {
        SortCat();
        SortSituation();
        catObject.GetComponent<Image>().sprite = activeCat.neutralSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SortCat()
    {
        int option = Random.Range(0, cats.Count);
        activeCat = cats[option];
    }

    public void SortSituation()
    {
        int option = Random.Range(0, situations.Count);
        activeSituation = situations[option];
    }
}
