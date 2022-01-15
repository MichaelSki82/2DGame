using UnityEngine.Tilemaps;
using UnityEngine;

namespace Skipin2D
{

    public class GeneratorController
    {
        private Tilemap _tilemap;
        private Tile _groundTile;
        private int _mapWidth;//ширина карты
        private int _mapHeith;//высота карты
        private bool _borders;//края массива
        private int _fillPercent;//процент покрытия карты тайлами
        private int _factorSmooth;//коэфициент сглаживания карты

        private int[,] _map;// двумерный массив сама карта

        private const int CountWall = 4;//переменная определяющая количество соседних клеток
        private MarshingSquaresController SquareGen;

        public GeneratorController(GeneratorLevelView levelView)
        {
            _tilemap = levelView.Tilemap;
            _groundTile = levelView.GroundTile;
            _mapHeith = levelView.MapHeith;
            _mapWidth = levelView.MapWidth;
            _borders = levelView.Borders;
            _factorSmooth = levelView.FactorSmooth;
            _fillPercent = levelView.FillPercent;

            _map = new int[_mapWidth, _mapHeith];

        }

        public void Init()//инициализация карты
        {
            FillMap();//заполнение карты , генерация двумерного массива и его заполнение рандомно
            for (int i = 0; i < _factorSmooth; i++)
            {
                SmoothMap();//сглаживание карты  - пробегаем по массиву несоклько раз и по правилу клеточного автомата преобразуем клекти из нулей в единицы

            }

            SquareGen = new MarshingSquaresController();
            SquareGen.GenerateGrid(_map, 1);
            SquareGen.DrawTilesOnMap(_tilemap, _groundTile);

            //DrawTiles();//отрисовка карты передаем маасив в тайловую палетку и пробигаемся по массиу и отрисовываем карту
        }

        private void FillMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeith; y++)
                {
                    if (x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeith - 1)
                    {
                        if (_borders)//проверка границ
                        {
                            _map[x , y] = 0;

                        }
                    }
                    else
                    {
                        _map[x, y] = Random.Range(0, 100) < _fillPercent ? 1 : 0;
                    }


                }
            }
        }


        private void SmoothMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeith; y++)
                {
                    int neighbour = GetNeighbour( x,  y); //переменная для проверки соседних клеток
                    if (neighbour > CountWall)
                    {
                        _map[x, y] = 1;
                    }
                    else if (neighbour < CountWall)
                    {
                        _map[x, y] = 0;
                    }


                }
            }

        }

        private int GetNeighbour(int x, int y)// этот метод пробегается по обозначенным зонам 
        {
            int neighbourCounter = 0;

            for (int gridX = x - 1; gridX <= x + 1; gridX++)
            {
                for (int gridY = y - 1; gridY <= y + 1; gridY++)
                {
                    if (gridX >= 0 && gridX < _mapWidth && gridY >= 0 && gridY < _mapHeith)
                    {
                        if (gridX!=x || gridY!=y)
                        {
                            neighbourCounter += _map[gridX, gridY];
                        }
                                                
                    }
                    else
                    {
                        neighbourCounter++;
                    }
                }
            }
            

            return neighbourCounter;
        }

        private void DrawTiles()
        {
            if (_map == null)
            {
                return;
            }
            else
            {
                for (int x = 0; x < _mapWidth; x++)
                {
                    for (int y = 0; y < _mapHeith; y++)
                    {
                        Vector3Int tilePosition = new Vector3Int(-_mapWidth / 2 + x, -_mapHeith / 2 + y, 0);
                        if (_map[x, y] == 1)
                        {
                            _tilemap.SetTile(tilePosition, _groundTile);
                        }
                    }
                }
            }


        }
    }


   
}