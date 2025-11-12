using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        private TRootViewState rootViewState;

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

        protected sealed override async Task ViewDidLoad(TPage view)
        {
            await base.ViewDidLoad(view);
            var state = new TRootViewState();
            rootViewState = state;
            disposables.Add(state);
            view.SetUp(state);
            await ViewDidLoad(view, rootViewState);
        }

        protected sealed override void ViewDidPushEnter(TPage view)
        {
            ViewDidPushEnter(view, rootViewState);
        }

        protected virtual Task ViewDidLoad(TPage view, TRootViewState state)
        {
            return Task.CompletedTask;
        }

        protected virtual void ViewDidPushEnter(TPage view, TRootViewState state)
        {
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
