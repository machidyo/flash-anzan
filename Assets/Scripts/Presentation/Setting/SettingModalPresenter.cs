using System.Threading.Tasks;
using R3;
using FlashAnzan.Presentation.Shared;
using FlashAnzan.View.Setting;
using FlashAnzan.UseCase.Setting;

namespace FlashAnzan.Presentation.Setting
{
    public class SettingModalPresenter : ModalPresenterBase<SettingModal, SettingView, SettingViewState>
    {
        private readonly SettingUseCase useCase;
        
        public SettingModalPresenter(SettingModal view, ITransitionService transitionService, SettingUseCase uc)
            : base(view, transitionService)
        {
            useCase = uc;
        }

        protected override async Task ViewDidLoad(SettingModal view, SettingViewState viewState)
        {
            await useCase.FetchSettingAsync();
            SetSettingGrade(viewState, useCase.Model.Grade);
            
            useCase.Model
                .OnValueChanged
                .Subscribe(changedValue =>
                {
                    SetSettingGrade(viewState, changedValue.Grade);
                    // Gradeが追加されるところまでは見れたので、ViewのほうのTextを更新する方法を見るところから
                    // PrayerPrefsに保存されて、再開したらもどるところの確認も
                });
            
            viewState.OnSaveButtonClicked
                .Subscribe(async _ =>
                {
                    var grade = useCase.Model.Grade + 1;
                    await useCase.SaveGrade(grade);
                });
            viewState.OnCancelButtonClicked.Subscribe(_ => TransitionService.PopCommandExecuted());
        }

        private void SetSettingGrade(SettingViewState viewState, int grade)
        {
            viewState.SettingValuesViewState.Grade.Value = grade;
        }
    }
}
