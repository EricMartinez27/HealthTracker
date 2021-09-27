using System;
using Microsoft.Data.Sqlite;

namespace AppLibrary
{
  public class Sql
  {
    public static void Query()
    {
      using var connection = new SqliteConnection("Data Source=./AppLibrary/data/healthtracking.db");
      connection.Open();
      var command = connection.CreateCommand();
      command.CommandText =
      @"
        select *
        from dailyProgress
      ";
      using var reader = command.ExecuteReader();
      while (reader.Read())
      {
        var day = reader.GetInt32(0);
        var weight = reader.GetInt32(1);
        var bmi = reader.GetFloat(2);
        var calories = reader.GetInt32(3);
        Console.WriteLine($"Day : {day}, {weight}, {bmi}, {calories}");
      }
    }

    public static void Update()
    {
       int userDay = 4;
       int userWeight = 175;
       float userBmi = 20.5F;
       int userCalories = 3000;

      using var connection = new SqliteConnection("Data Source=./AppLibrary/data/healthtracking.db");
      connection.Open();
      var command = connection.CreateCommand();
      command.CommandText = 
      @"
        UPDATE dailyProgress
        SET weight = $newweight, bmi = $newbmi, calories = $newcalories
        WHERE day = $day;
        ";

        command.Parameters.AddWithValue("$day", userDay);
        command.Parameters.AddWithValue("$newweight", userWeight);
        command.Parameters.AddWithValue("$newbmi", userBmi);
        command.Parameters.AddWithValue("$newcalories", userCalories);

        using var reader = command.ExecuteReader();
    }

    public static void Delete()
    {
       int userDay = 7;
     
      using var connection = new SqliteConnection("Data Source=./AppLibrary/data/healthtracking.db");
      connection.Open();
      var command = connection.CreateCommand();
      command.CommandText = 
      @"
        DELETE
        FROM dailyProgress
        WHERE day = $day;
        ";

        command.Parameters.AddWithValue("$day", userDay);

        using var reader = command.ExecuteReader();
  }
  }
}


