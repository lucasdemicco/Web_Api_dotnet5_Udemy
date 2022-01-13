using WebApiRestUdemy.Data;
using WebApiRestUdemy.Data.VO;
using WebApiRestUdemy.Model;
using System.Security.Cryptography;
using System.Text;
using System;
using System.Linq;

namespace WebApiRestUdemy.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        //Validação das credenciais do usuário
        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => ( u.UserName == user.UserName) && (u.Password == pass));
        }

        //Método para encriptar a senha
        private object ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
