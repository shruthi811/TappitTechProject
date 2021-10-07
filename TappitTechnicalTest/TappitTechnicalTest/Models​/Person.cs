using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TappitTechnicalTest.Models​
{
    [Table("People", Schema = "TappitTechnicalTest")]
    public partial class Person
    {
        public Person()
        {
            FavouriteSports = new HashSet<FavouriteSport>();
        }

        [Key]
        public int PersonId { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public bool IsAuthorised { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }

        [InverseProperty(nameof(FavouriteSport.Person))]
        public virtual ICollection<FavouriteSport> FavouriteSports { get; set; }
    }
}
