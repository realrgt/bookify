using Bookify.Application.Abstractions.Authentication;
using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using Dapper;

namespace Bookify.Application.Users.GetLoggedInUser;

internal sealed class GetLoggedInUserQueryHandler
    : IQueryHandler<GetLoggedInUserQuery, UserResponse>
{
    private readonly ISqlConnectionFactory _connectionFactory;
    private readonly IUserContext _userContext;

    public GetLoggedInUserQueryHandler(ISqlConnectionFactory connectionFactory, IUserContext userContext)
    {
        _connectionFactory = connectionFactory;
        _userContext = userContext;
    }

    public async Task<Result<UserResponse>> Handle(
        GetLoggedInUserQuery request,
        CancellationToken cancellationToken)
    {
        using var connection = _connectionFactory.CreateConnection();

        const string sql = """
            SELECT
                id AS Id,
                first_name AS FirstName,
                last_name AS LastName,
                email AS Email
            FROM
                users
            WHERE
                identity_id = @IdentityId
        """;

        var user = await connection.QuerySingleAsync<UserResponse>(
            sql,
            new
            {
                _userContext.IdentityId
            });

        return user!;
    }
}
