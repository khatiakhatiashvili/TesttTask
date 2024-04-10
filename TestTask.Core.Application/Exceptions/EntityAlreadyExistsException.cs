using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.Application.Exceptions
{
    public class EntityAlreadyExistsException: EntityValidationException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public EntityAlreadyExistsException(string message) : base(message) { }
    }
}
