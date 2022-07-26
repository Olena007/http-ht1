using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_ht1.Models
{
    internal sealed class CreateUser
    {
        public string Name { get; set; }

        public string Job { get; set; }

        public int? Id { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
