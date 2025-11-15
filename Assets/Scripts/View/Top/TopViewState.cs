using System;
using FlashAnzan.PresentationFramework;
using R3;

namespace FlashAnzan.View.Top
{
    public class TopViewState : AppViewState, ITopState
    {
        private readonly Subject<Unit> onSettingButtonClickedSubject = new Subject<Unit>();
        private readonly Subject<Unit> onStartButtonClickedSubject = new Subject<Unit>();
        
        public Observable<Unit> OnSettingButtonClicked => onSettingButtonClickedSubject;
        public Observable<Unit> OnStartButtonClicked => onStartButtonClickedSubject;
        
        protected override void DisposeInternal()
        {
            onSettingButtonClickedSubject.Dispose();
            onStartButtonClickedSubject.Dispose();
        }

        void ITopState.InvokeSettingButtonClicked()
        {
            onSettingButtonClickedSubject.OnNext(Unit.Default);
        }

        void ITopState.InvokeStartButtonClicked()
        {
            onStartButtonClickedSubject.OnNext(Unit.Default);
        }
    }

    internal interface ITopState
    {
        void InvokeSettingButtonClicked();
        void InvokeStartButtonClicked();
    }
}
