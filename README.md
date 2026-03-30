# Bank-Management-System-C-MySQL-
A full-featured, secure, and professional banking management system built with **C# .NET 9.0 Windows Forms** and **MySQL**. This application provides a comprehensive suite of tools for bank staff to manage customers, accounts, financial transactions, and loans with a focus on security and data integrity.
## 🌟 Key Features

### 🔐 Security & Access Control
*   **Secure Authentication**: Password hashing using **BCrypt.Net** for robust credential protection.
*   **First-Run Setup**: Mandatory administrative setup flow that forces credential changes on first access.
*   **RBAC (Role-Based Access Control)**: Distinct interfaces and permissions for **Administrators** and **Employees**.
*   **Audit Logging**: Every sensitive action (creation, deletion, or modification) is automatically recorded with a timestamp and user ID for security auditing.

### 💼 Portfolio Management
*   **Customer Hub**: Searchable relationship management with a "Corporate Hub" UI pattern.
*   **Account Portfolio**: Creation and management of Savings, Current, and Fixed Deposit accounts.
*   **Transaction Registry**: Real-time history of all deposits, withdrawals, and inter-account transfers.
*   **Atomic Transactions**: Uses MySQL transactions (Commit/Rollback) for funds transfers to ensure zero data loss or corruption.

### 📊 Loans & Reporting
*   **Loan Lifecycle**: Automated interest calculation, status tracking (Pending, Approved, Paid, Defaulted), and repayment schedules.
*   **Automated Reporting**: Export financial reports and account statements directly to **PDF** and **Excel**.
*   **System Analytics**: Dashboards providing bird's-eye views of total assets, customer growth, and daily transaction volume.

### 🌓 Modern UX
*   **Dynamic Theme Engine**: Smooth, live transitions between a sleek **Dark Mode** and a clean **Light Mode** across all modules.
*   **Responsive Layouts**: Optimized UserControl-based navigation for a fast and fluid session experience.

---
## 📸 Project Preview
 <img width="1202" height="710" alt="Screenshot 2026-03-30 084158" src="https://github.com/user-attachments/assets/815b6466-aac7-423f-bbc8-bbd9e15c9c56" />
 <img width="1173" height="539" alt="Screenshot 2026-03-30 084333" src="https://github.com/user-attachments/assets/910802ef-6fba-4c70-af11-74ec6b21b6f0" />
<img width="1206" height="576" alt="Screenshot 2026-03-30 084234" src="https://github.com/user-attachments/assets/abac28c6-8d7e-4312-bacb-728e878b519f" />



