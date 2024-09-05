using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.ClientModel;

public class ClientModelSettings : IClientModelSettings
{
    public Uri? Endpoint { get; set; }
}
