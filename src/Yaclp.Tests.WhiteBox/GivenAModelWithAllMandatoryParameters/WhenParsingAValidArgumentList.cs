using Shouldly;
using Xunit;

namespace Yaclp.Tests.WhiteBox.GivenAModelWithAllMandatoryParameters
{
    
    public class WhenParsingAValidArgumentList : TestFor<Parser<ModelWithAllMandatoryParameters>>
    {
        private const string _foo = "foo";
        private const string _bar = "bar";
        private const string _baz = "baz";

        private ModelWithAllMandatoryParameters _result;

        protected override Parser<ModelWithAllMandatoryParameters> Given()
        {
            return YaclpParserFactory.CreateParserFor<ModelWithAllMandatoryParameters>();
        }

        protected override void When()
        {
            var args = new[] {_foo, _bar, _baz};
            _result = Subject.Parse(args);
        }

        [Fact]
        public void NothingShouldGoBang()
        {
        }

        [Fact]
        public void FooShouldBeCorrect()
        {
            _result.Foo.ShouldBe(_foo);
        }

        [Fact]
        public void BarShouldBeCorrect()
        {
            _result.Bar.ShouldBe(_bar);
        }

        [Fact]
        public void BazShouldBeCorrect()
        {
            _result.Baz.ShouldBe(_baz);
        }
    }
}