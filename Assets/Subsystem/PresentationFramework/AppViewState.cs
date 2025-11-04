using System;

namespace FlashAnzan.PresentationFramework
{
    public abstract class AppViewState : IDisposable
    {
        private bool isDisposed;

        public void Dispose()
        {
            if (isDisposed)
                throw new ObjectDisposedException(GetType().Name);

            DisposeInternal();
            
            isDisposed = true;
        }
        
        protected abstract void DisposeInternal();
    }
}
