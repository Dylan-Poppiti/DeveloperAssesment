using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCore.Models;

namespace WebCore.Controllers
{
    public class PatientsController : Controller
    {
        private readonly PatientContext _context;

        public PatientsController(PatientContext context)
        {
            _context = context;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            return View(await _context.patients.ToListAsync());
        }

        public ActionResult<string> GetById(int Id)
        {
            if (Id <= 0)
            {
                return NotFound("Patient Id must be greater than zero");
            }
            Patient p = _context.patients.FirstOrDefault(s => s.Id == Id);
            if (p == null)
            {
                return NotFound("Patient is not here.");
            }
            return Ok(p.ToJson());
        }
        public ActionResult<string> GetByFirstName(string equals)
        {
            if (equals==null)
            {
                return NotFound("Must have a value.");
            }
            Patient p = _context.patients.FirstOrDefault(s => s.FirstName == equals);
            if (p == null)
            {
                return NotFound("Patient is not here.");
            }
            return Ok(p.ToJson());
        }
        public ActionResult<string> GetByLastName(string equals)
        {
            if (equals == null)
            {
                return NotFound("Must have a value.");
            }
            Patient p = _context.patients.FirstOrDefault(s => s.LastName == equals);
            if (p == null)
            {
                return NotFound("Patient is not here.");
            }
            return Ok(p.ToJson());
        }
        public ActionResult<string> GetByAddress(string equals)
        {
            if (equals == null)
            {
                return NotFound("Must have a value.");
            }
            Patient p = _context.patients.FirstOrDefault(s => s.Address == equals);
            if (p == null)
            {
                return NotFound("Patient is not here.");
            }
            return Ok(p.ToJson());
        }
        public ActionResult<string> GetByGender(string equals)
        {
            if (equals == null)
            {
                return NotFound("Must have a value.");
            }

            Patient p = _context.patients.FirstOrDefault(s => s.Gender == equals);
            if (p == null)
            {
                return NotFound("Patient is not here.");
            }
            return Ok(p.ToJson());
        }
        public ActionResult<string> GetByCity(string equals)
        {
            if (equals == null)
            {
                return NotFound("Must have a value.");
            }
            Patient p = _context.patients.FirstOrDefault(s => s.City == equals);
            if (p == null)
            {
                return NotFound("Patient is not here.");
            }
            return Ok(p.ToJson());
        }
        public ActionResult<string> GetByState(string equals)
        {
            if (equals == null)
            {
                return NotFound("Must have a value.");
            }
            Patient p = _context.patients.FirstOrDefault(s => s.State == equals);
            if (p == null)
            {
                return NotFound("Patient is not here.");
            }
            return Ok(p.ToJson());
        }
        public ActionResult<string> GetByDateOfBirth(string equals)
        {
            if (equals == null)
            {
                return NotFound("Must have a value.");
            }
            DateTime e = Convert.ToDateTime(equals);
            Patient p = _context.patients.FirstOrDefault(s => s.DateOfBirth == e);
            if (p == null)
            {
                return NotFound("Patient is not here.");
            }
            return Ok(p.ToJson());
        }

        public async Task<IActionResult> Upload(string p)
        {
            List<Patient> patt = new List<Patient>();
            List<string> Id = new List<string>();
            List<string> FirstName = new List<string>();
            List<string> LastName = new List<string>();
            List<string> Address = new List<string>();
            List<string> City = new List<string>();
            List<string> State = new List<string>();
            List<string> ZipCode = new List<string>();
            List<string> DateOfBirth = new List<string>();
            List<string> Gender = new List<string>();

            var path = @""+p;
            //  PatientContext context = new PatientContext();
            //  patientsController pC = new patientsController(context);

            try
            {
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        Id.Add(values[0]);
                        FirstName.Add(values[1]);
                        LastName.Add(values[2]);
                        DateOfBirth.Add(values[3]);
                        Gender.Add(values[4]);
                        Address.Add(values[5]);
                        City.Add(values[6]);
                        State.Add(values[7]);
                        ZipCode.Add(values[8]);
                    }


                }
                for (int i = 1; i < Id.Count; i++)
                {
                    int alpha = Convert.ToInt32(Id[i]);
                    Patient nP = new Patient(alpha, FirstName[i], LastName[i], DateOfBirth[i], Gender[i], Address[i], City[i], State[i], ZipCode[i]);
                    patt.Add(nP);

                    //_context.Add(nP);
                    //_context.SaveChanges();
                 }
                }
            catch
            {
                //return NotFound("Path Failure");
                return NotFound(path);
            }
            if (patt.Count() > 0)
            {
                for (int i = 0; i < patt.Count; i++)
                {
                    _context.Add(patt[i]);
                }
                    await _context.SaveChangesAsync();
                return NotFound("Finished");
            }
            else
            {
                return NotFound("Failure");
            }
        }
        //GET: Patients/Create
        public IActionResult AddOrEdit(int id = 0)
        {
            return View(new Patient());
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,FirstName,LastName,Address,City,State,ZipCode,DateOfBirth,Gender")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patient);
        }


        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.patients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (patient == null)
            {
                return NotFound();
            }

            return View(patient);
        }


    }
}
