using System.Collections.Generic;
using UnityEngine;

public class CheckWinStatus : MonoBehaviour
{
    private List<GameObject> _listOfPiecese;
    private bool _oneIteration = true;

    void Start()
    {
        _listOfPiecese = GameObject.FindGameObjectWithTag("PuzzleController").GetComponent<MakePuzzlesFromImage>().GamePieces;
    }

    void FixedUpdate()
    {
        if (_oneIteration && _listOfPiecese.Count <= 0)
        {
            _oneIteration = false;
            GameObject.FindGameObjectWithTag("RestartAndExit").GetComponent<Canvas>().enabled = true;
        }
    }
}
