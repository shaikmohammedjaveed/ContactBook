using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookEntityLayer
{
    public class ContactCategory
    {
        //Properties to Interact with Category table which is created in Data Base

        //Property for Category Id
        public int categoryId { get; set; }

        //Property for Category Name
        public string CategoryName { get; set; } 
    }
}
