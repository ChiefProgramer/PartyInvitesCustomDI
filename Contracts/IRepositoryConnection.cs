using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Contracts
{
    public interface IRepositoryConnection
    {
        IDbConnection Connection(string aConnectionString);
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
