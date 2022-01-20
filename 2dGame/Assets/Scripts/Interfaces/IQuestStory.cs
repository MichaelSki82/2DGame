using System;

namespace Skipin2D
{
    public interface IQuestStory : IDisposable
    {
        bool IsDone { get; }
    }
}
