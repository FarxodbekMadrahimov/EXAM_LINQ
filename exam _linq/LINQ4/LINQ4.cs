using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam__linq
{
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

    public class LINQ4
    {
         void LINQ()
        {
            List<int> raqamlar = new List<int> { 7, 1, 5, 4, 9, 2, 8, 6, 3, 10 };

            // 4.1. Berilgan raqamlar ro'yxatini tartiblangan tartibda qaytarish
            var tartiblanganRaqamlar = raqamlar.OrderBy(r => r).ToList();
            Console.WriteLine("4.1. Tartiblangan raqamlar: " + string.Join(", ", tartiblanganRaqamlar));

            List<Mijoz> mijozlar = new List<Mijoz>
        {
            new Mijoz { Ismi = "Ali", Familiya = "Aliyev", ID = 1 },
            new Mijoz { Ismi = "Vali", Familiya = "Valiyev", ID = 2 },
            new Mijoz { Ismi = "Hasan", Familiya = "Hasanov", ID = 3 }
        };

            // 4.2. Berilgan mijozlar ro'yxatini familiya bo'yicha tartiblangan tartibda chiqarish
            var tartiblanganMijozlar = mijozlar.OrderBy(m => m.Familiya).ToList();
            Console.WriteLine("4.2. Tartiblangan mijozlar bo'yicha: ");
            foreach (var mijoz in tartiblanganMijozlar)
            {
                Console.WriteLine($"{mijoz.Familiya}, {mijoz.Ismi}");
            }

            List<Mahsulot> mahsulotlar = new List<Mahsulot>
        {
            new Mahsulot { Nomi = "Telefon", Narxi = 500 },
            new Mahsulot { Nomi = "Noutbuk", Narxi = 800 },
            new Mahsulot { Nomi = "Monitor", Narxi = 200 },
            new Mahsulot { Nomi = "Printer", Narxi = 100 }
        };

            // 4.3. Berilgan mahsulotlar ro'yxatini narxi bo'yicha kamayish tartibida tartiblangan ro'yxatga o'tkazing
            var tartiblanganMahsulotlar = mahsulotlar.OrderBy(m => m.Narxi).ToList();
            Console.WriteLine("4.3. Tartiblangan mahsulotlar narxi bo'yicha: ");
            foreach (var mahsulot in tartiblanganMahsulotlar)
            {
                Console.WriteLine($"{mahsulot.Nomi}, {mahsulot.Narxi} USD");
            }

            List<Buyurtma> buyurtmalar = new List<Buyurtma>
        {
            new Buyurtma { MijozID = 1, Miqdori = 2, Sana = new DateTime(2023, 11, 6) },
            new Buyurtma { MijozID = 2, Miqdori = 3, Sana = new DateTime(2023, 11, 7) },
            new Buyurtma { MijozID = 3, Miqdori = 1, Sana = new DateTime(2023, 11, 8) }
        };

            // 4.4. Berilgan mijozlar va buyurtmalar ro'yxatlari orqali mijozlarni buyurtmalar soni bo'yicha kamayish tartibida tartiblangan mijozlar ro'yxatini olish
            var tartiblanganMijozlarBuyurtmaSoniBoyicha = from mijoz in mijozlar
                                                            join buyurtma in buyurtmalar on mijoz.ID equals buyurtma.MijozID
                                                        group buyurtma by new { mijoz.Ismi, mijoz.Familiya } into mijozBuyurtmalar
                                                            orderby mijozBuyurtmalar.Sum(b => b.Miqdori)
                                                            select new
                                                        {
                                                            MijozIsmi = mijozBuyurtmalar.Key.Ismi,
                                                            MijozFamiliya = mijozBuyurtmalar.Key.Familiya,
                                                            BuyurtmaSoni = mijozBuyurtmalar.Sum(b => b.Miqdori)
                                                        };

            Console.WriteLine("4.4. Tartiblangan mijozlar buyurtma soni bo'yicha: ");
            foreach (var mijoz in tartiblanganMijozlarBuyurtmaSoniBoyicha)
            {
                Console.WriteLine($"{mijoz.MijozFamiliya}, {mijoz.MijozIsmi}, Buyurtma soni: {mijoz.BuyurtmaSoni}");
            }
        }
    }

}
