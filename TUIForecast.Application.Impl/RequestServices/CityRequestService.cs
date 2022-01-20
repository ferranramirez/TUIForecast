using System;
using System.Collections.Generic;
using System.Text;
using TUIForecast.Application.Contract.RequestServices;
using TUIForecast.Application.Domain.Model;

namespace TUIForecast.Application.Impl.RequestServices
{
    public class CityRequestService : ICityRequestService
    {
        public IEnumerable<CityInfo> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
