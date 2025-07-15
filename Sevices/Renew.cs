using Newtonsoft.Json.Linq;
using RestSharp;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebPlupload.Models;
using Newtonsoft.Json;
using EGov.Platform.Net.Abstractions;
using System.Net;
using System.Threading;
namespace WebPlupload.Sevices
{
    public class Renew
    {
        private readonly Edoc _edoc;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;
        private readonly IApiClient _api;
        public Renew(Edoc edoc, IWebHostEnvironment env,IConfiguration config, IApiClient api)
        {
            _edoc = edoc;
            _env = env;
            _config = config;
            _api = api;
        }

       
        public async void RunTask()
        {


            //Delay(TimeSpan.FromSeconds(1));
            //await Task.Delay(TimeSpan.FromSeconds(1));
            //await Task.Run(() =>
            //     {

            //         Console.WriteLine("start task");
            //         // return "";
            //     }
            // );

            var tasks = new List<Task<string>>();

            var result1 = Task.Run(() => AsyncMethod("juristic1.jsonl"));
            var result2 = Task.Run(() => AsyncMethod("juristic2.jsonl"));
            //var result3 = Task.Run(() => AsyncMethod("juristicfile3"));

            tasks.Add(result1);
            tasks.Add(result2);

            var combinedResults = await Task.WhenAll(tasks);
            //var combinedResults = await Task.WhenAll(result1, result2, result3);
            var result = combinedResults.Select(cr => cr);
            foreach (var r in result)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine($"RunTask end on thread: {Environment.CurrentManagedThreadId}");



            //Console.WriteLine("After delay time 5 secconds");
        }

        public async Task<string> AsyncMethod(string f)
        {
            var status = string.Empty;
            var file = f;
            var token = string.Empty;
            List<SMEJuristic> result = new List<SMEJuristic>();
            try
            {
                var resLoadfile = await LoadData(f);
                // result = resLoadfile;


                var res1 =  await GetDBDProfile(resLoadfile,f);

                var res2 = await DBDfinance(resLoadfile, f);

                // Console.WriteLine($"DBDfinance  {file}  result {res1} on thread: {Environment.CurrentManagedThreadId}");

                //var ResultToken = await GetApiToken(file);

                //var ResultToken = await ResultToken;

                //token = ResultToken;

                // var res2 = await _edoc.RegisteredEDoc(file,token);
                // var res3 = await _edoc.SigningOrg(file, token);

                // var res4 = await SaveToSme(file);


                // Console.WriteLine($"SaveToSme  {file}  result {res3} on thread: {Environment.CurrentManagedThreadId}");

                // Console.WriteLine($"AsyncMethod end {file} on thread: {Environment.CurrentManagedThreadId}");

                status = $"{file} success";

            }
            catch(Exception ex)
            {
                status = $"{file} fail";
            }


             return Task.FromResult(status).Result;
           // return status;

            // return new TaskReult{ status ="sucess" ,code =1};
        }


        public Task<string> DBDfinance(List<SMEJuristic> juristics,string f)
        {
            var file = f;
            int Count = 0;
            foreach (var j in juristics.Take(5))
            {
                
                int Total = juristics.Count();


                Dictionary<string, object> dic = new();
                var currentYear = DateTimeOffset.UtcNow.Year + 543;
                for (int i = 1; i <= 4; i++)
                {
                    string year = (currentYear).ToString();

                    try
                    {
                        string dbdUrl = _config["EGovPlatform:DBDFinancialUrl"];
                        IRestRequest req = _api.Create(dbdUrl)
                            .AddQueryParameter("JuristicID", j.Id)
                            .AddQueryParameter("Year", string.IsNullOrEmpty(year) ?
                                (DateTimeOffset.UtcNow.Year + 543).ToString() : year);
                        var res = _api.Get(req);
                        if (res.StatusCode == HttpStatusCode.OK)
                        {
                            DBDFinancialResponse content = JsonConvert.DeserializeObject<DBDFinancialResponse>(res.Content);
                            var finance = content.GetDBDFinancial();

                            dic.Add(year, finance.TotalRevenue);
                        }
                        else
                        {
                            dic.Add(year, null);
                        }
                        

                    }
                    catch(Exception ex)
                    {
                        dic.Add(year, null);
                    }

                    currentYear = currentYear - 1;
                }
                var resdic = dic;



                Count++;

                Console.WriteLine($"DBDfinance {file}  {j.Id} {resdic.ElementAt(0).Key}:{resdic.GetValueOrDefault(resdic.ElementAt(0).Key)} {resdic.ElementAt(1).Key}:{resdic.GetValueOrDefault(resdic.ElementAt(1).Key)} {resdic.ElementAt(2).Key}:{resdic.GetValueOrDefault(resdic.ElementAt(2).Key)}  {resdic.ElementAt(3).Key}:{resdic.GetValueOrDefault(resdic.ElementAt(3).Key)}" + " - " + Count + "/" + Total);


            }

            

            //Console.WriteLine($"DBDfinance {file} started on thread: {Environment.CurrentManagedThreadId}");
            return Task.FromResult($"return DBDfinance {file}");


            //return Task.FromResult($"return RegisteredEDoc {file}").Result;
        }


