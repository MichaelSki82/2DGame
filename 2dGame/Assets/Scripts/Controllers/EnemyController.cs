using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Skipin2D
{
    public class EnemyController
    {
       
        private float _moveSpeed;
        
        private List<Transform> _wayPoints;

        private LevelObjectView _enemyView;

        private int _fromWayPointIndex;
        private float wayProgress;

        Vector3 nextWayPoint;
        Vector3 currentWayPoint;

        public EnemyController(LevelObjectView enemyView, float moveSpeed, List <Transform> wayPoints)
        {
            _enemyView = enemyView;
            _moveSpeed = moveSpeed;
            _wayPoints = wayPoints;

            _fromWayPointIndex = 0;
            currentWayPoint = _wayPoints[_fromWayPointIndex].position;
            nextWayPoint = _wayPoints[_fromWayPointIndex + 1].position;
        }

        public void Update()
        {
            wayProgress += Time.deltaTime * _moveSpeed;

            if (wayProgress >= 1)
            {
                SetupNextWayPoints();
                wayProgress -= 1;
            }

            _enemyView.transform.position = Vector3.Lerp(currentWayPoint, nextWayPoint, wayProgress);
        }

        private void SetupNextWayPoints()
        {
            _fromWayPointIndex++;

            if (_fromWayPointIndex + 1 >= _wayPoints.Count)
            {
                currentWayPoint = _wayPoints[_wayPoints.Count - 1].position;
                nextWayPoint = _wayPoints[0].position;
                _fromWayPointIndex = -1;
                return;
            }

            currentWayPoint = _wayPoints[_fromWayPointIndex].position;
            nextWayPoint = _wayPoints[_fromWayPointIndex + 1].position;
        }
    }
}
