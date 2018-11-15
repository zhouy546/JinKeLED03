using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainVideoNodeCtr : ICtr {
    public MediaPlayer medialPlayer;
    public Animator animator;


    public override void initialization()
    {
        base.initialization();
    }


    private void OnEnable()
    {
        DealWithUDPMessage.ToIntro += hide;
        DealWithUDPMessage.ToDefaultScene += hide;
        DealWithUDPMessage.ToLogoWell += hide;
        DealWithUDPMessage.ToScreenProtect += hide;
        DealWithUDPMessage.ToStrategy += hide;

        DealWithUDPMessage.ToYeWuMoXing += hide;
        DealWithUDPMessage.ToCo += hide;
        DealWithUDPMessage.ToMatching += hide;
        DealWithUDPMessage.ToChinaMap += hide;
        DealWithUDPMessage.ToMainVideo += show;

        //DefaultNodesCtr.HideMainPic += hide;
        //DefaultNodesCtr.ShowMainPic += hide;
    }

    private void OnDisable()
    {
        DealWithUDPMessage.ToIntro -= hide;
        DealWithUDPMessage.ToDefaultScene -= hide;
        DealWithUDPMessage.ToLogoWell -= hide;
        DealWithUDPMessage.ToScreenProtect -= hide;
        DealWithUDPMessage.ToStrategy -= hide;

        DealWithUDPMessage.ToYeWuMoXing -= hide;
        DealWithUDPMessage.ToCo -= hide;
        DealWithUDPMessage.ToMatching -= hide;
        DealWithUDPMessage.ToChinaMap -= hide;
        DealWithUDPMessage.ToMainVideo -= show;

        //DefaultNodesCtr.HideMainPic -= hide;
        //DefaultNodesCtr.ShowMainPic -= hide;
    }

    public void CheckIsFinish() {
        Debug.Log("finished");
        hide();
    }




    public override void PlayVideo(string str)
    {
        medialPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, str, true);
    }

    public override void StopVideo()
    {
        medialPlayer.Stop();
    }

    public void show()
    {

        ShowAll();
    }

    public void hide()
    {
        HideAll();
        SoundMangager.instance.PlayBGM();
    }

    public override void HideAll(float time = 1)
    {
        animator.SetBool("Show", false);
        StopVideo();

    }

    public override void ShowAll(float time = 1)
    {
        animator.SetBool("Show", true);

        PlayVideo(ValueSheet.MainVideoUrl);
    }

}
