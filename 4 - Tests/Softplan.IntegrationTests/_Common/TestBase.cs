using Softplan.IntegrationTests._Common.Utils;
using System;
using Xunit;

namespace Softplan.IntegrationTests._Common
{
    public abstract class TestBase : IClassFixture<SoftplanFixture>
    {
        protected readonly Uri Uri;
        protected readonly Request Request;

        public TestBase(SoftplanFixture fixture, string url)
        {
            Request = fixture.Request;
            Uri = new Uri($"{fixture.Client.BaseAddress}/{url}");
        }
    }
}
