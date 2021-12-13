using System;
using UnityEngine;

namespace Skipin2D
{
    public class LevelObjectView : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] public  SpriteRenderer _spriteRenderer;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
    }
}
