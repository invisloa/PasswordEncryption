using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordEncryption
{
	internal class PasswordManager
	{
		public static byte[] GenerateSalt(int size)
		{
			var rng = new RNGCryptoServiceProvider();
			var salt = new byte[size];
			rng.GetBytes(salt);
			return salt;
		}
		public static byte[] HashPasswordWithSalt(byte[] password, byte[] salt)
		{
			using (var sha256 = SHA256.Create())
			{
				byte[] combined = password.Concat(salt).ToArray();
				return sha256.ComputeHash(combined);
			}
		}
		public static byte[] HashPasswordWithSalt(string password, byte[] salt)
		{
			return HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt);
		}
		public static bool VerifyPassword(byte[] password, byte[] salt, byte[] hash)
		{
			return HashPasswordWithSalt(password, salt).SequenceEqual(hash);
		}
	}
}
