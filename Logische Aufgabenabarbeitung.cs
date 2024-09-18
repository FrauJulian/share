namespace Program
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
            var categories = (from product in products
                              orderby product.Price descending
                              select new
                              {
                                  ProductID = product.ProductID,
                                  Name = product.Name,
                                  Category = product.Category,
                                  Price = product.Price,
                                  AverageReview = product.Review.Average(),
                              }).GroupBy(product => product.Category).ToList();

            foreach (var category in categories)
            {
                Console.WriteLine($"Kategorie: {category.Key}");
                Console.WriteLine("------------------");

                foreach (var product in category)
                {
                    Console.WriteLine($"ProduktID: {product.ProductID} Name: {product.Name} Preis: {product.Price} Bewertung: {product.AverageReview}");
                }

                Console.WriteLine(" ");
            }

            var productReviews = (from product in products
                                  select new
                                  {
                                      ProductID = product.ProductID,
                                      Name = product.Name,
                                      AverageReview = product.Review.Average()
                                  }).ToList();

            foreach (var product in productReviews)
            {
                if (product.AverageReview >= 4)
                {
                    Console.WriteLine($"Das Produkt mit der ID {product.ProductID} und dem Namen {product.Name} hat eine Bewertung über 4! (Bewertung: {product.AverageReview})");
                }

                if (product.AverageReview >= 5)
                {
                    Console.WriteLine($"Das Produkt mit der ID {product.ProductID} und dem Namen {product.Name} hat eine Bewertung über 5! (Bewertung: {product.AverageReview})");
                }
            }

            Console.WriteLine(" ");

            var averagePrice = (from product in products
                                select product.Price).Average();

            Console.WriteLine($"Der durchschnittliche Preis aller gelisteten Produkte ist {averagePrice}!");

            Console.WriteLine(" ");

            var overallPrice = (from product in products
                                select product.Price * product.Amount).Sum();

            Console.WriteLine($"Der Preis aller gelisteten Produkte ist {overallPrice}!");

            Console.WriteLine(" ");

            var electronicDevicesOverThousand = (from product in products
                                                 where product.Category == "Elektronik" && product.Price > 1000
                                                 select product).ToList();

            foreach (var product in electronicDevicesOverThousand)
            {
                Console.WriteLine($"Das Produkt mit der ID {product.ProductID} und dem Namen {product.Name} hat einen Preis über 1000! (Preis: {product.Price})");
            }

            Console.WriteLine(" ");

            var expensiveProduct = (from product in products
                                    orderby product.Price
                                    select product).Last();

            Console.WriteLine($"Das Produkt mit der ID {expensiveProduct.ProductID} und dem Namen {expensiveProduct.Name} ist das teuerste Produkt mit einem Preis von {expensiveProduct.Price}!");
        }

        class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public List<int> Review { get; set; }
            public int Amount { get; set; }

            public Product(int productID, string name, string category, decimal price, List<int> review, int amount)
            {
                ProductID = productID;
                Name = name;
                Category = category;
                Price = price;
                Review = review;
                Amount = amount;
            }
        }
    }
}
