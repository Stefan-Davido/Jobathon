using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class NegativeWord
    {
        [Key]
        public int Id { get; set; }
        public string Word { get; set; }
    }
}
