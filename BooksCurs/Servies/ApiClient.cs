
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using BooksCurs.models;

public class ApiClient
{
    #region Base
    private readonly HttpClient _httpClient;
    private string? _token;
    public static string? base_url;
    public static bool Auth { get; private set; } = false;
    public ApiClient()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri(base_url)};
    }
    public void SetToken(string token)
    {
        _token = token;
        _httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        Auth = true;
    }
    #endregion

    #region User

    public async Task<User?> RegisterUser(User user)
    {
        try
        {
            var requestData = new
            {
                name = user.name,
                lname = user.lname,
                fname = user.fname,
                login = user.login,
                password = user.password
            };

            var result = await PostAsync<User>("/api/register", requestData);

            if (result == null)
            {
                Console.WriteLine("Ошибка: полученные данные пусты.");
                return null;
            }

            return result;
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine("Ошибка HTTP-запроса:");
            Console.WriteLine(httpEx.Message);
            return null;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine("Ошибка обработки JSON:");
            Console.WriteLine(jsonEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла непредвиденная ошибка:");
            Console.WriteLine(ex.Message);
            return null;
        }
    }
    public async Task<string?> AuthorizeUser(User user)
    {
        try
        {
            var requestData = new { user.login, user.password };
            var result = await PostAsync<AuthResponse>("/api/login", requestData);

            if (result == null || string.IsNullOrEmpty(result.access_token))
            {
                Console.WriteLine("Ошибка: не удалось получить токен авторизации.");
                return null;
            }

            return result.access_token;
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine("Ошибка HTTP-запроса:");
            Console.WriteLine(httpEx.Message);
            return null;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine("Ошибка обработки JSON:");
            Console.WriteLine(jsonEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла непредвиденная ошибка:");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    #endregion

    #region Books
    public async Task<List<Book>?> GetAllBooks()
    {
        try
        {
            var result = await GetAsync<List<Book>>("/api/books");

            if (result == null)
            {
                Console.WriteLine("Ошибка: полученные данные пусты.");
                return null;
            }

            return result;
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine("Ошибка HTTP-запроса:");
            Console.WriteLine(httpEx.Message);
            return null;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine("Ошибка обработки JSON:");
            Console.WriteLine(jsonEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла непредвиденная ошибка:");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<Book?> GetBookById(int book_id)
    {
        try
        {
            var result = await GetAsync<Book>($"/api/books/{book_id}");

            if (result == null)
            {
                Console.WriteLine($"Ошибка: книга с ID {book_id} не найдена.");
                return null;
            }

            return result;
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine("Ошибка HTTP-запроса:");
            Console.WriteLine(httpEx.Message);
            return null;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine("Ошибка обработки JSON:");
            Console.WriteLine(jsonEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла непредвиденная ошибка:");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    #endregion

    #region Authors
    public async Task<List<Author>?> GetAllAuthors()
    {
        try
        {
            var result = await GetAsync<List<Author>>("/api/authors");

            if (result == null)
            {
                Console.WriteLine("Ошибка: полученные данные пусты.");
                return null;
            }

            return result;
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine("Ошибка HTTP-запроса:");
            Console.WriteLine(httpEx.Message);
            return null;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine("Ошибка обработки JSON:");
            Console.WriteLine(jsonEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла непредвиденная ошибка:");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<Author?> GetAuthorById(int author_id)
    {
        try
        {
            var result = await GetAsync<Author>($"/api/authors/{author_id}");

            if (result == null)
            {
                Console.WriteLine($"Ошибка: автор с ID {author_id} не найден.");
                return null;
            }

            return result;
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine("Ошибка HTTP-запроса:");
            Console.WriteLine(httpEx.Message);
            return null;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine("Ошибка обработки JSON:");
            Console.WriteLine(jsonEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла непредвиденная ошибка:");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    #endregion

    #region Genres
    public async Task<List<Genre>?> GetAllGenres()
    {
        try
        {
            var result = await GetAsync<List<Genre>>("/api/genres");

            if (result == null)
            {
                Console.WriteLine("Ошибка: полученные данные пусты.");
                return null;
            }

            return result;
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine("Ошибка HTTP-запроса:");
            Console.WriteLine(httpEx.Message);
            return null;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine("Ошибка обработки JSON:");
            Console.WriteLine(jsonEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла непредвиденная ошибка:");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<Genre?> GetGenreById(int genre_id)
    {
        try
        {
            var result = await GetAsync<Genre>($"/api/genres/{genre_id}");

            if (result == null)
            {
                Console.WriteLine($"Ошибка: жанр с ID {genre_id} не найден.");
                return null;
            }

            return result;
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine("Ошибка HTTP-запроса:");
            Console.WriteLine(httpEx.Message);
            return null;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine("Ошибка обработки JSON:");
            Console.WriteLine(jsonEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла непредвиденная ошибка:");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    #endregion

    #region author-publications
    public async Task<List<AuthorPublication>?> GetAllAuthorPublications()
    {
        try
        {
            var result = await GetAsync<List<AuthorPublication>>("/api/author-publications");

            if (result == null)
            {
                Console.WriteLine("Ошибка: список публикаций пуст.");
                return null;
            }

            return result;
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine("Ошибка HTTP-запроса:");
            Console.WriteLine(httpEx.Message);
            return null;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine("Ошибка обработки JSON:");
            Console.WriteLine(jsonEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла непредвиденная ошибка:");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<AuthorPublication?> GetAuthorPublicationsById(int publication_id)
    {
        try
        {
            var result = await GetAsync<AuthorPublication>($"/api/author-publications/{publication_id}");

            if (result == null)
            {
                Console.WriteLine($"Ошибка: публикации с ID {publication_id} не найдена.");
                return null;
            }

            return result;
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine("Ошибка HTTP-запроса:");
            Console.WriteLine(httpEx.Message);
            return null;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine("Ошибка обработки JSON:");
            Console.WriteLine(jsonEx.Message);
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла непредвиденная ошибка:");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    #endregion

    #region Helpers
    private async Task<T?> PostAsync<T>(string endpoint, object data)
    {
        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(endpoint, content);
        return await HandleResponse<T>(response);
    }
    private async Task<T?> GetAsync<T>(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);
        return await HandleResponse<T>(response);
    }

    private async Task<T?> HandleResponse<T>(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"API Error ({response.StatusCode}): {error}");
            return default;
        }
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
    #endregion

}
public class Program
{
    static async Task Main(string[] args)
    {
        ApiClient.base_url = "https://130861f3-a43f-485b-8481-b3f6f2d14ca4.tunnel4.com";
        const string testToken = "1|p6Kt8PWGJLUlWdoEtz1GR0CMZEwQHtWAtEmXoKFd07324be6";

        var apiClient = new ApiClient();
        apiClient.SetToken(testToken);

        #region Test RegisterUser
        //try
        //{
        //    Console.WriteLine("Начинаем регистрацию пользователя...");

        //    var newUser = new User
        //    {
        //        name = "John2",
        //        lname = "Doe2",
        //        fname = "MiddleName2",
        //        login = "johndoe3",
        //        password = "password1233",
        //        role_id = 1,
        //    };

        //    var registeredUser = await apiClient.RegisterUser(newUser);

        //    if (registeredUser != null)
        //    {
        //        Console.WriteLine("Пользователь успешно зарегистрирован.");
        //        Console.WriteLine($"ID: {registeredUser.user_id}, Логин: {registeredUser.login}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Не удалось зарегистрировать пользователя.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Произошла ошибка при регистрации пользователя:");
        //    Console.WriteLine($"Ошибка: {ex.Message}");

        //    if (ex is JsonException jsonEx)
        //    {
        //        Console.WriteLine("Ошибка в обработке JSON:");
        //        Console.WriteLine($"Ошибка: {jsonEx.Message}");
        //        Console.WriteLine($"Стек вызовов: {jsonEx.StackTrace}");
        //    }

        //    Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
        //}
        #endregion

        #region Test AuthorizeUser
        //try
        //{
        //    Console.WriteLine("Начинаем авторизацию пользователя...");

        //    User user = new User { login = "johndoe3", password = "password1233" };
        //    var token = await apiClient.AuthorizeUser(user);

        //    if (!string.IsNullOrEmpty(token))
        //    {
        //        Console.WriteLine("Пользователь успешно авторизован.");
        //        Console.WriteLine($"Токен: {token}");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Не удалось авторизовать пользователя.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Произошла ошибка при авторизации пользователя:");
        //    Console.WriteLine($"Ошибка: {ex.Message}");

        //    if (ex is JsonException jsonEx)
        //    {
        //        Console.WriteLine("Ошибка в обработке JSON:");
        //        Console.WriteLine($"Ошибка: {jsonEx.Message}");
        //        Console.WriteLine($"Стек вызовов: {jsonEx.StackTrace}");
        //    }

        //    Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
        //}
        #endregion





        #region Test GetAllBooks  
        //try
        //{
        //    Console.WriteLine("Начинаем запрос списка книг...");

        //    var books = await apiClient.GetAllBooks();

        //    if (books != null)
        //    {
        //        Console.WriteLine("Список книг получен успешно.");
        //        Console.WriteLine($"Количество книг: {books.Count}");

        //        foreach (var book in books)
        //        {
        //            Console.WriteLine($"ID: {book.book_id}, Название: {book.title}");
        //            Console.WriteLine($"Описание: {book.description}");
        //            Console.WriteLine($"Год издания: {book.year_of_publication.Year}");
        //            Console.WriteLine($"Обложка: {book.picture}");

        //            if (book.publication != null)
        //            {
        //                Console.WriteLine($"Издательство: {book.publication.title}, Адрес: {book.publication.address}");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Издательство: информация отсутствует");
        //            }

        //            if (book.user != null)
        //            {
        //                Console.WriteLine($"Добавил: {book.user.lname} {book.user.fname} ({book.user.login})");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Пользователь: информация отсутствует");
        //            }

        //            Console.WriteLine(new string('-', 40));
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Не удалось получить список книг.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Произошла ошибка при получении списка книг:");
        //    Console.WriteLine($"Ошибка: {ex.Message}");

        //    if (ex is JsonException jsonEx)
        //    {
        //        Console.WriteLine("Ошибка в обработке JSON:");
        //        Console.WriteLine($"Ошибка: {jsonEx.Message}");
        //        Console.WriteLine($"Стек вызовов: {jsonEx.StackTrace}");
        //    }

        //    Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
        //}
        #endregion

        #region Test GetBookById
        //try
        //{
        //    int book_id = 1;

        //    Console.WriteLine("Начинаем запрос книги по ID..."  + book_id);

        //    var book = await apiClient.GetBookById(book_id);

        //    if (book != null)
        //    {
        //        Console.WriteLine("Книга получена успешно.");
        //        Console.WriteLine($"ID: {book.book_id}, Название: {book.title}");
        //        Console.WriteLine($"Описание: {book.description}");
        //        Console.WriteLine($"Год издания: {book.year_of_publication.Year}");
        //        Console.WriteLine($"Обложка: {book.picture}");

        //        if (book.publication != null)
        //        {
        //            Console.WriteLine($"Издательство: {book.publication.title}, Адрес: {book.publication.address}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Издательство: информация отсутствует");
        //        }

        //        if (book.user != null)
        //        {
        //            Console.WriteLine($"Добавил: {book.user.lname} {book.user.fname} ({book.user.login})");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Пользователь: информация отсутствует");
        //        }

        //        Console.WriteLine(new string('-', 40));
        //    }
        //    else
        //    {
        //        Console.WriteLine("Не удалось получить информацию о книге.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Произошла ошибка при получении информации о книге:");
        //    Console.WriteLine($"Ошибка: {ex.Message}");

        //    if (ex is JsonException jsonEx)
        //    {
        //        Console.WriteLine("Ошибка в обработке JSON:");
        //        Console.WriteLine($"Ошибка: {jsonEx.Message}");
        //        Console.WriteLine($"Стек вызовов: {jsonEx.StackTrace}");
        //    }

        //    Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
        //}
        #endregion


        #region Test GetAllAuthors  

        //try
        //{
        //    Console.WriteLine("Начинаем запрос списка авторов...");

        //    var authors = await apiClient.GetAllAuthors();

        //    if (authors != null)
        //    {
        //        Console.WriteLine("Список авторов получен успешно.");
        //        Console.WriteLine($"Количество авторов: {authors.Count}");

        //        foreach (var author in authors)
        //        {
        //            Console.WriteLine($"ID: {author.author_id}, Имя: {author.name} {author.fname} {author.lname}");
        //            Console.WriteLine($"Биография: {author.biography}");
        //            Console.WriteLine($"Фото: {author.picture}");

        //            Console.WriteLine(new string('-', 40));
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Не удалось получить список авторов.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Произошла ошибка при получении списка авторов:");
        //    Console.WriteLine($"Ошибка: {ex.Message}");

        //    if (ex is JsonException jsonEx)
        //    {
        //        Console.WriteLine("Ошибка в обработке JSON:");
        //        Console.WriteLine($"Ошибка: {jsonEx.Message}");
        //        Console.WriteLine($"Стек вызовов: {jsonEx.StackTrace}");
        //    }

        //    Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
        //}

        #endregion

        #region Test GetAuthorById
        //try
        //{
        //    int author_id = 1;

        //    Console.WriteLine("Начинаем запрос автора по ID..." + author_id);

        //    var author = await apiClient.GetAuthorById(author_id);

        //    if (author != null)
        //    {
        //        Console.WriteLine("Автор получен успешно.");
        //        Console.WriteLine($"ID: {author.author_id}, Имя: {author.name} {author.fname} {author.lname}");
        //        Console.WriteLine($"Биография: {author.biography}");
        //        Console.WriteLine($"Изображение: {author.picture}");

        //        Console.WriteLine(new string('-', 40));
        //    }
        //    else
        //    {
        //        Console.WriteLine("Не удалось получить информацию об авторе.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Произошла ошибка при получении информации об авторе:");
        //    Console.WriteLine($"Ошибка: {ex.Message}");

        //    if (ex is JsonException jsonEx)
        //    {
        //        Console.WriteLine("Ошибка в обработке JSON:");
        //        Console.WriteLine($"Ошибка: {jsonEx.Message}");
        //        Console.WriteLine($"Стек вызовов: {jsonEx.StackTrace}");
        //    }

        //    Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
        //}
        #endregion



        #region Test GetAllGenres

        //try
        //{
        //    Console.WriteLine("Начинаем запрос списка жанров...");

        //    var genres = await apiClient.GetAllGenres();

        //    if (genres != null)
        //    {
        //        Console.WriteLine("Список жанров получен успешно.");
        //        Console.WriteLine($"Количество жанров: {genres.Count}");

        //        foreach (var genre in genres)
        //        {
        //            Console.WriteLine($"ID: {genre.genre_id}, Стиль: {genre.style}");
        //            Console.WriteLine($"Дата создания: {genre.created_at?.ToString() ?? "Нет данных"}");
        //            Console.WriteLine($"Дата обновления: {genre.updated_at?.ToString() ?? "Нет данных"}");

        //            Console.WriteLine(new string('-', 40));
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Не удалось получить список жанров.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Произошла ошибка при получении списка жанров:");
        //    Console.WriteLine($"Ошибка: {ex.Message}");

        //    if (ex is JsonException jsonEx)
        //    {
        //        Console.WriteLine("Ошибка в обработке JSON:");
        //        Console.WriteLine($"Ошибка: {jsonEx.Message}");
        //        Console.WriteLine($"Стек вызовов: {jsonEx.StackTrace}");
        //    }

        //    Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
        //}

        #endregion

        #region Test GetGenreById

        //try
        //{
        //    int genreId = 1; 
        //    Console.WriteLine($"Начинаем запрос жанра с ID {genreId}...");

        //    var genre = await apiClient.GetGenreById(genreId);

        //    if (genre != null)
        //    {
        //        Console.WriteLine("Жанр получен успешно.");
        //        Console.WriteLine($"ID: {genre.genre_id}, Стиль: {genre.style}");
        //        Console.WriteLine($"Дата создания: {genre.created_at?.ToString() ?? "Нет данных"}");
        //        Console.WriteLine($"Дата обновления: {genre.updated_at?.ToString() ?? "Нет данных"}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Не удалось получить жанр с ID {genreId}.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Произошла ошибка при получении жанра:");
        //    Console.WriteLine($"Ошибка: {ex.Message}");

        //    if (ex is JsonException jsonEx)
        //    {
        //        Console.WriteLine("Ошибка в обработке JSON:");
        //        Console.WriteLine($"Ошибка: {jsonEx.Message}");
        //        Console.WriteLine($"Стек вызовов: {jsonEx.StackTrace}");
        //    }

        //    Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
        //}

        #endregion


        #region Test GetAllAuthorPublications

        //try
        //{
        //    Console.WriteLine("Начинаем запрос всех публикаций авторов...");

        //    var publications = await apiClient.GetAllAuthorPublications();

        //    if (publications != null)
        //    {
        //        Console.WriteLine("Список публикаций получен успешно.");
        //        Console.WriteLine($"Количество публикаций: {publications.Count}");

        //        foreach (var publication in publications)
        //        {
        //            Console.WriteLine($"ID публикации: {publication.author_publications_id}");
        //            Console.WriteLine($"Название: {publication.title}");
        //            Console.WriteLine($"Тип публикации: {publication.type_of_publication}");
        //            Console.WriteLine($"Дата публикации: {publication.publication_date}");

        //            if (publication.author != null)
        //            {
        //                Console.WriteLine("Автор:");
        //                Console.WriteLine($"  ID: {publication.author.author_id}");
        //                Console.WriteLine($"  Имя: {publication.author.name} {publication.author.fname} {publication.author.lname}");
        //                Console.WriteLine($"  Биография: {publication.author.biography}");
        //                Console.WriteLine($"  Фото: {publication.author.picture}");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Автор не указан.");
        //            }

        //            Console.WriteLine(new string('-', 40));
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Не удалось получить список публикаций.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Произошла ошибка при получении списка публикаций:");
        //    Console.WriteLine($"Ошибка: {ex.Message}");

        //    if (ex is JsonException jsonEx)
        //    {
        //        Console.WriteLine("Ошибка в обработке JSON:");
        //        Console.WriteLine($"Ошибка: {jsonEx.Message}");
        //        Console.WriteLine($"Стек вызовов: {jsonEx.StackTrace}");
        //    }

        //    Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
        //}

        #endregion

        #region Test GetAuthorPublicationsById

        //try
        //{
        //    int _id = 1;
        //    Console.WriteLine($"Начинаем запрос публикации автора с ID {_id}...");

        //    var publication = await apiClient.GetAuthorPublicationsById(_id);

        //    if (publication != null)
        //    {
        //        Console.WriteLine($"Публикация автора с ID {_id} получена успешно.");
        //        Console.WriteLine($"ID публикации: {publication.author_publications_id}");
        //        Console.WriteLine($"Название: {publication.title}");
        //        Console.WriteLine($"Тип публикации: {publication.type_of_publication}");
        //        Console.WriteLine($"Дата публикации: {publication.publication_date}");

        //        if (publication.author != null)
        //        {
        //            Console.WriteLine("Автор:");
        //            Console.WriteLine($"  ID: {publication.author.author_id}");
        //            Console.WriteLine($"  Имя: {publication.author.name} {publication.author.fname} {publication.author.lname}");
        //            Console.WriteLine($"  Биография: {publication.author.biography}");
        //            Console.WriteLine($"  Фото: {publication.author.picture}");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Автор не указан.");
        //        }

        //        Console.WriteLine(new string('-', 40));
        //    }
        //    else
        //    {
        //        Console.WriteLine($"Не удалось получить публикацию для автора с ID {_id}.");
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Произошла ошибка при получении публикации автора:");
        //    Console.WriteLine($"Ошибка: {ex.Message}");

        //    if (ex is JsonException jsonEx)
        //    {
        //        Console.WriteLine("Ошибка в обработке JSON:");
        //        Console.WriteLine($"Ошибка: {jsonEx.Message}");
        //        Console.WriteLine($"Стек вызовов: {jsonEx.StackTrace}");
        //    }

        //    Console.WriteLine($"Стек вызовов: {ex.StackTrace}");
        //}

        #endregion



    }
}
   