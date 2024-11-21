using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsumeAp
{

    public class Customer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }

        public Customer(int id, string title, string author,string desc,decimal price,DateTime publishdate)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = desc;
            Price = price;
                PublishDate = publishdate;

        }

        public override string ToString()
        {
            return $"Id({Id}) - Name({Title}) - Author({Author}) - Description({Description}) - Price({Price}) - PublishDate({PublishDate})";
        }
    }
    class Program
    {
        // Act as a HTTP client
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {

            // Specify Web API base address
            client.BaseAddress = 
                new Uri("http://localhost:7241/api");
           
                      // Specify headers
            var val = "application/json";
            var media =
                new MediaTypeWithQualityHeaderValue(val);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(media);

            // Make the calls - POST, GET, UPDATE and DELETE
           /* try
            {*/
              /*  var book = new Book(10, "The book!", "Someone");
                var message = string.Empty;

                // create
                message = AddBook(book);
                Console.WriteLine($"Create: {message}");

                Console.WriteLine();*/

                // read
            /*    Console.WriteLine("List books:");
                List<Customer> books = GetBook();
                for (int i = 0; i < books.Count; i++)
                {
                    var lb = books[i];
                    Console.WriteLine($"{i + 1}: {lb}");
                }

                Console.WriteLine();*/

                List<Customer> b = GetSingle(3);
                Console.WriteLine($"Read: {b.FirstOrDefault()}");

                Console.WriteLine();

         /*   }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }*/

            Console.ReadLine();
        }

    
        private static List<Customer> GetSingle(int? id = null)
        {
            var action = $"api/CustomerController/{id}";
            var request =
                client.GetAsync(action);

            var response =
                request.Result.Content.
                ReadAsAsync<List<Customer>>();

            return response.Result;
        }

        
    }
}

