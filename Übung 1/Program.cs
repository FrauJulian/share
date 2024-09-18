namespace LINQ
{
    class Program
    {
        public static void Main()
        {
            List<Product> products = new List<Product>
            {
                new Product(1, "Laptop", "Elektronik", 1200, new List<int> { 5, 4, 5 }, 1),
                new Product(2, "Smartphone", "Elektronik", 800, new List<int> { 4, 4, 3 }, 1),
                new Product(3, "T-Shirt", "Kleidung", 20, new List<int> { 5, 5, 5 }, 1),
                new Product(4, "Kaffeemaschine", "Haushalt", 150, new List<int> { 3, 4, 4 }, 1),
                new Product(5, "Buch", "Literatur", 15, new List<int> { 5, 5, 4 }, 1)
            };

            PrintInformation(products);
        }

        private static void PrintInformation(List<Product> products)
        {
            var categories = products
                             .OrderByDescending(product => product.Price)
                             .GroupBy(product => product.Category);


            foreach (var category in categories)
            {
                Console.WriteLine($"Kategorie: {category.Key}");
                Console.WriteLine("------------------");

                foreach (var product in category)
                {
                    Console.WriteLine($"ProduktID: {product.ID} Name: {product.Name} Preis: {product.Price} Bewertung: {product.Review.Average()}");
                }

                Console.WriteLine(" ");
            }

            var productReviews = products
                                 .Select(products => products);

            foreach (var product in productReviews)
            {
                if (product.Review.Average() >= 4)
                {
                    Console.WriteLine($"Das Produkt mit der ID {product.Review.Average()} und dem Namen {product.Name} hat eine Bewertung über 4! (Bewertung: {product.Review.Average()})");
                }

                if (product.Review.Average() >= 5)
                {
                    Console.WriteLine($"Das Produkt mit der ID {product.ID} und dem Namen {product.Name} hat eine Bewertung über 5! (Bewertung: {product.Review.Average()})");
                }
            }

            Console.WriteLine(" ");

            var averagePrice = products
                               .Select(products => products.Price)
                               .Average();

            Console.WriteLine($"Der durchschnittliche Preis aller gelisteten Produkte ist {averagePrice}!");

            Console.WriteLine(" ");

            var overallPrice = products
                               .Select(products => products.Price)
                               .Sum();

            Console.WriteLine($"Der Preis aller gelisteten Produkte ist {overallPrice}!");

            Console.WriteLine(" ");

            var electronicDevicesOverThousand = products
                                                .Where(products => products.Category == "Elektronik" && products.Price > 1000)
                                                .Select(products => products);

            foreach (var product in electronicDevicesOverThousand)
            {
                Console.WriteLine($"Das Produkt mit der ID {product.ID} und dem Namen {product.Name} hat einen Preis über 1000! (Preis: {product.Price})");
            }

            Console.WriteLine(" ");

            var expensiveProduct = products
                                   .OrderBy(products => products.Price)
                                   .Select(products => products)
                                   .Last();

            Console.WriteLine($"Das Produkt mit der ID {expensiveProduct.ID} und dem Namen {expensiveProduct.Name} ist das teuerste Produkt mit einem Preis von {expensiveProduct.Price}!");
        }
    }
}