using Shouldly;
using Xunit;

namespace Yaclp.Tests.WhiteBox.GivenAModelWithStaticProperty
{
    
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

        [Fact]
        public void TheMessageShouldMentionFoo()
        {
            _result.Contains("Foo").ShouldBe(true);
        }

        [Fact]
        public void TheMessageShouldNotMentionBar()
        {
            _result.Contains("Bar").ShouldBe(false);
        }
    }
}