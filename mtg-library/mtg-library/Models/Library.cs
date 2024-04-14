using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace mtg_library.Models
{
    public class Library
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Status { get; set; }

    }
}
