using API.Models.User.Requests;
using API.Models.User.Responses;
using AutoMapper;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService,
            IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            _logger.LogInformation("Get user request. UserId: {UserId}", id);

            if (user == null)
                return NotFound();

            var respsonse = _mapper.Map<UserResponse>(user);
            return respsonse;
        }

        [HttpPost]
        public async Task<ActionResult<UserResponse>> PostUser(CreateUserRequest createUserRequest)
        {
            var user = _mapper.Map<User>(createUserRequest);
            var result = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(PostUser), result);
        }
    }
}
