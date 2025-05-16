using InventoryManager.Models;

namespace InventoryManager.Repositories
{
    public interface IItemRepository
    {
        List<Item> GetItems();
        void AddItem(Item item);
        void EditItem(Item item);
        void RemoveItem(int itemID);
    }
}
