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

            //await Task.Run(() =>
            //     {
            //         var s = "send sms";
            //         Console.WriteLine(s);
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
            try
            {
                var res1 = await DBDfinance(file);
                var res2 = await _edoc.creatEdoc(file);
                var res3 = await SaveToSme(file);

                Console.WriteLine($"AsyncMethod end {file} on thread: {Environment.CurrentManagedThreadId}");

                status = $"{file} success";

            }
            catch(Exception ex)
            {
                status = $"{file} fail";
            }


            // return Task.FromResult(status);
            return status;

            // return new TaskReult{ status ="sucess" ,code =1};
        }


        public  Task<string> DBDfinance(string f)
        {
            var file = f;




            Console.WriteLine($"DBDfinance {file} started on thread: {Environment.CurrentManagedThreadId}");
            return Task.FromResult($"return RegisteredEDoc {file}");


            //return Task.FromResult($"return RegisteredEDoc {file}").Result;
        }

        public Task<string> SaveToSme(string f)
        {
            var file = f;
            Console.WriteLine($"SaveToSme {file} started on thread: {Environment.CurrentManagedThreadId}");

            //await Task.Delay(TimeSpan.FromSeconds(1));

            //return "return DBDfinance";

            return Task.FromResult($"return SaveToSme {file}");
        }
    }

   

}
