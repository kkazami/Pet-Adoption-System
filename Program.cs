using System;
using System.Net;
using System.Net.Mail;

namespace meyn;

public class process
{
    public static void choice1()
    {
        int choice = 0;

        while (choice != 3)
        {
            loginreg.showMenu();

            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {

                case 1:
                    loginreg.register();
                    break;
                case 2:
                    loginreg.login();
                    if (loginreg.isLoggedIn)
                    {
                        choice2();
                    }
                    break;
                case 3:
                    Console.WriteLine(@"



                                         _____  _                    _                                   ___                                                 _    _                ___          _       _____      _                _                        ___                 _                        
                                        (_   _)( )                  ( )                                /'___)                            _                  ( )_ ( )              (  _`\       ( )_    (  _  )    ( )              ( )_  _                  (  _`\              ( )_                      
                                          | |  | |__     _ _   ___  | |/')     _   _    _    _   _    | (__   _    _ __     _   _   ___ (_)  ___     __     | ,_)| |__     __     | |_) )  __  | ,_)   | (_) |   _| |   _    _ _   | ,_)(_)   _     ___     | (_(_) _   _   ___ | ,_)   __    ___ ___     
                                          | |  |  _ `\ /'_` )/' _ `\| , <     ( ) ( ) /'_`\ ( ) ( )   | ,__)/'_`\ ( '__)   ( ) ( )/',__)| |/' _ `\ /'_ `\   | |  |  _ `\ /'__`\   | ,__/'/'__`\| |     |  _  | /'_` | /'_`\ ( '_`\ | |  | | /'_`\ /' _ `\   `\__ \ ( ) ( )/',__)| |   /'__`\/' _ ` _ `\   
                                          | |  | | | |( (_| || ( ) || |\`\    | (_) |( (_) )| (_) |   | |  ( (_) )| |      | (_) |\__, \| || ( ) |( (_) |   | |_ | | | |(  ___/   | |   (  ___/| |_    | | | |( (_| |( (_) )| (_) )| |_ | |( (_) )| ( ) |   ( )_) || (_) |\__, \| |_ (  ___/| ( ) ( ) | _ 
                                          (_)  (_) (_)`\__,_)(_) (_)(_) (_)   `\__, |`\___/'`\___/'   (_)  `\___/'(_)      `\___/'(____/(_)(_) (_)`\__  |   `\__)(_) (_)`\____)   (_)   `\____)`\__)   (_) (_)`\__,_)`\___/'| ,__/'`\__)(_)`\___/'(_) (_)   `\____)`\__, |(____/`\__)`\____)(_) (_) (_)(_)
                                                                              ( )_| |                                                             ( )_) |                                                                   | |                                    ( )_| |                                
                                                                              `\___/'                                                              \___/'                                                                   (_)                                    `\___/'                                



");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice! Please try again..");
                    break;
            }
        }
    }

