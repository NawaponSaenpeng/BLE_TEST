using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeShow : MonoBehaviour
{
    public static ThemeShow instance;
    [Header("Button Skin Item")]
    public ButtonSkinDisplay itemPrefab;

    public string path;
    public GameObject buttonParent;
    public ThemeData getData;
    public GameObject popUpBuy;
    int currentItem;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        getData = Resources.Load<ThemeData>(path);
        currentItem = getData.skinData.Count;
        CheckSkin();
    }

    public void CheckSkin()
    {   
            DestroyObject(buttonParent);
            if (getData.skinData.Count != 0)
            {
                for (int i = 0; i < getData.skinData.Count; i++)
                {
                    ButtonSkinDisplay newButton = Instantiate(itemPrefab, buttonParent.transform);
                    newButton.name = $"Item{i}";
                    newButton.info = getData.skinData[i];
                    newButton.popUpBuy = popUpBuy;
                }
            }
        
        
    }

    public void DestroyObject(GameObject gameObject)
    {
        
        for (var i = gameObject.transform.childCount - 1; i >= 0; i--)
        {
                Destroy(gameObject.transform.GetChild(i).gameObject);
        }
    }

}
