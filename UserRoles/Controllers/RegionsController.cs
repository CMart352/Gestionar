using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserRoles.Repositories.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserRoles.Controllers
{
    public class RegionsController : Controller
    {
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;

        public RegionsController(IStateRepository stateRepository, ICityRepository cityRepository)
        {
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }

        public JsonResult getstatebyId(int? Countryid)
        {
            //var employee = await _repository.EmployeeRepository.GetEmployee(id);
            var liststates = _stateRepository.GetAllStates(Countryid);
            
            return Json(new SelectList(liststates, "Id", "Name"));

        }

        public JsonResult getcitybyId(int? Stateid)
        {
            //var employee = await _repository.EmployeeRepository.GetEmployee(id);
            var listcities = _cityRepository.GetAllCity(Stateid);

            return Json(new SelectList(listcities, "Id", "Name"));
        }

    }
}
