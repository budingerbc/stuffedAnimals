using Microsoft.VisualStudio.TestTools.UnitTesting;
using StuffedAnimalCollection.Models;
using System;
using System.Collections.Generic;

namespace StuffedAnimalCollection.Test
{
  [TestClass]
  public class StuffedAnimalTests : IDisposable
  {
    public void Dispose()
    {
      StuffedAnimal.DeleteAll();
    }
    public StuffedAnimalTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=stuffedanimals_test;";
    }
    [TestMethod]
    public void GetAll_DatabaseEmptyAtFirst_0()
    {
      int result = StuffedAnimal.GetAll().Count;

      Assert.AreEqual(0, result);
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Animal()
    {
      //Arrange
      StuffedAnimal firstAnimal = new StuffedAnimal("bear");
      StuffedAnimal secondAnimal = new StuffedAnimal("bear");

      Assert.AreEqual(firstAnimal, secondAnimal);
    }
    [TestMethod]
    public void Save_SavesToDatabase_newAnimalList()
    {
      StuffedAnimal testAnimal = new StuffedAnimal("bear");

      testAnimal.Save();
      List<StuffedAnimal> result = StuffedAnimal.GetAll();
      Console.WriteLine(result);
      List<StuffedAnimal> testList = new List<StuffedAnimal>{testAnimal};
      Console.WriteLine(testList);

      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Find_FindsAnimalInDatabase_Animal()
    {
      StuffedAnimal testAnimal = new StuffedAnimal("giraffe");
      testAnimal.Save();

      StuffedAnimal foundAnimal = StuffedAnimal.Find(testAnimal.GetId());

      Assert.AreEqual(testAnimal, foundAnimal);
    }

    [TestMethod]
    public void DeleteAll_DeletesAllDatabaseValues_0()
    {
      StuffedAnimal testAnimal = new StuffedAnimal("giraffe");
      StuffedAnimal animalTwo = new StuffedAnimal("canary");

      testAnimal.Save();
      animalTwo.Save();

      StuffedAnimal.DeleteAll();
      int result = StuffedAnimal.GetAll().Count;

      Assert.AreEqual(0, result);
    }
  }
}
