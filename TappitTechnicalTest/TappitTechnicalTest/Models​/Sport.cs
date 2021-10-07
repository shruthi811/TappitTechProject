using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TappitTechnicalTest.Models​
{
    [Table("Sports", Schema = "TappitTechnicalTest")]
    public partial class Sport
    {
        public Sport()
        {
            FavouriteSports = new HashSet<FavouriteSport>();
        }

        [Key]
        public int SportId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        [InverseProperty(nameof(FavouriteSport.Sport))]
        public virtual ICollection<FavouriteSport> FavouriteSports { get; set; }
    }

}
