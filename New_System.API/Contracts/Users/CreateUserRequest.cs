﻿namespace New_System.API.Contracts.Users;

public sealed record CreateUserRequest(string FirstName, string LastName, string Email, string Password);
