using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;
using static UnityEngine.EventSystems.EventTrigger;

public class AppleController : MonoBehaviour
{
    [SerializeField] GameObject prfApple;
    [SerializeField] int count;
    [SerializeField] float radius;
    [SerializeField] float minheight;
    [SerializeField] float maxheight;
    [SerializeField] UnityEvent onGrab;

    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            float r = Random.Range(0, radius);
            float theta = Random.Range(0, 2 * Mathf.PI);
            Vector3 pos = new Vector3();
            pos.x = r * Mathf.Cos(theta);
            pos.z = r * Mathf.Sin(theta);
            pos.y = minheight + Random.Range(0, maxheight - minheight);

            GameObject a = Instantiate(prfApple, gameObject.transform);
            a.transform.localPosition = pos;

            Rigidbody rb = a.GetComponent<Rigidbody>();
            rb.AddRelativeTorque(new Vector3(Random.Range(0, 0.5f), Random.Range(0, 0.5f), Random.Range(0, 0.5f)), ForceMode.VelocityChange);
            rb.AddRelativeForce(new Vector3(Random.Range(0, 0.01f), Random.Range(0, 0.01f), Random.Range(0, 0.01f)), ForceMode.VelocityChange);

            a.GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnSelectEntered);
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs arg0)
    {
        onGrab.Invoke();
    }
}
