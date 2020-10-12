using System.Collections.Generic;

namespace ProjectHierarchization.Models
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Dependencies { get; set; }
    }
}
