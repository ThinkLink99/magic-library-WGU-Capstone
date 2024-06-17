using SQLite;
using System;

namespace mtg_library.Models
{
    public class LibraryCard
    {
        [PrimaryKey]
        //[Indexed(Name = "CompositeKey", Order = 2, Unique = true)]
        public Guid CardId { get; set; }
        //[Indexed(Name = "CompositeKey", Order = 1, Unique = true)]
        [PrimaryKey]
        public Guid LibraryId { get; set; }
        public int Quantity { get; set; }
    }
}
