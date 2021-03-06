using UnityEngine;


namespace Skipin2D
{
    public class PlayerController
    {
        //то, что возвращает ось Horizontal
        private float _xAxisInput;
        //проверка в прыжке персонаж или нет
        private bool _isJump;
        //проверка движения
        private bool _isMoving;
        //скорость перемещения
        private float _walkSpeed = 150f;
        // скорость анимации
        private float _animationSpeed = 10f;
        //порог для движения
        private float _movingTreshold = 0.1f;
        //вектора на лефт и райт скейл выбор движения влево или вправо
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);

        //скорость прыжка
        private float _jumpSpeed = 10f;
        // порог для прыжка
        private float _jumpTreshold = 1f;
        //private float _gravitaion = -9.8f;
        ////уровень земли
        //private float _groundLevel = 0.5f;
        //результирующая велосити 
        //private float _yVelocity = 0f;
        private float _xVelocity = 0f;

        private LevelObjectView _view;
        private SpriteAnimatorController _playerAnimator;
        private readonly ContactPooler _contactPooler;





        public PlayerController(LevelObjectView player, SpriteAnimatorController animator)
        {
            _view = player;
            _playerAnimator = animator;
            _playerAnimator.StartAnimation(_view._spriteRenderer, AnimState.Idle, true, _animationSpeed);
            _contactPooler = new ContactPooler(_view._collider);
        }

        private void MoveTowards()//метод передвижения персонажа
        {
            //_view._transform.position += Vector3.right * (Time.deltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1));
            _xVelocity= Time.fixedDeltaTime * _walkSpeed * (_xAxisInput < 0 ? -1 : 1);
            _view._rigidbody.velocity = _view._rigidbody.velocity.Change(x: _xVelocity);
            _view._transform.localScale = _xAxisInput < 0 ? _leftScale : _rightScale;
           
        }

        ////проверка земли
        //public bool IsGrounded()
        //{
        //    return _view._transform.position.y <= _groundLevel && _yVelocity <= 0;
        //}

        public void Update()
        {
            _playerAnimator.Update();
            _contactPooler.Update();
            _xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;//проверка нажата ли кнопака прыжка
            _isMoving = Mathf.Abs(_xAxisInput) > _movingTreshold;

            if (_isMoving)
            {
                MoveTowards();
            }
            //описываем проверки если стоим на земле или не стоим на земле
            if(_contactPooler.IsGrounded)
            {                                                   //проверка если _isMoving true, то мы запускаем run если false то idle
                _playerAnimator.StartAnimation(_view._spriteRenderer, _isMoving ? AnimState.Run : AnimState.Idle, true, _animationSpeed);

                if(_isJump && Mathf.Abs(_view._rigidbody.velocity.y) <= _jumpTreshold)
                {
                    _view._rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
                }

                //else if(_yVelocity < 0)
                //{
                //    _yVelocity = 0f;
                //                                                        //замена позиции через расширение Change
                //    _view.transform.position = _view._transform.position.Change(y: _groundLevel);

                //}
            }
            else
            {
                if(Mathf.Abs(_view._rigidbody.velocity.y) > _jumpTreshold)
                {
                    _playerAnimator.StartAnimation(_view._spriteRenderer, AnimState.Jump, true, _animationSpeed);

                }
               
                //_yVelocity += _gravitaion * Time.deltaTime;
                
                //_view._transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }
        }
    }
}
 