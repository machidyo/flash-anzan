using System;
using FlashAnzan.PresentationFramework;
using R3;

namespace FlashAnzan.View.Setting
{
    public class SettingViewState : AppViewState, ISettingState
    {
        private readonly Subject<Unit> onCloseButtonClickedSubject = new Subject<Unit>();
        
        public Observable<Unit> OnCloseButtonClicked => onCloseButtonClickedSubject;
        
        protected override void DisposeInternal()
        {
            onCloseButtonClickedSubject.Dispose();
        }

        void ISettingState.InvokeCloseButtonClicked()
        {
            onCloseButtonClickedSubject.OnNext(Unit.Default);
        }
    }

    internal interface ISettingState
    {
        void InvokeCloseButtonClicked();
    }
}
