using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Data
{
    public enum FieldType { Field, Office, Lab }
    public class Archer
    {
        [Required]
        public int AgentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Key]
        public Guid DbId { get; set; }
        public FieldType FieldType { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }

    }
}
