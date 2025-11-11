using FlashAnzan.Presentation.Shared;
using FlashAnzan.View.Loading;

namespace FlashAnzan.Presentation.Loading
{
    public class LoadingPagePresenterFactory
    {
        public LoadingPagePresenter Create(LoadingPage view, ITransitionService transitionService)
        {
            return new LoadingPagePresenter(view, transitionService);
        }
    }
}
