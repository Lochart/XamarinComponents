using System.Collections.Generic;
using System.Threading.Tasks;

namespace XamarinComponents
{
    /// <summary>
    /// Пользовательский интерфейс по списку контактов из телефона
    /// </summary>
    public interface IDevicePhoneContactsUser 
    {
        Task<List<ModelPhoneContactsUser>> GetDeviceContacts();
    }
}

