using Backend.Models.Entities;
using Backend.Models.Requests;
using Backend.Models.Responses;
using Backend.Models.Responses.Auth;
using Dapper;
using Npgsql;
using System.Data;

namespace Backend.Db
{
    public class DbHelper : IDbHelper
    {
        private readonly string _connectionString;

        public DbHelper(string connectionString)
        {
            _connectionString = connectionString;
        }


        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@login", request.Login, DbType.String);
            dp.Add("@password", request.Password, DbType.String);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<LoginResponse>(Queries.LoginQuery, dp);
            }
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@login", request.Login, DbType.String);
            dp.Add("@password", request.Password, DbType.String);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var response = await connection.QuerySingleOrDefaultAsync<RegisterResponse>(Queries.RegisterQuery, dp);
                return await connection.QuerySingleOrDefaultAsync<RegisterResponse>(Queries.LoginQuery, dp);
            }
        }

        //public async Task<UploadAvatarResponse> UploadAvatar(UploadAvatarRequest request)
        //{
        //    var dp = new DynamicParameters();
        //    dp.Add("@login", request.Avatar, DbType.String);

        //    using (var connection = new NpgsqlConnection(_connectionString))
        //    {
        //        var response = await connection.QuerySingleOrDefaultAsync<RegisterResponse>(Queries.RegisterQuery, dp);
        //        return await connection.QuerySingleOrDefaultAsync<RegisterResponse>(Queries.LoginQuery, dp);
        //    }
        //}



        public async Task<AddCommentResponse> AddComment(AddCommentRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@text", request.Text, DbType.String);
            dp.Add("@scoreId", request.ScoreId, DbType.Int32);
            dp.Add("@userId", request.UserId, DbType.Int32);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<AddCommentResponse>(Queries.AddCommentQuery, dp);
            }
        }

        public async Task<EditCommentResponse> EditComment(EditCommentRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@text", request.Text, DbType.String);
            dp.Add("@scoreId", request.ScoreId, DbType.Int32);
            dp.Add("@id", request.Id, DbType.Int32);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<EditCommentResponse>(Queries.EditCommentQuery, dp);
            }
        }

        public async Task<RemoveCommentResponse> RemoveComment(RemoveCommentRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@id", request.Id, DbType.Int32);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<RemoveCommentResponse>(Queries.RemoveCommentQuery, dp);
            }
        }



        public async Task<GetCommentsAllResponse> GetCommentsAll(GetCommentsAllRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@id", request.WorkId, DbType.Int32);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var response = await connection.QueryAsync<Comment>(Queries.GetCommentsAllQuery, dp);
                return new GetCommentsAllResponse
                {
                    Comments = response.ToArray()
                };
            }
        }

        public async Task<AddWorkResponse> AddWork(AddWorkRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@name", request.Tag, DbType.String);
            dp.Add("@description", request.Description, DbType.String);
            dp.Add("@data", request.Picture, DbType.Byte);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<AddWorkResponse>(Queries.AddWorkQuery, dp);
            }
        }

        public async Task<EditWorkResponse> EditWork(EditWorkRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@id", request.Data, DbType.Int32);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<EditWorkResponse>(Queries.EditWorkQuery, dp);
            }
        }

        public async Task<GetWorkDetailsResponse> GetWorkDetails(GetWorkDetailsRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@id", request.Data, DbType.Int32);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<GetWorkDetailsResponse>(Queries.GetWorkDetailsQuery, dp);
            }
        }

        public async Task<GetWorksAllResponse> GetWorksAll(GetWorksAllRequest request)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var response = await connection.QueryAsync<Work>(Queries.GetWorksAllQuery);
                return new GetWorksAllResponse 
                { 
                    Works = response.ToArray() 
                };
            }
        }

        public async Task<GetWorksByFilterResponse> GetWorksByFilter(GetWorksByFilterRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@id", request.Name, DbType.Int32);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var response = await connection.QueryAsync<Work>(Queries.GetWorksByFilterQuery, dp);
                return new GetWorksByFilterResponse
                {
                    Works = response.ToArray()
                };
            }
        }

        public async Task<RemoveWorkResponse> RemoveWork(RemoveWorkRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@id", request.Id, DbType.Int32);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync<RemoveWorkResponse>(Queries.RemoveWorkQuery, dp);
            }
        }


        public CheckLoginResponse CheckLogin(string login)
        {
            var dp = new DynamicParameters();
            dp.Add("@login", login, DbType.String);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                return connection.QuerySingleOrDefault<CheckLoginResponse>(Queries.CheckLoginQuery, dp);
            }
        }
    }
}
