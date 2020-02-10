using System;

using Xamarin.Forms;

namespace XamarinComponents
{
    public interface IAuthSocialNetworks 
    {
        // Авторизация через соц. вконтакте
        void SendAuthApp(string typeAccounts);
    }
}

