# 🛒 IIH Ordering System API

A backend ordering and e-commerce system built with Clean Architecture and .NET, designed to manage companies, employee users, products, and multi-product customer orders.

## 🏗️ Database Entities & Relationships
The system consists of 5 core relational tables:
1. **User:** Stores user/employee information, where each user is linked to a specific company (`CompanyId`).
2. **Company:** Stores companies whose employees are authorized to place orders.
3. **Product:** Stores available products and their pricing.
4. **Order:** Represents a purchase transaction, containing an `OrderId`, the `UserId` who placed the order, and the calculated `TotalPrice`.
5. **OrderDetail:** Acts as a junction/detail table holding specific products, quantities, and prices for each order.

## 🚀 Tech Stack
* **Backend:** C#, .NET, ASP.NET Core Web API
* **Database & ORM:** SQL Server, Entity Framework Core
* **Architecture:** Clean Architecture / Layered Architecture
* **Security:** User Secrets (for secure local database connection string management)

## ⚙️ Getting Started & Local Setup

To run this project locally, follow these steps:

### 1. Clone the Repository
```bash
git clone [https://github.com/Abdulrahman-Daboubash/IIHTask.git](https://github.com/Abdulrahman-Daboubash/IIHTask.git)