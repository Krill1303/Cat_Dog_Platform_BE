using System;
using System.Collections.Generic;

namespace Cat_Dog_Platform_BE.Model;

public partial class Tag
{
    public string IdTag { get; set; } = null!;

    public string? NameTag { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}
