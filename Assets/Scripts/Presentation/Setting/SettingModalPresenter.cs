using System.Threading.Tasks;
using FlashAnzan.Presentation.Shared;
using FlashAnzan.View.Setting;
using R3;
using UnityEngine;

namespace FlashAnzan.Presentation.Setting
{
    public class SettingModalPresenter : ModalPresenterBase<SettingModal, SettingView, SettingViewState>
    {
        public SettingModalPresenter(SettingModal view, ITransitionService transitionService) : base(view, transitionService)
        {
        }

        protected override Task ViewDidLoad(SettingModal view, SettingViewState viewState)
        {
            viewState.OnSaveButtonClicked.Subscribe(_ => Debug.Log("保存します"));
            viewState.OnCancelButtonClicked.Subscribe(_ => TransitionService.PopCommandExecuted());
            return Task.CompletedTask;
        }
    }
}
