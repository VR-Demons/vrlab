using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] public bool grabbed;
    public void Grabbed()
    {
        grabbed = true;
        EnableGlow();
    }
    public void Released()
    {
        grabbed = false;
        DisableGlow();
    }

    public void EnableGlow()
    {
        GetComponent<Animator>().enabled = true;
    }
    public void DisableGlow()
    {
        GetComponent<Animator>().enabled = true;
    }
}
