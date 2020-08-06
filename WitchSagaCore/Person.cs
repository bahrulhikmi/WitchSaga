using System;

namespace WitchSagaCore
{
    /// <summary>
    /// Record of person that has been killed by the witch
    /// </summary>
    public class Person
    {
        public int AgeOfDeath { get; set; }
        public int YearOfDeath { get; set; }

        public int YearBorn {
            get
            {
                return YearOfDeath - AgeOfDeath;
            }
        }

    }
}
