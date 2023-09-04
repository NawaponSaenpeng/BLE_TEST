using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MusicButton : MonoBehaviour
{
    public static MusicButton instance;
    public GetValue musicData;
    public static GetValue get;
    public TMP_Text songName;
    public Image image;
    public Outline outline;
   



    void Start()
    {   
        instance = this;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate () { SetDataMusic(musicData); });
        image.gameObject.GetComponent<Image>().sprite = musicData.image;
        songName.text = musicData.songName.ToString();
    }

    public void SetDataMusic(GetValue getValue)
    {   
        get = getValue;

    }



}
