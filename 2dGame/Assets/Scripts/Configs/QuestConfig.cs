using UnityEngine;

namespace Skipin2D
{

    [CreateAssetMenu(fileName = "QuestCfg", menuName = "Configs / Quest Cfg", order = 1)]
    public class QuestConfig : ScriptableObject
    {
        public int id;//Id Ч уникальный идентификатор или первичный ключ.

        public QuestType questType;//QuestType Ч тип квеста, на основе которого будет выстраиватьс€ та или ина€ логика его оперировани€.

    }

    public enum QuestType
    {
        Coins
    }
}