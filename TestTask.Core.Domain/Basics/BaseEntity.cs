using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.Domain.Basics
{
    public abstract class BaseEntity
    {      
        public virtual Guid Id { get; init; }
    }
}
