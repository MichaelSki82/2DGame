using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skipin2D
{
    public class BulletController
    {

        private Vector3 _velocity;
        private LevelObjectView _view;

        public BulletController( LevelObjectView view)
        {
            _view = view;
            ActiveBullet(false);
        }
        
        public void ActiveBullet(bool val)
        {
            _view.gameObject.SetActive(val);

        }
        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;

            float angle = Vector3.Angle(Vector3.left, _velocity);
            Vector3 axis = Vector3.Cross(Vector3.left, _velocity);
            _view._transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        public void ThrowBullet(Vector3 position, Vector3 velocity)
        {
            ActiveBullet(true);
            SetVelocity(velocity);

            _view._transform.position = position;
            _view._rigidbody.angularVelocity = 0;

            _view._rigidbody.AddForce(velocity, ForceMode2D.Impulse);
        }
    }
}

