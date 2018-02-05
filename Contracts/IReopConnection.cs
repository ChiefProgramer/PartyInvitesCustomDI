using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Contracts
{
   public interface IRepoConnection {
		
		IDbConnection Connection(string aConnectionString);
		string ConnectionString { get; set; }
		string DatabaseName { get; set; }


	}
}
