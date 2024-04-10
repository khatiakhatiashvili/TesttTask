using MediatR;
using TestTask.Core.Application.Interfaces;

namespace TestTask.Core.Application.Behaviors
{
    public class RequestTransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse>
    {
        private readonly IUnitOfWork _uof; 

        public RequestTransactionBehavior(IUnitOfWork uof)
        {
            _uof = uof;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
        var response = default(TResponse);
            if(request is ITransactionalRequest)
            {
                try
                {
                    await _uof.BeginTransactionAsync();
                    var result = await next();

                    await _uof.CommitTransactionAsync();
                    return result;
                }
                catch(Exception ex)
                {
                    await _uof.RollbackTransactionAsync();
                    throw;
                }
            } else 
                response = await next();
            return response;
        }
    }
}
