using System;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Yaclp.Tests.GivenAModelWithAllMandatoryParameters;

namespace Yaclp.Tests.GivenAModelWithSomeParameterDescriptions
{
    [TestFixture]
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

        [Test]
        public void TheMessageShouldMentionFoosDescription()
        {
            var fooLine = _result
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Skip(3)
                .First();
            fooLine.ShouldBe("	Foo                                      	This is Foo ");
        }

        [Test]
        public void TheMessageShouldMentionBarsDefault()
        {
            var barLine = _result
                .Split(Environment.NewLine.ToCharArray(),StringSplitOptions.RemoveEmptyEntries)
                .Skip(4)
                .First();

            barLine.ShouldBe("	Bar                                      	e.g. 'Bar Default'");
        }

        [Test]
        public void TheMessageShouldMentionBazsExample()
        {
            var bazLine = _result
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Skip(5)
                .First();

            bazLine.ShouldBe("	Baz                                      	e.g. 'Baz Example'");
        }

        [Test]
        public void TheMessageShouldMentionLongParamsNoIdea()
        {
            var bazLine = _result
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Skip(6)
                .First();

            bazLine.ShouldBe("	MuchLongerParameterNameToMessUpFormatting	(No idea. Sorry.)");
        }

        [Test]
        public void TheMessageShouldMentionAllsDescriptionAndExample()
        {
            var bazLine = _result
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Skip(7)
                .First();

            bazLine.ShouldBe("	All                                      	This is All e.g. 'All Example'");
        }

        [Test]
        public void TheMessageShouldMentionDescAndDefaultsDescriptionAndDefault()
        {
            var bazLine = _result
                .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Skip(8)
                .First();

            bazLine.ShouldBe("	DescAndDefault                           	This is DescAndDefault e.g. 'DescAndDefault Default'");
        }

        [Test]
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