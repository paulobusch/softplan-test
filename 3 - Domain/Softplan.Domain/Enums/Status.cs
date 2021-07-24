﻿namespace Softplan.Domain.Enums
{
    public enum Status
    {
        Success = 200,
        Invalid = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFund = 404,
        NotAllowed = 405,
        Conflict = 409,
        Error = 500
    }
}
