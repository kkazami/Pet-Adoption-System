using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;

namespace meyn
{
    class ManageAnimal
    {
        private static string connString = "Server=localhost;Database=petadoption;User ID=root;Password=;";

        public static bool CheckUserExists(string email)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE Email = @Email";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool RegisterUser(string fullName, string email, string password)
        {
            string hashedPassword = HashPassword(password);
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "INSERT INTO users (FullName, Email, Password) VALUES (@FullName, @Email, @Password)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public static bool ValidateLogin(string email, string password)
        {
            string hashedPassword = HashPassword(password);
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE Email = @Email AND Password = @Password";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void RegisterAnimal(string species, string breed, int age, string healthStatus)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected to MySQL!");

                    string query = "INSERT INTO animals (species, breed, age, healthStatus) VALUES (@species, @breed, @age, @healthStatus)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@species", species);
                        cmd.Parameters.AddWithValue("@breed", breed);
                        cmd.Parameters.AddWithValue("@age", age);
                        cmd.Parameters.AddWithValue("@healthStatus", healthStatus);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.Clear();
                        Console.WriteLine(rowsAffected > 0 ? @"

                                                                                                                                                                                                                                             ,---. 
                                          ,---.          ,--.                  ,--.                         ,--.        ,--.                          ,--.                                                     ,---.        ,--.,--.         |   | 
                                         /  O  \ ,--,--, `--',--,--,--. ,--,--.|  |    ,--.--. ,---.  ,---. `--' ,---.,-'  '-. ,---. ,--.--. ,---.  ,-|  |     ,---. ,--.,--. ,---. ,---. ,---.  ,---.  ,---. /  .-',--.,--.|  ||  |,--. ,--.|  .' 
                                        |  .-.  ||      \,--.|        |' ,-.  ||  |    |  .--'| .-. :| .-. |,--.(  .-''-.  .-'| .-. :|  .--'| .-. :' .-. |    (  .-' |  ||  || .--'| .--'| .-. :(  .-' (  .-' |  `-,|  ||  ||  ||  | \  '  / |  |  
                                        |  | |  ||  ||  ||  ||  |  |  |\ '-'  ||  |    |  |   \   --.' '-' '|  |.-'  `) |  |  \   --.|  |   \   --.\ `-' |    .-'  `)'  ''  '\ `--.\ `--.\   --..-'  `).-'  `)|  .-''  ''  '|  ||  |  \   '  `--'  
                                        `--' `--'`--''--'`--'`--`--`--' `--`--'`--'    `--'    `----'.`-  / `--'`----'  `--'   `----'`--'    `----' `---'     `----'  `----'  `---' `---' `----'`----' `----' `--'   `----' `--'`--'.-'  /   .--.  
                                                                                                     `---'                                                                                                                          `---'    '--'  
"
: @"


                                      █████▒▄▄▄       ██▓ ██▓    ▓█████ ▓█████▄    ▄▄▄█████▓ ▒█████      ██▀███  ▓█████   ▄████  ██▓  ██████ ▄▄▄█████▓▓█████  ██▀███      ▄▄▄       ███▄    █  ██▓ ███▄ ▄███▓ ▄▄▄       ██▓         
                                    ▓██   ▒▒████▄    ▓██▒▓██▒    ▓█   ▀ ▒██▀ ██▌   ▓  ██▒ ▓▒▒██▒  ██▒   ▓██ ▒ ██▒▓█   ▀  ██▒ ▀█▒▓██▒▒██    ▒ ▓  ██▒ ▓▒▓█   ▀ ▓██ ▒ ██▒   ▒████▄     ██ ▀█   █ ▓██▒▓██▒▀█▀ ██▒▒████▄    ▓██▒         
                                    ▒████ ░▒██  ▀█▄  ▒██▒▒██░    ▒███   ░██   █▌   ▒ ▓██░ ▒░▒██░  ██▒   ▓██ ░▄█ ▒▒███   ▒██░▄▄▄░▒██▒░ ▓██▄   ▒ ▓██░ ▒░▒███   ▓██ ░▄█ ▒   ▒██  ▀█▄  ▓██  ▀█ ██▒▒██▒▓██    ▓██░▒██  ▀█▄  ▒██░         
                                    ░▓█▒  ░░██▄▄▄▄██ ░██░▒██░    ▒▓█  ▄ ░▓█▄   ▌   ░ ▓██▓ ░ ▒██   ██░   ▒██▀▀█▄  ▒▓█  ▄ ░▓█  ██▓░██░  ▒   ██▒░ ▓██▓ ░ ▒▓█  ▄ ▒██▀▀█▄     ░██▄▄▄▄██ ▓██▒  ▐▌██▒░██░▒██    ▒██ ░██▄▄▄▄██ ▒██░         
                                    ░▒█░    ▓█   ▓██▒░██░░██████▒░▒████▒░▒████▓      ▒██▒ ░ ░ ████▓▒░   ░██▓ ▒██▒░▒████▒░▒▓███▀▒░██░▒██████▒▒  ▒██▒ ░ ░▒████▒░██▓ ▒██▒    ▓█   ▓██▒▒██░   ▓██░░██░▒██▒   ░██▒ ▓█   ▓██▒░██████▒ ██▓ 
                                     ▒ ░    ▒▒   ▓▒█░░▓  ░ ▒░▓  ░░░ ▒░ ░ ▒▒▓  ▒      ▒ ░░   ░ ▒░▒░▒░    ░ ▒▓ ░▒▓░░░ ▒░ ░ ░▒   ▒ ░▓  ▒ ▒▓▒ ▒ ░  ▒ ░░   ░░ ▒░ ░░ ▒▓ ░▒▓░    ▒▒   ▓▒█░░ ▒░   ▒ ▒ ░▓  ░ ▒░   ░  ░ ▒▒   ▓▒█░░ ▒░▓  ░ ▒▓▒ 
                                     ░       ▒   ▒▒ ░ ▒ ░░ ░ ▒  ░ ░ ░  ░ ░ ▒  ▒        ░      ░ ▒ ▒░      ░▒ ░ ▒░ ░ ░  ░  ░   ░  ▒ ░░ ░▒  ░ ░    ░     ░ ░  ░  ░▒ ░ ▒░     ▒   ▒▒ ░░ ░░   ░ ▒░ ▒ ░░  ░      ░  ▒   ▒▒ ░░ ░ ▒  ░ ░▒  
                                     ░ ░     ░   ▒    ▒ ░  ░ ░      ░    ░ ░  ░      ░      ░ ░ ░ ▒       ░░   ░    ░   ░ ░   ░  ▒ ░░  ░  ░    ░         ░     ░░   ░      ░   ▒      ░   ░ ░  ▒ ░░      ░     ░   ▒     ░ ░    ░   
                                                 ░  ░ ░      ░  ░   ░  ░   ░                    ░ ░        ░        ░  ░      ░  ░        ░              ░  ░   ░              ░  ░         ░  ░         ░         ░  ░    ░  ░  ░  
                                                                         ░                                                                                                                                                       ░  

");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void CreateAdoptionRequest(string adopterName, int animalId)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO adoption_requests (adopterName, animalId, requestDate) VALUES (@adopterName, @animalId, NOW())";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@adopterName", adopterName);
                        cmd.Parameters.AddWithValue("@animalId", animalId);
                        cmd.ExecuteNonQuery();
                        Console.Clear();
                        Console.WriteLine(@"

                                                                                                                                                                                                                                                                                              ,---. 
                                                      ,---.     ,--.                ,--.  ,--.                                                               ,--.                 ,--.   ,--.          ,--.                                                     ,---.        ,--.,--.         |   | 
                                                     /  O  \  ,-|  | ,---.  ,---. ,-'  '-.`--' ,---. ,--,--,     ,--.--. ,---.  ,---. ,--.,--. ,---.  ,---.,-'  '-.     ,--,--. ,-|  | ,-|  | ,---.  ,-|  |     ,---. ,--.,--. ,---. ,---. ,---.  ,---.  ,---. /  .-',--.,--.|  ||  |,--. ,--.|  .' 
                                                    |  .-.  |' .-. || .-. || .-. |'-.  .-',--.| .-. ||      \    |  .--'| .-. :| .-. ||  ||  || .-. :(  .-''-.  .-'    ' ,-.  |' .-. |' .-. || .-. :' .-. |    (  .-' |  ||  || .--'| .--'| .-. :(  .-' (  .-' |  `-,|  ||  ||  ||  | \  '  / |  |  
                                                    |  | |  |\ `-' |' '-' '| '-' '  |  |  |  |' '-' '|  ||  |    |  |   \   --.' '-' |'  ''  '\   --..-'  `) |  |      \ '-'  |\ `-' |\ `-' |\   --.\ `-' |    .-'  `)'  ''  '\ `--.\ `--.\   --..-'  `).-'  `)|  .-''  ''  '|  ||  |  \   '  `--'  
                                                    `--' `--' `---'  `---' |  |-'   `--'  `--' `---' `--''--'    `--'    `----' `-|  | `----'  `----'`----'  `--'       `--`--' `---'  `---'  `----' `---'     `----'  `----'  `---' `---' `----'`----' `----' `--'   `----' `--'`--'.-'  /   .--.  
                                                                           `--'                                                   `--'                                                                                                                                               `---'    '--'  



");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void TrackAdoptionRequest(string adopterName, int animalId)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT adopterName, animalId, requestDate FROM adoption_requests WHERE adopterName = @adopterName AND animalId = @animalId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@adopterName", adopterName);
                        cmd.Parameters.AddWithValue("@animalId", animalId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string adopter = reader.GetString(0);
                                    int animal = reader.GetInt32(1);
                                    DateTime requestDate = reader.GetDateTime(2);
                                    Console.Clear();
                                    Console.WriteLine(@"


                                                     █████╗ ██████╗  ██████╗ ██████╗ ████████╗██╗ ██████╗ ███╗   ██╗    ██████╗ ███████╗ ██████╗ ██╗   ██╗███████╗███████╗████████╗    ███████╗ ██████╗ ██╗   ██╗███╗   ██╗██████╗ ██╗
                                                    ██╔══██╗██╔══██╗██╔═══██╗██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║    ██╔══██╗██╔════╝██╔═══██╗██║   ██║██╔════╝██╔════╝╚══██╔══╝    ██╔════╝██╔═══██╗██║   ██║████╗  ██║██╔══██╗██║
                                                    ███████║██║  ██║██║   ██║██████╔╝   ██║   ██║██║   ██║██╔██╗ ██║    ██████╔╝█████╗  ██║   ██║██║   ██║█████╗  ███████╗   ██║       █████╗  ██║   ██║██║   ██║██╔██╗ ██║██║  ██║██║
                                                    ██╔══██║██║  ██║██║   ██║██╔═══╝    ██║   ██║██║   ██║██║╚██╗██║    ██╔══██╗██╔══╝  ██║▄▄ ██║██║   ██║██╔══╝  ╚════██║   ██║       ██╔══╝  ██║   ██║██║   ██║██║╚██╗██║██║  ██║╚═╝
                                                    ██║  ██║██████╔╝╚██████╔╝██║        ██║   ██║╚██████╔╝██║ ╚████║    ██║  ██║███████╗╚██████╔╝╚██████╔╝███████╗███████║   ██║       ██║     ╚██████╔╝╚██████╔╝██║ ╚████║██████╔╝██╗
                                                    ╚═╝  ╚═╝╚═════╝  ╚═════╝ ╚═╝        ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝    ╚═╝  ╚═╝╚══════╝ ╚══▀▀═╝  ╚═════╝ ╚══════╝╚══════╝   ╚═╝       ╚═╝      ╚═════╝  ╚═════╝ ╚═╝  ╚═══╝╚═════╝ ╚═╝
 
");
                                    Console.WriteLine($"Adopter: {adopter}\nAnimal ID: {animal}\nRequest Date: {requestDate}\n");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine(@"


                                             ███▄    █  ▒█████      ▄▄▄      ▓█████▄  ▒█████   ██▓███  ▄▄▄█████▓ ██▓ ▒█████   ███▄    █     ██▀███  ▓█████   █████   █    ██ ▓█████   ██████ ▄▄▄█████▓     █████▒▒█████   █    ██  ███▄    █ ▓█████▄ 
                                             ██ ▀█   █ ▒██▒  ██▒   ▒████▄    ▒██▀ ██▌▒██▒  ██▒▓██░  ██▒▓  ██▒ ▓▒▓██▒▒██▒  ██▒ ██ ▀█   █    ▓██ ▒ ██▒▓█   ▀ ▒██▓  ██▒ ██  ▓██▒▓█   ▀ ▒██    ▒ ▓  ██▒ ▓▒   ▓██   ▒▒██▒  ██▒ ██  ▓██▒ ██ ▀█   █ ▒██▀ ██▌
                                            ▓██  ▀█ ██▒▒██░  ██▒   ▒██  ▀█▄  ░██   █▌▒██░  ██▒▓██░ ██▓▒▒ ▓██░ ▒░▒██▒▒██░  ██▒▓██  ▀█ ██▒   ▓██ ░▄█ ▒▒███   ▒██▒  ██░▓██  ▒██░▒███   ░ ▓██▄   ▒ ▓██░ ▒░   ▒████ ░▒██░  ██▒▓██  ▒██░▓██  ▀█ ██▒░██   █▌
                                            ▓██▒  ▐▌██▒▒██   ██░   ░██▄▄▄▄██ ░▓█▄   ▌▒██   ██░▒██▄█▓▒ ▒░ ▓██▓ ░ ░██░▒██   ██░▓██▒  ▐▌██▒   ▒██▀▀█▄  ▒▓█  ▄ ░██  █▀ ░▓▓█  ░██░▒▓█  ▄   ▒   ██▒░ ▓██▓ ░    ░▓█▒  ░▒██   ██░▓▓█  ░██░▓██▒  ▐▌██▒░▓█▄   ▌
                                            ▒██░   ▓██░░ ████▓▒░    ▓█   ▓██▒░▒████▓ ░ ████▓▒░▒██▒ ░  ░  ▒██▒ ░ ░██░░ ████▓▒░▒██░   ▓██░   ░██▓ ▒██▒░▒████▒░▒███▒█▄ ▒▒█████▓ ░▒████▒▒██████▒▒  ▒██▒ ░    ░▒█░   ░ ████▓▒░▒▒█████▓ ▒██░   ▓██░░▒████▓ 
                                            ░ ▒░   ▒ ▒ ░ ▒░▒░▒░     ▒▒   ▓▒█░ ▒▒▓  ▒ ░ ▒░▒░▒░ ▒▓▒░ ░  ░  ▒ ░░   ░▓  ░ ▒░▒░▒░ ░ ▒░   ▒ ▒    ░ ▒▓ ░▒▓░░░ ▒░ ░░░ ▒▒░ ▒ ░▒▓▒ ▒ ▒ ░░ ▒░ ░▒ ▒▓▒ ▒ ░  ▒ ░░       ▒ ░   ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒ ░ ▒░   ▒ ▒  ▒▒▓  ▒ 
                                            ░ ░░   ░ ▒░  ░ ▒ ▒░      ▒   ▒▒ ░ ░ ▒  ▒   ░ ▒ ▒░ ░▒ ░         ░     ▒ ░  ░ ▒ ▒░ ░ ░░   ░ ▒░     ░▒ ░ ▒░ ░ ░  ░ ░ ▒░  ░ ░░▒░ ░ ░  ░ ░  ░░ ░▒  ░ ░    ░        ░       ░ ▒ ▒░ ░░▒░ ░ ░ ░ ░░   ░ ▒░ ░ ▒  ▒ 
                                               ░   ░ ░ ░ ░ ░ ▒       ░   ▒    ░ ░  ░ ░ ░ ░ ▒  ░░         ░       ▒ ░░ ░ ░ ▒     ░   ░ ░      ░░   ░    ░      ░   ░  ░░░ ░ ░    ░   ░  ░  ░    ░          ░ ░   ░ ░ ░ ▒   ░░░ ░ ░    ░   ░ ░  ░ ░  ░ 
                                                     ░     ░ ░           ░  ░   ░        ░ ░                     ░      ░ ░           ░       ░        ░  ░    ░       ░        ░  ░      ░                         ░ ░     ░              ░    ░    
                                                                              ░                                                                                                                                                               ░      

");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void RegisterVolunteer(string volunteerName, string contactInfo)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected to MySQL!");

                    string query = "INSERT INTO volunteers (volunteerName, contactInfo) VALUES (@volunteerName, @contactInfo)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@volunteerName", volunteerName);
                        cmd.Parameters.AddWithValue("@contactInfo", contactInfo);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.Clear();
                        Console.WriteLine(rowsAffected > 0 ? @"

                                                                                                                                                                                                                                                   ,---. 
                        ,--.   ,--.     ,--.                  ,--.                                                ,--.        ,--.                          ,--.                                                     ,---.        ,--.,--.         |   | 
                         \  `.'  /,---. |  |,--.,--.,--,--, ,-'  '-. ,---.  ,---. ,--.--.    ,--.--. ,---.  ,---. `--' ,---.,-'  '-. ,---. ,--.--. ,---.  ,-|  |     ,---. ,--.,--. ,---. ,---. ,---.  ,---.  ,---. /  .-',--.,--.|  ||  |,--. ,--.|  .' 
                          \     /| .-. ||  ||  ||  ||      \'-.  .-'| .-. :| .-. :|  .--'    |  .--'| .-. :| .-. |,--.(  .-''-.  .-'| .-. :|  .--'| .-. :' .-. |    (  .-' |  ||  || .--'| .--'| .-. :(  .-' (  .-' |  `-,|  ||  ||  ||  | \  '  / |  |  
                           \   / ' '-' '|  |'  ''  '|  ||  |  |  |  \   --.\   --.|  |       |  |   \   --.' '-' '|  |.-'  `) |  |  \   --.|  |   \   --.\ `-' |    .-'  `)'  ''  '\ `--.\ `--.\   --..-'  `).-'  `)|  .-''  ''  '|  ||  |  \   '  `--'  
                            `-'   `---' `--' `----' `--''--'  `--'   `----' `----'`--'       `--'    `----'.`-  / `--'`----'  `--'   `----'`--'    `----' `---'     `----'  `----'  `---' `---' `----'`----' `----' `--'   `----' `--'`--'.-'  /   .--.  
                                                                                                           `---'                                                                                                                          `---'    '--'  


" : @"  

                    █████▒▄▄▄       ██▓ ██▓    ▓█████ ▓█████▄    ▄▄▄█████▓ ▒█████      ██▀███  ▓█████   ▄████  ██▓  ██████ ▄▄▄█████▓▓█████  ██▀███      ██▒   █▓ ▒█████   ██▓     █    ██  ███▄    █ ▄▄▄█████▓▓█████ ▓█████  ██▀███       
                    ▓██   ▒▒████▄    ▓██▒▓██▒    ▓█   ▀ ▒██▀ ██▌   ▓  ██▒ ▓▒▒██▒  ██▒   ▓██ ▒ ██▒▓█   ▀  ██▒ ▀█▒▓██▒▒██    ▒ ▓  ██▒ ▓▒▓█   ▀ ▓██ ▒ ██▒   ▓██░   █▒▒██▒  ██▒▓██▒     ██  ▓██▒ ██ ▀█   █ ▓  ██▒ ▓▒▓█   ▀ ▓█   ▀ ▓██ ▒ ██▒     
                    ▒████ ░▒██  ▀█▄  ▒██▒▒██░    ▒███   ░██   █▌   ▒ ▓██░ ▒░▒██░  ██▒   ▓██ ░▄█ ▒▒███   ▒██░▄▄▄░▒██▒░ ▓██▄   ▒ ▓██░ ▒░▒███   ▓██ ░▄█ ▒    ▓██  █▒░▒██░  ██▒▒██░    ▓██  ▒██░▓██  ▀█ ██▒▒ ▓██░ ▒░▒███   ▒███   ▓██ ░▄█ ▒     
                    ░▓█▒  ░░██▄▄▄▄██ ░██░▒██░    ▒▓█  ▄ ░▓█▄   ▌   ░ ▓██▓ ░ ▒██   ██░   ▒██▀▀█▄  ▒▓█  ▄ ░▓█  ██▓░██░  ▒   ██▒░ ▓██▓ ░ ▒▓█  ▄ ▒██▀▀█▄       ▒██ █░░▒██   ██░▒██░    ▓▓█  ░██░▓██▒  ▐▌██▒░ ▓██▓ ░ ▒▓█  ▄ ▒▓█  ▄ ▒██▀▀█▄       
                    ░▒█░    ▓█   ▓██▒░██░░██████▒░▒████▒░▒████▓      ▒██▒ ░ ░ ████▓▒░   ░██▓ ▒██▒░▒████▒░▒▓███▀▒░██░▒██████▒▒  ▒██▒ ░ ░▒████▒░██▓ ▒██▒      ▒▀█░  ░ ████▓▒░░██████▒▒▒█████▓ ▒██░   ▓██░  ▒██▒ ░ ░▒████▒░▒████▒░██▓ ▒██▒ ██▓ 
                     ▒ ░    ▒▒   ▓▒█░░▓  ░ ▒░▓  ░░░ ▒░ ░ ▒▒▓  ▒      ▒ ░░   ░ ▒░▒░▒░    ░ ▒▓ ░▒▓░░░ ▒░ ░ ░▒   ▒ ░▓  ▒ ▒▓▒ ▒ ░  ▒ ░░   ░░ ▒░ ░░ ▒▓ ░▒▓░      ░ ▐░  ░ ▒░▒░▒░ ░ ▒░▓  ░░▒▓▒ ▒ ▒ ░ ▒░   ▒ ▒   ▒ ░░   ░░ ▒░ ░░░ ▒░ ░░ ▒▓ ░▒▓░ ▒▓▒ 
                     ░       ▒   ▒▒ ░ ▒ ░░ ░ ▒  ░ ░ ░  ░ ░ ▒  ▒        ░      ░ ▒ ▒░      ░▒ ░ ▒░ ░ ░  ░  ░   ░  ▒ ░░ ░▒  ░ ░    ░     ░ ░  ░  ░▒ ░ ▒░      ░ ░░    ░ ▒ ▒░ ░ ░ ▒  ░░░▒░ ░ ░ ░ ░░   ░ ▒░    ░     ░ ░  ░ ░ ░  ░  ░▒ ░ ▒░ ░▒  
                     ░ ░     ░   ▒    ▒ ░  ░ ░      ░    ░ ░  ░      ░      ░ ░ ░ ▒       ░░   ░    ░   ░ ░   ░  ▒ ░░  ░  ░    ░         ░     ░░   ░         ░░  ░ ░ ░ ▒    ░ ░    ░░░ ░ ░    ░   ░ ░   ░         ░      ░     ░░   ░  ░   
                                 ░  ░ ░      ░  ░   ░  ░   ░                    ░ ░        ░        ░  ░      ░  ░        ░              ░  ░   ░              ░      ░ ░      ░  ░   ░              ░             ░  ░   ░  ░   ░       ░  
                                                         ░                                                                                                    ░                                                                          ░  

");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void RegisterDonor(string donorName, double donationAmount)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected to MySQL!");

                    string query = "INSERT INTO donors (donorName, donationAmount) VALUES (@donorName, @donationAmount)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@donorName", donorName);
                        cmd.Parameters.AddWithValue("@donationAmount", donationAmount);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? @"

