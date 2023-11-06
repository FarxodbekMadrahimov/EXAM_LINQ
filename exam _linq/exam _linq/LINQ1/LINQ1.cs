using System;
using System.Collections.Generic;
using System.Linq;

public class Mahsulot
{
    public string Nomi { get; set; }
    public double Narxi { get; set; }
}

public class Mijoz
{
    public int ID { get; set; }
    public string Ismi { get; set; }
}

public class Buyurtma
{
    public int MijozID { get; set; }
    public int Miqdori { get; set; }
}

class LINQ1
{
    public void LINQ()
    {
        
        List<Mahsulot> mahsulotlar = new List<Mahsulot>
        {
            new Mahsulot { Nomi = "Telefon", Narxi = 500 },
            new Mahsulot { Nomi = "Noutbuk", Narxi = 800 },
            new Mahsulot { Nomi = "Monitor", Narxi = 200 },
            new Mahsulot { Nomi = "Printer", Narxi = 100 }
        };

        
        List<Mijoz> mijozlar = new List<Mijoz>
        {
            new Mijoz { ID = 1, Ismi = "Ali" },
            new Mijoz { ID = 2, Ismi = "Vali" },
            new Mijoz { ID = 3, Ismi = "Hasan" }
        };

       
        List<Buyurtma> buyurtmalar = new List<Buyurtma>
        {
            new Buyurtma { MijozID = 1, Miqdori = 2 },
            new Buyurtma { MijozID = 2, Miqdori = 3 },
            new Buyurtma { MijozID = 3, Miqdori = 1 }
        };
        //LInq 1.1
        var arzonMahsulotlar = mahsulotlar.Where(m => m.Narxi < 50);
        
        foreach (var mahsulot in arzonMahsulotlar)
        {
            Console.WriteLine($"Nomi: {mahsulot.Nomi}, Narxi: {mahsulot.Narxi}");
        }

        //Linq 1.2
        var engYaqinNarx = mahsulotlar.OrderByDescending(m => m.Narxi).FirstOrDefault();
        
        Console.WriteLine($"Nomi: {engYaqinNarx.Nomi}, Narxi: {engYaqinNarx.Narxi}");

       //Linq 1.3
        var mijozlarBuyurtmalari = from mijoz in mijozlar
                                   join buyurtma in buyurtmalar on mijoz.ID equals buyurtma.MijozID
                                   select new
                                   {
                                       MijozIsmi = mijoz.Ismi,
                                       BuyurtmaMiqdori = buyurtma.Miqdori
                                   };
        foreach (var item in mijozlarBuyurtmalari)
        {
            Console.WriteLine($"Mijoz: {item.MijozIsmi}, Buyurtma miqdori: {item.BuyurtmaMiqdori}");
        }

        // Linq 1.4
        var mijozlarVaBuyurtmalar = from mijoz in mijozlar
                                    join buyurtma in buyurtmalar on mijoz.ID equals buyurtma.MijozID
                                    select new
                                    {
                                        MijozIsmi = mijoz.Ismi,
                                        BuyurtmaMiqdori = buyurtma.Miqdori,
                                        
                                    };
        foreach (var item in mijozlarVaBuyurtmalar)
        {
            Console.WriteLine($"Mijoz: {item.MijozIsmi}, Buyurtma miqdori: {item.BuyurtmaMiqdori}");
        }
    }
}
