using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (RoadBending))]

public class RouadPath : Editor {
    RoadBending road;
    private void OnEnable()
    {
        road = (RoadBending)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
    }

    private void OnSceneGUI()
    {
        Vector3 []tmpPoints=new Vector3[road.positions.Length];
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        float offset = 0.5f;

        for (var i = 0; i < road.positions.Length; i++)
        {

            if (road.positions[i] == new Vector3(0, 0, 0))
            {
                road.positions[i] = new Vector3(i * offset, i * offset, 0);
            }

            road.positions[i]= Handles.PositionHandle(road.positions[i]+road.transform.position, Quaternion.identity)-road.transform.position;
            Handles.Label(road.positions[i] + road.transform.position, "Point:" + (i+1).ToString(), style);
            tmpPoints[i] = road.positions[i] + road.transform.position;
        }   
        Handles.DrawAAPolyLine(tmpPoints);
    }
}
