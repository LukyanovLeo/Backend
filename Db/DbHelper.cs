using Backend.Models.Requests.Auth;
using Backend.Models.Requests.Comment;
using Dapper;
using Npgsql;
using System.Data;

namespace Backend.Db
{
    public class DbHelper
    {
        private readonly string _connectionString;

        public DbHelper(string connectionString)
        {
            _connectionString = connectionString;
        }


        public LoginResponse Login(LoginRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@login", request.Login, DbType.String);
            dp.Add("@password", request.Password, DbType.String);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var response = Convert.ToBoolean(connection.Query<int>(Queries.LoginQuery, dp).First());
                return new LoginResponse(response);
            }
        }

        public RegisterResponse Register(RegisterRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@login", request.Login, DbType.String);
            dp.Add("@name", request.Name, DbType.String);
            dp.Add("@email", request.Email, DbType.String);
            dp.Add("@password", request.Password, DbType.String);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Query(Queries.RegisterQuery, dp);
                return new RegisterResponse(true);
            }
        }

        public AddCommentResponse AddComment(AddCommentRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@text", request.Text, DbType.String);
            dp.Add("@scoreId", request.ScoreId, DbType.Int32);
            dp.Add("@userId", request.UserId, DbType.Int32);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Query<int>(Queries.AddCommentQuery, dp);
                return new AddCommentResponse(true);
            }
        }

        public EditCommentResponse EditComment(EditCommentRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@text", request.Text, DbType.String);
            dp.Add("@scoreId", request.ScoreId, DbType.Int32);
            dp.Add("@id", request.Id, DbType.Int32);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Query<int>(Queries.EditCommentQuery, dp);
                return new EditCommentResponse(true);
            }
        }

        public EditCommentResponse EditComment(EditCommentRequest request)
        {
            var dp = new DynamicParameters();
            dp.Add("@text", request.Text, DbType.String);
            dp.Add("@scoreId", request.ScoreId, DbType.Int32);
            dp.Add("@id", request.Id, DbType.Int32);

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Query<int>(Queries.EditCommentQuery, dp);
                return new EditCommentResponse(true);
            }
        }
    }
}
