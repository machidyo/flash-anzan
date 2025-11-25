using FlashAnzan.Presentation.Home;
using FlashAnzan.Presentation.Loading;
using FlashAnzan.Presentation.Setting;
using FlashAnzan.Presentation.Top;
using FlashAnzan.Setting.Repository;
using FlashAnzan.UseCase.Setting;
using UnityEngine;

namespace FlashAnzan.Composition
{
    public class ApplicationCompositionRoot : MonoBehaviour
    {
        // [SerializeField] private ConnectingView connectingView;

        async void Start()
        {
            // Repositories
            var settingRepository = new SettingRepository();
            
            // Models
            // await settingRepository.FetchSettingAsync(); で初期化するか迷ったが、いったん-1という無い値を設定しておくことにした
            var setting = new Domain.Setting.Model.Setting(-1); 
            
            // Use Cases
            var settingUseCase = new SettingUseCase(setting, settingRepository);
            
            // Presenter Factories
            var topPagePresenterFactory = new TopPagePresenterFactory();
            var loadingPagePresenterFactory = new LoadingPagePresenterFactory();
            var settingModalPresenterFactory = new SettingModalPresenterFactory(settingUseCase);
            var homePagePresenterFactory = new HomePagePresenterFactory();
            
            // Transition Service
            var transitionService = new TransitionService(
                topPagePresenterFactory,
                loadingPagePresenterFactory,
                settingModalPresenterFactory,
                homePagePresenterFactory);
            
            transitionService.ApplicationStarted();
        }
    }
}
