using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UICard : MonoBehaviour
{
    [SerializeField] UnityEvent uevent;
    [SerializeField] float delay = 0;
    [SerializeField] bool autostart = false;
    public void TriggerEvent()
    {
        uevent.Invoke();
    }
    private void OnEnable()
    {
        if (autostart)
            StartCoroutine(TriggerEventDelayed());
    }
    public IEnumerator TriggerEventDelayed()
    {
        yield return new WaitForSeconds(delay);
        uevent.Invoke();
    }
}
