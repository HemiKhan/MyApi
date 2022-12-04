namespace Persistence.Data.Config.CardFormatConfigs;

using Domain.Models.CardFormatsModels;
using Domain.Seeding;



internal record CardFormatEC(IQClaims QClaims) : IEntityTypeConfiguration<CardFormat>
{
    public void Configure(EntityTypeBuilder<CardFormat> builder)
    {
        #region Configuration  

        builder.AddDateTimeConfig();
        builder
       .HasIndex(_ => new { _.OrganizationId, _.Name })
       .IsUnique();
        builder.HasQueryFilter(o => o.OrganizationId == QClaims.OrganizationId);
        builder.HasMany(_ => _.CardFormatItems).WithOne(_ => _.CardFormat).HasForeignKey(_ => _.CardFormatId);
        builder.Property(x => x.Id)
            .HasColumnOrder(-2);
        builder.Property(_ => _.OrganizationId)
            .HasColumnName("OrganizationId")
            .HasColumnOrder(-1);
        builder.Property(_ => _.Name)
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR(64)");
        builder.Property(_ => _.Token)
            .HasColumnName("Token")
            .HasColumnType("VARCHAR(64)");
        builder.Property(_ => _.Description)
           .HasColumnName("Description")
           .HasColumnType("VARCHAR(64)");
        builder.Property(_ => _.BitLength)
           .HasColumnName("BitLength")
           .HasColumnType("int");
        builder.Property(_ => _.IsEnable)
          .HasColumnName("IsEnable")
          .HasColumnType("bit");

        #endregion

        #region Seeder
        //Seed this on Organization Add Seeding will be obsolete in future for this
        builder.HasData(
               new CardFormatSeeder
               {
                   Id = 1,
                   OrganizationId = 1,
                   Name = "Wiegand 26-bit (H10301)",
                   Description = "Standard 26-bit Wiegand (H10301)",
                   Token = "iddataconf_wiegand_26bit_h10301",
                   BitLength = 26,
                   IsEnable = true,

               },
               new CardFormatSeeder
               {
                   Id = 2,
                   OrganizationId = 1,
                   Name = "32-bit Card Data",
                   Description = "32-bit raw card data",
                   Token = "iddataconf_32bit_card_data",
                   BitLength = 32,
                   IsEnable = true,
               },
               new CardFormatSeeder
               {
                   Id = 3,
                   OrganizationId = 1,
                   Name = "Wiegand 34-bit",
                   Description = "Standard 34-bit Wiegand",
                   Token = "iddataconf_wiegand_34bit",
                   BitLength = 34,
                   IsEnable = true,
               },
               new CardFormatSeeder
               {
                   Id = 4,
                   OrganizationId = 1,
                   Name = "Wiegand 37-bit (H10302)",
                   Description = "Standard 37-bit Wiegand (H10302)",
                   Token = "iddataconf_wiegand_37bit_h10302",
                   BitLength = 37,
                   IsEnable = true,
               },
               new CardFormatSeeder
               {
                   Id = 5,
                   OrganizationId = 1,
                   Name = "Wiegand 37-bit with facility code (H10304)",
                   Description = "Standard 37-bit Wiegand with facility code (H10304)",
                   Token = "iddataconf_wiegand_37bit_h10304",
                   BitLength = 37,
                   IsEnable = true,
               },
               new CardFormatSeeder
               {
                   Id = 6,
                   OrganizationId = 1,
                   Name = "80-bit SmartIntego",
                   Description = "80-bit SmartIntego Card Data",
                   Token = "iddataconf_smartintego_80bit",
                   BitLength = 80,
                   IsEnable = true,
               },
               new CardFormatSeeder
               {
                   Id = 7,
                   OrganizationId = 1,
                   Name = "56-bit Card Data",
                   Description = "56-bit raw card data",
                   Token = "iddataconf_56bit_card_data",
                   BitLength = 56,
                   IsEnable = true,
               }
            );
        #endregion
    }
}
