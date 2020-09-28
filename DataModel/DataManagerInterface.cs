using BookShoppingApp.DataModel.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopping.DataModel
{
    interface DataManagerInterface
    {
       
        public Object GetDate(int dataId, Type dataType);
        public Object addDate(Object data, Type dataType);
        public Object updateDate(Object data, Type dataType);
        public Object findBy(string propertyName, Type dataType);
        public bool deleteDate(Object data, Type dataType);
        public bool SaveDate(Object data, Type dataType);

        //TODO dataManager to implement this interface

    }
}
