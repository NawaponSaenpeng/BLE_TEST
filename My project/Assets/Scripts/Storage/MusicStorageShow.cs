using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MusicStorageShow : MonoBehaviour
{
    public MusicStorage buttonPrefab;
    public string path;
    public GameObject buttonParent;
    public StorageData getData;

    [Header("PopUp")]
    public TMP_Text itemName;
    public Image itemImg;
    public TMP_Text itemInfo;
    public GameObject previewPopup;

    void Start()
    {
        getData = Resources.Load<StorageData>(path);
        for (int i = 0; i < getData.storageData.Length; i++)
        {
            MusicStorage newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.name = $"Music{i}";
            newButton.items = getData.storageData[i];
            newButton.itemName = itemName;
            newButton.itemImg = itemImg;
            newButton.itemInfo = itemInfo;
            newButton.previewPopup = previewPopup;

            if (i == 0)
            {
                newButton.SetDataItem(getData.storageData[i]);

            }

        }
    }
}
