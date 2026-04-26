using System;
using System.Collections.Generic;

namespace DL.Models;

public partial class Direccion
{
    public int IdDireccion { get; set; }

    public int IdColonia { get; set; }

    public virtual Colonium IdColoniaNavigation { get; set; } = null!;

    public virtual ICollection<Restaurante> Restaurantes { get; set; } = new List<Restaurante>();
}
