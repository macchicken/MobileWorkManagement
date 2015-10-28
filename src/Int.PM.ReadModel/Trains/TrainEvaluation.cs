using Int.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Int.PM.ReadModel.Trains
{
    public class TrainEvaluation : AggregateRoot
    {
        public Train Train { get; set; }
        [Required]
        [StringLength(50)]
        public string TrainId { get; set; }
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
        [StringLength(100)]
        public string Choice17 { get; set; }
        [StringLength(100)]
        public string Choice18 { get; set; }
        [StringLength(2000)]
        public string Choice19 { get; set; }
        [StringLength(2000)]
        public string Choice20 { get; set; }
        [StringLength(2000)]
        public string Choice21 { get; set; }
    }
}
