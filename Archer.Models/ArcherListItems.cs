using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archer.Models
{
    public class ArcherListItems
    {
        public int AgentId { get; set; }
        public string Name { get; set; }
        public FieldType FieldType { get; set; }
        [Display(Name ="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
