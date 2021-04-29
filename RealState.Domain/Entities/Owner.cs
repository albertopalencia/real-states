using System;

namespace RealState.Domain.Entities
{
	public class Owner : BaseEntity
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public string Photo { get; set; }
		public DateTime Birthday { get; set; }
	}
}