using EGov.Platform.Net.Abstractions;
using Newtonsoft.Json;
using WebPlupload.Models;

namespace WebPlupload.Sevices
{
    public class SmsServices
    {
        private readonly IApiClient _api;
        private readonly string _url;
        private readonly string _user;
        private readonly string _password;
        private readonly string _senderName;

        public SmsServices(IApiClient api, SmsConfiguration sms)
        {
            _api = api;
            _url = sms.WsUrl;
            _user = sms.User;
            _password = sms.Pwd;
            _senderName = sms.SenderName;
        }



        public async Task  SendAsync(List<string> mobileNumbers, string messsage)
        {




            var req = _api.Create(_url).AddJsonBody(new
            {
                User = _user,
                Password = _password,
                Sender = _senderName,
                Msnlist = string.Join(";", mobileNumbers),
                MsgType = "T",
                Msg = messsage,
            });

            var res =   await _api.PostAsync<SmsResponse>(req);

            //var result = res;


        }
           
        

        

    }
}
