﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverriderCameraMove : MonoBehaviour {
    public static OverriderCameraMove instance;

    public int PerviousID;
    public int TargetID;


    public void initializtion(Vector3 defaultpos, Vector3 _targetPos)
    {
        if (instance == null)
        {
            instance = this;
        }

        PerviousID = TargetID = ValueSheet.NodeList.Count - 1;

    }


    public void OnEnable()
    {
        DealWithUDPMessage.ToScreenProtect += toScreeanProtect;
    }

    public void OnDisable()
    {
        DealWithUDPMessage.ToScreenProtect -= toScreeanProtect;
    }


    private void toScreeanProtect() {
        RotateTo(Vector3.zero);
        MoveTo(new Vector3(0, 15.3f, -30), 1f);
    } 

    public void Go(int ID, Dictionary<int, GameObject> ID_Node_keyValuePairs)
    {
        LeanTween.cancel(this.gameObject);



        StartCoroutine(MoveToTarget(getRotue(ID, ID_Node_keyValuePairs), .5f, ID));

    }

    IEnumerator MoveToTarget(List<RotueNode> rotueNodes, float timeEachSetp, int id)
    {
        TargetID = id;
       // SoundMangager.instance.GoThrough();
      //  CanvasMangager.instance.HideCurretTitle();
        // Debug.Log(rotueNodes.Count+ "rotueNodes 数量");
      //  BottomBarCtr.instance.UpdateBottomBar(id + 1, ReadJson.NodeList.Count);
        for (int i = 0; i < rotueNodes.Count; i++)
        {

            if (i == rotueNodes.Count - 1)//going in 
            {
                DefaultNodesCtr.hideMainPic();
                DefaultNodesCtr.ShowDescription(id);
                yield return new WaitForSeconds(.5f);
              //  SoundMangager.instance.GoThrough();
                MoveTo(rotueNodes[i].pos, timeEachSetp, () => updatePerviousID(id));
                RotateTo(rotueNodes[i].rotationAngle, timeEachSetp);

                //CanvasMangager.instance.UpdateTitle(titleNum, CanvasMangager.instance.MainTitle);//show title
            }
            else
            {
                DefaultNodesCtr.showMainPic();
                MoveTo(rotueNodes[i].pos, timeEachSetp, () => updatePerviousID(id));
                RotateTo(rotueNodes[i].rotationAngle, timeEachSetp);
            }


            yield return new WaitForSeconds(timeEachSetp);
        }
    }

    public void updatePerviousID(int id)
    {
        if (PerviousID - id < 0)
        {
            PerviousID++;
        }
        else if (PerviousID - id > 0)
        {
            PerviousID--;
        }
    }

    List<RotueNode> getRotue(int id, Dictionary<int, GameObject> ID_Node_keyValuePairs)
    {

        List<Vector3> rot = new List<Vector3>();
        rot = GetStep(id);
        // Debug.Log(rot.Count);
        List<RotueNode> rotue = new List<RotueNode>();


        for (int i = 0; i < rot.Count; i++)
        {
            if (i == rot.Count - 1)
            {

                rotue.Add(new RotueNode(rot[i], ID_Node_keyValuePairs[id].GetComponent<NodeCtr>().cameraSetTrans.localRotation.eulerAngles));

            }
            else
            {
                rotue.Add(new RotueNode(rot[i], Vector3.zero));
            }
        }



        return rotue;
    }

    List<Vector3> GetStep(int id)
    {
        List<Vector3> pos = new List<Vector3>();

        int step = Mathf.Abs(PerviousID - id);

        if (PerviousID - id < 0)//从小到大走，向前
        {
            for (int i = 0; i <= step; i++)
            {
                pos.Add(new Vector3(0, 15.3f, -30 + (PerviousID + i) * ValueSheet.NodeDistance));
            }
        }
        else if (PerviousID - id > 0)//从大到小走，向后
        {
            for (int i = 0; i <= step; i++)
            {
                pos.Add(new Vector3(0, 15.3f, -30 + (PerviousID - i) * ValueSheet.NodeDistance));
            }
        }
        else if (PerviousID - id == 0)
        {//没走

        }

        pos.Add(ValueSheet.ID_Node_keyValuePairs[id].GetComponent<NodeCtr>().cameraSetTrans.position);

        foreach (var item in pos)
        {
            //   Debug.Log(item);

        }


        return pos;
    }

    public void MoveTo(Vector3 pos, float time, Action action = null)
    {
        //  stopCameraFloating();
        //Debug.Log("Move TO POS"+pos.ToString());
        LeanTween.move(this.gameObject, pos, time).setOnUpdate(delegate (Vector3 v) {

        }).setOnComplete(delegate () {
            if (action != null)
            {
                action();
            }
        }).setEase(LeanTweenType.notUsed);
    }

    public void RotateTo(Vector3 angle, float time = .5f)
    {
        LeanTween.rotateY(this.gameObject, angle.y, time).setEase(LeanTweenType.notUsed);
    }
}

public class RotueNode
{
    public Vector3 pos;
    public Vector3 rotationAngle;
    public RotueNode parent;

    public RotueNode()
    {

    }



    public RotueNode(Vector3 pos, Vector3 rotationAngle)
    {
        this.pos = pos;
        this.rotationAngle = rotationAngle;
    }

    public RotueNode(Vector3 pos, RotueNode parent)
    {
        this.pos = pos;
        this.parent = parent;
    }
}
