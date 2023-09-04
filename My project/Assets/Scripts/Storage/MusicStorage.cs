using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MusicStorage : MonoBehaviour
{
    public static MusicStorage instance;
    public StorageItems items;
    public static StorageItems get;
    public Image image;
    public TMP_Text songName;

    [Header("PopUp")]
    public TMP_Text itemName;
    public Image itemImg;
    public TMP_Text itemInfo;
    public GameObject previewPopup;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate () { SetDataItem(items); });
        image.gameObject.GetComponent<Image>().sprite = items.itemImg;
        songName.text = items.itemName.ToString();
    }

    public void SetDataItem(StorageItems getValue)
    {
        get = getValue;
        itemName.text = get.itemName;
        itemImg.gameObject.GetComponent<Image>().sprite = get.itemImg;
        itemInfo.text = get.itemData;
    }
}
