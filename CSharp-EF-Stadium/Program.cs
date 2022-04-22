using CSharp_EF_Stadium.Data.Entities;
using System;

namespace CSharp_EF_Stadium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StadiumData stadiumData = new StadiumData();
            UsersData usersData = new UsersData();
            ReservationsData reservations = new ReservationsData();
            string ans = "";
            string stadiumName = "";
            string username = "";
            string email = "";
            string hourPriceStr;
            double hourPrice;
            string capacityStr;
            int capacity;
            string selectedIdStr;
            int selectedId;
            string startStr;
            DateTime start;
            string endStr;
            DateTime end;
            do
            {
                Console.WriteLine("1. Stadion elave et\n2. Stadionlari goster\n3. Verilmish id'li stadionu goster\n4. Verilmish id'li stadionu sil\n 5. İstifadeci elave et\n 6. İstifadecileri göster\n 7. Rezervasiyaları göster\n8. Rezervasiya yarat\n 9. Verilmiş id-li stadionun rezervasiyalarını göster\n0. Proqrami bitir");
                ans = Console.ReadLine();

                switch (ans)
                {
                    case "1":

                        do
                        {
                            Console.WriteLine("Stadion adini daxil edin: ");
                            stadiumName = Console.ReadLine();
                        } while (stadiumName.Length < 256 && String.IsNullOrEmpty(stadiumName));

                        do
                        {
                            Console.WriteLine("Stadionun saatliq qiymetini daxil edin: ");
                            hourPriceStr = Console.ReadLine();
                        } while (!double.TryParse(hourPriceStr, out hourPrice));

                        do
                        {
                            Console.WriteLine("Stadionun tutumunu yazin: ");
                            capacityStr = Console.ReadLine();
                        } while (!int.TryParse(capacityStr, out capacity));

                        Stadium stadium = new Stadium
                        {
                            Name = stadiumName,
                            HourPrice = hourPrice,
                            Capacity = capacity,
                        };


                        stadiumData.AddStadion(stadium);
                        break;
                    case "2":

                        foreach (var item in stadiumData.GetAllStadiums())
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - {item.HourPrice} - {item.Capacity}");
                        };

                        break;
                    case "3":


                        do
                        {
                            Console.WriteLine("Id daxil edin: ");
                            selectedIdStr = Console.ReadLine();
                        } while (!int.TryParse(selectedIdStr, out selectedId) && stadiumData.GetAllStadiums().Count < selectedId);

                        Console.WriteLine(stadiumData.GetStadiumById(selectedId).Name);

                        break;
                    case "4":


                        do
                        {
                            Console.WriteLine("Id daxil edin: ");
                            selectedIdStr = Console.ReadLine();
                        } while (!int.TryParse(selectedIdStr, out selectedId) && stadiumData.GetAllStadiums().Count < selectedId);

                        stadiumData.DeleteStadiumById(selectedId);

                        break;
                    case "5":
                        do
                        {
                            Console.WriteLine("User adini ve soyadini daxil edin: ");
                            username = Console.ReadLine();
                        } while (username.Length < 256 && String.IsNullOrEmpty(username));

                        do
                        {
                            Console.WriteLine("User emailini daxil edin: ");
                            email = Console.ReadLine();
                        } while (email.Length < 256 && String.IsNullOrEmpty(email));

                        Users users = new Users
                        {
                            FullName = username,
                            Email = email,
                        };


                        usersData.AddUser(users);
                        break;
                    case "6":
                        foreach (var item in usersData.GetAllUsers())
                        {
                            Console.WriteLine($"{item.Id} - {item.FullName} - {item.Email}");
                        };
                        break;
                    case "7":
                        foreach (var item in reservations.GetAllReservations())
                        {
                            Console.WriteLine($"reservation id: {item.Id} - stadium id: {item.StadiumId} - user id: {item.UserId} - bashlangic tarixi: {item.StartDate} - bitme tarixi: {item.EndDate}");
                        };
                        break;
                    case "8":
                        Reservations reservations1 = new Reservations();
                        Console.WriteLine("\n============Users============\n");
                        foreach (var item in usersData.GetAllUsers())
                        {
                            Console.WriteLine($"{item.Id} - {item.FullName} - {item.Email}");
                        };

                        do
                        {
                            Console.WriteLine("Id daxil edin: ");
                            selectedIdStr = Console.ReadLine();
                        } while (!int.TryParse(selectedIdStr, out selectedId) && usersData.GetAllUsers().Count < selectedId);
                        reservations1.UserId = selectedId;
                        Console.WriteLine("\n============Stadiums============\n");
                        foreach (var item in stadiumData.GetAllStadiums())
                        {
                            Console.WriteLine($"{item.Id} - {item.Name} - price: {item.HourPrice} - capacity: {item.Capacity}");
                        };

                        do
                        {
                            Console.WriteLine("Id daxil edin: ");
                            selectedIdStr = Console.ReadLine();
                        } while (!int.TryParse(selectedIdStr, out selectedId) && stadiumData.GetAllStadiums().Count < selectedId);
                        reservations1.StadiumId = selectedId;

                        do
                        {
                            Console.WriteLine("Rezervin bashlangic deyerini daxil edin: ");
                            startStr = Console.ReadLine();
                        } while (DateTime.TryParse(startStr,out start));
                        reservations1.StartDate = start;

                        do
                        {
                            Console.WriteLine("Rezervin bitme deyerini daxil edin: ");
                            endStr = Console.ReadLine();
                        } while (DateTime.TryParse(endStr, out end));
                        reservations1.EndDate = end;


                        reservations.AddReservation(reservations1);
                        break;
                    case "9":
                        do
                        {
                            Console.WriteLine("Id daxil edin: ");
                            selectedIdStr = Console.ReadLine();
                        } while (!int.TryParse(selectedIdStr, out selectedId) && reservations.GetAllReservations().Count < selectedId);

                        Console.WriteLine("id: " + reservations.GetReservationById(selectedId).Id + " - start date: " + reservations.GetReservationById(selectedId).StartDate + " - end date: " + reservations.GetReservationById(selectedId).EndDate);
                        break;
                    default:
                        Console.WriteLine("Duzgun deyer daxil edin: ");
                        break;
                }


            } while (ans!="0");
        }
    }
}
