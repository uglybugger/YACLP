using Shouldly;
using Xunit;

namespace Yaclp.Tests.WhiteBox.GivenAModelWithMandatoryAndOptionalParameters
{
    
    public class WhenParsingAValidButOutOfOrderArgumentList : TestFor<Parser<ModelWithMandatoryAndOptionalParameters>>
    {
        private ModelWithMandatoryAndOptionalParameters _result;

        protected override Parser<ModelWithMandatoryAndOptionalParameters> Given()
        {
            return  YaclpParserFactory.CreateParserFor<ModelWithMandatoryAndOptionalParameters>();
        }

        protected override void When()
        {
            var args = new[] {"foo", "/Baz:baz", "/Bar:bar"};
            _result = Subject.Parse(args);
        }

        [Fact]
        public void NothingShouldGoBang()
        {
        }

        [Fact]
        public void FooShouldBeCorrect()
        {
            _result.Foo.ShouldBe("foo");
        }

        [Fact]
        public void BarShouldBeCorrect()
        {
            _result.Bar.ShouldBe("bar");
        }

        [Fact]
        public void BazShouldBeCorrect()
        {
            _result.Baz.ShouldBe("baz");
        }
    }
}