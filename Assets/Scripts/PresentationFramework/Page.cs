using System.Threading.Tasks;
using UnityEngine.Assertions;
using UnityScreenNavigator.Runtime.Core.Page;

namespace FlashAnzan.PresentationFramework
{
    public abstract class Page<TRootView, TViewState> : Page
         where TRootView : AppView<TViewState>
         where TViewState : AppViewState
    {
        public TRootView Root { get; set; }
        private bool isInitialized;
        private TViewState state;

        protected virtual ViewInitializationTiming rootInitializationTiming =>
            ViewInitializationTiming.BeforeFirstEnter;

        public void SetUp(TViewState vs)
        {
            state = vs;
        }

        public override async Task Initialize()
        {
            Assert.IsNotNull(Root);
            
            await base.Initialize();

            if (rootInitializationTiming == ViewInitializationTiming.Initialize && !isInitialized)
            {
                await Root.InitializeAsync(state);
                isInitialized = true;
            }
        }
    }
}
