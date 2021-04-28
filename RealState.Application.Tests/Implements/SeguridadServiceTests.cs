// ***********************************************************************
// Assembly         : XM.Evento.ConsultaGeneral.Application.Test
// Author           : Alberto Palencia
// Created          : 08-10-2020
//
// Last Modified By : Alberto Palencia
// Last Modified On : 08-10-2020
// ***********************************************************************
// <copyright file="SeguridadServiceTests.cs" company="XM.Evento.ConsultaGeneral.Application.Test">
//     Copyright (c) Ingeneo SAS. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace XM.LeccionesAprendidas.Application.Tests.Implements
{
	using Moq;
	using NUnit.Framework;
	using System.Threading.Tasks;
	using XM.LeccionesAprendidas.Application.Abstract;
	using XM.LeccionesAprendidas.Application.Implements;
	using XM.LeccionesAprendidas.Domain.DTO;
	using XM.LeccionesAprendidas.Domain.Entities;
	using XM.LeccionesAprendidas.Infrastructure.Interfaces;

	/// <summary>
	/// Defines test class SeguridadServiceTests.
	/// </summary>
	[TestFixture]
	public class SeguridadServiceTests
	{
		/// <summary>
		/// The mock repository
		/// </summary>
		private MockRepository mockRepository;

		/// <summary>
		/// The mock unit of work
		/// </summary>
		private Mock<IUnitOfWork> mockUnitOfWork;

		/// <summary>
		/// The mock contrasena service
		/// </summary>
		private Mock<IContrasenaService> mockContrasenaService;

		/// <summary>
		/// Sets up.
		/// </summary>
		[SetUp]
		public void SetUp()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockUnitOfWork = this.mockRepository.Create<IUnitOfWork>();
			this.mockContrasenaService = this.mockRepository.Create<IContrasenaService>();
		}

		/// <summary>
		/// Creates the service.
		/// </summary>
		/// <returns>SeguridadService.</returns>
		private SeguridadService CreateService()
		{
			return new SeguridadService(
				this.mockUnitOfWork.Object,
				this.mockContrasenaService.Object);
		}

		/// <summary>
		/// Defines the test method CrearUsuario_Resultado_Exitoso.
		/// </summary>
		/// <returns>Task.</returns>
		[Test]
		[Author("Alberto Palencia")]
		public async Task CrearUsuario_Resultado_Exitoso()
		{
			var service = this.CreateService();
			var usuario = new SeguridadMicroServicio
			{
				Contrasena = "10000.feUzERp1/cWLzjxJD6dl+g==.XSCcROLL98o00jrC7xWbariI4lz1V1plbUECiBdT3Cw=",
				NombreUsuario = "pepito",
				Rol = Domain.Enumerations.RoleType.Administrador,
				Usuario = "juanmijo"
			};

			mockUnitOfWork.Setup(s => s.SeguridadRepository.Add(usuario)).Verifiable();
			mockUnitOfWork.Setup(s => s.SaveChangesAsync()).Returns(Task.CompletedTask);
			await service.CrearUsuario(usuario);
			Assert.NotNull(usuario);
			this.mockRepository.VerifyAll();
		}

		/// <summary>
		/// Defines the test method ValidarUsuario_Exitoso.
		/// </summary>
		/// <returns>Task.</returns>
		[Test]
		[Author("Alberto Palencia")]
		public async Task ValidarUsuario_Exitoso()
		{
			var service = this.CreateService();
			const string contrasena = "10000.feUzERp1/cWLzjxJD6dl+g==.XSCcROLL98o00jrC7xWbariI4lz1V1plbUECiBdT3Cw=";
			var usuario = new SeguridadDto { Usuario = "Pepito", Contrasena = "Master1248*" };
			var seguridad = new SeguridadMicroServicio { Contrasena = contrasena, Id = 1, Usuario = "Pepito" };
			mockContrasenaService.Setup(s => s.Check(contrasena, usuario.Contrasena)).Returns(true);
			mockUnitOfWork.Setup(s => s.SeguridadRepository.ValidarUsuario(usuario)).ReturnsAsync(seguridad);
			var result = await service.ValidarUsuario(usuario);
			Assert.AreEqual(usuario.Usuario, result.Usuario);
			this.mockRepository.VerifyAll();
		}

		/// <summary>
		/// Defines the test method ValidarUsuario_No_Exitoso.
		/// </summary>
		/// <returns>Task.</returns>
		[Test]
		[Author("Alberto Palencia")]
		public async Task ValidarUsuario_No_Exitoso()
		{
			var service = this.CreateService();
			const string contrasena = "10000.feUzERp1/cWLzjxJD6dl+g==.XSCcROLL98o00jrC7xWbariI4lz1V1plbUECiBdT3Cw=";
			var usuario = new SeguridadDto { Usuario = "Pepito1", Contrasena = "Master12481*" };
			var seguridad = new SeguridadMicroServicio { Contrasena = contrasena, Id = 1, Usuario = "Pepito" };
			mockContrasenaService.Setup(s => s.Check(contrasena, usuario.Contrasena)).Returns(false);
			mockUnitOfWork.Setup(s => s.SeguridadRepository.ValidarUsuario(usuario)).ReturnsAsync(seguridad);
			var result = await service.ValidarUsuario(usuario);
			Assert.AreEqual(null, result);
			this.mockRepository.VerifyAll();
		}
	}
}