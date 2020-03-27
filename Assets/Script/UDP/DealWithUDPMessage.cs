
//*********************❤*********************
// 
// 文件名（File Name）：	DealWithUDPMessage.cs
// 
// 作者（Author）：			LoveNeon
// 
// 创建时间（CreateTime）：	Don't Care
// 
// 说明（Description）：	接受到消息之后会传给我，然后我进行处理
// 
//*********************❤*********************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

public class DealWithUDPMessage : MonoBehaviour {
    public static Action ToDefaultScene;
    public static Action ToLogoWell;
    public static Action ToIntro;
    public static Action ToStrategy;
    public static Action ToScreenProtect;
    public static Action ToYeWuMoXing;
    public static Action ToCo;
    public static Action ToMatching;
    public static Action ToChinaMap;
    public static Action ToNewScreenProtectLayer;
    public static Action ToMainVideo;
    public static Action<string> PlayMainVideo;


    public static DealWithUDPMessage instance;
    // public GameObject wellMesh;
    private string dataTest;
    // public static char[] sliceStr;
    private Vector3 CamRotation;

    public string tempstr = "10000";

    private static bool isInDefaultScreen,isInLogoWell,isInIntro,isInStrategy,isInYeWuMoXing,isInCo,isInMatching,isInChinaMap,isInNewScreenProtectLayer;
    //private static bool isInScreenProtect=true;


    //public LogoWellCtr logoWellCtr;
    //private bool enterTrigger, exitTrigger;
    /// <summary>
    /// 消息处理
    /// </summary>
    /// <param name="_data"></param>
    public void MessageManage(string _data)
    {
        if (_data != "")
        {


            dataTest = _data;

            Debug.Log(dataTest);


            if (dataTest == "10000")
            {
                toScreenProtect();
            }
            else if (ValueSheet.NodeList_UDP_ID.ContainsKey(dataTest))
            {//项目介绍
                toDefaultScene();

                OverriderCameraMove.instance.Go(ValueSheet.NodeList_UDP_ID[dataTest], ValueSheet.ID_Node_keyValuePairs);

            }

            else if (int.Parse(dataTest) >= 10011 && int.Parse(dataTest) <= 10012)
            {//公司介绍
                toIntro();
                if (dataTest == "10011")
                {
                    OverriderCameraMove.instance.toIntro(0);
                }
                else if (dataTest == "10012")
                {
                    OverriderCameraMove.instance.toIntro(1);
                }
            }
            else if (dataTest == "10013")
            {
                toLogoWell();
            }
            else if (dataTest == "10014")
            {
                toYeWuMoXing();
            }

            else if (dataTest == "10015")
            {
                toCo();
            }
            else if (dataTest == "10016")
            {
                toMatching();
            }
            else if (int.Parse(dataTest) >= 10017 && int.Parse(dataTest) <= 10020)
            {//策略
                toStrategy();
                if (dataTest == "10017")
                {
                    OverriderCameraMove.instance.toStrategy(0);
                }
                else if (dataTest == "10018")
                {
                    OverriderCameraMove.instance.toStrategy(1);
                }
                else if (dataTest == "10019")
                {
                    OverriderCameraMove.instance.toStrategy(2);
                }
                else if (dataTest == "10020")
                {
                    OverriderCameraMove.instance.toStrategy(3);
                }
            }
            else if (dataTest == "10021")
            {
                toChinaMap();
            }

            else if (ValueSheet.udp_videoPathDic.ContainsKey(dataTest))
            {
                toMainVideo();
                playMainVideo(ValueSheet.udp_videoPathDic[dataTest]);
            }


            if (int.Parse(dataTest) < 10022)
            {
                tempstr = dataTest;
            }

            if (dataTest == "20001")
            {
                toNewScreenProtectLayer();
            }
        }
    }



    private void Awake()
    {

    }

    public IEnumerator Initialization() {
        if (instance == null)
        {
            instance = this;
        }
        yield return new  WaitForSeconds(0.01f);
    }

    public void Start()
    {

    }


    private void Update()
    {


        //Debug.Log("数据：" + dataTest);  
    }

