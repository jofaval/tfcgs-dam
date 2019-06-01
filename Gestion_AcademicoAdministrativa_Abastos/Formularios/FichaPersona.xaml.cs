using Controller;
using Gestion_AcademicoAdministrativa_Abastos.Classes;
using Gestion_AcademicoAdministrativa_Abastos.CustomElements;
using Model;
using Model.DataStructure;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gestion_AcademicoAdministrativa_Abastos.Formularios
{
    /// <summary>
    /// Lógica de interacción para FichaPersona.xaml
    /// </summary>
    public partial class FichaPersona : Window
    {
        public Persona SelectedPersona { get; set; }
        public TrabajadoresEnum SelectedTrabajadorEnum { get; set; }

        public FichaPersona()
        {
            DataContext = this;
            InitializeComponent();
            ComboBoxTrabajadorType.ItemsSource = Enum.GetValues(typeof(TrabajadoresEnum)).Cast<TrabajadoresEnum>();
            ComboBoxCurso.ItemsSource = StaticReferences.Context.CursoDbSet.ToList();

            TxtDNI.PreviewTextInput += Restrictions.AlphaNumericText;
            TxtNIF.PreviewTextInput += Restrictions.AlphaNumericText;
            TxtNombre.PreviewTextInput += Restrictions.AlphaNumericText;
            TxtApellidos.PreviewTextInput += Restrictions.AlphaNumericText;
            TxtEmail.PreviewTextInput += Restrictions.AlphaNumericText;
            TxtCalle.PreviewTextInput += Restrictions.AlphaNumericText;
            TxtPatio.PreviewTextInput += Restrictions.NumericOnlyText;
            TxtPiso.PreviewTextInput += Restrictions.NumericOnlyText;
            TxtPuerta.PreviewTextInput += Restrictions.NumericOnlyText;
            TxtProvincia.PreviewTextInput += Restrictions.AlphabetOnlyText;
            TxtLocalidad.PreviewTextInput += Restrictions.AlphabetOnlyText;
            TxtCodigoPostal.PreviewTextInput += Restrictions.NumericOnlyText;
            TxtNumExpediente.PreviewTextInput += Restrictions.NumericOnlyText;
            TxtNIA.PreviewTextInput += Restrictions.AlphaNumericText;
            TxtSueldo.PreviewTextInput += Restrictions.NumericOnlyText;
            TxtTelefono.PreviewTextInput += Restrictions.NumericOnlyText;
            TxtComentario.PreviewTextInput += Restrictions.AlphaNumericText;
        }

        public void FillWithData(Persona persona)
        {
            if (persona != null)
            {
                SelectedPersona = persona;
                SelectedPersonaLabel.Content = persona.ToString();
                TxtDNI.Text = persona.Dni;
                TxtNIF.Text = persona.Nif;
                TxtNombre.Text = persona.Nombre;
                TxtApellidos.Text = persona.Apellidos;
                TxtEmail.Text = persona.Email;
                TxtCalle.Text = persona.Calle;
                TxtPatio.Text = persona.Patio;
                TxtPiso.Text = persona.Piso;
                TxtPuerta.Text = persona.Puerta;
                TxtProvincia.Text = persona.Provincia;
                TxtLocalidad.Text = persona.Localidad;
                TxtCodigoPostal.Text = persona.CodigoPostal;
                FechaNacmimiento.Value = persona.FechaNacimiento;
                var alumno = persona.Alumno;
                if (alumno != null)
                {
                    FillAlumnoWithData(alumno);
                }
                var trabajador = persona.Trabajador;
                if (trabajador != null)
                {
                    FillTrabajadorWithData(trabajador);
                }
            }
        }

        public void FillAlumnoWithData(Alumno alumno)
        {
            TxtNumExpediente.Text = alumno.NumExpediente;
            TxtNIA.Text = alumno.NIA;
            FechaMatriculacion.Value = alumno.FechaMatriculacion;
            ComboBoxCurso.SelectedValue = StaticReferences.Context.CursoDbSet
                .SingleOrDefault(c => c.Cod.Equals(alumno.CursoCod)
                && c.Nombre.Equals(alumno.CursoNombre));
        }

        public void FillTrabajadorWithData(Trabajador trabajador)
        {
            TxtSueldo.Text = trabajador.Sueldo.ToString();
            FechaIncorporacion.Value = trabajador.FechaIncorporacion;
            if (trabajador.Profesor != null)
            {
                ComboBoxTrabajadorType.SelectedValue = TrabajadoresEnum.Profesor;
                return;
            }
            else if (trabajador.Administrativo != null)
            {
                ComboBoxTrabajadorType.SelectedValue = TrabajadoresEnum.Administrativo;
            }
            else if (trabajador.Mantenimiento != null)
            {
                ComboBoxTrabajadorType.SelectedValue = TrabajadoresEnum.Mantenimiento;
            }
            else if (trabajador.Especial != null)
            {
                ComboBoxTrabajadorType.SelectedValue = TrabajadoresEnum.Especial;
            }
            ComboBoxTrabajadorType_SelectionChanged(ComboBoxTrabajadorType, null);
        }

        public void ClearPersonaData()
        {
            var emptyString = string.Empty;
            TxtDNI.Text = emptyString;
            TxtNIF.Text = emptyString;
            TxtNombre.Text = emptyString;
            TxtApellidos.Text = emptyString;
            TxtEmail.Text = emptyString;
            TxtCalle.Text = emptyString;
            TxtPatio.Text = emptyString;
            TxtPiso.Text = emptyString;
            TxtPuerta.Text = emptyString;
            TxtProvincia.Text = emptyString;
            TxtLocalidad.Text = emptyString;
            TxtCodigoPostal.Text = emptyString;
            FechaNacmimiento.Value = new DateTime();
            SelectedPersona = null;
            ClearAlumno();
        }

        public void ClearAlumno()
        {
            TxtNumExpediente.Text = string.Empty;
            TxtNIA.Text = string.Empty;
            FechaMatriculacion.Value = null;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            var persona = DataRetriever.GetInstance().GetPersona(TxtDniSearch.Text);
            if (persona is null)
            {
                Notification.CreateNotificaion(Constants.NoResults);
            }
            else
            {
                FillWithData(persona);
            }
        }

        private void CreatePersona_Click(object sender, RoutedEventArgs e)
        {
            var dni = TxtDNI.Text;
            var nif = TxtNIF.Text;
            var nombre = TxtNombre.Text;
            var apellidos = TxtApellidos.Text;
            var email = TxtEmail.Text;
            var calle = TxtCalle.Text;
            var patio = TxtPatio.Text;
            var piso = TxtPiso.Text;
            var puerta = TxtPuerta.Text;
            var codigoPostal = TxtCodigoPostal.Text;
            var provincia = TxtProvincia.Text;
            var localidad = TxtLocalidad.Text;

            if (string.IsNullOrWhiteSpace(dni))
            {
                Notification.CreateNotificaion("El campo DNI es obligatorio");
                return;
            }
            else if (string.IsNullOrWhiteSpace(nif))
            {
                Notification.CreateNotificaion("El campo NIF es obligatorio");
                return;
            }
            else if (string.IsNullOrWhiteSpace(nombre))
            {
                Notification.CreateNotificaion("El campo Nombre es obligatorio");
                return;
            }
            else if (string.IsNullOrWhiteSpace(apellidos))
            {
                Notification.CreateNotificaion("El campo Apellidos es obligatorio");
                return;
            }
            else if (string.IsNullOrWhiteSpace(email))
            {
                Notification.CreateNotificaion("El campo Email es obligatorio");
                return;
            }
            else if (string.IsNullOrWhiteSpace(calle)
                || string.IsNullOrWhiteSpace(patio)
                || string.IsNullOrWhiteSpace(piso)
                || string.IsNullOrWhiteSpace(puerta)
                || string.IsNullOrWhiteSpace(codigoPostal)
                || string.IsNullOrWhiteSpace(provincia)
                || string.IsNullOrWhiteSpace(localidad))
            {
                Notification.CreateNotificaion("Se ha de rellenar la dirección completa.");
                return;
            }

            Notification.CreateNotificaion(ComponentGenerator.GetInstance().CreatePersona(dni, nif, nombre, apellidos, email, calle, patio, piso, puerta, codigoPostal, FechaNacmimiento.Value.Value, provincia, localidad));
        }

        private void ModifyPersona_Click(object sender, RoutedEventArgs e)
        {
            var notification = ConfirmNotification.CreateNotificaion();
            //DynamicMojo.SwapMethodBodies(
            //    typeof(ConfirmNotification).GetMethod(nameof(notification.DoWhenFinished)),
            //    typeof(FichaPersona).GetMethod(nameof(ModifyContent))
            //);
            notification.WhenDone += ModifyContent;
        }

        public void ModifyContent(object sender, RoutedEventArgs e)
        {
            if (SelectedPersona is null)
            {
                Notification.CreateNotificaion("No se ha seleccionado nignuna persona");
            }
            else
            {
                var dni = TxtDNI.Text;
                var nif = TxtNIF.Text;
                var nombre = TxtNombre.Text;
                var apellidos = TxtApellidos.Text;
                var email = TxtEmail.Text;
                var calle = TxtCalle.Text;
                var patio = TxtPatio.Text;
                var piso = TxtPiso.Text;
                var puerta = TxtPuerta.Text;
                var codigoPostal = TxtCodigoPostal.Text;
                var provincia = TxtProvincia.Text;
                var localidad = TxtLocalidad.Text;

                if (string.IsNullOrWhiteSpace(dni))
                {
                    Notification.CreateNotificaion("El campo DNI es obligatorio");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(nif))
                {
                    Notification.CreateNotificaion("El campo NIF es obligatorio");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(nombre))
                {
                    Notification.CreateNotificaion("El campo Nombre es obligatorio");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(apellidos))
                {
                    Notification.CreateNotificaion("El campo Apellidos es obligatorio");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(email))
                {
                    Notification.CreateNotificaion("El campo Email es obligatorio");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(calle)
                    || string.IsNullOrWhiteSpace(patio)
                    || string.IsNullOrWhiteSpace(piso)
                    || string.IsNullOrWhiteSpace(puerta)
                    || string.IsNullOrWhiteSpace(codigoPostal)
                    || string.IsNullOrWhiteSpace(provincia)
                    || string.IsNullOrWhiteSpace(localidad))
                {
                    Notification.CreateNotificaion("Se ha de rellenar la dirección completa.");
                    return;
                }

                SelectedPersona.Nombre = nombre;
                SelectedPersona.Apellidos = apellidos;
                SelectedPersona.Email = email;
                SelectedPersona.Calle = calle;
                SelectedPersona.Patio = patio;
                SelectedPersona.Piso = piso;
                SelectedPersona.Puerta = puerta;
                SelectedPersona.CodigoPostal = codigoPostal;
                SelectedPersona.Provincia = provincia;
                SelectedPersona.Localidad = localidad;

                StaticReferences.Context.Entry(SelectedPersona).State = System.Data.Entity.EntityState.Modified;
                StaticReferences.Context.SaveChanges();

                Notification.CreateNotificaion("Se ha modificado correctamente");

                FillWithData(SelectedPersona);
            }
        }

        private void RemovePersona_Click(object sender, RoutedEventArgs e)
        {
            StaticReferences.Context.PersonaDbSet.Remove(SelectedPersona);
            StaticReferences.Context.SaveChanges();
            ClearPersonaData();
        }

        private void CreateAlumno_Click(object sender, RoutedEventArgs e)
        {
            var selectedDate = FechaNacmimiento.Value.Value;
            var numExpediente = TxtNumExpediente.Text;
            var nia = TxtNIA.Text;
            var curso = (Curso)ComboBoxCurso.SelectedValue;

            Notification.CreateNotificaion(ComponentGenerator.GetInstance().CreateAlumno(SelectedPersona, numExpediente, nia, selectedDate, curso));
        }

        private void ModifyAlumno_Click(object sender, RoutedEventArgs e)
        {
            var alumno = SelectedPersona.Alumno;
            var cod = alumno.CursoCod;
            var nombre = alumno.CursoNombre;
            var curso = (Curso)ComboBoxCurso.SelectedValue;
            alumno.NumExpediente = TxtNumExpediente.Text;
            alumno.FechaMatriculacion = FechaMatriculacion.Value.Value;
            alumno.CursoCod = curso.Cod;
            alumno.CursoNombre = curso.Nombre;
            SelectedPersona.Alumno = alumno;
            alumno.NIA = TxtNIA.Text;
            var estudio = StaticReferences.Context.EstudiosDbSet.AsEnumerable()
                .SingleOrDefault(es => es.Alumno1.Persona.Equals(alumno.Persona)
                && es.Curso.Equals(curso));
            if (estudio != null)
            {
                estudio.Curso = curso;
                estudio.CursoCod = curso.Cod;
                estudio.CursoNombre = curso.Nombre;
                StaticReferences.Context.Entry(estudio).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                estudio = new Estudio()
                {
                    Alumno = alumno.Persona,
                    Alumno1 = alumno,
                    Curso = curso,
                    CursoCod = curso.Cod,
                    CursoNombre = curso.Nombre,
                };
                StaticReferences.Context.EstudiosDbSet.Add(estudio);
            }
            StaticReferences.Context.Entry(alumno).State = System.Data.Entity.EntityState.Modified;
            StaticReferences.Context.SaveChanges();
        }

        private void RemoveAlumno_Click(object sender, RoutedEventArgs e)
        {
            var alumno = SelectedPersona.Alumno;
            SelectedPersona.Alumno = null;
            StaticReferences.Context.Entry(SelectedPersona).State = System.Data.Entity.EntityState.Modified;
            StaticReferences.Context.SaveChanges();
        }

        private void CreateTrabajador_Click(object sender, RoutedEventArgs e)
        {
            var trabajador = SelectedPersona.Trabajador;
            if (trabajador is null)
            {
                trabajador = new Trabajador()
                {
                    Persona = SelectedPersona.Dni,
                    Persona1 = SelectedPersona,
                    Sueldo = double.Parse(TxtSueldo.Text, CultureInfo.InvariantCulture),
                    FechaIncorporacion = FechaIncorporacion.Value.Value,
                };
                StaticReferences.Context.TrabajadorDbSet.Add(trabajador);
                StaticReferences.Context.SaveChanges();
            }

            switch (SelectedTrabajadorEnum)
            {
                case TrabajadoresEnum.Profesor:
                    var selectedDepartamentoProfesor = (Departamento)XamlFunctionality.FindChild<ComboBox>(Application.Current.MainWindow, "ComboBoxDepartamento").SelectedValue;
                    var selectedCursoProfesor = (Curso)XamlFunctionality.FindChild<ComboBox>(Application.Current.MainWindow, "ComboBoxCursoTutor").SelectedValue;
                    if (trabajador.Profesor is null)
                    {
                        var profesor = new Profesor()
                        {
                            Departamento = selectedDepartamentoProfesor.Cod,
                            Departamento1 = selectedDepartamentoProfesor,
                            FechaIncorporacion = FechaIncorporacion.Value.Value,
                        };
                        trabajador.Profesor = profesor;
                        var currentYear = AdministrativoFunctionality.GetAcademicYear(StaticReferences.CurrentDateTime);
                        var currentTutoritation = new Tutores()
                        {
                            Anyo = currentYear,
                            Curso = selectedCursoProfesor,
                            CursoCod = selectedCursoProfesor.Cod,
                            CursoNombre = selectedCursoProfesor.Nombre,
                            Profesor = profesor.Trabajador,
                            Profesor1 = profesor,
                        };
                        StaticReferences.Context.TutoresDbSet.Add(currentTutoritation);
                        StaticReferences.Context.ProfesorDbSet.Add(trabajador.Profesor);
                        StaticReferences.Context.Entry(trabajador).State = System.Data.Entity.EntityState.Modified;

                    }
                    break;
                case TrabajadoresEnum.Administrativo:
                    var selectedDepartamentoAdministrativo = (Departamento)XamlFunctionality.FindChild<ComboBox>(Application.Current.MainWindow, "ComboBoxDepartamento").SelectedValue;
                    var funcionAdministrativo = XamlFunctionality.FindChild<TextBox>(Application.Current.MainWindow, "TxtFunctionTrabajador").Text;
                    if (trabajador.Administrativo is null)
                    {
                        trabajador.Administrativo = new Administrativo()
                        {
                            Departamento = selectedDepartamentoAdministrativo.Cod,
                            Departamento1 = selectedDepartamentoAdministrativo,
                            Funcion = funcionAdministrativo,
                        };
                        StaticReferences.Context.AdministrativoDbSet.Add(trabajador.Administrativo);
                        StaticReferences.Context.Entry(trabajador).State = System.Data.Entity.EntityState.Modified;
                    }
                    break;
                case TrabajadoresEnum.Especial:
                    var funcionEspecial = XamlFunctionality.FindChild<TextBox>(Application.Current.MainWindow, "TxtFunctionTrabajador").Text;
                    if (trabajador.Especial is null)
                    {
                        trabajador.Especial = new Especial()
                        {
                            Funcion = funcionEspecial,
                        };
                        StaticReferences.Context.EspecialDbSet.Add(trabajador.Especial);
                        StaticReferences.Context.Entry(trabajador).State = System.Data.Entity.EntityState.Modified;
                    }
                    break;
                case TrabajadoresEnum.Mantenimiento:
                    var funcionMantenimiento = XamlFunctionality.FindChild<TextBox>(Application.Current.MainWindow, "TxtFunctionTrabajador").Text;
                    var horarioMantenimiento = XamlFunctionality.FindChild<TextBox>(Application.Current.MainWindow, "TxtHorario").Text;
                    if (trabajador.Mantenimiento is null)
                    {
                        trabajador.Mantenimiento = new Mantenimiento()
                        {
                            Funcion = funcionMantenimiento,
                            Horario = horarioMantenimiento,
                        };
                        StaticReferences.Context.MantenimientoDbSet.Add(trabajador.Mantenimiento);
                        StaticReferences.Context.Entry(trabajador).State = System.Data.Entity.EntityState.Modified;
                    }
                    break;
                default:
                    break;
            }
            StaticReferences.Context.SaveChanges();
        }

        private void ModifyTrabajador_Click(object sender, RoutedEventArgs e)
        {
            var trabajador = SelectedPersona.Trabajador;

            if (trabajador is null)
            {
                Notification.CreateNotificaion("No existe ningún trabajador");
                return;
            }

            switch (SelectedTrabajadorEnum)
            {
                case TrabajadoresEnum.Profesor:
                    var selectedDepartamentoProfesor = (Departamento)XamlFunctionality.FindChild<ComboBox>(Application.Current.MainWindow, "ComboBoxDepartamento").SelectedValue;
                    var selectedCursoProfesor = (Curso)XamlFunctionality.FindChild<ComboBox>(Application.Current.MainWindow, "ComboBoxCursoTutor").SelectedValue;
                    if (trabajador.Profesor is null)
                    {
                        var profesor = new Profesor()
                        {
                            Departamento = selectedDepartamentoProfesor.Cod,
                            Departamento1 = selectedDepartamentoProfesor,
                            FechaIncorporacion = FechaIncorporacion.Value.Value,
                        };
                        trabajador.Profesor = profesor;
                        var currentYear = AdministrativoFunctionality.GetAcademicYear(StaticReferences.CurrentDateTime);
                        var currentTutoritation = trabajador.Profesor.Tutores
                            .SingleOrDefault(t => t.Anyo.Equals(currentYear));
                        if (currentTutoritation is null)
                        {
                            currentTutoritation = new Tutores()
                            {
                                Anyo = currentYear,
                                Curso = selectedCursoProfesor,
                                CursoCod = selectedCursoProfesor.Cod,
                                CursoNombre = selectedCursoProfesor.Nombre,
                                Profesor = profesor.Trabajador,
                                Profesor1 = profesor,
                            };
                            StaticReferences.Context.TutoresDbSet.Add(currentTutoritation);
                            profesor.Tutores.Add(currentTutoritation);
                        }
                        else
                        {
                            currentTutoritation.Curso = selectedCursoProfesor;
                        }
                        StaticReferences.Context.Entry(currentTutoritation).State = System.Data.Entity.EntityState.Modified;
                        StaticReferences.Context.ProfesorDbSet.Add(profesor);
                        StaticReferences.Context.Entry(trabajador).State = System.Data.Entity.EntityState.Modified;
                    }
                    break;
                case TrabajadoresEnum.Administrativo:
                    var selectedDepartamentoAdministrativo = (Departamento)XamlFunctionality.FindChild<ComboBox>(Application.Current.MainWindow, "ComboBoxDepartamento").SelectedValue;
                    var funcionAdministrativo = XamlFunctionality.FindChild<TextBox>(Application.Current.MainWindow, "TxtFunctionTrabajador").Text;
                    if (trabajador.Administrativo != null)
                    {
                        trabajador.Administrativo = new Administrativo()
                        {
                            Departamento = selectedDepartamentoAdministrativo.Cod,
                            Departamento1 = selectedDepartamentoAdministrativo,
                            Funcion = funcionAdministrativo,
                        };
                        StaticReferences.Context.AdministrativoDbSet.Add(trabajador.Administrativo);
                        StaticReferences.Context.Entry(trabajador).State = System.Data.Entity.EntityState.Modified;
                    }
                    break;
                case TrabajadoresEnum.Especial:
                    var funcionEspecial = XamlFunctionality.FindChild<TextBox>(Application.Current.MainWindow, "TxtFunctionTrabajador").Text;
                    if (trabajador.Especial != null)
                    {
                        trabajador.Especial = new Especial()
                        {
                            Funcion = funcionEspecial,
                        };
                        StaticReferences.Context.EspecialDbSet.Add(trabajador.Especial);
                        StaticReferences.Context.Entry(trabajador).State = System.Data.Entity.EntityState.Modified;
                    }
                    break;
                case TrabajadoresEnum.Mantenimiento:
                    var funcionMantenimiento = XamlFunctionality.FindChild<TextBox>(Application.Current.MainWindow, "TxtFunctionTrabajador").Text;
                    var horarioMantenimiento = XamlFunctionality.FindChild<TextBox>(Application.Current.MainWindow, "TxtHorario").Text;
                    if (trabajador.Mantenimiento != null)
                    {
                        trabajador.Mantenimiento = new Mantenimiento()
                        {
                            Funcion = funcionMantenimiento,
                            Horario = horarioMantenimiento,
                        };
                        StaticReferences.Context.MantenimientoDbSet.Add(trabajador.Mantenimiento);
                        StaticReferences.Context.Entry(trabajador).State = System.Data.Entity.EntityState.Modified;
                    }
                    break;
                default:
                    break;
            }
            StaticReferences.Context.Entry(trabajador).State = System.Data.Entity.EntityState.Modified;
            StaticReferences.Context.SaveChanges();
        }

        private void RemoveTrabajador_Click(object sender, RoutedEventArgs e)
        {
            var trabajador = SelectedPersona.Trabajador;
            if (trabajador is null)
            {
                Notification.CreateNotificaion("Esta persona no es un trabajador registrado");
            }
            else
            {
                SelectedPersona.Trabajador = null;
                StaticReferences.Context.Entry(SelectedPersona).State = System.Data.Entity.EntityState.Modified;
                StaticReferences.Context.SaveChanges();
            }
        }

        private void ComboBoxTrabajadorType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox senderAsComboBox)
            {
                var selectedValueOrigin = senderAsComboBox.SelectedValue;
                if (selectedValueOrigin is null)
                {
                    return;
                }
                var selectedValue = (TrabajadoresEnum)selectedValueOrigin;
                SelectedTrabajadorEnum = selectedValue;
                var childrens = RolGrid.Children;
                childrens.Clear();
                var trabajador = SelectedPersona.Trabajador;
                switch (selectedValue)
                {
                    case TrabajadoresEnum.Profesor:
                        var labelDepartamento = new Label()
                        {
                            Content = "Departamento",
                        };
                        childrens.Add(labelDepartamento);
                        Grid.SetRow(labelDepartamento, 0);
                        Grid.SetColumn(labelDepartamento, 0);

                        var departamento = new ComboBox
                        {
                            ItemsSource = StaticReferences.Context.DepartamentoDbSet.ToList(),
                            Name = "ComboBoxDepartamento",
                        };
                        childrens.Add(departamento);
                        Grid.SetRow(departamento, 1);
                        Grid.SetColumn(departamento, 0);
                        if (trabajador != null)
                        {
                            if (selectedValue.Equals(TrabajadoresEnum.Profesor))
                            {
                                departamento.SelectedValue = trabajador.Profesor?.Departamento1;
                            }
                            else if (selectedValue.Equals(TrabajadoresEnum.Administrativo))
                            {
                                departamento.SelectedValue = trabajador.Administrativo?.Departamento1;
                            }
                        }

                        var labelTutor = new Label()
                        {
                            Content = "Tutor",
                        };
                        childrens.Add(labelTutor);
                        Grid.SetRow(labelTutor, 0);
                        Grid.SetColumn(labelTutor, 2);

                        var comboBoxTutor = new ComboBox()
                        {
                            Name = "ComboBoxCursoTutor",
                        };
                        comboBoxTutor.ItemsSource = ComboBoxCurso.ItemsSource;
                        childrens.Add(comboBoxTutor);
                        Grid.SetRow(comboBoxTutor, 1);
                        Grid.SetColumn(comboBoxTutor, 2);
                        break;
                    case TrabajadoresEnum.Administrativo:
                        var labelDepartamento2 = new Label()
                        {
                            Content = "Departamento",
                        };
                        childrens.Add(labelDepartamento2);
                        Grid.SetRow(labelDepartamento2, 0);
                        Grid.SetColumn(labelDepartamento2, 0);

                        var departamento2 = new ComboBox
                        {
                            ItemsSource = StaticReferences.Context.DepartamentoDbSet.ToList(),
                            Name = "ComboBoxDepartamento",
                        };
                        childrens.Add(departamento2);
                        Grid.SetRow(departamento2, 1);
                        Grid.SetColumn(departamento2, 0);
                        if (trabajador != null)
                        {
                            if (selectedValue.Equals(TrabajadoresEnum.Profesor))
                            {
                                departamento2.SelectedValue = trabajador.Profesor?.Departamento1;
                            }
                            else if (selectedValue.Equals(TrabajadoresEnum.Administrativo))
                            {
                                departamento2.SelectedValue = trabajador.Administrativo?.Departamento1;
                            }
                        }

                        var labelFuncionAdministrativo2 = new Label()
                        {
                            Content = "Funcion",
                        };
                        childrens.Add(labelFuncionAdministrativo2);
                        Grid.SetRow(labelFuncionAdministrativo2, 0);
                        Grid.SetColumn(labelFuncionAdministrativo2, 2);

                        var txtFuncionAdministrativo2 = new TextBox()
                        {
                            Name = "TxtFunctionTrabajador",
                        };
                        txtFuncionAdministrativo2.PreviewTextInput += Restrictions.AlphabetOnlyText;
                        childrens.Add(txtFuncionAdministrativo2);
                        Grid.SetRow(txtFuncionAdministrativo2, 1);
                        Grid.SetColumn(txtFuncionAdministrativo2, 2);
                        break;
                    case TrabajadoresEnum.Mantenimiento:
                        var labelFuncion = new Label()
                        {
                            Content = "Funcion",
                        };
                        childrens.Add(labelFuncion);
                        Grid.SetRow(labelFuncion, 0);
                        Grid.SetColumn(labelFuncion, 0);

                        var txtFuncion = new TextBox()
                        {
                            Name = "TxtFunctionTrabajador",
                        };
                        txtFuncion.PreviewTextInput += Restrictions.AlphabetOnlyText;
                        childrens.Add(txtFuncion);
                        Grid.SetRow(txtFuncion, 1);
                        Grid.SetColumn(txtFuncion, 0);

                        var labelHorario = new Label()
                        {
                            Content = "Horario",
                        };
                        childrens.Add(labelHorario);
                        Grid.SetRow(labelHorario, 0);
                        Grid.SetColumn(labelHorario, 2);

                        var txtHorario = new TextBox()
                        {
                            Name = "TxtHorario",
                        };
                        txtHorario.PreviewTextInput += Restrictions.AlphabetOnlyText;
                        childrens.Add(txtHorario);
                        Grid.SetRow(txtHorario, 1);
                        Grid.SetColumn(txtHorario, 2);

                        if (trabajador != null)
                        {
                            txtFuncion.Text = trabajador.Mantenimiento?.Funcion;
                            txtHorario.Text = trabajador.Mantenimiento?.Horario;
                        }
                        break;
                    case TrabajadoresEnum.Especial:
                        var labelFuncion2 = new Label()
                        {
                            Content = "TxtFunctionTrabajador",
                        };
                        childrens.Add(labelFuncion2);
                        Grid.SetRow(labelFuncion2, 0);
                        Grid.SetColumn(labelFuncion2, 0);

                        var txtFuncion2 = new TextBox()
                        {
                            Name = "TxtFunction",
                        };
                        txtFuncion2.PreviewTextInput += Restrictions.AlphabetOnlyText;
                        childrens.Add(txtFuncion2);
                        Grid.SetRow(txtFuncion2, 1);
                        Grid.SetColumn(txtFuncion2, 0);

                        if (trabajador != null)
                        {
                            txtFuncion2.Text = trabajador.Especial?.Funcion;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void RemoveTrabajadorRole_Click(object sender, RoutedEventArgs e)
        {
            var selecetedValue = ComboBoxTrabajadorType.SelectedValue;

            if (selecetedValue is null)
            {
                Notification.CreateNotificaion("No has seleccionado ningún rol");
                return;
            }

            var trabajador = SelectedPersona.Trabajador;

            if (trabajador is null)
            {
                Notification.CreateNotificaion("El trabajador no ha sido creado todavía");
                return;
            }

            var context = StaticReferences.Context;
            switch (selecetedValue)
            {
                case TrabajadoresEnum.Profesor:
                    if (context.ProfesorDbSet.AsEnumerable().Contains(trabajador.Profesor))
                    {
                        context.ProfesorDbSet.Remove(trabajador.Profesor);
                    }
                    trabajador.Profesor = null;
                    break;
                case TrabajadoresEnum.Administrativo:
                    if (context.AdministrativoDbSet.AsEnumerable().Contains(trabajador.Administrativo))
                    {
                        context.AdministrativoDbSet.Remove(trabajador.Administrativo);
                    }
                    trabajador.Administrativo = null;
                    break;
                case TrabajadoresEnum.Especial:
                    if (context.EspecialDbSet.AsEnumerable().Contains(trabajador.Especial))
                    {
                        context.EspecialDbSet.Remove(trabajador.Especial);
                    }
                    trabajador.Especial = null;
                    break;
                case TrabajadoresEnum.Mantenimiento:
                    if (context.MantenimientoDbSet.AsEnumerable().Contains(trabajador.Mantenimiento))
                    {
                        context.MantenimientoDbSet.Remove(trabajador.Mantenimiento);
                    }
                    trabajador.Mantenimiento = null;
                    break;
                default:
                    break;
            }
            StaticReferences.Context.Entry(trabajador).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        private void CreateTelefono_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPersona is null)
            {
                Notification.CreateNotificaion("No hay nignuna persona seleccionada");
                return;
            }

            var telefonoText = TxtTelefono.Text;
            var comentario = TxtComentario.Text;

            var telefono = new Telefono()
            {
                Telefono1 = telefonoText,
                Comentario = comentario,
                Persona = SelectedPersona.Dni,
                Persona1 = SelectedPersona,
            };

            if (StaticReferences.Context.TelefonoDbSet
                .AsEnumerable()
                .Contains(telefono))
            {
                Notification.CreateNotificaion("Ya existe");
                return;
            }
            else
            {
                StaticReferences.Context.TelefonoDbSet.Add(telefono);
                StaticReferences.Context.SaveChanges();
                Notification.CreateNotificaion("Se ha añadido con exito");
            }
        }

        private void ModifyTelefono_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPersona is null)
            {
                Notification.CreateNotificaion("No hay nignuna persona seleccionada");
                return;
            }

            var telefonoText = TxtTelefono.Text;

            var telefono = StaticReferences.Context.TelefonoDbSet
                .AsEnumerable()
                .SingleOrDefault(t => t.Persona1.Equals(SelectedPersona)
                && t.Telefono1.Equals(telefonoText));

            if (telefono is null)
            {
                Notification.CreateNotificaion("No se ha encontrado");
                return;
            }
            else
            {
                var comentario = TxtComentario.Text;
                telefono.Comentario = comentario;
                StaticReferences.Context.Entry(telefono).State = System.Data.Entity.EntityState.Modified;
                StaticReferences.Context.SaveChanges();
                Notification.CreateNotificaion("Se ha añadido con exito");
            }
        }

        private void RemoveTelefono_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPersona is null)
            {
                Notification.CreateNotificaion("No hay nignuna persona seleccionada");
                return;
            }

            var telefonoText = TxtTelefono.Text;
            var comentario = TxtComentario.Text;

            var telefono = StaticReferences.Context.TelefonoDbSet
                .SingleOrDefault(t => t.Persona1.Equals(SelectedPersona)
                && t.Telefono1.Equals(telefonoText));

            if (telefono is null)
            {
                Notification.CreateNotificaion("No se ha encontrado");
                return;
            }
            else
            {
                StaticReferences.Context.TelefonoDbSet.Remove(telefono);
                StaticReferences.Context.SaveChanges();
                Notification.CreateNotificaion("Se ha añadido con exito");
            }
        }
    }
}