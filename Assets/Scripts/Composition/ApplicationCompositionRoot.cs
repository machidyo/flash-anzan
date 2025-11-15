using FlashAnzan.Presentation.Home;
using FlashAnzan.Presentation.Loading;
using FlashAnzan.Presentation.Setting;
using FlashAnzan.Presentation.Top;
using UnityEngine;

namespace FlashAnzan.Composition
{
    public class ApplicationCompositionRoot : MonoBehaviour
    {
        // [SerializeField] private ConnectingView connectingView;

        void Start()
        {
            var topPagePresenterFactory = new TopPagePresenterFactory();
            var loadingPagePresenterFactory = new LoadingPagePresenterFactory();
            var settingModalPresenterFactory = new SettingModalPresenterFactory();
            var homePagePresenterFactory = new HomePagePresenterFactory();
            
            var transitionService = new TransitionService(
                topPagePresenterFactory,
                loadingPagePresenterFactory,
                settingModalPresenterFactory,
                homePagePresenterFactory);
            
            transitionService.ApplicationStarted();
        }
    }
}
