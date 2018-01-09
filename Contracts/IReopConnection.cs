using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Contracts
{
   public interface IReopConnection {

		IDbConnection Connection(string aConnectionString);
		IDataAdapter DataAdapter(); //Not sure about this
		string ConnectionString { get; }
		string DatabaseName { get; }


	}
}
