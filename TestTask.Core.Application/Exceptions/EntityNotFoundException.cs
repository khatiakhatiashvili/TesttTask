using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.Application.Exceptions
{
    public class EntityNotFoundException : ApplicationBaseException
    {
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;

        /// <summary>
        /// მოთხოვნილი ჩანაწერი ვერ მოიძებნა
        /// </summary>
        public EntityNotFoundException(string message) : base(message) { }
    }
}
