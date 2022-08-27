using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace SportsAppxUnitTestProject
{
    public partial class CategoriesApiTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public CategoriesApiTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }
    }
}
