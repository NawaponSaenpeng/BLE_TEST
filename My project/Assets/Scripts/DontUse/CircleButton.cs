using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleButton : MonoBehaviour
{   
    [SerializeField] GameObject obj;
    public Transform scale;
    bool click;
    // Start is called before the first frame update
    void Start()
    { 
      click = false;  
    }

    // Update is called once per frame
    void Update()
    {
        if (click == true) {
            obj.transform.localScale = new Vector3(1.67f, 1.67f, 1.67f);
        }
    }

    void OnMouseDown() {
        // Debug.Log(obj.transform.localScale);
        if (obj.transform.localScale.x > 1.74 && obj.transform.localScale.y > 1.74 && obj.transform.localScale.z > 1.74) {
            obj.SetActive(false);
        }
    
    
        if (obj.transform.localScale.x > 2.2 && obj.transform.localScale.y > 2.2 && obj.transform.localScale.z > 2.2) {
            Debug.Log("Bad");
        } else if ((obj.transform.localScale.x > 1.81 && obj.transform.localScale.y > 1.81 && obj.transform.localScale.z > 1.81)
         || (obj.transform.localScale.x > 1.67 && obj.transform.localScale.y > 1.67 && obj.transform.localScale.z > 1.67)) {
            Debug.Log("Good");
        } else if (obj.transform.localScale.x > 1.74 && obj.transform.localScale.y > 1.74 && obj.transform.localScale.z > 1.74) {
            Debug.Log("Perfect");
        } else {
            Debug.Log("Bad");
        }
        click = true;
    }
    
    void OnMouseUp() {
        obj.SetActive(true);
        click = false;
    }
}
