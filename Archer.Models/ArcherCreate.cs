using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Models
{
    public enum FieldType { Field, Office, Lab }
    public class ArcherCreate
    {
        [Required]
        [MinLength(6, ErrorMessage = "Id must be at least six digits")]
        [MaxLength(12, ErrorMessage = "Id must be less than twelve digits")]
        public int AgentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public FieldType FieldType { get; set; }
        
    }
}
