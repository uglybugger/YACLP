using System;
using System.Linq;
using Shouldly;
using Xunit;
using Yaclp.Tests.GivenAModelWithAllMandatoryParameters;

namespace Yaclp.Tests.GivenAModelWithSomeParameterDescriptions
{
    
    public class WhenGeneratingTheUsageMessage : TestFor<UsageMessageBuilder>
    {
        private string _result;

        protected override UsageMessageBuilder Given()
        {
            return new UsageMessageBuilder(typeof(ModelWithParameterDocumentation));
        }

        protected override void When()
        {
            _result = Subject.Build();
        }

        [Fact]
        public void TheMessageShouldMentionFoosDescription()
        {
            var fooLine = _result
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Skip(3)
                .First();
            fooLine.ShouldBe("	Foo                                      	This is Foo ");
        }

        [Fact]
        public void TheMessageShouldMentionBarsDefault()
        {
            var barLine = _result
                .Split(Environment.NewLine.ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                .Skip(4)
                .First();

            barLine.ShouldBe("	Bar                                      	e.g. 'Bar Default'");
        }

        [Fact]
        public void TheMessageShouldMentionBazsExample()
        {
            var bazLine = _result
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Skip(5)
                .First();

            bazLine.ShouldBe("	Baz                                      	e.g. 'Baz Example'");
        }

        [Fact]
        public void TheMessageShouldMentionLongParamsNoIdea()
        {
            var bazLine = _result
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Skip(6)
                .First();

            bazLine.ShouldBe("	MuchLongerParameterNameToMessUpFormatting	(No idea. Sorry.)");
        }

        [Fact]
        public void TheMessageShouldMentionAllsDescriptionAndExample()
        {
            var bazLine = _result
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Skip(7)
                .First();

            bazLine.ShouldBe("	All                                      	This is All e.g. 'All Example'");
        }

        [Fact]
        public void TheMessageShouldMentionDescAndDefaultsDescriptionAndDefault()
        {
            var bazLine = _result
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Skip(8)
                .First();

            bazLine.ShouldBe("	DescAndDefault                           	This is DescAndDefault e.g. 'DescAndDefault Default'");
        }

        [Fact]
        public void TheDescriptionShouldBeFormattedNicely()
        {
            var lines = _result.Split(Environment.NewLine.ToCharArray());
            lines.ShouldContain("	Foo                                      	This is Foo ");
            lines.ShouldContain("	Bar                                      	e.g. 'Bar Default'");
            lines.ShouldContain("	Baz                                      	e.g. 'Baz Example'");
            lines.ShouldContain("	MuchLongerParameterNameToMessUpFormatting	(No idea. Sorry.)");
            lines.ShouldContain("	All                                      	This is All e.g. 'All Example'");
            lines.ShouldContain("	DescAndDefault                           	This is DescAndDefault e.g. 'DescAndDefault Default'");
        }
    }
}