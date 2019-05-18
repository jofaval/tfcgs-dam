using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ComponentRemover
    {
        private static ComponentRemover Instance { get; set; }

        public static ComponentRemover GetInstance()
        {
            if (Instance is null)
            {
                Instance = new ComponentRemover();
            }

            return Instance;
        }

        public string RemovePersona (string Dni)
        {
            var context = StaticReferences.Context;
            var personas = context.PersonaDbSet.ToList();

            var persona = personas.SingleOrDefault(p => p.Dni.Equals(Dni));
            if (personas.Contains(persona))
            {
                context.PersonaDbSet.Remove(persona);
                context.SaveChanges();
                return Constants.SuccessRemovingEntity;
            }
            else
            {
                return Constants.FailureRemovingEntity;
            }
        }
    }
}
