using AutoMapper;
using BlogNetCore.AppService.Domain;
using BlogNetCore.AppService.Mapping.Configuration;
using BlogNetCore.AppService.Repository.Core;
using BlogNetCore.AppService.Services;
using BlogNetCore.Test.TestData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BlogNetCore.Test
{
    public class PostServiceTest
    {
        public readonly PostService postService;
        public readonly Mock<IRepository<Post>> postRepository;
        public readonly Mock<IRepository<Category>> categoryRepository;
        public readonly Mock<IMapper> mapper;

        public PostServiceTest()
        {
            postRepository = new Mock<IRepository<Post>>();
            categoryRepository = new Mock<IRepository<Category>>();
            mapper = new Mock<IMapper>();
            postService = new PostService(postRepository.Object, categoryRepository.Object, mapper.Object);
        }

        [Fact]
        public void IsExist_Test_ReturnTrue()
        {
            var query = PostData.GetPostsQueryable();
            postRepository.Setup(r => r.Query()).Returns(query);

            var isExist = postService.IsExist(1);

            Assert.True(isExist);
        }

        [Fact]
        public void IsExist_Test_ReturnFalse()
        {
            var query = PostData.GetPostsQueryable();
            postRepository.Setup(r => r.Query()).Returns(query);

            var isExist = postService.IsExist(99);

            Assert.False(isExist);
        }
    }
}
