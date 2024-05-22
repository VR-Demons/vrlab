using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortalWindow : MonoBehaviour
{
    [SerializeField] string tag;
    [SerializeField] UnityEvent OnEnter;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag==tag)
            OnEnter.Invoke();
    }
}
