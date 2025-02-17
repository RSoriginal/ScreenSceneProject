# Screen Scene Cinema Project

Screen Scene is a RESTful web service built with ASP.NET Core, designed to manage a cinema's operations, including movies, schedules, ticket bookings, and user management. The API follows best practices in software development and includes Swagger for easy API documentation and testing.

# Features

- **Movie management** (CRUD operations)
- **Showtimes and schedules**
- **Movie rating, writing a comments**
- **Ticket reservations and user authentication**
- **API documentation with Swagger UI**

# Tech Stack

- **ASP.NET Core Web API**
- **Entity Framework Core** (EF Core)
- **Remote MS SQL Server**
- **Swagger API**
- **Authentication & Authorization (JWT)**

# Database structure

![Image alt](https://cdn.discordapp.com/attachments/1329935072794771520/1338214653485907968/hLPDJnin4BtpArOvLkB0bHDHI0egHAW9N2lZdOPH_16DPnkbfF-ziQq4PkFTFRJSUEzvFkQDlRa9h8WRQox0CVAk6lsOpXvnHOhHkt27WJtjHjNxHLLzgKx4VLrTLu49tIeHJ-JhHlCBK3Ym7zoVYrFSSTZCWRzx0-4OhXrbhYoq44zM6VmDzJatyKutHE3qRi7ARWQoJen2ArEZu_HFfDkr9Fboj.png?ex=67aa4504&is=67a8f384&hm=590088fa99103e8492dbb62b4f65d6b3ffd7f70ab71f192e5d4b5e7b45103622&)


# Setup Instructions

This project is connected to a **single remote database**, which is located on our server.
To **try** this project, you need to do the following:

1. **Clone the Repository:**
    ```bash
    git clone https://github.com/RSoriginal/ScreenSceneProject
    ```

2. **Restore Dependencies:**
    ```bash
    dotnet restore
    ```

3. **Update Database:**
    ```bash
    dotnet ef database update
    ```

4. **Run the Application:**
    ```bash
    dotnet run
    ```

5. **Open Swagger UI at:**
    ```bash
    http://localhost:7020/swagger
    ```

After this, you will be able to interact with the project using the **local database**.

## License

This project is licensed under the [MIT License](LICENSE).
