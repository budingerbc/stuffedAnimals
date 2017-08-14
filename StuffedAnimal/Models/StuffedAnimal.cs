using System;
using System.Collections.Generic;
using StuffedAnimalCollection.Controllers;
using MySql.Data.MySqlClient;

namespace StuffedAnimalCollection.Models
{
  public class StuffedAnimal
  {
    private int _id;
    private string _name;

    public StuffedAnimal(string name, int id = 0)
    {
      _id = id;
      _name = name;
    }

    public override bool Equals(System.Object otherAnimal)
    {
      if (!(otherAnimal is StuffedAnimal))
      {
        return false;
      }
      else
      {
        return false;
      }
    }
  }
}
