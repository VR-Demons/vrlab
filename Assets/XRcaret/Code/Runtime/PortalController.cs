using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PortalController : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            OnTrigger.Invoke();
    }
}
