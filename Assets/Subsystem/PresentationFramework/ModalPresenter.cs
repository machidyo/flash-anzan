using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlashAnzan.Misc;
using FlashAnzan.PresentationFramework.UnityScreenExtensions;

namespace FlashAnzan.PresentationFramework
{
    public abstract class ModalPresenter<TModal, TRootView, TRootViewState> : ModalPresenter<TModal>, 
        IDisposableCollectionHolder
        where TModal : Modal<TRootView, TRootViewState>
        where TRootView : AppView<TRootViewState>
        where TRootViewState : AppViewState, new()
    {
        private readonly List<IDisposable> disposables = new ();
        private TRootViewState rootViewState;
        
        protected ModalPresenter(TModal view) : base(view)
        {
        }

        public ICollection<IDisposable> GetDisposableCollection()
        {
            return disposables;
        }

        protected sealed override void Initialize(TModal view)
        {
            base.Initialize(view);
        }

        protected sealed override async Task ViewDidLoad(TModal view)
        {
            await base.ViewDidLoad(view);
            var state = new TRootViewState();
            rootViewState = state;
            disposables.Add(state);
            view.SetUp(state);
            await ViewDidLoad(view, state);
        }
        
        protected virtual Task ViewDidLoad(TModal view, TRootViewState viewState)
        {
            return Task.CompletedTask;
        }
    }
}