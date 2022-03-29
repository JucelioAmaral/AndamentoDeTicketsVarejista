using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteHavan.Domain.ModelLogin;

namespace TesteHavan.Infrastructure.RepoLogin
{
    public static class UsarioLoginRepositpory
    {
        public static UsuarioLogin Get(string username, string password)
        {
            var users = new List<UsuarioLogin>();
            users.Add(new UsuarioLogin { Id = 1, Username = "Ana", Password = "Ana1", Role = "gerente" });
            users.Add(new UsuarioLogin { Id = 2, Username = "Maria", Password = "Maria1", Role = "funcionaria" });
            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
