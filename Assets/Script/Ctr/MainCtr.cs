using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCtr : ICtr {
    public List<ICtr> ctrs = new List<ICtr>();


	// Use this for initialization
	void Start () {
		
	}

    public override void initialization()
    {
        base.initialization();
        foreach (var item in ctrs)
        {
            item.initialization();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
