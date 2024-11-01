using System;
using System.Collections.Generic;

namespace Clinic.Models;

public partial class HistorialMedico
{
    public int Id { get; set; }

    public int? PacienteId { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Descripcion { get; set; }

    public int? TratamientoId { get; set; }

    public int? MedicoId { get; set; }

    public virtual Medico? Medico { get; set; }

    public virtual Paciente? Paciente { get; set; }

    public virtual Tratamiento? Tratamiento { get; set; }
}
