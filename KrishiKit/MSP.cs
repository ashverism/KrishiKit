using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Windows;
using System.IO;
using System.Web;
using System.Threading.Tasks;
using System.Data;

namespace KrishiKit
{
    public static class MSP
    {
        private static string safe(string s)
        {
            if (s.Contains("&nbsp;") || s.Contains("-"))
                return string.Empty;
            else return s;
        }
        public static DataTable getMSP(string page_url = "http://farmer.gov.in/mspstatements.aspx")
        {
            WebClient wc = new WebClient();
            string url = page_url;
            string page_source = string.Empty;
            /*try {
                page_source = wc.DownloadString(url);
            }
            catch {
                MessageBox.Show("Web Exception");
            }*/
            StreamReader sr = new StreamReader("Resources/SourceCodeMSP.txt");
            string line = string.Empty;
            while ((line = sr.ReadLine()) != null)
            {
                page_source += line;
                page_source += '\n';
            }
            //MessageBox.Show(page_source);
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(page_source);
            DataTable dt = new DataTable();
            string[] column_names = { "Commodity", "Variety", "2010-11", "2011-12", "2012-13", "2013-14", "2014-15", "2015-16", "2016-17" };
            foreach (string name in column_names)
                dt.Columns.Add(name, typeof(string));
            //string temp = string.Empty;

            foreach (var row in doc.DocumentNode.SelectNodes("//table[@id='tablebottom']/tr"))
            {
                DataRow dr = dt.NewRow();
                if (row.SelectNodes("td").Count == 1)
                {
                    foreach (var cell in row.SelectNodes("td"))
                    {
                        dr[column_names[0]] = safe(cell.InnerText + ' ');
                        //temp += safe(cell.InnerText + ' ');
                    }
                }
                else if (row.SelectNodes("td").Count == 8)
                {
                    int __i = 1;
                    foreach (var cell in row.SelectNodes("td"))
                    {
                        dr[column_names[__i++]] = safe(cell.InnerText + ' ');

                        //temp += safe(cell.InnerText + ' ');
                    }
                }
                else
                {
                    int __i = 0;
                    foreach (var cell in row.SelectNodes("td"))
                    {
                        dr[column_names[__i++]] = safe(cell.InnerText + ' ');

                        //temp += safe(cell.InnerText + ' ');
                    }
                }
                //temp += '\n';
                dt.Rows.Add(dr);
            }
            //MessageBox.Show(temp)
            for (int __i = 2; __i < 8; __i++) dt.Columns.Remove(column_names[__i]);
            
            return dt;
        }
    }
}
