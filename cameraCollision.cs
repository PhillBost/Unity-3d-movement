using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCollision : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxDistance = 4.0f;
    public float smooth = 10.0f;
    Vector3 dollyDir;
    public Vector3 dollyDirAdjusted;
    public float distance;


    // Start is called before the first frame update
    void Awake() 
    {
        dollyDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 desiredCameraPos = transform.parent.TransformPoint(dollyDir * maxDistance);
        RaycastHit hit;

        if (Physics.Linecast (transform.parent.position, desiredCameraPos, out hit))
        {
            distance = Mathf.Clamp(hit.distance, minDistance, maxDistance);

                
        }
        else
        {
            distance = maxDistance;
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDir * distance, Time.deltaTime * smooth);



        /******
         * Zoom in/out code
         * Adjusts maxDistance
         * 
         * ****/

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            maxDistance--;
            
            
            if(maxDistance < 1)
            {
                maxDistance = 1;
            }
            
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            maxDistance++;

            if (maxDistance > 10)
            {
                maxDistance = 10;
            }
            
        }
    }
}
