using FlashAnzan.Presentation.Shared;
using FlashAnzan.View.Setting;

namespace FlashAnzan.Presentation.Setting
{
    public class SettingModalPresenterFactory
    {
        public SettingModalPresenter Create(SettingModal view, ITransitionService transitionService)
        {
            return new SettingModalPresenter(view, transitionService);
        }
    }
}
