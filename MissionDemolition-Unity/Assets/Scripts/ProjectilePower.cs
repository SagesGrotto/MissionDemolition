using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePower : MonoBehaviour
{
  //  public float velocityMultiplier = Slingshot.velocity_Multiplier;
    public Rigidbody projectileRB; //rigidbody of projec
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            projectileRB = this.GetComponent<Rigidbody>();
            //mouse button has been released
  //          projectileRB.velocity *= velocityMultiplier;
        }
    }
}
