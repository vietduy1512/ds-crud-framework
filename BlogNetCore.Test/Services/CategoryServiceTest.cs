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
    public class CategoryServiceTest
    {
        public readonly CategoryService categoryService;
        public readonly Mock<IRepository<Category>> categoryRepository;
        public readonly Mock<IMapper> mapper;

        public CategoryServiceTest()
        {
            categoryRepository = new Mock<IRepository<Category>>();
            mapper = new Mock<IMapper>();
            categoryService = new CategoryService(categoryRepository.Object, mapper.Object);
        }

        [Fact]
        public void IsExist_Test_ReturnTrue()
        {
            var query = CategoryData.GetCategoriesQueryable();
            categoryRepository.Setup(r => r.Query()).Returns(query);

            var isExist = categoryService.IsExist(1);

            Assert.True(isExist);
        }

        [Fact]
        public void IsExist_Test_ReturnFalse()
        {
            var query = CategoryData.GetCategoriesQueryable();
            categoryRepository.Setup(r => r.Query()).Returns(query);

            var isExist = categoryService.IsExist(99);

            Assert.False(isExist);
        }
    }
}
