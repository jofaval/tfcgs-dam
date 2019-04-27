using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Controller;
using EntityFrameworkModel;
using EntityFrameworkModel.Model;

namespace AlgorithmTester
{
    class Program
    {

        static public AbastosDbContext Context;
        static public DataGenerator Generator;
        static public Random RandomGenerator;

        static private void LoadData()
        {
            Context = new AbastosDbContext();
            Generator = DataGenerator.GetInstance();
            RandomGenerator = new Random(DateTime.Now.Millisecond);
            //LoadPersonal();
            //LoadUsuarios();
            LoadProfesores();
            Context.SaveChanges();
        }

        static private void LoadProfesores()
        {
            var personas = Context.PersonaDbSet;
            var personasLen = personas.Count();
            var trabajadores = Context.TrabajadorDbSet;
            var profesores = Context.ProfesorDbSet;

            var departamento = new Departamento()
            {
                Cod = "INF",
                Nombre = "Test"
            };

            var numProfesores = 150;

            for (int profesorIterator = 0; profesorIterator < numProfesores; profesorIterator++)
            {
                var persona = personas.OrderBy(p => p.Dni).Skip(Generator.RandomNumberBetween(personasLen)).Take(1).First();

                if (!trabajadores.Any(t => t.Persona.Equals(persona.Dni)))
                {
                    var randomDate = Generator.RandomDate(1990);
                    var trabjador = new Trabajador()
                    {
                        Persona = persona.Dni,
                        Persona1 = persona,
                        FechaIncorporacion = randomDate,
                        Sueldo = Generator.RandomNumberBetween(2200, 1600),
                    };
                    trabajadores.Add(trabjador);

                    var profesor = new Profesor()
                    {
                        Trabajador = persona.Dni,
                        Trabajador1 = trabjador,
                        FechaIncorporacion = randomDate,
                        Departamento = departamento.Cod,
                        Departamento1 = departamento,
                    };
                    profesores.Add(profesor);
                    Context.SaveChanges();
                }
                else
                {
                    profesorIterator--;
                }
            }
        }

        //Dni	  Nif	   Calle	        CodigoPostal  Patio	 Piso  Puerta Nombre  Apellidos	        FechaNacimiento	        Email
        //%08d%c  K%07d%c  Noemy Village	2392	      698    700   210	  Steven  Drinks Kennebeck  1900-01-01 00:00:00.000	Steven.Drinks.Kennebeck @yahoo.es
        static private void LoadPersonal()
        {
            var personas = Context.PersonaDbSet;
            var alumnos = Context.AlumnoDbSet;
            var numPersonas = 150;
            for (int personIterator = 0; personIterator < numPersonas; personIterator++)
            {
                var dni = Generator.GenerateDNI();

                if (!personas.Any((p) => p.Dni == dni))
                {
                    var nif = Generator.GenerateNIF();
                    if (!personas.Any((p) => p.Nif == nif))
                    {
                        var nombre = Generator.GenerateFirstName();
                        var apellidos = string.Concat(Generator.GenerateSurName(), " ", Generator.GenerateSurName());
                        var numExpediente = Generator.RandomNumberBetween(999999999).ToString();
                        var fechaNacimiento = Generator.RandomDate();
                        var fechaMatriculacion = Generator.RandomDate();

                        if (!alumnos.Any((a) => a.NumExpediente == numExpediente))
                        {

                            var person = new Persona()
                            {
                                Dni = dni,
                                Nif = nif,
                                Calle = Faker.Address.StreetName(),
                                CodigoPostal = (RandomGenerator.Next(52999) + 1).ToString(),
                                Patio = (RandomGenerator.Next(1000) + 1).ToString(),
                                Piso = (RandomGenerator.Next(999) + 1).ToString(),
                                Puerta = (RandomGenerator.Next(999) + 1).ToString(),
                                Nombre = nombre,
                                Apellidos = apellidos,
                                FechaNacimiento = fechaNacimiento,
                                Email = Generator.GenerateEmail(string.Concat(nombre, " ", apellidos))
                            };
                            personas.Add(person);
                            var alumno = new Alumno()
                            {
                                Persona = person.Dni,
                                NumExpediente = numExpediente,
                                FechaMatriculacion = fechaMatriculacion,
                            };
                            alumnos.Add(alumno);
                            Context.SaveChanges();
                        }
                        else
                        {
                            personIterator--;
                        }
                    }
                    else
                    {
                        personIterator--;
                    }
                }
                else
                {
                    personIterator--;
                }
            }
        }

