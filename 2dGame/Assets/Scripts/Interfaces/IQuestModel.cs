using UnityEngine;

namespace Skipin2D
{
    public interface IQuestModel//Возможность завершения квеста будет обсчитываться на основе некоторой модели.

    {
        bool TryComplete(GameObject actor);
    }
}

