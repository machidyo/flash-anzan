using System;
using FlashAnzan.Presentation.Home;
using FlashAnzan.Presentation.Loading;
using FlashAnzan.Presentation.Setting;
using FlashAnzan.Presentation.Shared;
using FlashAnzan.Presentation.Top;
using FlashAnzan.PresentationFramework.UnityScreenExtensions;
using FlashAnzan.View.Home;
using FlashAnzan.View.Top;
using FlashAnzan.View.Loading;
using FlashAnzan.View.Setting;
using UnityScreenNavigator.Runtime.Core.Page;
using UnityScreenNavigator.Runtime.Core.Modal;
using R3;

namespace FlashAnzan.Composition
{
    public class TransitionService : ITransitionService
    {
        private readonly TopPagePresenterFactory topPagePresenterFactory;
        private readonly LoadingPagePresenterFactory loadingPagePresenterFactory;
        private readonly SettingModalPresenterFactory settingModalPresenterFactory;
        private readonly HomePagePresenterFactory homePagePresenterFactory;
        
        private static PageContainer MainPageContainer => PageContainer.Find("MainPageContainer");
        private static ModalContainer MainModalContainer => ModalContainer.Find("MainModalContainer");

        public TransitionService(
            TopPagePresenterFactory tppf,
            LoadingPagePresenterFactory ldpff,
            SettingModalPresenterFactory smpf,
            HomePagePresenterFactory hppf)
        {
            topPagePresenterFactory = tppf;
            loadingPagePresenterFactory = ldpff;
            settingModalPresenterFactory = smpf;
            homePagePresenterFactory = hppf;
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

        public void TopPageSettingButtonClicked()
        {
            MainModalContainer.Push<SettingModal>("SettingModal", true,
                onLoad: x =>
                {
                    var modal = x.modal;
                    var presenter =  settingModalPresenterFactory.Create(modal, this);
                    OnModalPresenterCreated(presenter, modal);
                });
        }

        public void HomeLoadingPageShown()
        {
            MainPageContainer.Push<HomePage>("HomePage", true,
                onLoad: x =>
                {
                    var page = x.page;
                    var presenter = homePagePresenterFactory.Create(page, this);
                    OnPagePresenterCreated(presenter, page);
                },
                stack: false);
        }

        public void PopCommandExecuted()
        {
            if (MainModalContainer.IsInTransition || MainPageContainer.IsInTransition)
            {
                throw new InvalidOperationException("PageまたはModalがTransition中はPopできません。");
            }

            if (MainModalContainer.Modals.Count >= 1)
            {
                MainModalContainer.Pop(true);
            }
            else if (MainPageContainer.Pages.Count >= 1)
            {
                MainPageContainer.Pop(true);
            }
            else
            {
                throw new InvalidOperationException("Page、Modalの両方ともスタックされていないためPopできません。");
            }
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

        private IModalPresenter OnModalPresenterCreated(IModalPresenter presenter, Modal modal, bool shouldInitialize = true)
        {
            if (shouldInitialize)
            {
                ((IPresenter)presenter).Initialize();
                presenter.AddTo(modal.gameObject);
            }

            return presenter;
        }
    }
}
