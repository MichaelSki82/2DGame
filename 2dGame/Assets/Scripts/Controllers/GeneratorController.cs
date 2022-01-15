using UnityEngine.Tilemaps;
using UnityEngine;

namespace Skipin2D
{

    public class GeneratorController
    {
        private Tilemap _tilemap;
        private Tile _groundTile;
        private int _mapWidth;//������ �����
        private int _mapHeith;//������ �����
        private bool _borders;//���� �������
        private int _fillPercent;//������� �������� ����� �������
        private int _factorSmooth;//���������� ����������� �����

        private int[,] _map;// ��������� ������ ���� �����

        private const int CountWall = 4;//���������� ������������ ���������� �������� ������
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

        public void Init()//������������� �����
        {
            FillMap();//���������� ����� , ��������� ���������� ������� � ��� ���������� ��������
            for (int i = 0; i < _factorSmooth; i++)
            {
                SmoothMap();//����������� �����  - ��������� �� ������� ��������� ��� � �� ������� ���������� �������� ����������� ������ �� ����� � �������

            }

            SquareGen = new MarshingSquaresController();
            SquareGen.GenerateGrid(_map, 1);
            SquareGen.DrawTilesOnMap(_tilemap, _groundTile);

            //DrawTiles();//��������� ����� �������� ������ � �������� ������� � ����������� �� ������ � ������������ �����
        }

        private void FillMap()
        {
            for (int x = 0; x < _mapWidth; x++)
            {
                for (int y = 0; y < _mapHeith; y++)
                {
                    if (x == 0 || x == _mapWidth - 1 || y == 0 || y == _mapHeith - 1)
                    {
                        if (_borders)//�������� ������
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
                    int neighbour = GetNeighbour( x,  y); //���������� ��� �������� �������� ������
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

        private int GetNeighbour(int x, int y)// ���� ����� ����������� �� ������������ ����� 
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