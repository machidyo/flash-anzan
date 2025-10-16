using FlashAnzan.Presentation.Shared;
using FlashAnzan.View.Top;

namespace FlashAnzan.Presentation.Top
{
    public class TopPagePresenterFactory
    {
        public TopPagePresenter Create(TopPage view, ITransitionService transitionService)
        {
            return new TopPagePresenter(view, transitionService);
        }
    }
}
