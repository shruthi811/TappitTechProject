using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TappitTechnicalTest.Models​
{
    [Table("FavouriteSports", Schema = "TappitTechnicalTest")]
    public partial class FavouriteSport
    {
        [Key]
        public int PersonId { get; set; }
        [Key]
        public int SportId { get; set; }

        [ForeignKey(nameof(PersonId))]
        [InverseProperty("FavouriteSports")]
        public virtual Person Person { get; set; }
        [ForeignKey(nameof(SportId))]
        [InverseProperty("FavouriteSports")]
        public virtual Sport Sport { get; set; }
    }
}
