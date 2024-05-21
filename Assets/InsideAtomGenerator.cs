using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideAtomGenerator : MonoBehaviour
{
    [SerializeField] GameObject prfElectron;
    [SerializeField] GameObject prfLines;

    [SerializeField] int rows;
    [SerializeField] float spacing;

    void Start()
    {
        for (int i=-rows; i<rows;++i)
        {
            for (int j = -rows; j < rows; ++j)
            {
                for (int k = -rows; k < rows; ++k)
                {
                    GameObject a= Instantiate(prfElectron, gameObject.transform);
                    a.transform.localPosition = new Vector3(k, i, j) * spacing;

                    if (i == 0)
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
        
    }
}
