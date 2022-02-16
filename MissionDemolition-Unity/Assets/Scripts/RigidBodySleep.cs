/****
* Created by: Sage
* Date Created: Feb 16, 2022
* 
* Last Edited by: NA
* Last Edited: Feb 16, 2022
* 
* Description: Put rigidbody to sleep(1 frame)
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidBodySleep : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null) rb.Sleep();

    }//end Start

    // Update is called once per frame
    void Update()
    {
        
    }
}
