using NUnit.Framework;
using Shouldly;

namespace Yaclp.Tests.GivenAModelWithStaticProperty
{
    [TestFixture]
    public class WhenGeneratingTheUsageMessage : TestFor<UsageMessageBuilder>
    {
        private string _result;

        protected override UsageMessageBuilder Given()
        {
            return new UsageMessageBuilder(typeof(ModelWithStaticProperty));
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
        public void TheMessageShouldNotMentionBar()
        {
            _result.Contains("Bar").ShouldBe(false);
        }
    }
}