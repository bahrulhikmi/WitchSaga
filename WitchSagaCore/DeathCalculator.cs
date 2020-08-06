using System;
using System.Collections.Generic;
using System.Text;

namespace WitchSagaCore
{
 
    /// <summary>
    /// Calculator for calculating.. death....
    /// </summary>
    public class DeathCalculator
    {
        /// <summary>
        /// Calculate Average People Killed on the years of birth of the provided persons (which is also killed...)
        /// </summary>
        public double CalculateAveragePeopleKilledOnYearOfBirth(List<Person> persons)
        {
            if (persons.Count == 0) return 0;

            int totalKilled = 0;
            foreach (var person in persons)
            {
                totalKilled += KilledYearRecords.Get(person.YearBorn);

                //We have an invalid total killed return -1
                if (totalKilled < 0)
                    return -1;
            }

            return totalKilled / (double) persons.Count;
        }

    }
}
