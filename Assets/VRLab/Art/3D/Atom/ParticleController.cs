using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI;

public class ParticleController : MonoBehaviour
{
    [SerializeField] public bool grabbed;
    [SerializeField] public string tagname;
    public void Grabbed()
    {
        grabbed = true;
        EnableGlow();
        SetTag();
    }
    public void Released()
    {
        grabbed = false;
        DisableGlow();
        UnsetTag();
    }

    public void EnableGlow()
    {
        GetComponent<Animator>().enabled = true;
    }
    public void DisableGlow()
    {
        GetComponent<Animator>().enabled = true;
    }
    public void SetTag()
    {
        GameObject tag = GameObject.Find("FollowingTag");
        tag.GetComponentInChildren<TMP_Text>().text = tagname;
        tag.transform.localScale = new Vector3(-0.0015f, 0.0015f, 0.0015f);
        tag.GetComponent<LazyFollow>().target = transform;
    }
    public void UnsetTag()
    {
        GameObject tag = GameObject.Find("FollowingTag");
        tag.transform.localScale = Vector3.zero;
    }
}
