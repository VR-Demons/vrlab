using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideAtomGenerator : MonoBehaviour
{
    [SerializeField] GameObject prfElectron;
    [SerializeField] GameObject prfLines;

    [SerializeField] int rows;
    [SerializeField] float spacing;

    [SerializeField] bool vlines;

    [SerializeField] bool vibration;
    [SerializeField] float movement;
    [SerializeField] float frecuency;

    /// <summary>
    /// Private
    /// </summary>
    List<GameObject> electrons; 
    List<Vector3> positions;
    float counter;

    void Start()
    {
        counter = frecuency;

        electrons = new List<GameObject>();
        positions = new List<Vector3>();
        for (int i=-rows; i<rows;++i)
        {
            for (int j = -rows; j < rows; ++j)
            {
                for (int k = -rows; k < rows; ++k)
                {
                    GameObject a= Instantiate(prfElectron, gameObject.transform);
                    a.transform.localPosition = new Vector3(k, i, j) * spacing;

                    electrons.Add(a);
                    positions.Add(new Vector3(k, i, j) * spacing);

                    if (i == 0 && vlines)
                    {
                        GameObject lprefi = Instantiate(prfLines, gameObject.transform);
                        LineRenderer lni = lprefi.GetComponent<LineRenderer>();
                        lni.SetPositions(new Vector3[] { new Vector3(k, -rows, j) * spacing, new Vector3(k, rows, j) * spacing });
                    }
                }
                GameObject lprefk = Instantiate(prfLines, gameObject.transform);
                LineRenderer lnk = lprefk.GetComponent<LineRenderer>();
                lnk.SetPositions(new Vector3[] { new Vector3(i, j, -rows) * spacing, new Vector3(i, j, rows) * spacing });

                GameObject lprefj = Instantiate(prfLines, gameObject.transform);
                LineRenderer lnj = lprefj.GetComponent<LineRenderer>();
                lnj.SetPositions(new Vector3[] { new Vector3(-rows, j, i) * spacing, new Vector3(rows, j, i) * spacing });
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vibration==false) return;
        if (counter > 0) { counter -= Time.deltaTime; return; }

        for (int i = 0;i<electrons.Count;i++)
        {
            electrons[i].transform.position = positions[i] + Random.Range(0, movement) *Vector3.one;
        }

        counter = frecuency;
    }
}
