using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KrishiKit
{
    public static class functions
    {
        //public static void loginButtonClicked(object sender, RoutedEventArgs e)
        //{
        //    if(loginSignup.Login(window.loginUsername.Text, window.loginPass.Password) == false)
        //    {
        //        MessageBox.Show("Invalid Credentials");
        //    }else
        //    {

        //    }
        //}
    }

    public static class loginSignup
    {
        public static string username, password;
        public static System.IO.StreamReader sr = null;
        public static System.IO.StreamWriter sw = null;
        private static string filename = "Resources/LoginSignUp.txt";
        public static bool SignUp(string user, string pass)
        {
            username = user;
            password = pass;
            string __line = string.Empty;
            try
            {
                sr = System.IO.File.OpenText(filename);
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
            sw = System.IO.File.AppendText(filename);
            sw.WriteLine(username + " " + password);
            sw.Close();
            //MessageBox.Show("Registered successfully!");
            return true;
        }
        public static bool Login(string user, string pass)
        {
            username = user;
            password = pass;
            string __line = string.Empty;
            try
            {
                sr = System.IO.File.OpenText(filename);
            }
            catch
            {
            }
            if (sr == null)
            {
                //MessageBox.Show("Invalid Credentials");
                return false;
            }

            while ((__line = sr.ReadLine()) != null)
            {
                string[] pair = __line.Split(' ');
                if (pair[0].Equals(username) && pair[1].Equals(password))
                {
                    //MessageBox.Show("Login Successful");
                    sr.Close();
                    return true;
                }
            }
            sr.Close();
            //MessageBox.Show("Invalid Credentials");
            return false;

        }
    }
}
