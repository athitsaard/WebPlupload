using System.Threading.Tasks;

namespace WebPlupload.Sevices
{
    public class Edoc
    {
        public async Task<string> creatEdoc(string f)
        {
            var file = f;

            Console.WriteLine($"creatEdoc {file} started on thread: {Environment.CurrentManagedThreadId}");

            //RegisteredEDoc(file).GetAwaiter().GetResult();

            //SigningOrg(file).GetAwaiter().GetResult();

            //return Task.FromResult($"return createEdoc");


            var res1 = await RegisteredEDoc(file);

            var res2 = await SigningOrg(file);

            return "return createEdoc";


        }

        static Task<string> RegisteredEDoc(string f)
        {
            var file = f;

            Console.WriteLine($"RegisteredEDoc {file} started on thread: {Environment.CurrentManagedThreadId}");
            // Console.WriteLine($"RegisteredEDoc-{T} thread:{Environment.CurrentManagedThreadId}");
            //if (T == "juristicfile2")
            //{
            //    throw new Exception("methot2 juristicfile2 fail");
            //}
            return Task.FromResult($"return RegisteredEDoc {file}");
          

        }


        static Task<string> SigningOrg(string f)
        {
            var file = f;

            Console.WriteLine($"SigningOrg {file} started on thread: {Environment.CurrentManagedThreadId}");
            //Console.WriteLine($"SigningOrg-{T} thread:{Environment.CurrentManagedThreadId}");

            return Task.FromResult($"return SigningOrg {file}");

        }


    }
}
