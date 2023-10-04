using System;
using System.Collections.Generic;

namespace Cat_Dog_Platform_BE.Model;

public partial class Pet
{
    public string IdPet { get; set; } = null!;

    public string? PetName { get; set; }

    public string? Type { get; set; }

    public int? PetAge { get; set; }

    public float? Weight { get; set; }

    public float? Price { get; set; }

    public string? PetImage { get; set; }

    public string UserIdUser { get; set; } = null!;

    public string PetTypeIdPetType { get; set; } = null!;

    public virtual Pettype PetTypeIdPetTypeNavigation { get; set; } = null!;

    public virtual ICollection<Pettrade> Pettrades { get; set; } = new List<Pettrade>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

    public virtual User UserIdUserNavigation { get; set; } = null!;
}
