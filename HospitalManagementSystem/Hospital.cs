using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem
{
    public class Hospital
    {
        public List<Doctor> Doctors { get; set; }
        public List<Patient> Patients { get; set; }
        public List<HospitalRoom> Rooms { get; set; }
        public List<MedicalRecord> Records { get; set; }

        // Ініціалізація порожніх списків
        public Hospital()
        {
            Doctors = new List<Doctor>();
            Patients = new List<Patient>();
            Rooms = new List<HospitalRoom>();
            Records = new List<MedicalRecord>();
        }

        // додавання лікаря
        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                Console.WriteLine("Помилка: спроба додати null лікаря");
                return;
            }

            Doctors.Add(doctor);
            Console.WriteLine($"Лікар {doctor.Name} ({doctor.Specialization}) доданий до системи");
        }

        // реєстрація пацієнта
        public void RegisterPatient(Patient patient)
        {
            if (patient == null)
            {
                Console.WriteLine("Помилка: спроба зареєструвати null пацієнта");
                return;
            }

            Patients.Add(patient);
            Console.WriteLine($"Пацієнт {patient.Name}, {patient.Age} років, зареєстрований");
        }

        // створення палати
        public void CreateRoom(HospitalRoom room)
        {
            if (room == null)
            {
                Console.WriteLine("Помилка: спроба створити null палату");
                return;
            }

            Rooms.Add(room);
            Console.WriteLine($"Палата №{room.RoomNumber} створена (місткість: {room.Capacity})");
        }

        // госпіталізація пацієнта
        public void HospitalizePatient(int patientId, int roomNumber)
        {
            Patient? foundPatient = Patients.FirstOrDefault(p => p.Id == patientId);
            if (foundPatient == null)
            {
                Console.WriteLine($"Пацієнт з ID {patientId} не знайдений!");
                return;
            }

            // Пошук палати за номером
            HospitalRoom? foundRoom = Rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
            if (foundRoom == null)
            {
                Console.WriteLine($"Палата №{roomNumber} не знайдена!");
                return;
            }

            foundRoom.AddPatient(foundPatient);
        }

        // додавання медичного запису
        public void AddMedicalRecord(MedicalRecord record)
        {
            if (record == null)
            {
                Console.WriteLine("Помилка: спроба додати null медичний запис");
                return;
            }

            Records.Add(record);
            Console.WriteLine($"Медичний запис створено: {record.Patient.Name} -> {record.Doctor.Name}");
        }

        // отримання історії пацієнта
        public List<MedicalRecord> GetPatientHistory(int patientId)
        {
            return Records.Where(r => r.Patient.Id == patientId).ToList();
        }

        // отримання статистики
        public string GetStatistics()
        {
            int totalPatientsInRooms = Rooms.Sum(room => room.Patients.Count);

            return $"\n=== СТАТИСТИКА ЛІКАРНІ ===\n" +
                   $"Кількість лікарів: {Doctors.Count}\n" +
                   $"Кількість зареєстрованих пацієнтів: {Patients.Count}\n" +
                   $"Кількість палат: {Rooms.Count}\n" +
                   $"Кількість пацієнтів у палатах: {totalPatientsInRooms}\n" +
                   $"Кількість медичних записів: {Records.Count}\n";
        }
    }
}