    public static void choice2()
    {
        int choice = 0;
        ManageAnimal manageAnimal = new ManageAnimal();

        while (choice != 9)
        {
            inside.showInside();

            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Clear();
                HandleError("Invalid input. Please enter a number.");
                continue;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        inside.viewAccount();
                        break;
                    case 2:
                        inside.updateAccount();
                        break;
                    case 3:
                        inside.animalRegister();
                        break;
                    case 4:
                        inside.adoptionRequest();
                        break;
                    case 5:
                        inside.TadoptionRequest();
                        break;
                    case 6:
                        inside.registerVolunteer();
                        break;
                    case 7:
                        inside.registerDonor();
                        break;
                    case 8:
                        inside.updateMedicalHistory();
                        break;
                    case 9:
                        Console.WriteLine(@"


                                         _____  _                    _                                   ___                                                 _    _                ___          _       _____      _                _                        ___                 _                        
                                        (_   _)( )                  ( )                                /'___)                            _                  ( )_ ( )              (  _`\       ( )_    (  _  )    ( )              ( )_  _                  (  _`\              ( )_                      
                                          | |  | |__     _ _   ___  | |/')     _   _    _    _   _    | (__   _    _ __     _   _   ___ (_)  ___     __     | ,_)| |__     __     | |_) )  __  | ,_)   | (_) |   _| |   _    _ _   | ,_)(_)   _     ___     | (_(_) _   _   ___ | ,_)   __    ___ ___     
                                          | |  |  _ `\ /'_` )/' _ `\| , <     ( ) ( ) /'_`\ ( ) ( )   | ,__)/'_`\ ( '__)   ( ) ( )/',__)| |/' _ `\ /'_ `\   | |  |  _ `\ /'__`\   | ,__/'/'__`\| |     |  _  | /'_` | /'_`\ ( '_`\ | |  | | /'_`\ /' _ `\   `\__ \ ( ) ( )/',__)| |   /'__`\/' _ ` _ `\   
                                          | |  | | | |( (_| || ( ) || |\`\    | (_) |( (_) )| (_) |   | |  ( (_) )| |      | (_) |\__, \| || ( ) |( (_) |   | |_ | | | |(  ___/   | |   (  ___/| |_    | | | |( (_| |( (_) )| (_) )| |_ | |( (_) )| ( ) |   ( )_) || (_) |\__, \| |_ (  ___/| ( ) ( ) | _ 
                                          (_)  (_) (_)`\__,_)(_) (_)(_) (_)   `\__, |`\___/'`\___/'   (_)  `\___/'(_)      `\___/'(____/(_)(_) (_)`\__  |   `\__)(_) (_)`\____)   (_)   `\____)`\__)   (_) (_)`\__,_)`\___/'| ,__/'`\__)(_)`\___/'(_) (_)   `\____)`\__, |(____/`\__)`\____)(_) (_) (_)(_)
                                                                              ( )_| |                                                             ( )_) |                                                                   | |                                    ( )_| |                                
                                                                              `\___/'                                                              \___/'                                                                   (_)                                    `\___/'                                




");
                        break;
                    default:
                        HandleError("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                HandleError(ex.Message);
            }
        }
    }

    public static void HandleError(string errorMessage)
    {
        Console.Clear();
        Console.WriteLine("Error: " + errorMessage);
        Console.WriteLine("Please try again.");
    }


}

public class loginreg
{
    public static string name;
    public static string email;
    public static string password;
    public static bool isRegistered = false;
    public static bool isLoggedIn = false;

