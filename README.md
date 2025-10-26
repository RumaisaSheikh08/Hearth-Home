🏠 Hearth-Home
Hearth-Home is a full-stack eCommerce web application built with ASP.NET Core and Angular, designed to deliver a smooth shopping experience with a scalable architecture, secure APIs, and modern UI.

🧩 Overview
Hearth-Home enables users to browse products, manage their cart, and place orders securely.
The backend is powered by ASP.NET Core Web API using Entity Framework Core with SQL Server, while the frontend is a responsive Angular SPA that consumes RESTful APIs.
This project follows Clean Architecture principles — separating the presentation, business logic, and data layers for better maintainability and scalability.

🛠️ Tech Stack
Backend: ASP.NET Core, C#, Entity Framework Core, SQL Server, JWT Authentication
Frontend: Angular, TypeScript, HTML5, CSS3, RxJS
Tools / DevOps: Visual Studio, VS Code, Git, Postman

🚀 Features
🔐 Secure user authentication and authorization (JWT)
🛒 Product catalog with search and filtering
🧾 Shopping cart and checkout flow
💳 Order history per user
🧱 Layered architecture for clean separation of concerns
⚙️ RESTful API integration between frontend & backend

📂 Project Structure
Hearth-Home/
│
├── Backend/      → ASP.NET Core Web API (C#, EF Core, SQL Server)
└── Frontend/     → Angular SPA (TypeScript, HTML, CSS)

⚙️ Setup Instructions
🔹 Backend
    1. Navigate to the backend folder
       cd Backend
    2. Update the SQL Server connection string in appsettings.json
    3. Run the following commands:
        dotnet restore
        dotnet ef database update
        dotnet run
    4. The API runs at https://localhost:5001
🔹 Frontend
    1. Navigate to the frontend folder
       cd Frontend
    2. Install dependencies and start the Angular app:
        npm install
        ng serve
    3. Open http://localhost:4200 in your browser

🧭 Future Enhancements
    🧑‍💼 Admin dashboard for managing products and orders
    ☁️ Cloud deployment (Azure / AWS)
    🧩 Microservices for payments and inventory
    🐳 Docker + Kubernetes support
    🔄 CI/CD pipeline with GitHub Actions or Azure DevOps
👩‍💻 Author
    Rumaisa Sheikh
    📍 Dubai, UAE
    💼 https://www.linkedin.com/in/rumaisa-sheikh-41b855227/
    📧 rumaisasheikh08@outlook.com
    ⭐ If you like this project, consider giving it a star on GitHub to show your support!
