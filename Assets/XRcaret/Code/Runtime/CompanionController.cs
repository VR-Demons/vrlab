using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleController : MonoBehaviour
{
    [SerializeField] private AudioSource voice;
    [SerializeField] private Animator animator;
    private void Update()
    {
        animator.SetBool("Talking", voice.isPlaying);
    }
}
