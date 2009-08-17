using System;

namespace Ion.HabboHotel.Client
{
    public partial class ClientMessageHandler
    {
        private void InitCrypto()
        {
            Response.Initialize(257); // "DA"
            Response.AppendInt32(9);
            Response.AppendInt32(0);
            Response.AppendInt32(0);
            Response.AppendInt32(1);
            Response.AppendInt32(1);
            Response.AppendInt32(3);
            Response.AppendInt32(0);
            Response.AppendInt32(2);
            Response.AppendInt32(1);
            Response.AppendInt32(4);
            Response.AppendInt32(0);
            Response.AppendInt32(5);
            Response.AppendString("dd-MM-yyyy");
            Response.AppendInt32(7);
            Response.AppendBoolean(false);
            Response.AppendInt32(8);
            Response.AppendString("hotel-co.uk");
            Response.AppendInt32(9);
            Response.AppendBoolean(false);
            SendResponse();
        }

        private void SSOTicket()
        {
            // Process ticket login
            string sTicket = Request.PopFixedString();
            mSession.Login(sTicket);
        }

        public void RegisterPreLogin()
        {
            mRequestHandlers[206] = new RequestHandler(InitCrypto);
            mRequestHandlers[204] = new RequestHandler(SSOTicket);
        }
        public void UnRegisterPreLogin()
        {
            mRequestHandlers[206] = null;
            mRequestHandlers[204] = null;
        }
    }
}
