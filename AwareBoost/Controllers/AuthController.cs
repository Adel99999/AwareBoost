using AwareBoost.Dtos;
using AwareBoost.Helpers;
using AwareBoost.Models;
using AwareBoost.Repository;
using AwareBoost.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AwareBoost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUsers> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public AuthController(UserManager<AppUsers> userManager, IUnitOfWork tokenRepository)
        {
            _userManager = userManager;
            _unitOfWork = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto obj)
        {
            var identityUser = new AppUsers
            {
                UserName = obj.UserName,
                Email = obj.Email
            };

            // Create the user
            var identityResult = await _userManager.CreateAsync(identityUser, obj.Password);
            if (identityResult.Succeeded)
            {
                // Assign default role
                var roleResult = await _userManager.AddToRoleAsync(identityUser, RoleType.User.ToString());
                if (roleResult.Succeeded)
                {
                    return Ok("User registered successfully. Please log in.");
                }
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto obj)
        {
            // Find the user by email
            var user = await _userManager.FindByEmailAsync(obj.Email);
            if (user != null)
            {
                // Check if the password is correct
                var checkPassResult = await _userManager.CheckPasswordAsync(user, obj.Password);
                if (checkPassResult)
                {
                    // Get roles for the user
                    var roles = await _userManager.GetRolesAsync(user);

                    // Create JWT token
                    var jwtToken = _unitOfWork.TokenRepository.CreateJwtToken(user, roles.ToList());

                    // Generate a refresh token
                    var refreshToken = _unitOfWork.TokenRepository.GenerateRefreshToken();

                    // Set the refresh token in the response cookies (secure cookie)
                    _unitOfWork.TokenRepository.SetRefreshToken(refreshToken);


                    // Update user with the new refresh token details
                    user.RefreshToken = refreshToken.Token;
                    user.TokenCreated = refreshToken.Created;
                    user.TokenExpires = refreshToken.Expires;

                    await _userManager.UpdateAsync(user);

                    // Return JWT and refresh token to the client
                    return Ok(new { Token = jwtToken, RefreshToken = refreshToken.Token });
                }
            }

            // If the user is not found or the password is incorrect
            return BadRequest("Invalid login attempt.");
        }

        [HttpPost]
        [Route("Logout")]
        public IActionResult Logout()
        {
            // Remove refresh token from cookies
            if (Request.Cookies["refreshToken"] != null)
            {
                Response.Cookies.Delete("refreshToken");
            }

            return Ok("Logged out successfully.");
        }



    }
}
