using FlashAnzan.Presentation.Shared;
using FlashAnzan.View.Home;

namespace FlashAnzan.Presentation.Home
{
    public class HomePagePresenterFactory
    {
        public HomePagePresenter Create(HomePage view, ITransitionService transitionService)
        {
            return new HomePagePresenter(view, transitionService);
        }
    }
}
