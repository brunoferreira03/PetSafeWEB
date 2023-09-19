using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassLibrary1.Entities;
using PetSafeWeb.Data;
using PetSafeWeb.Repositories.Interfaces;
using PetSafeWeb.Helpers.Interfaces;
using PetSafeWeb.Models;
using PetSafeWeb.Helpers.Classes;

namespace PetSafeWeb.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public DoctorsController(IDoctorRepository doctorRepository,
            IConverterHelper converterHelper,
            IImageHelper imageHelper)
        {
            _doctorRepository = doctorRepository;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
        }

        // GET: Doctors
        public IActionResult Index()
        {
            return View(_doctorRepository.GetAll());
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var doctor = await _doctorRepository.GetByIdAsync(id.Value);


            if (doctor == null)
                return NotFound();

            var model = _converterHelper.ConvertToDoctorViewModel(doctor);

            return View(model);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            var model = new DoctorViewModel();

            return View(model);
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                    path = await _imageHelper.UploadImageAsync(model.ImageFile, "Doctors");

                var doctor = _converterHelper.ConvertToDoctor(model, path, true);
                await _doctorRepository.CreateAsync(doctor);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var doctor = await _doctorRepository.GetByIdAsync(id.Value);

            if (doctor == null)
                return NotFound();

            var model = _converterHelper.ConvertToDoctorViewModel(doctor);

            return View(model);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = model.ImageURL;

                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                        path = await _imageHelper.UploadImageAsync(model.ImageFile, "Doctors");

                    var doctor = await _doctorRepository.GetByIdAsync(model.Id);
                    doctor = _converterHelper.ConvertToDoctor(model, path, false);
                    

                    await _doctorRepository.UpdateAsync(doctor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _doctorRepository.ExistAsync(model.Id))
                        return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var doctor = await _doctorRepository.GetByIdAsync(id.Value);
            if (doctor == null)
                return NotFound();

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);
            await _doctorRepository.DeleteAsync(doctor);
            return RedirectToAction(nameof(Index));
        }
    }
}
