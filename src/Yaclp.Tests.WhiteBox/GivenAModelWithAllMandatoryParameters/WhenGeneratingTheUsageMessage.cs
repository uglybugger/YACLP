using Shouldly;
using Xunit;

namespace Yaclp.Tests.WhiteBox.GivenAModelWithAllMandatoryParameters
{
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

        [Fact]
        public void TheMessageShouldMentionFoo()
        {
            _result.Contains("Foo").ShouldBe(true);
        }

        [Fact]
        public void TheMessageShouldMentionBar()
        {
            _result.Contains("Bar").ShouldBe(true);
        }

        [Fact]
        public void TheMessageShouldMentionBaz()
        {
            _result.Contains("Baz").ShouldBe(true);
        }
    }
}