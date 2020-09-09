using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopping.DataModel
{
    interface DataManager
    {
        public Object GetDate(int dataId, Object dataType);
        public Object SaveDate(int dataId, Object dataType);

        //TODO dataManager to implement this interface

    }
}
