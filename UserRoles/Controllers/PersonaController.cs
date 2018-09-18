using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserRoles.Data;
using UserRoles.Helpers;
using UserRoles.Models;
using UserRoles.Models.FormsViewModels;
using UserRoles.Repositories.Interface;


namespace UserRoles.Controllers
{
    public class PersonaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPersonaRepository _personaRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;


        public PersonaController(ApplicationDbContext context, IPersonaRepository personaRepository, ICountryRepository countryRepository, 
                                IStateRepository stateRepository, ICityRepository cityRepository)
        {
            _context = context;
            _personaRepository = personaRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }

        // GET: Persona
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Personas.Include(p => p.City);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Persona/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.City)
                .SingleOrDefaultAsync(m => m.PersonId == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }
        //been updated with th
        // GET: Persona/Create
        public async Task<IActionResult> Create()
        {
            IEnumerable<Country> listcountries = await _countryRepository.All();
            //IEnumerable<State> liststates = await _stateRepository.All();
            //IEnumerable<City> listcities = await _cityRepository.All();

            //this is a model fo persona fisica
            PersonaFormViewModel personaVModel = new PersonaFormViewModel(new SelectList(listcountries, "Id", "Name"));
            //personaVModel.TypoPersona = CustomEnums.TypoPersonaEnum.Juridica;
            personaVModel.StatusCliente = CustomEnums.TypoStatusClienteEnum.Pending; //set up new cliente to status pendi
            
            //PersonaFormViewModel juridicaVModel = new PersonaFormViewModel(new SelectList(listcountries, "Id", "Name"));
            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name");
            return View( personaVModel);
        }


        // POST: Persona/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(PersonaFisicaViewModel fisicavmodel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _personaRepository.Add(fisicavmodel);
        //        await _personaRepository.Save();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", fisicavmodel.CityId);
        //    return View(fisicavmodel);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,Street,Numero,Floor,Aparment,Zip,City,State,Country,Email,Web,HomePhone,CellPhone,NumeroDoc,FirstName, SecondName, FirstLastName, SecondLastName,TypoDocumento,TypoPersona, RazonSocial,TypoRepresentante")] PersonaFormViewModel personavmodels, IFormCollection collectionRepresentantes)
        //public async Task<IActionResult> Create([Bind("PersonId,Street,Numero,Floor,Aparment,Zip,City,State,Country,Email,Web,HomePhone,CellPhone,NumeroDoc,FirstName, SecondName, FirstLastName, SecondLastName,TypoDocumento,TypoPersona, RazonSocial,TypoRepresentante")] PersonaFormViewModel personavmodels, IFormCollection collectionRepresentantes)
        {
            Persona person = null;
            Console.WriteLine(personavmodels.TypoPersona);
           
            //var firstName = collectionRepresentantes["firstName"];  
            //var lastName = collectionRepresentantes["lastName"];  
            //var typoRep = collectionRepresentantes["typoRep"];  
            //var typoDoc = collectionRepresentantes["typoDoc"];  
            //var numDoc = collectionRepresentantes["numDoc"];  

            Console.WriteLine(personavmodels);
            if (personavmodels.TypoPersona == CustomEnums.TypoPersonaEnum.Fisica)
            {
                ModelState.Remove("RazonSocial");
            }
            else if (personavmodels.TypoPersona == CustomEnums.TypoPersonaEnum.Juridica)
            {
                ModelState.Remove("FirstName");
                ModelState.Remove("FirstLastName");

            }
            if (ModelState.IsValid)
               
            {
                if (personavmodels.TypoPersona == CustomEnums.TypoPersonaEnum.Fisica)
                {
                    person = Utils.GetModel<PersonaFisica>(personavmodels);// se pasan como parametro el view model
                }
                else if (personavmodels.TypoPersona == CustomEnums.TypoPersonaEnum.Juridica)
                {
                    person = Utils.GetModel<PersonaJuridica>(personavmodels);// se pasan como parametro el view model

                    for (int i = 0; i < collectionRepresentantes["FirstNameTable"].Count; i++)
                    {

                        Representante repr = new Representante()
                        {
                            FirstName = collectionRepresentantes["FirstNameTable"][i],
                            FirstLastName = collectionRepresentantes["FirstLastNameTable"][i],
                            TypoRepresentante = (CustomEnums.TypoRepresentanteEnum)Enum.Parse(typeof(CustomEnums.TypoRepresentanteEnum), collectionRepresentantes["TypoRepresentanteTable"][i]),
                            TypoDocumento = (CustomEnums.TypoDocumentoEnum)Enum.Parse(typeof(CustomEnums.TypoDocumentoEnum), collectionRepresentantes["TypoDocumentoTable"][i]),
                            NumeroDoc = collectionRepresentantes["NumeroDocTable"][i]
                        };
                        ((PersonaJuridica)person).Representantes.Add(repr);
                    }
                }

                //person = new PersonaFisica(personavmodels.PersonId, personavmodels.Street); 
                //i can pass the view model to persona fisic o pasar por el contructo que cree en persona fisica todos los parameters de esa fucnion 
                await _personaRepository.Add(person);
               // //        await _personaRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", persona.CityId);
            IEnumerable<Country> listcountries = await _countryRepository.All();

            personavmodels.Countries = new SelectList(listcountries, "Id", "Name");

            return View(personavmodels);
        } 

        // GET: Persona/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas.SingleOrDefaultAsync(m => m.PersonId == id);
            if (persona == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", persona.CityId);
            return View(persona);
        }

        // POST: Persona/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,Street,Numero,Floor,Aparment,Zip,CityId,Email,Web,HomePhone,CellPhone,Id,NumeroDoc")] Persona persona)
        {
            if (id != persona.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.PersonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "Id", "Name", persona.CityId);
            return View(persona);
        }

        // GET: Persona/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = await _context.Personas
                .Include(p => p.City)
                .SingleOrDefaultAsync(m => m.PersonId == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var persona = await _context.Personas.SingleOrDefaultAsync(m => m.PersonId == id);
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PersonaFisica()
        {
            var model = _personaRepository.All();

            return View(model);
        }

        public async Task<IActionResult> PersonaJuridica()
        {
            return View();
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.PersonId == id);
        }
    }
}
