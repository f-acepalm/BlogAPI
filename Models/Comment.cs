using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Models
{
    public class Comment : BaseModel
    {
        public int PostId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Text { get; set; }
    }
}