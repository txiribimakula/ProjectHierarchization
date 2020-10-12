using System.Collections.Generic;

namespace ProjectHierarchization.Models
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Dependencies { get; set; }

        public Project(string id, string name) {
            Id = id;
            Name = name;
            Dependencies = new List<string>();
        }
    }
}
