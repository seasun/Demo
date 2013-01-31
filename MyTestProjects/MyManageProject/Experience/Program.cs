using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Experience
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(p_PropertyChanged);
            p.Name = "seasun";
            p.Name = "seasunK";
            Console.WriteLine(GetCHZNLength("我?a"));
            Console.Read();
        }

        static void p_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine("名稱已修改為{0}", ((Person)sender).Name);
        }

        public static int GetCHZNLength(string inputData)
        {
            byte[] bytes = new ASCIIEncoding().GetBytes(inputData);
            int num = 0;
            for (int i = 0; i <= (bytes.Length - 1); i++)
            {
                if (bytes[i] == 63)//这个判断是否中文不是很准。因为?的ASCII码也是63
                {
                    num++;
                }
                num++;
            }
            return num;
        }

    }
}
