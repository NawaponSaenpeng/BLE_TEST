using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float bpm;
    [SerializeField] AudioSource audioSource;
    [SerializeField] private Intervals intervals;


    private void Update() {
            float sampledTime = (audioSource.timeSamples / (audioSource.clip.frequency * intervals.GetIntervalLength(bpm)));
            intervals.CheckForNewInterval(sampledTime);
    }

[System.Serializable]
public class Intervals {
    [SerializeField] private float steps;
    [SerializeField] private UnityEvent trigger;
    private int lastInterval;

    public float GetIntervalLength(float bpm) {
        return 60f / (bpm * steps);
    }

    public void CheckForNewInterval (float interval) {
        if (Mathf.FloorToInt(interval) != lastInterval) {
            lastInterval = Mathf.FloorToInt(interval);
            trigger.Invoke();
        }
    }
}

}
