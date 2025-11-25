using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using R3;
using FlashAnzan.PresentationFramework;
using FlashAnzan.View.Foundation.Binders;

namespace FlashAnzan.View.Setting
{
    public class SettingView : AppView<SettingViewState>
    {
        [SerializeField] private Button saveButton;
        [SerializeField] private Button cancelButton;
        
        [SerializeField] private SettingValuesView settingValuesView;

        protected override UniTask Initialize(SettingViewState state)
        {
            var internalState = (ISettingState)state;
            saveButton.SetOnClickDestination(internalState.InvokeSaveButtonClicked).AddTo(this);
            cancelButton.SetOnClickDestination(internalState.InvokeCancelButtonClicked).AddTo(this);
            return settingValuesView.InitializeAsync(state.SettingValuesViewState);
        }
    }
}
