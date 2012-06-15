using NUnit.Framework;

namespace Yaclp.Tests
{
    [TestFixture]
    public abstract class TestFor<T> where T : class
    {
        protected T Subject { get; private set; }
        protected abstract T Given();
        protected abstract void When();

        [SetUp]
        public void SetUp()
        {
            Subject = Given();
            When();
        }
    }
}