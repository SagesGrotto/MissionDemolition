/****
* Created by: Sage
* Date Created: Feb 09, 2022
* 
* Last Edited by: NA
* Last Edited: Feb 16, 2022
* 
* Description: Cam follows projectile
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; //static point of interest

    [Header("Set in Inspector")]
    public float easing = 0.05f; //amount of ease
    public Vector2 minXY = Vector2.zero;


    public float camZ; //desired Z position of cam

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        //if (POI == null) return;

        //Vector3 destination = POI.transform.position;

        Vector3 destination; //destination of POI
        if(POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = POI.transform.position;
            if(POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    POI = null;
                }
            }//end if(POI.tag == "Projectile")
        }


        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);

        destination = Vector3.Lerp(transform.position, destination, easing); //interpolate from current cam pos towards destination
        destination.z = camZ;
        transform.position = destination;

        Camera.main.orthographicSize = destination.y + 10;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            POI = null;
        }
    }
}
