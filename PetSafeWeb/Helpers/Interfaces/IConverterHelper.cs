using ClassLibrary1.Entities;
using PetSafeWeb.Models.AnimalModels;
using PetSafeWeb.Models.Appointment_Models;
using PetSafeWeb.Models.ClientModels;
using PetSafeWeb.Models.DoctorModels;
using PetSafeWeb.Models.Room_Models;
using PetSafeWeb.Models.Service_Models;

namespace PetSafeWeb.Helpers.Interfaces
{
    public interface IConverterHelper
    {
        ServiceViewModel ConvertToServiceViewModel(Service service);

        Service ConvertToService(ServiceViewModel model, bool isNew);

        RoomViewModel ConvertToRoomViewModel(Room room);

        Room ConvertToRoom(RoomViewModel model, bool isNew);

        DoctorViewModel ConvertToDoctorViewModel(Doctor doctor);

        Doctor ConvertToDoctor(DoctorViewModel model, bool isNew);

        ClientViewModel ConvertToClientViewModel(Client client);

        Client ConvertToClient(ClientViewModel model, bool isNew);

        AnimalViewModel ConvertToAnimalViewModel(Animal animal);

        Animal ConvertToAnimal(AnimalViewModel model, bool isNew);

        AppointmentViewModel ConvertToAppointmentViewModel(Appointment appointment);

        Appointment ConvertToAppointment(AppointmentViewModel model, bool isNew);
    }
}
