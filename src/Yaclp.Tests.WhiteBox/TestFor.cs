namespace Yaclp.Tests
{
    
    public abstract class TestFor<T> where T : class
    {
        protected T Subject { get; private set; }
        protected abstract T Given();
        protected abstract void When();

        public TestFor()
        {
            Subject = Given();
            When();

        }
    }
}