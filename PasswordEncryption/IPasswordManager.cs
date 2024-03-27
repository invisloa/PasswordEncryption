using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordEncryption
{
	public interface IPasswordManager
	{
		byte[] GenerateSalt(int size);
		byte[] HashPasswordWithSalt(byte[] password, byte[] salt);
		byte[] HashPasswordWithSalt(string password, byte[] salt);
		bool VerifyPassword(byte[] password, byte[] salt, byte[] hash);
	}
}