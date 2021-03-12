using System;
using System.Net;
using System.Text;
using System.Threading;
using Shop.View;

namespace Shop.ServerControl
{
    public class ServerShop
    {
        private IView _view;
        private Shop Shop;
        public ServerShop(IView view)
        {
            _view = view;
        }

        private void ThreadServer()
        {
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:55874/");
            httpListener.Start();
            
            
            while (true)
            {
                var requestContext = httpListener.GetContext();
                var requestStream = requestContext.Request.InputStream;

                if (requestContext.Request.HttpMethod == "POST")
                {
                    var requestBytes = new byte[requestContext.Request.ContentLength64];
                    requestStream.Read(requestBytes, 0, (int)requestContext.Request.ContentLength64);
                    _view.ClientRequest = Encoding.UTF8.GetString(requestBytes);
                    Console.WriteLine(_view.ClientRequest);
                    requestContext.Response.StatusCode = 200; //OK
                    _view.WaitRequest.Set();
                    _view.WaitAnswer.WaitOne();
                    var stream = requestContext.Response.OutputStream;
                    var bytes = Encoding.UTF8.GetBytes(_view.ServerAnswer);
                    stream.Write(bytes, 0, bytes.Length);
                    isClientConnected = true;
                }
                requestContext.Response.Close();
            }

            httpListener.Stop();
            httpListener.Close();
        }
        public void Start()
        {
            new Thread(() => ThreadServer()).Start();
            Shop = new Shop(_view);
            _view.ReadLine();
            Console.WriteLine("Клиент инициализирован");

            Shop.Start();
            

        }

        public bool isClientConnected=false;

    }
}
