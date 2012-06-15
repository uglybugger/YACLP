using NUnit.Framework;
using Shouldly;

namespace Yaclp.Tests.GivenAModelWithMandatoryAndOptionalParameters
{
    [TestFixture]
    public class WhenParsingAValidButOutOfOrderArgumentList : TestFor<Parser<ModelWithMandatoryAndOptionalParameters>>
    {
        private ModelWithMandatoryAndOptionalParameters _result;

        protected override Parser<ModelWithMandatoryAndOptionalParameters> Given()
        {
            return new Parser<ModelWithMandatoryAndOptionalParameters>();
        }

        protected override void When()
        {
            var args = new[] {"foo", "/Baz:baz", "/Bar:bar"};
            _result = Subject.Parse(args);
        }

        [Test]
        public void NothingShouldGoBang()
        {
        }

        [Test]
        public void FooShouldBeCorrect()
        {
            _result.Foo.ShouldBe("foo");
        }

        [Test]
        public void BarShouldBeCorrect()
        {
            _result.Bar.ShouldBe("bar");
        }

        [Test]
        public void BazShouldBeCorrect()
        {
            _result.Baz.ShouldBe("baz");
        }
    }
}