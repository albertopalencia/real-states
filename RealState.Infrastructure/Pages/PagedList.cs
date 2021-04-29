namespace RealState.Infrastructure.Pages
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.CodeAnalysis;

	[ExcludeFromCodeCoverage]
	public class PagedList<T> : List<T>
	{
		public int CurrentPage { get; set; }

		public int TotalPages { get; set; }

		public int PageSize { get; set; }

		public int TotalCount { get; set; }

		public bool HasPreviousPage => CurrentPage > 1;

		public bool HasNextPage => CurrentPage < TotalPages;

		public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : (int?)null;

		public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : (int?)null;

		public PagedList(List<T> items, int count, int pageNumber, int pageSize)
		{
			TotalCount = count;
			PageSize = pageSize;
			CurrentPage = pageNumber;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);

			AddRange(items);
		}

		public static PagedList<T> Create(List<T> source, int count, int pageNumber, int pageSize)
		{
			return new PagedList<T>(source, count, pageNumber, pageSize);
		}
	}
}