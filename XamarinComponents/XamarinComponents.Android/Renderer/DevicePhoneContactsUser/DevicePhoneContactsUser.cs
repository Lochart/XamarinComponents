using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Android.Provider;
using Xamarin.Forms;
using XamarinComponents.Droid;

[assembly: Dependency(typeof(DevicePhoneContactsUser))]
namespace XamarinComponents.Droid
{
    public class DevicePhoneContactsUser : IDevicePhoneContactsUser
    {
        Task<List<ModelPhoneContactsUser>> IDevicePhoneContactsUser.GetDeviceContacts()
        {
            var phoneContacts = new List<ModelPhoneContactsUser>();

            var requestContentResolver = Android.App.Application.Context.ContentResolver.Query(
                ContactsContract.CommonDataKinds.Phone.ContentUri,
                null, null, null, null);

            using (var phones = requestContentResolver)
            {
                if (phones == null || phones.Count.Equals(0))
                    Untils.Toast("Нет ни одного контакта");
                else
                {
                    while (phones.MoveToNext())
                    {
                        try
                        {
                            string photo = phones.GetString(
                                phones.GetColumnIndex(
                                    ContactsContract.Contacts.InterfaceConsts.PhotoUri));

                            string name = phones.GetString(
                                phones.GetColumnIndex(
                                ContactsContract.Contacts.InterfaceConsts.DisplayName));

                            string phoneNumber = phones.GetString(
                                phones.GetColumnIndex(
                                    ContactsContract.CommonDataKinds.Phone.Number));

                            string[] words = name.Split(' ');

                            var contact = new ModelPhoneContactsUser
                            {
                                FirstName = words[0]
                            };

                            contact.LastName = words.Length > 1 ? words[1] : ""; //no last name
                            contact.PhoneNumber = phoneNumber;
                            contact.Avatar = photo;

                            phoneContacts.Add(contact);
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e);
                            //something wrong with one contact, may be display name is completely empty, decide what to do
                        }
                    }
                    phones.Close();
                }
                // if we get here, we can't access the contacts. Consider throwing an exception to display to the user
            }

            return Task.Run(() => phoneContacts);
        }
    }
}
