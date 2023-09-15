using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestDataRows.Row a = DataTableManager.Instance().GetTestData(1);
        Debug.Log(a.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
