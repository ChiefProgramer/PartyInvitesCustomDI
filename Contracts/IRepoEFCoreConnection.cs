using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepoEFCoreConnection {

		string  ConnectionString { get; set; }
		string  DbFileName { get; }
	}
}
