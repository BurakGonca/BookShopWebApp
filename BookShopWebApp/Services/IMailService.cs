﻿namespace BookShopWebApp.Services
{
    public interface IMailService
    {

        void Send(string email, string displayName, string subject, string body);
    }
}