        static private void LoadUsuarios()
        {
            var numUsuarios = 50;
            var usuarios = Context.UsuarioDbSet;
            var personas = Context.PersonaDbSet;
            var personasLen = personas.Count();
            var permisos = Context.PermisosUsuarioDbSet;

            var permisosLen = 10;

            for (int permiseIterator = 0; permiseIterator < permisosLen; permiseIterator++)
            {
                var nombre = Faker.Name.FullName() + Faker.Name.Suffix();
                if (!permisos.Any((p) => p.Nombre == nombre))
                {
                    var permiso = new PermisosUsuario()
                    {
                        Nombre = nombre,
                        Descripcion = "",
                        PermisoAdmin = RandomGenerator.Next(100) < 5,
                        PermisoAdministrativo = RandomGenerator.Next(100) < 50,
                        PermisoAlumno = RandomGenerator.Next(100) < 50,
                        PermisProfesor = RandomGenerator.Next(100) < 50
                    };

                    permisos.Add(permiso);
                    Context.SaveChanges();
                }
                else
                {
                    permiseIterator--;
                }
            }

            var permisos2 = Context.PermisosUsuarioDbSet.ToList();
            permisosLen = permisos.Count() - 1;
            var personas2 = personas.ToList();
            personasLen = personas2.Count() - 1;

            for (int userIterator = 0; userIterator < numUsuarios; userIterator++)
            {
                var persona = personas2.ElementAt(RandomGenerator.Next(personasLen));
                var dni = persona.Dni;
                if (!usuarios.Any((u) => u.Persona == dni))
                {
                    var permiso = permisos2.ElementAt(RandomGenerator.Next(permisosLen));
                    var fullname = persona.Nombre + " " + persona.Apellidos;
                    var usuario = new Usuario()
                    {
                        Nombre = permiso.Nombre,
                        Username = persona.Nombre,
                        Contrasenya = Generator.GeneratePassword(),
                        PermisosUsuario = permiso,
                        Persona = dni,
                        //Persona1 = persona
                    };

                    usuarios.Add(usuario);
                    Context.SaveChanges();
                }
                else
                {
                    userIterator--;
                }
            }
        }

        static private void LoadCursos()
        {
            var cursos = Context.CursoDbSet;
            var numCursos = 50;
            for (int cursoIterator = 0; cursoIterator < numCursos; cursoIterator++)
            {
                var probability = RandomGenerator.Next(100);
                if (probability <= 33)
                {//ESO

                }
                else if (probability <= 66)
                {//Bachiller

                }
                else
                {//Ciclo Formativo
                    if (probability <= 33)
                    {//Básica

                    }
                    else if (probability <= 66)
                    {//Medio

                    }
                    else
                    {//Superior

                    }
                }
            }
        }

        static void Main(string[] args)
        {
            /*var path = System.Environment.CurrentDirectory;
            var file = new FileInfo(path);
            Console.WriteLine(path);
            Console.ReadLine();
            var db = new AbastosDbContext();
            var list = db.PersonaDbSet;
            list.Add(new Persona()
            {
                Dni = "12345678D",
                Nif = "12346578D",
                Nombre = "El primero",
                Calle = "ergreghrewg",
                CodigoPostal = "6002",
                Patio = "21",
                Piso = "12",
                Puerta = "12",
                Apellidos = "ergreghrewg",
                FechaNacimiento = new DateTime(1998,12,29),
                Email = "ergreghrewg",
            });
            db.SaveChanges();*/

            //CARGAR DATOS EN LA BASE DE DATOS
            LoadData();

            /*string solutiondir = Directory.GetParent(
    Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Controller";

            Console.WriteLine(solutiondir);
            Console.ReadLine();*/
            //Console.ReadLine();

            //SendEmail();

        }

        private static void SendEmail()
        {
            var fromAddress = new MailAddress("r4pepearts@gmail.com");
            var fromPassword = "pass";
            var toAddress = new MailAddress("r4pepearts@gmail.com");

            string subject = "subject";
            string body = "body";

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })


                smtp.Send(message);
        }
    }
}

