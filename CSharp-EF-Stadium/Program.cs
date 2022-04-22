using CSharp_EF_Stadium.Data.Entities;
using System;

namespace CSharp_EF_Stadium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StadiumData stadiumData = new StadiumData();
            string ans = "";
            string stadiumName = "";
            string hourPriceStr;
            double hourPrice;
            string capacityStr;
            int capacity;
            string selectedIdStr;
            int selectedId;
            do
            {
                Console.WriteLine("1. Stadion elave et\n2. Stadionlari goster\n3. Verilmish id'li stadionu goster\n4. Verilmish id'li stadionu sil\n0. Proqrami bitir");
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
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Duzgun deyer daxil edin: ");
                        break;
                }


            } while (true);
        }
    }
}
