using System.Threading.Tasks;
using FlashAnzan.Presentation.Shared;
using FlashAnzan.View.Top;
using R3;

namespace FlashAnzan.Presentation.Top
{
    public class TopPagePresenter : PagePresenterBase<TopPage, TopView, TopViewState>
    {
        public TopPagePresenter(TopPage view, ITransitionService transitionService) : base(view, transitionService)
        {
        }

        protected override Task ViewDidLoad(TopPage view, TopViewState viewState)
        {
            viewState.OnClicked.Subscribe(_ => TransitionService.TopPageClicked());
            return Task.CompletedTask;
        }
    }
}
