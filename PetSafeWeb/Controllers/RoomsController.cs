﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetSafeWeb.Data;
using PetSafeWeb.Helpers.Interfaces;
using PetSafeWeb.Models.Room_Models;
using PetSafeWeb.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PetSafeWeb.Controllers
{
    public class RoomsController : Controller
    {
        private readonly DataContext _context;
        private readonly IRoomRepository _roomRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IConverterHelper _converterHelper;

        public RoomsController(DataContext context,
            IRoomRepository roomRepository,
            IConverterHelper converterHelper,
            IServiceRepository serviceRepository)
        {
            _context = context;
            _roomRepository = roomRepository;
            _converterHelper = converterHelper;
            _serviceRepository = serviceRepository;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rooms.ToListAsync());
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var room = await _roomRepository.GetByIdAsync(id.Value);

            if (room == null)
                return NotFound();

            var model = _converterHelper.ConvertToRoomViewModel(room);
            model.RoomServices = await _serviceRepository.GetActiveRoomServices(room);

            return View(model);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            var model = new RoomViewModel
            {
                Services = _serviceRepository.GetServicesList(),
            };

            return View(model);
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                var room = _converterHelper.ConvertToRoom(model, true);
                await _roomRepository.CreateAsync(room);

                // create roomservices
                await _serviceRepository.CreateRoomServices(room, model.Services);

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var room = await _roomRepository.GetByIdAsync(id.Value);

            if (room == null)
                return NotFound();

            var model = _converterHelper.ConvertToRoomViewModel(room);

            model.RoomServices = await _serviceRepository.GetActiveRoomServices(room);
            model.Services = _serviceRepository.GetActiveServicesList(model);

            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoomViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var room = _converterHelper.ConvertToRoom(model, false);
                    room = await _roomRepository.GetByIdAsync(room.Id);

                    await _serviceRepository.CreateRoomServices(room, model.Services);

                    await _roomRepository.UpdateAsync(room);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _roomRepository.ExistAsync(model.Id))
                        return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var room = await _roomRepository.GetByIdAsync(id.Value);
            if (room == null)
                return NotFound();

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _roomRepository.GetByIdAsync(id);
            await _roomRepository.DeleteAsync(room);
            return RedirectToAction(nameof(Index));
        }
    }
}
