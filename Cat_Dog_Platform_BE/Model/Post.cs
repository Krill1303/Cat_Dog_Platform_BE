using System;
using System.Collections.Generic;

namespace Cat_Dog_Platform_BE.Model;

public partial class Post
{
    public string IdPosts { get; set; } = null!;

    public string? Content { get; set; }

    public string PetIdPet { get; set; } = null!;

    public string PetUserIdUser { get; set; } = null!;

    public string PetPetTypeIdPetType { get; set; } = null!;

    public virtual Pet Pet { get; set; } = null!;
}
