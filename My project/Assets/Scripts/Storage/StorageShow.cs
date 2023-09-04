using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class StorageShow : MonoBehaviour
{
    public static StorageShow instance;
    public StorageDisplay buttonPrefab;
    public string path;
    public GameObject buttonParent;
    public ThemeData getData;
    public int itemCount;

    [Header("PopUp")]
    public TMP_Text itemName;
    public Image itemImg;
    public TMP_Text itemInfo;
    public GameObject previewPopup;
    
  
    void Start()
    {
        instance = this;
        getData = Resources.Load<ThemeData>(path);
        itemCount = getData.skinData.Count;
        if (itemCount == getData.skinData.Count)
        {
            for (int i = 0; i < getData.skinData.Count; i++)
            {
                StorageDisplay newButton = Instantiate(buttonPrefab, buttonParent.transform);
                newButton.name = $"Music{i}";
                newButton.items = getData.skinData[i];
                newButton.itemName = itemName;
                newButton.itemImg = itemImg;
                newButton.itemInfo = itemInfo;
                newButton.previewPopup = previewPopup;

                if (i == 0)
                {
                    newButton.SetDataItem(getData.skinData[i]);

                }


            }
        } else
        {
            CheckSkin(path);
        }
        
    }

    public void CheckSkin(string path)
    {
        getData = Resources.Load<ThemeData>(path);
        DestroyObject(buttonParent);
            for (int i = 0; i < getData.skinData.Count; i++)
            {
                StorageDisplay newButton = Instantiate(buttonPrefab, buttonParent.transform);
                newButton.name = $"Music{i}";
                newButton.items = getData.skinData[i];
                newButton.itemName = itemName;
                newButton.itemImg = itemImg;
                newButton.itemInfo = itemInfo;
                newButton.previewPopup = previewPopup;

                if (i == 0)
                {
                    newButton.SetDataItem(getData.skinData[i]);

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
