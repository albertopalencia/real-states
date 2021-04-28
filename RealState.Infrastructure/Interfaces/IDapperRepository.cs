﻿namespace RealState.Infrastructure.Interfaces
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IDapperRepository<T> where T : class
	{
		Task<IEnumerable<T>> ExecuteQuerySelectAsync(string cnx, string query, object filter = null);

		Task<T> ExecuteFirstOrDefaultAsync(string cnx, string query, object filter = null);

		Task<IEnumerable<T>> ExecuteStoreProcedureAsync(string cnx, string storeProcedure, object filter = null);

		Task<int> ExecuteQueryScalarAsync(string cnx, string query, object filter = null);
	}
}