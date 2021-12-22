using System.Collections.Generic;
using UnityEngine;


namespace Skipin2D
{
    
    public class CannonView : MonoBehaviour
    {
        public Transform _muzzleTransform;//ствол
        public Transform _emitterTransform;//место вылета пули
        public List<LevelObjectView> _bullets;

    }
}
