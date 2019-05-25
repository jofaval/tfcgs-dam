using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class PermisosUsuarioViewModel
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool PermisoAdmin { get; set; }
        public bool PermisoAdministrativo { get; set; }
        public bool PermisProfesor { get; set; }
        public bool PermisoAlumno { get; set; }
    }
}
