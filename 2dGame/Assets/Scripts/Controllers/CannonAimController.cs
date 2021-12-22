
using UnityEngine;


namespace Skipin2D
{
    public class CannonAimController 
    {
        private Transform _muzzleTransform;//��� �����
        private Transform _targetTransform;//��� ���� - ��������

        private Vector3 _dir;
        private float _angle;
        private Vector3 _axis; //��� ��������

        public CannonAimController(Transform muzzleTransform, Transform playerTransform)
        {
            _muzzleTransform = muzzleTransform;
            _targetTransform = playerTransform;
        }

        public void Update()
        {
            _dir = _targetTransform.position - _muzzleTransform.position;//������ �����������
            _angle = Vector3.Angle(Vector3.down, _dir);
            _axis = Vector3.Cross(Vector3.down, _dir);//��������� ��������, ������ ������ ��������������� ������ �� ������� ����� ����

            _muzzleTransform.rotation = Quaternion.AngleAxis(_angle, _axis); //������� ������ ������ ���
        }
    }
}
