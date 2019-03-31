using Cigninum.Search.Cross.Core.Constant;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace Cigninum.Search.Cross.Core.Configuration
{
    public static class ConfigFile
    {
        public static T GetConfigurationSectionGroup<T>(this string name)
        {
            var searcher = ConfigurationManager.GetSection(string.Concat(ConstantData.SectionConfig.SectionGroup, "/", name)) as NameValueCollection;
            var objGeneric = typeof(T);
            var dynamicObject = Activator.CreateInstance(objGeneric);

            try
            {
                foreach (var key in searcher.AllKeys)
                {                   
                    PropertyInfo pi = objGeneric.GetProperty(key, BindingFlags.Public | BindingFlags.Instance);
                    if (pi != null)
                    {
                        pi.SetValue(dynamicObject, searcher[key], null);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Method GetConfigurationSectionGroup", ex);
                Console.ReadKey();
            }          

            return (T)dynamicObject;
        }
        public static List<string> GetSectionItems(this string sectionName)
        {
            var sectionList = new List<string>();         

            Uri UriAssemblyFolder = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase));
            string appPath = UriAssemblyFolder.LocalPath;
           
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(string.Concat(appPath, @"\Cigninum.Search.Presentation.Console.exe"));

            var sections = config.GetSectionGroup(sectionName).Sections;

            foreach (var key in sections.Keys)
            {
                sectionList.Add(key.ToString());
            }         

            return sectionList;
        }

    }
}
