using System;

namespace FlashAnzan.PresentationFramework.UnityScreenExtensions
{
    public interface IPresenter : IDisposable
    {
        bool IsDisposed { get; }
        bool IsInitialized { get; }
        void Initialize();
    }
}
