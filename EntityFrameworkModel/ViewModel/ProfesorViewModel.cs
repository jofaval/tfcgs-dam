using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class ProfesorViewModel : IHasName
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public Departamento Departamento { get; set; }
        public string Funcion { get; set; }
        public string Email { get; set; }
    }
}
