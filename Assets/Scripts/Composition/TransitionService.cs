using FlashAnzan.Presentation.Shared;
using FlashAnzan.Presentation.Top;
using FlashAnzan.PresentationFramework.UnityScreenExtentions;
using FlashAnzan.View.Top;
using UnityScreenNavigator.Runtime.Core.Page;
using R3;

namespace FlashAnzan.Composition
{
    public class TransitionService : ITransitionService
    {
        private readonly TopPagePresenterFactory topPagePresenterFactory;
        
        private static PageContainer MainPageContainer => PageContainer.Find("MainPageContainer");

        public TransitionService(TopPagePresenterFactory tppf)
        {
            topPagePresenterFactory = tppf;
        }
        
        public void ApplicationStarted()
        {
            MainPageContainer.Push<TopPage>("TopPage", false,
                onLoad: x =>
                {
                    var page = x.page;
                    var presenter = topPagePresenterFactory.Create(page, this);
                    OnPagePresenterCreated(presenter, page);
                });
        }

        private IPagePresenter OnPagePresenterCreated(IPagePresenter presenter, Page page, bool shouldInitialize = true)
        {
            if (shouldInitialize)
            {
                ((IPresenter)presenter).Initialize();
                presenter.AddTo(page.gameObject);
            }

            return presenter;
        }
    }
}
