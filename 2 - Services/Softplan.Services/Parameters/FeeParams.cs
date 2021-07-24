using Microsoft.AspNetCore.Mvc;

namespace Softplan.Services.Models.Params
{
    public class FeeParams
    {
        [FromQuery(Name = "valorinicial")]
        public decimal Capital { get; set; }

        [FromQuery(Name = "meses")]
        public int Time { get; set; }
    }
}
