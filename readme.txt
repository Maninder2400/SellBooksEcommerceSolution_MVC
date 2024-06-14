# Project Title: BookStore - E-commerce Platform for Buying and Selling Books

## Overview
BookStore is an e-commerce web application built using ASP.NET Core MVC with Razor Pages for authentication and authorization. It provides a platform for users to buy and sell books online. The project integrates Bootstrap with a Bootswatch theme for a responsive front-end, AJAX and jQuery for dynamic content loading, and Stripe for payment processing.

## Features
- User authentication and authorization using ASP.NET Core Identity.
- Responsive design with Bootstrap and Bootswatch theme.
- AJAX and jQuery for seamless user experience.
- Stripe payment integration.
- Facebook authentication (requires valid keys).
- Admin user creation on initial setup.

## Prerequisites
- .NET 8.0.301 SDK
- SQL Server
- Visual Studio 2022 or later / Visual Studio Code

## Getting Started

### Step 1: Clone the Repository
```sh
git clone https://github.com/yourusername/BookStore.git
cd BookStore
```

### Step 2: Set Up the Database
1. Update the connection string in `appsettings.json` to point to your SQL Server instance.
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=your_server_name;Database=BookStoreDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```
2. Run the database migrations to create the database schema.
   ```sh
   dotnet ef database update
   ```

### Step 3: Configure Stripe Keys
- Open `appsettings.json` and replace the placeholder Stripe keys with your own.
  ```json
  "Stripe": {
    "SecretKey": "your_stripe_secret_key",
    "PublishableKey": "your_stripe_publishable_key"
  }
  ```

### Step 4: Configure Facebook Authentication
- Facebook authentication will not work with the dummy keys provided. Replace them with your own valid keys in `Startup.cs`.

### Step 5: Build and Run the Project
```sh
dotnet build
dotnet run
```

### Admin User
An admin user will be automatically created upon first run. You can find the login credentials in the `DbInitializer` class located in the `DataAccess` folder.


## Notes
- Facebook authentication keys in the project are placeholders. Use your own keys for it to function correctly.
- Stripe payment integration requires valid Stripe keys. The keys provided in the project are placeholders and will not work.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
This project is licensed under the MIT License.

---

By following the steps above, you should be able to set up and run the BookStore project locally. If you encounter any issues, feel free to open an issue on GitHub. Happy coding!