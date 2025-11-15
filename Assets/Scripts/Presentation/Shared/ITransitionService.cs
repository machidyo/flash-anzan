
namespace FlashAnzan.Presentation.Shared
{
    public interface ITransitionService
    {
        void ApplicationStarted();
        void TopPageClicked();
        void TopPageSettingButtonClicked();
        void HomeLoadingPageShown();
        void PopCommandExecuted();
    }
}

