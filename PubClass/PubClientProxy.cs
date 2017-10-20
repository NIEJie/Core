using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Web.Services.Description;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using Genersoft.Platform.Core.Common;

namespace Core.PubClass
{
    public class PubClientProxy
    {

        /*调试webservice步骤：动态和静态的都是这样
         * 1. 你要知道VS上的IIS只能用来浏览，不能用来附加进程（原因未知，猜测是不能自己附加自己） -- http://bbs.csdn.net/topics/391545570
         * 2. 注意！！！！不需要在IIS上发布，VS自带的IIS Express就可以了，只需要把Webservice设置为启动项，直接使用F11就可以断点到后台了（注意web.config需要改为debug模式，你调到断点的时候，会提示你是否改为debug模式，你选择是就可以了）
         * 
         * */

        private ChangeType changeType = new ChangeType();
        private static string assemblyName = @"Core.WebService";//这个地方好像不是为了取数，而是为了定义一个命名空间？！

        //https://zhidao.baidu.com/question/148925883.html
        //https://zhidao.baidu.com/question/587801059.html
        //http://www.cnblogs.com/muou/archive/2009/07/08/1518971.html
        //http://bbs.csdn.net/topics/390332011
        //https://zhidao.baidu.com/question/1494248641890170939.html

        //http://blog.csdn.net/lyncai/article/details/8621880  这个最全
        //动态调用Webservice http://www.cnblogs.com/atree/p/WebService_dynamic.html
        //http://blog.csdn.net/huanglan513/article/details/46930393

        #region 第一种方法：手动添加引用
        //assemblyName : LRSystemClient  ：：程序集的名字，由于是在Client有引用，所以直接写Client的名字（DLL名）
        //className    : LRSystemClient.QAWebService.QAWebServiceSoapClient （Class的名字）
        //method       : 方法名
        //parameters   : 参数数组
        //public T PubClientProxyClient<T>(string className, string method, string[] parameters)
        //{
        //    Assembly assembly = Assembly.Load(assemblyName);
        //    //Type type = Type.GetType(className);
        //    Type type = assembly.GetType(className,true,true);
        //    MethodInfo mm = type.GetMethod(method);
        //    object obj = mm.Invoke(className, parameters);
        //    string str = obj.ToString();
        //    T t = changeType.changeStrToT<T>(str);
        //    return t;
        //}

        //public string PubClientProxyClient(string className, string method, string[] parameters)
        //{
        //    Assembly assembly = Assembly.Load(assemblyName);
        //    //Type type = Type.GetType(className);
        //    Type type = assembly.GetType(className);
        //    MethodInfo mm = type.GetMethod(method);
        //    object obj = mm.Invoke(className, parameters);
        //    string str = obj.ToString();
        //    return str;
        //}
        #endregion

        #region 动态引用
        public T PubClientProxyClient<T>(string url, string method, string[] parameters)
        {
            object obj = InvokeWebService(url, method, parameters);
            string str = Convert.ToString(obj);
            //T t = changeType.changeStrToT<T>(str);
            T t = Serializer.ProtobufDeSerialize<T>(str);
            return t;
        }

        public string PubClientProxyClient(string url, string method, string[] parameters)
        {
            object obj = InvokeWebService(url, method, parameters);
            string str = Convert.ToString(obj);
            return str;
        }


        
        /// <summary>
        /// 实例化WebServices
        /// </summary>
        /// <param name="url">WebServices地址</param>
        /// <param name="methodname">调用的方法</param>
        /// <param name="args">把webservices里需要的参数按顺序放到这个object[]里</param>
        public static object InvokeWebService(string url, string methodname, object[] args)
        {

            //这里的namespace是需引用的webservices的命名空间，我没有改过，也可以使用。也可以加一个参数从外面传进来。
            //string @namespace = "client";
            string @namespace = assemblyName;
            try
            {
                //获取WSDL
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url + "?WSDL");
                ServiceDescription sd = ServiceDescription.Read(stream);
                string classname = sd.Services[0].Name;
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(@namespace);

                //生成客户端代理类代码
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                CSharpCodeProvider csc = new CSharpCodeProvider();
                //ICodeCompiler icc = csc.CreateCompiler();

                //设定编译参数
                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.GenerateInMemory = true;
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");

                //编译代理类
                CompilerResults cr = csc.CompileAssemblyFromDom(cplist, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    foreach (System.CodeDom.Compiler.CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }

                //生成代理实例，并调用方法
                System.Reflection.Assembly assembly = cr.CompiledAssembly;
                Type t = assembly.GetType(@namespace + "." + classname, true, true);
                object obj = Activator.CreateInstance(t);
                System.Reflection.MethodInfo mi = t.GetMethod(methodname);

                return mi.Invoke(obj, args);
            }
            catch(Exception ex)
            {
                throw ex.InnerException;//throw ex.InnerException; 看到的是原始异常
                //return null;
            }
        }

    #endregion
    }
}
