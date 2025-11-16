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
        [SerializeField] private Button saveButton;
        [SerializeField] private Button cancelButton;

        protected override UniTask Initialize(SettingViewState state)
        {
            var internalState = (ISettingState)state;
            saveButton.SetOnClickDestination(internalState.InvokeSaveButtonClicked).AddTo(this);
            cancelButton.SetOnClickDestination(internalState.InvokeCancelButtonClicked).AddTo(this);
            return UniTask.CompletedTask;
        }
    }
}
