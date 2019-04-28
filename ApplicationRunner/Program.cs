using Gestion_AcademicoAdministrativa_Abastos;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;

namespace ApplicationRunner
{
    class Program
    {
        public LogIn loginWindow = new LogIn();
        static void Main(string[] args)
        {
            Console.WriteLine(DataGenerator.GetInstance().GenerateEmail());

            //Program p = new Program();
            //ControladorWPF.ChangeVisibility(p.loginWindow);
            Console.ReadLine();
        }
    }
}
