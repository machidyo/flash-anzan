using System;
using UnityEngine;
using UnityEngine.UI;
using R3;
using R3.Triggers;

namespace FlashAnzan.View.Foundation.Binders
{
    public static class ButtonExtensions
    {
        public static IDisposable SetOnClickDestination(this Button self, Action onClick)
        {
            return self.onClick.AsObservable().Subscribe(_ => onClick.Invoke()).AddTo(self);
        }
    }
}
