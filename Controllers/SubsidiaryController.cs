using AutoMapper;
using  AppGestionFranca.Data;
using AppGestionFranca.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace  AppGestionFranca.Controllers
{
    public class SubsidiaryController : Controller
    {
        readonly ISubsidiaryRepository subsidiaryRepository;
        readonly IMapper mapper;

        public SubsidiaryController(ISubsidiaryRepository subsidiaryRepository, IMapper mapper)
        {
            this.subsidiaryRepository = subsidiaryRepository;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            var subsidiary = subsidiaryRepository.GetAllAsync().Result;
            var subsidiaryDTO = subsidiary.Select(x => mapper.Map<SubsidiaryDTO>(x));
            return View(subsidiaryDTO);
        }

        public JsonResult Json()
        {
            var subsidiary = subsidiaryRepository.GetAllAsync().Result;
            var subsidiaryDTO = subsidiary.Select(x => mapper.Map<SubsidiaryDTO>(x));
            return Json(subsidiaryDTO.ToDictionary(x => x.SubsidiaryId));
        }
    }
}
