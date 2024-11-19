using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Drawing.Printing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace PROJEKT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            user.Register();
            if (user.IsRegistered == true)
            {
                user.Print();
            }
            else {
                Console.WriteLine("Could not register user, try again");
            }
        }
        class User
        {
            public bool IsRegistered=false;
            private string Email;
            private string Password;
            protected byte[] PasswordHash;
            public bool HasSpecialChars(string yourString)
            {
                return yourString.Any(ch => !char.IsLetterOrDigit(ch));
            }
            public bool HasUpperCase(string yourString) {
                return yourString.Any(ch=> char.IsUpper(ch));
            }
            public bool HasNumber(string yourString)
            {
                return yourString.Any(ch=>char.IsNumber(ch));
            }
            public bool IsEmailCorrect(string email)
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                if (match.Success) {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void Print()
            {
                Console.WriteLine($" Email:{this.Email}\n Password:{this.Password}\n Hash:{Convert.ToBase64String(this.PasswordHash)}");
            }
            public void Register()
            {
                string email = Console.ReadLine();
                string password = Console.ReadLine();
                string password2 = Console.ReadLine();
                if (email != null && password != null && password == password2 && IsEmailCorrect(email))
                {
                    if (password.Length > 7 && HasSpecialChars(password) && HasUpperCase(password))
                    {
                        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
                        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: password!,
                            salt: salt,
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 100000,
                            numBytesRequested: 256 / 8));
                        this.Email = email;
                        this.Password = hashed;
                        this.PasswordHash = salt;
                        this.IsRegistered = true;
                        Console.WriteLine("Zarejestrowano pomyślnie");
                    }
                    else
                    {
                        Console.WriteLine("Password must contain atleast 8 characters, 1 special character ,1 uppercase character and 1 number" ) ;
                    }
                }
                else
                {
                    Console.WriteLine("Niepoprawne dane");
                }
            }
        }
    }
}
