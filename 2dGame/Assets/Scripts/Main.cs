
using System.Collections.Generic;
using UnityEngine;

namespace Skipin2D
{

    public class Main : MonoBehaviour
    {
        [SerializeField] private SpriteAnimatorConfig _playerConfig;
        [SerializeField] private SpriteAnimatorConfig _coinAnimatorCfg;
        //[SerializeField] private int _animationSpeed = 15;
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private CannonView _cannonView;
        [SerializeField] private List<LevelObjectView> _coinViews;
       


        private SpriteAnimatorController _playerAnimator;
        private SpriteAnimatorController _coinAnimator;
        private PlayerController _playerController;
        private CameraController _cameraController;
        private CannonAimController _cannon;
        private BulletEmitterController _bulletEmitterController;
        private CoinsManager _coinsManager;



        void Awake()
        {
            _playerConfig = Resources.Load<SpriteAnimatorConfig>("PlayerAnimCfg");
            _coinAnimatorCfg = Resources.Load<SpriteAnimatorConfig>("CoinAnimCfg");
            _coinAnimator = new SpriteAnimatorController(_coinAnimatorCfg);
            _playerAnimator = new SpriteAnimatorController(_playerConfig);


            //_playerAnimator.StartAnimation(_playerView._spriteRenderer, AnimState.Run, true, _animationSpeed);

            _playerController = new PlayerController(_playerView, _playerAnimator);
            _cameraController = new CameraController(_playerView, Camera.main);
            _cannon = new CannonAimController(_cannonView._muzzleTransform, _playerView._transform);
            _bulletEmitterController = new BulletEmitterController(_cannonView._bullets, _cannonView._emitterTransform);
            _coinsManager = new CoinsManager(_playerView, _coinViews, _coinAnimator);
            

        }

        void Update()
        {
            //_playerAnimator.Update();
            _playerController.Update();
            _cameraController.Update();
            _cannon.Update();
            _bulletEmitterController.Update();
            _coinAnimator.Update();
        }
    }
}
