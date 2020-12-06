using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NT.GM.Domain.GalleryAgg;


namespace NT.GM.Infrastructure.EFCore.Mappings
{
    public class GalleryMapping : IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            builder.ToTable("Tbl_Gallery");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Title);
            builder.Property(x => x.TypeID);
            builder.Property(x => x.PhotoAddress);
            builder.Property(x => x.ParentID);
            builder.Property(x => x.Status);

            //builder.HasOne(x => x.BaseInfo).WithMany(x => x.Galleries).HasForeignKey(x => x.TypeID);

            builder.HasOne(x => x.gallery).WithMany(x => x.Galleries).HasForeignKey(x => x.ParentID);
            builder.HasMany(x => x.Galleries).WithOne(x => x.gallery).HasForeignKey(x => x.ParentID);
        }
    }
}
