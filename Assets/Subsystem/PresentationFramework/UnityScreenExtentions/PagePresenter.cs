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
            return ViewDidLoad(View);
        }

        Task IPageLifecycleEvent.WillPushEnter()
        {
            return ViewWillPushEnter(View);
        }

        void IPageLifecycleEvent.DidPushEnter()
        {
            ViewDidPushEnter(View);
        }

        Task IPageLifecycleEvent.WillPushExit()
        {
            return ViewWillPushExit(View);
        }

        void IPageLifecycleEvent.DidPushExit()
        {
            ViewDidPushExit(View);
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

        protected virtual Task ViewDidLoad(TPage page)
        {
            return Task.CompletedTask;
        }

        protected virtual Task ViewWillPushEnter(TPage page)
        {
            return Task.CompletedTask;
        }

        protected virtual void ViewDidPushEnter(TPage page)
        {
        }
        
        protected virtual Task ViewWillPushExit(TPage view)
        {
            return Task.CompletedTask;
        }
        
        protected virtual void ViewDidPushExit(TPage view)
        {
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
