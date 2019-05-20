using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.VisitRegistration.DomainClasses.Models
{
    [Table("Log", Schema = "Management")]
    public class Log
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
