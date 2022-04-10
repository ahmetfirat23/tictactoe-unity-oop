using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: SerializeField]
    public string Name { get; private set; }
    [field: SerializeField]
    //0=o,1=x
    public int Sign { get; private set; }
    public List<int> Table { get; private set; }

    private void Start()
    {
        Table = new List<int>();
    }

    public void MakeMove(Square square)
    {   
        int move = square.Index;
        Table.Add(move);
        Table.Sort();
    }
}