                                                                                                                                                                                                                                     ,---. 
                                    ,------.                                                        ,--.        ,--.                          ,--.                                                     ,---.        ,--.,--.         |   | 
                                    |  .-.  \  ,---. ,--,--,  ,---. ,--.--.    ,--.--. ,---.  ,---. `--' ,---.,-'  '-. ,---. ,--.--. ,---.  ,-|  |     ,---. ,--.,--. ,---. ,---. ,---.  ,---.  ,---. /  .-',--.,--.|  ||  |,--. ,--.|  .' 
                                    |  |  \  :| .-. ||      \| .-. ||  .--'    |  .--'| .-. :| .-. |,--.(  .-''-.  .-'| .-. :|  .--'| .-. :' .-. |    (  .-' |  ||  || .--'| .--'| .-. :(  .-' (  .-' |  `-,|  ||  ||  ||  | \  '  / |  |  
                                    |  '--'  /' '-' '|  ||  |' '-' '|  |       |  |   \   --.' '-' '|  |.-'  `) |  |  \   --.|  |   \   --.\ `-' |    .-'  `)'  ''  '\ `--.\ `--.\   --..-'  `).-'  `)|  .-''  ''  '|  ||  |  \   '  `--'  
                                    `-------'  `---' `--''--' `---' `--'       `--'    `----'.`-  / `--'`----'  `--'   `----'`--'    `----' `---'     `----'  `----'  `---' `---' `----'`----' `----' `--'   `----' `--'`--'.-'  /   .--.  
                                                                                             `---'                                                                                                                          `---'    '--'  

