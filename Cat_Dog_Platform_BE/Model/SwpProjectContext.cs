using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cat_Dog_Platform_BE.Model;

public partial class SwpProjectContext : DbContext
{
    public SwpProjectContext()
    {
    }

    public SwpProjectContext(DbContextOptions<SwpProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BlogHasPettype> BlogHasPettypes { get; set; }

    public virtual DbSet<Blogcatelogry> Blogcatelogries { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<Pettrade> Pettrades { get; set; }

    public virtual DbSet<Pettype> Pettypes { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Postreaction> Postreactions { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Tradeapplied> Tradeapplieds { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;user id=root;password=123456;port=3306;database=swp_project;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => new { e.IdBlog, e.UserIdUser, e.BlogCatelogryIdBlogCatelogry }).HasName("PRIMARY");

            entity.ToTable("blog");

            entity.HasIndex(e => e.BlogCatelogryIdBlogCatelogry, "fk_Blog_BlogCatelogry1_idx");

            entity.HasIndex(e => e.UserIdUser, "fk_Blog_User1_idx");

            entity.Property(e => e.IdBlog)
                .HasMaxLength(20)
                .HasColumnName("idBlog");
            entity.Property(e => e.UserIdUser)
                .HasMaxLength(20)
                .HasColumnName("User_idUser");
            entity.Property(e => e.BlogCatelogryIdBlogCatelogry)
                .HasMaxLength(20)
                .HasColumnName("BlogCatelogry_idBlogCatelogry");
            entity.Property(e => e.BlogImage).HasColumnType("text");
            entity.Property(e => e.BlogStatus).HasMaxLength(60);
            entity.Property(e => e.BlogTitle).HasColumnType("text");
            entity.Property(e => e.Content).HasColumnType("text");

            entity.HasOne(d => d.BlogCatelogryIdBlogCatelogryNavigation).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.BlogCatelogryIdBlogCatelogry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Blog_BlogCatelogry1");

            entity.HasOne(d => d.UserIdUserNavigation).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.UserIdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Blog_User1");
        });

        modelBuilder.Entity<BlogHasPettype>(entity =>
        {
            entity.HasKey(e => new { e.BlogIdBlog, e.BlogUserIdUser, e.PetTypeIdPetType }).HasName("PRIMARY");

            entity.ToTable("blog_has_pettype");

            entity.HasIndex(e => new { e.BlogIdBlog, e.BlogUserIdUser }, "fk_Blog_has_PetType_Blog1_idx");

            entity.HasIndex(e => e.PetTypeIdPetType, "fk_Blog_has_PetType_PetType1_idx");

            entity.Property(e => e.BlogIdBlog)
                .HasMaxLength(20)
                .HasColumnName("Blog_idBlog");
            entity.Property(e => e.BlogUserIdUser)
                .HasMaxLength(20)
                .HasColumnName("Blog_User_idUser");
            entity.Property(e => e.PetTypeIdPetType)
                .HasMaxLength(20)
                .HasColumnName("PetType_idPetType");

            entity.HasOne(d => d.PetTypeIdPetTypeNavigation).WithMany(p => p.BlogHasPettypes)
                .HasForeignKey(d => d.PetTypeIdPetType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Blog_has_PetType_PetType1");
        });

        modelBuilder.Entity<Blogcatelogry>(entity =>
        {
            entity.HasKey(e => e.IdBlogCatelogry).HasName("PRIMARY");

            entity.ToTable("blogcatelogry");

            entity.Property(e => e.IdBlogCatelogry)
                .HasMaxLength(20)
                .HasColumnName("idBlogCatelogry");
            entity.Property(e => e.NameCatelogry).HasMaxLength(255);
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.HasKey(e => new { e.IdPet, e.UserIdUser, e.PetTypeIdPetType }).HasName("PRIMARY");

            entity.ToTable("pet");

            entity.HasIndex(e => e.PetTypeIdPetType, "fk_Pet_PetType1_idx");

            entity.HasIndex(e => e.UserIdUser, "fk_Pet_User_idx");

            entity.Property(e => e.IdPet)
                .HasMaxLength(20)
                .HasColumnName("idPet");
            entity.Property(e => e.UserIdUser)
                .HasMaxLength(20)
                .HasColumnName("User_idUser");
            entity.Property(e => e.PetTypeIdPetType)
                .HasMaxLength(20)
                .HasColumnName("PetType_idPetType");
            entity.Property(e => e.PetImage).HasColumnType("text");
            entity.Property(e => e.PetName).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.PetTypeIdPetTypeNavigation).WithMany(p => p.Pets)
                .HasForeignKey(d => d.PetTypeIdPetType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Pet_PetType1");

            entity.HasOne(d => d.UserIdUserNavigation).WithMany(p => p.Pets)
                .HasForeignKey(d => d.UserIdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Pet_User");
        });

        modelBuilder.Entity<Pettrade>(entity =>
        {
            entity.HasKey(e => new { e.IdPetTrade, e.PostsIdPosts, e.PetIdPet, e.PetUserIdUser, e.PetPetTypeIdPetType }).HasName("PRIMARY");

            entity.ToTable("pettrade");

            entity.HasIndex(e => new { e.PetIdPet, e.PetUserIdUser, e.PetPetTypeIdPetType }, "fk_PetTrade_Pet1_idx");

            entity.HasIndex(e => e.PostsIdPosts, "fk_PetTrade_Posts1_idx");

            entity.Property(e => e.IdPetTrade)
                .HasMaxLength(20)
                .HasColumnName("idPetTrade");
            entity.Property(e => e.PostsIdPosts)
                .HasMaxLength(40)
                .HasColumnName("Posts_idPosts");
            entity.Property(e => e.PetIdPet)
                .HasMaxLength(20)
                .HasColumnName("Pet_idPet");
            entity.Property(e => e.PetUserIdUser)
                .HasMaxLength(20)
                .HasColumnName("Pet_User_idUser");
            entity.Property(e => e.PetPetTypeIdPetType)
                .HasMaxLength(20)
                .HasColumnName("Pet_PetType_idPetType");

            entity.HasOne(d => d.Pet).WithMany(p => p.Pettrades)
                .HasForeignKey(d => new { d.PetIdPet, d.PetUserIdUser, d.PetPetTypeIdPetType })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PetTrade_Pet1");
        });

        modelBuilder.Entity<Pettype>(entity =>
        {
            entity.HasKey(e => e.IdPetType).HasName("PRIMARY");

            entity.ToTable("pettype");

            entity.Property(e => e.IdPetType)
                .HasMaxLength(20)
                .HasColumnName("idPetType");
            entity.Property(e => e.ImagePetType).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => new { e.IdPosts, e.PetIdPet, e.PetUserIdUser, e.PetPetTypeIdPetType }).HasName("PRIMARY");

            entity.ToTable("posts");

            entity.HasIndex(e => new { e.PetIdPet, e.PetUserIdUser, e.PetPetTypeIdPetType }, "fk_Posts_Pet1_idx");

            entity.Property(e => e.IdPosts)
                .HasMaxLength(40)
                .HasColumnName("idPosts");
            entity.Property(e => e.PetIdPet)
                .HasMaxLength(20)
                .HasColumnName("Pet_idPet");
            entity.Property(e => e.PetUserIdUser)
                .HasMaxLength(20)
                .HasColumnName("Pet_User_idUser");
            entity.Property(e => e.PetPetTypeIdPetType)
                .HasMaxLength(20)
                .HasColumnName("Pet_PetType_idPetType");
            entity.Property(e => e.Content).HasColumnType("text");

            entity.HasOne(d => d.Pet).WithMany(p => p.Posts)
                .HasForeignKey(d => new { d.PetIdPet, d.PetUserIdUser, d.PetPetTypeIdPetType })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Posts_Pet1");
        });

        modelBuilder.Entity<Postreaction>(entity =>
        {
            entity.HasKey(e => new { e.IdPostReaction, e.UserIdUser, e.PostsIdPosts }).HasName("PRIMARY");

            entity.ToTable("postreaction");

            entity.HasIndex(e => e.PostsIdPosts, "fk_PostReaction_Posts1_idx");

            entity.HasIndex(e => e.UserIdUser, "fk_PostReaction_User1_idx");

            entity.Property(e => e.IdPostReaction)
                .HasMaxLength(20)
                .HasColumnName("idPostReaction");
            entity.Property(e => e.UserIdUser)
                .HasMaxLength(20)
                .HasColumnName("User_idUser");
            entity.Property(e => e.PostsIdPosts)
                .HasMaxLength(40)
                .HasColumnName("Posts_idPosts");
            entity.Property(e => e.Comment).HasColumnType("text");

            entity.HasOne(d => d.UserIdUserNavigation).WithMany(p => p.Postreactions)
                .HasForeignKey(d => d.UserIdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PostReaction_User1");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.IdTag).HasName("PRIMARY");

            entity.ToTable("tag");

            entity.Property(e => e.IdTag)
                .HasMaxLength(20)
                .HasColumnName("idTag");
            entity.Property(e => e.NameTag).HasMaxLength(255);

            entity.HasMany(d => d.Blogs).WithMany(p => p.TagIdTags)
                .UsingEntity<Dictionary<string, object>>(
                    "TagHasBlog",
                    r => r.HasOne<Blog>().WithMany()
                        .HasForeignKey("BlogIdBlog", "BlogUserIdUser", "BlogBlogCatelogryIdBlogCatelogry")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Tag_has_Blog_Blog1"),
                    l => l.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagIdTag")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Tag_has_Blog_Tag1"),
                    j =>
                    {
                        j.HasKey("TagIdTag", "BlogIdBlog", "BlogUserIdUser", "BlogBlogCatelogryIdBlogCatelogry").HasName("PRIMARY");
                        j.ToTable("tag_has_blog");
                        j.HasIndex(new[] { "BlogIdBlog", "BlogUserIdUser", "BlogBlogCatelogryIdBlogCatelogry" }, "fk_Tag_has_Blog_Blog1_idx");
                        j.HasIndex(new[] { "TagIdTag" }, "fk_Tag_has_Blog_Tag1_idx");
                        j.IndexerProperty<string>("TagIdTag")
                            .HasMaxLength(20)
                            .HasColumnName("Tag_idTag");
                        j.IndexerProperty<string>("BlogIdBlog")
                            .HasMaxLength(20)
                            .HasColumnName("Blog_idBlog");
                        j.IndexerProperty<string>("BlogUserIdUser")
                            .HasMaxLength(20)
                            .HasColumnName("Blog_User_idUser");
                        j.IndexerProperty<string>("BlogBlogCatelogryIdBlogCatelogry")
                            .HasMaxLength(20)
                            .HasColumnName("Blog_BlogCatelogry_idBlogCatelogry");
                    });
        });

        modelBuilder.Entity<Tradeapplied>(entity =>
        {
            entity.HasKey(e => new { e.IdTradeApplied, e.PetTradeIdPetTrade, e.PetTradePostsIdPosts, e.PetTradePetIdPet, e.PetTradePetUserIdUser, e.PetTradePetPetTypeIdPetType, e.UserIdUser }).HasName("PRIMARY");

            entity.ToTable("tradeapplied");

            entity.HasIndex(e => new { e.PetTradeIdPetTrade, e.PetTradePostsIdPosts, e.PetTradePetIdPet, e.PetTradePetUserIdUser, e.PetTradePetPetTypeIdPetType }, "fk_TradeApplied_PetTrade1_idx");

            entity.HasIndex(e => e.UserIdUser, "fk_TradeApplied_User1_idx");

            entity.Property(e => e.IdTradeApplied)
                .HasMaxLength(20)
                .HasColumnName("idTradeApplied");
            entity.Property(e => e.PetTradeIdPetTrade)
                .HasMaxLength(20)
                .HasColumnName("PetTrade_idPetTrade");
            entity.Property(e => e.PetTradePostsIdPosts)
                .HasMaxLength(40)
                .HasColumnName("PetTrade_Posts_idPosts");
            entity.Property(e => e.PetTradePetIdPet)
                .HasMaxLength(20)
                .HasColumnName("PetTrade_Pet_idPet");
            entity.Property(e => e.PetTradePetUserIdUser)
                .HasMaxLength(20)
                .HasColumnName("PetTrade_Pet_User_idUser");
            entity.Property(e => e.PetTradePetPetTypeIdPetType)
                .HasMaxLength(20)
                .HasColumnName("PetTrade_Pet_PetType_idPetType");
            entity.Property(e => e.UserIdUser)
                .HasMaxLength(20)
                .HasColumnName("User_idUser");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.UserIdUserNavigation).WithMany(p => p.Tradeapplieds)
                .HasForeignKey(d => d.UserIdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_TradeApplied_User1");

            entity.HasOne(d => d.PetTrade).WithMany(p => p.Tradeapplieds)
                .HasForeignKey(d => new { d.PetTradeIdPetTrade, d.PetTradePostsIdPosts, d.PetTradePetIdPet, d.PetTradePetUserIdUser, d.PetTradePetPetTypeIdPetType })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_TradeApplied_PetTrade1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.Property(e => e.IdUser)
                .HasMaxLength(20)
                .HasColumnName("idUser");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PassWord).HasMaxLength(45);
            entity.Property(e => e.UserName).HasMaxLength(45);
            entity.Property(e => e.UserRole)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
