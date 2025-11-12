using System.Collections;
using FlashAnzan.Presentation.Shared;
using FlashAnzan.View.Loading;

namespace FlashAnzan.Presentation.Loading
{
    public class LoadingPagePresenter : PagePresenterBase<LoadingPage, LoadingView, LoadingViewState>
    {
        public LoadingPagePresenter(LoadingPage view, ITransitionService transitionService) : base(view, transitionService)
        {
        }
        
        protected override void ViewDidPushEnter(LoadingPage page, LoadingViewState viewState)
        {
            page.StartCoroutine(WaitAndCallHomeLoadingPageShown());
        }

        private IEnumerator WaitAndCallHomeLoadingPageShown()
        {
            yield return null;
            TransitionService.HomeLoadingPageShown();
        }
    }
}
