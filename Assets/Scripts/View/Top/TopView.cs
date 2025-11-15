using Cysharp.Threading.Tasks;
using FlashAnzan.PresentationFramework;
using FlashAnzan.View.Foundation.Binders;
using UnityEngine;
using UnityEngine.UI;
using R3;

namespace FlashAnzan.View.Top
{
    public class TopView : AppView<TopViewState>
    {
        [SerializeField] private Button settingButton;
        [SerializeField] private Button startButton;

        protected override UniTask Initialize(TopViewState state)
        {
            var internalState = (ITopState)state;
            settingButton.SetOnClickDestination(internalState.InvokeSettingButtonClicked).AddTo(this);
            startButton.SetOnClickDestination(internalState.InvokeStartButtonClicked).AddTo(this);
            return UniTask.CompletedTask;
        }
    }
}
