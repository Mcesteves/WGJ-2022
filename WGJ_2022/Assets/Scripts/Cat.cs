using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cat", menuName = "Cat", order = 0)]
public class Cat : ScriptableObject
{
    public string catName;
    public Sprite happySprite;
    public Sprite neutralSprite;
    public Sprite sadSprite;
    public Sprite earlessSprite;
    public bool isSmaller;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
