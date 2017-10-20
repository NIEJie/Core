using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

//注意！！！！namespace是分节的，这个在core.pubclass下面的
//命名空间不能和类名重复
namespace Core.PubClass
{
    public class ChangeType
    {
        //https://www.douban.com/note/217745732/
        //http://blog.163.com/tianjunqiang666@126/blog/static/872591192012101511303449/  ::
        //数据转换的误区：：：不是转换成流，而是分两种：string和T；T代表除string以外的所有基础类型+复杂泛型+其他类型

        //!!!!开源序列化库很重要！！可以在github上找到很多著名的开源库，比如google的probuf，以及微软的bond
        //记得学些二进制的序列化和反序列化方法 http://www.cnblogs.com/windsinger77/p/3834287.html
        //现在先用公司自己的吧 Genersoft.Platform.Core.Common 竟然可以全部反编译出啦！！！！记得学习一下，顺便放在自己的代码里

        //别的类型数据转换成string
        public string changeTToStr<T>(T tData)
        {

            MemoryStream strm = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(strm, tData);
            strm.Position = 0;
            byte[] buffer = new byte[strm.Length];
            //StreamReader reader = new StreamReader(strm, Encoding.GetEncoding("gb2312"));//用指定的编码方式
            //string result = reader.ReadToEnd();
            strm.Write(buffer, 0, buffer.Length);
            strm.Flush();
            strm.Close();
            string strData = Convert.ToBase64String(buffer);

            return strData;
        }


        //http://www.cnblogs.com/GS-Crazy/archive/2013/12/16/3476733.html
        //string转换成别的类型
        public T changeStrToT<T>(string strData)
        {
            //SoapFormatter formatter = new SoapFormatter();
            BinaryFormatter formatter = new BinaryFormatter();

            byte[] array = Encoding.Unicode.GetBytes(strData);
            MemoryStream strm = new MemoryStream(array);
            //strm.Position = 0;
            //strm.ReadTimeout = 200000;
            //strm.Read(array, 0, array.Length);
            //strm.Flush();
            //strm.Close();
            T tData = (T)formatter.Deserialize(strm);
            
            return tData;
        }
    }
}
