using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management;

namespace ConsoleApplication1
{
    //class 'b' from original .exe
    class compinfo
    {
        public static string g()
        {
            return Environment.ExpandEnvironmentVariables("%SystemDrive%")[0].ToString();
        }

        public static string f()
        {
            string str = "";
            try
            {
                foreach (ManagementObject instance in new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances())
                {
                    if ((bool)instance["IPEnabled"])
                    {
                        str = instance["MacAddress"].ToString();
                        instance.Dispose();
                        break;
                    }
                }
            }
            catch (Exception ex) { }
            return str;
        }

        public static string e()
        {
            string str = "";
            try
            {
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = new ManagementClass("Win32_Processor").GetInstances().GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        ManagementObject current = (ManagementObject)enumerator.Current;
                        str = current.Properties["ProcessorId"].Value.ToString();
                        current.Dispose();
                    }
                }
            }
            catch (Exception ex) { }
            return str;
        }

        public static string a(string A_0)
        {
            string str = "";
            try
            {
                ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.DeviceId=\"" + A_0 + ":\"");
                managementObject.Get();
                string index = "VolumeSerialNumber";
                str = managementObject[index].ToString();
            }
            catch (Exception ex) { }
            return str;
        }

        public static string d()
        {
            return Path.GetDirectoryName(Path.GetFullPath(Environment.GetCommandLineArgs()[0]));
        }

        public static string c()
        {
            return Path.GetPathRoot(Path.GetFullPath(Environment.GetCommandLineArgs()[0]))[0].ToString();
        }

        public static string b()
        {
            return compinfo.a(compinfo.g());
        }

        public static string a()
        {
            return compinfo.a(compinfo.c());
        }


        //Unscrambled method f.a from original source code
        internal static byte[] GetCompInfo()
        {
            string str1 = compinfo.b();
            string str2 = compinfo.f();
            string str3 = compinfo.e();
            return new UTF8Encoding().GetBytes(str1 + str2 + str3);
        }
    }
}