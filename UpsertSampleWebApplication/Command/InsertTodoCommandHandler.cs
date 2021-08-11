using UpsertSampleWebApplication.Services;

namespace UpsertSampleWebApplication.Command
{
    public record InsertTodoCommand(string Name) : TodoCommand;
    
    public class InsertTodoCommandHandler : TodoCommandHandler<InsertTodoCommand>
    {
        public InsertTodoCommandHandler(ITodoService todoService) 
            : base(todoService)
        { }
    }
}