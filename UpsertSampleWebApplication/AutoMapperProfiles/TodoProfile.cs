using AutoMapper;
using UpsertSampleWebApplication.Command;
using UpsertSampleWebApplication.Persistence;
using UpsertSampleWebApplication.Queries;

namespace UpsertSampleWebApplication.AutoMapperProfiles
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<InsertTodoCommand, TodoEntity>();
            CreateMap<UpdateTodoCommand, TodoEntity>();
            CreateMap<TodoEntity, TodoViewModel>();
        }
    }
}