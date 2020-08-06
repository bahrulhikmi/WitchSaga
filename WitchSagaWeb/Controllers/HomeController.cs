using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WitchSagaCore;
using WitchSagaWeb.Models;

namespace WitchSagaWeb.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [HttpGet]
        public IActionResult Index(PersonsViewModel personsViewParam)
        {
            PersonsViewModel personsViewModel;
            if (personsViewParam.NumberOfVictims > 0)
                personsViewModel = personsViewParam;
            else
                personsViewModel = new PersonsViewModel() { NumberOfVictims = 2 };
            
            if(!personsViewModel.Calculate)
            {
                personsViewModel.Persons.Clear();
                for (int i = 0; i < personsViewModel.NumberOfVictims; i++)
                {
                    personsViewModel.Persons.Add(new PersonViewModel() { AgeOfDeath =10, YearOfDeath = 12 });
                }
            }

            else
            {
                var deathCalculator = new DeathCalculator();
               personsViewModel.Result = deathCalculator.CalculateAveragePeopleKilledOnYearOfBirth(personsViewModel.Persons.
                    Select(x => new Person() { AgeOfDeath = x.AgeOfDeath, YearOfDeath = x.YearOfDeath }).ToList());
            }

            return View(personsViewModel);
        }

    }
}
