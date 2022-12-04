namespace Persistence.Data.Config.CardFormatConfigs;
using Domain.Models.CardFormatsModels;
using Domain.Seeding;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal record CardFormatItemEC(IQClaims QClaims) : IEntityTypeConfiguration<CardFormatItems>
{
    public void Configure(EntityTypeBuilder<CardFormatItems> builder)
    {
        #region Configuration  

        builder.AddDateTimeConfig();
        builder.Property(x => x.Id)
            .HasColumnOrder(-2);
        builder.Property(_ => _.CardFormatId)
            .HasColumnName("CardFormatId")
            .HasColumnOrder(-1);
        builder.Property(_ => _.Name)
            .HasColumnName("CardFormatItemName")
            .HasColumnType("NVARCHAR(64)");
        builder.Property(_ => _.EncodingRange)
            .HasColumnName("EncodingRange")
            .HasColumnType("VARCHAR(21)");
        builder.Property(_ => _.Encoding)
           .HasColumnName("Encoding")
           .HasColumnType("VARCHAR(13)");

        #endregion

        #region Seeder
        builder.HasData(
              new CardFormatItemsSeeder
              {
                  Id = 1,
                  CardFormatId = 1,
                  Name = "EvenParity",
                  EncodingRange = "1",
                  Encoding = "BinLE2Int",
              },
               new CardFormatItemsSeeder
               {
                   Id = 2,
                   CardFormatId = 1,
                   Name = "FacilityCode",
                   EncodingRange = "2-9",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 3,
                   CardFormatId = 1,
                   Name = "CardNr",
                   EncodingRange = "10-25",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 4,
                   CardFormatId = 1,
                   Name = "CardNrHex",
                   EncodingRange = "10-25",
                   Encoding = "BinLE2hex",
               },
               new CardFormatItemsSeeder
               {
                   Id = 5,
                   CardFormatId = 1,
                   Name = "OddParity",
                   EncodingRange = "26",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 6,
                   CardFormatId = 2,
                   Name = "CardNr",
                   EncodingRange = "1-32",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 7,
                   CardFormatId = 2,
                   Name = "CardNrHex",
                   EncodingRange = "1-32",
                   Encoding = "BinLE2hex",
               },
               new CardFormatItemsSeeder
               {
                   Id = 8,
                   CardFormatId = 3,
                   Name = "EvenParity",
                   EncodingRange = "1",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 9,
                   CardFormatId = 3,
                   Name = "FacilityCode",
                   EncodingRange = "2-17",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 10,
                   CardFormatId = 3,
                   Name = "CardNr",
                   EncodingRange = "18-33",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 11,
                   CardFormatId = 3,
                   Name = "CardNrHex",
                   EncodingRange = "18-33",
                   Encoding = "BinLE2hex",
               },
               new CardFormatItemsSeeder
               {
                   Id = 12,
                   CardFormatId = 3,
                   Name = "OddParity",
                   EncodingRange = "34",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 13,
                   CardFormatId = 4,
                   Name = "EvenParity",
                   EncodingRange = "1",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 14,
                   CardFormatId = 4,
                   Name = "CardNr",
                   EncodingRange = "2-36",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 15,
                   CardFormatId = 4,
                   Name = "CardNrHex",
                   EncodingRange = "2-36",
                   Encoding = "BinLE2hex",
               },
               new CardFormatItemsSeeder
               {
                   Id = 16,
                   CardFormatId = 4,
                   Name = "OddParity",
                   EncodingRange = "37",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 17,
                   CardFormatId = 5,
                   Name = "EvenParity",
                   EncodingRange = "1",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 18,
                   CardFormatId = 5,
                   Name = "FacilityCode",
                   EncodingRange = "2-17",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 19,
                   CardFormatId = 5,
                   Name = "CardNr",
                   EncodingRange = "18-36",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 20,
                   CardFormatId = 5,
                   Name = "CardNrHex",
                   EncodingRange = "18-36",
                   Encoding = "BinLE2hex",
               },
               new CardFormatItemsSeeder
               {
                   Id = 21,
                   CardFormatId = 5,
                   Name = "OddParity",
                   EncodingRange = "37",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 22,
                   CardFormatId = 6,
                   Name = "CardNr",
                   EncodingRange = "17-80",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 23,
                   CardFormatId = 6,
                   Name = "CardNrHex",
                   EncodingRange = "17-80",
                   Encoding = "BinLE2hex",
               },
               new CardFormatItemsSeeder
               {
                   Id = 24,
                   CardFormatId = 7,
                   Name = "CardNr",
                   EncodingRange = "1-56",
                   Encoding = "BinLE2Int",
               },
               new CardFormatItemsSeeder
               {
                   Id = 25,
                   CardFormatId = 7,
                   Name = "CardNrHex",
                   EncodingRange = "1-56",
                   Encoding = "BinLE2hex",
               },
               new CardFormatItemsSeeder
               {
                   Id = 26,
                   CardFormatId = 1,
                   Name = "OddParity",
                   EncodingRange = "1",
                   Encoding = "BinLE2Int",
               }
           );
        #endregion
    }
}
