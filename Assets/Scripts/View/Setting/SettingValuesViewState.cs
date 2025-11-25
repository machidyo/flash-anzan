using R3;
using FlashAnzan.PresentationFramework;

namespace FlashAnzan.View.Setting
{
    public class SettingValuesViewState : AppViewState, ISettingValuesState
    {
        public ReactiveProperty<int> Grade = new ();
        
        protected override void DisposeInternal()
        {
            Grade.Dispose();
        }
    }

    internal interface ISettingValuesState
    {
    }
}