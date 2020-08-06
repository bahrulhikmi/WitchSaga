using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WitchSagaWeb.Models
{   
    public class PersonViewModel
    {
        
        [Required]
        public int AgeOfDeath { get; set; }
        [Required]
        public int YearOfDeath { get; set; }
    }

    public class PersonsViewModel
    {
        public PersonsViewModel()
        {
            Persons = new List<PersonViewModel>();
        }
        public int NumberOfVictims { get; set; }
        public List<PersonViewModel> Persons { get; set; }
        public bool Calculate { get; set; }
        public double Result { get; set; }
    }

 
}
