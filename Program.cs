using System.Collections.Generic;
namespace CollectionsApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var egypt = new Country { ISOCode = "EGY", Name = "Egypt" };
            var jordan = new Country { ISOCode = "JOR", Name = "Jordan" };
            var iraq = new Country { ISOCode = "IRQ", Name = "Iraq" };
            Country[] countriesArray = { egypt, jordan, iraq };
            //Constructors 
            //  List<Country> countries = new List<Country>();
            // List<Country> countries = new List<Country>(3);
            List<Country> countries = new List<Country>(countriesArray);
            Print(countries);
            //Properties
            //Methods
            countries.Add(new Country { ISOCode = "BRA", Name = "Brasil" });
            //countries.AddRange(countriesArray);
            
            countries.Insert(1, new Country { ISOCode = "FRA", Name = "France" });//O(n)
            Print(countries);
            countries.RemoveAt(4);
            countries.RemoveAll(x => x.Name.EndsWith("ce"));
            countries.Remove(new Country { ISOCode = "IRQ", Name = "Iraq" });
            Print(countries);
        }
        static void Print(List<Country> countries)
        {
            foreach (var c in countries)
            {
                Console.WriteLine(c);
            }
            //Properties
            Console.WriteLine($"Count{countries.Count}" ); //actual count
            Console.WriteLine($"Capacity:{countries.Capacity}");//initial 
        }
        }
        class Country {
        public string ISOCode { get; set; }
        public string Name { get; set; }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 19;
                hash = hash * 397 +ISOCode.GetHashCode();
                hash =hash*397+Name.GetHashCode();
            }
            return base.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
          var  country = obj as Country;
            if (country == null) //better than country == null
                return false;
            return this.Name.Equals(country.Name,StringComparison.OrdinalIgnoreCase)
                && this.ISOCode.Equals(country.ISOCode,StringComparison.OrdinalIgnoreCase)
                ;
        }
        public override string ToString()
        {
            return $"{Name}({ISOCode})";//Egypt (EGY)

        }
    }

    
}