using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] UnityEvent OnComplete;
    [SerializeField] VideoPlayer player;
    [SerializeField] public float Delay { get; set; }
    private void Start()
    {
        player.loopPointReached += EndReached;
    }
    void EndReached(VideoPlayer vp)
    {
        OnComplete.Invoke();
    }

    private void OnEnable()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(Delay);
        OnComplete.Invoke();
    }
}