    public static void showMenu()
    {
        Console.WriteLine(@"             


                                            ██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗    ████████╗ ██████╗     ████████╗██╗  ██╗███████╗
                                            ██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝    ╚══██╔══╝██╔═══██╗    ╚══██╔══╝██║  ██║██╔════╝
                                            ██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗         ██║   ██║   ██║       ██║   ███████║█████╗  
                                            ██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝         ██║   ██║   ██║       ██║   ██╔══██║██╔══╝  
                                            ╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗       ██║   ╚██████╔╝       ██║   ██║  ██║███████╗
                                             ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝       ╚═╝    ╚═════╝        ╚═╝   ╚═╝  ╚═╝╚══════╝
                                             ___          _       _____      _                _                        ___                 _                     
                                            (  _`\       ( )_    (  _  )    ( )              ( )_  _                  (  _`\              ( )_                   
                                            | |_) )  __  | ,_)   | (_) |   _| |   _    _ _   | ,_)(_)   _     ___     | (_(_) _   _   ___ | ,_)   __    ___ ___  
                                            | ,__/'/'__`\| |     |  _  | /'_` | /'_`\ ( '_`\ | |  | | /'_`\ /' _ `\   `\__ \ ( ) ( )/',__)| |   /'__`\/' _ ` _ `\
                                            | |   (  ___/| |_    | | | |( (_| |( (_) )| (_) )| |_ | |( (_) )| ( ) |   ( )_) || (_) |\__, \| |_ (  ___/| ( ) ( ) |
                                            (_)   `\____)`\__)   (_) (_)`\__,_)`\___/'| ,__/'`\__)(_)`\___/'(_) (_)   `\____)`\__, |(____/`\__)`\____)(_) (_) (_)
                                                                                      | |                                    ( )_| |                             
                                                                                      (_)                                    `\___/'                             





                    Press [1] to Register
                    Press [2] to Login
                    Press [3] to Exit

");
        Console.Write("Enter your choice: ");
    }

    public static void register()
    {
        Console.Clear();
        Console.WriteLine(@"


                                                    ██████╗ ███████╗ ██████╗ ██╗███████╗████████╗██████╗  █████╗ ████████╗██╗ ██████╗ ███╗   ██╗
                                                    ██╔══██╗██╔════╝██╔════╝ ██║██╔════╝╚══██╔══╝██╔══██╗██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║
                                                    ██████╔╝█████╗  ██║  ███╗██║███████╗   ██║   ██████╔╝███████║   ██║   ██║██║   ██║██╔██╗ ██║
                                                    ██╔══██╗██╔══╝  ██║   ██║██║╚════██║   ██║   ██╔══██╗██╔══██║   ██║   ██║██║   ██║██║╚██╗██║
                                                    ██║  ██║███████╗╚██████╔╝██║███████║   ██║   ██║  ██║██║  ██║   ██║   ██║╚██████╔╝██║ ╚████║
                                                    ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝
                                                                                            

");

        Console.Write("Enter your Full Name: ");
        string fullName = Console.ReadLine();

        string email;
        while (true)
        {
            Console.Write("Enter your Email Address: ");
            email = Console.ReadLine();
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                if (addr.Address == email) break;
            }
            catch
            {
                Console.WriteLine("\nInvalid email format. Please try again.");
            }

        }

        Console.Write("Enter your Password: ");
        string password = Console.ReadLine();

        if (ManageAnimal.CheckUserExists(email))
        {
            Console.Clear();
            Console.WriteLine("Email already registered! Try logging in.");
            return;
        }

        string verificationCode = GenerateVerificationCode();
        bool emailSent = emailSetup.SendEmail(email, verificationCode);

        if (emailSent)
        {
            Console.Write("Enter the Verification Code sent to your email: ");
            string userCode = Console.ReadLine();

            if (userCode == verificationCode)
            {
                if (ManageAnimal.RegisterUser(fullName, email, password))
                {
                    Show3DLoadingAnimation();
                    Console.Clear();
                    Console.WriteLine("\nAccount Registered and Verified Successfully!\n");
                }
            }
            else
            {
                Show3DLoadingAnimation();
                Console.WriteLine("Invalid Verification Code. Registration failed.");
            }
        }
        else
        {
            Console.WriteLine("Failed to send verification email. Please try again later.");
        }
    }

    public static void login()
    {
        Console.Clear();
        Console.WriteLine(@"

                                                                        ██╗      ██████╗  ██████╗ ██╗███╗   ██╗
                                                                        ██║     ██╔═══██╗██╔════╝ ██║████╗  ██║
                                                                        ██║     ██║   ██║██║  ███╗██║██╔██╗ ██║
                                                                        ██║     ██║   ██║██║   ██║██║██║╚██╗██║
                                                                        ███████╗╚██████╔╝╚██████╔╝██║██║ ╚████║
                                                                        ╚══════╝ ╚═════╝  ╚═════╝ ╚═╝╚═╝  ╚═══╝
                                       

");

        Console.Write("Enter your Email Address: ");
        string email = Console.ReadLine();

        Console.Write("Enter your Password: ");
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
            else if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();

        if (ManageAnimal.ValidateLogin(email, password))
        {

            Show3DLoadingAnimation();
            Console.Clear();
            Console.WriteLine("Login Successful!\n");
            isLoggedIn = true;
        }
        else
        {
            Show3DLoadingAnimation();
            Console.Clear();
            Console.WriteLine("Invalid Email Address or Password!\n");
        }
    }

    private static string GenerateVerificationCode()
    {
        Random random = new Random();
        return random.Next(100000, 999999).ToString();
    }

    public static void Show3DLoadingAnimation()
        {
            Console.CursorVisible = false;
            int barWidth = 120; 
            int duration = 100; 
            char block = '█';
            char empty = ' ';

            Console.Clear();
            Console.WriteLine(@"
                                                                                                                                    
                                                                                                                                    
                                        █████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗█████╗
                                        ╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝╚════╝
                                                                                                                                    
                                                                                                                                    
                                                                                                                                    
                                                                                                                
                                                                                ██╗      ██████╗  █████╗ ██████╗ ██╗███╗   ██╗ ██████╗          
                                                                                ██║     ██╔═══██╗██╔══██╗██╔══██╗██║████╗  ██║██╔════╝          
                                                                                ██║     ██║   ██║███████║██║  ██║██║██╔██╗ ██║██║  ███╗         
                                                                                ██║     ██║   ██║██╔══██║██║  ██║██║██║╚██╗██║██║   ██║         
                                                                                ███████╗╚██████╔╝██║  ██║██████╔╝██║██║ ╚████║╚██████╔╝██╗██╗██╗
                                                                                ╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═════╝ ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝╚═╝╚═╝
                 





");

            for (int i = 0; i <= duration; i++)
            {
                double percent = (double)i / duration;
                int filled = (int)(barWidth * percent);

                string line1 = "[" + new string(block, filled) + new string(empty, barWidth - filled) + "]";
                string line2 = "[" + new string(block, (int)(filled * 0.9)) + new string(empty, barWidth - (int)(filled * 0.9)) + "]";
                string line3 = "[" + new string(block, (int)(filled * 0.8)) + new string(empty, barWidth - (int)(filled * 0.8)) + "]";

                Console.SetCursorPosition(0, Console.CursorTop - 3);
                Console.WriteLine("\t\t\t\t\t\t" + line1);
                Console.WriteLine("\t\t\t\t\t\t" + line2);
                Console.WriteLine("\t\t\t\t\t\t" + line3);
                Console.Write("\t\t\t\t\t\t\t\t\t\t\t\tLoading: " + i + "%");
                Thread.Sleep(50);
            }

            Console.WriteLine("\n\n\t\t✅ Loading Complete!\n");
        }
}

public class emailSetup
{


    public static bool SendEmail(string recipientEmail, string verificationCode)
    {
        try
        {
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("tamuni.vents@gmail.com", "Pet Adoption System"),
                Subject = "Your Verification Code",
                IsBodyHtml = true
            };
            mail.To.Add(recipientEmail);

            // Plain text email with the verification code
            string htmlBody = $@"
                <html>
                    <body>
                        <h2>Welcome to Pet Adoption System</h2>
                        <p>Your verification code is:</p>
                        <h1 style='color: black;'>{verificationCode}</h1>
                        <p>Please use this code to verify your account.</p>
                        <hr>
                        <p>If you did not request this, please ignore this email.</p>
                    </body>
                </html>";

            mail.Body = htmlBody;

            // SMTP settings
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("mypetadoptionsystem@gmail.com", "odcl otjm kwcu euog"),
                EnableSsl = true
            };

            smtpServer.Send(mail);
            Console.WriteLine("Email sent successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error sending email: " + ex.Message);
            return false;
        }
    }


}



public class inside
{
    public static void showInside()
    {
        Console.WriteLine(@" 

                                                                        ███╗   ███╗ █████╗ ██╗███╗   ██╗    ███╗   ███╗███████╗███╗   ██╗██╗   ██╗
                                                                        ████╗ ████║██╔══██╗██║████╗  ██║    ████╗ ████║██╔════╝████╗  ██║██║   ██║
                                                                        ██╔████╔██║███████║██║██╔██╗ ██║    ██╔████╔██║█████╗  ██╔██╗ ██║██║   ██║
                                                                        ██║╚██╔╝██║██╔══██║██║██║╚██╗██║    ██║╚██╔╝██║██╔══╝  ██║╚██╗██║██║   ██║
                                                                        ██║ ╚═╝ ██║██║  ██║██║██║ ╚████║    ██║ ╚═╝ ██║███████╗██║ ╚████║╚██████╔╝
                                                                        ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝    ╚═╝     ╚═╝╚══════╝╚═╝  ╚═══╝ ╚═════╝ 
                                                                          
 

                                                        Press [1] to View Account                                                  Press [5] to Track Adoption Request
                                                        Press [2] to Update Account                                                Press [6] to Register a Volunteer
                                                        Press [3] to Register a New Animal                                         Press [7] to Register a Donor
                                                        Press [4] to Create an Adoption Request                                    Press [8] to Update Medical History

                                                                                                       Press [9] to Logout
                             
                           
                              
                               

");

        Console.Write("Enter your choice: ");
    }

    public static void viewAccount()
    {
        Console.Clear();
        Console.WriteLine("\n======= View Account Information =======");
        Console.WriteLine($"Full Name: {loginreg.name}");
        Console.WriteLine($"Email Address: {loginreg.email}\n");
    }

    public static void updateAccount()
    {
        Console.Clear();
        Console.WriteLine(@"\n 

                    ██╗   ██╗██████╗ ██████╗  █████╗ ████████╗███████╗     █████╗  ██████╗ ██████╗ ██████╗ ██╗   ██╗███╗   ██╗████████╗    ██╗███╗   ██╗███████╗ ██████╗ ██████╗ ███╗   ███╗ █████╗ ████████╗██╗ ██████╗ ███╗   ██╗    
                    ██║   ██║██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔════╝    ██╔══██╗██╔════╝██╔════╝██╔═══██╗██║   ██║████╗  ██║╚══██╔══╝    ██║████╗  ██║██╔════╝██╔═══██╗██╔══██╗████╗ ████║██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║    
                    ██║   ██║██████╔╝██║  ██║███████║   ██║   █████╗      ███████║██║     ██║     ██║   ██║██║   ██║██╔██╗ ██║   ██║       ██║██╔██╗ ██║█████╗  ██║   ██║██████╔╝██╔████╔██║███████║   ██║   ██║██║   ██║██╔██╗ ██║    
                    ██║   ██║██╔═══╝ ██║  ██║██╔══██║   ██║   ██╔══╝      ██╔══██║██║     ██║     ██║   ██║██║   ██║██║╚██╗██║   ██║       ██║██║╚██╗██║██╔══╝  ██║   ██║██╔══██╗██║╚██╔╝██║██╔══██║   ██║   ██║██║   ██║██║╚██╗██║    
                    ╚██████╔╝██║     ██████╔╝██║  ██║   ██║   ███████╗    ██║  ██║╚██████╗╚██████╗╚██████╔╝╚██████╔╝██║ ╚████║   ██║       ██║██║ ╚████║██║     ╚██████╔╝██║  ██║██║ ╚═╝ ██║██║  ██║   ██║   ██║╚██████╔╝██║ ╚████║    
                     ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚══════╝    ╚═╝  ╚═╝ ╚═════╝ ╚═════╝ ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝   ╚═╝       ╚═╝╚═╝  ╚═══╝╚═╝      ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚═╝  ╚═╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝    
                                                                                                                                                                                                                   

                    Press [1] to Update Full Name
                    Press [2] to Update Email Address
                    Press [3] to Update Account Password
                    Press [4] to Cancel

");


        try
        {
            int updateAcc = int.Parse(Console.ReadLine());
            switch (updateAcc)
            {
                case 1:
                    Console.Write("Enter your Full Name: ");
                    loginreg.name = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Account Name Updated Successfully!\n");
                    break;

                case 2:
                    Console.Write("Enter your Email Address: ");
                    loginreg.email = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Account Email Updated Successfully!\n");
                    break;

                case 3:
                    Console.Write("Enter your current Password: ");
                    string currentPassword = Console.ReadLine();
                    if (currentPassword == loginreg.password)
                    {
                        Console.Write("Enter your new Account Password: ");
                        loginreg.password = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Account Password Updated Successfully!\n");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Account Password!\n");
                    }
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Update Cancelled!\n");
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("Invalid choice! Please try again..\n");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public static void animalRegister()
    {
        Console.Clear();
        Console.WriteLine(@"

                                                 ___                           _                              _   _                       _____                              _   
                                                |  _`\                _       ( )_                           ( ) ( )                     (  _  )        _                   (_ ) 
                                                | (_) )   __     __  (_)  ___ | ,_)   __   _ __       _ _    | `\| |   __   _   _   _    | (_) |  ___  (_)  ___ ___     _ _  | | 
                                                | ,  /  /'__`\ /'_ `\| |/',__)| |   /'__`\( '__)    /'_` )   | , ` | /'__`\( ) ( ) ( )   |  _  |/' _ `\| |/' _ ` _ `\ /'_` ) | | 
                                                | |\ \ (  ___/( (_) || |\__, \| |_ (  ___/| |      ( (_| |   | |`\ |(  ___/| \_/ \_/ |   | | | || ( ) || || ( ) ( ) |( (_| | | | 
                                                (_) (_)`\____)`\__  |(_)(____/`\__)`\____)(_)      `\__,_)   (_) (_)`\____)`\___x___/'   (_) (_)(_) (_)(_)(_) (_) (_)`\__,_)(___)
                                                              ( )_) |                                                                                                            
                                                               \___/'                                                                                                            

