using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Test : MonoBehaviour
{
    [HideInInspector] public int _hp;  // ＿を付けると、pravateな変数という意味になる

    public TestPlayer player;

    public int Hp
    {
        get { return _hp; }
        set { this._hp = value; }
    }

    void Start()
    {
        Hp = 100;
        Debug.Log(_hp);
    }

    void Update()
    {

    }

    [Serializable]
    public class TestPlayer
    {
        public string name;
        public int hp;
    }
}
