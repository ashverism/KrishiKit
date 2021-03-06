﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KrishiKit
{
    public static partial class functions
    {
        public static DataTable weatherDataTable = new DataTable();
        static string currentForecast = string.Empty;

        public static void Calling()
        {
            Weather();
            Forecast();
        }

        public static void Weather()
        {
            string data = "";
            try
            {
                WebClient client = new WebClient();
                data = client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=dhanbad&appid=46bae8e6ef27dcf8ed7b5341931f4c99");
            }
            catch (WebException ex)
            {
                string mess = "Web exception : ";
                mess += ex.Message;
                //MessageBox.Show(mess);
                /*Console.WriteLine("Exception Occured in Current : {0}", mess);
                Console.ReadLine();*/
            }
            string pat;
            string[] lines = new string[3];
            pat = "description";
            lines[0] = dataSplit(data, pat);

            pat = "temp";
            lines[1] = dataSplit(data, pat);
            float t = float.Parse(lines[1])/10;
            int w = (int)Math.Ceiling(t);
            lines[1] = w.ToString();

            pat = "humidity";
            lines[2] = dataSplit(data, pat);
            currentForecast = currentForecast + lines[0] + "\nTemperature : " + lines[1] + "\nHumidity : " + lines[2];
            Console.WriteLine(currentForecast);
            Console.ReadLine();
        }

        public static string dataSplit(string data, string pat)
        {
            int idx = data.IndexOf(pat);
            idx += pat.Length + 2;
            if (data[idx] == '"')
                idx++;
            string val = "";
            int i;
            for (i = idx; ; i++)
            {
                if (data[i] == '"' || data[i] == ',')
                    break;
                val += data[i];
            }
            return val;
        }

        public static void Forecast()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("http://api.openweathermap.org/data/2.5/forecast?q=dhanbad&mode=xml&appid=46bae8e6ef27dcf8ed7b5341931f4c99");
            Dictionary<int, Fore> dict = new Dictionary<int, Fore>();
            int i = 0;
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node.Name == "forecast")
                {
                    foreach (XmlNode node1 in node.ChildNodes)
                    {
                        Fore val = new Fore();

                        foreach (XmlAttribute item in node1.Attributes)
                        {
                            if (item.Name == "from")
                            {
                                string split_time = item.Value;
                                string[] t1 = split_time.Split(':');
                                string[] t2 = t1[0].Split('T');
                                string[] t3 = t2[0].Split('-');
                                string tym = "";
                                tym = tym + t3[2] + "/" + t3[1] + "/" + t3[0];
                                val.time = tym;
                            }
                        }
                        foreach (XmlNode node2 in node1.ChildNodes)
                        {
                            if (node2.Name == "temperature")
                            {
                                foreach (XmlAttribute item in node2.Attributes)
                                {
                                    if (item.Name == "value")
                                        val.temp = item.Value;
                                }
                            }
                            else if (node2.Name == "humidity")
                            {
                                foreach (XmlAttribute item in node2.Attributes)
                                {
                                    if (item.Name == "value")
                                        val.humidity = item.Value;
                                }
                            }
                            else if (node2.Name == "clouds")
                            {
                                foreach (XmlAttribute item in node2.Attributes)
                                {
                                    if (item.Name == "value")
                                        val.clouds = item.Value;
                                }
                            }
                        }
                        if (i % 8 == 0)
                            dict[i] = val;
                        i++;
                    }
                }
            }
            weatherDataTable.Columns.Add("Time", typeof(string));
            weatherDataTable.Columns.Add("Temperature", typeof(string));
            weatherDataTable.Columns.Add("Humidity", typeof(string));
            weatherDataTable.Columns.Add("Sky", typeof(string));

            foreach (int item in dict.Keys)
            {
                Fore v = dict[item];
                DataRow dr = weatherDataTable.NewRow();
                dr["Temperature"] = v.temp;
                dr["Humidity"] = v.humidity;
                dr["Sky"] = v.clouds;
                dr["Time"] = v.time;
                weatherDataTable.Rows.Add(dr);
            }

            foreach (DataRow dr in weatherDataTable.Rows)
            {
                foreach (var cell in dr.ItemArray)
                {
                    Console.Write(cell+" ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }

    class Fore
    {
        public string temp { get; set; }
        public string humidity { get; set; }
        public string clouds { get; set; }
        public string time { get; set; }
    }

    public static class loginSignup
    {
        public static string username, password;
        public static System.IO.StreamReader sr = null;
        public static System.IO.StreamWriter sw = null;
        private static string filename = "Resources/LoginSignUp.txt";
        public static bool SignUp(string user, string pass, bool isSeller)
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
                        return true;
                        return false;
                    }
                }
                sr.Close();
            }
            sw = System.IO.File.AppendText(filename);
            if (isSeller)
            {
                sw.WriteLine(username + " " + password + "S ");
            }
            else
            {
                sw.WriteLine(username + " " + password + "B ");
            }
            sw.Close();
            //MessageBox.Show("Registered successfully!");
            return true;
        }
        public static bool Login(string user, string pass, bool isSeller)
        {
            username = user;
            password = pass;
            string sellOrBuy;
            if (isSeller)
            {
                sellOrBuy = "S";
            }else
            {
                sellOrBuy = "B";
            }
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
                if (pair[0].Equals(username) && pair[1].Equals(password) && pair[2].Equals(sellOrBuy))
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
