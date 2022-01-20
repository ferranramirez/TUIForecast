using System;
using System.Collections.Generic;
using System.Text;
using TUIForecast.Application.Domain.Model;

namespace TUIForecast.Application.Contract.RequestServices
{
    public interface ICityRequestService
    {
        IEnumerable<CityInfo> GetAll();
    }
}
