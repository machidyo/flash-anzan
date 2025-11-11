using FlashAnzan.PresentationFramework;

namespace FlashAnzan.View.Loading
{
    public class LoadingViewState : AppViewState, ILoadingState
    {
        protected override void DisposeInternal()
        {
        }
    }

    internal interface ILoadingState
    {
    }
}
