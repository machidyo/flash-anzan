using FlashAnzan.PresentationFramework;
using UnityEngine;

namespace FlashAnzan.View.Top
{
    public class TopViewState : AppViewState, ITopState
    {
        protected override void DisposeInternal()
        {
            throw new System.NotImplementedException();
        }

        public void InvokeBackButtonClicked()
        {
            throw new System.NotImplementedException();
        }
    }

    internal interface ITopState
    {
        void InvokeBackButtonClicked();
    }
}
