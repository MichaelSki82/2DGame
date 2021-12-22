using System.Collections.Generic;
using UnityEngine;


namespace Skipin2D
{
    public class BulletEmitterController 
    {

        private List<BulletController> _bullets = new List<BulletController>();
        private Transform _transfrom;

        private int _currentIndex;
        private float _timeTillNextBullet;

        private float _delay = 1f;
        private float _startSpeed = 15f;

        public BulletEmitterController(List<LevelObjectView> bulletViews, Transform transform)
        {
            _transfrom = transform;
            foreach(LevelObjectView BulletView in bulletViews)
            {
                _bullets.Add(new BulletController(BulletView));
            }
        }

        public void Update()
        {
            if(_timeTillNextBullet > 0)
            {
                _bullets[_currentIndex].ActiveBullet(false);
                _timeTillNextBullet -= Time.deltaTime;

            }
            else
            {
                _timeTillNextBullet = _delay;
                _bullets[_currentIndex].ThrowBullet(_transfrom.position, -_transfrom.up * _startSpeed);
                _currentIndex++;

                if(_currentIndex>=_bullets.Count)
                {
                    _currentIndex = 0;
                }
            }
        }
    }
}
