using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public float rotationSpeed = 1;
    public Transform Target, Player;
    float mouseX, mouseY;

    
    

    void Start()
    {
        
        
        
    }

    private void LateUpdate()
    {
        //control toggle
        
        if (Input.GetKey(KeyCode.LeftControl))
        {
          build();
        }
        else
        {
          reg();
        }
        
        
    }


    void reg()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);
        

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
        
    }
    

    void build()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; 

       
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.Mouse1))
        {
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }


    }


   
}
