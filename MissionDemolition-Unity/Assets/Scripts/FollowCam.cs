/****
* Created by: Sage
* Date Created: Feb 09, 2022
* 
* Last Edited by: NA
* Last Edited: Feb 09, 2022
* 
* Description: Cam follows projectile
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; //static point of interest

    public float camZ; //desired Z position of cam

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    void FixedUpdate()
    {
        if (POI == null) return;

        Vector3 destination = POI.transform.position;
        destination.z = camZ;
        transform.position = destination;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
