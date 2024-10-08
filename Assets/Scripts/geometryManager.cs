using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manage the geometry canvas
public class GeometryManager : MonoBehaviour
{
    //// 2D Shapes
    //public Canvas square;
    //public Canvas circle;
    //public Canvas triangle;
    //public Canvas hexagon;

    //// 2D Sliders
    //public Slider circleSlider;
    //public Slider hexagonSlider;

    // 3D Shapes
    public Canvas cube;
    public Canvas sphere;
    public Canvas pyramid;
    public Canvas cylinder;

    // 3D Sliders
    public Slider cubeSlider;
    public Slider pyramidSlider;
    public Slider polygonSlider;

    public void Start()
    {
        // Hide all shapes and sliders at the start
        HideAllShapes();
        HideAllSliders();
    }

    // Hide all 2D and 3D shapes
    private void HideAllShapes()
    {
        //square.gameObject.SetActive(false);
        //circle.gameObject.SetActive(false);
        //triangle.gameObject.SetActive(false);
        //hexagon.gameObject.SetActive(false);

        cube.gameObject.SetActive(false);
        sphere.gameObject.SetActive(false);
        pyramid.gameObject.SetActive(false);
        cylinder.gameObject.SetActive(false);
    }

    // Hide all sliders
    public void HideAllSliders()
    {
        //circleSlider.gameObject.SetActive(false);
        //hexagonSlider.gameObject.SetActive(false);
        cubeSlider.gameObject.SetActive(false);
        pyramidSlider.gameObject.SetActive(false);
        polygonSlider.gameObject.SetActive(false);
    }

    //// Show specific shapes (2D)
    //public void ShowSquare()
    //{
    //    HideAllShapes();
    //    square.gameObject.SetActive(true);
    //}

    //public void ShowCircle()
    //{
    //    HideAllShapes();
    //    circle.gameObject.SetActive(true);
    //    ShowCircleSlider();
    //}

    //public void ShowTriangle()
    //{
    //    HideAllShapes();
    //    triangle.gameObject.SetActive(true);
    //}

    //public void ShowHexagon()
    //{
    //    HideAllShapes();
    //    hexagon.gameObject.SetActive(true);
    //    ShowHexagonSlider();
    //}

    // Show specific shapes (3D)
    public void ShowCube()
    {
        HideAllShapes();
        cube.gameObject.SetActive(true);
    }

    public void ShowSphere()
    {
        HideAllShapes();
        sphere.gameObject.SetActive(true);
    }

    public void ShowPyramid()
    {
        HideAllShapes();
        pyramid.gameObject.SetActive(true);
    }

    public void ShowCylinder()
    {
        HideAllShapes();
        cylinder.gameObject.SetActive(true);
    }

    // Show specific sliders
    //public void ShowCircleSlider()
    //{
    //    HideAllSliders();
    //    circleSlider.gameObject.SetActive(true);
    //}

    //public void ShowHexagonSlider()
    //{
    //    HideAllSliders();
    //    hexagonSlider.gameObject.SetActive(true);
    //}

    public void ShowCubeSlider()
    {
        HideAllSliders();
        cubeSlider.gameObject.SetActive(true);
    }

    public void ShowPyramidSlider()
    {
        HideAllSliders();
        pyramidSlider.gameObject.SetActive(true);
    }

    public void ShowPolygonSlider()
    {
        HideAllSliders();
        polygonSlider.gameObject.SetActive(true);
    }
}
