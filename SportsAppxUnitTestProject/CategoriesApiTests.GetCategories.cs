using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using SportsApp.Controllers;
using SportsApp.Models;
using Xunit;
using Xunit.Abstractions;
using static SportsAppxUnitTestProject.CategoriesApiTests;

namespace SportsAppxUnitTestProject
{
    public partial class CategoriesApiTests
    {
        [Fact]
        public void GetCategories_OkResult()
        {
            var dbName = nameof(CategoriesApiTests.GetCategories_OkResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new CategoriesController(dbContext, logger);

            IActionResult actionresult = controller.GetCategories().Result;

            Assert.IsType<OkObjectResult>(actionresult);

            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK;
            var actualStatusCode = (actionresult as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategories_CheckCorrectResult()    // second 
        {
            var dbName = nameof(CategoriesApiTests.GetCategories_CheckCorrectResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new CategoriesController(dbContext, logger);

            IActionResult actionresult = controller.GetCategories().Result;

            Assert.IsType<OkObjectResult>(actionresult);

            var okResult = actionresult.Should().BeOfType<OkObjectResult>().Subject;

            Assert.IsAssignableFrom<List<Category>>(okResult.Value); //error can be found

            var categories = okResult.Value.Should().BeAssignableTo<List<Category>>().Subject;

            Assert.NotNull(categories);

            Assert.Equal(expected: DbContextMocker.TestData_Categories.Length,
                        actual: categories.Count);


            int ndx = 0;
            foreach (Category Category in DbContextMocker.TestData_Categories)
            {
                Assert.Equal<int>(expected: Category.CategoryId,
                    actual: categories[ndx].CategoryId);

                Assert.Equal(expected: Category.CategoryName,
                    actual: categories[ndx].CategoryName);

                _outputHelper.WriteLine($"Row # {ndx} Okay !!! Issue Id - {Category.CategoryId} Issue - {Category.CategoryName}");
                ndx++;
            }

        }
    }
}
