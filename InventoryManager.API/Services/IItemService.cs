using InventoryManager.Models;

namespace InventoryManager.Services
{
    public interface IItemService
    {
        List<Item> GetItems();
        void AddItem(Item item);
        void EditItem(Item item);
        void RemoveItem(int itemID);
    }
}
