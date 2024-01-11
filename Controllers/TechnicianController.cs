using AutoMapper;
using  AppGestionFranca.Data;
using AppGestionFranca.Repositories.Interfaces;
using  AppGestionFranca.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AppGestionFranca.Services;

namespace  AppGestionFranca.Controllers
{
    public class TechnicianController : Controller
    {
        readonly ITechnicianRepository technicianRepository;
        readonly ISubsidiaryRepository subsidiaryRepository;
        readonly IMapper mapper;

        public TechnicianController(ITechnicianRepository technicianRepository, IMapper mapper, ISubsidiaryRepository subsidiaryRepository)
        {
            this.technicianRepository = technicianRepository;
            this.mapper = mapper;
            this.subsidiaryRepository = subsidiaryRepository;
        }
        public IActionResult Index()
        {
            var technician = technicianRepository.GetAllAsync().Result;
            var technicianDTO = technician.Select(x => mapper.Map<TechnicianDTO>(x));
            return View(technicianDTO);
        }
        public IActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TechnicianDTO technicianDTO)
        {
            try
            {
                SubsidiaryService Service = new();
                TechnicianService Service2 = new();          
                int next = Service2.GetNextId();
                technicianDTO.TechnicianId = next;
                var technician = mapper.Map<Technician>(technicianDTO);              
                if (technician != null)
                {             
                    technician = technicianRepository.InsertAsync(technician).Result;
                    technicianDTO.TechnicianId = technician.TechnicianId;
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }

        }

        public IActionResult Edit(int? id)
        {        
            var technician = technicianRepository.GetByIdAsync((int)id).Result;
            return PartialView(technician);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int Id, TechnicianDTO technicianDTO)
        {
            try
            {
                var technician = technicianRepository.GetByIdAsync(Id).Result;
                if (technician == null)
                {
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });
                }

                if (technician != null)
                {
                    technician = mapper.Map<Technician>(technicianDTO);
                    technician = technicianRepository.UpdateAsync(technician).Result;
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        public IActionResult Delete(int? id)
        {
            var technician = technicianRepository.GetByIdAsync((int)id).Result;
            return PartialView(technician);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var technician = technicianRepository.GetByIdAsync(id).Result;
                if (technician == null)
                {
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });
                }

                if (technician != null)
                {

                    await technicianRepository.DeleteAsync(id);
                }
                return RedirectToAction("Index");                
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

    }
}
