using System;

namespace FlashAnzan.PresentationFramework.UnityScreenExtensions
{
    public abstract class Presenter<TView> : IDisposable
    {
        public bool IsDisposed { get; private set; }
        public bool IsInitialized { get; private set; }
        
        private TView View { get; }

        protected Presenter(TView view)
        {
            View = view;
        }
        
        public virtual void Dispose()
        {
            if (!IsInitialized) return;
            if (IsDisposed) return;
            
            Dispose(View);
            IsDisposed = true;
        }

        public void Initialize()
        {
            if (IsInitialized)
            {
                throw new InvalidOperationException($"");
            }
            
            Initialize(View);
            IsInitialized = true;
        }
        
        protected abstract void Initialize(TView view);
        
        protected abstract void Dispose(TView view);
    }
}
