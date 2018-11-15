﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoAnimCtr : ICtr {
    Animator animator;
	// Use this for initialization
	public override void initialization() {
        base.initialization();
        animator = this.GetComponent<Animator>();
    }

    public override void HideAll(float time = 1)
    {
        animator.SetBool("Show", false);
    }

    public override void ShowAll(float time = 1)
    {
        animator.SetBool("Show", true);
    }
}