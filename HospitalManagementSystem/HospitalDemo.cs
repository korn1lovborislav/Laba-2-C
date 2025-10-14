using System;
using System.Collections.Generic;

namespace HospitalManagementSystem
{
   
    public class HospitalDemo
    {
      
        public void Run()
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");

            // Створення об'єкта лікарні
            Hospital hospital = new Hospital();

            // Додавання лікарів до системи
            Console.WriteLine("--- ДОДАВАННЯ ЛІКАРІВ ---");
            hospital.AddDoctor(new Doctor(1, "Іваненко Петро", "Хірург"));
            hospital.AddDoctor(new Doctor(2, "Петренко Ольга", "Терапевт"));
            hospital.AddDoctor(new Doctor(3, "Сидоренко Василь", "Кардіолог"));

            // Реєстрація пацієнтів
            Console.WriteLine("\n--- РЕЄСТРАЦІЯ ПАЦІЄНТІВ ---");
            hospital.RegisterPatient(new Patient(1, "Коваленко Тарас", 45));
            hospital.RegisterPatient(new Patient(2, "Мельник Юлія", 32));
            hospital.RegisterPatient(new Patient(3, "Шевченко Андрій", 28));
            hospital.RegisterPatient(new Patient(4, "Бондаренко Наталія", 60));

            // Створення палат
            Console.WriteLine("\n--- СТВОРЕННЯ ПАЛАТ ---");
            hospital.CreateRoom(new HospitalRoom(101, 2));
            hospital.CreateRoom(new HospitalRoom(102, 3));
            hospital.CreateRoom(new HospitalRoom(201, 1));

            // Госпіталізація пацієнтів
            Console.WriteLine("\n--- ГОСПІТАЛІЗАЦІЯ ---");
            hospital.HospitalizePatient(1, 101); 
            hospital.HospitalizePatient(2, 101); 
            hospital.HospitalizePatient(3, 102); 
            hospital.HospitalizePatient(4, 201); 

            // Створення медичних записів

            Console.WriteLine("\n--- МЕДИЧНІ ЗАПИСИ ---");

            // Отримання посилань на створених пацієнтів і лікарів
            Patient patient1 = hospital.Patients[0]; 
            Doctor doctor1 = hospital.Doctors[0]; 
            Doctor doctor2 = hospital.Doctors[1]; 

            hospital.AddMedicalRecord(new MedicalRecord(patient1, doctor1, DateTime.Now, "Планове обстеження"));
            hospital.AddMedicalRecord(new MedicalRecord(patient1, doctor2, DateTime.Now.AddDays(-5), "Консультація щодо загального самопочуття"));

            // Перегляд історії пацієнта

            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");
            var history = hospital.GetPatientHistory(1); // Історія пацієнта з ID=1 (Коваленко)
            foreach (var record in history)
            {
                Console.WriteLine($" Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($" Лікар: {record.Doctor.Name}");
                Console.WriteLine($" Опис: {record.Description}\n");
            }

            // Вивід статистики
            Console.WriteLine(hospital.GetStatistics());
        }
    }
}