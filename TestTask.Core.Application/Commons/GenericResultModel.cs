using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Core.Application.Commons
{
    public class GenericResultModel<TResult>
    {
        public int ErrCode { get; set; } = 0;
        public string Message { get; set; } = "Success";
        public TResult Result { get; set; } = default(TResult);

        public GenericResultModel()
        {

        }

        public GenericResultModel(TResult result, int errCode, string message)
        {
            ErrCode = errCode;
            Message = message;
            Result = result;
        }

        public GenericResultModel(TResult result)
        {
            Result = result;
        }


    }
}
