using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUI : MonoBehaviour {
    public GameObject[] parent;

    public GameObject NodeL_Default;
    public GameObject NodeR_Default;

    public GameObject SunNode_Intro;
    public GameObject SunNode_Strategy;


    // Use this for initialization
    public void Initialization() {
        CreateDefaultNode();

    }



    private void CreateDefaultNode() {
        for (int j = 0; j < ValueSheet.NodeList.Count; j++)
        {
            if (j % 2 == 0)
            {
                Vector3 pos = new Vector3(-20, 16.3f, j * ValueSheet.NodeDistance);
                CreateObject<NodeCtr>(NodeL_Default, j, pos,  parent[0], ValueSheet.nodeCtrs);
            }
            else
            {
                Vector3 pos = new Vector3(20, 16.3f, j * ValueSheet.NodeDistance);
                CreateObject<NodeCtr>(NodeR_Default, j, pos,  parent[0], ValueSheet.nodeCtrs);
            }
            ValueSheet.ID_Node_keyValuePairs.Add(ValueSheet.NodeList[j].ID, ValueSheet.nodeCtrs[j].gameObject);
        }
    }

    private void CreateObject<t>(GameObject g, int i, Vector3 pos, GameObject parent, List<t> nodeCtr)
    {

        GameObject MgameObject = Instantiate(g);

        MgameObject.name = i.ToString();

        nodeCtr.Add(MgameObject.GetComponent<t>());

        MgameObject.transform.SetParent(parent.transform);

        MgameObject.transform.position = pos;

        MgameObject.transform.rotation = Quaternion.identity;

    }
}
