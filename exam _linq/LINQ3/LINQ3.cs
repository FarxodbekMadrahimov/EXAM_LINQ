namespace exam_linq3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Mijoz
    {
        public string Ismi { get; set; }
        public string Familiya { get; set; }
        public int ID { get; set; }
    }

    public class Mahsulot
    {
        public string Nomi { get; set; }
        public double Narxi { get; set; }
    }

    public class Buyurtma
    {
        public int MijozID { get; set; }
        public int Miqdori { get; set; }
        public DateTime Sana { get; set; }
    }

    public class Oquvchilar
    {
        public string Ismi { get; set; }
        public List<string> Darslar { get; set; }
    }

    public class LINQ
    {
        public void LINQ3()
        {
            List<Mijoz> mijozlar = new List<Mijoz>
        {
            new Mijoz { Ismi = "Ali", Familiya = "Aliyev", ID = 1 },
            new Mijoz { Ismi = "Vali", Familiya = "Valiyev", ID = 2 },
            new Mijoz { Ismi = "Hasan", Familiya = "Hasanov", ID = 3 }
        };

            List<Mahsulot> mahsulotlar = new List<Mahsulot>
        {
            new Mahsulot { Nomi = "Telefon", Narxi = 500 },
            new Mahsulot { Nomi = "Noutbuk", Narxi = 800 },
            new Mahsulot { Nomi = "Monitor", Narxi = 200 },
            new Mahsulot { Nomi = "Printer", Narxi = 100 }
        };

            List<Buyurtma> buyurtmalar = new List<Buyurtma>
        {
            new Buyurtma { MijozID = 1, Miqdori = 2, Sana = new DateTime(2023, 11, 6) },
            new Buyurtma { MijozID = 2, Miqdori = 3, Sana = new DateTime(2023, 11, 7) },
            new Buyurtma { MijozID = 3, Miqdori = 1, Sana = new DateTime(2023, 11, 8) }
        };

            List<Oquvchilar> oquvchilar = new List<Oquvchilar>
        {
            new Oquvchilar { Ismi = "Ali", Darslar = new List<string> { "Matematika", "Fizika" } },
            new Oquvchilar { Ismi = "Vali", Darslar = new List<string> { "Informatika", "Ingliz tili" } },
            new Oquvchilar { Ismi = "Hasan", Darslar = new List<string> { "Tarix", "Geografiya" } }
        };

            // Buyurtmalar va mijozlar bilan bog'langan yangi ro'yxat
            var mijozlarVaBuyurtmalar = from mijoz in mijozlar
                                        join buyurtma in buyurtmalar on mijoz.ID equals buyurtma.MijozID
                                        select new
                                        {
                                            MijozIsmi = mijoz.Ismi,
                                            BuyurtmaMiqdori = buyurtma.Miqdori,
                                            BuyurtmaSana = buyurtma.Sana
                                        };

            Console.WriteLine("Mijozlar va buyurtmalar:");
            foreach (var item in mijozlarVaBuyurtmalar)
            {
                Console.WriteLine($"Mijoz: {item.MijozIsmi}, Buyurtma miqdori: {item.BuyurtmaMiqdori}, Sana: {item.BuyurtmaSana}");
            }

            // Qolgan funksiyalar
            var juftRaqamlar = GetJuftRaqamlar(mijozlar.Select(m => m.ID).ToList());
            var mijozlarIsmiFamiliyasi = GetMijozIsmiFamiliyasi(mijozlar);
            var oquvchilarVaDarslar = GetOquvchilarVaDarslar(oquvchilar);

            Console.WriteLine("Juft raqamlar: " + string.Join(", ", juftRaqamlar));
            Console.WriteLine("Mijozlar ismi va familiyasi:");
            foreach (var mijoz in mijozlarIsmiFamiliyasi)
            {
                Console.WriteLine($"{mijoz.Ismi} {mijoz.Familiya}");
            }
            Console.WriteLine("O'quvchilar va ularning darslari:");
            foreach (var oquvchi in oquvchilarVaDarslar)
            {
                Console.WriteLine($"{oquvchi.Ismi}: {string.Join(", ", oquvchi.Darslar)}");
            }
        }

        // Qolgan funksiyalar
        public static List<int> GetJuftRaqamlar(List<int> raqamlar)
        {
            return raqamlar.Where(r => r % 2 == 0).ToList();
        }

        public static List<Mijoz> GetMijozIsmiFamiliyasi(List<Mijoz> mijozlar)
        {
            return mijozlar.Select(m => new Mijoz { Ismi = m.Ismi, Familiya = m.Familiya }).ToList();
        }

        public static List<Oquvchilar> GetOquvchilarVaDarslar(List<Oquvchilar> oquvchilar)
        {
            return oquvchilar.Select(o => new Oquvchilar { Ismi = o.Ismi, Darslar = o.Darslar }).ToList();
        }
    }

}