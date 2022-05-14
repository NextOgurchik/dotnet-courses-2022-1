using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WinFormsApp1
{
    class MyBindingList<T> : BindingList<T>
    {
        public MyBindingList(IList<T> list)
            : base(list)
        {

        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var list = this.Items;
            var templist = new List<T>();
            if (direction == ListSortDirection.Ascending)
                templist = list.OrderBy(y => prop.GetValue(y)).ToList();
            else
                templist = list.OrderByDescending(y => prop.GetValue(y)).ToList();
            list.Clear();
            foreach (var inside in templist)
            {
                list.Add(inside);
            }
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
    }
}

