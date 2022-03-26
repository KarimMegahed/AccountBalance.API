# AccountBalance.API
Just Sample Backend / API Project

This API Project has 4 different services:
  - Accounts/GetAllAccounts       : [GET]   Get All Accounts Stored 
  - Accounts/CreateAccount        : [POST]  Create New Account for an existing Customer
  - Customers/GetAllCustomers     : [GET]   Get All Customers Stored 
  - Customers/GetCustomerDetails  : [GET]   Get Customer Details (Personal info, Accounts and Transactions) by Customer Id

Please Note that the data is saved in memory and not actually persisted to an external database.

# How to Execute Service
I activated Swagger, You can find it by this link and test over Swagger all APIs: 
"http://localhost:5000/swagger/index.html"

# Data to Test
As mentioned, the data is stored in memory, so I already filled up initial data:
  - Customer name = "Karim Megahed" with Customer ID = 1000
  - Customer name = "Ahmed Mohammed" with Customer ID = 1001

and also I added some accounts and transactions as initial data to test all APIs.

