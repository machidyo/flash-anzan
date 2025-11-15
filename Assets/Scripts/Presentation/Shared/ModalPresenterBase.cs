using FlashAnzan.PresentationFramework;

namespace FlashAnzan.Presentation.Shared
{
    public abstract class ModalPresenterBase<TModal, TRootView, TRootViewState>
        : ModalPresenter<TModal, TRootView, TRootViewState>
        where TModal : Modal<TRootView, TRootViewState>
        where TRootView : AppView<TRootViewState>
        where TRootViewState : AppViewState, new()
    {
        protected ITransitionService TransitionService { get; }

        protected ModalPresenterBase(TModal view, ITransitionService transitionService) : base(view)
        {
            TransitionService = transitionService;
        }
    }
}