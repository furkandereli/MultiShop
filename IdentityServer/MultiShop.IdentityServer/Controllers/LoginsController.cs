﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;

namespace MultiShop.IdentityServer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> _signInManager;

		public LoginsController(SignInManager<ApplicationUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpPost]
		public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
			if (result.Succeeded)
				return Ok("Giriş başarılı !");
			else
				return Ok("Kullanıcı Adı ya da şifre hatalı !");
		}
	}
}
