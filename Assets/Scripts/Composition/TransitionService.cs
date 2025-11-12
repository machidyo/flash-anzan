using FlashAnzan.Presentation.Loading;
using FlashAnzan.Presentation.Shared;
using FlashAnzan.Presentation.Top;
using FlashAnzan.PresentationFramework.UnityScreenExtentions;
using FlashAnzan.View.Top;
using FlashAnzan.View.Loading;
using UnityEngine;
using UnityScreenNavigator.Runtime.Core.Page;
using R3;

namespace FlashAnzan.Composition
{
    public class TransitionService : ITransitionService
    {
        private readonly TopPagePresenterFactory topPagePresenterFactory;
        private readonly LoadingPagePresenterFactory loadingPagePresenterFactory;
        
        private static PageContainer MainPageContainer => PageContainer.Find("MainPageContainer");

        public TransitionService(
            TopPagePresenterFactory tppf,
            LoadingPagePresenterFactory ldpff)
        {
            topPagePresenterFactory = tppf;
            loadingPagePresenterFactory = ldpff;
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

        public void TopPageClicked()
        {
            MainPageContainer.Push<LoadingPage>("LoadingPage", true,
                onLoad: x =>
                {
                    var page = x.page;
                    var presenter = loadingPagePresenterFactory.Create(page, this);
                    OnPagePresenterCreated(presenter, page);
                },
                stack: false);
        }

        public void HomeLoadingPageShown()
        {
            Debug.Log("HomeLoadingPageShown");
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
