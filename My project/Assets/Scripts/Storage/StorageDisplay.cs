using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class StorageDisplay : MonoBehaviour
{
    public static StorageDisplay instance;
    public ThemeButtonSkinInfo items;
    public static ThemeButtonSkinInfo get;
    public Image image;

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
    }

    public void SetDataItem(ThemeButtonSkinInfo getValue)
    {
        get = getValue;
        itemName.text = get.itemName;
        itemImg.gameObject.GetComponent<Image>().sprite = get.itemImg;
        itemInfo.text = get.itemDetail;
    }
}
