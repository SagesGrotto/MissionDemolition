/****
* Created by: Sage
* Date Created: Feb 09, 2022
* 
* Last Edited by: NA
* Last Edited: Feb 09, 2022
* 
* Description: Creates slingshot mechanics
****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    /**** VARIABLES ****/
    [Header("Set in Inspector")]
    public GameObject prefabProjectile;

    [Header("Set Dynamically")]
    public GameObject launchPoint;
    public Vector3 launchPos;
    public GameObject projectile;
    public bool aimingMode;//is player aiming
    public Rigidbody projectileRB;//rigidbody of projec
    public float velocityMultiplier = 8f;

    private void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;

        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!aimingMode) return; //if not aiming, get out

        //get mouse pos from 2d coords
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 mouseDelta = mousePos3D - launchPos;

        // limit mouseDelta to slingshot collider radius
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;

        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize(); //sets vector to same direction but a length of 1
            mouseDelta *= maxMagnitude;//infinite range, but same magnitude as max distance
        }

        //Move projectile to new position
        Vector3 projectilePos = launchPos + mouseDelta;
        projectile.transform.position = projectilePos;

        if (Input.GetMouseButtonUp(0))
        {
            //mouse button has been released
            aimingMode = false;
            projectileRB.isKinematic = false;
            projectileRB.velocity = -mouseDelta * velocityMultiplier;
            FollowCam.POI = projectile;
            projectile = null; // empties ref to istance projectile
        }
    }

    private void OnMouseEnter()
    {
        launchPoint.SetActive(true);
        //print("Slingshot: OnMouseEnter");
    }//end OnMouseEnter()
    private void OnMouseExit()
    {
        launchPoint.SetActive(false);
        //print("Slingshot: OnMouseEnter");
    }//end OnMouseExit()

    private void OnMouseDown()
    {
        aimingMode = true; // playing is aiming
        projectile = Instantiate(prefabProjectile) as GameObject;
        projectile.transform.position = launchPos;
        projectileRB = projectile.GetComponent<Rigidbody>();
        projectileRB.isKinematic = true;
    }
}
