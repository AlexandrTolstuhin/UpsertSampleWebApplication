using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UpsertSampleWebApplication.Services;

namespace UpsertSampleWebApplication.Command
{
    public abstract record TodoCommand : IRequest<int>;

    public class TodoCommandHandler<T> : IRequestHandler<T, int>
        where T : TodoCommand
    {
        private readonly ITodoService _todoService;

        protected TodoCommandHandler(ITodoService todoService)
        {
            _todoService = todoService ?? throw new ArgumentNullException(nameof(todoService));
        }
        
        public Task<int> Handle(T request, CancellationToken cancellationToken) => 
            _todoService.UpsertAsync(request, cancellationToken);
    }
}