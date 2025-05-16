using InventoryManager.Models;
using InventoryManager.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemService _itemService;

        public ItemController(ILogger<ItemController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpGet("{id}", Name = "GetItemById")]
        public IActionResult GetById(int id)
        {
            var item = _itemService.GetItems().FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet(Name = "GetItems")]
        public ActionResult<IEnumerable<Item>> Get()
        {
            return Ok(_itemService.GetItems().ToArray());
        }

        [HttpPost(Name = "AddItem")]
        public ActionResult Add([FromBody] Item item)
        {
            if (item == null) return BadRequest("Item cannot be null!");
            _itemService.AddItem(item);
            return CreatedAtAction(nameof(Get), new {id = item.Id }, item);
        }

        [HttpPut(Name = "EditItem")]
        public ActionResult Edit([FromBody] Item item)
        {
            if (item == null) return BadRequest("Item cannot be null!");
            _itemService.EditItem(item);
            return NoContent();
        }

        [HttpDelete(Name = "DeleteItem")]
        public ActionResult Delete(int itemID)
        {
            _itemService.RemoveItem(itemID);
            return NoContent();
        }
    }
}
