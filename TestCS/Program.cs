using System;
using System.Collections.Generic;
using System.Text;
using Lwh.ChineseSegment;
using Lwh.ChineseSegment.Utility;

namespace TestCS
{
    class Program
    {
        const string TESTTEXT = "新浪科技讯 2月23日上午消息，已成为热门关键词的丁磊养猪事件似乎并未吸引风险投资的兴趣。虽然投资者会用“有趣”一词来形容这样一则新闻，但更多的是保持谨慎观望态度。\n\n　　早在去年初，风险投资已经开始将嗅觉转向传统领域，新农业是关注重点之一，然而具体到养猪项目，则看的多投的少。即使加上足够吸引眼球的网易CEO丁磊，也并未能吸引投资者对“开源养猪”模式的兴趣。\n\n　　丁磊的计划是：养10000头猪来探索一套科学养猪模式供大家分享，他的优势在于，其养猪计划的背后挂靠一个老牌互联网公司，他希望用互联网直播等方式来公开猪肉信息、探索一个盈利的高效养猪模式。";
        //const string TESTTEXT = "2月23日上午消息";//，已成为热门关键词的丁磊养猪事件似乎并未吸引风险投资的兴趣。虽然投资者会用“有趣”一词来形容这样一则新闻，但更多的是保持谨慎观望态度。\n\n　　早在去年初，风险投资已经开始将嗅觉转向传统领域，新农业是关注重点之一，然而具体到养猪项目，则看的多投的少。即使加上足够吸引眼球的网易CEO丁磊，也并未能吸引投资者对“开源养猪”模式的兴趣。\n\n　　丁磊的计划是：养10000头猪来探索一套科学养猪模式供大家分享，他的优势在于，其养猪计划的背后挂靠一个老牌互联网公司，他希望用互联网直播等方式来公开猪肉信息、探索一个盈利的高效养猪模式。";
        //const string TESTTEXT = "养10000头猪来探索一套科学养猪模式供大家分享";
        static void Main(string[] args)
        {
            //TestSegment();
            //string space = "";
            //space.PadRight(10,' ');
            //Console.WriteLine("#" + space + "#");
            //StringBuilder builder = new StringBuilder();
            //builder.Append(' ', 10);
            //Console.WriteLine("#" + builder.ToString() + "#");
            //AuxiliaryString auxString = new AuxiliaryString();
            ////auxString.Append("/");
            //TestAuxString(auxString);
            //Console.WriteLine(auxString.ToString());
            for (int i = 0; i <= 255; i++)
            {
                Console.Write(i & 15);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        static void TestAuxString(AuxiliaryString auxString)
        {
            auxString.Append("helloworld");
        }
        static void TestSegment()
        {
            string path = @"d:\Indexer\seglib\";
            Segment.SetPaths(path + "BaseDict.txt", path + "FamilyName.txt", path + "Number.txt", path + "CustomDict.txt", path + "Other.txt");
            //string text = "ASP.Net MVC框架配置与分析 而今，微软推出了新的MVC开发框架，也就是Microsoft ASP.NET 3.5 Extensions";
            Segment.SetDefaults(new Lwh.ChineseSegment.DictionaryLoader.TextDictionaryLoader(), new ForwardMatchSegment());
            //Segment.OutputDictionary();
            List<int> posList;
            DateTime now = DateTime.Now;
            string result = Segment.SegmentString(TESTTEXT, out posList);
            TimeSpan span = DateTime.Now - now;
            Console.WriteLine(result);
            Console.WriteLine(span.TotalMilliseconds);
            foreach (int pos in posList)
            {
                Console.WriteLine(TESTTEXT.Substring(pos));
            }
            string[] tokens=result.Split("/".ToCharArray(),StringSplitOptions.RemoveEmptyEntries);
            foreach (string token in tokens)
            {
                Console.Write(token+"/");
            }
            Console.WriteLine();
            foreach (int pos in posList)
            {
                Console.Write(pos.ToString()+"/");
            }
            Console.WriteLine();
            Console.WriteLine(posList.Count);
            Console.WriteLine(tokens.Length);
        }
    }
}
