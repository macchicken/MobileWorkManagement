using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Int.Repository
{
    public class AggregateRoot : Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sequence { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedOn { get; set; }

        public int Version { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
