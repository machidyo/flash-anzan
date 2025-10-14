using UnityEngine;

namespace FlashAnzan.Composition
{
    public class ApplicationCompositionRoot : MonoBehaviour
    {
        // [SerializeField] private ConnectingView connectingView;

        void Start()
        {
            var transitionService = new TransitionService();
            transitionService.ApplicationStarted();
        }
    }
}
