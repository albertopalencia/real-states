// ***********************************************************************
// Assembly         : RealState.Application
// Author           : Alberto Palencia
// Created          : 05-02-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-03-2021
// ***********************************************************************
// <copyright file="PropertyService.cs" company="RealState.Application">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Options;
using RealState.Application.Abstract;
using RealState.Application.DTO;
using RealState.Application.DTO.Property;
using RealState.Domain.Entities;
using RealState.Infrastructure.Interfaces.Repository;
using RealState.Infrastructure.Options;
using RealState.Infrastructure.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RealState.Infrastructure.Extensions;

namespace RealState.Application.Implements
{
	/// <summary>
	/// Interface IPropertyService
	/// Implements the <see cref="RealState.Application.Abstract.IPropertyService" />
	/// </summary>
	/// <seealso cref="RealState.Application.Abstract.IPropertyService" />
	public class PropertyService : IPropertyService
	{
		/// <summary>
		/// The repository
		/// </summary>
		private readonly IPropertyRepository _repository;

		/// <summary>
		/// The pagination option
		/// </summary>
		private readonly PaginationOption _paginationOption;

		/// <summary>
		/// Initializes a new instance of the <see cref="PropertyService" /> class.
		/// </summary>
		/// <param name="repository">The repository.</param>
		/// <param name="paginationOption">The pagination option.</param>
		public PropertyService(IPropertyRepository repository, IOptions<PaginationOption> paginationOption)
		{
			_repository = repository;
			_paginationOption = paginationOption.Value;
		}

		/// <summary>
		/// Gets all properties.
		/// </summary>
		/// <returns>Task&lt;IEnumerable&lt;Property&gt;&gt;.</returns>
		public async Task<IEnumerable<PropertyListDto>> GetAllProperties()
		{
			var propertyList = await _repository.GetAllAsync();
			return propertyList.Select<Property, PropertyListDto>(p => p);
		}

		/// <summary>
		/// Gets the paged properties.
		/// </summary>
		/// <param name="paginate">The paginate.</param>
		/// <param name="propertyRequest">The property request.</param>
		/// <returns>Task&lt;PagedList&lt;PropertyListDto&gt;&gt;.</returns>
		public async Task<PagedList<PropertyListDto>> GetPagedProperties(QueryParamDto paginate, PropertyRequestDto propertyRequest)
		{
			paginate.PageNumber = paginate.PageNumber == decimal.Zero ? _paginationOption.DefaultPageNumber : paginate.PageNumber;
			paginate.PageSize = paginate.PageSize == decimal.Zero ? _paginationOption.DefaultPageSize : paginate.PageSize;
			var propertyExpression = BuildPropertyExpression(propertyRequest);
			var propertyList = await _repository.GetAllAsync(propertyExpression, o => o.OrderBy(s => s.Name), include: BuildPropertyIncludes);
			return PagedList<PropertyListDto>.Create(propertyList.Select<Property, PropertyListDto>(p => p).ToList(), propertyList.Count(), paginate.PageNumber, paginate.PageSize);
		}

		/// <summary>
		/// Builds the property expression.
		/// </summary>
		/// <param name="request">The property request.</param>
		/// <returns>System.Linq.Expressions.Expression&lt;System.Func&lt;RealState.Domain.Entities.Property, System.Boolean&gt;&gt;.</returns>
		public Expression<Func<Property, bool>> BuildPropertyExpression(PropertyRequestDto request)
		{  
			
			if ( string.IsNullOrEmpty(request.Name)  && string.IsNullOrEmpty(request.CodeInternal) && request.Year == decimal.Zero) return PredicateBuilderExtension.True<Property>();


			var predicate = PredicateBuilderExtension.False<Property>(); 

			if (!string.IsNullOrEmpty(request.Name))
			{
				predicate = predicate.Or(p =>   p.Name.Contains(request.Name) );
			}

			if (!string.IsNullOrEmpty(request.CodeInternal))
			{
				predicate = predicate.Or(p => p.CodeInternal.Equals(request.CodeInternal) );
			}

			if (request.Year > decimal.Zero)
			{
				predicate = predicate.Or(p =>   p.Year == request.Year );
			}


			
			return predicate;
		}

		/// <summary>
		/// Gets the build property includes.
		/// </summary>
		/// <value>The build property includes.</value>
		protected Func<IQueryable<Property>, IIncludableQueryable<Property, object>> BuildPropertyIncludes =>
			i => i.Include(s => s.IdOwnerNavigation);
	}
}