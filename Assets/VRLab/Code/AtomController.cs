using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class AtomController : MonoBehaviour
{
    [SerializeField] int atomicnumber;
    [SerializeField] GameObject neutron;
    [SerializeField] GameObject proton;
    [SerializeField] GameObject electron;
    [SerializeField] List<GameObject> neutrons;
    [SerializeField] List<GameObject> protons;
    [SerializeField] List<GameObject> electrons;

    [SerializeField] GameObject tag;
    private void Start()
    {
        for (int i = 0; i < atomicnumber; i++)
        {
            Vector3 tmp = new Vector3 (0, 0, 0);
            GameObject n = Instantiate(neutron, gameObject.transform);
            neutrons.Add (n);
            tmp = RandomVector3();
            tmp.Normalize ();
            tmp *= Random.Range(0f, 0.2f);
            n.transform.localPosition = tmp;

            GameObject p = Instantiate(proton, gameObject.transform);
            protons.Add(p);
            tmp = RandomVector3();
            tmp.Normalize();
            tmp *= Random.Range(0f, 0.2f);
            p.transform.localPosition = tmp;

            GameObject e = Instantiate(electron, gameObject.transform);
            electrons.Add(e);
            tmp = RandomVector3();
            tmp.Normalize();
            tmp *= 0.5f;
            e.transform.localPosition = tmp;
        }
    }
    private void Update()
    {
        foreach (var e in neutrons) 
        {
            if (e.GetComponent<ParticleController>().grabbed) break;
            Vector3 tmp = e.transform.localPosition + 0.005f * RandomVector3();
            tmp.Normalize();
            tmp *= 0.1f;
            e.transform.localPosition = tmp;
        }
        foreach (var e in protons)
        {
            if (e.GetComponent<ParticleController>().grabbed) break;
            Vector3 tmp = e.transform.localPosition + 0.005f * RandomVector3();
            tmp.Normalize();
            tmp *= 0.1f;
            e.transform.localPosition = tmp;
        }
        foreach (var e in electrons)
        {
            if (e.GetComponent<ParticleController>().grabbed) break;
            Vector3 tmp = e.transform.localPosition + 0.001f * RandomVector3();
            tmp.Normalize();
            tmp *= 0.5f;
            e.transform.localPosition = tmp;
        }
    }
    private Vector3 RandomVector3()
    {
        return new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f));
    }
    public void RandomGlow()
    {
        electrons[Random.Range(0, electrons.Count)].GetComponent<ParticleController>().EnableGlow();
    }
}
