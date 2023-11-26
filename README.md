# Work Schedule System

The Work Schedule System is a .NET Core-based application designed to streamline the scheduling process for workers. It provides platform for managing work schedules, helping both employees and managers to coordinate tasks and track work hours effectively.

## Features

- **User Authentication**: Secure user authentication system to ensure only authorized personnel can access and modify schedules.

- **Schedule Management**: Easily create, update, and view work schedules for employees.


## Technologies Used

- **.NET Core**: The backend framework for building scalable and modular applications.

- **ASP.NET Core MVC**: A powerful framework for building dynamic web applications.

- **Entity Framework Core**: An Object-Relational Mapping (ORM) framework for database operations.

- **SQL Server**: The database management system for storing and retrieving schedule data.

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/your-username/work-schedule-system.git
    ```

2. Navigate to the project directory:

    ```bash
    cd work-schedule-system
    ```

3. Restore dependencies and build the project:

    ```bash
    dotnet restore
    ```

4. Update the database with migrations:

    ```bash
    dotnet ef database update
    ```

5. Run the application:

    ```bash
    dotnet run
    ```

6. Access the application in your web browser at `http://localhost:5000`.

## User Roles and Capabilities

The Work Schedule System includes two distinct user roles, each with specific capabilities:

### Worker Role:

Workers are responsible for their schedule submissions. Their main capabilities include:

- **Viewing Schedules**: Workers can view their own schedules to check upcoming shifts and important information.

- **Submitting Schedule Requests**: Workers have the ability to submit schedule requests, such as time-off requests or shift change requests.

### Admin Role:

Admins have broader control over the work schedule system. Their main capabilities include:

- **Viewing All Schedules**: Admins can view schedules for all workers, allowing them to oversee the entire work schedule.

- **Approving or Declining Schedule Requests**: Admins have the authority to approve or decline schedule requests submitted by workers.

- **User Management**: Admins can manage user accounts, including adding new workers, deactivating accounts, and updating user roles.

It's important to note that the capabilities mentioned above are based on the default settings of the Work Schedule System. Depending on the specific requirements of your organization, these roles and capabilities can be customized further.

## Default Login Credentials

To access the Work Schedule System, you can use the following default login credentials:

### Worker Account:

- **Email:** worker@example.com
- **Password:** worker@123

### Admin Account:

- **Email:** admin@example.com
- **Password:** Admin@123

