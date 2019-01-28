using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ControlWork
{
    class Program
    {

        static void Main(string[] args)
        {
            PasswordsContext context = new PasswordsContext();

            Logic logic = new Logic(context);
            Console.WriteLine("1.Registraion\n2.recovery");
            string a = Console.ReadLine();
            int b = int.Parse(a);

            switch (b)
            {
                case 1:
                    Console.WriteLine("Введите имя: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите логин: ");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль: ");
                    string password = Console.ReadLine();
                    Console.WriteLine("Введите номер телефона:");
                    string mobilephone = Console.ReadLine();
                    List<User> userList = context.Users.ToList();

                    const string accountId2 = "AC75494a200395e6db7d8dc76a8ad39822";
                    const string token2 = "c266720aff16179a2a2faeb59cf99696";
                    TwilioClient.Init(accountId2, token2);
                    Random random2 = new Random();
                    string code2 = Convert.ToString(random2.Next(123));
                    try
                    {
                        var mesage = MessageResource.Create(
                from: new Twilio.Types.PhoneNumber("+18508426542"),
                body: code2,
                to: new Twilio.Types.PhoneNumber(mobilephone));
                    }
                    catch (InvalidOperationException)
                    {
                        Console.WriteLine("Wrong telephone identity");
                    }
                    Console.WriteLine("Enter message adressed to you");
                    string verificationcode2 = Console.ReadLine();
                    if (verificationcode2 == code2)
                    {
                        var registration1 = new User
                        {
                            FullName = name,
                            Login = login,
                            Password = password,
                            MobilePhone = mobilephone

                        };

                        context.Users.Add(registration1);
                        context.SaveChanges();
                        Console.WriteLine("congratulations you are in!!!");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Somthing wrong ");
                    }







                    break;
                case 2:
                    List<User> userList2 = context.Users.ToList();

                    Console.WriteLine("Введите номер телефона:");
                    string mobilephone2 = Console.ReadLine();
                    for (int i = 0; i < userList2.Count; i++)
                    {
                        if (mobilephone2 == userList2[i].MobilePhone)
                        {
                            const string accountId = "AC75494a200395e6db7d8dc76a8ad39822";
                            const string token = "c266720aff16179a2a2faeb59cf99696";
                            TwilioClient.Init(accountId2, token2);
                            Random random = new Random();
                            string code = Convert.ToString(random.Next(123));
                            try
                            {
                                var mesage = MessageResource.Create(
                        from: new Twilio.Types.PhoneNumber("+18508426542"),
                        body: code,
                        to: new Twilio.Types.PhoneNumber(mobilephone2));
                            }
                            catch (InvalidOperationException)
                            {
                                Console.WriteLine("Wrong telephone identity");
                            }
                            Console.WriteLine("Enter message adressed to you");
                            string verificationcode = Console.ReadLine();
                            if (verificationcode == code)
                            {

                                var registration1 = new User
                                {

                                    MobilePhone = mobilephone2
                                };
                                context.Users.Add(registration1);
                                context.SaveChanges();
                                Console.WriteLine("congratulations you are in!!!");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Wrong");

                            }
                        }
                    }
                    break;

            }
        }




    }
}





//List<User> userList = context.Users.ToList();

//for (int i = 0; i < userList.Count; i++)
//{
//    if (userList[i].Password == password && userList[i].Login == login)
//    {
//    break;
//}
//else
//{
//    Console.WriteLine("Неправильные данные! Попробуйте позже!");
//    Console.ReadLine();
//    Environment.Exit(0);
//}