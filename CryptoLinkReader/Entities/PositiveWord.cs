using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class PositiveWord
    {
        [Key]
        public int Id { get; set; }
        public string Word{ get; set; }
    }
}
