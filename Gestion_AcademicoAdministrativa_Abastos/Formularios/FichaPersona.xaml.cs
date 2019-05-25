using Controller;
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
            var comboBoxTrabajadorTypeItems = ComboBoxTrabajadorType.Items;
            var trabajadoresEnumValues = Enum.GetValues(typeof(TrabajadoresEnum)).Cast<TrabajadoresEnum>();
            foreach (var trabajadorTypeFromEnum in trabajadoresEnumValues)
            {
                comboBoxTrabajadorTypeItems.Add(trabajadorTypeFromEnum);
            }
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
                TxtCodigoPostal.Text = persona.CodigoPostal;
                FechaNacmimiento.Value = persona.FechaNacimiento;
                var alumno = persona.Alumno;
                if (alumno != null)
                {
                    FillAlumnoWithData(alumno);
                }
            }
        }

        public void FillAlumnoWithData(Alumno alumno)
        {
            TxtNumExpediente.Text = alumno.NumExpediente;
            TxtNIA.Text = alumno.NumExpediente;
            FechaMatriculacion.Value = alumno.FechaMatriculacion;
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
            TxtCodigoPostal.Text = emptyString;
            FechaNacmimiento.Value = new DateTime();
            SelectedPersona = null;
            ClearAlumno();
        }

        public void ClearAlumno()
        {
            TxtNumExpediente.Text = string.Empty;
            TxtNIA.Text = string.Empty;
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
                || string.IsNullOrWhiteSpace(codigoPostal))
            {
                Notification.CreateNotificaion("Se ha de rellenar la dirección completa.");
                return;
            }

            Notification.CreateNotificaion(ComponentGenerator.GetInstance().CreatePersona(dni, nif, nombre, apellidos, email, calle, patio, piso, puerta, codigoPostal, FechaNacmimiento.Value.Value));
        }

        private void ModifyPersona_Click(object sender, RoutedEventArgs e)
        {
            var notification = ConfirmNotification.CreateNotificaion();
            DynamicMojo.SwapMethodBodies(
                typeof(ConfirmNotification).GetMethod(nameof(notification.DoWhenFinished)),
                typeof(FichaPersona).GetMethod(nameof(ModifyContent))
            );
        }

        public void ModifyContent()
        {
            Notification.CreateNotificaion("Funciona");
            if (SelectedPersona != null)
            {
                XamlBridge.FichaPersona.TxtNombre.Text = XamlBridge.FichaPersona.TxtNombre.Text + "Funciona";
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

            Notification.CreateNotificaion(ComponentGenerator.GetInstance().CreateAlumno(SelectedPersona, numExpediente, nia, selectedDate));
        }

        private void ModifyAlumno_Click(object sender, RoutedEventArgs e)
        {
            var alumno = SelectedPersona.Alumno;
            alumno.NumExpediente = TxtNumExpediente.Text;
            alumno.FechaMatriculacion = FechaMatriculacion.Value.Value;
            SelectedPersona.Alumno = alumno;
            StaticReferences.Context.Entry(alumno).State = System.Data.Entity.EntityState.Modified;
            StaticReferences.Context.SaveChanges();
        }

        private void RemoveAlumno_Click(object sender, RoutedEventArgs e)
        {
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
                    if (trabajador.Profesor is null)
                    {
                        trabajador.Profesor = new Profesor()
                        {
                            Departamento = selectedDepartamentoProfesor.Cod,
                            Departamento1 = selectedDepartamentoProfesor,
                            FechaIncorporacion = FechaIncorporacion.Value.Value,
                        };
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
                    if (trabajador.Profesor != null)
                    {
                        trabajador.Profesor = new Profesor()
                        {
                            Departamento = selectedDepartamentoProfesor.Cod,
                            Departamento1 = selectedDepartamentoProfesor,
                            FechaIncorporacion = FechaIncorporacion.Value.Value,
                        };
                        StaticReferences.Context.ProfesorDbSet.Add(trabajador.Profesor);
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
                StaticReferences.Context.TrabajadorDbSet.Remove(trabajador);
                StaticReferences.Context.SaveChanges();
            }
        }

        private void ComboBoxTrabajadorType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox senderAsComboBox)
            {
                var selectedValue = (TrabajadoresEnum)senderAsComboBox.SelectedValue;
                SelectedTrabajadorEnum = selectedValue;
                var childrens = RolGrid.Children;
                childrens.Clear();
                var trabajador = SelectedPersona.Trabajador;
                switch (selectedValue)
                {
                    case TrabajadoresEnum.Profesor:
                    case TrabajadoresEnum.Administrativo:
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

                        var labelFuncionAdministrativo = new Label()
                        {
                            Content = "Funcion",
                        };
                        childrens.Add(labelFuncionAdministrativo);
                        Grid.SetRow(labelFuncionAdministrativo, 0);
                        Grid.SetColumn(labelFuncionAdministrativo, 2);

                        var txtFuncionAdministrativo = new TextBox()
                        {
                            Name = "TxtFunctionTrabajador",
                        };
                        childrens.Add(txtFuncionAdministrativo);
                        Grid.SetRow(txtFuncionAdministrativo, 1);
                        Grid.SetColumn(txtFuncionAdministrativo, 2);
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
                    if (context.ProfesorDbSet.Contains(trabajador.Profesor))
                    {
                        context.ProfesorDbSet.Remove(trabajador.Profesor);
                    }
                    trabajador.Profesor = null;
                    break;
                case TrabajadoresEnum.Administrativo:
                    if (context.AdministrativoDbSet.Contains(trabajador.Administrativo))
                    {
                        context.AdministrativoDbSet.Remove(trabajador.Administrativo);
                    }
                    trabajador.Administrativo = null;
                    break;
                case TrabajadoresEnum.Especial:
                    if (context.EspecialDbSet.Contains(trabajador.Especial))
                    {
                        context.EspecialDbSet.Remove(trabajador.Especial);
                    }
                    trabajador.Especial = null;
                    break;
                case TrabajadoresEnum.Mantenimiento:
                    if (context.MantenimientoDbSet.Contains(trabajador.Mantenimiento))
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
    }
}