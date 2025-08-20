# LibraryProgram

A C# project for managing a network of libraries, developed as a learning side project and later for a university assignment. The application allows users to browse available books in each library, rate and review books, and provides an admin panel for editing database records and managing library operations.

## Features

- Display all books available in each library location
- Users can rate and write reviews for books
- Simple book search functionality
- Admin panel for editing any data from the database
  - Multi-select and batch delete functionality
- Built-in user and admin roles

## Technologies Used

- **C#** (models and business logic)
- **WebAPI** (server/backend)
- **MySQL** (database)
- **WinForms** (client UI)
  - Note: The choice of WinForms limited some features due to its functionality constraints and limited UI variety

## Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/ghy4/LibraryProgram.git
   ```

2. **Configure Database Connection:**
   - Update the database connection string in User Secrets for both the `Database` and `Server` folders.

3. **Run the Server:**
   - Navigate to the Server project directory and run the server.

4. **Run the WinForms Project:**
   - Open the solution in Visual Studio (or your preferred C# IDE).
   - Set the WinForms project as the startup project and run it.

## Usage

- Users can browse books, rate and review them.
- Admins can access the admin panel to edit data, use the multi-select feature to delete records, and manage library operations.

## Contributing

Contributions are welcome! Please open issues or pull requests with suggestions or improvements.

## License

This project is licensed under the MIT License.

## Contact

For questions or suggestions, please contact via [GitHub](https://github.com/ghy4).

---

Feel free to suggest additional features or improvements!
