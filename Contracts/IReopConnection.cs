using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Contracts
{
   public interface IReopConnection {

		IDbConnection Connection(string aConnectionString);
		string ConnectionString { get; }
		string DatabaseName { get; }


	}
}
