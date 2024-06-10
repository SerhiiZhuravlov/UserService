using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Application.Validators;
using FluentValidation;
using Microsoft.Extensions.Logging;
using UserService.Application.Interfaces.Database;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly UserValidator _userValidator;

        public UserService
            (
             ILogger<UserService> logger,
             IUserRepository userRepository,
            UserValidator userValidator)
        {
            _logger = logger;
            _userRepository = userRepository;
            _userValidator = userValidator;

        }

        public async Task<User> GetUserAsync(int id)
        {
            var result = await _userRepository
                .FindByCondition(user => user.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return result!;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _userValidator.ValidateAndThrowAsync(user);
            await _userRepository.CreateAsync(user);
            return user;
        }
    }
}
