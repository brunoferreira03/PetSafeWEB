using ClassLibrary1.Entities;
using PetSafeWeb.Models;

namespace PetSafeWeb.Helpers.Interfaces
{
    public interface IConverterHelper
    {
        ServiceViewModel ConvertToServiceViewModel(Service service);

        Service ConvertToService(ServiceViewModel model, bool isNew);

        RoomViewModel ConvertToRoomViewModel(Room room);

        Room ConvertToRoom(RoomViewModel model, bool isNew);

        DoctorViewModel ConvertToDoctorViewModel(Doctor doctor);

        Doctor ConvertToDoctor(DoctorViewModel model, string path, bool isNew);

        ClientViewModel ConvertToClientViewModel(Client client);

        Client ConvertToClient(ClientViewModel model,string path, bool isNew);

        AnimalViewModel ConvertToAnimalViewModel(Animal animal);

        Animal ConvertToAnimal(AnimalViewModel model, string path, bool isNew);

        AppointmentViewModel ConvertToAppointmentViewModel(Appointment appointment);

        Appointment ConvertToAppointment(AppointmentViewModel model, bool isNew);
    }
}
