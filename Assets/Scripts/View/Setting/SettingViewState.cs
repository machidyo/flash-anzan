using System;
using FlashAnzan.PresentationFramework;
using R3;

namespace FlashAnzan.View.Setting
{
    public class SettingViewState : AppViewState, ISettingState
    {
        private readonly Subject<Unit> onSaveButtonClickedSubject = new ();
        private readonly Subject<Unit> onCancelButtonClickedSubject = new ();

        public SettingValuesViewState SettingValuesViewState { get; } = new ();
        public Observable<Unit> OnSaveButtonClicked => onSaveButtonClickedSubject;
        public Observable<Unit> OnCancelButtonClicked => onCancelButtonClickedSubject;
        
        protected override void DisposeInternal()
        {
            onSaveButtonClickedSubject.Dispose();
            onCancelButtonClickedSubject.Dispose();
        }

        void ISettingState.InvokeSaveButtonClicked()
        {
            onSaveButtonClickedSubject.OnNext(Unit.Default);
        }

        void ISettingState.InvokeCancelButtonClicked()
        {
            onCancelButtonClickedSubject.OnNext(Unit.Default);
        }
    }

    internal interface ISettingState
    {
        void InvokeSaveButtonClicked();
        void InvokeCancelButtonClicked();
    }
}
