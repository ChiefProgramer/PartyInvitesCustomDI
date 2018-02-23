using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Contracts
{
   public interface IRepoConnection {

		string ConnectionString { get; set; }
		string DbConnectionString { get; }
		string DatabaseName { get; set; }

		IDbConnection Connection(string aConnectionString);
		IDbConnection Connection(); 

	}
}
