using Cysharp.Threading.Tasks;
using FlashAnzan.PresentationFramework;

namespace FlashAnzan.View.Loading
{
    public class LoadingView : AppView<LoadingViewState>
    {
        protected override UniTask Initialize(LoadingViewState state)
        {
            return UniTask.CompletedTask;
        }
    }
}
