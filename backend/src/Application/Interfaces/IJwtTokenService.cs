using backend.Domain.Entitles;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Application.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}
