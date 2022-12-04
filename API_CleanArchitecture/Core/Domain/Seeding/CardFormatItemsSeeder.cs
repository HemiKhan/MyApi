namespace Domain.Seeding
{
    public class CardFormatItemsSeeder
    {
        public long Id { get; set; }
        public long CardFormatId { get; set; }
        public string? Name { get; set; }
        public string? EncodingRange { get; set; }
        public string? Encoding { get; set; }
    }
}

