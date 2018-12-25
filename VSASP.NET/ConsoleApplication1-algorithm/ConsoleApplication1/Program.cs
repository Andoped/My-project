using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;



namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            TestReadingFile();
            Console.Read();
        }
        //    static void TestReadingFile()
        //    {
        //        //var memoryBefore = GC.GetTotalMemory(true);
        //        StreamReader sr;
        //        try
        //        {
        //            sr = File.OpenText("I:\\Web\\算法\\ConsoleApplication1\\tempFile.txt");
        //        }
        //        catch (FileNotFoundException)
        //        {
        //            Console.WriteLine("这个例子需要一个txt的文件。");
        //            return;
        //        }
        //        var fileContents = new List<string>();
        //        while (!sr.EndOfStream)
        //        {

        //            fileContents.Add(sr.ReadLine());
        //        }
        //        //var stringsFound =
        //        //    from line in fileContents
        //        //    where line.Contains("人工智能")
        //        //    select line;
        //       
   


              

        //        sr.Close();
        //        //Console.WriteLine("数量:"+stringsFound.Count());

        //        //var memoryAfter = GC.GetTotalMemory(false);
        //        //Console.WriteLine("不使用Iterator的内存用量=\t"+string.Format(((memoryAfter-memoryBefore)/1000).ToString(),"n")+"kb");
        //    }

        //}


        static void TestReadingFile()
        {
            var memoryBefore = GC.GetTotalMemory(true);
            StreamReader sr;
            try
            {
                sr = File.OpenText("I:\\Web\\算法\\ConsoleApplication1\\tempFile.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(@"这个例子需要一个名为 tempFile.txt 的文件。");
                return;
            }
            var result = new List<string>();

            // C#中substring ()的用法
            //String.SubString(int   index, int   length)
            //index: 开始位置，从0开始
            //length:你要取的子字符串的长度

            //String.Format (String, Object, Object) 将指定的 String 中的格式项替换为两个指定的 Object 实例的值的文本等效项。 
            //这是定义一个正则表达式 {0}从第0次开始     []任意字符    ^ 匹配输入字符串的开始位置   { 1 }至少匹配一次  *匹配前面的零次或多次的子表达式
            //Substring取人工智能中的 人字
            Regex regex = new Regex(string.Format("{0}[^{1}]*", "人工智能", "人工智能".Substring(0, 1)));
            string lineString = "";
            int lineIndex = 0;
            //意思是在流的开始位置（SeekOrigin.Begin）偏移零位。定位文本读取的位置
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            //定义循环读取文本中的每一句  如果为null和""返回true这里判断为false才可以  并存储到一个空字符
            while (!string.IsNullOrEmpty((lineString = sr.ReadLine())))
            {
                //这里是自增记录第几句
                lineIndex++;
                //这里是初始化第几个字
                int searchIndex = 0;
                //Matches在指定的输入字符串中搜索正则表达式的所有匹配项。并传给item
                foreach (var item in regex.Matches(lineString))
                {
                    //存储一句字符串
                    var regexResult = item.ToString();
                    //IndexOf(string,a)查找字串中指定字符或字串首次出现的位置,返首索引值，||string要查找的语句||a从第几个元素开始查找
                    searchIndex = lineString.IndexOf("人工智能", searchIndex) + 1;
                    result.Add(regexResult);
                    var Mystr = "";
                    //try
                    //{
                    //Substring提取字符串中的第i个字符开始的长度为j的字符串；
                    Mystr = regexResult.Substring(0, 4);
                    //}
                    //catch (Exception)
                    //{

                    //   
                    //}
                     
                    Console.WriteLine("第" + lineIndex + "行，第" + searchIndex + "个字母开始：" + Mystr+".........");

                }
            }
        }
    }
    //class Program()
    //{
    //    const string filePath = @"Users/lzzy/Desktop/算法/DAA01.TeachingMaterials/tempFile.txt";
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("测试本文路径：" + filePath);
    //        Console.Write("请输入搜索关键字：");
    //        var keyString = Console.ReadLine();
    //        TestReadingFile(keyString);
    //        Console.WriteLine("---");
    //        Console.ReadKey();

    //    }
    //    static void TestReadingFile(string key)
    //    {
    //        var memoryBefore = GC.GetTotalMemory(true);
    //        StreamReader sr;
    //try 
    //{ 
    //     sr = File.OpenText(filePath);
    //}
    //catch (Exception) 
    //{ 
    //    Console.WriteLine(@"这个例例⼦子需要⼀一个名为 C:\temp\tempFile.txt 的 ⽂文件。");
    //    return; 
    //}

    //定义一个泛型数组数组
    //        var result = new List<string>();
    //读取指定txt文件
    //        var doc = sr.ReadToEnd();
    //正则表达式RegEx
    //        Regex regex = new Regex(string.Format("{0}[^。]*", key));
    //        Console.WriteLine("--------------------------");
    //        Console.WriteLine(string.Format("“{0}”搜索结果：", key));
    //        Console.WriteLine("--------------------------");
    //Matches用来检查字符串是否与指定的表达式匹配
    //        foreach (var item in regex.Matches(doc))
    //        {
    //            var regexResult = item.ToString();
    //            result.Add(regexResult);
    //            Console.WriteLine(regexResult);
    //        }
    //    }













    //static void TestReadingFile(string key)
    //{
    //    if (string.IsNullOrEmpty(key.Trim()))
    //    {
    //        Console.WriteLine("关键字输入不正确！");
    //        return;
    //    }
    //    var memoryBefore = GC.GetTotalMemory(true);
    //    StreamReader sr;
    //    try { sr = File.OpenText(filePath); }
    //    catch (Exception) { Console.WriteLine(@"这个例例⼦子需要⼀一个名为 C:\temp\tempFile.txt 的 ⽂文件。"); return; }


    //    var result = new List<string>();
    //    string errorChar = "。！";
    //    Regex regex = new Regex(string.Format("{0}[^{1}]*", key, key.Substring(0, 1) + errorChar));
    //    Console.WriteLine("--------------------------");
    //    Console.WriteLine(string.Format("“{0}”已找到{1}个结果：", key, regex.Matches(sr.ReadToEnd()).Count));
    //    Console.WriteLine("--------------------------");
    //    string lineString = "";
    //    int lineIndex = 0;
    //    sr.BaseStream.Seek(0, SeekOrigin.Begin);
    //    while (!string.IsNullOrEmpty((lineString = sr.ReadLine())))
    //    {
    //        lineIndex++;
    //        int searchIndex = 0;
    //        foreach (var item in regex.Matches(lineString))
    //        {
    //            var regexResult = item.ToString();
    //            searchIndex = lineString.IndexOf(key, searchIndex) + 1;
    //            result.Add(regexResult);
    //            Console.WriteLine("第" + lineIndex + "行，第" + searchIndex + "个字母开始：" + regexResult);
    //        }
    //    }
    //}





}
