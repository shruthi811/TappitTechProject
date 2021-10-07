using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TappitTechnicalTest.Models;

namespace TappitTechnicalTest.BusinessEntities
{
    public class PeopleEntity
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAuthorised { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }

        public IEnumerable<string> FavouriteSports { get; set; }
    }
}
