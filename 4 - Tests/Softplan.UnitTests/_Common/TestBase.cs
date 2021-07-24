using Xunit;

namespace Softplan.UnitTests._Common
{
    public abstract class TestBase : IClassFixture<SoftplanFixture>
    {
        public TestBase(SoftplanFixture _) { }
    }
}