" : @"

                                                  █████▒▄▄▄       ██▓ ██▓    ▓█████ ▓█████▄    ▄▄▄█████▓ ▒█████      ██▀███  ▓█████   ▄████  ██▓  ██████ ▄▄▄█████▓▓█████  ██▀███     ▓█████▄  ▒█████   ███▄    █  ▒█████   ██▀███       
                                                ▓██   ▒▒████▄    ▓██▒▓██▒    ▓█   ▀ ▒██▀ ██▌   ▓  ██▒ ▓▒▒██▒  ██▒   ▓██ ▒ ██▒▓█   ▀  ██▒ ▀█▒▓██▒▒██    ▒ ▓  ██▒ ▓▒▓█   ▀ ▓██ ▒ ██▒   ▒██▀ ██▌▒██▒  ██▒ ██ ▀█   █ ▒██▒  ██▒▓██ ▒ ██▒     
                                                ▒████ ░▒██  ▀█▄  ▒██▒▒██░    ▒███   ░██   █▌   ▒ ▓██░ ▒░▒██░  ██▒   ▓██ ░▄█ ▒▒███   ▒██░▄▄▄░▒██▒░ ▓██▄   ▒ ▓██░ ▒░▒███   ▓██ ░▄█ ▒   ░██   █▌▒██░  ██▒▓██  ▀█ ██▒▒██░  ██▒▓██ ░▄█ ▒     
                                                ░▓█▒  ░░██▄▄▄▄██ ░██░▒██░    ▒▓█  ▄ ░▓█▄   ▌   ░ ▓██▓ ░ ▒██   ██░   ▒██▀▀█▄  ▒▓█  ▄ ░▓█  ██▓░██░  ▒   ██▒░ ▓██▓ ░ ▒▓█  ▄ ▒██▀▀█▄     ░▓█▄   ▌▒██   ██░▓██▒  ▐▌██▒▒██   ██░▒██▀▀█▄       
                                                ░▒█░    ▓█   ▓██▒░██░░██████▒░▒████▒░▒████▓      ▒██▒ ░ ░ ████▓▒░   ░██▓ ▒██▒░▒████▒░▒▓███▀▒░██░▒██████▒▒  ▒██▒ ░ ░▒████▒░██▓ ▒██▒   ░▒████▓ ░ ████▓▒░▒██░   ▓██░░ ████▓▒░░██▓ ▒██▒ ██▓ 
                                                 ▒ ░    ▒▒   ▓▒█░░▓  ░ ▒░▓  ░░░ ▒░ ░ ▒▒▓  ▒      ▒ ░░   ░ ▒░▒░▒░    ░ ▒▓ ░▒▓░░░ ▒░ ░ ░▒   ▒ ░▓  ▒ ▒▓▒ ▒ ░  ▒ ░░   ░░ ▒░ ░░ ▒▓ ░▒▓░    ▒▒▓  ▒ ░ ▒░▒░▒░ ░ ▒░   ▒ ▒ ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░ ▒▓▒ 
                                                 ░       ▒   ▒▒ ░ ▒ ░░ ░ ▒  ░ ░ ░  ░ ░ ▒  ▒        ░      ░ ▒ ▒░      ░▒ ░ ▒░ ░ ░  ░  ░   ░  ▒ ░░ ░▒  ░ ░    ░     ░ ░  ░  ░▒ ░ ▒░    ░ ▒  ▒   ░ ▒ ▒░ ░ ░░   ░ ▒░  ░ ▒ ▒░   ░▒ ░ ▒░ ░▒  
                                                 ░ ░     ░   ▒    ▒ ░  ░ ░      ░    ░ ░  ░      ░      ░ ░ ░ ▒       ░░   ░    ░   ░ ░   ░  ▒ ░░  ░  ░    ░         ░     ░░   ░     ░ ░  ░ ░ ░ ░ ▒     ░   ░ ░ ░ ░ ░ ▒    ░░   ░  ░   
                                                             ░  ░ ░      ░  ░   ░  ░   ░                    ░ ░        ░        ░  ░      ░  ░        ░              ░  ░   ░           ░        ░ ░           ░     ░ ░     ░       ░  
                                                                                     ░                                                                                                ░                                              ░  

