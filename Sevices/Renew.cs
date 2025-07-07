using Newtonsoft.Json.Linq;
using RestSharp;

namespace WebPlupload.Sevices
{
    public class Renew
    {
        private readonly Edoc _edoc;
        public Renew(Edoc edoc)
        {
            _edoc = edoc;
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

            var result1 = Task.Run(() => AsyncMethod("juristicfile1"));
            var result2 = Task.Run(() => AsyncMethod("juristicfile2"));
            var result3 = Task.Run(() => AsyncMethod("juristicfile3"));

            var combinedResults = await Task.WhenAll(result1, result2, result3);
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
            try
            {
                var res1 =  await DBDfinance(file);

                // Console.WriteLine($"DBDfinance  {file}  result {res1} on thread: {Environment.CurrentManagedThreadId}");

                var ResultToken = await GetApiToken(file);

                //var ResultToken = await ResultToken;

                token = ResultToken;

                var res2 = await _edoc.RegisteredEDoc(file,token);
                var res3 = await _edoc.SigningOrg(file, token);

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


        public Task<string> DBDfinance(string f)
        {
            var file = f;
            Thread.Sleep(3000); // Delay for 2000 milliseconds (2 seconds)
            // await Task.Delay(TimeSpan.FromSeconds(1));


            Console.WriteLine($"DBDfinance {file} started on thread: {Environment.CurrentManagedThreadId}");
            return Task.FromResult($"return DBDfinance {file}");


            //return Task.FromResult($"return RegisteredEDoc {file}").Result;
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

        public  Task<string> GetApiToken(string f, string AgentId = "dgaAgent")
        {
            var file = f;
            var result = string.Empty;

            try
            {
                var SecretKey = "x1VQ9Jl7W0H";
                var ConsumerKey = "6df7d876-3b30-4786-bb12-455446291b8f";

                var client = new RestClient("https://api.egov.go.th");
                var request = new RestRequest("/ws/auth/validate?ConsumerSecret=" + SecretKey + "&AgentID=" + AgentId, Method.Get);
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
