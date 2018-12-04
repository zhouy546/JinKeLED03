using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenProtectCtr : ICtr {
    public static ScreenProtectCtr instance;
    public List<ICtr> ctrs = new List<ICtr>();
    public Transform CameratransformPos;
	// Use this for initialization
	public override void initialization() {
        base.initialization();
        foreach (ICtr ctr in ctrs)
        {
            float time =Random.Range(0.5f, 5f);
            ctr.initialization();
           StartCoroutine( ctr.TriggerFloating(time));
            
        }

        if (instance == null) {
            instance = this;
        }
	}

    private void OnEnable()
    {
        DealWithUDPMessage.ToScreenProtect += show;
        DealWithUDPMessage.ToDefaultScene += hide;
        DealWithUDPMessage.ToLogoWell += hide;
        DealWithUDPMessage.ToIntro += hide;
        DealWithUDPMessage.ToStrategy += hide;
        DealWithUDPMessage.ToYeWuMoXing += hide;
        DealWithUDPMessage.ToCo += hide;
        DealWithUDPMessage.ToMatching += hide;
        DealWithUDPMessage.ToChinaMap += hide;
       // DealWithUDPMessage.ToMainVideo += hide;

        DefaultNodesCtr.HideMainPic += hide;
        DefaultNodesCtr.ShowMainPic += hide;
    }

    private void OnDisable()
    {
        DealWithUDPMessage.ToScreenProtect -= show;
        DealWithUDPMessage.ToDefaultScene -= hide;
        DealWithUDPMessage.ToLogoWell -= hide;
        DealWithUDPMessage.ToIntro -= hide;
        DealWithUDPMessage.ToStrategy -= hide;
        DealWithUDPMessage.ToYeWuMoXing -= hide;
        DealWithUDPMessage.ToCo -= hide;
        DealWithUDPMessage.ToMatching -= hide;
        DealWithUDPMessage.ToChinaMap -= hide;
      //  DealWithUDPMessage.ToMainVideo -= hide;

        DefaultNodesCtr.HideMainPic -= hide;
        DefaultNodesCtr.ShowMainPic -= hide;
    }

    private void show() {
        ShowAll();
    }

    private void hide() {
        HideAll();
    }

    public override void ShowAll(float time = 1)
    {
        foreach (ICtr ctr in ctrs)
        {
            ctr.ShowAll();
        }
    }

    public override void HideAll(float time = 1)
    {
        foreach (ICtr ctr in ctrs)
        {
            ctr.HideAll();
        }
    }
}
