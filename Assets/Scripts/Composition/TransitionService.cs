using FlashAnzan.Presentation.Shared;

namespace FlashAnzan.Composition
{
    public class TransitionService : ITransitionService
    {
        private readonly TopPagePresenterFactory topPagePresenterFactory;

        public TransitionService(TopPagePresenterFactory tppf)
        {
            topPagePresenterFactory = tppf;
        }
        
        public void ApplicationStarted()
        {
            throw new System.NotImplementedException();
        }
    }
}
