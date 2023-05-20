using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsArray : MonoBehaviour
{

    public static ArrayList points;

    private void Awake() {

        points = new ArrayList();

        for (int i = 0; i < transform.childCount; i++)
            points.Add(transform.GetChild(i));

    }

}
