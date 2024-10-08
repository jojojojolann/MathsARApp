using APPack.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class symmetryManager : MonoBehaviour
{
    // Parameters
    public GameObject reflectionsPrefab;
    public GameObject rotationsPrefab;
    public GameObject translationsPrefab;
    public GameObject dilationsPrefab;

    public GameObject symmetryBarPrefab;

    private GameObject currentShape;
    private GameObject reflectedShape;
    private GameObject symmetryBar;
    private GameObject rotatedShape;
    private GameObject translatedShape;
    private GameObject dilatedShape;

    public Button reflection;
    public Button rotation;
    public Button translation;
    public Button dilation;

    public Material redMaterial;
    public Material blueMaterial;

    public void Start()
    {
        reflection.gameObject.SetActive(false);
        rotation.gameObject.SetActive(false);
        translation.gameObject.SetActive(false);
        dilation.gameObject.SetActive(false);
    }

    public void showReflection()
    {
        reflection.gameObject.SetActive(true);
        rotation.gameObject.SetActive(false);
        translation.gameObject.SetActive(false);
        dilation.gameObject.SetActive(false);

        destroyShapes();

        currentShape = Instantiate(reflectionsPrefab, Vector3.zero, Quaternion.identity);   // Instantiate the shape
        currentShape.transform.position = new Vector3(0, 0, 20);                         // Set the position
        currentShape.transform.localScale = new Vector3(10, 10, 10);                        // Set the scale
    }

    public void Reflection() // Function to reflect the shape
    {
        if (symmetryBar != null)
        {
            Destroy(symmetryBar);
        } else if (reflectedShape != null)
        {
            Destroy(reflectedShape);
        }

        symmetryBar = Instantiate(symmetryBarPrefab, new Vector3(0, 0, 0), Quaternion.identity);     // Instantiate the symmetry bar
        Vector3 symmetryPosition = new Vector3(-currentShape.transform.position.x, currentShape.transform.position.y, currentShape.transform.position.z);   // Calculate the position of the reflected shape

        reflectedShape = Instantiate(currentShape, symmetryPosition, Quaternion.identity);  // Instantiate the reflected shape
        reflectedShape.transform.localScale = currentShape.transform.localScale;            // Set the scale of the reflected shape
        reflectedShape.transform.position = new Vector3(0, 0, -20);                      // Set the position of the reflected shape
        reflectedShape.transform.Rotate(0, 180, 0);                                         // Rotate the reflected shape

        reflectedShape.GetComponent<MeshRenderer>().material = redMaterial; // Set the material of the reflected shape
    }

    public void showRotation()
    {
        reflection.gameObject.SetActive(false);
        rotation.gameObject.SetActive(true);
        translation.gameObject.SetActive(false);
        dilation.gameObject.SetActive(false);

        destroyShapes();

        currentShape = Instantiate(rotationsPrefab, Vector3.zero, Quaternion.identity); // Instantiate the shape
        currentShape.transform.position = new Vector3(0, 0, -10);                    // Set the position
        currentShape.transform.localScale = new Vector3(10, 10, 10);                    // Set the scale
    }

    public void Rotation()
    {
        StartCoroutine(RotateShapeCoroutine(new Vector3(0, 0, 0), 90f, 1f)); 
    }

    private IEnumerator RotateShapeCoroutine(Vector3 pivot, float angle, float duration)
    {
        if (rotatedShape != null)
        {
            Destroy(rotatedShape);
        }

        rotatedShape = Instantiate(currentShape, currentShape.transform.position, Quaternion.identity); // Instantiate the rotated shape
        rotatedShape.GetComponent<MeshRenderer>().material = redMaterial;   // Set the material
        Vector3 startPos = rotatedShape.transform.position;                 // Get the start position
        Quaternion startRot = rotatedShape.transform.rotation;              // Get the start rotation

        float t = 0f;
        while (t < duration)
        {
            float currentAngle = Mathf.Lerp(0, angle, t / duration);  // Calculate the current angle
            rotatedShape.transform.RotateAround(pivot, Vector3.up, currentAngle - rotatedShape.transform.rotation.eulerAngles.y);   // Rotate the shape
            t += Time.deltaTime;    // Update time
            yield return null;      // Wait for the next frame
        }

        rotatedShape.transform.RotateAround(pivot, Vector3.up, angle - rotatedShape.transform.rotation.eulerAngles.y);  // Rotate the shape to the final angle
    }


    public void showTranslation()
    {
        reflection.gameObject.SetActive(false);
        rotation.gameObject.SetActive(false);
        translation.gameObject.SetActive(true);
        dilation.gameObject.SetActive(false);

        destroyShapes();

        currentShape = Instantiate(translationsPrefab, Vector3.zero, Quaternion.identity);  // Instantiate the shape
        currentShape.transform.position = new Vector3(0, 0, -10);    // Set the position
        currentShape.transform.localScale = new Vector3(10, 10, 10);    // Set the scale
    }

    public void Translation()
    {
        StartCoroutine(TranslateShapeCoroutine(new Vector3(0, 0, 10), 1f));
    }

    private IEnumerator TranslateShapeCoroutine(Vector3 targetPosition, float duration)
    {
        if (translatedShape != null)
        {
            Destroy(translatedShape);
        }

        translatedShape = Instantiate(currentShape, currentShape.transform.position, Quaternion.identity);  // Instantiate the translated shape
        translatedShape.GetComponent<MeshRenderer>().material = redMaterial;    // Set the material of the translated shape
        Vector3 startPos = translatedShape.transform.position;                  // Get the start position

        float t = 0f; // Time
        while (t < duration)
        {
            translatedShape.transform.position = Vector3.Lerp(startPos, targetPosition, t / duration);    // Translate the shape
            t += Time.deltaTime;    // Update the time
            yield return null;      // Wait for the next frame
        }

        translatedShape.transform.position = targetPosition;    // Set the final position of the translated shape
    }


    public void showDilation()
    {
        reflection.gameObject.SetActive(false);
        rotation.gameObject.SetActive(false);
        translation.gameObject.SetActive(false);
        dilation.gameObject.SetActive(true);

        destroyShapes();

        currentShape = Instantiate(dilationsPrefab, Vector3.zero, Quaternion.identity); // Instantiate the shape
        currentShape.transform.position = new Vector3(0, 0, -10);    // Set the position
        currentShape.transform.localScale = new Vector3(10, 10, 10);    // Set the scale
    }

    public void Dilation()
    {
        StartCoroutine(DilateShapeCoroutine(new Vector3(0, 0, 10), new Vector3(2, 2, 2), 1f));
    }

    private IEnumerator DilateShapeCoroutine(Vector3 targetPosition, Vector3 finalScale, float duration)
    {
        if (dilatedShape != null)
        {
            Destroy(dilatedShape);
        }

        dilatedShape = Instantiate(currentShape, currentShape.transform.position, Quaternion.identity); // Instantiate the dilated shape
        dilatedShape.GetComponent<MeshRenderer>().material = blueMaterial;                              // Set the material of the dilated shape
        Vector3 startPos = dilatedShape.transform.position;         // Get the start position
        Vector3 startScale = dilatedShape.transform.localScale;     // Get the start scale

        float t = 0f;
        while (t < duration)
        {
            dilatedShape.transform.position = Vector3.Lerp(startPos, targetPosition, t / duration);   // Translate the shape
            dilatedShape.transform.localScale = Vector3.Lerp(startScale, finalScale, t / duration);   // Scale the shape
            t += Time.deltaTime;    // Update the time
            yield return null;      // Wait for the next frame
        }

        dilatedShape.transform.position = targetPosition;   // Set the final position of the dilated shape
        dilatedShape.transform.localScale = finalScale;     // Same for the scale
    }

    // Function to destroy the shapes
    public void destroyShapes()
    {
        Destroy(currentShape);
        Destroy(reflectedShape);
        Destroy(symmetryBar);
        Destroy(rotatedShape);
        Destroy(translatedShape);
        Destroy(dilatedShape);
    }
}
