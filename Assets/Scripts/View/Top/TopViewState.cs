using System;
using FlashAnzan.PresentationFramework;
using R3;

namespace FlashAnzan.View.Top
{
    public class TopViewState : AppViewState, ITopState
    {
        private readonly Subject<Unit> onClickedSubject = new Subject<Unit>();
        
        public Observable<Unit> OnClicked => onClickedSubject;
        
        protected override void DisposeInternal()
        {
            onClickedSubject.Dispose();
        }

        void ITopState.InvokeBackButtonClicked()
        {
            onClickedSubject.OnNext(Unit.Default);
        }
    }

    internal interface ITopState
    {
        void InvokeBackButtonClicked();
    }
}
