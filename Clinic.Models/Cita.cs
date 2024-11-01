using System;
using System.Collections.Generic;

namespace Clinic.Models;

public partial class Cita
{
    public int Id { get; set; }

    public int? PacienteId { get; set; }

    public int? MedicoId { get; set; }

    public DateTime? Fecha { get; set; }

    public TimeOnly? Hora { get; set; }

    public string? Estado { get; set; }

    public virtual Medico? Medico { get; set; }

    public virtual Paciente? Paciente { get; set; }
}
