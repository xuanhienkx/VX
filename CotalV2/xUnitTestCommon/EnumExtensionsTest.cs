using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Cotal.Core.Common.Enums;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace xUnitTestCommon
{
    public class EnumExtensionsTest : TestBase
    {

        public EnumExtensionsTest(ITestOutputHelper output) : base(output)
        {
        }
        [Theory]
        [InlineData("FunctionType")]
        [InlineData("SlideType")]
        [InlineData("ActionEnum")]
        public void GetObjectListByTypeTest(string type)
        { 
            var list = EnumExtensions.GetObjectListByType(type);
            Output.WriteLine(JsonConvert.SerializeObject(list));
            Assert.NotNull(list);
        }
    }

    public class TestBase
    {
        public readonly ITestOutputHelper Output;

        public TestBase(ITestOutputHelper output)
        {
            this.Output = output ?? throw new ArgumentNullException(nameof(output));
        }
    }
}
