
using UnityEngine;

namespace Skipin2D
{

    public class ContactPooler
    {
        private ContactPoint2D[] _contacts = new ContactPoint2D[10];//массив контактов с чем происходит столкновение

        private int _contactCount;//количество контактов
        private Collider2D _collider2D;
        private float _treshold;//погрешность на колижион трешхолд

        public bool IsGrounded { get; private set; }
        public bool LeftContact { get; private set; }
        public bool RightContact { get; private set; }

        public ContactPooler(Collider2D collider)
        {
            _collider2D = collider;
        }
        public void Update()
        {
            IsGrounded = false;
            LeftContact = false;
            RightContact = false;

            _contactCount = _collider2D.GetContacts(_contacts);

            for(int i = 0; i < _contactCount; i++)
            {
                if (_contacts[i].normal.y > _treshold) IsGrounded = true;// если условие верное значит стоим на земле
                if (_contacts[i].normal.x > _treshold) LeftContact = true;
                if (_contacts[i].normal.x > _treshold) RightContact = true;
            }
        }



    }
}
