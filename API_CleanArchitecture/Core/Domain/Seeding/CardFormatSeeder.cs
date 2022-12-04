namespace Domain.Seeding
{
    public class CardFormatSeeder
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public string Token { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int BitLength { get; set; }
        public bool IsEnable { get; set; }
    }
}

