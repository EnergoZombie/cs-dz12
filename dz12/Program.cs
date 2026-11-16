namespace dz12
{
    internal class Program
    {
        class Play : IDisposable
        {
            public string Title { get; set; }
            public string Genre { get; set; }
            public string Author { get; set; }
            public int Date { get; set; }

            public Play(string title, string genre, string author, int date)
            {
                Title = title; Genre = genre; Author = author; Date = date;
            }
            public override string ToString() { return $"{Title} by {Author} | Genre: {Genre} | {Date}";}

            ~Play()
            {
                Console.WriteLine("Play object was deleted");
            }
            public void Dispose()
            {
                Console.WriteLine("Play object was disposed");
            }
        }

        enum ShopType
        {
            Grocery, Household, Clothing, Footwear
        }

        class Shop : IDisposable
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public ShopType Type { get; set; }

            public Shop(string name, string address, ShopType type)
            {
                Name = name; Address = address; Type = type;
            }

            public override string ToString() { return $"{Name} | {Address} | {Type}"; }

            public void Dispose()
            {
                Console.WriteLine("Shop object was disposed");
            }

            ~Shop()
            {
                Console.WriteLine("Shop object was deleted");
            }
        }

        static void Temp()
        {
            Play play = new Play("title", "genre", "author", 2024);
            Shop shop = new Shop("name", "address", ShopType.Clothing);
            Console.WriteLine(play);
            Console.WriteLine(shop);
            shop.Dispose();
            play.Dispose();
        }

        static void Main(string[] args)
        {
            Temp();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
