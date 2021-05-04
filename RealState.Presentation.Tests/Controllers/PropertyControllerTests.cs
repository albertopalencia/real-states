// ***********************************************************************
// Assembly         : RealState.Presentation.Tests
// Author           : Alberto Palencia
// Created          : 05-03-2021
//
// Last Modified By : Alberto Palencia
// Last Modified On : 05-03-2021
// ***********************************************************************
// <copyright file="PropertyControllerTests.cs" company="RealState.Presentation.Tests">
//     Copyright (c) AlbertPalencia. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RealState.Api.Controllers;
using RealState.Application.Abstract;
using RealState.Application.DTO;
using RealState.Application.DTO.Property;
using RealState.Infrastructure.Pages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealState.Presentation.Tests.Controllers
{
	/// <summary>
	/// Defines test class PropertyControllerTests.
	/// </summary>
	[TestFixture]
	public class PropertyControllerTests
	{
		/// <summary>
		/// The mock repository
		/// </summary>
		private MockRepository _mockRepository;

		/// <summary>
		/// The mock property service
		/// </summary>
		private Mock<IPropertyService> _mockPropertyService;

		/// <summary>
		/// Sets up.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			_mockRepository = new MockRepository(MockBehavior.Strict);

			_mockPropertyService = _mockRepository.Create<IPropertyService>();
		}

		private PropertyController CreatePropertyController()
		{
			return new(_mockPropertyService.Object);
		}

		[Test]
		[Author("Alberto Palencia Benedetti")]
		public async Task GetPagedProperties_StateUnderTest_ExpectedBehavior()
		{
			var propertyController = CreatePropertyController();
			var paginate = new QueryParamDto { PageSize = 1, PageNumber = 3 };
			var request = new PropertyRequestDto { Year = 2021 };
			var propertyList = new List<PropertyListDto>
			{
				new()
				{
					Name = "Propertie 1", Year = 2021, CodeInternal = "10212"
				}
			};

			var pagedList = PagedList<PropertyListDto>.Create(propertyList, propertyList.Count, paginate.PageNumber,
				paginate.PageNumber);

			_mockPropertyService.Setup(s => s.GetPagedProperties(paginate, request)).ReturnsAsync(pagedList);

			var result = await propertyController.GetPagedProperties(paginate, request);
			var responseOkResult = result as OkObjectResult;
			Assert.AreEqual(200, responseOkResult?.StatusCode);
			_mockRepository.VerifyAll();
		}
	}
}