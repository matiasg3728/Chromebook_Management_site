using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chromebook_Management.Models
{
    public class Chromebook
    {
        public int ChromebookId { get; set; }
        public int CommunityId { get; set; }
        /*
        This order ID will be relevent going forward with all new chromebook orders. The idea is that once we have all the current 
        chrombooks input into this site we will begin adding in chromebooks through orders. When a client orders a new chromebook an order
        will be created for every chromebook within their order (Client orders 3 CBs we make 3 order rows). Once the chromebooks arive in office
        the CB ID is entered into the Order and then the system creates a new chromebook row with the ID.
        */
        public int OrderID { get; set; }


        public bool Refurbished { get; set; } 
        public string ChromebookType { get; set; }
        public string Status { get; set; } // In house, Broken, On site
        public DateTime EnrollmentDate { get; set; }

       


    }
}
