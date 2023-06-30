using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class MixPuxxles : MonoBehaviour
{
    private List<GameObject> _listOfPiecese;
    private float _speed = 4f;
    private bool _mixComplite = true;

    private void Start()
    {
        _listOfPiecese = GetComponent<MakePuzzlesFromImage>().GamePieces;
        StartCoroutine(MixPuzzes());
    }

    IEnumerator MixPuzzes()
    {
        while (_mixComplite)
        {
            yield return new WaitForEndOfFrame();
            for (int i = 0; i < _listOfPiecese.Count; i++)
            {
                var rnd = new System.Random();
                int x = rnd.Next(10, 20);
                int y = rnd.Next(1, 9);
                _listOfPiecese[i].transform.position = Vector3.Lerp(_listOfPiecese[i].transform.position, new Vector3(x, y, 0f), _speed * Time.deltaTime);
                if (i == _listOfPiecese.Count-1 && Vector3.Distance(_listOfPiecese[i].GetComponent<FrizeTargetCoordinates>().TargetCoordinates, _listOfPiecese[i].transform.position) > 7)
                    _mixComplite = false;
            }
        }
    }
}
