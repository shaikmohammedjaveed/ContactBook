using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookEntityLayer
{
    public class Contacts
    {
        // Properties to intertact with the Table which is created in Data Base


        // Properties Category Id
        public int CategoryId { get; set; }

        // Properties Contact Id

        public int ContactId { get; set; }

        // Properties First Name
        public string FirstName { get; set; }

        //Properties Last Name
        public string LastName { get; set; }

        //Properties Phone Number
        public string PhoneNo { get; set; }

        //Properties Email ID
        public string Email { get; set; }
    }
}
