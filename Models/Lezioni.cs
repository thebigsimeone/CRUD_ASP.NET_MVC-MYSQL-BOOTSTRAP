using System;
using System.Collections.Generic;

namespace SimeoneCRUD.Models;

public partial class Lezioni
{
    public int Id { get; set; }

    public string Lezione { get; set; } = null!;

    public virtual ICollection<Allievi> IdAllievos { get; } = new List<Allievi>();
}
