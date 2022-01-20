using System;


namespace Skipin2D
{
    public interface IQuest : IDisposable
    {

        event EventHandler<IQuest> Completed;//событие для отслеживания завершения квеста
                                             //состояния: выполнен/не выполнен. Пусть также можно сбросить прогресс квеста.

        bool IsCompleted { get; }
        void Reset();
    }
}