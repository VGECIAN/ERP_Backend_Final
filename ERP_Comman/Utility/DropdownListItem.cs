using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Comman
{
    public class DropdownListItem
    {
        public int Value { get; set; }
        public string Text { get; set; } = null!;
        public bool IsSelected { get; set; }
    }

    public class DropdownListItemWithParent : DropdownListItem
    {
        public int ParentId { get; set; }
    }
}
