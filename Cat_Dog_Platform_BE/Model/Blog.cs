using System;
using System.Collections.Generic;

namespace Cat_Dog_Platform_BE.Model;

public partial class Blog
{
    public string IdBlog { get; set; } = null!;

    public string? Content { get; set; }

    public string? BlogStatus { get; set; }

    public string? BlogImage { get; set; }

    public string? BlogTitle { get; set; }

    public string UserIdUser { get; set; } = null!;

    public string BlogCatelogryIdBlogCatelogry { get; set; } = null!;

    public virtual Blogcatelogry BlogCatelogryIdBlogCatelogryNavigation { get; set; } = null!;

    public virtual User UserIdUserNavigation { get; set; } = null!;

    public virtual ICollection<Tag> TagIdTags { get; set; } = new List<Tag>();
}
