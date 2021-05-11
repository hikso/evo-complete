using System;
using System.Collections.Generic;
using System.Text;

namespace processDBDocumentation.Models
{
    public class Table
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public List<Column> Columns { get; set; }
    }
}