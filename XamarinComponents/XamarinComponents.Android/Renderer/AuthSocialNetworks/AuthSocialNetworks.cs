using System;
using System.Linq;
using Android.Accounts;
using Xamarin.Forms;
using XamarinComponents;
using XamarinComponents.Droid;

[assembly: Dependency(typeof(AuthSocialNetworks))]
namespace XamarinComponents.Droid
{
    public class AuthSocialNetworks : IAuthSocialNetworks
    {
        // Авторизация через соц. сети
        public void SendAuthApp(string typeAccounts)
        {
            try
            {
                // var sharedPrefs = PreferenceManager.GetDefaultSharedPreferences(this);
                if(MainActivity.mainActivity == null)
                    throw new Exception("Авторизация невозможна");

                AccountManager manager = AccountManager.Get(MainActivity.mainActivity);

                Account[] accounts = manager.GetAccountsByType(typeAccounts);//"com.vkontakte.account");//com.google");
                                                                                        //List<string> emails = new List<string>();

                if (accounts.Length.Equals(0))
                    throw new Exception("Нет аккаунтов");

                foreach (var account in manager.GetAccounts())
                {
                    System.Diagnostics.Debug.WriteLine("account Name : " + account.Name + " Type" + account.Type);
                }

                foreach (var item in accounts)
                {
                    System.Diagnostics.Debug.WriteLine("item Name : " + item.Name + " Type" + item.Type);
                }

            }
            catch (Exception ex)
            {
                Untils.Toast(ex.Message);
            }
        }
    }
}

