using System;
using System.Collections.Generic;

namespace Clinic.DAL.DataContext;

public partial class Paciente
{
    public int Personid { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Sexo { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();

    public virtual ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
}
