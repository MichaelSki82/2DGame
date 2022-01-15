using UnityEngine.Tilemaps;//��� ������ � �������� ���������� ������ �����
using UnityEngine;

namespace Skipin2D
{
    public class GeneratorLevelView : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private Tile _groundTile;
        [SerializeField] private int _mapWidth;//������ �����
        [SerializeField] private int _mapHeith;//������ �����
        [SerializeField] private  bool _borders;//���� �������
        [SerializeField] [Range(0, 100)] private int _fillPercent;//������� �������� ����� �������
        [SerializeField] [Range(0, 100)] private int _factorSmooth;//���������� ����������� �����

        public Tilemap Tilemap { get => _tilemap; set => _tilemap = value; } //������������ ���� ����� ������� �������� � �����������
        public Tile GroundTile { get => _groundTile; set => _groundTile = value; }
        public int MapWidth { get => _mapWidth; set => _mapWidth = value; }
        public int MapHeith { get => _mapHeith; set => _mapHeith = value; }
        public bool Borders { get => _borders; set => _borders = value; }
        public int FillPercent { get => _fillPercent; set => _fillPercent = value; }
        public int FactorSmooth { get => _factorSmooth; set => _factorSmooth = value; }
    }
}
