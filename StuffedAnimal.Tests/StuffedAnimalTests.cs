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
      // StuffedAnimal.DeleteAll();
    }
    public StuffedAnimalTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=stuffedanimals;";
    }
    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Animal()
    {
      //Arrange
      StuffedAnimal firstAnimal = new StuffedAnimal("bear");
      StuffedAnimal secondAnimal = new StuffedAnimal("bear");

      Assert.AreEqual(firstAnimal, secondAnimal);
    }
  }
}
