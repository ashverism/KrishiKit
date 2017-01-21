using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows;
using System.Text;
using System.Threading.Tasks;

namespace KrishiKit
{
    class LoginSignUp
    {
        string username, password;
        StreamReader sr = null;
        StreamWriter sw = null;
        private string filename = "Resources/LoginSignUp.txt";
        public bool SignUp(string user, string pass)
        {
            username = user;
            password = pass;
            string __line = string.Empty;
            try
            {
                sr = File.OpenText(filename);
            }
            catch
            {
            }
            if (sr != null)
            {
                while ((__line = sr.ReadLine()) != null)
                {
                    string[] pair = __line.Split(' ');
                    if (pair[0].Equals(username))
                    {
                        //MessageBox.Show("Username already exists!");
                        sr.Close();
                        return false;
                    }
                }
                sr.Close();
            }
            sw = File.AppendText(filename);
            sw.WriteLine(username + " " + password);
            sw.Close();
            MessageBox.Show("Registered successfully!");
            return true;
        }
        public bool Login( string user, string pass)
        {
            username = user;
            password = pass;
            string __line = string.Empty;
            try
            {
                sr = File.OpenText(filename);
            }
            catch
            {
            }
            if (sr == null)
            {
                MessageBox.Show("Invalid Credentials");
                return false;
            }
            
            while ((__line = sr.ReadLine()) != null)
            {
                string[] pair = __line.Split(' ');
                if (pair[0].Equals(username) && pair[1].Equals(password))
                {
                    MessageBox.Show("Login Successful");
                    sr.Close();
                    return true;
                }
            }
            sr.Close();
            MessageBox.Show("Invalid Credentials");
            return false;

        }
    }
}