    public static void toDefaultScene() {
        if (!isInDefaultScreen) {
            Debug.Log("去项目集锦");
            ToDefaultScene?.Invoke();
           // isInDefaultScreen = true;
            isInLogoWell = isInIntro = isInStrategy /*= isInScreenProtect*/ = isInYeWuMoXing= isInCo = isInMatching = isInChinaMap= isInNewScreenProtectLayer = false;
        }
    }

    public static void toLogoWell()
    {
        if (!isInLogoWell)
        {
            ToLogoWell?.Invoke();
            isInLogoWell = true;
            isInDefaultScreen = isInIntro = isInStrategy /*= isInScreenProtect*/= isInYeWuMoXing= isInCo = isInMatching = isInChinaMap= isInNewScreenProtectLayer = false;
        }
    }

    public static void toIntro()
    {
        if (!isInIntro)
        {
            ToIntro?.Invoke();
            isInIntro = true;
            isInDefaultScreen = isInLogoWell = isInStrategy /*= isInScreenProtect*/ = isInYeWuMoXing= isInCo = isInMatching = isInChinaMap = isInNewScreenProtectLayer = false;
        }
    }
    public static void toStrategy()
    {
        if (!isInStrategy)
        {
            ToStrategy?.Invoke();
            isInStrategy = true;
            isInDefaultScreen = isInLogoWell = isInIntro /*= isInScreenProtect*/ = isInYeWuMoXing= isInCo = isInMatching = isInChinaMap = isInNewScreenProtectLayer = false;
        }
    }
    public static void toScreenProtect()
    {
        //if (!isInScreenProtect) {
            ToScreenProtect?.Invoke();
            //isInScreenProtect = true;
            isInDefaultScreen = isInLogoWell = isInIntro = isInStrategy = isInYeWuMoXing= isInCo = isInMatching = isInChinaMap= isInNewScreenProtectLayer = false;
        //}
    }

    public static void toYeWuMoXing()
    {
        if (!isInYeWuMoXing)
        {
            ToYeWuMoXing?.Invoke();
            isInYeWuMoXing = true;
            isInDefaultScreen = isInLogoWell = isInIntro = isInStrategy /*= isInScreenProtect */= isInCo= isInMatching = isInChinaMap = isInNewScreenProtectLayer = false;
        }
    }

    public static void toCo()
    {
        if (!isInCo)
        {
            ToCo?.Invoke();
            isInCo = true;
            isInDefaultScreen = isInLogoWell = isInIntro = isInStrategy /*= isInScreenProtect*/= isInYeWuMoXing = isInMatching = isInChinaMap = isInNewScreenProtectLayer = false;
        }
    }

    public static void toMatching() {
        if (!isInMatching)
        {
            ToMatching?.Invoke();
            isInMatching = true;
            isInDefaultScreen = isInLogoWell = isInIntro = isInStrategy /*= isInScreenProtect */= isInYeWuMoXing = isInCo = isInChinaMap = isInNewScreenProtectLayer = false;
        }
    }

    public static void toChinaMap() {
        if (!isInChinaMap) {
            ToChinaMap?.Invoke();
            isInChinaMap = true;
            isInDefaultScreen = isInLogoWell = isInIntro = isInStrategy/* = isInScreenProtect*/ = isInYeWuMoXing = isInCo = isInMatching= isInNewScreenProtectLayer = false;
        }
    }

    public static void toNewScreenProtectLayer() {
        if (!isInNewScreenProtectLayer)
        {
            ToNewScreenProtectLayer?.Invoke();
            isInNewScreenProtectLayer = true;
            isInDefaultScreen = isInLogoWell = isInIntro = isInStrategy/* = isInScreenProtect*/ = isInYeWuMoXing = isInCo = isInMatching  = false;
        }
    }

    public static void toMainVideo()
    {

            ToMainVideo?.Invoke();

        isInChinaMap = isInDefaultScreen = isInLogoWell = isInIntro = isInStrategy/* = isInScreenProtect */= isInYeWuMoXing = isInCo = isInMatching= isInNewScreenProtectLayer = false;

    }

    public static void playMainVideo(string str = " ") {
        PlayMainVideo?.Invoke(str);
    }

}
