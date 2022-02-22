using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace ProgrammingTasks
{
    public class HackerRank
    {
        private static async Task<List<User>> GetUsersByApi()
        {
            var users = new List<User>();
            
            using (var client = new HttpClient())
            {
                try
                {
                    var totalPage = 1;

                    for (int i = 1; i <= totalPage; i++)
                    {
                        var url = @$"https://jsonmock.hackerrank.com/api/article_users?page={i}";

                        var response = await client.GetAsync(url);

                        if (!response.IsSuccessStatusCode)
                        {
                            return null;
                        }

                        var jsonString = await response.Content.ReadAsStringAsync();

                        var content = JsonSerializer.Deserialize<PagedResult>(jsonString);

                        totalPage = content.total_pages;
                        users.AddRange(content.data);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return users;
            }
        }
        
        public static async Task<List<string>> getUsernames(int threshold)
        {
            var users = await GetUsersByApi();
            
            var result = users
                .Where(k => k.submission_count > threshold)
                .Select(x => x.username).ToList();

            return result;
        }
    }

    public class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string about { get; set; }
        public int submitted { get; set; }
        public int submission_count { get; set; }
        public int coment_count { get; set; }
        public int created_at { get; set; }

        //var test = DateTime.Parse(content.data[0].updated_at);
        public string updated_at { get; set; }
    }

    public class PagedResult
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<User> data { get; set; }
    }
}