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

            PriceOverThounds(products);
            Console.WriteLine(" ");
            AveragePrice(products);
            Console.WriteLine(" ");
            AverageReview(products);
            Console.WriteLine(" ");
            CategoryProducts(products);
            Console.WriteLine(" ");
            HighestPrice(products);
            Console.WriteLine(" ");
            ProductsWith4PlusStars(products);
            Console.WriteLine(" ");
            SortAndPrint(products);
            Console.WriteLine(" ");
            ReviewsOver5(products);
            Console.WriteLine(" ");
            OverallPrice(products);

        }

        private static void PriceOverThounds(List<Product> products)
        {
            var electronicProducts = (from product in products
                                      where product.Category == "Elektronik" && product.Price >= 1000
                                      select product).ToList();

            foreach (var product in electronicProducts)
            {
                Console.WriteLine($"Elektronisches Produkt mit einem Preis über 1000 mit der ID {product.ProductID} und dem namen {product.Name} wurde gefunden!");
            }
        }

        private static void AveragePrice(List<Product> products)
        {
            var averagePrice = (from product in products
                                select product.Price).Average();

            Console.WriteLine($"Der Durchschnittliche Preis aller gelisteten Produkte ist {averagePrice}!");
        }

        private static void AverageReview(List<Product> products)
        {
            var productReviews = (from product in products
                                  select new
                                  {
                                      ProductID = product.ProductID,
                                      Name = product.Name,
                                      AverageReview = product.Review.Average()
                                  }).ToList();

            foreach (var product in productReviews)
            {
                Console.WriteLine($"Das Produkt mit der ID {product.ProductID} und dem Namen {product.Name} hat eine durchschnittliche Bewertung von {product.AverageReview}!");
            }
        }

        private static void CategoryProducts(List<Product> products)
        {
            var categories = from product in products
                             group product by product.Category;

            foreach (var category in categories)
            {
                Console.WriteLine($"Kategorie: {category.Key}");
                Console.WriteLine("---------");

                foreach (Product product in category)
                {
                    Console.WriteLine($"ID: {product.ProductID} Name: {product.Name} Preis: {product.Price}");
                }

                Console.WriteLine(" ");
            }
        }

        private static void HighestPrice(List<Product> products)
        {
            var expensiveProduct = (from product in products
                                    orderby product.Price
                                    select product).Last();

            Console.WriteLine($"Das teuerste Produkt ist der {expensiveProduct.Name} mit der ID {expensiveProduct.ProductID} und dem Preis {expensiveProduct.Price}!");
        }

        private static void ProductsWith4PlusStars(List<Product> products)
        {
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
                    Console.WriteLine($"Das Produkt mit der ID {product.ProductID} und dem Namen {product.Name} hat eine durchschnittliche Bewertung von {product.AverageReview}!");
                }
            }
        }

        private static void SortAndPrint(List<Product> products)
        {
            var productList = from product in products
                              orderby product.Price descending
                              select product;

            foreach (var product in productList)
            {
                Console.WriteLine($"Name: {product.Name} Preis: ${product.Price}");
            }
        }

        private static void ReviewsOver5(List<Product> products)
        {
            var productReviews = (from product in products
                                  select new
                                  {
                                      ProductID = product.ProductID,
                                      Name = product.Name,
                                      AverageReview = product.Review.Average()
                                  }).ToList();

            foreach (var product in productReviews)
            {
                if (product.AverageReview == 5)
                {
                    Console.WriteLine($"Das Produkt mit der ID {product.ProductID} und dem Namen {product.Name} hat eine Bewertung von {product.AverageReview}!");
                }
            }
        }

        private static void Categories(List<Product> products)
        {
            var categories = from product in products
                             group product by product.Category;

            foreach (var category in categories)
            {
                Console.WriteLine($"Kategorie: {category.Key}");
            }
        }

        private static void OverallPrice(List<Product> products)
        {
            var gesamtwert = (from product in products
                              select product.Price * product.Amount).Sum();

            Console.WriteLine($"Der Gesamtwert aller Produkte im Lager beträgt: {gesamtwert} Euro");
        }
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
