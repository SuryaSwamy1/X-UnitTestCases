--> I have created the common file for mocking and creation of dummy data named as "AutoMoqDataAttribute"
--> This file is regarding the setup for mocking your interfaces and creation of dummy data for your Classes / Models, I have used Autofiture for creating dummy data and mocking those interfaces
--> I have added the dependency injection for your test classes so that you can directly enter the class name as a parameter and if you want dummy data you can directly add that type in your parameters then it will create the required data and you can modify it accordingly (check the BankTransactionsTest.cs for reference)
--> I have used X-Unit, AutoFixtures and an individual test project 

// dummy Classes / Models
--> I have created an interface IVerifyTransactions.cs, implemented those definitions in VerifyTransactions.cs also created a user model and used VerifyTransactions functions on BankTransactions.cs

you can check BankTransactionTests.cs this class you will understand it 