# 📚 Book Store Website  

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)]()  [![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-5C2D91?logo=dotnet&logoColor=white)]()  [![Entity Framework](https://img.shields.io/badge/Entity%20Framework-ORM-success)]()  [![Bootstrap](https://img.shields.io/badge/Bootstrap-5-563D7C?logo=bootstrap&logoColor=white)]()  [![SQL Server](https://img.shields.io/badge/SQL%20Server-DB-red?logo=microsoftsqlserver&logoColor=white)]()  [![Azure](https://img.shields.io/badge/Deploy-Azure-blue?logo=microsoftazure&logoColor=white)]()  

An **ASP.NET Core MVC Book Store application** with authentication, authorization, shopping cart, Stripe payment integration, and full content management system for books, categories, companies, and users.  

⚠️ **Note**: This project is currently in development. Features listed below are in-progress and may not yet be fully implemented.  

---

## 🚀 Deployment (Coming Soon)  
The project will be deployed on **Microsoft Azure**.  

🔗 Live Demo: *(Coming soon...)*  

---

## 📸 Preview  
*(Screenshots & GIFs will be added once UI is finalized)*  

---

## ✨ Features  

### 🛒 Customer Side  
- **Home Page** → Displays available books with cover image, title, price, and detail button.  
- **Book Detail Page** → Shows title, description, price, quantity, and add-to-cart option.  
- **Shopping Cart** → Displays selected books, allows quantity updates, calculates total.  
- **Checkout Page**  
  - Shipping details form.  
  - Order summary with **estimated arrival date**.  
  - Redirects to **Stripe Checkout** for secure payment.  
  - Confirmation page after successful order.  
- **Manage Orders** → View past orders with detailed summaries and statuses.  

### 🔑 Authentication & Authorization  
- User registration with **email/password** or **Facebook login**.  
- Secure login with **Identity Framework**.  
- Role-based authorization (Customer, Employee, Admin, Company).  

### 🛠️ Admin Side  
- **Content Management Navbar** (visible only to admins).  
- **Category Management** → Create, update, delete categories.  
- **Product Management**  
  - List books with Title, ISBN, Price, Author, Category.  
  - Edit book details with a text editor + image upload.  
  - Create new products or delete existing ones.  
- **Company Management** → Create, update, delete companies.  
- **User Management** → Admin can create users and assign roles.  

### 📩 Notifications  
- Email notifications for order confirmation.  
- Toast notifications for user interactions (add/update/delete).  

---

## 🛠️ Tech Stack  
- **Frameworks:** ASP.NET Core 8, ASP.NET Core MVC, Razor Pages
- **Database:** SQL Server + Entity Framework Core  
- **Authentication:** Identity Framework  
- **Frontend:** HTML, CSS, Bootstrap  
- **Payments:** Stripe API  
- **Tools:** Visual Studio 2022, SQL Server Management Studio (SSMS)  
- **Deployment:** Microsoft Azure  

---

## 📌 Future Plans  
- Add advanced search & filtering for books.  
- Implement order tracking system with real-time status updates.  
- Add wishlists & favorites.  
- Multi-language support.  
- Recommendation engine (e.g., “Customers also bought…”).  

---

## ⚡ Getting Started  


1. Clone the repository:
   ```bash
   git clone https://github.com/Elvin308/OnlineBookStore.git
2. Open the project in **Visual Studio 2022**.  
3. Open the **appsettings.json** file and configure your **database connection string**.  
4. Open the **Package Manager Console** (Tools → NuGet Package Manager → Package Manager Console).  
5. Make sure the **Default Project** in PMC is set to your ASP.NET Core project.  
6. Run the following command to apply migrations and create the database:  
   ```powershell
   Update-Database
7. Press F5 to run the project locally (or Ctrl + F5 to run without debuggin

## 👤 Author
Created by Elvin Martinez
