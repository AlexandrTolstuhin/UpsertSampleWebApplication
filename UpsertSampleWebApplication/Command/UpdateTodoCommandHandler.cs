using System;
using UpsertSampleWebApplication.Services;

namespace UpsertSampleWebApplication.Command
{
    public record UpdateTodoCommand(Guid Id, string Name) : InsertTodoCommand(Name);
    
    public class UpdateTodoCommandHandler : TodoCommandHandler<UpdateTodoCommand>
    {
        public UpdateTodoCommandHandler(ITodoService todoService) 
            : base(todoService)
        { }
    }
}