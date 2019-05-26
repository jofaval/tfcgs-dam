using Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gestion_AcademicoAdministrativa_Abastos.Threads
{
    public class RobotoProfesorGuardia
    {
        public static void Run()
        {
            while (true)
            {
                Thread.Sleep(Constants.SleepTimeProfesorGuardiaRoboto);
            }
        }

        public static Thread CreateThread()
        {
            return new Thread(Run);
        }
    }
}
