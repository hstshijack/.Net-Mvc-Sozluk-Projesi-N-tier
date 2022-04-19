using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [StringLength(50)]
        public string Sender { get; set; }
        [StringLength(50)]
        public string Receiver { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }


    }
}
