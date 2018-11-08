using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCtr_Intro : ICtr {
    public Transform cameraSetTrans;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void HideAll(float time = 1)
    {
        base.HideAll(time);
    }

    public override void ShowAll(float time = 1)
    {
        base.ShowAll(time);
    }
}
