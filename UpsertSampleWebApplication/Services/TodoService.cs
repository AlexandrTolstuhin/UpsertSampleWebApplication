using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UpsertSampleWebApplication.Command;
using UpsertSampleWebApplication.Persistence;
using UpsertSampleWebApplication.Queries;

namespace UpsertSampleWebApplication.Services
{
    public class TodoService : ITodoService
    {
        private readonly IDbContextFactory<TodoDbContext> _contextFactory;
        
        private readonly IMapper _mapper;

        public TodoService(
            IDbContextFactory<TodoDbContext> contextFactory,
            IMapper mapper)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<TodoViewModel[]> GetAllTodosAsync(CancellationToken token = default)
        {
            await using var todoDbContext = _contextFactory.CreateDbContext();

            var todoEntities = await todoDbContext.Todos.ToArrayAsync(token);

            return _mapper.Map<TodoViewModel[]>(todoEntities);
        }

        public async Task<int> UpsertAsync(TodoCommand command, CancellationToken token = default)
        {
            await using var todoDbContext = _contextFactory.CreateDbContext();

            var todoEntity = _mapper.Map<TodoEntity>(command);

            return await todoDbContext.Todos
                .Upsert(todoEntity)
                .AllowIdentityMatch()
                .On(t => t.Id)
                .RunAsync(token);
        }
    }
}