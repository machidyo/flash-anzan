using System.Threading.Tasks;
using FlashAnzan.Presentation.Shared;
using FlashAnzan.View.Loading;

namespace FlashAnzan.Presentation.Loading
{
    public class LoadingPagePresenter : PagePresenterBase<LoadingPage, LoadingView, LoadingViewState>
    {
        public LoadingPagePresenter(LoadingPage view, ITransitionService transitionService) : base(view, transitionService)
        {
        }

        protected override Task ViewDidLoad(LoadingPage view, LoadingViewState viewState)
        {
            return Task.CompletedTask;
        }
    }
}
