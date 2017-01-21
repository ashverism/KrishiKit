using System;
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
        static DataTable datatable = new DataTable();
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
            catch (System.Net.WebException ex)
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
            datatable.Columns.Add("Time", typeof(string));
            datatable.Columns.Add("Temperature", typeof(string));
            datatable.Columns.Add("Humidity", typeof(string));
            datatable.Columns.Add("Sky", typeof(string));
            foreach (int item in dict.Keys)
            {
                Fore v = dict[item];
                DataRow dr = datatable.NewRow();
                dr["Temperature"] = v.temp;
                dr["Humidity"] = v.humidity;
                dr["Sky"] = v.clouds;
                dr["Time"] = v.time;
                datatable.Rows.Add(dr);
            }

            foreach (DataRow dr in datatable.Rows)
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
}   
