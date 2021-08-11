using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UpsertSampleWebApplication.Services;

namespace UpsertSampleWebApplication.Command
{
    public abstract record TodoCommand : IRequest<int>;

    public record InsertTodoCommand(string Name) : TodoCommand;

    public record UpdateTodoCommand(Guid Id, string Name) : InsertTodoCommand(Name);

    public class InsertTodoCommandHandler : IRequestHandler<InsertTodoCommand, int>
    {
        private readonly ITodoService _todoService;

        public InsertTodoCommandHandler(ITodoService todoService)
        {
            _todoService = todoService ?? throw new ArgumentNullException(nameof(todoService));
        }
        
        public Task<int> Handle(InsertTodoCommand request, CancellationToken cancellationToken) => 
            _todoService.UpsertAsync(request, cancellationToken);
    }
    
    public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, int>
    {
        private readonly ITodoService _todoService;

        public UpdateTodoCommandHandler(ITodoService todoService)
        {
            _todoService = todoService ?? throw new ArgumentNullException(nameof(todoService));
        }
        
        public Task<int> Handle(UpdateTodoCommand request, CancellationToken cancellationToken) => 
            _todoService.UpsertAsync(request, cancellationToken);
    }
}