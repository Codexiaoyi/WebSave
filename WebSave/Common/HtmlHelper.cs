using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebSave
{
    public class HtmlHelper
    {
        public async static Task<string> GetHtmlAsString(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();//错误的话抛出异常
            return await response.Content.ReadAsStringAsync();//字符串形式返回Html
        }

        public async static Task<Stream> GetHtmlAsStream(string url)
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();//错误的话抛出异常
            return await response.Content.ReadAsStreamAsync();//字符串形式返回Html
        }
    }
}
