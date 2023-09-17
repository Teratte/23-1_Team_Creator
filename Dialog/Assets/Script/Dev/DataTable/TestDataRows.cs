using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDataRows : ScriptableObject
{
[System.Serializable]
    public class Row
    {
        public int id;
        public string name;
        public int age;
    }

    public Row[] rows;
}
