using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 80.0f;

    public Transform target;
    public Transform camTransform;
    public Camera cam;


    private Vector3 moveDir = Vector3.zero;

    Vector2 input;

    public static float distance = 10.0f;
    private static float currentX = 0.0f;
    private static float currentY = 0.0f;
    public float sensitivityX = 4.0f;
    public float sensitivityY = 4.0f;
    public float speed;
    public float gravity;




    void Start()
    {
        


    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX); //clamps a maximum Y so camera cannot go too high above character

        









    }
    void LateUpdate()
    {
        regMode();

    }
    public void regMode()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 camF = camTransform.forward;
        Vector3 camR = camTransform.right;

        camF.y = 0;  //without these two lines, character will move downward and upward with camera, useful for vehicles?
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;

        Vector3 dir = new Vector3(0, 0, -distance);

        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        camTransform.position = target.position + rotation * dir; //position of camera
        camTransform.LookAt(target.position); //makes camera look at player

        target.position += ((camF * input.y + camR * input.x) * Time.deltaTime * distance) * speed; //player travels in direction of camera
    }


}

