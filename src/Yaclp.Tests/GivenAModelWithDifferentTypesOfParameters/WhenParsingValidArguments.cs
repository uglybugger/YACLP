using NUnit.Framework;
using Shouldly;

namespace Yaclp.Tests.GivenAModelWithDifferentTypesOfParameters
{
    [TestFixture]
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

        [Test]
        public void TheStringShouldBeCorrect()
        {
            _result.SomeString.ShouldBe("somestring");
        }

        [Test]
        public void TheIntShouldBeCorrect()
        {
            _result.SomeInt.ShouldBe(1);
        }

        [Test]
        public void TheBoolShouldBeCorrect()
        {
            _result.SomeBool.ShouldBe(true);
        }

        [Test]
        public void TheNullableIntShouldBeCorrect()
        {
            _result.SomeNullableInt.ShouldBe(2);
        }

        [Test]
        public void TheNullableBoolShouldBeCorrect()
        {
            _result.SomeNullableBool.ShouldBe(false);
        }
    }
}