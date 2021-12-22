
using UnityEngine;


namespace Skipin2D
{
    public class CannonAimController 
    {
        private Transform _muzzleTransform;//это ствол
        private Transform _targetTransform;//это цель - персонаж

        private Vector3 _dir;
        private float _angle;
        private Vector3 _axis; //ось поворота

        public CannonAimController(Transform muzzleTransform, Transform playerTransform)
        {
            _muzzleTransform = muzzleTransform;
            _targetTransform = playerTransform;
        }

        public void Update()
        {
            _dir = _targetTransform.position - _muzzleTransform.position;//вектор направления
            _angle = Vector3.Angle(Vector3.down, _dir);
            _axis = Vector3.Cross(Vector3.down, _dir);//умнодение векторов, дающий третий результатирущий вектор по правилу левой руки

            _muzzleTransform.rotation = Quaternion.AngleAxis(_angle, _axis); //поворот ствола вокруг оси
        }
    }
}
