
using Shouldly;
using Xunit;

namespace Yaclp.Tests.GivenAModelWithStaticProperty
{
    
    public class WhenParsingAValidArgumentList : TestFor<Parser<ModelWithStaticProperty>>
    {
        private const string _foo = "foo";

        private ModelWithStaticProperty _result;

        protected override Parser<ModelWithStaticProperty> Given()
        {
            return YaclpParserFactory.CreateParserFor<ModelWithStaticProperty>();
        }

        protected override void When()
        {
            var args = new[] { _foo };
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
            ModelWithStaticProperty.Bar.ShouldBe(null);
        }
    }
}