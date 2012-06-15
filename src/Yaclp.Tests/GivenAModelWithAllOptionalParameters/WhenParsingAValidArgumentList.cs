using NUnit.Framework;
using Shouldly;

namespace Yaclp.Tests.GivenAModelWithAllOptionalParameters
{
    public class WhenParsingAValidArgumentList : TestFor<Parser<ModelWithAllOptionalParameters>>
    {
        private const string _foo = "foo";
        private const string _bar = "bar";
        private const string _baz = "baz";

        private ModelWithAllOptionalParameters _result;

        protected override Parser<ModelWithAllOptionalParameters> Given()
        {
            return YaclpParserFactory.CreateParserFor<ModelWithAllOptionalParameters>();
        }

        protected override void When()
        {
            var args = new[] {BuildParam("Foo", _foo), BuildParam("Bar", _bar), BuildParam("Baz", _baz)};
            _result = Subject.Parse(args);
        }

        private static string BuildParam(string key, string value)
        {
            return string.Format("/{0}:{1}", key, value);
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