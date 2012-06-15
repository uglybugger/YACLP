using NUnit.Framework;
using Shouldly;

namespace Yaclp.Tests.GivenAModelWithAllMandatoryParameters
{
    [TestFixture]
    public class WhenGeneratingTheUsageMessage : TestFor<UsageMessageBuilder>
    {
        private string _result;

        protected override UsageMessageBuilder Given()
        {
            return new UsageMessageBuilder(typeof(ModelWithAllMandatoryParameters));
        }

        protected override void When()
        {
            _result = Subject.Build();
        }

        [Test]
        public void TheMessageShouldMentionFoo()
        {
            _result.Contains("Foo").ShouldBe(true);
        }

        [Test]
        public void TheMessageShouldMentionBar()
        {
            _result.Contains("Bar").ShouldBe(true);
        }

        [Test]
        public void TheMessageShouldMentionBaz()
        {
            _result.Contains("Baz").ShouldBe(true);
        }
    }
}