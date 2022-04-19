﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public bool Status { get; set; }
        public ICollection<Content>Contents { get; set; }
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }

    }
}
