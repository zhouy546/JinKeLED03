using System;
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
