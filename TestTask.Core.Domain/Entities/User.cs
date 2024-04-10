using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core.Domain.Basics;

namespace TestTask.Core.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual WatchList? WatchList { get; set; }
        public Guid? WatchListId {  get; set; } 



    }
}
