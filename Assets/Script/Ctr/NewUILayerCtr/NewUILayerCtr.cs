using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewUILayerCtr : MonoBehaviour {
     

    public Image M_image;
    public Sprite sprite;
	// Use this for initialization
	void Start () {

        string ImageUrl = Application.streamingAssetsPath+ "/NewUILayer.jpg";
       // Debug.Log(ImageUrl);

      StartCoroutine(  GetTexture(ImageUrl));

        DealWithUDPMessage.ToDefaultScene += Hide;
        DealWithUDPMessage.ToLogoWell += Hide;
        DealWithUDPMessage.ToIntro += Hide;
        DealWithUDPMessage.ToStrategy += Hide;
        DealWithUDPMessage.ToScreenProtect += Hide;
        DealWithUDPMessage.ToYeWuMoXing += Hide;
        DealWithUDPMessage.ToCo += Hide;
        DealWithUDPMessage.ToMatching += Hide;
        DealWithUDPMessage.ToChinaMap += Hide;
        DealWithUDPMessage.ToMainVideo += Hide;
        DealWithUDPMessage.ToNewScreenProtectLayer += Show;
    }

	
	// Update is called once per frame
	void Update () {
		
	}
    void Hide() {
        M_image.enabled = false;
    }

    void Show() {
        M_image.enabled = true;
    }

    IEnumerator GetTexture(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.isDone && www.error == null)
        {
            Texture2D img = www.texture;
            sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), new Vector2(0.5f, 0.5f));

            M_image.sprite = sprite;
        }
    }
}
