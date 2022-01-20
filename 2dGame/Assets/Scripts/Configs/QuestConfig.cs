using UnityEngine;

namespace Skipin2D
{

    [CreateAssetMenu(fileName = "QuestCfg", menuName = "Configs / Quest Cfg", order = 1)]
    public class QuestConfig : ScriptableObject
    {
        public int id;//Id � ���������� ������������� ��� ��������� ����.

        public QuestType questType;//QuestType � ��� ������, �� ������ �������� ����� ������������� �� ��� ���� ������ ��� ������������.

    }

    public enum QuestType
    {
        Coins
    }
}