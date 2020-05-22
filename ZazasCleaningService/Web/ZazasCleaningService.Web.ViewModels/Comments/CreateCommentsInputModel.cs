namespace ZazasCleaningService.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using ZazasCleaningService.Services.Mapping;
    using ZazasCleaningService.Services.Models.Comments;

    public class CreateCommentsInputModel : IMapTo<CommentsServiceModel>, IMapFrom<CommentsServiceModel>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public string UserUserName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<CommentsServiceModel, CreateCommentsInputModel>()
                .ForMember(
                    destination => destination.UserUserName,
                    options => options.MapFrom(origin => origin.User.UserName));
        }
    }
}
