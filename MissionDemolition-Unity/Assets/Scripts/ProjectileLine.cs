/****
* Created by: Sage
* Date Created: Feb 16, 2022
* 
* Last Edited by: NA
* Last Edited: Feb 16, 2022
* 
* Description: Render lines of the projectile
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLine : MonoBehaviour
{
    static public ProjectileLine S; //

    [Header("Set in Inspector")]
    public float minDist = 0.1f;

    private LineRenderer line;
    private GameObject _poi;
    private List<Vector3> points;

    // Start is called before the first frame update
    void Start()
    {
        S = this;
        line = GetComponent<LineRenderer>();
        line.enabled = false;
        points = new List<Vector3>();
    }

    public GameObject poi
    {
        get { return (_poi); }
        set
        {
            _poi = value;
            if (_poi != null)
            {
                line.enabled = false;
                points = new List<Vector3>();
                AddPoints();
            }

        }
    }

    public void Clear()
    {
        _poi = null;
        line.enabled = false;
        points = new List<Vector3>();

    }

    public void AddPoints()
    {
        Vector3 pt = _poi.transform.position;
        if(points.Count > 0 && (pt - lastPoint).magnitude < minDist)
        {
            return; //if the point is not far enough from the last point
        }
        if(points.Count == 0)
        {
            Vector3 launchPosDiff = pt - Slingshot.Launch_Pos;
            points.Add(pt + launchPosDiff);
            points.Add(pt);
            line.positionCount = 2;
            line.SetPosition(0, points[0]);
            line.SetPosition(1, points[1]);
            line.enabled = true;
        }
        else
        {
            points.Add(pt);
            line.positionCount = points.Count;
            line.SetPosition(points.Count-1, lastPoint);
            line.enabled = true;
        }
    }

    public Vector3 lastPoint
    {
        get
        {
            if (points == null) { return (Vector3.zero); }
            return (points[points.Count - 1]);
        }
        
    }


    private void FixedUpdate()
    {
        if (poi == null)
        {
            if (FollowCam.POI != null)
            {
                if (FollowCam.POI.tag == "Projectile")
                {
                    poi = FollowCam.POI;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        AddPoints();
        if (FollowCam.POI == null)
        {
            poi = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
