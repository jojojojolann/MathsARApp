using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using System;

public class ARRayCastPlace : MonoBehaviour
{
    public List<GameObject> objectsToPlace;
    public ARRaycastManager raycastManager;

    private int index = 0;
    private GameObject placedObject;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Debug.Log("Touch detected");
            // If the user touch the screen, shoot a raycast
            if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = hits[0].pose;
                Debug.Log("Raycast hit at " + hitPose.position);

                if (placedObject == null)
                {
                    // If there is no object placed, instantiate the object
                    placedObject = Instantiate(objectsToPlace[index], hitPose.position, hitPose.rotation);
                    Debug.Log("Object placed at " + hitPose.position);
                }
                else
                {
                    // If there is an object placed, update the position
                    placedObject.transform.position = hitPose.position;
                    Debug.Log("Object moved to " + hitPose.position);
                }
            }
        }
    }

    public void SetIndex(int ID)
    {
        index = ID;
        Debug.Log("Index set to " + index);
    }

}
