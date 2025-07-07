using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace WebPlupload.Sevices
{
    public class Edoc
    {
        private static string Token { get; set; }
        public Edoc()
        {
            
           
        }
        public  string creatEdoc(string f,string t)
        {
            var file = f;

            Token = t;

            //var ResultToken = GetApiToken(file).GetAwaiter().GetResult();


            //Token = ResultToken;


            var reg = RegisteredEDoc(file, Token);

            //Console.WriteLine($"RegisteredEDoc {file} result {reg} on thread: {Environment.CurrentManagedThreadId}");

            //var Sign = SigningOrg(file, Token).GetAwaiter().GetResult();

            //Console.WriteLine($"SigningOrg {file} result {Sign} on thread: {Environment.CurrentManagedThreadId}");

            //Console.WriteLine($"creatEdoc {file} started on thread: {Environment.CurrentManagedThreadId}");

            // return Task.FromResult($"return createEdoc");


            //var res1 = await RegisteredEDoc(file);

            //var res2 = await SigningOrg(file);

            //Console.WriteLine($"creatEdoc {file} started on thread: {Environment.CurrentManagedThreadId}");


            return "return createEdoc";


        }

        public Task<string> RegisteredEDoc(string f,string t)
        {
            var file = f;

            Console.WriteLine($"RegisteredEDoc {file} Token {t} started on thread: {Environment.CurrentManagedThreadId}");
            //Console.WriteLine($"RegisteredEDoc {file}{Token}");
            // Console.WriteLine($"RegisteredEDoc-{T} thread:{Environment.CurrentManagedThreadId}");
            //if (T == "juristicfile2")
            //{
            //    throw new Exception("methot2 juristicfile2 fail");
            //}
             return Task.FromResult($"return RegisteredEDoc {file}");
           // return "return RegisteredEDoc";

        }


        public Task<string> SigningOrg(string f,string t)
        {
            var file = f;

            Console.WriteLine($"SigningOrg {file} token {t} started on thread: {Environment.CurrentManagedThreadId}");
           // Console.WriteLine($"SigningOrg {Token}");

            //Console.WriteLine($"SigningOrg-{T} thread:{Environment.CurrentManagedThreadId}");

            return Task.FromResult($"return SigningOrg {file}");

        }



        //public   Task<string> GetApiToken(string f ,string AgentId = "dgaAgent")
        //{
        //    var file = f;
        //    var result = string.Empty;

        //    try
        //    {
        //        var SecretKey = "x1VQ9Jl7W0H";
        //        var ConsumerKey = "6df7d876-3b30-4786-bb12-455446291b8f";
                
        //        var client = new RestClient("https://api.egov.go.th");
        //        var request = new RestRequest("/ws/auth/validate?ConsumerSecret=" + SecretKey + "&AgentID=" + AgentId, Method.Get);
        //        request.AddHeader("Consumer-Key", ConsumerKey);
        //        var response =  client.ExecuteAsync(request).GetAwaiter().GetResult();

        //        if (response.StatusCode == HttpStatusCode.OK && response.Content.Contains("Result"))
        //        {
        //            var obj = JObject.Parse(response.Content);
        //            result = obj["Result"].ToString();
        //            // return obj["Result"].ToString();

        //        } 
        //        else
        //        {
                   
        //        }
        //    }
        //    catch (Exception ex)
        //    {
           
        //    }
        //   // Console.WriteLine($"GetApiToken {file} Token {result} started on thread: {Environment.CurrentManagedThreadId}");
        //    //return result;
        //    return Task.FromResult(result);
        //}

    }
}
