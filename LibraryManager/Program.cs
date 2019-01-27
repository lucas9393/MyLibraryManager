using System;
using LibraryManager.DBConnection;
using LibraryManager.Model;

namespace LibraryManager
{
    class Program
    {
        static void Main(string[] args)
        {           
            var UI = new UserInterface(new Processor(new EntityDBMethods()));
            UI.MainMenu();
        }
    }
}
