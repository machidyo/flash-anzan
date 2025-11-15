using System.Threading.Tasks;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace FlashAnzan.PresentationFramework.UnityScreenExtensions
{
    public abstract class ModalPresenter<TModal> : Presenter<TModal>, IModalPresenter where TModal : Modal
    {
        private TModal View { get; }

        protected ModalPresenter(TModal view) : base(view)
        {
            View = view;
        }

        Task IModalLifecycleEvent.Initialize()
        {
            return ViewDidLoad(View);
        }

        Task IModalLifecycleEvent.WillPushEnter()
        {
            return ViewWillPushEnter(View);
        }

        void IModalLifecycleEvent.DidPushEnter()
        {
            ViewDidPushEnter(View);
        }

        Task IModalLifecycleEvent.WillPushExit()
        {
            throw new System.NotImplementedException();
        }

        void IModalLifecycleEvent.DidPushExit()
        {
            throw new System.NotImplementedException();
        }

        Task IModalLifecycleEvent.WillPopEnter()
        {
            throw new System.NotImplementedException();
        }

        void IModalLifecycleEvent.DidPopEnter()
        {
            throw new System.NotImplementedException();
        }

        Task IModalLifecycleEvent.WillPopExit()
        {
            return ViewWillPopExit(View);
        }

        void IModalLifecycleEvent.DidPopExit()
        {
            ViewDidPopExit(View);
        }

        Task IModalLifecycleEvent.Cleanup()
        {
            return ViewWillDestroy(View);
        }

        protected virtual Task ViewDidLoad(TModal modal)
        {
            return Task.CompletedTask;
        }
        
        protected virtual Task ViewWillPushEnter(TModal view)
        {
            return Task.CompletedTask;
        }

        protected virtual void ViewDidPushEnter(TModal view)
        {
        }
        
        protected virtual Task ViewWillPopExit(TModal view)
        {
            return Task.CompletedTask;
        }

        protected virtual void ViewDidPopExit(TModal view)
        {
        }
        
        protected virtual Task ViewWillDestroy(TModal view)
        {
            return Task.CompletedTask;
        }
        
        protected override void Initialize(TModal view)
        {
            view.AddLifecycleEvent(this, 1);
        }

        protected override void Dispose(TModal view)
        {
            view.RemoveLifecycleEvent(this);
        }
    }
}