");
        Console.Write("Enter Species: ");
        string species = Console.ReadLine();
        Console.Write("Enter Breed: ");
        string breed = Console.ReadLine();
        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter Health Status: ");
        string healthStatus = Console.ReadLine();
        ManageAnimal manageAnimal = new ManageAnimal();
        manageAnimal.RegisterAnimal(species, breed, age, healthStatus);
        Console.Clear();
        Console.WriteLine("Animal Registered Successfully!\n");
    }

    public static void adoptionRequest()
    {
        Console.Clear();
        Console.WriteLine(@"
                                                 █████╗ ██████╗  ██████╗ ██████╗ ████████╗██╗ ██████╗ ███╗   ██╗    ██████╗ ███████╗ ██████╗ ██╗   ██╗███████╗███████╗████████╗
                                                ██╔══██╗██╔══██╗██╔═══██╗██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║    ██╔══██╗██╔════╝██╔═══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝
                                                ███████║██║  ██║██║   ██║██████╔╝   ██║   ██║██║   ██║██╔██╗ ██║    ██████╔╝█████╗  ██║   ██║██║   ██║█████╗  ███████╗   ██║   
                                                ██╔══██║██║  ██║██║   ██║██╔═══╝    ██║   ██║██║   ██║██║╚██╗██║    ██╔══██╗██╔══╝  ██║▄▄ ██║██║   ██║██╔══╝  ╚════██║   ██║   
                                                ██║  ██║██████╔╝╚██████╔╝██║        ██║   ██║╚██████╔╝██║ ╚████║    ██║  ██║███████╗╚██████╔╝╚██████╔╝███████╗███████║   ██║   
                                                ╚═╝  ╚═╝╚═════╝  ╚═════╝ ╚═╝        ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝    ╚═╝  ╚═╝╚══════╝ ╚══▀▀═╝  ╚═════╝ ╚══════╝╚══════╝   ╚═╝   
              ");

        try
        {
            Console.Write("Enter Adopter Name: ");
            string adopterName = Console.ReadLine();

            Console.Write("Enter Animal ID: ");
            if (int.TryParse(Console.ReadLine(), out int animalId))
            {
                ManageAnimal manageAnimal = new ManageAnimal();
                manageAnimal.CreateAdoptionRequest(adopterName, animalId);
            }
            else
            {
                Console.WriteLine("Invalid Animal ID. Please enter a valid number.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    public static void TadoptionRequest()
    {
        Console.Clear();
        Console.WriteLine(@"

                        ████████╗██████╗  █████╗  ██████╗██╗  ██╗     █████╗ ███╗   ██╗     █████╗ ██████╗  ██████╗ ██████╗ ████████╗██╗ ██████╗ ███╗   ██╗    ██████╗ ███████╗ ██████╗ ██╗   ██╗███████╗███████╗████████╗    
                        ╚══██╔══╝██╔══██╗██╔══██╗██╔════╝██║ ██╔╝    ██╔══██╗████╗  ██║    ██╔══██╗██╔══██╗██╔═══██╗██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║    ██╔══██╗██╔════╝██╔═══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝    
                           ██║   ██████╔╝███████║██║     █████╔╝     ███████║██╔██╗ ██║    ███████║██║  ██║██║   ██║██████╔╝   ██║   ██║██║   ██║██╔██╗ ██║    ██████╔╝█████╗  ██║   ██║██║   ██║█████╗  ███████╗   ██║       
                           ██║   ██╔══██╗██╔══██║██║     ██╔═██╗     ██╔══██║██║╚██╗██║    ██╔══██║██║  ██║██║   ██║██╔═══╝    ██║   ██║██║   ██║██║╚██╗██║    ██╔══██╗██╔══╝  ██║▄▄ ██║██║   ██║██╔══╝  ╚════██║   ██║       
                           ██║   ██║  ██║██║  ██║╚██████╗██║  ██╗    ██║  ██║██║ ╚████║    ██║  ██║██████╔╝╚██████╔╝██║        ██║   ██║╚██████╔╝██║ ╚████║    ██║  ██║███████╗╚██████╔╝╚██████╔╝███████╗███████║   ██║       
                           ╚═╝   ╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝    ╚═╝  ╚═╝╚═╝  ╚═══╝    ╚═╝  ╚═╝╚═════╝  ╚═════╝ ╚═╝        ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝    ╚═╝  ╚═╝╚══════╝ ╚══▀▀═╝  ╚═════╝ ╚══════╝╚══════╝   ╚═╝       
                                                                                                                                                                                                     

");
        try
        {
            Console.Write("Enter Adopter Name: ");
            string adopterName = Console.ReadLine();

            Console.Write("Enter Animal ID: ");
            if (int.TryParse(Console.ReadLine(), out int animalId))
            {
                ManageAnimal manageAnimal = new ManageAnimal();
                manageAnimal.TrackAdoptionRequest(adopterName, animalId);
            }
            else
            {
                Console.WriteLine("Invalid Animal ID. Please enter a valid number.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

    }

    public static void registerVolunteer()
    {
        Console.Clear();
        Console.WriteLine(@"

                        ██████╗ ███████╗ ██████╗ ██╗███████╗████████╗███████╗██████╗      █████╗     ██╗   ██╗ ██████╗ ██╗     ██╗   ██╗███╗   ██╗████████╗███████╗███████╗██████╗ 
                        ██╔══██╗██╔════╝██╔════╝ ██║██╔════╝╚══██╔══╝██╔════╝██╔══██╗    ██╔══██╗    ██║   ██║██╔═══██╗██║     ██║   ██║████╗  ██║╚══██╔══╝██╔════╝██╔════╝██╔══██╗
                        ██████╔╝█████╗  ██║  ███╗██║███████╗   ██║   █████╗  ██████╔╝    ███████║    ██║   ██║██║   ██║██║     ██║   ██║██╔██╗ ██║   ██║   █████╗  █████╗  ██████╔╝
                        ██╔══██╗██╔══╝  ██║   ██║██║╚════██║   ██║   ██╔══╝  ██╔══██╗    ██╔══██║    ╚██╗ ██╔╝██║   ██║██║     ██║   ██║██║╚██╗██║   ██║   ██╔══╝  ██╔══╝  ██╔══██╗
                        ██║  ██║███████╗╚██████╔╝██║███████║   ██║   ███████╗██║  ██║    ██║  ██║     ╚████╔╝ ╚██████╔╝███████╗╚██████╔╝██║ ╚████║   ██║   ███████╗███████╗██║  ██║
                        ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝    ╚═╝  ╚═╝      ╚═══╝   ╚═════╝ ╚══════╝ ╚═════╝ ╚═╝  ╚═══╝   ╚═╝   ╚══════╝╚══════╝╚═╝  ╚═╝
             
            
    ");
        Console.Write("Enter Volunteer Name: ");
        string volunteerName = Console.ReadLine();
        Console.Write("Enter Volunteer Contact Number: ");
        string contactNumber = Console.ReadLine();
        ManageAnimal manageAnimal = new ManageAnimal();
        manageAnimal.RegisterVolunteer(volunteerName, contactNumber);
        Console.Clear();
        Console.WriteLine("Volunteer Registered Successfully!\n");
    }

    public static void registerDonor()
    {
        Console.Clear();
        Console.WriteLine(@"

                        ██████╗ ███████╗ ██████╗ ██╗███████╗████████╗███████╗██████╗      █████╗     ██████╗  ██████╗ ███╗   ██╗ ██████╗ ██████╗     
                        ██╔══██╗██╔════╝██╔════╝ ██║██╔════╝╚══██╔══╝██╔════╝██╔══██╗    ██╔══██╗    ██╔══██╗██╔═══██╗████╗  ██║██╔═══██╗██╔══██╗    
                        ██████╔╝█████╗  ██║  ███╗██║███████╗   ██║   █████╗  ██████╔╝    ███████║    ██║  ██║██║   ██║██╔██╗ ██║██║   ██║██████╔╝    
                        ██╔══██╗██╔══╝  ██║   ██║██║╚════██║   ██║   ██╔══╝  ██╔══██╗    ██╔══██║    ██║  ██║██║   ██║██║╚██╗██║██║   ██║██╔══██╗    
                        ██║  ██║███████╗╚██████╔╝██║███████║   ██║   ███████╗██║  ██║    ██║  ██║    ██████╔╝╚██████╔╝██║ ╚████║╚██████╔╝██║  ██║    
                        ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝    ╚═╝  ╚═╝    ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝ ╚═════╝ ╚═╝  ╚═╝    

");
        Console.Write("Enter Donor Name: ");
        string donorName = Console.ReadLine();
        Console.Write("Enter Donation Amount: ");
        double donationAmount = double.Parse(Console.ReadLine());
        ManageAnimal manageAnimal = new ManageAnimal();
        manageAnimal.RegisterDonor(donorName, donationAmount);
        Console.Clear();
        Console.WriteLine("Donor Registered Successfully!\n");
    }

    public static void updateMedicalHistory()
    {
        Console.Clear();
        Console.WriteLine(@"

                            ██╗   ██╗██████╗ ██████╗  █████╗ ████████╗███████╗    ███╗   ███╗███████╗██████╗ ██╗ ██████╗ █████╗ ██╗         ██╗  ██╗██╗███████╗████████╗ ██████╗ ██████╗ ██╗   ██╗
                            ██║   ██║██╔══██╗██╔══██╗██╔══██╗╚══██╔══╝██╔════╝    ████╗ ████║██╔════╝██╔══██╗██║██╔════╝██╔══██╗██║         ██║  ██║██║██╔════╝╚══██╔══╝██╔═══██╗██╔══██╗╚██╗ ██╔╝
                            ██║   ██║██████╔╝██║  ██║███████║   ██║   █████╗      ██╔████╔██║█████╗  ██║  ██║██║██║     ███████║██║         ███████║██║███████╗   ██║   ██║   ██║██████╔╝ ╚████╔╝ 
                            ██║   ██║██╔═══╝ ██║  ██║██╔══██║   ██║   ██╔══╝      ██║╚██╔╝██║██╔══╝  ██║  ██║██║██║     ██╔══██║██║         ██╔══██║██║╚════██║   ██║   ██║   ██║██╔══██╗  ╚██╔╝  
                            ╚██████╔╝██║     ██████╔╝██║  ██║   ██║   ███████╗    ██║ ╚═╝ ██║███████╗██████╔╝██║╚██████╗██║  ██║███████╗    ██║  ██║██║███████║   ██║   ╚██████╔╝██║  ██║   ██║   
                             ╚═════╝ ╚═╝     ╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚══════╝    ╚═╝     ╚═╝╚══════╝╚═════╝ ╚═╝ ╚═════╝╚═╝  ╚═╝╚══════╝    ╚═╝  ╚═╝╚═╝╚══════╝   ╚═╝    ╚═════╝ ╚═╝  ╚═╝   ╚═╝   

");
        try
        {
            Console.Write("Enter Animal ID: ");
            int animalId = int.Parse(Console.ReadLine());

            // Verify if animal exists before updating the medical history
            ManageAnimal manageAnimal = new ManageAnimal();
            if (!manageAnimal.AnimalExists(animalId))
            {
                throw new Exception($"Animal with ID {animalId} does not exist.");
            }

            Console.Write("Enter Medical History: ");
            string medicalHistory = Console.ReadLine();
            manageAnimal.UpdateMedicalHistory(animalId, medicalHistory);
            Console.Clear();
            Console.WriteLine("Medical History Updated Successfully!\n");
        }
        catch (FormatException)
        {
            Console.Clear();
            Console.WriteLine("Error: Invalid input. Please enter a valid number for the Animal ID.\n");
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.WriteLine("Error: " + ex.Message + "\n");
        }
    }



}

