using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {

            [Test]
            public void ConstructorShouldInitializeVAlidName()
            {
                Weapon weapon = new Weapon("N", 1.2, 2);
                string actualName = weapon.Name;
                string expectedName = "N";

                Assert.AreEqual(expectedName, actualName);
            }


            [Test]
            public void ConstructorShouldInitializeVAlidPrice()
            {
                Weapon weapon = new Weapon("N", 1.2, 2);
                double actualPrice = weapon.Price;
                double expectedPrice = 1.2;

                Assert.AreEqual(expectedPrice, actualPrice);
            }

            [Test]
            public void ConstructorShouldInitializeVAlidLevel()
            {
                Weapon weapon = new Weapon("N", 1.2, 2);
                int actualLevel = weapon.DestructionLevel;
                int expectedLevel = 2;

                Assert.AreEqual(expectedLevel, actualLevel);
            }


            [TestCase(0)]
            [TestCase(1)]
            [TestCase(50)]
            public void SetShouldInitializeValidPrice(double price)
            {
                Weapon weapon = new Weapon("N", price, 2);
                double actualLevel = weapon.Price;
                double expectedLevel = price;

                Assert.AreEqual(expectedLevel, actualLevel);
            }

            [TestCase("")]
            [TestCase("  ")]
            [TestCase("very very very long name")]
            public void SetShouldInitializeValidName(string name)
            {
                Weapon weapon = new Weapon(name, 1.2, 2);
                string actualLevel = weapon.Name;
                string expectedLevel = name;

                Assert.AreEqual(expectedLevel, actualLevel);
            }

            [TestCase(-1)]
            [TestCase(-100)]
            public void SetShouldTrowExceptionForInvalidPrice(double price)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Weapon weapon = new Weapon("N", price, 2);

                }, "Price cannot be negative.");

            }

            [Test]
            public void IncreseCestructionLevelShouldBeValid()
            {
                Weapon weapon = new Weapon("", 1.2, 2);

                weapon.IncreaseDestructionLevel();

                int expectedLevel = 2 + 1;
                int actualLevel = weapon.DestructionLevel;

                Assert.AreEqual(expectedLevel, actualLevel);
            }

            [TestCase(10)]
            [TestCase(11)]
            [TestCase(50)]
            public void IsNuclearShouldReturnValidTrueBoolean(int level)
            {
                Weapon weapon = new Weapon("", 1.2, level);
                Assert.IsTrue(weapon.IsNuclear);
            }

            [TestCase(9)]
            [TestCase(0)]
            public void IsNuclearShouldReturnValidFalseBoolean(int level)
            {
                Weapon weapon = new Weapon("", 1.2, level);
                Assert.IsFalse(weapon.IsNuclear);
            }

            [Test]
            public void ConstructorForPlanetShouldInitializeVAlidName()
            {
                Planet planet = new Planet("Planet", 12.2);

                string actualPrice = planet.Name;
                string expectedPrice = "Planet";

                Assert.AreEqual(expectedPrice, actualPrice);
            }

            [Test]
            public void ConstructorForPlanetShouldInitializeVAlidBudget()
            {
                Planet planet = new Planet("Planet", 12.2);

                double actualPrice = planet.Budget;
                double expectedPrice = 12.2;

                Assert.AreEqual(expectedPrice, actualPrice);
            }

            [Test]
            public void ConstructorForPlanetShouldInitializeNewListOfWeapons()
            {

                List<Weapon> weapons = new List<Weapon>();
                Planet planet = new Planet("Planet", 12.2);

                CollectionAssert.AreEqual(weapons, planet.Weapons);
            }

            [TestCase("m")]
            [TestCase("  ")]
            [TestCase("very very very long name")]
            public void SetNameShouldInitializeValidNameForPlanet(string name)
            {
                Planet planet = new Planet(name, 12.2);
                string actualLevel = planet.Name;
                string expectedLevel = name;

                Assert.AreEqual(expectedLevel, actualLevel);
            }

            [TestCase(null)]
            [TestCase("")]
            public void SetShouldTrowExceptionForInvalidNAmeForPlanet(string name)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet p = new Planet(name, 12);

                }, "Invalid planet Name");

            }
            [TestCase(0)]
            [TestCase(5)]
            [TestCase(100000)]
            public void SetShouldInitializeValidBudgetForPlanet(double budget)
            {
                Planet planet = new Planet("N", budget);
                double actualLevel = planet.Budget;
                double expectedLevel = budget;

                Assert.AreEqual(expectedLevel, actualLevel);
            }

            [TestCase(-1)]
            [TestCase(-100)]
            public void SetShouldTrowExceptionForInvalidBudgetForPlanet(double b)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet p = new Planet("N", b);

                }, "Budget cannot drop below Zero!");

            }


            [Test]
            public void AddWeaponShouldTrowExceptionForExistingWeapon()
            {

                Assert.Throws<InvalidOperationException>(() =>
                {

                    Planet planet = new Planet("N", 12);

                    planet.AddWeapon(new Weapon("w", 2, 100));
                    planet.AddWeapon(new Weapon("w", 4, 100));
                }, $"There is already a w weapon.");

            }

            [Test]
            public void MilotaryPowerRatioShouldReturnSumOfAllWeaponsDestructionLevel()
            {

                Planet planet = new Planet("N", 12);

                planet.AddWeapon(new Weapon("w", 2, 100));
                planet.AddWeapon(new Weapon("w2", 4, 100));


                Assert.AreEqual(200, planet.MilitaryPowerRatio);

            }

            [Test]
            public void ProfitShouldIncreaseBudget()
            {

                Planet planet = new Planet("N", 12);

                planet.Profit(8);

                Assert.AreEqual(20, planet.Budget);

            }

            [TestCase(12)]
            [TestCase(4)]
            public void ProfitShouldDecreaseBudget(double am)
            {

                Planet planet = new Planet("N", 12);

                planet.SpendFunds(am);

                Assert.AreEqual(12 - am, planet.Budget);

            }

            [TestCase(13)]
            [TestCase(50)]
            public void ProfitShouldTrowExceprionForBiggerAmountBudget(double am)
            {
                Assert.Throws<InvalidOperationException>(() =>
                {
                    Planet planet = new Planet("N", 12);

                    planet.SpendFunds(am);

                }, "Not enough funds to finalize the deal.");

            }

            [Test]
            public void RemoveWeaponShouldBeVAlid()
            {
                Planet planet = new Planet("N", 12);

                planet.AddWeapon(new Weapon("w", 2, 100));
                planet.AddWeapon(new Weapon("w2", 4, 100));

                planet.RemoveWeapon("w2");

                Weapon notFound = planet.Weapons.FirstOrDefault(x => x.Name == "w2");

                Assert.AreEqual(notFound, null);
            }

            [Test]
            public void UpdateWeaponShouldBeVAlid()
            {
                Planet planet = new Planet("N", 12);

                planet.AddWeapon(new Weapon("w", 2, 100));
                planet.AddWeapon(new Weapon("w2", 4, 100));


                planet.UpgradeWeapon("w2");

                int expected = 101;
                int actual = planet.Weapons.FirstOrDefault(x => x.Name == "w2").DestructionLevel;

                Assert.AreEqual(expected, actual);
            }

            [Test]
            public void UpdateWeaponShouldBeTrowExceptionForNotExistingWeapon()
            {

                Assert.Throws<InvalidOperationException>(() =>
                {

                    Planet planet = new Planet("N", 12);

                    planet.AddWeapon(new Weapon("w", 2, 100));
                    planet.AddWeapon(new Weapon("w2", 4, 100));


                    planet.UpgradeWeapon("w3");

                }, $"w3 does not exist in the weapon repository of N");

            }

            [Test]

            public void DestructOpponentShouldTrowException()
            {

                Assert.Throws<InvalidOperationException>(() =>
                {

                    Planet planet = new Planet("N", 12);
                    Planet planet2 = new Planet("N2", 12);

                    planet.AddWeapon(new Weapon("w", 2, 100));
                    planet.AddWeapon(new Weapon("w2", 4, 100));

                    planet2.AddWeapon(new Weapon("w", 2, 100));
                    planet2.AddWeapon(new Weapon("w2", 4, 100));


                    string resulr = planet.DestructOpponent(planet2);

                }, $"N2 is too strong to declare war to!");

            }

            [Test]
            public void DestructOpponentShouldBeValid()
            {

                Planet planet = new Planet("N", 12);
                Planet planet2 = new Planet("N2", 12);

                planet.AddWeapon(new Weapon("w", 2, 100));
                planet.AddWeapon(new Weapon("w2", 4, 100));

                planet2.AddWeapon(new Weapon("w", 2, 50));
                planet2.AddWeapon(new Weapon("w2", 4, 50));


                Assert.AreEqual($"N2 is destructed!", planet.DestructOpponent(planet2));
            }

        }
    }
}
