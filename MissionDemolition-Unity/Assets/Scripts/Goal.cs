/****
* Created by: Sage
* Date Created: Feb 17, 2022
* 
* Last Edited by: NA
* Last Edited: Feb 17, 2022
* 
* Description: Goal mechanics
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static public bool goalMet = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            Goal.goalMet = true;
            Material mat = GetComponent<Renderer>().material;
            Color c = mat.color;
            c.a = 1;
            mat.color = c;
        }
    }
}
