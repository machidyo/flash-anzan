using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;
using UnityScreenNavigator.Runtime.Core.Page;

namespace FlashAnzan.PresentationFramework
{
    public abstract class Page<TRootView, TViewState> : Page
         where TRootView : AppView<TViewState>
         where TViewState : AppViewState
    {
        [SerializeField] private TRootView root;

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
            Assert.IsNotNull(root);
            
            await base.Initialize();

            if (rootInitializationTiming == ViewInitializationTiming.Initialize && !isInitialized)
            {
                await root.InitializeAsync(state);
                isInitialized = true;
            }
        }

        public override async Task WillPushEnter()
        {
            Assert.IsNotNull(root);

            await base.WillPushEnter();

            if (rootInitializationTiming == ViewInitializationTiming.BeforeFirstEnter && !isInitialized)
            {
                await root.InitializeAsync(state);
                isInitialized = true;
            }
        }
    }
}
