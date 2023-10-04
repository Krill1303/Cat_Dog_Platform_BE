using System;
using System.Collections.Generic;

namespace Cat_Dog_Platform_BE.Model;

public partial class Tradeapplied
{
    public string IdTradeApplied { get; set; } = null!;

    public string? Status { get; set; }

    public string PetTradeIdPetTrade { get; set; } = null!;

    public string PetTradePostsIdPosts { get; set; } = null!;

    public string PetTradePetIdPet { get; set; } = null!;

    public string PetTradePetUserIdUser { get; set; } = null!;

    public string PetTradePetPetTypeIdPetType { get; set; } = null!;

    public string UserIdUser { get; set; } = null!;

    public virtual Pettrade PetTrade { get; set; } = null!;

    public virtual User UserIdUserNavigation { get; set; } = null!;
}
