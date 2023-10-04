using System;
using System.Collections.Generic;

namespace Cat_Dog_Platform_BE.Model;

public partial class Pettrade
{
    public string IdPetTrade { get; set; } = null!;

    public string PostsIdPosts { get; set; } = null!;

    public string PetIdPet { get; set; } = null!;

    public string PetUserIdUser { get; set; } = null!;

    public string PetPetTypeIdPetType { get; set; } = null!;

    public virtual Pet Pet { get; set; } = null!;

    public virtual ICollection<Tradeapplied> Tradeapplieds { get; set; } = new List<Tradeapplied>();
}
