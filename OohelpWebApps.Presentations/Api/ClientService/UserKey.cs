using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OohelpWebApps.Presentations.Api.ClientService
{
    public class UserKey
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
    }
}
