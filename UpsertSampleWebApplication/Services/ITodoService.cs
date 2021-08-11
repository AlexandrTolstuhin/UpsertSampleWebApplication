using System.Threading;
using System.Threading.Tasks;
using UpsertSampleWebApplication.Command;
using UpsertSampleWebApplication.Queries;

namespace UpsertSampleWebApplication.Services
{
    public interface ITodoService
    {
        Task<TodoViewModel[]> GetAllTodosAsync(CancellationToken token = default);

        Task<int> UpsertAsync(TodoCommand command, CancellationToken token = default);
    }
}