using System;
using System.Collections.Generic;

namespace Clinic.DAL.DataContext;

public partial class Tratamiento
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Costo { get; set; }

    public int? PacienteId { get; set; }

    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();

    public virtual Paciente? Paciente { get; set; }
}
