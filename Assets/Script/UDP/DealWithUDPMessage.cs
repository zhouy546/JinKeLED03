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

    public static DealWithUDPMessage instance;
    // public GameObject wellMesh;
    private string dataTest;
    // public static char[] sliceStr;
    private Vector3 CamRotation;

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
        ToDefaultScene?.Invoke();
    }

    public static void toLogoWell()
    {
        ToLogoWell?.Invoke();
    }

    public static void toIntro()
    {
        ToIntro?.Invoke();
    }
    public static void toStrategy()
    {
        ToStrategy?.Invoke();
    }
    public static void toScreenProtect()
    {
        ToScreenProtect?.Invoke();
    }

}
