using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Canvas mainCanvas;
    public Canvas geometry2Canvas;
    public Canvas geometry3Canvas;
    public Canvas graphsCanvas;
    public Canvas puzzleCanvas;
    public Canvas symmetryCanvas;
    public Canvas operationsCanvas;
    public Canvas measurementsCanvas;
    public Canvas statisticsCanvas;

    void Start()
    {
        ShowMainCanvas();
    }

    public void ShowMainCanvas()
    {
        mainCanvas.gameObject.SetActive(true);
        geometry2Canvas.gameObject.SetActive(false);
        geometry3Canvas.gameObject.SetActive(false);
        graphsCanvas.gameObject.SetActive(false);
        puzzleCanvas.gameObject.SetActive(false);
        symmetryCanvas.gameObject.SetActive(false);
        operationsCanvas.gameObject.SetActive(false);
        measurementsCanvas.gameObject.SetActive(false);
        statisticsCanvas.gameObject.SetActive(false);
    }

    public void Showgeometry2Canvas()
    {
        mainCanvas.gameObject.SetActive(false);
        geometry2Canvas.gameObject.SetActive(true);
        geometry3Canvas.gameObject.SetActive(false);
        graphsCanvas.gameObject.SetActive(false);
        puzzleCanvas.gameObject.SetActive(false);
        symmetryCanvas.gameObject.SetActive(false);
        operationsCanvas.gameObject.SetActive(false);
        measurementsCanvas.gameObject.SetActive(false);
        statisticsCanvas.gameObject.SetActive(false);
    }

    public void Showgeometry3Canvas()
    {
        mainCanvas.gameObject.SetActive(false);
        geometry2Canvas.gameObject.SetActive(false);
        geometry3Canvas.gameObject.SetActive(true);
        graphsCanvas.gameObject.SetActive(false);
        puzzleCanvas.gameObject.SetActive(false);
        symmetryCanvas.gameObject.SetActive(false);
        operationsCanvas.gameObject.SetActive(false);
        measurementsCanvas.gameObject.SetActive(false);
        statisticsCanvas.gameObject.SetActive(false);
    }

    public void ShowgraphsCanvas()
    {
        mainCanvas.gameObject.SetActive(false);
        geometry2Canvas.gameObject.SetActive(false);
        geometry3Canvas.gameObject.SetActive(false);
        graphsCanvas.gameObject.SetActive(true);
        puzzleCanvas.gameObject.SetActive(false);
        symmetryCanvas.gameObject.SetActive(false);
        operationsCanvas.gameObject.SetActive(false);
        measurementsCanvas.gameObject.SetActive(false);
        statisticsCanvas.gameObject.SetActive(false);
    }

    public void ShowpuzzleCanvas()
    {
        mainCanvas.gameObject.SetActive(false);
        geometry2Canvas.gameObject.SetActive(false);
        geometry3Canvas.gameObject.SetActive(false);
        graphsCanvas.gameObject.SetActive(false);
        puzzleCanvas.gameObject.SetActive(true);
        symmetryCanvas.gameObject.SetActive(false);
        operationsCanvas.gameObject.SetActive(false);
        measurementsCanvas.gameObject.SetActive(false);
        statisticsCanvas.gameObject.SetActive(false);
    }

    public void ShowsymmetryCanvas()
    {
        mainCanvas.gameObject.SetActive(false);
        geometry2Canvas.gameObject.SetActive(false);
        geometry3Canvas.gameObject.SetActive(false);
        graphsCanvas.gameObject.SetActive(false);
        puzzleCanvas.gameObject.SetActive(false);
        symmetryCanvas.gameObject.SetActive(true);
        operationsCanvas.gameObject.SetActive(false);
        measurementsCanvas.gameObject.SetActive(false);
        statisticsCanvas.gameObject.SetActive(false);
    }

    public void ShowoperationsCanvas()
    {
        mainCanvas.gameObject.SetActive(false);
        geometry2Canvas.gameObject.SetActive(false);
        geometry3Canvas.gameObject.SetActive(false);
        graphsCanvas.gameObject.SetActive(false);
        puzzleCanvas.gameObject.SetActive(false);
        symmetryCanvas.gameObject.SetActive(false);
        operationsCanvas.gameObject.SetActive(true);
        measurementsCanvas.gameObject.SetActive(false);
        statisticsCanvas.gameObject.SetActive(false);
    }

    public void ShowmeasurementsCanvas()
    {
        mainCanvas.gameObject.SetActive(false);
        geometry2Canvas.gameObject.SetActive(false);
        geometry3Canvas.gameObject.SetActive(false);
        graphsCanvas.gameObject.SetActive(false);
        puzzleCanvas.gameObject.SetActive(false);
        symmetryCanvas.gameObject.SetActive(false);
        operationsCanvas.gameObject.SetActive(false);
        measurementsCanvas.gameObject.SetActive(true);
        statisticsCanvas.gameObject.SetActive(false);
    }

    public void ShowstatisticsCanvas()
    {
        mainCanvas.gameObject.SetActive(false);
        geometry2Canvas.gameObject.SetActive(false);
        geometry3Canvas.gameObject.SetActive(false);
        graphsCanvas.gameObject.SetActive(false);
        puzzleCanvas.gameObject.SetActive(false);
        symmetryCanvas.gameObject.SetActive(false);
        operationsCanvas.gameObject.SetActive(false);
        measurementsCanvas.gameObject.SetActive(false);
        statisticsCanvas.gameObject.SetActive(true);
    }
    public void GoBackToMainMenu()
    {
        ShowMainCanvas();
    }
}
