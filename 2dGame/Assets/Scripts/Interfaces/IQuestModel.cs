using UnityEngine;

namespace Skipin2D
{
    public interface IQuestModel//����������� ���������� ������ ����� ������������� �� ������ ��������� ������.

    {
        bool TryComplete(GameObject actor);
    }
}

