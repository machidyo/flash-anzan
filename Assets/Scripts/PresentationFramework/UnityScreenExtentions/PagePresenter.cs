using UnityScreenNavigator.Runtime.Core.Page;

namespace FlashAnzan.PresentationFramework.UnityScreenExtentions
{
    public abstract class PagePresenter<TPage> : Presenter<TPage>, IPagePresenter where TPage : Page
    {
        private TPage View { get; }
        
        protected PagePresenter(TPage view) : base(view)
        {
            View = view;
        }
    }
}
