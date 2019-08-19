using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Api.ResponseModels
{
    public class PraksaDetailsResponseModel
    {
        public int Godina { get; set; }
        public List<string> KorisnickaImena { get; set; }
    }
}
