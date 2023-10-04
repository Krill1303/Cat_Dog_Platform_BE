using System;
using System.Collections.Generic;

namespace Cat_Dog_Platform_BE.Model;

public partial class Postreaction
{
    public string IdPostReaction { get; set; } = null!;

    public string? Comment { get; set; }

    public int? Like { get; set; }

    public string UserIdUser { get; set; } = null!;

    public string PostsIdPosts { get; set; } = null!;

    public virtual User UserIdUserNavigation { get; set; } = null!;
}
