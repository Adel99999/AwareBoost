using AutoMapper;
using AwareBoost.Dtos;
using AwareBoost.Models;

namespace AwareBoost.Mappings
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            // Answers
            CreateMap<Answers, AnswerDto>()
                .ReverseMap();

            // Badges
            CreateMap<Badges, BadgeDto>()
                .ReverseMap();
            CreateMap<AddBadgeRequestDto, Badges>().ReverseMap();
            CreateMap<UpdateBadgeRequestDto, Badges>().ReverseMap();

            // Category
            CreateMap<Category, CategoryDto>()
                .ReverseMap();
            CreateMap<AddCategoryRequestDto, Category>()
               .ReverseMap();
            CreateMap<UpdateCategoryRequestDto, Category>()
               .ReverseMap();


            // Comments
            CreateMap<Comments, CommentDto>()
                .ReverseMap();
            CreateMap<AddCommentRequestDto, Comments>().ReverseMap();
            CreateMap<UpdateCommentRequestDto, Comments>().ReverseMap();

            // Followers
            CreateMap<Followers, FollowerDto>()
                .ReverseMap();
            CreateMap<AddFollowerRequestDto, Followers>().ReverseMap();
            CreateMap<RemoveFollowerRequestDto, Followers>().ReverseMap();

            // Questions
            CreateMap<Questions, QuestionDto>()
                .ReverseMap();
            CreateMap<AddQuestionRequestDto, Questions>().ReverseMap();
            CreateMap<UpdateQuestionRequestDto, Questions>().ReverseMap();

            // Tags
            CreateMap<Tags, TagDto>()
                .ReverseMap();
            CreateMap<AddTagRequestDto, Tags>().ReverseMap();
            CreateMap<UpdateTagRequestDto, Tags>().ReverseMap();

           
            // Upvote
            CreateMap<Upvote, UpvoteDto>()
                .ReverseMap();
            CreateMap<AddUpvoteRequestDto,Upvote>().ReverseMap();
            CreateMap<RemoveUpvoteRequestDto, Upvote>().ReverseMap();
 

        }
    }
}
