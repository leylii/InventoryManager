using InventoryManager.Models;
using InventoryManager.Repositories;

namespace InventoryManager.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;
        public ItemService(IItemRepository repository) {  _repository = repository; }
        public void AddItem(Item item)
        {
            if (item != null && item.Quantity > 0) 
            {
                _repository.AddItem(item);
            } else 
            {
                Console.WriteLine("Invalid item. Quantity must be greater than 0.");
            }
        }

        public void EditItem(Item item)
        {
            _repository?.EditItem(item);
        }

        public List<Item> GetItems()
        {
            return _repository.GetItems();
        }

        public void RemoveItem(int itemID)
        {
            _repository.RemoveItem(itemID);
        }
    }
}
