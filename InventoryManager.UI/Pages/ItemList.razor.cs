using InventoryManager.UI.Models;

namespace InventoryManager.UI.Pages
{
    public partial class ItemList
    {
        List<ItemDto> items = new();

        protected override async Task OnInitializedAsync()
        {
            items = await itemService.GetItemsAsync();
        }
    }
}
