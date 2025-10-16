using FlashAnzan.Presentation.Shared;
using FlashAnzan.View.Top;
using UnityEngine;

namespace FlashAnzan.Presentation.Top
{
    public class TopPagePresenter : PagePresenterBase<TopPage, TopView, TopViewState>
    {
        public TopPagePresenter(TopPage view, ITransitionService transitionService) : base(view, transitionService)
        {
        }

        // ViewDidLoad(...)
    }
}
