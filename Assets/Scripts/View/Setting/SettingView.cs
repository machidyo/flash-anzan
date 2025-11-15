using Cysharp.Threading.Tasks;
using FlashAnzan.PresentationFramework;
using FlashAnzan.View.Foundation.Binders;
using UnityEngine.UI;
using R3;
using UnityEngine;

namespace FlashAnzan.View.Setting
{
    public class SettingView : AppView<SettingViewState>
    {
        [SerializeField] private Button closeButton;

        protected override UniTask Initialize(SettingViewState state)
        {
            var internalState = (ISettingState)state;
            closeButton.SetOnClickDestination(internalState.InvokeCloseButtonClicked).AddTo(this);
            return UniTask.CompletedTask;
        }
    }
}
