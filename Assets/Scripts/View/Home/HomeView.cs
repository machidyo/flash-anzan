using Cysharp.Threading.Tasks;
using FlashAnzan.PresentationFramework;
using FlashAnzan.View.Foundation.Binders;
using UnityEngine.UI;
using R3;

namespace FlashAnzan.View.Home
{
    public class HomeView : AppView<HomeViewState>
    {
        public Button Button;

        protected override UniTask Initialize(HomeViewState state)
        {
            var internalState = (IHomeState)state;
            Button.SetOnClickDestination(internalState.InvokeBackButtonClicked).AddTo(this);
            return UniTask.CompletedTask;
        }
    }
}
