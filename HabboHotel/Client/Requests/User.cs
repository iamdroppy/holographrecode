﻿using System;
using System.Collections.Generic;

using Ion.HabboHotel.Client.Utilities;
using Ion.HabboHotel.Messenger;

namespace Ion.HabboHotel.Client
{
    public partial class ClientMessageHandler
    {
        private const bool ENABLE_MESSENGER = true;

        /// <summary>
        /// 7 - "@G"
        /// </summary>
        public void InfoRetrieve()
        {
            if (mSession.GetHabbo() != null)
            {
                Response.Initialize(5); // "@E"
                Response.AppendObject(mSession.GetHabbo());
                SendResponse();
            }
        }

        /// <summary>
        /// 8 - "@H"
        /// </summary>
        public void GetCredits()
        {
            if (mSession.GetHabbo() != null)
            {
                Response.Initialize(6); // "@F"
                Response.Append(mSession.GetHabbo().Coins);
                Response.Append(".0");

                SendResponse();
            }
        }
        /// <summary>
        /// 12 - "@L"
        /// </summary>
        private void MessengerInit()
        {
            if (mSession.InitializeMessenger())
            {
                // Register handlers
                RegisterMessenger();

                // Send initialization message
                Response.Initialize(12); // "@L"
                Response.AppendInt32(600);
                Response.AppendInt32(200);
                Response.AppendInt32(600);
                Response.AppendBoolean(false);

                Response.AppendInt32(mSession.GetMessenger().GetBuddies().Count);
                foreach (MessengerBuddy buddy in mSession.GetMessenger().GetBuddies())
                {
                    Response.AppendObject(buddy);
                }

                SendResponse();
            }
        }
        /// <summary>
        /// 26 - "@Z"
        /// </summary>
        public void ScrGetUserInfo()
        {
            string sSubscription = Request.PopFixedString();
            Response.Initialize(7); // "@G"
            Response.AppendString(sSubscription);
            Response.AppendInt32(1337);
            Response.AppendInt32(0);
            Response.AppendInt32(0);
            Response.AppendBoolean(true);
            SendResponse();
        }

        /// <summary>
        /// 157 - "B]"
        /// </summary>
        public void GetBadges()
        {

        }

        /// <summary>
        /// 233 - "EA"
        /// </summary>
        private void GetIgnoredUsers()
        {
            Response.Initialize(420); // "Fd"
            Response.AppendString("Aaron");
            Response.AppendString("office.boy");
            Response.AppendString("Phoenix");
            SendResponse();
        }

        /// <summary>
        /// Registers request handlers available from successful login.
        /// </summary>
        public void RegisterUser()
        {
            mRequestHandlers[7] = new RequestHandler(InfoRetrieve);
            mRequestHandlers[8] = new RequestHandler(GetCredits);
            mRequestHandlers[12] = new RequestHandler(MessengerInit);
            mRequestHandlers[26] = new RequestHandler(ScrGetUserInfo);
            mRequestHandlers[157] = new RequestHandler(GetBadges);
            mRequestHandlers[233] = new RequestHandler(GetIgnoredUsers);
        }
    }
}
