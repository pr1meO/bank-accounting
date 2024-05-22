using System.Text;

namespace BankAccouting.Generate
{
    public class Password
    {
        private const string charactersPassword = "123456789qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM!@$%^&*?:";

        public static string GeneratePassword(int length)
        {
            Random random = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(charactersPassword.Length);
                password.Append(charactersPassword[randomIndex]);
            }

            return password.ToString();
        }
    }
}
