using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ComponentRemover
    {
        private static ComponentGenerator Instance { get; set; }

        public ComponentGenerator GetInstance()
        {
            if (Instance is null)
            {
                Instance = new ComponentGenerator();
            }

            return Instance;
        }

        public string RemovePersona (string Dni)
        {
            var context = StaticReferences.Context;
            var personas = context.PersonaDbSet;

            var persona = personas.SingleOrDefault(p => p.Dni.Equals(Dni));
            if (personas.Contains(persona))
            {
                personas.Remove(persona);
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
