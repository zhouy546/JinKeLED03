
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


    public static DealWithUDPMessage instance;
    // public GameObject wellMesh;
    private string dataTest;
    // public static char[] sliceStr;
    private Vector3 CamRotation;

    private static bool isInDefaultScreen,isInLogoWell,isInIntro,isInStrategy,isInYeWuMoXing,isInCo,isInMatching;
    private static bool isInScreenProtect=true;


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
            else if (int.Parse(dataTest) >= 10001 && int.Parse(dataTest) <= 10007)
            {//项目介绍
                toDefaultScene();
                if (dataTest == "10001")
                {
                    OverriderCameraMove.instance.Go(0, ValueSheet.ID_Node_keyValuePairs);
                }
                else if (dataTest == "10002")
                {
                    OverriderCameraMove.instance.Go(1, ValueSheet.ID_Node_keyValuePairs);

                }
                else if (dataTest == "10003")
                {
                    OverriderCameraMove.instance.Go(2, ValueSheet.ID_Node_keyValuePairs);

                }
                else if (dataTest == "10004")
                {
                    OverriderCameraMove.instance.Go(3, ValueSheet.ID_Node_keyValuePairs);

                }
                else if (dataTest == "10005")
                {
                    OverriderCameraMove.instance.Go(4, ValueSheet.ID_Node_keyValuePairs);

                }
                else if (dataTest == "10006")
                {
                    OverriderCameraMove.instance.Go(5, ValueSheet.ID_Node_keyValuePairs);

                }
                else if (dataTest == "10007")
                {
                    OverriderCameraMove.instance.Go(6, ValueSheet.ID_Node_keyValuePairs);

                }
            }

            else if (int.Parse(dataTest) >= 10008 && int.Parse(dataTest) <= 10009)
            {//公司介绍
                toIntro();
                if (dataTest == "10008")
                {
                    OverriderCameraMove.instance.toIntro(0);
                }
                else if (dataTest == "10009")
                {
                    OverriderCameraMove.instance.toIntro(1);
                }
            }
            else if (dataTest == "10010")
            {
                toLogoWell();
            }
            else if (dataTest == "10011")
            {
                toYeWuMoXing();
            }

            else if (dataTest == "10012")
            {
                toCo();
            }
            else if (dataTest == "10013") {
                toMatching();
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
            isInDefaultScreen = true;
            isInLogoWell = isInIntro = isInStrategy = isInScreenProtect = isInYeWuMoXing= isInCo = isInMatching = false;
        }
    }

    public static void toLogoWell()
    {
        if (!isInLogoWell)
        {
            ToLogoWell?.Invoke();
            isInLogoWell = true;
            isInDefaultScreen = isInIntro = isInStrategy = isInScreenProtect= isInYeWuMoXing= isInCo = isInMatching = false;
        }
    }

    public static void toIntro()
    {
        if (!isInIntro)
        {
            ToIntro?.Invoke();
            isInIntro = true;
            isInDefaultScreen = isInLogoWell = isInStrategy = isInScreenProtect = isInYeWuMoXing= isInCo = isInMatching = false;
        }
    }
    public static void toStrategy()
    {
        if (!isInStrategy)
        {
            ToStrategy?.Invoke();
            isInStrategy = true;
            isInDefaultScreen = isInLogoWell = isInIntro = isInScreenProtect = isInYeWuMoXing= isInCo = isInMatching = false;
        }
    }
    public static void toScreenProtect()
    {
        if (!isInScreenProtect) {
            ToScreenProtect?.Invoke();
            isInScreenProtect = true;
            isInDefaultScreen = isInLogoWell = isInIntro = isInStrategy = isInYeWuMoXing= isInCo = isInMatching = false;
        }
    }

    public static void toYeWuMoXing()
    {
        if (!isInYeWuMoXing)
        {
            ToYeWuMoXing?.Invoke();
            isInYeWuMoXing = true;
            isInDefaultScreen = isInLogoWell = isInIntro = isInStrategy = isInScreenProtect = isInCo= isInMatching = false;
        }
    }

    public static void toCo()
    {
        if (!isInCo)
        {
            ToCo?.Invoke();
            isInCo = true;
            isInDefaultScreen = isInLogoWell = isInIntro = isInStrategy = isInScreenProtect= isInYeWuMoXing = isInMatching = false;
        }
    }

    public static void toMatching() {
        if (!isInMatching)
        {
            ToMatching?.Invoke();
            isInMatching = true;
            isInDefaultScreen = isInLogoWell = isInIntro = isInStrategy = isInScreenProtect = isInYeWuMoXing = isInCo = false;
        }
    }

}
