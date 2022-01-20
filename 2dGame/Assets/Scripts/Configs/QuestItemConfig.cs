using UnityEngine;
using System.Collections.Generic;

namespace Skipin2D
{
    [CreateAssetMenu(fileName = "QuestItemCfg", menuName = "Configs / Quest Item Cfg", order = 1)]
    public class QuestItemConfig : ScriptableObject
    {
        public int questId;
        public List<int> questItemCollection;

    }
}
