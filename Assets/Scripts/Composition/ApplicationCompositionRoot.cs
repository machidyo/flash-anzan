using FlashAnzan.Presentation.Top;
using UnityEngine;

namespace FlashAnzan.Composition
{
    public class ApplicationCompositionRoot : MonoBehaviour
    {
        // [SerializeField] private ConnectingView connectingView;

        void Start()
        {
            var topPagePresenterFactory = new TopPagePresenterFactory();
            
            var transitionService = new TransitionService(topPagePresenterFactory);
            transitionService.ApplicationStarted();
        }
    }
}
