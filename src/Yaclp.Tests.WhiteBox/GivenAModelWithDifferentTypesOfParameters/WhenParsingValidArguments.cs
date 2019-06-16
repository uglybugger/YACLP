using Shouldly;
using Xunit;

namespace Yaclp.Tests.WhiteBox.GivenAModelWithDifferentTypesOfParameters
{
    
    public class WhenParsingValidArguments : TestFor<Parser<AllDifferentTypesOfParametersModel>>
    {
        private AllDifferentTypesOfParametersModel _result;

        protected override Parser<AllDifferentTypesOfParametersModel> Given()
        {
            return YaclpParserFactory.CreateParserFor<AllDifferentTypesOfParametersModel>();
        }

        protected override void When()
        {
            var args = new[] {"somestring", "1", "true", "2", "false"};
            _result = Subject.Parse(args);
        }

        [Fact]
        public void TheStringShouldBeCorrect()
        {
            _result.SomeString.ShouldBe("somestring");
        }

        [Fact]
        public void TheIntShouldBeCorrect()
        {
            _result.SomeInt.ShouldBe(1);
        }

        [Fact]
        public void TheBoolShouldBeCorrect()
        {
            _result.SomeBool.ShouldBe(true);
        }

        [Fact]
        public void TheNullableIntShouldBeCorrect()
        {
            _result.SomeNullableInt.ShouldBe(2);
        }

        [Fact]
        public void TheNullableBoolShouldBeCorrect()
        {
            _result.SomeNullableBool.ShouldBe(false);
        }
    }
}