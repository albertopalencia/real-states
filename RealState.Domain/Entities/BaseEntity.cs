namespace RealState.Domain.Entities
{
	using System.Diagnostics.CodeAnalysis;

	[ExcludeFromCodeCoverage]
	public abstract class BaseEntity
	{
		public int Id { get; set; }
	}
}