using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class geometryShapeManager : MonoBehaviour
{
    public GameObject[] geometryPrefabs;  // Array of geometric shapes

    public GameObject[] conePrefabs;      // Array of cone shapes
    public GameObject[] cubePrefabs;      // Array of cube shapes
    public GameObject[] polygonPrefabs;   // Array of polygon shapes

    public Slider coneSlider;
    public Slider cubeSlider;
    public Slider polygonSlider;

    public Boolean isEdge = false;

    private GameObject currentGeometry;   // The currently displayed shape

    public void showShape(int index)
    {
        if (currentGeometry != null)
        {
            Destroy(currentGeometry);
        }

        // Instantiate the selected shape
        currentGeometry = Instantiate(geometryPrefabs[index], new Vector3(0, -120, 0), Quaternion.identity);
        currentGeometry.transform.position = new Vector3(0, 0, 0);
        //currentGeometry.AddComponent<testMovement>();

        switch (index)
        {
            case 0: // Cube
                showCube();
                break;

            case 1: // Cylinder
                showPolygon();
                break;

            case 2: // Divided Sphere
                currentGeometry.transform.position = new Vector3(0, -120, 0);
                currentGeometry.transform.localScale = new Vector3(20, 20, 20);

                // Rotation animation
                currentGeometry.AddComponent<RotateOnAppear>();
                break;

            case 3: // Pyramid
                showCone();
                break;

            case 6: // 2D Cube
                if (isEdge)
                {
                    currentGeometry = Instantiate(geometryPrefabs[index], new Vector3(0, -120, 0), Quaternion.identity);
                    currentGeometry.transform.localScale = new Vector3(20, 20, 20);
                }
                else
                {
                    currentGeometry = Instantiate(geometryPrefabs[index], new Vector3(0, -120, 0), Quaternion.identity);
                    currentGeometry.transform.localScale = new Vector3(20, 20, 20);
                }
                break;

            default:
                currentGeometry.transform.localScale = new Vector3(10, 10, 10);
                currentGeometry.transform.position = new Vector3(0, -120, 0);
                // Rotation animation
                currentGeometry.AddComponent<RotateOnAppear>();
                break;
        }
        currentGeometry.transform.SetParent(null);
    }

    public void showCone()
    {
        if (currentGeometry != null)
        {
            Destroy(currentGeometry);
        }

        int ID = Mathf.RoundToInt(coneSlider.value) - 3;

        // Instantiate the selected shape
        currentGeometry = Instantiate(conePrefabs[ID], Vector3.zero, Quaternion.Euler(-90, 0, 0));
        currentGeometry.transform.position = new Vector3(0, -120, 0);
        currentGeometry.transform.localScale = new Vector3(20, 20, 10);
        currentGeometry.transform.SetParent(null);

        // Rotation animation
        currentGeometry.AddComponent<RotatePyramidShit>();
    }

    public void showCube()
    {
        if (currentGeometry != null)
        {
            Destroy(currentGeometry);
        }

        int ID = Mathf.RoundToInt(cubeSlider.value);
        currentGeometry = Instantiate(cubePrefabs[ID], Vector3.zero, Quaternion.identity);

        Vector3 position = (ID == 1) ? new Vector3(10, -120, 10) : new Vector3(0, -120, 0);
        currentGeometry.transform.position = position;

        currentGeometry.transform.localScale = new Vector3(20, 20, 20);
        currentGeometry.transform.SetParent(null);

        if (ID == 0)
        {
            currentGeometry.AddComponent<RotateOnAppear>();
        }
    }

    public void showPolygon()
    {
        if (currentGeometry != null)
        {
            Destroy(currentGeometry);
        }

        int ID = Mathf.RoundToInt(polygonSlider.value) - 3;
        // Instantiate the selected shape
        if (ID < 6)
        {
            currentGeometry = Instantiate(polygonPrefabs[ID], new Vector3(0, -120, 0), Quaternion.Euler(90, 0, 0));
        } else
        {
            currentGeometry = Instantiate(polygonPrefabs[6], new Vector3(0, -120, 0), Quaternion.Euler(90, 0, 0));
        }
        
        currentGeometry.transform.position = new Vector3(0, -120, 0);
        currentGeometry.transform.localScale = new Vector3(10, 10, 10);
        currentGeometry.transform.SetParent(null);

        // Rotation animation
        currentGeometry.AddComponent<RotatePyramidShit>();
    }

    public void switchEdgesToggle()
    {
        isEdge = !isEdge;
    }

    public void destroyCurrentGeometry()
    {
        if (currentGeometry != null)
        {
            Destroy(currentGeometry);
        }
    }
}