using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Classes
{
    public class ClassEvaluation : AggregateRoot
    {
        public Class Class { get; set; }
        [Required]
        [StringLength(100)]
        public string ClassId { get; set; }

        public int EvaluationVersion { get; set; }

        [StringLength(100)]
        public string Choice1 { get; set; }
        [StringLength(100)]
        public string Choice2 { get; set; }
        [StringLength(100)]
        public string Choice3 { get; set; }
        [StringLength(100)]
        public string Choice4 { get; set; }
        [StringLength(100)]
        public string Choice5 { get; set; }
        [StringLength(100)]
        public string Choice6 { get; set; }
        [StringLength(100)]
        public string Choice7 { get; set; }
        [StringLength(100)]
        public string Choice8 { get; set; }
        [StringLength(100)]
        public string Choice9 { get; set; }
        [StringLength(100)]
        public string Choice10 { get; set; }
        [StringLength(100)]
        public string Choice11 { get; set; }
        [StringLength(100)]
        public string Choice12 { get; set; }
        [StringLength(100)]
        public string Choice13 { get; set; }
        [StringLength(100)]
        public string Choice14 { get; set; }
        [StringLength(100)]
        public string Choice15 { get; set; }
        [StringLength(100)]
        public string Choice16 { get; set; }
    }
}
