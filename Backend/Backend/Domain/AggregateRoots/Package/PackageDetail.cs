namespace Domain.AggregateRoots.Package
{
    public class PackageDetail : Domain.Common.Entity
    {
        public int PackageId { get; set; }
        public required Package Package { get; set; }

        public string? Detail { get; set; }
        public int Quantity { get; set; }
    }
}
