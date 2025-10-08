using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FlashAnzan.PresentationFramework
{
    public abstract class AppView<TState> : MonoBehaviour
        where TState : AppViewState
    {
        private bool isInitialized;

        public async UniTask InitializeAsync(TState state)
        {
            if (isInitialized) return;

            isInitialized = true;

            await Initialize(state);
        }

        protected abstract UniTask Initialize(TState state);
    }
}
