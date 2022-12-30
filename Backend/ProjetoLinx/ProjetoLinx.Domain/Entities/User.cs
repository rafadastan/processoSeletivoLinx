using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLinx.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; internal set; }
        public string Name { get; internal set; }
        public string Email { get; internal set; }
        public string Password { get; internal set; }
    }
}
