using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class RadialBackHand : MonoBehaviour
{
    [SerializeField] InputActionAsset map;
    [SerializeField] InputActionReference trigger;
    [SerializeField] Image filler;
    [SerializeField] float fill = 0;
    [SerializeField] UnityEvent OnComplete;
    private void Start()
    {
        map.Enable();
    }
    private void Update()
    {
        if(trigger.action.phase== InputActionPhase.Performed)
        {
            fill += Time.deltaTime/3f;
            if(fill>=1)
            {
                fill = 0;
                OnComplete.Invoke();
            }
            filler.fillAmount = fill;
        }
        else
        {
            fill = 0;
            filler.fillAmount = fill;
        }
    }
}
