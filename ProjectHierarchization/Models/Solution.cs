
using System.Collections.Generic;

namespace ProjectHierarchization.Models
{
    class Solution
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}
