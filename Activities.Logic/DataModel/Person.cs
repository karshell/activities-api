using System;
using System.Collections.Generic;
using System.Text;

namespace Activities.Logic.DataModel
{
    public class Person
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Activity { get; set; }

        public string Comments { get; set; }
    }
}
