using System;
using System.Collections.Generic;

namespace SimeoneCRUD.Models;

public partial class Professori
{
    public int Id { get; set; }

    public string Professore { get; set; } = null!;

    public string Materia { get; set; } = null!;
}
