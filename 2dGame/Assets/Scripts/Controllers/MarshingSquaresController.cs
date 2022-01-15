using UnityEngine;
using UnityEngine.Tilemaps;

namespace Skipin2D
{
    public class MarshingSquaresController //контроллер для марширующих квадратов
    {

        private SquareGrid _squareGrid;//сетка
        private Tilemap _tilemap;
        private Tile _groundTile;

        public void GenerateGrid(int[,] map, float squareSize)//класс прорисовки
        {
            _squareGrid = new SquareGrid(map, squareSize);
        }

        public void DrawTilesOnMap(Tilemap tileMapGround, Tile groundTile)
        {
            if (_squareGrid == null)
            {
                return;
            }

            _tilemap = tileMapGround;
            _groundTile = groundTile;

            for (int x = 0; x < _squareGrid.Squares.GetLength(0); x++)//ширина
            {
                for (int y = 0; y < _squareGrid.Squares.GetLength(1); y++)//высота
                {
                    DrawTile(_squareGrid.Squares[x, y].TopLeft.Active, _squareGrid.Squares[x, y].TopLeft.Position);
                    DrawTile(_squareGrid.Squares[x, y].TopRight.Active, _squareGrid.Squares[x, y].TopRight.Position);
                    DrawTile(_squareGrid.Squares[x, y].BottomLeft.Active, _squareGrid.Squares[x, y].BottomLeft.Position);
                    DrawTile(_squareGrid.Squares[x, y].BottomRight.Active, _squareGrid.Squares[x, y].BottomRight.Position);
                }
            }
        }

        public void DrawTile(bool active, Vector3 position)
        {
            if (active)
            {
                Vector3Int pos = new Vector3Int((int)position.x, (int)position.y, 0);
                _tilemap.SetTile(pos, _groundTile);
            }
        }
    }

    public class Node//класс ноды
    {
        public Vector3 Position;

        public Node(Vector3 _pos)
        {
            Position = _pos;
        }
    }

    public class ControlNode : Node//контрольная нода
    {
        public bool Active;
        public ControlNode(Vector3 pos, bool active) : base(pos)
        {
            Active = active;
        }
    }

    public class Square//квадрат
    {
        public ControlNode TopLeft, TopRight, BottomLeft, BottomRight;

        public Square(ControlNode topLeft, ControlNode topRight, ControlNode bottomLeft, ControlNode bottomRight)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }
    }

    public class SquareGrid//класс сетки. состоящий из квадратов
    {
        public Square[,] Squares;

        public SquareGrid(int[,] map, float squareSize)
        {
            int nodeCountX = map.GetLength(0);
            int nodeCountY = map.GetLength(1);

            float mapWidth = nodeCountX * squareSize;//ширина секти
            float mapHeight = nodeCountY * squareSize;//высота сетки
            float size = squareSize / 2;
            float width = -mapWidth / 2;
            float height = -mapHeight / 2;
            ControlNode[,] controlNodes = new ControlNode[nodeCountX, nodeCountY];

            for (int x = 0; x < nodeCountX; x++)
            {
                for (int y = 0; y < nodeCountY; y++)
                {
                    Vector3 position = new Vector3(width + x * squareSize + size, height + y * squareSize + size, 0);
                    controlNodes[x, y] = new ControlNode(position, map[x, y] == 1);
                }
            }

            Squares = new Square[nodeCountX - 1, nodeCountY - 1];

            for (int x = 0; x < nodeCountX - 1; x++)
            {
                for (int y = 0; y < nodeCountY - 1; y++)
                {
                    Squares[x, y] = new Square(controlNodes[x, y + 1], controlNodes[x + 1, y + 1], controlNodes[x + 1, y], controlNodes[x, y]);
                }
            }
        }
    }
}
