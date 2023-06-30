using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(FrizeTargetCoordinates))]
public class DragAndDropPieces : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _mousPos;
    private Vector3 _dragOffset;
    private float _speedMovement = 100f;
    private FrizeTargetCoordinates _targetCoordinates;
    private List<GameObject> _listOfPiecese;

    private void Start()
    {
        // кидаем ссылку на камеру в переменную;
        _camera = Camera.main;
        _targetCoordinates = GetComponent<FrizeTargetCoordinates>();
        _listOfPiecese = GameObject.FindGameObjectWithTag("PuzzleController").GetComponent<MakePuzzlesFromImage>().GamePieces;
    }

    private void OnMouseDown()
    {
        //дельта между местом нажатия мышки и позиции пазла 
        _dragOffset = transform.position - GetMousePos();
    }

    private void OnMouseDrag()
    {
        // перетаскиваем пазл
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speedMovement * Time.deltaTime);
    }

    public Vector3 GetMousePos()
    {
        // определяем позицию мышки
        _mousPos = _camera.ScreenToWorldPoint(Input.mousePosition);
        return _mousPos;
    }

    private void OnMouseUp()
    {
        if (Vector3.Distance(transform.position, _targetCoordinates.TargetCoordinates) < 0.11)
        {
            transform.position = _targetCoordinates.TargetCoordinates;
            _listOfPiecese.Remove(transform.gameObject);
            Destroy(transform.gameObject.GetComponent<DragAndDropPieces>());
        }        
    }
}
