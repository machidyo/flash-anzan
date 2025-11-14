using System;
using FlashAnzan.PresentationFramework;
using R3;

namespace FlashAnzan.View.Home
{
    public class HomeViewState : AppViewState, IHomeState
    {
        private readonly Subject<Unit> onClickedSubject = new Subject<Unit>();
        
        public Observable<Unit> OnClicked => onClickedSubject;
        
        protected override void DisposeInternal()
        {
            onClickedSubject.Dispose();
        }

        void IHomeState.InvokeBackButtonClicked()
        {
            onClickedSubject.OnNext(Unit.Default);
        }
    }

    internal interface IHomeState
    {
        void InvokeBackButtonClicked();
    }
}
