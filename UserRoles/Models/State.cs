using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserRoles.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }

        [Display(Name = "Pais"), ForeignKey("Country")]
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<City> Cities { get; set; }

        public State()
        {
            Cities = new Collection<City>();
        }
    }
}
