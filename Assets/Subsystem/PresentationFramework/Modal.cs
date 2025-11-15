using System.Threading.Tasks;
using UnityEngine.Assertions;
using UnityScreenNavigator.Runtime.Core.Modal;

namespace FlashAnzan.PresentationFramework
{
    public abstract class Modal<TRootView, TViewState> : Modal
        where TRootView : AppView<TViewState>
        where TViewState : AppViewState
    {
        public TRootView RootView;
        
        private bool isInitialized;
        private TViewState viewState;

        protected virtual ViewInitializationTiming RootInitializationTiming =>
            ViewInitializationTiming.BeforeFirstEnter;

        public void SetUp(TViewState state)
        {
            Assert.IsNotNull(RootView);
            viewState = state;
        }

        public override async Task Initialize()
        {
            Assert.IsNotNull(RootView);
            
            await base.Initialize();

            if (RootInitializationTiming == ViewInitializationTiming.Initialize && !isInitialized)
            {
                await RootView.InitializeAsync(viewState);
                isInitialized = true;
            }
        }
        
        public override async Task WillPushEnter()
        {
            Assert.IsNotNull(RootView);
            
            await base.WillPushEnter();

            if (RootInitializationTiming == ViewInitializationTiming.BeforeFirstEnter && !isInitialized)
            {
                await RootView.InitializeAsync(viewState);
                isInitialized = true;
            }
        }
    }
}