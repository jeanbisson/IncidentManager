using System;
using System.Collections.Generic;
using System.Text;

namespace IncidentManager.Shared
{
    public class ColumnDetails
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public bool Filterable { get; set; }
        public bool Sortable { get; set; }
    }
}
