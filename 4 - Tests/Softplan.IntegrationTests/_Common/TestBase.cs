using Moq;
using Softplan.IntegrationTests._Common.Utils;
using System;
using System.Collections.Generic;
using Xunit;

namespace Softplan.IntegrationTests._Common
{
    public abstract class TestBase : IClassFixture<SoftplanFixture>
    {
        protected readonly Uri Uri;
        protected readonly Request Request;

        private readonly Dictionary<Type, Mock> _mocks;

        public TestBase(SoftplanFixture fixture, string url)
        {
            Request = fixture.Request;
            Uri = new Uri($"{fixture.Client.BaseAddress}/{url}");
        }

        protected Mock<T> GetMock<T>() where T : class
        {
            var type = typeof(T);
            if (!_mocks.ContainsKey(type)) return null;
            var mock = _mocks[type];
            mock.Invocations.Clear();
            return mock as Mock<T>;
        }
    }
}
