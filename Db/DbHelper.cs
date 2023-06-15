using Backend.Models.Entities;
using Backend.Models.Requests;
using Backend.Models.Responses;
using Backend.Models.Responses.Auth;
using Dapper;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Data;
using System.Text;

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

        public async Task<LoginResponse> Register(RegisterRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@login", request.Login, DbType.String);
            dp.Add("@password", request.Password, DbType.String);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var response = connection.QuerySingleOrDefault<RegisterResponse>(Queries.RegisterQuery, dp);
                return connection.QuerySingleOrDefault<LoginResponse>(Queries.LoginQuery, dp);
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
            var saveDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "pictures");
            if (!Directory.Exists(saveDir))
            {
                Directory.CreateDirectory(saveDir);
            }

            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);

                var pictureBytes = ms.ToArray();
                string fileName = Path.GetFileName(request.Picture.FileName);
                string fileSavePath = Path.Combine(saveDir, fileName);
                File.WriteAllBytes(fileSavePath, pictureBytes);
            }
            var dp = new DynamicParameters();
            dp.Add("@name", request.Tag, DbType.String);
            dp.Add("@description", request.Description, DbType.String);

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

        public async Task<GetWorksAllResponse> GetWorksAll()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var works = await connection.QueryAsync<Work>(Queries.GetWorksAllQuery);
                var resp = new GetWorksAllResponse();
                resp.Works.AddRange(works);

                return resp;
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
