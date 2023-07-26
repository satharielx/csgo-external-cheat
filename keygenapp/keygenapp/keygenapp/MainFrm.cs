using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
using System.Management;


namespace keygenapp
{
    public partial class MainFrm : Form
    {
        User currentUser;
        LoginFrm instance;
        public MainFrm(User current, LoginFrm instance)
        {
            InitializeComponent();
            current = currentUser;
            this.instance = instance;
        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {
            User @new = new User(existinguser.Text, ipadr.Text);
            string temp = @new.ChangeKey();
            respkey.Text = temp.Substring(temp.IndexOf("Key: ") + "Key: ".Length + 1);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            User @new = new User(user.Text, ipadr.Text);
            string temp = @new.ChangeKey();
            key.Text = temp.Substring(temp.IndexOf("Key: ") + "Key: ".Length + 1);
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            instance.Close();
        }
    }

    public class User
    {
        private static Component[] PCSpecs = HardwareEngine.GetPCComponents();
        protected static string componentHash = PCSpecs.ToHWIDHash(true);
        private string username, key, ipaddr;
        public User(string username, string ipaddr, string key="")
        {
            this.username = username;
            this.key = key;
            this.ipaddr = ipaddr;
        }

        public bool Verify(bool useHttps = true)
        {
            Dictionary<string, string> @params = new Dictionary<string, string>();
            #region Assigning parameters
            @params.Add("cmd", "check");
            @params.Add("u", username);
            @params.Add("k", key);
            @params.Add("ipAddr", ipaddr);
            @params.Add("privilege", componentHash);
            #endregion
            string uri = "http://wickedempress.site/init.php".ToValidUri(@params);
            //Program.Print($"[DEBUG] Connecting to {uri} ...");
            string response = Engine.SendGetAsyncRequest(uri);
            Thread.Sleep(1000);
            //Program.Print($"[DEBUG] Connected to {uri} ...");
            MessageBox.Show($"[DEBUG] Response from {uri} ... \n Response: {response}", "Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            return response.Contains("Valid");
        }
        public string ChangeKey(bool useHttps = true)
        {
            Dictionary<string, string> @params = new Dictionary<string, string>();
            #region Assigning parameters
            @params.Add("cmd", "generateForNewUser");
            @params.Add("u", username);
            @params.Add("k", key);
            @params.Add("privilege", componentHash);
            #endregion
            string uri = "http://wickedempress.site/init.php".ToValidUri(@params);
            //Program.Print($"[DEBUG] Connecting to {uri} ...");
            string response = Engine.SendGetAsyncRequest(uri);
            Thread.Sleep(1000);
            MessageBox.Show($"[DEBUG] Connected to {uri} ... \n Response: {response}", "Error!", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            //Program.Print($"[DEBUG] Response from {uri} ... \n Response: {response}");
            return response;
        }
    }

    public static class HardwareEngine
    {

        public static Component[] GetPCComponents()
        {
            Component[] allComponents = new Component[] { };
            allComponents.AddNew(GetCpuInformation());
            allComponents.AddNew(GetGPUInformation());
            allComponents.AddNew(GetMotherboardInformation());
            return allComponents;
        }
        private static string identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                if (mo[wmiMustBeTrue].ToString() == "True")
                {
                    if (result == "")
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return result;
        }

        public static string GetIdentifier(string @class, string property)
        {
            string result = "";
            System.Management.ManagementClass mClass = new System.Management.ManagementClass(@class);
            System.Management.ManagementObjectCollection objectCollection = mClass.GetInstances();
            foreach (System.Management.ManagementObject mo in objectCollection)
            {
                if (result == "")
                {
                    try
                    {
                        result = mo[property].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        public static Component GetCpuInformation()
        {
            string retVal = GetIdentifier("Win32_Processor", "UniqueId");
            Component cpu;
            if (retVal == "")
            {
                retVal = GetIdentifier("Win32_Processor", "ProcessorId");
                if (retVal == "") //If no ProcessorId, use Name
                {
                    retVal = GetIdentifier("Win32_Processor", "Name");
                    if (retVal == "") //If no Name, use Manufacturer
                    {
                        retVal = GetIdentifier("Win32_Processor", "Manufacturer");
                    }
                    //Add clock speed for extra security
                    retVal += GetIdentifier("Win32_Processor", "MaxClockSpeed");
                    cpu = new Component(GetIdentifier("Win32_Processor", "Name"), retVal);
                }
            }
            return new Component(GetIdentifier("Win32_Processor", "Name"), retVal);
        }
        public static Component GetGPUInformation()
        {
            string id = GetIdentifier("Win32_VideoController", "DriverVersion") + GetIdentifier("Win32_VideoController", "Name");
            return new Component(GetIdentifier("Win32_VideoController", "Name"), id);
        }

        public static Component GetMotherboardInformation()
        {
            string id = GetIdentifier("Win32_BaseBoard", "Model")
            + GetIdentifier("Win32_BaseBoard", "Manufacturer")
            + GetIdentifier("Win32_BaseBoard", "Name")
            + GetIdentifier("Win32_BaseBoard", "SerialNumber");
            return new Component(GetIdentifier("Win32_BaseBoard", "Name"), id);
        }

        public static string GetMACInformation()
        {
            string id = identifier("Win32_NetworkAdapterConfiguration",
                "MACAddress", "IPEnabled");
            return id;
        }
    }

    public class Component
    {
        public string Name { get; private set; }
        public string Serial { get; private set; }
        public Component(string name, string serial)
        {
            Name = name.Length > 0 ? name : "";
            Serial = serial;
        }
    }

    public static class Engine
    {
        public static string SendGetAsyncRequest(string uri)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            using (Stream s = response.GetResponseStream())
            using (StreamReader r = new StreamReader(s))
            {
                return r.ReadToEnd();
            }
        }

        public static string ToValidUri(this string uri, Dictionary<string, string> paramaters)
        {
            string result = "";
            result += uri;
            string parameters = paramaters.ToParameterString();
            result += parameters;

            return result;
        }
        public static string ToParameterString(this Dictionary<string, string> parameters)
        {
            string result = "";
            int idx = -1;
            foreach (var param in parameters)
            {
                idx++;
                if (idx == 0)
                {
                    result += "?";
                    result += Regex.Escape(param.Key);
                    result += $"={HttpUtility.UrlEncode(Regex.Escape(param.Value))}";
                }
                else
                {
                    result += "&";
                    result += Regex.Escape(param.Key);
                    result += $"={HttpUtility.UrlEncode(Regex.Escape(param.Value))}";
                }
            }
            return result;
        }

        public static string ToHWIDHash(this Component[] pcspecs, bool includeMac = false)
        {
            string totalSerial = "";
            if (includeMac)
            {
                string macId = HardwareEngine.GetMACInformation();
                foreach (Component c in pcspecs)
                {
                    totalSerial += c.Serial;
                }
                totalSerial += macId;
                using (SHA256 hashEngine = SHA256Managed.Create())
                {
                    totalSerial = string.Concat(hashEngine.ComputeHash(Encoding.UTF8.GetBytes(totalSerial)).Select((item) => item.ToString("x2"))).ToUpper();
                }
            }
            else
            {
                foreach (Component c in pcspecs)
                {

                    totalSerial += c.Serial;

                    using (SHA256 hashEngine = SHA256Managed.Create())
                    {
                        totalSerial = string.Concat(hashEngine.ComputeHash(Encoding.UTF8.GetBytes(totalSerial)).Select((item) => item.ToString("x2"))).ToUpper();
                    }
                }
            }
            return totalSerial;
        }
        public static void AddNew(this Component[] componentArray, Component theDesiredComponent)
        {
            Array.Resize(ref componentArray, componentArray.Length + 1);
            componentArray[componentArray.Length - 1] = theDesiredComponent;
        }
    }
}
