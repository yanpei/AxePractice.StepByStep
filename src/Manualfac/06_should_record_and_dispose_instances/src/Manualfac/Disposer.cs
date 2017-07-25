using System;
using System.Collections.Generic;

namespace Manualfac
{
    class Disposer : Disposable
    {
        #region Please implements the following methods

        /*
         * The disposer is used for disposing all disposable items added when it is disposed.
         */

        Stack<IDisposable> itemsNeedDispose = new Stack<IDisposable>();

        public void AddItemsToDispose(object item)
        {
            var disposableItem = item as IDisposable;
            if(item == null) return;

            itemsNeedDispose.Push(disposableItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                while (itemsNeedDispose.Count > 0)
                {
                    itemsNeedDispose.Pop().Dispose();
                }

                itemsNeedDispose = null;
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}