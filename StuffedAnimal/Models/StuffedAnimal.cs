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

    public string GetName()
    {
      return _name;
    }

    public int GetId()
    {
      return _id;
    }

    public override bool Equals(System.Object otherAnimal)
    {
      if (!(otherAnimal is StuffedAnimal))
      {
        return false;
      }
      else
      {
        StuffedAnimal newAnimal = (StuffedAnimal) otherAnimal;
        bool nameEquality = (this.GetName() == newAnimal.GetName());
        return nameEquality;
      }
    }

    public static List<StuffedAnimal> GetAll()
    {
      List<StuffedAnimal> newAnimalList = new List<StuffedAnimal> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM animals;";
      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      while (rdr.Read())
      {
        int animalId = rdr.GetInt32(0);
        string animalName = rdr.GetString(1);
        StuffedAnimal newAnimal = new StuffedAnimal(animalName, animalId);
        newAnimalList.Add(newAnimal);
      }
      return newAnimalList;
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();

      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `animals` (`name`) VALUES (@Name);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@Name";
      name.Value = this._name;
      cmd.Parameters.Add(name);

      cmd.ExecuteNonQuery();
      _id = (int) cmd.LastInsertedId;
    }

    public static void DeleteAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM animals;";
      cmd.ExecuteNonQuery();
    }

    public static StuffedAnimal Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `animals` WHERE id = @thisId;";

      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);

      var rdr = cmd.ExecuteReader() as MySqlDataReader;

      int animalId = 0;
      string animalName = "";

      while (rdr.Read())
      {
        animalId = rdr.GetInt32(0);
        animalName = rdr.GetString(1);
      }
      StuffedAnimal foundAnimal = new StuffedAnimal(animalName, animalId);
      return foundAnimal;
    }
  }
}
