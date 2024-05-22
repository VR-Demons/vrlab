using Microsoft.MixedReality.Toolkit.Experimental.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardUnityEvents : MonoBehaviour
{
    [SerializeField] NonNativeKeyboard keyboard;
    [SerializeField] UnityEvent<string> OnSend;
    private void Start()
    {
        keyboard.OnTextSubmitted += OnTextSubmitted;
    }

    private void OnTextSubmitted(object sender, System.EventArgs e)
    {
        if(keyboard.InputField.text.Length==0)
        {
            keyboard.PresentKeyboard();
            return;
        }
        OnSend.Invoke(keyboard.InputField.text);
    }
}
