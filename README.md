**## > ATTENDANCE CAPTURE
DOCUMENTATION**

						




## Table of Contents

1. REQUIREMENTS	
2. IMPLEMENTATION	
2.1 Models	
2.2 SQL Database	
2.3 Controllers, Razor Views, Routing and Actions	
2.4 Controller Implementation Logic	
2.5 UI Materialize Implementation	
2.6 UI Validation and Model Validations	
2.7 Additional Thoughts and Features	
2.8 Azure Deployment	
2.9 Demo and Steps To Reproduce









## 1.	REQUIREMENTS
1.	Build a test database in SQL. Create tables mentioned below
Users Table
 ID – (Primary Key, Auto increment),
StudentName

Attendance Table
ID – (Primary Key, Auto increment),
StudentName
Attendance_Date	
Attendance_Status

2.	Create some dummy rows in user table. 

3.	Build page as below.
a.	Page should show all the students.
b.	Page should contain an option to select date.
c.	For each student there should be a way to select Present or Absent.
d.	Once user selected date and you should allow the user to check present or absent for different students.
e.	Once user click save this information should be stored in Attendance Table
4.	For reference you can see any online attendance pages.

## 2. IMPLEMENTATION
### 2.1 Models

•	Two Models are used in the implementation of MVC using C# Attendance.cs and Users.cs.
Attendance Model Contains:
1.	AttendanceID-int(Primary Key)
2.	 Name String
3.	 Attendance_Date  DateTime
4.	  Attendance_status Boolean




Users Model Contains:
		1. ID int (Primary Key)
           	2. Name String
          		3. DOB DateTime
        		4. UnivId string
### 2.2 SQL Database
•	Added code to initialize the database with test data.
•	In the Data folder, created a new class file named DbInitializer.cs which causes a database to be created when needed and loads test data into the new database.
•	Appsetting.json and startup.cs are modified to initialize a local DB with test data on first run.
### 2.3 Controllers, Razor Views, Routing and Actions
•	Two Controller AttendanceController.cd and UsersController.cs are created to perform all the required operations between view and models.
•	Razor Views are created to implement required html code and bind the data from controllers.
•	Attendance View are routed as default home page and landing page .This will enable user to check the previous Attendance History.
•	Users View is embedded with Attendance Marking feature. This is to reduce the number of unnecessary clicks on a page.
•	Additional Add Edit, Delete and View all students Views are provided.
•	Each controller action methods are called from views using asp-action tag helpers. 
### 2.4 Controller Implementation Logic
•	Each Controller action methods have different parameters inputted. Index Method is majorly implemented by returning and inputting as a list. Using List Enables us to fetch the entire table’s database as a list.
•	By fetching the entire table as a list, I implemented a logic to match the primary key and Perform CRUD Operations.
•	As the views for Edit, Delete are different, these action methods input just the primary key and fetch the data from database.
•	Edit, Delete and Add Operations are asynchronous operations which improves the performance of the WebApp.
### 2.5 UI Materialize Implementation
•	User Interface is implemented with Bootstrap Library and Materialize Library Propller.in.
•	To ease the complexity of increasing database in attendance table .JQYERY Data table is implemented.
•	JQUERY Data table is a client side implementation which provides out of box features like search, sort and responsiveness.
•	Propeller Library is an open source Project which helps us develop our website with material components.
•	Bootstrap inline Date Time picker along with propeller.in css.is used to perform date operations.
### 2.6 UI Validation and Model Validations
•	UI validations are implemented for mark attendance .For Example User cannot submit more than one attendance sheet.
•	Similarly Date cannot be null, this is implemented handled both in UI and in Models, and Alert messages are created in the view for UI validations.
### 2.7 Additional Thoughts and Features	
•	Adding to the requirements I have added few additional features. This can be best explained with a USECASE.
1.	Add new student is enabled with additional columns like DOB and University ID.Similarly We can add other columns like Joining Date, Fathers Name, Nationality, Gender etc.
2.	Similarly uploading a student’s image feature can also be implemented, which can be binded to Material cards.
3.	Even though I have implemented my code using Entity framework. I have explicitly not linked the foreign keys. But By using EF we can provide an option to view a statistical representation of every student’s attendance like by clicking on each students stats a chart of his performance can be shown.
4.	I have implemented a prototype of material cards of students with image in Viewallstudents page. 
### 2.8 Azure Deployment
•	Deployed the entire code to azure with a free 20 MB SQL database using visual studio.
•	http://attendancecapture.azurewebsites.net/
### 2.9 Demo and Steps To Reproduce
•https://drive.google.com/drive/folders/0B2YNEcFquEYaRWRucUFqTWN6TUU
You can find a demo video in the above link.

