using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrishiKit
{
    public static class SuggestCrops
    {


        static string seasons = @"rice maize millet bajra ragi pulses soyabean oilseeds sugarcane
7,10
wheat barley oats gram pulses linseed oilseeds
11,4
watermelon muskmelon cucumber 
5,6";
        static string states = @"andhrapradesh rice jowar bajra maize ragi
arunachalpradesh paddy millet wheat pulses 
assam rice jute sugarcane fruits tea 
bihar rice wheate maize pulses 
chhattisgarh paddy rice wheat maize groundnuts 
goa paddy ragi maize jowar bajra   
gujarat tobacco cotton groundnuts rice wheat jowar bajra  
haryana rice jowar bajra maize wheat  
himachalpradesh wheat maize rice barley 
jammuandkashmir wheat maize rice 
jharkhand paddy jowar bajra maize wheat barley 
karnataka rice ragi jowat maize 
kerala coconut tea coffee ginger 
madhyapradesh paddy wheat maize jowar 
maharashtra wheat rice jowar bajra 
manipur paddy sugarcane potato tobacco mustard 
meghalaya rice maize 
mizoram sugarcane 
nagaland rice millets maize pulses 
odisha rice pulses jute sugarcane 
punjab wheat rice cotton sugarcane 
rajasthan wheat barley pulses sugarcane 
sikkim wheat paddy maize barley 
tamilnadu paddy jowar bajra ragi 
tripura rice potato sugarcane jute 
uttarakhand rice wheat barley corn 
uttarpradesh wheat rice pulses potato sugarcane 
westbengal rice potato jute sugarcane wheat ";
        static Dictionary<string, string> seasonMap = null;
        static Dictionary<string, int> counter = null;
        public static string getSuggestion(string state, string season)
        {
            counter = new Dictionary<string, int>();
            seasonMap = new Dictionary<string, string>();
            string ret = string.Empty;
            seasonMap["khareef"] = " rice paddy maize millet bajra jute ragi pulses soyabean oilseeds sugarcane ";
            seasonMap["rabi"] = " wheat barley oats gram pulses linseed oilseeds mustard ";
            seasonMap["zaid"] = " watermelon muskmelon cucumber";
            string[] states_lines = states.Split('\n');
            foreach (string line in states_lines)
            {
                //Console.WriteLine(line);
                string[] crops = line.Split(' ');
                state = state.ToLower().Replace(" ", string.Empty);
                if (state.Equals(crops[0]))
                {
                    for (int i = 1; i < crops.Length; ++i)
                    {
                        counter.Add(crops[i], 1);
                        //Console.WriteLine(crops[i]);
                    }
                    season = season.ToLower().Replace(" ", string.Empty);
                    string[] crops_season = seasonMap[season].Split();
                    foreach (string crop in crops_season)
                    {
                        if (counter.ContainsKey(crop)) ret += crop + ' ';
                        //Console.WriteLine(crop);
                    }
                }
            }
            counter = null;
            seasonMap = null;
            return ret;
        }
    }
}
