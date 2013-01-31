using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using Util.Core;
using System.Web;

namespace XmlTest
{
    [Serializable]
    [XmlRoot("reply")]
    public class Reply
    {
        [XmlElement("username")]
        public string UserName { get; set; }
        [XmlElement("date")]
        public string Date { get; set; }

        private string content = string.Empty;
        [XmlElement("content")]
        public XmlCDataSection Content
        {
            get
            {
                XmlDocument xdoc = new XmlDocument();
                return xdoc.CreateCDataSection(content);
            }
            set
            {
                //HttpUtility.UrlEncode(value.Value);
                content = value.Value;
            }
        }
    }

    [Serializable]
    [XmlRoot("root")]
    public class ReplyList
    {
        [XmlArray("replys")]
        [XmlArrayItem("reply")]
        // [XmlElement("replys")]
        public List<Reply> Replys { get; set; }
    }

    public class Entity<T> where T : class
    {
        public Entity()
        {
            Console.WriteLine("进来了");
        }

        private static Entity<T> _install = null;
        public static Entity<T> Install
        {
            get
            {
                if (_install == null)
                {
                    _install = new Entity<T>();
                }
                return _install;
            }
        }
    }

    public static class Util
    {
        /// <summary>
        /// 过滤古怪字符
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string FilterQueerString(this string content)
        {
            if (!string.IsNullOrEmpty(content))
            {
                Regex reg = new Regex(@"[^\ufb00-\ufffdh\w\?？。！!￥\s\f\n\r\v\u4e00-\u9fa5\xAC00-\xD7A3\u0800-\u4e00~!@#\$%\^&*()+-=\.,/\\'"":;~！@#￥%……&*（）—
×÷±≈≠∧∨∑∪∩∈⊙⌒⊥∥∠√∨∧≯≮≥≤＞＜≌∽﹙﹚﹛﹜∫∮∝∞⊙∏∶₄·₃₁₂ⁿ⁴³²¹º½⅓⅔¼¾⅛⅜⅝⅞∵∵∷μλκιθη
ζ￡＄￥Pa㏒㏑molml㏎㎥㎡℉℃°〒¤○㏕〖〗』『︻︼﹄﹃︽︾㈠㈡㈢㈣㈤㈥㈦㈧㈨㈩ⅩⅨⅧⅦⅥⅤⅣⅢⅡⅠ
❶❷❸❹❺❻❼❽❾❿⑩⑨⑧⑦⑥⑤③④②①⑪⑫⑬⑭⑮⑯⑰⑱⑲⑳
]", RegexOptions.IgnoreCase);
                if (!string.IsNullOrEmpty(content))
                    content = reg.Replace(content, "*");
            }
            return content;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region xml测试
            string content = "如果1221真係末日，距離而家仲有一個星期，呢個星期你會想點過？";
            Console.WriteLine(content.FilterQueerString());
            #endregion

            //Entity<ReplyList> me = Entity<ReplyList>.Install;
            //Entity<ReplyList> me2 = Entity<ReplyList>.Install;

            // Console.WriteLine((int)Convert.ToChar("語"));
            List<string> s = new List<string>();
            s.Add("1");
            s.Add("2");
            s.Add("3");
            s.Add("4");
            s.Add("5");
            /* 
             * s.ForEach((m) =>
             {
                 if (m.Equals("3"))
                 {
                     //s.Remove(m); 不抛错但结果不会如期
                     return;
                 }
                 Console.WriteLine(m);
             });*/

            /* 抛错，集合不让修改
            foreach (var m in s)
            {
                if (m.Equals("3"))
                {
                    s.Remove(m);//会抛错

                }
                Console.WriteLine(m);
            }*/

            Console.Read();
        }
    }
}
