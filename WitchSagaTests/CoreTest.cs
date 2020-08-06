using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WitchSagaCore;
namespace WitchSagaTests
{
    [TestClass]
    public class CoreTest
    {
        [TestMethod]
        public void TestAverageNumberOfKilledTwoPersons()
        {
            var killedPersons = new List<Person>() {
               new Person() {AgeOfDeath = 10, YearOfDeath = 12 },
               new Person() {AgeOfDeath = 13, YearOfDeath = 17 } 
            };

            var deathCalculator = new DeathCalculator();

            Assert.AreEqual<double>(4.5d, deathCalculator.CalculateAveragePeopleKilledOnYearOfBirth(killedPersons));
        }

        [TestMethod]
        public void TestAverageNumberOfKilledSinglePersons()
        {
            var killedPersons = new List<Person>() {
               new Person() {AgeOfDeath = 10, YearOfDeath = 16 }
            };

            var deathCalculator = new DeathCalculator();

            Assert.AreEqual(20, deathCalculator.CalculateAveragePeopleKilledOnYearOfBirth(killedPersons));
        }


        [TestMethod]
        public void TestAverageNumberOfKilledAlotOfPersons()
        {
            var killedPersons = new List<Person>() {
               new Person() {AgeOfDeath = 10, YearOfDeath = 11 },
               new Person() {AgeOfDeath = 10, YearOfDeath = 12 },
               new Person() {AgeOfDeath = 10, YearOfDeath = 13 },
               new Person() {AgeOfDeath = 10, YearOfDeath = 14 },
               new Person() {AgeOfDeath = 10, YearOfDeath = 15 },
               new Person() {AgeOfDeath = 10, YearOfDeath = 16 },
            };

            var deathCalculator = new DeathCalculator();

            Assert.AreEqual(46/(double)killedPersons.Count, deathCalculator.CalculateAveragePeopleKilledOnYearOfBirth(killedPersons));
        }

        [TestMethod]
        public void TestAverageNumberOfKilled0Persons_ShouldReturn0()
        {
            var killedPersons = new List<Person>();

            var deathCalculator = new DeathCalculator();

            Assert.AreEqual(0, deathCalculator.CalculateAveragePeopleKilledOnYearOfBirth(killedPersons));
        }


        [TestMethod]
        public void TestInvalidDataSinglePerson_ShouldReturnNegativeOne()
        {
            var killedPersons = new List<Person>() {
               new Person() {AgeOfDeath = 11, YearOfDeath = 10 }
            };

            var deathCalculator = new DeathCalculator();

            Assert.AreEqual(-1, deathCalculator.CalculateAveragePeopleKilledOnYearOfBirth(killedPersons));
        }

        [TestMethod]
        public void TestInvalidDataMultiplePerson_OneValid_OneInvalid_ShouldReturnNegativeOne()
        {
            var killedPersons = new List<Person>() {
               new Person() {AgeOfDeath = 13, YearOfDeath = 10 },
               new Person() {AgeOfDeath = 10, YearOfDeath = 17 }
            };

            var deathCalculator = new DeathCalculator();

            Assert.AreEqual(-1, deathCalculator.CalculateAveragePeopleKilledOnYearOfBirth(killedPersons));
        }

    }
}
