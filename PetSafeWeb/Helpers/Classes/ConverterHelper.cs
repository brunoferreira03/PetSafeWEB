using ClassLibrary1.Entities;
using PetSafeWeb.Helpers.Interfaces;
using PetSafeWeb.Models;
using PetSafeWeb.Models.AnimalModels;
using PetSafeWeb.Models.Appointment_Models;
using PetSafeWeb.Models.ClientModels;
using PetSafeWeb.Models.DoctorModels;
using PetSafeWeb.Models.Service_Models;

namespace PetSafeWeb.Helpers.Classes
{
    public class ConverterHelper : IConverterHelper
    {
        public Animal ConvertToAnimal(AnimalViewModel model, bool isNew)
        {
            throw new System.NotImplementedException();
        }

        public AnimalViewModel ConvertToAnimalViewModel(Animal animal)
        {
            throw new System.NotImplementedException();
        }

        public Appointment ConvertToAppointment(AppointmentViewModel model, bool isNew)
        {
            throw new System.NotImplementedException();
        }

        public AppointmentViewModel ConvertToAppointmentViewModel(Appointment appointment)
        {
            throw new System.NotImplementedException();
        }

        public Client ConvertToClient(ClientViewModel model, bool isNew)
        {
            throw new System.NotImplementedException();
        }

        public ClientViewModel ConvertToClientViewModel(Client client)
        {
            throw new System.NotImplementedException();
        }

        public Doctor ConvertToDoctor(DoctorViewModel model, bool isNew)
        {
            throw new System.NotImplementedException();
        }

        public DoctorViewModel ConvertToDoctorViewModel(Doctor doctor)
        {
            throw new System.NotImplementedException();
        }

        public Room ConvertToRoom(RoomViewModel model, bool isNew)
        {
            return new Room
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                ServiceIds = model.ServiceIds,
            };
        }

        public RoomViewModel ConvertToRoomViewModel(Room room)
        {
            return new RoomViewModel
            {
                Id = room.Id,
                Name = room.Name,
                ServiceIds = room.ServiceIds,
            };
        }

        public Service ConvertToService(ServiceViewModel model, bool isNew)
        {
            return new Service
            {
                Id = isNew ? 0 : model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
            };
        }

        public ServiceViewModel ConvertToServiceViewModel(Service service)
        {
            return new ServiceViewModel
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
            };
        }
    }
}
