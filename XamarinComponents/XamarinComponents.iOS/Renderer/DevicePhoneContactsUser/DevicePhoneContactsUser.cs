using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contacts;
using Foundation;
using Xamarin.Forms;
using XamarinComponents.iOS;

[assembly: Dependency(typeof(DevicePhoneContactsUser))]
namespace XamarinComponents.iOS
{
    public class DevicePhoneContactsUser : IDevicePhoneContactsUser
    {
        private NSError error;

#pragma warning disable XI0002 // Напоминание не использовать более новые API Apple при ориентации на старую версию ОС
        /// <summary>
        /// Метод получения списка контактов
        /// </summary>
        /// <returns></returns>
        public async Task<List<ModelPhoneContactsUser>> GetDeviceContacts()
        {
            var keysToFetch = new[] {
                CNContactKey.ThumbnailImageData,
                CNContactKey.GivenName,
                CNContactKey.FamilyName,
                CNContactKey.PhoneNumbers
            };

            // Список контактов
            var contactList = new List<CNContact>();

            // Записи контактов
            using (var store = new CNContactStore())
            {
                var allContainers = store.GetContainers(null, out error);
                foreach (var container in allContainers)
                {
                    try
                    {
                        using (var predicate = CNContact.GetPredicateForContactsInContainer(container.Identifier))
                        {
                            var containerResults = store.GetUnifiedContacts(predicate, keysToFetch, out error);
                            contactList.AddRange(containerResults);
                        }
                    }
                    catch
                    {
                        System.Diagnostics.Debug.WriteLine("Ignore missed contacts from errors");
                    }
                }
            }

            // Новый список контактов
            var contacts = new List<ModelPhoneContactsUser>();

            foreach (var item in contactList)
            {
                var numbers = item.PhoneNumbers;

                if (numbers != null && !numbers.Length.Equals(0))
                    foreach (var item2 in numbers)
                        contacts.Add(new ModelPhoneContactsUser
                        {
                            Avatar = item.ThumbnailImageData.ToString(),
                            FirstName = item.GivenName,
                            LastName = item.FamilyName,
                            PhoneNumber = item2.Value.StringValue
                        });
            }

            return contacts;
        }
#pragma warning restore XI0002 // Напоминание не использовать более новые API Apple при ориентации на старую версию ОС
    }
}

