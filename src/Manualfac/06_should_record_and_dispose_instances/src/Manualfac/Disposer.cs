using System;
using System.Collections.Generic;
using System.Linq;

namespace Manualfac
{
    class Disposer : Disposable
    {
        #region Please implements the following methods

        /*
         * The disposer is used for disposing all disposable items added when it is disposed.
         */

        readonly List<IDisposable> itemsNeedDispose = new List<IDisposable>();

        public void AddItemsToDispose(IDisposable item)
        {
            if(item == null) throw new ArgumentNullException(nameof(item));
            itemsNeedDispose.Add(item);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                itemsNeedDispose.ForEach(i => i.Dispose() );
            }
            base.Dispose();
        }

        #endregion
    }
}