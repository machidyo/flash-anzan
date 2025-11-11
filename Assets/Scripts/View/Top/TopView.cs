using Cysharp.Threading.Tasks;
using FlashAnzan.PresentationFramework;
using FlashAnzan.View.Foundation.Binders;
using UnityEngine.UI;
using R3;

namespace FlashAnzan.View.Top
{
    public class TopView : AppView<TopViewState>
    {
        public Button Button;

        protected override UniTask Initialize(TopViewState state)
        {
            var internalState = (ITopState)state;
            Button.SetOnClickDestination(internalState.InvokeBackButtonClicked).AddTo(this);
            return UniTask.CompletedTask;
        }
    }
}
