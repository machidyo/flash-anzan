using System;

namespace FlashAnzan.PresentationFramework.UnityScreenExtentions
{
    public interface IPresenter : IDisposable
    {
        bool IsDisposed { get; }
        bool IsInitialized { get; }
        void Initialize();
    }
}
