using System;
using System.Collections.Generic;
using UnityEngine;

namespace FlashAnzan.Misc
{
    public interface IDisposableCollectionHolder
    {
        ICollection<IDisposable> GetDisposableCollection();
    }
}
