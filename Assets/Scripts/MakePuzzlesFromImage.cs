using System;
using System.Collections.Generic;
using UnityEngine;

public class MakePuzzlesFromImage : MonoBehaviour
{
    private Texture2D _image;
    private int _countOfSeparation = 5;
    private int _columns;
    private int _rows;
    private float _num = 0f;
    private List<GameObject> _gamePieces = new List<GameObject>();
    public List<GameObject> GamePieces
    {
        get { return _gamePieces; }
    }

    void Awake()
    {
        // поиск исходной картинки
        _image = DataHolder.Image;

        if (!_image) return;

        _countOfSeparation = Convert.ToInt32(DataHolder.Text);

        if (_countOfSeparation % 2 != 0 && _countOfSeparation != 1)
            _countOfSeparation++;

       // количество сепараций
       _columns = _countOfSeparation;
        _rows = _countOfSeparation;

        // вычисление размера каждого пазла
        float pieceWidth = _image.width / (float)_rows;
        float pieceHeight = _image.height / (float)_columns;

        // стартовая позиция первого пазла
        float x = 0f;
        float y = 0f;

        // создание пазлов
        for (int column = 0; column < _columns; column++)
        {
            for (int row = 0; row < _rows; row++)
            {
                // создание игрового объекта для пазла
                GameObject piece = new GameObject($"Piece_{column}_{row}");

                // позиционирование объекта-пазла
                piece.transform.position = new Vector3(x, y, 0f);

                // фиксируем исходные координаты для пазла
                FrizeTargetCoordinates _targetCoordinates = piece.AddComponent<FrizeTargetCoordinates>();
                _targetCoordinates.TargetCoordinates = piece.transform.position;

                // добавление компонента SpriteRenderer (изображение) к пазлу
                SpriteRenderer renderer = piece.AddComponent<SpriteRenderer>();                                               

                // разметка куска изображения из исходной картинки для очередного пазла
                Rect rect = new Rect(column * pieceWidth, row * pieceHeight, pieceWidth, pieceHeight);

                // создание спрайта для отсепарированного эелемента
                Sprite pieceSprite = Sprite.Create(_image, rect, Vector2.zero);                

                // назначение спрайта для самого пазла
                renderer.sprite = pieceSprite;

                // добавляем компонент перетаскивания элементов мышкой
                DragAndDropPieces dragAndDrop = piece.AddComponent<DragAndDropPieces>();

                // добавляем коллайдер для перетаскивания
                BoxCollider2D collider = piece.AddComponent<BoxCollider2D>();

                //меняем позицию пазла
                y += pieceSprite.bounds.size.y;
                _num = pieceSprite.bounds.size.x;

                _gamePieces.Add(piece);
            }
            y = 0f;
            x += _num;            
        }
    }
}
