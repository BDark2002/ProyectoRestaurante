using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Restaurante
{
    public int IdRestaurante { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Logo { get; set; }

    public DateOnly FechaApertura { get; set; }

    public DateOnly? FechaCierre { get; set; }

    public int IdDireccion { get; set; }

    public virtual Direccion IdDireccionNavigation { get; set; } = null!;
}
