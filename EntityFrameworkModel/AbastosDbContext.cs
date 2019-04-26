namespace EntityFrameworkModel.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AbastosDbContext : DbContext
    {
        public AbastosDbContext()
            : base("name=Abastos")
        {
        }

        public virtual DbSet<Administrativo> AdministrativoDbSet { get; set; }
        public virtual DbSet<Alumno> AlumnoDbSet { get; set; }
        public virtual DbSet<Asignatura> AsignaturaDbSet { get; set; }
        public virtual DbSet<AsistenciaDiaAsignatura> AsistenciaDiaAsignaturaDbSet { get; set; }
        public virtual DbSet<AsistenciaSemanaAsignatura> AsistenciaSemanaAsignaturaDbSet { get; set; }
        public virtual DbSet<Aula> AulaDbSet { get; set; }
        public virtual DbSet<Bachiller> BachillerDbSet { get; set; }
        public virtual DbSet<Baja> BajaDbSet { get; set; }
        public virtual DbSet<Certificado> CertificadoDbSet { get; set; }
        public virtual DbSet<CertificadoMatricula> CertificadoMatriculaDbSet { get; set; }
        public virtual DbSet<CertificadoNotas> CertificadoNotasDbSet { get; set; }
        public virtual DbSet<CertificadoTitulo> CertificadoTituloDbSet { get; set; }
        public virtual DbSet<Ciclo> CicloDbSet { get; set; }
        public virtual DbSet<Convocatoria> ConvocatoriaDbSet { get; set; }
        public virtual DbSet<Curso> CursoDbSet { get; set; }
        public virtual DbSet<Departamento> DepartamentoDbSet { get; set; }
        public virtual DbSet<Eso> EsoDbSet { get; set; }
        public virtual DbSet<Especial> EspecialDbSet { get; set; }
        public virtual DbSet<Evaluacion> EvaluacionDbSet { get; set; }
        public virtual DbSet<Horario> HorarioDbSet { get; set; }
        public virtual DbSet<Impartimiento> ImpartimientoDbSet { get; set; }
        public virtual DbSet<Mantenimiento> MantenimientoDbSet { get; set; }
        public virtual DbSet<Nota> NotaDbSet { get; set; }
        public virtual DbSet<Ordenador> OrdenadorDbSet { get; set; }
        public virtual DbSet<PermisosUsuario> PermisosUsuarioDbSet { get; set; }
        public virtual DbSet<Persona> PersonaDbSet { get; set; }
        public virtual DbSet<Profesor> ProfesorDbSet { get; set; }
        public virtual DbSet<ProfesorSustituto> ProfesorSustitutoDbSet { get; set; }
        public virtual DbSet<Proyecto> ProyectoDbSet { get; set; }
        public virtual DbSet<Reclamacion> ReclamacionDbSet { get; set; }
        public virtual DbSet<Superior> SuperiorDbSet { get; set; }
        public virtual DbSet<Telefono> TelefonoDbSet { get; set; }
        public virtual DbSet<Titulo> TituloDbSet { get; set; }
        public virtual DbSet<Trabajador> TrabajadorDbSet { get; set; }
        public virtual DbSet<Usuario> UsuarioDbSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrativo>()
                .Property(e => e.Trabajador)
                .IsUnicode(false);

            modelBuilder.Entity<Administrativo>()
                .Property(e => e.Departamento)
                .IsUnicode(false);

            modelBuilder.Entity<Administrativo>()
                .Property(e => e.Funcion)
                .IsUnicode(false);

            modelBuilder.Entity<Alumno>()
                .Property(e => e.Persona)
                .IsUnicode(false);

            modelBuilder.Entity<Alumno>()
                .Property(e => e.NumExpediente)
                .IsUnicode(false);

            modelBuilder.Entity<Alumno>()
                .Property(e => e.Tutor)
                .IsUnicode(false);

            modelBuilder.Entity<Alumno>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<Alumno>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Certificado)
                .WithRequired(e => e.Alumno1)
                .HasForeignKey(e => e.Alumno);

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Convocatoria)
                .WithRequired(e => e.Alumno1)
                .HasForeignKey(e => e.Alumno);

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Proyecto)
                .WithRequired(e => e.Alumno1)
                .HasForeignKey(e => e.Alumno);

            modelBuilder.Entity<Alumno>()
                .HasMany(e => e.Reclamacion)
                .WithRequired(e => e.Alumno1)
                .HasForeignKey(e => e.Alumno);

            modelBuilder.Entity<Asignatura>()
                .Property(e => e.Cod)
                .IsUnicode(false);

            modelBuilder.Entity<Asignatura>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Asignatura>()
                .Property(e => e.Rama)
                .IsUnicode(false);

            modelBuilder.Entity<Asignatura>()
                .HasMany(e => e.Convocatoria)
                .WithRequired(e => e.Asignatura)
                .HasForeignKey(e => e.CodAsignatura);

            modelBuilder.Entity<Asignatura>()
                .HasMany(e => e.Horario)
                .WithRequired(e => e.Asignatura)
                .HasForeignKey(e => e.CodAsignatura);

            modelBuilder.Entity<AsistenciaDiaAsignatura>()
                .Property(e => e.Persona)
                .IsUnicode(false);

            modelBuilder.Entity<AsistenciaDiaAsignatura>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<AsistenciaDiaAsignatura>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<AsistenciaDiaAsignatura>()
                .Property(e => e.CodAsignatura)
                .IsUnicode(false);

            modelBuilder.Entity<AsistenciaSemanaAsignatura>()
                .Property(e => e.Persona)
                .IsUnicode(false);

            modelBuilder.Entity<AsistenciaSemanaAsignatura>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<AsistenciaSemanaAsignatura>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<AsistenciaSemanaAsignatura>()
                .Property(e => e.CodAsignatura)
                .IsUnicode(false);

            modelBuilder.Entity<AsistenciaSemanaAsignatura>()
                .HasOptional(e => e.AsistenciaDiaAsignatura)
                .WithRequired(e => e.AsistenciaSemanaAsignatura)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Aula>()
                .Property(e => e.Num)
                .IsUnicode(false);

            modelBuilder.Entity<Aula>()
                .Property(e => e.Piso)
                .IsUnicode(false);

            modelBuilder.Entity<Aula>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Aula>()
                .HasMany(e => e.Impartimiento)
                .WithRequired(e => e.Aula)
                .HasForeignKey(e => new { e.AulaNum, e.AulaPiso })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Aula>()
                .HasMany(e => e.Departamento)
                .WithOptional(e => e.Aula)
                .HasForeignKey(e => new { e.Num, e.Piso })
                .WillCascadeOnDelete();

            modelBuilder.Entity<Aula>()
                .HasMany(e => e.Ordenador)
                .WithRequired(e => e.Aula)
                .HasForeignKey(e => new { e.Num, e.Piso });

            modelBuilder.Entity<Bachiller>()
                .Property(e => e.Cod)
                .IsUnicode(false);

            modelBuilder.Entity<Bachiller>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Bachiller>()
                .Property(e => e.Especializacion)
                .IsUnicode(false);

            modelBuilder.Entity<Baja>()
                .Property(e => e.Trabajador)
                .IsUnicode(false);

            modelBuilder.Entity<Baja>()
                .Property(e => e.Causa)
                .IsUnicode(false);

            modelBuilder.Entity<Certificado>()
                .Property(e => e.Alumno)
                .IsUnicode(false);

            modelBuilder.Entity<Certificado>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<Certificado>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Certificado>()
                .HasOptional(e => e.CertificadoMatricula)
                .WithRequired(e => e.Certificado)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Certificado>()
                .HasOptional(e => e.CertificadoNotas)
                .WithRequired(e => e.Certificado)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Certificado>()
                .HasOptional(e => e.CertificadoTitulo)
                .WithRequired(e => e.Certificado)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Certificado>()
                .HasOptional(e => e.Titulo)
                .WithRequired(e => e.Certificado)
                .WillCascadeOnDelete();

            modelBuilder.Entity<CertificadoMatricula>()
                .Property(e => e.Alumno)
                .IsUnicode(false);

            modelBuilder.Entity<CertificadoMatricula>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<CertificadoMatricula>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<CertificadoMatricula>()
                .Property(e => e.NumRegistro)
                .IsUnicode(false);

            modelBuilder.Entity<CertificadoNotas>()
                .Property(e => e.Alumno)
                .IsUnicode(false);

            modelBuilder.Entity<CertificadoNotas>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<CertificadoNotas>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<CertificadoTitulo>()
                .Property(e => e.Alumno)
                .IsUnicode(false);

            modelBuilder.Entity<CertificadoTitulo>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<CertificadoTitulo>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<CertificadoTitulo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ciclo>()
                .Property(e => e.Cod)
                .IsUnicode(false);

            modelBuilder.Entity<Ciclo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Ciclo>()
                .Property(e => e.Rama)
                .IsUnicode(false);

            modelBuilder.Entity<Ciclo>()
                .HasOptional(e => e.Superior)
                .WithRequired(e => e.Ciclo)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Convocatoria>()
                .Property(e => e.Alumno)
                .IsUnicode(false);

            modelBuilder.Entity<Convocatoria>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<Convocatoria>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Convocatoria>()
                .Property(e => e.CodAsignatura)
                .IsUnicode(false);

            modelBuilder.Entity<Convocatoria>()
                .HasMany(e => e.Evaluacion)
                .WithRequired(e => e.Convocatoria)
                .HasForeignKey(e => new { e.Alumno, e.CursoCod, e.CursoNombre, e.CodAsignatura, e.ConvocatoriaNum });

            modelBuilder.Entity<Curso>()
                .Property(e => e.Cod)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .Property(e => e.Tutor)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .HasOptional(e => e.Bachiller)
                .WithRequired(e => e.Curso)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Certificado)
                .WithRequired(e => e.Curso)
                .HasForeignKey(e => new { e.CursoCod, e.CursoNombre });

            modelBuilder.Entity<Curso>()
                .HasOptional(e => e.Ciclo)
                .WithRequired(e => e.Curso)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Convocatoria)
                .WithRequired(e => e.Curso)
                .HasForeignKey(e => new { e.CursoCod, e.CursoNombre });

            modelBuilder.Entity<Curso>()
                .HasOptional(e => e.Eso)
                .WithRequired(e => e.Curso)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Horario)
                .WithRequired(e => e.Curso)
                .HasForeignKey(e => new { e.CursoCod, e.CursoNombre });

            modelBuilder.Entity<Departamento>()
                .Property(e => e.Cod)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.Num)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.Piso)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .HasMany(e => e.Administrativo)
                .WithOptional(e => e.Departamento1)
                .HasForeignKey(e => e.Departamento)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Departamento>()
                .HasMany(e => e.Profesor)
                .WithRequired(e => e.Departamento1)
                .HasForeignKey(e => e.Departamento);

            modelBuilder.Entity<Eso>()
                .Property(e => e.Cod)
                .IsUnicode(false);

            modelBuilder.Entity<Eso>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Especial>()
                .Property(e => e.Trabajador)
                .IsUnicode(false);

            modelBuilder.Entity<Especial>()
                .Property(e => e.Funcion)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluacion>()
                .Property(e => e.Alumno)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluacion>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluacion>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluacion>()
                .Property(e => e.CodAsignatura)
                .IsUnicode(false);

            modelBuilder.Entity<Evaluacion>()
                .HasMany(e => e.AsistenciaSemanaAsignatura)
                .WithRequired(e => e.Evaluacion)
                .HasForeignKey(e => new { e.Persona, e.CursoCod, e.CursoNombre, e.CodAsignatura, e.ConvocatoriaNum, e.EvaluacionNum });

            modelBuilder.Entity<Evaluacion>()
                .HasOptional(e => e.Nota)
                .WithRequired(e => e.Evaluacion)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Horario>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .Property(e => e.CodAsignatura)
                .IsUnicode(false);

            modelBuilder.Entity<Horario>()
                .HasMany(e => e.Impartimiento)
                .WithRequired(e => e.Horario)
                .HasForeignKey(e => new { e.CursoCod, e.CursoNombre, e.CodAsignatura, e.HoraInicio, e.Dia, e.Anyo, e.HoraFinal });

            modelBuilder.Entity<Impartimiento>()
                .Property(e => e.Profesor)
                .IsUnicode(false);

            modelBuilder.Entity<Impartimiento>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<Impartimiento>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Impartimiento>()
                .Property(e => e.CodAsignatura)
                .IsUnicode(false);

            modelBuilder.Entity<Impartimiento>()
                .Property(e => e.AulaNum)
                .IsUnicode(false);

            modelBuilder.Entity<Impartimiento>()
                .Property(e => e.AulaPiso)
                .IsUnicode(false);

            modelBuilder.Entity<Mantenimiento>()
                .Property(e => e.Trabajador)
                .IsUnicode(false);

            modelBuilder.Entity<Mantenimiento>()
                .Property(e => e.Horario)
                .IsUnicode(false);

            modelBuilder.Entity<Mantenimiento>()
                .Property(e => e.Funcion)
                .IsUnicode(false);

            modelBuilder.Entity<Nota>()
                .Property(e => e.Alumno)
                .IsUnicode(false);

            modelBuilder.Entity<Nota>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<Nota>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Nota>()
                .Property(e => e.CodAsignatura)
                .IsUnicode(false);

            modelBuilder.Entity<Nota>()
                .Property(e => e.Observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<Ordenador>()
                .Property(e => e.Num)
                .IsUnicode(false);

            modelBuilder.Entity<Ordenador>()
                .Property(e => e.Piso)
                .IsUnicode(false);

            modelBuilder.Entity<Ordenador>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Ordenador>()
                .Property(e => e.CodOrdenadorAula)
                .IsUnicode(false);

            modelBuilder.Entity<Ordenador>()
                .Property(e => e.Ip)
                .IsUnicode(false);

            modelBuilder.Entity<Ordenador>()
                .Property(e => e.SistemaOperativo)
                .IsUnicode(false);

            modelBuilder.Entity<PermisosUsuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PermisosUsuario>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<PermisosUsuario>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.PermisosUsuario)
                .HasForeignKey(e => new { e.Nombre, e.PermisoAdministrativo, e.PermisoAdmin, e.PermisProfesor, e.PermisoAlumno });

            modelBuilder.Entity<Persona>()
                .Property(e => e.Dni)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Nif)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Calle)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.CodigoPostal)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Patio)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Piso)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Puerta)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Persona>()
                .HasOptional(e => e.Alumno)
                .WithRequired(e => e.Persona1)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Telefono)
                .WithRequired(e => e.Persona1)
                .HasForeignKey(e => e.Persona);

            modelBuilder.Entity<Persona>()
                .HasOptional(e => e.Trabajador)
                .WithRequired(e => e.Persona1)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Persona>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Persona1)
                .HasForeignKey(e => e.Persona);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Trabajador)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .Property(e => e.Departamento)
                .IsUnicode(false);

            modelBuilder.Entity<Profesor>()
                .HasMany(e => e.Impartimiento)
                .WithRequired(e => e.Profesor1)
                .HasForeignKey(e => e.Profesor);

            modelBuilder.Entity<Profesor>()
                .HasOptional(e => e.ProfesorSustituto)
                .WithRequired(e => e.Profesor)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ProfesorSustituto>()
                .Property(e => e.Sustituido)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Alumno)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.SuperiorCod)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.SuperiorNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Memoria)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Contenido)
                .IsUnicode(false);

            modelBuilder.Entity<Proyecto>()
                .Property(e => e.Tutor)
                .IsUnicode(false);

            modelBuilder.Entity<Reclamacion>()
                .Property(e => e.Alumno)
                .IsUnicode(false);

            modelBuilder.Entity<Reclamacion>()
                .Property(e => e.Asunto)
                .IsUnicode(false);

            modelBuilder.Entity<Reclamacion>()
                .Property(e => e.Contenido)
                .IsUnicode(false);

            modelBuilder.Entity<Reclamacion>()
                .Property(e => e.DirigidoA)
                .IsUnicode(false);

            modelBuilder.Entity<Reclamacion>()
                .Property(e => e.Respuesta)
                .IsUnicode(false);

            modelBuilder.Entity<Reclamacion>()
                .Property(e => e.Revisor)
                .IsUnicode(false);

            modelBuilder.Entity<Superior>()
                .Property(e => e.Cod)
                .IsUnicode(false);

            modelBuilder.Entity<Superior>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Superior>()
                .Property(e => e.ReglasProyecto)
                .IsUnicode(false);

            modelBuilder.Entity<Superior>()
                .HasMany(e => e.Proyecto)
                .WithRequired(e => e.Superior)
                .HasForeignKey(e => new { e.SuperiorCod, e.SuperiorNombre });

            modelBuilder.Entity<Telefono>()
                .Property(e => e.Persona)
                .IsUnicode(false);

            modelBuilder.Entity<Telefono>()
                .Property(e => e.Telefono1)
                .IsUnicode(false);

            modelBuilder.Entity<Telefono>()
                .Property(e => e.Comentario)
                .IsUnicode(false);

            modelBuilder.Entity<Titulo>()
                .Property(e => e.Alumno)
                .IsUnicode(false);

            modelBuilder.Entity<Titulo>()
                .Property(e => e.CursoCod)
                .IsUnicode(false);

            modelBuilder.Entity<Titulo>()
                .Property(e => e.CursoNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Titulo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Titulo>()
                .Property(e => e.Firmado)
                .IsUnicode(false);

            modelBuilder.Entity<Trabajador>()
                .Property(e => e.Persona)
                .IsUnicode(false);

            modelBuilder.Entity<Trabajador>()
                .HasOptional(e => e.Administrativo)
                .WithRequired(e => e.Trabajador1)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Trabajador>()
                .HasMany(e => e.Baja)
                .WithRequired(e => e.Trabajador1)
                .HasForeignKey(e => e.Trabajador);

            modelBuilder.Entity<Trabajador>()
                .HasOptional(e => e.Especial)
                .WithRequired(e => e.Trabajador1)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Trabajador>()
                .HasOptional(e => e.Mantenimiento)
                .WithRequired(e => e.Trabajador1)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Trabajador>()
                .HasOptional(e => e.Profesor)
                .WithRequired(e => e.Trabajador1)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Persona)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contrasenya)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsUnicode(false);
        }
    }
}
