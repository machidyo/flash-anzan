using System.Threading.Tasks;
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

        Task IPageLifecycleEvent.Initialize()
        {
            throw new System.NotImplementedException();
        }

        Task IPageLifecycleEvent.WillPushEnter()
        {
            throw new System.NotImplementedException();
        }

        void IPageLifecycleEvent.DidPushEnter()
        {
            throw new System.NotImplementedException();
        }

        Task IPageLifecycleEvent.WillPushExit()
        {
            throw new System.NotImplementedException();
        }

        void IPageLifecycleEvent.DidPushExit()
        {
            throw new System.NotImplementedException();
        }

        Task IPageLifecycleEvent.WillPopEnter()
        {
            throw new System.NotImplementedException();
        }

        void IPageLifecycleEvent.DidPopEnter()
        {
            throw new System.NotImplementedException();
        }

        Task IPageLifecycleEvent.WillPopExit()
        {
            throw new System.NotImplementedException();
        }

        void IPageLifecycleEvent.DidPopExit()
        {
            throw new System.NotImplementedException();
        }

        Task IPageLifecycleEvent.Cleanup()
        {
            throw new System.NotImplementedException();
        }
        
        protected override void Initialize(TPage view)
        {
            view.AddLifecycleEvent(this, 1);
        }

        protected override void Dispose(TPage view)
        {
            view.RemoveLifecycleEvent(this);
        }
    }
}
