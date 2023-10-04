using System;
using System.Collections.Generic;

namespace Cat_Dog_Platform_BE.Model;

public partial class BlogHasPettype
{
    public string BlogIdBlog { get; set; } = null!;

    public string BlogUserIdUser { get; set; } = null!;

    public string PetTypeIdPetType { get; set; } = null!;

    public virtual Pettype PetTypeIdPetTypeNavigation { get; set; } = null!;
}
