using System;
using System.Collections.Generic;

namespace Cat_Dog_Platform_BE.Model;

public partial class Blogcatelogry
{
    public string IdBlogCatelogry { get; set; } = null!;

    public string? NameCatelogry { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}
