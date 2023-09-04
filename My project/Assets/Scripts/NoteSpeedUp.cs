using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpeedUp : MonoBehaviour
{
    private float beatTempo;
    // Start is called before the first frame update
    public void setSpeed(float beatSpeed)
    {
        
        beatTempo = beatSpeed / 60f;
    }

    // Update is called once per frame
    void Update()
    {
     
        transform.position += new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        
    }
}
