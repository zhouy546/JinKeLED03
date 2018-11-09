﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueSheet : MonoBehaviour {
    public static string screenProtect = "屏幕保护.mp4";

    public static string CultureAndECON = "商业·文化.mp4";

    public static string ProjcetHighLight = "浚县沙盘.mp4";

    public static string Gongyi = "社会公益.mp4";

    public static string Co = "合作伙伴.mp4";

    public static float BGMVolume = 0;



    public static float NodeDistance = 30f;

    public static Dictionary<int, GameObject> ID_Node_keyValuePairs = new Dictionary<int, GameObject>();
    public static Dictionary<int, GameObject> ID_ECO_Node_keyValuePairs = new Dictionary<int, GameObject>();
    public static Dictionary<int, GameObject> ID_Gongyi_Node_keyValuePairs = new Dictionary<int, GameObject>();

    public static Dictionary<int, List<Sprite>> DescriptionkeyValuePairs = new Dictionary<int, List<Sprite>>();
    public static Dictionary<string, AudioClip> NameAudio_keyValuePairs = new Dictionary<string, AudioClip>();

    public static List<Sprite> MainUIsprites = new List<Sprite>();

    public static List<Sprite> IntroUIsprites = new List<Sprite>();

    public static List<Sprite> YeWuMoXingUIsprites = new List<Sprite>();

    public static List<Sprite> CoNodeUIsprites = new List<Sprite>();

    public static List<Sprite> MatchingUIsprites = new List<Sprite>();

    public static List<Node> NodeList = new List<Node>();

    public static List<Node> Intro_NodeList = new List<Node>();

    public static List<Node> strategy_NodeList = new List<Node>();





    public static List<NodeCtr> nodeCtrs = new List<NodeCtr>();

    public static List<IntroNodeCtr> introNodeCtr = new List<IntroNodeCtr>();

    public static List<YeWuMoXingNodeCtr> yeWuMoXingNodeCtr = new List<YeWuMoXingNodeCtr>();

    public static List<CoNodeCtr> coNodeCtr = new List<CoNodeCtr>();

    public static List<MatchingNodeCtr> matchingNodeCtr = new List<MatchingNodeCtr>();

    public static List<NodeCtr_Strategy> NodeCtr_Strategy = new List<NodeCtr_Strategy>();
 

    public static List<NodeCtr> CurrentNodeCtr = new List<NodeCtr>();
    public static bool IsInMainMenu = true;




}
