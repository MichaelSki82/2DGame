
using UnityEngine;

namespace Skipin2D
{
    public class CameraController
    {
        private LevelObjectView _playerView;
        private Transform _playerTransform;
        //private Transform _mCamTransfrom;
        private Camera _camera2d;
        private float _dampTime = 0.15f;
        private Vector3 velocity = Vector3.zero;



        //private float _camSpeed = 1.2f;


        //private float X;
        //private float Y;

        //private float offsetY;
        //private float offsetX;

        //private float _xAxisInput;
        //private float _yAxisVelocity;

        public CameraController(LevelObjectView player, Camera camera)
        {
            _playerView = player;
            _playerTransform = _playerView._transform;
            _camera2d = camera;
        }


        
        public void Update()
        {
            //_xAxisInput = Input.GetAxis("Horizontal");
            //_yAxisVelocity = _playerView._rigidbody.velocity.y;

            //if (_xAxisInput > 0)
            //{
            //    offsetX = 4;
            //}
            //else if (_xAxisInput < 0)
            //{
            //    offsetX = -4;

            //}
            //else
            //{
            //    offsetX = 0;
            //}

            //if (_yAxisVelocity > 0)
            //{
            //    offsetY = 4;
            //}

            //else if (_yAxisVelocity < 0)
            //{
            //    offsetY = -4;
            //}

            //else
            //{
            //    offsetY = 0;
            //}

            //_mCamTransfrom.position = Vector3.Lerp(_mCamTransfrom.position,
            //                                        new Vector3(X + offsetX, Y + offsetY, _mCamTransfrom.position.z), Time.deltaTime * _camSpeed);

            if (_playerTransform)
            {
                Vector3 point = _camera2d.WorldToViewportPoint(_playerTransform.position);
                Vector3 delta = _playerTransform.position - _camera2d.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
                Vector3 destination = _camera2d.transform.position + delta;
                _camera2d.transform.position = Vector3.SmoothDamp(_camera2d.transform.position, destination, ref velocity, _dampTime);
                _camera2d.transform.position = new Vector3(_camera2d.transform.position.x, -1, _camera2d.transform.position.z);
            }

        }
    }
}
