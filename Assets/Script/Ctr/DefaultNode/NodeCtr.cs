using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCtr : ICtr {
    public Transform cameraSetTrans;
    public List<ICtr> ctrs = new List<ICtr>();
    public string ID;

    public void Start()
    {
        initialization();
    }

    // Use this for initialization
    public override void initialization() {
        base.initialization();
        ID = gameObject.name;
        foreach (var item in ctrs)
        {
            item.initialization();
        }
      
           
	}

    private void OnEnable()
    {
        DealWithUDPMessage.ToDefaultScene += showMainImage;
        DealWithUDPMessage.ToLogoWell += HideAllImage;
        DealWithUDPMessage.ToScreenProtect += HideAllImage;
        DealWithUDPMessage.ToIntro += HideAllImage;
        DealWithUDPMessage.ToStrategy += HideAllImage;



    }

    private void OnDisable()
    {
        DealWithUDPMessage.ToDefaultScene -= showMainImage;
        DealWithUDPMessage.ToLogoWell -= HideAllImage;
        DealWithUDPMessage.ToScreenProtect -= HideAllImage;
        DealWithUDPMessage.ToIntro -= HideAllImage;
        DealWithUDPMessage.ToStrategy -= HideAllImage;
    }


    void Update () {

	}

    private void showMainImage() {
        ShowOne(ctrs[0]);
    }

    private void HideAllImage() {
        HideAll();
    }

    public override void HideAll(float time = 1)
    {
        foreach (var item in ctrs)
        {
            item.HideAll();
        }
    }

    public override void ShowAll(float time = 1)
    {
        foreach (var item in ctrs)
        {
            item.ShowAll();
        }
    }

    public override void ShowOne(ICtr ctr)
    {
        for (int i = 0; i < ctrs.Count; i++)
        {
            if (i == ctrs.IndexOf(ctr))
            {
                ctrs[i].ShowAll();
            }
            else {
                ctrs[i].HideAll();
            }
        }
        
    }

}
