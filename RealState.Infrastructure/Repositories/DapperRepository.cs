namespace RealState.Infrastructure.Repositories
{
	using Dapper;
	using Microsoft.Data.SqlClient;
	using RealState.Infrastructure.Interfaces;
	using System.Collections.Generic;
	using System.Data;
	using System.Diagnostics.CodeAnalysis;
	using System.Threading.Tasks;

	[ExcludeFromCodeCoverage]
	public class DapperRepository<T> : IDapperRepository<T> where T : class
	{
		#region Métodos Públicos

		public async Task<IEnumerable<T>> ExecuteQuerySelectAsync(string cnx, string query, object filter = null)
		{
			using var conn = new SqlConnection(cnx);
			conn.Open();
			var result = await conn.QueryAsync<T>(query, filter).ConfigureAwait(false);
			conn.Close();
			return result;
		}

		public async Task<T> ExecuteFirstOrDefaultAsync(string cnx, string query, object filter = null)
		{
			using var conn = new SqlConnection(cnx);
			conn.Open();
			var result = await conn.QueryFirstOrDefaultAsync<T>(query, filter).ConfigureAwait(false);
			conn.Close();
			return result;
		}

		public async Task<IEnumerable<T>> ExecuteStoreProcedureAsync(string cnx, string storeProcedure, object filter = null)
		{
			using var conn = new SqlConnection(cnx);
			conn.Open();
			var result = await conn.QueryAsync<T>(storeProcedure, filter, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
			conn.Close();
			return result;
		}

		public async Task<int> ExecuteQueryScalarAsync(string cnx, string query, object filter = null)
		{
			using var conn = new SqlConnection(cnx);
			conn.Open();
			var result = await conn.ExecuteScalarAsync<int>(query, filter).ConfigureAwait(false);
			conn.Close();
			return result;
		}

		#endregion Métodos Públicos
	}
}