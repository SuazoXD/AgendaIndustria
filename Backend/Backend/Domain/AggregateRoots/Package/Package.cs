using System.Collections.Generic;
using Domain.Common;

namespace Domain.AggregateRoots.Package
{
    public class Package : AggregateRoot
    {
        public string? Name { get; set; }
        public ICollection<PackageDetail> Details { get; set; } = [];
    }
}
