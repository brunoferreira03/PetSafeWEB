using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetSafeWeb.Data;
using PetSafeWeb.Helpers.Interfaces;
using PetSafeWeb.Models;
using PetSafeWeb.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PetSafeWeb.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataContext _context;
        private readonly IServiceRepository _serviceRepository;

        private readonly IConverterHelper _converterHelper;

        public ServicesController(DataContext context,
            IServiceRepository serviceRepository,
            IConverterHelper converterHelper)
        {
            _context = context;
            _serviceRepository = serviceRepository;
            _converterHelper = converterHelper;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            return View(await _context.Services.ToListAsync());
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var service = await _serviceRepository.GetByIdAsync(id.Value);

            if (service == null)
                return NotFound();

            var model = _converterHelper.ConvertToServiceViewModel(service);

            return View(model);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            var model = new ServiceViewModel();

            return View(model);
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = _converterHelper.ConvertToService(model, true);
                await _serviceRepository.CreateAsync(service);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var service = await _serviceRepository.GetByIdAsync(id.Value);
            if (service == null)
                return NotFound();

            var model = _converterHelper.ConvertToServiceViewModel(service);

            return View(model);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var service = _converterHelper.ConvertToService(model, false);
                    service = await _serviceRepository.GetByIdAsync(service.Id);

                    await _serviceRepository.UpdateAsync(service);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _serviceRepository.ExistAsync(model.Id))
                        return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var service = await _serviceRepository.GetByIdAsync(id.Value);

            if (service == null)
                return NotFound();

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _serviceRepository.GetByIdAsync(id);
            await _serviceRepository.DeleteAsync(service);
            return RedirectToAction(nameof(Index));
        }
    }
}
