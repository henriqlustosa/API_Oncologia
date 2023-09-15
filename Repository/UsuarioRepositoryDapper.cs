using Dapper;
using BackendOncologia.Entities;
using BackendOncologia.Interfaces;
using System.Data.SqlClient;
using static Dapper.SqlMapper;
namespace BackendOncologia.Repository
{
    public class UsuarioRepositoryDapper : DapperRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepositoryDapper(IConfiguration configuration) : base(configuration)
        {
        }

        public override void Update(Usuario usuario)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "UPDATE [Usuario] SET [Nome] = @Nome WHERE Id = @Id";
            dbconnection.Query(query, usuario);
        }

        public override void Add(Usuario usuario)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "INSERT INTO [Usuario]([Nome]) VALUES(@Nome)";
            dbconnection.Execute(query, usuario);
        }
       public override void Delete(int id)
        {
                using var dbconnection = new SqlConnection(ConnectionString);
                var query = "DELETE FROM [Usuario] WHERE Id = @Id";
                dbconnection.Execute(query, new { Id = id });
        }

        public override IList<Usuario> GetAll()
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM [Usuario]";
            return dbconnection.Query<Usuario>(query).ToList();
        }

        public override Usuario GetById(int id)
        {
            using var dbconnection = new SqlConnection(ConnectionString);
            var query = "SELECT * FROM [Usuario] Where Id = @Id";
            return dbconnection.Query<Usuario>(query, new { Id = id }).FirstOrDefault();
        }
        public Usuario ObterPedidosPorUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario ObterUsuarioPorNomeDoUsuarioSenha(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
