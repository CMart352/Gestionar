using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserRoles.Models
{
    public class Country
    {
      
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del pais es requerido")]
        [StringLength(20)]
        public string Name { get; set; }

        public ICollection<State> States { get; set; }
       
        public Country()
        {
            States = new Collection<State>();
        }

    }
}
