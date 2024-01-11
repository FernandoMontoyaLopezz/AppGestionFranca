using AutoMapper;
using  AppGestionFranca.Data;
using AppGestionFranca.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace  AppGestionFranca.Controllers
{
    public class ItemController : Controller
    {
        readonly IItemRepository itemRepository;
        readonly IMapper mapper;

        public ItemController(IItemRepository itemRepository, IMapper mapper)
        {
            this.itemRepository = itemRepository;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var item = itemRepository.GetAllAsync().Result;
            var itemDTO = item.Select(x => mapper.Map<ItemDTO>(x));
            return View(itemDTO);
        }
    }
}
