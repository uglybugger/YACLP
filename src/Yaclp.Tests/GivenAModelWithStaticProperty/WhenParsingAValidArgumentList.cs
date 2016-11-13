using NUnit.Framework;
using Shouldly;

namespace Yaclp.Tests.GivenAModelWithStaticProperty
{
    [TestFixture]
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

        [Test]
        public void NothingShouldGoBang()
        {
        }

        [Test]
        public void FooShouldBeCorrect()
        {
            _result.Foo.ShouldBe(_foo);
        }

        [Test]
        public void BarShouldBeCorrect()
        {
            ModelWithStaticProperty.Bar.ShouldBe(null);
        }
    }
}