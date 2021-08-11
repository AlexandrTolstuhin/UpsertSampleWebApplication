using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UpsertSampleWebApplication.Services;

namespace UpsertSampleWebApplication.Queries
{
    public record TodoViewModel(Guid Id, string Name);

    public record GetAllTodosQuery : IRequest<TodoViewModel[]>;
    
    public class GetAllTodosQueryHandler : IRequestHandler<GetAllTodosQuery, TodoViewModel[]>
    {
        private readonly ITodoService _todoService;

        public GetAllTodosQueryHandler(ITodoService todoService)
        {
            _todoService = todoService ?? throw new ArgumentNullException(nameof(todoService));
        }
        
        public Task<TodoViewModel[]> Handle(GetAllTodosQuery request, CancellationToken cancellationToken) => 
            _todoService.GetAllTodosAsync(cancellationToken);
    }
}