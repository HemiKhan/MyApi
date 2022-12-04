namespace Domain.Seeding
{
    public class SchedulesSeeder
    {
        public long Id { get; set; }
        public long OrganizationId { get; set; }
        public string? Name { get; set; }
        public string? Token { get; set; }
        public string? Description { get; set; }
        public bool IsSubtraction { get; set; }

    }
}
