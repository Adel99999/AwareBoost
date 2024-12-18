﻿using AwareBoost.Data;
using AwareBoost.Repository;
using AwareBoost.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace AwareBoost.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;
        public IAnswerRepo AnswerRepo { get; private set; }
        public IBadgesRepo BadgesRepo { get; private set; }
        public ICategoryRepo CategoryRepo { get; private set; }
        public ICommentsRepo CommentsRepo { get; private set; }
        public IFollowersRepo FollowersRepo { get; private set; }
        public IQuestionsRepo QuestionsRepo { get; private set; }
        public IQuestionsTagsRepo QuestionsTagsRepo { get; private set; }
        public ITagsRepo TagsRepo { get; private set; }
        public IUpvoteRepo UpvoteRepo { get; private set; }
        public IUserBadgesRepo UserBadgesRepo { get; private set; }
        public IViewsRepo ViewsRepo { get; private set; }

        // Inject the TokenRepository
        public ITokenRepository TokenRepository { get; private set; }

        // Inject IConfiguration and IHttpContextAccessor
        public UnitOfWork(AppDbContext db, IConfiguration config, IHttpContextAccessor contextAccessor)
        {
            _db = db;
            AnswerRepo = new AnswerRepo(_db);
            BadgesRepo = new BadgesRepo(_db);
            CategoryRepo = new CategoryRepo(_db);
            CommentsRepo = new CommentsRepo(_db);
            FollowersRepo = new FollowersRepo(_db);
            QuestionsRepo = new QuestionRepo(_db);
            TagsRepo = new TagsRepo(_db);
            QuestionsTagsRepo = new QuestionsTagsRepo(_db);
            UpvoteRepo = new UpvoteRepo(_db);
            UserBadgesRepo = new UserBadgesRepo(_db);
            ViewsRepo = new ViewsRepo(_db);

            // Initialize TokenRepository with dependencies
            TokenRepository = new TokenRepository(config, contextAccessor);
        }
    }
}
