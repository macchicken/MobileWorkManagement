using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.CRM.ReadModel.Customers
{
    public class OldCustomer : AggregateRoot
    {
        [StringLength(50)]
        public string CityId { get; set; }

        [StringLength(200)]
        public string Company { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Position { get; set; }

        [StringLength(200)]
        public string Phone { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(1000)]
        public string Remark { get; set; }
    }
}
