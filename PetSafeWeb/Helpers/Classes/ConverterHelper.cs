using ClassLibrary1.Entities;
using PetSafeWeb.Helpers.Interfaces;
using PetSafeWeb.Models;

namespace PetSafeWeb.Helpers.Classes
{
    public class ConverterHelper : IConverterHelper
    {
        public Animal ConvertToAnimal(AnimalViewModel model, string path, bool isNew)
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

        public Client ConvertToClient(ClientViewModel model, string path, bool isNew)
        {
            return new Client
            {
                Id = isNew ? 0 : model.Id,
                ImageURL = path,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                PetIds = model.PetIds,
            };
        }

        public ClientViewModel ConvertToClientViewModel(Client client)
        {
            return new ClientViewModel
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Address = client.Address,
                PhoneNumber = client.PhoneNumber,
                PetIds = client.PetIds,
                ImageURL = client.ImageURL,
            };
        }

        public Doctor ConvertToDoctor(DoctorViewModel model, string path, bool isNew)
        {
            return new Doctor
            {
                Id = isNew ? 0 : model.Id,
                ImageURL = path,
                FirstName = model.FirstName,
                LastName = model.LastName,

            };
        }

        public DoctorViewModel ConvertToDoctorViewModel(Doctor doctor)
        {
            return new DoctorViewModel
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                ImageURL = doctor.ImageURL,
            };
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
