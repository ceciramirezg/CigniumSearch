using Cigninum.Search.Cross.Core.Constant;
using Cigninum.Search.Distribution.Core.Contract;
using Cigninum.Search.Distribution.Core.Model;
using Cigninum.Search.Distribution.Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cigninum.Search.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new[] { ".net", "java", "python", "C#", "“java script”" };
           
            if (args.Length >= 1)
            {
                Console.WriteLine("Searching....\n");

                var result = SearchAsync(args.ToList(), ConstantData.SectionConfig.SectionGroup).Result;

                foreach (var item in result.SearchLanguageList)
                {
                    Console.WriteLine("{0}: {1}: {2}", item.Text, item.Searcher, item.Total);
                }

                Console.Write("\n");
                foreach (var item in result.WinnerList)
                {
                    Console.WriteLine("{0} winner: {1}", item.SearcherName, item.Text);
                }

                Console.Write("\n");
                Console.WriteLine("Total winner: {0}", result.WinnerMax.Text);
            }
            else
            {
                Console.Write("You have not entered texts to search.");
            }

            Console.ReadKey();
        }

        private static async Task<SearcherModel> SearchAsync(List<string> textList, string sectionGroupName)
        {
            ISearchResult search = new SearchResult();
            return await search.SearchLanguage(textList, sectionGroupName);          
        }
    }
}
