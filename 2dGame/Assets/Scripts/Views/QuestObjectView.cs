using UnityEngine;

namespace Skipin2D
{
    public class QuestObjectView : LevelObjectView// вест также будет иметь представление на сцене.
                                                  //Ёто представление может визуально измен€тьс€ в зависимости от того, был или не был ли выполнен квест.
    {
        [SerializeField] private int _id;
        [SerializeField] private Color _completedColor;
        [SerializeField] private Color _defaultColor;

        public int Id { get => _id; set => _id = value; }

        void Awake()
        {
            _defaultColor = _spriteRenderer.color;
        }


        public void ProcessComplete()
        {
            _spriteRenderer.color = _completedColor;
        }

        public void ProcessActivate()
        {
            _spriteRenderer.color = _defaultColor;
        }
    }
}
