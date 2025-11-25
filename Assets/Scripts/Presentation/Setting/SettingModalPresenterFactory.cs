using FlashAnzan.Presentation.Shared;
using FlashAnzan.UseCase.Setting;
using FlashAnzan.View.Setting;

namespace FlashAnzan.Presentation.Setting
{
    public class SettingModalPresenterFactory
    {
        private readonly SettingUseCase settingUseCase;
        
        public SettingModalPresenterFactory(SettingUseCase suc)
        {
            settingUseCase = suc;
        }
        
        public SettingModalPresenter Create(SettingModal view, ITransitionService transitionService)
        {
            return new SettingModalPresenter(view, transitionService, settingUseCase);
        }
    }
}
