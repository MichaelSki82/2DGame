using UnityEngine;

namespace Skipin2D
{
    [CreateAssetMenu(fileName = "QuestStoryCfg", menuName = "Configs / Quest Story Cfg", order = 1)]
    public class QuestStoryConfig : ScriptableObject//объект, который будет хранить в себе данные о цепочке квестов.
    {
        public QuestConfig[] quests;
        public QuestStoryType Type;
    }

    public enum QuestStoryType//тип историй обычная или сбрасываемая 
    {
        Common,
        Resettable
    }
}
