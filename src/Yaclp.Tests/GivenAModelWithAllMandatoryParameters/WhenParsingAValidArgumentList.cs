using NUnit.Framework;
using Shouldly;

namespace Yaclp.Tests.GivenAModelWithAllMandatoryParameters
{
    [TestFixture]
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
            _result.Bar.ShouldBe(_bar);
        }

        [Test]
        public void BazShouldBeCorrect()
        {
            _result.Baz.ShouldBe(_baz);
        }
    }
}