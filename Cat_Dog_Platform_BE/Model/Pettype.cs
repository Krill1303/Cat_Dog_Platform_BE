using System;
using System.Collections.Generic;

namespace Cat_Dog_Platform_BE.Model;

public partial class Pettype
{
    public string IdPetType { get; set; } = null!;

    public string? Name { get; set; }

    public string? ImagePetType { get; set; }

    public virtual ICollection<BlogHasPettype> BlogHasPettypes { get; set; } = new List<BlogHasPettype>();

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
