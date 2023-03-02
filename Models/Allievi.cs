using System;
using System.Collections.Generic;

namespace SimeoneCRUD.Models;

public partial class Allievi
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public int Idlezione { get; set; }

    public virtual ICollection<Lezioni> IdLeziones { get; } = new List<Lezioni>();
}
