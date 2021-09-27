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
                var day = reader.GetInt32(1);
                var weight = reader.GetInt32(2);
                var bmi = reader.GetDouble(3);
                var calories = reader.GetInt32(4);
                Console.WriteLine($"Day: {day}, Weight: {weight}, BMI: {bmi}, Calories: {calories}");
            }
        }

        public static void Update()
        {
            int userDay;
            int userWeight;
            double userBmi;
            int userCalories;
            Console.WriteLine("Please enter the day you want to update:");
            userDay = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the weight:");
            userWeight = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the BMI:");
            userBmi = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the calories:");
            userCalories = Convert.ToInt32(Console.ReadLine());

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
            int userDay;
            Console.WriteLine("Please enter the day you want to delete:");
            userDay = Convert.ToInt32(Console.ReadLine());
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


