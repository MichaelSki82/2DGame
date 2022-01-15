using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Skipin2D
{

    public class LevelCompleteManager : IDisposable

    {
        private Vector3 _startPosition;
        private LevelObjectView _playerView;
        private List<LevelObjectView> _deathZones;

        public LevelCompleteManager(LevelObjectView playerView, List<LevelObjectView> deathZones)
        {
            _playerView = playerView;
            _deathZones = deathZones;

            _startPosition = _playerView.transform.position;
            playerView.OnLevelObjectContact += OnLevelObjectContact;

                       
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_deathZones.Contains(contactView))
            {
                _playerView.transform.position = _startPosition;
            }
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }

}

