using InventoryManager.Models;

namespace InventoryManager.Repositories
{
    public class InMemoryItemRepository : IItemRepository
    {
        List<Item> items = new List<Item>();
        private int _nextId = 0;
        public void AddItem(Item item)
        {
            Console.WriteLine($"the nextId is {_nextId}");
            item.Id = _nextId++;
            items.Add(item);
            Console.WriteLine($"Save the item {item.Id} and {_nextId}");
        }

        public void EditItem(Item item)
        {
            Item existingItem = items.FirstOrDefault(x => x.Id == item.Id); 
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Quantity = item.Quantity;
                Console.WriteLine("Edit the item");
            }
            else 
            { 
                Console.WriteLine("The item does not Exist!"); 
            }           
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public void RemoveItem(int itemID)
        {
            var existingItem = items.FirstOrDefault(x => x.Id != itemID);
            if (existingItem != null)
            {
                items.Remove(existingItem);
                Console.WriteLine("The item deleted");
            }
            else
            { 
                Console.WriteLine("The item did not find to be removed"); 
            }
            
        }
    }
}
