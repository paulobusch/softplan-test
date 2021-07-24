using System.Collections.Generic;

namespace Softplan.IntegrationTests._Common.Results
{
    public class ResultTest<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> ErrorMessages { get; set; }
    }

    public class ResultTest : ResultTest<dynamic> { }
}
