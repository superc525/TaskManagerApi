namespace TaskManager.Utilities
{
    using AutoMapper;
    using TaskManager.Domain.Dtos;
    using TaskManager.Domain.Enums;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DtoTask, Domain.Task>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status));

            CreateMap<Domain.Task, DtoTask>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (TaskStatusEnum)src.Status));

            CreateMap<Domain.Task, DtoGetTask>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.TaskStatus.Status));
        }
    }
}
