using System.Threading.Tasks;
using FlashAnzan.Presentation.Shared;
using FlashAnzan.View.Home;
using R3;

namespace FlashAnzan.Presentation.Home
{
    public class HomePagePresenter : PagePresenterBase<HomePage, HomeView, HomeViewState>
    {
        public HomePagePresenter(HomePage view, ITransitionService transitionService) : base(view, transitionService)
        {
        }

        protected override Task ViewDidLoad(HomePage view, HomeViewState viewState)
        {
            viewState.OnClicked.Subscribe(_ => TransitionService.TopPageClicked());
            return Task.CompletedTask;
        }
    }
}