        public Task<List<SMEJuristic>> LoadData(string fileName)
        {
            Console.WriteLine("start Import data from file " + fileName);
            var MyPath = Path.Combine(_env.WebRootPath, "file", fileName);

            string juristicjson = File.ReadAllText(MyPath);

            var lsjuristics = new List<SMEJuristic>();
            int count = 0;

            foreach (var line in juristicjson.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    string str = line;
                    // str = str.Replace(":NaN", ":null");
                    //Data = BsonDocument.Parse(data.ToString()),
                    var smej = System.Text.Json.JsonSerializer.Deserialize<SMEJuristic>(str, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals });

                    //if (smej.Id == "0245534000382")
                    //{
                    //    var result = smej;
                    //}
                    //if (smej.Profile.Financial != null)
                    //{
                    //    if (smej.Profile.Financial.Count > 0)
                    //    {
                    //        fff = smej.Profile.Financial.FirstOrDefault().Value;
                    //    }

                    //}

                   // Console.WriteLine(smej.Id);
                    lsjuristics.Add(smej);
                    count++;
                }
                catch (Exception ex)
                {
                   // Console.WriteLine(line);
                }


            }

            Console.WriteLine("End Import data from" + fileName +"- Good data -"+lsjuristics.Count());
            return Task.FromResult(lsjuristics);
        }

        //public Task<string> SaveToSme(string f)
        //{
        //    var file = f;
        //    //Thread.Sleep(3000);
        //    Console.WriteLine($"SaveToSme {file} started on thread: {Environment.CurrentManagedThreadId}");

        //    //await Task.Delay(TimeSpan.FromSeconds(1));

        //    //return "return DBDfinance";

        //    return Task.FromResult($"return SaveToSme {file}");
        //}

        public Task<string> GetDBDProfile(List<SMEJuristic> juristics,string file)
        {
            string filename = file;
            int Count = 0;
            int Total = juristics.Count();
            foreach (var j in juristics.Take(5))
            {
                try
                {
                    var dbdUrl = _config["EGovPlatform:DBDProfileUrlV7"];
                    var req = _api.Create(dbdUrl, AgentID: "SME").AddJsonBody(new { OrganizationJuristicID = j.Id }); ;
                    var res = _api.Post<DBDProfileResponseV7>(req);
                    var result = res.status.code;
                    var data = res.data;
                    var juristicProfileV7Data = JsonConvert.DeserializeObject<DBDProfileV7Juristic>(JsonConvert.SerializeObject(data));
                    Count++;
                    Console.WriteLine("DBDProfile " + filename+" - "+juristicProfileV7Data.JuristicPerson.JuristicID +" - "+ juristicProfileV7Data.JuristicPerson.JuristicNameTH+" - "+Count+"/"+ Total);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                
                //return juristicProfileV7Data;
            }


            return Task.FromResult("");
           
        }


        public  Task<string> GetApiToken(string f, string AgentId = "dgaAgent")
        {
            var file = f;
            var result = string.Empty;

            try
            {
                var SecretKey = "x1VQ9Jl7W0H";
                var ConsumerKey = "6df7d876-3b30-4786-bb12-455446291b8f";

                var client = new RestClient("https://api.egov.go.th");
                var request = new RestRequest("/ws/auth/validate?ConsumerSecret=" + SecretKey + "&AgentID=" + AgentId, Method.GET);
                request.AddHeader("Consumer-Key", ConsumerKey);
                var response = client.Execute(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK && response.Content.Contains("Result"))
                {
                    var obj = JObject.Parse(response.Content);
                    result = obj["Result"].ToString();
                    // return obj["Result"].ToString();

                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
            // Console.WriteLine($"GetApiToken {file} Token {result} started on thread: {Environment.CurrentManagedThreadId}");
           // return result;
            return Task.FromResult(result);
        }



    }



}
