using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OohelpWebApps.Presentations.Api.Contracts
{
    public abstract class BaseRequest : Common.Interfaces.IRequest
    {
        public string Key { get; set; }
    }
}