");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void UpdateMedicalHistory(int animalId, string medicalHistory)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected to MySQL!");

                    string query = "UPDATE animals SET medicalHistory = @medicalHistory WHERE id = @animalId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@medicalHistory", medicalHistory);
                        cmd.Parameters.AddWithValue("@animalId", animalId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        Console.WriteLine(rowsAffected > 0 ? @"

                                                                                                                                                                                                                                                                                ,---. 
                                ,--.   ,--.          ,--.,--.              ,--.    ,--.     ,--.        ,--.                                               ,--.          ,--.            ,--.                                                     ,---.        ,--.,--.         |   | 
                                |   `.'   | ,---.  ,-|  |`--' ,---. ,--,--.|  |    |  ,---. `--' ,---.,-'  '-. ,---. ,--.--.,--. ,--.    ,--.,--. ,---.  ,-|  | ,--,--.,-'  '-. ,---.  ,-|  |     ,---. ,--.,--. ,---. ,---. ,---.  ,---.  ,---. /  .-',--.,--.|  ||  |,--. ,--.|  .' 
                                |  |'.'|  || .-. :' .-. |,--.| .--'' ,-.  ||  |    |  .-.  |,--.(  .-''-.  .-'| .-. ||  .--' \  '  /     |  ||  || .-. |' .-. |' ,-.  |'-.  .-'| .-. :' .-. |    (  .-' |  ||  || .--'| .--'| .-. :(  .-' (  .-' |  `-,|  ||  ||  ||  | \  '  / |  |  
                                |  |   |  |\   --.\ `-' ||  |\ `--.\ '-'  ||  |    |  | |  ||  |.-'  `) |  |  ' '-' '|  |     \   '      '  ''  '| '-' '\ `-' |\ '-'  |  |  |  \   --.\ `-' |    .-'  `)'  ''  '\ `--.\ `--.\   --..-'  `).-'  `)|  .-''  ''  '|  ||  |  \   '  `--'  
                                `--'   `--' `----' `---' `--' `---' `--`--'`--'    `--' `--'`--'`----'  `--'   `---' `--'   .-'  /        `----' |  |-'  `---'  `--`--'  `--'   `----' `---'     `----'  `----'  `---' `---' `----'`----' `----' `--'   `----' `--'`--'.-'  /   .--.  
                                                                                                                            `---'                `--'                                                                                                                  `---'    '--'  

" : @"

                                          █████▒▄▄▄       ██▓ ██▓    ▓█████ ▓█████▄    ▄▄▄█████▓ ▒█████      █    ██  ██▓███  ▓█████▄  ▄▄▄     ▄▄▄█████▓▓█████     ███▄ ▄███▓▓█████ ▓█████▄  ██▓ ▄████▄   ▄▄▄       ██▓        ██░ ██  ██▓  ██████ ▄▄▄█████▓ ▒█████   ██▀███ ▓██   ██▓     
                                        ▓██   ▒▒████▄    ▓██▒▓██▒    ▓█   ▀ ▒██▀ ██▌   ▓  ██▒ ▓▒▒██▒  ██▒    ██  ▓██▒▓██░  ██▒▒██▀ ██▌▒████▄   ▓  ██▒ ▓▒▓█   ▀    ▓██▒▀█▀ ██▒▓█   ▀ ▒██▀ ██▌▓██▒▒██▀ ▀█  ▒████▄    ▓██▒       ▓██░ ██▒▓██▒▒██    ▒ ▓  ██▒ ▓▒▒██▒  ██▒▓██ ▒ ██▒▒██  ██▒     
                                        ▒████ ░▒██  ▀█▄  ▒██▒▒██░    ▒███   ░██   █▌   ▒ ▓██░ ▒░▒██░  ██▒   ▓██  ▒██░▓██░ ██▓▒░██   █▌▒██  ▀█▄ ▒ ▓██░ ▒░▒███      ▓██    ▓██░▒███   ░██   █▌▒██▒▒▓█    ▄ ▒██  ▀█▄  ▒██░       ▒██▀▀██░▒██▒░ ▓██▄   ▒ ▓██░ ▒░▒██░  ██▒▓██ ░▄█ ▒ ▒██ ██░     
                                        ░▓█▒  ░░██▄▄▄▄██ ░██░▒██░    ▒▓█  ▄ ░▓█▄   ▌   ░ ▓██▓ ░ ▒██   ██░   ▓▓█  ░██░▒██▄█▓▒ ▒░▓█▄   ▌░██▄▄▄▄██░ ▓██▓ ░ ▒▓█  ▄    ▒██    ▒██ ▒▓█  ▄ ░▓█▄   ▌░██░▒▓▓▄ ▄██▒░██▄▄▄▄██ ▒██░       ░▓█ ░██ ░██░  ▒   ██▒░ ▓██▓ ░ ▒██   ██░▒██▀▀█▄   ░ ▐██▓░     
                                        ░▒█░    ▓█   ▓██▒░██░░██████▒░▒████▒░▒████▓      ▒██▒ ░ ░ ████▓▒░   ▒▒█████▓ ▒██▒ ░  ░░▒████▓  ▓█   ▓██▒ ▒██▒ ░ ░▒████▒   ▒██▒   ░██▒░▒████▒░▒████▓ ░██░▒ ▓███▀ ░ ▓█   ▓██▒░██████▒   ░▓█▒░██▓░██░▒██████▒▒  ▒██▒ ░ ░ ████▓▒░░██▓ ▒██▒ ░ ██▒▓░ ██▓ 
                                         ▒ ░    ▒▒   ▓▒█░░▓  ░ ▒░▓  ░░░ ▒░ ░ ▒▒▓  ▒      ▒ ░░   ░ ▒░▒░▒░    ░▒▓▒ ▒ ▒ ▒▓▒░ ░  ░ ▒▒▓  ▒  ▒▒   ▓▒█░ ▒ ░░   ░░ ▒░ ░   ░ ▒░   ░  ░░░ ▒░ ░ ▒▒▓  ▒ ░▓  ░ ░▒ ▒  ░ ▒▒   ▓▒█░░ ▒░▓  ░    ▒ ░░▒░▒░▓  ▒ ▒▓▒ ▒ ░  ▒ ░░   ░ ▒░▒░▒░ ░ ▒▓ ░▒▓░  ██▒▒▒  ▒▓▒ 
                                         ░       ▒   ▒▒ ░ ▒ ░░ ░ ▒  ░ ░ ░  ░ ░ ▒  ▒        ░      ░ ▒ ▒░    ░░▒░ ░ ░ ░▒ ░      ░ ▒  ▒   ▒   ▒▒ ░   ░     ░ ░  ░   ░  ░      ░ ░ ░  ░ ░ ▒  ▒  ▒ ░  ░  ▒     ▒   ▒▒ ░░ ░ ▒  ░    ▒ ░▒░ ░ ▒ ░░ ░▒  ░ ░    ░      ░ ▒ ▒░   ░▒ ░ ▒░▓██ ░▒░  ░▒  
                                         ░ ░     ░   ▒    ▒ ░  ░ ░      ░    ░ ░  ░      ░      ░ ░ ░ ▒      ░░░ ░ ░ ░░        ░ ░  ░   ░   ▒    ░         ░      ░      ░      ░    ░ ░  ░  ▒ ░░          ░   ▒     ░ ░       ░  ░░ ░ ▒ ░░  ░  ░    ░      ░ ░ ░ ▒    ░░   ░ ▒ ▒ ░░   ░   
                                                     ░  ░ ░      ░  ░   ░  ░   ░                    ░ ░        ░                 ░          ░  ░           ░  ░          ░      ░  ░   ░     ░  ░ ░            ░  ░    ░  ░    ░  ░  ░ ░        ░               ░ ░     ░     ░ ░       ░  
                                                                             ░                                                 ░                                                     ░          ░                                                                             ░ ░       ░  

");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public bool AnimalExists(int animalId)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM animals WHERE id = @animalId";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@animalId", animalId);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;  // Returns true if animal exists, false otherwise
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }




    }
}
