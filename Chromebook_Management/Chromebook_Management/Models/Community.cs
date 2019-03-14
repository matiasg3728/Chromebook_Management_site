using System;
using System.Collections.Generic;

namespace Chromebook_Management.Models {
    public class Community
    {
        public int CompanyID { get; set; }

        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Chromebook> Chromebooks { get; set; }


    }
}