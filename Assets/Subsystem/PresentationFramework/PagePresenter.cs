using System;
using System.Collections.Generic;
using FlashAnzan.Misc;
using FlashAnzan.PresentationFramework.UnityScreenExtentions;

namespace FlashAnzan.PresentationFramework
{
    public abstract class PagePresenter<TPage, TRootView, TRootViewState> : PagePresenter<TPage>, IDisposableCollectionHolder
        where TPage : Page<TRootView, TRootViewState>
        where TRootView : AppView<TRootViewState>
        where TRootViewState : AppViewState, new()
    {
        private readonly List<IDisposable> disposables = new ();

        protected PagePresenter(TPage view) : base(view)
        {
        }

        ICollection<IDisposable> IDisposableCollectionHolder.GetDisposableCollection()
        {
            return disposables;
        }

        protected sealed override void Initialize(TPage view)
        {
            base.Initialize(view);
        }

        protected sealed override void Dispose(TPage view)
        {
            base.Dispose(view);
            foreach (var disposable in disposables)
            {
                disposable.Dispose();
            }
        }
    }
}
