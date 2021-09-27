using System;
using AppLibrary;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
           Sql.Update();
           Sql.Delete();
           Sql.Query();

        }
    }
}
