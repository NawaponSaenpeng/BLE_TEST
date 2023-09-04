using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseToBeat : MonoBehaviour
{
    [SerializeField] bool useTestBeat;
    [SerializeField] float pulseSize = 1.15f;
    [SerializeField] float returnSpeed = 5f;
    private Vector3 startsize;

    void Start()
    {
        startsize = transform.localScale;
        if (useTestBeat) {
            StartCoroutine(TestBeat());
        }
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, startsize, Time.deltaTime * returnSpeed);
    }

    public void Pulse() {
        transform.localScale = startsize * pulseSize;
    }

    IEnumerator TestBeat() {
        while (true) {
            yield return new WaitForSeconds(1f);
            Pulse();
        }
    }
}
