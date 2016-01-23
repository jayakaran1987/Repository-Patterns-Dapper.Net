# Repository Patterns using Dapper.Net


This is Dapper.net used small application for Pricing query form in C# MVC.NET.     
 
The form contains following fields:
 
First Name - Optional
Last Name - Mandatory
Email - Mandatory
Address -Line 1, City, postcode and  Country mandatory
Phone - Mandatory
Products-  User should be able to select multiple products, selection of at least one product is mandatory
 
After form submission, the query will be registered in database and some other services like notification
 
To make this application simple,  I haven't used or introduced the following 

  1. Dependency Injection libraries but mentioned in the code where I would use IOC.
  2. I have created the Unit Test to ensure the registering of Pricing Query and User but did not cover wide range of Unit Test cases for repositories and services
  3. Additional custom exception handling
  4. Third party services like AutoMapper for mapping, Log4net for logging and FluentValidation for model validation.
 
