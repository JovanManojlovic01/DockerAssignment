using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using BookFrontend.Models;

namespace BookFrontend.Services
{
    public class BookService
    {
        private readonly HttpClient _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Fetch all books
        public async Task<List<Book>> GetBooksAsync()
        {
            string apiURL = "http://192.168.1.167:5000/api/Books"; // Explicit port for API
            HttpResponseMessage response = await _httpClient.GetAsync(apiURL);

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Book>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        // Fetch a book by its ID
        public async Task<Book> GetBookByIdAsync(int id)
        {
            string apiURL = $"http://192.168.1.167:5000/api/Books/{id}";
            HttpResponseMessage response = await _httpClient.GetAsync(apiURL);

            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Book>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        // Add a new book
        public async Task AddBookAsync(Book book)
        {
            string apiURL = "http://192.168.1.167:5000/api/Books";
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(apiURL, book);

            response.EnsureSuccessStatusCode();
        }

        // Update an existing book
        public async Task UpdateBookAsync(Book book)
        {
            string apiURL = $"http://192.168.1.167:5000/api/Books/{book.Id}";
            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(apiURL, book);

            response.EnsureSuccessStatusCode();
        }

        // Delete a book by its ID
        public async Task DeleteBookAsync(int id)
        {
            string apiURL = $"http://192.168.1.167:5000/api/Books/{id}";
            HttpResponseMessage response = await _httpClient.DeleteAsync(apiURL);

            response.EnsureSuccessStatusCode();
        }
    }
}
