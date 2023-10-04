using System;
using System.Collections.Generic;

namespace Cat_Dog_Platform_BE.Model;

public partial class User
{
    public string IdUser { get; set; } = null!;

    public string? Name { get; set; }

    public string? UserName { get; set; }

    public string? UserRole { get; set; }

    public string? PassWord { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

    public virtual ICollection<Postreaction> Postreactions { get; set; } = new List<Postreaction>();

    public virtual ICollection<Tradeapplied> Tradeapplieds { get; set; } = new List<Tradeapplied>();
}
