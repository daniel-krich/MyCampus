# My campus
### My campus is a college management system.
#### Tech stack consists of ASP.NET Core (Blazor-server framework) + Microsoft SQL server (EF Core code first approach).

### Core features
- `Login`
- `Register`
- `Sessions`
- `Profile settings`
- `Navigation`

### Features
- `Courses management`
- `Classes management`
- `Students management`
- `Meetings`
- `Assignments`
- `Quizzes`
###### Note: Some of the features are not 100% implemented yet and still under development.
  
<hr />
  
### Currently campus has 4 types of users
- `Unactivated`
  - Pretty much just exists and can't actually do anything until status changes.
  
- `Student`
  - View information about my profile, courses, classes, upcoming meetings, submitted assignments with feedback and quizzes.
  - Submit, update home assignments (Supports file attaching).
  - Submit quizzes and receive feedback immediately.
  
- `Lecturer`
  - Create, update, delete and check submitted assignments of his students and hand out grades (Supports file attaching).
  - Create quizzes for his students to test their knowledge based on subjects that were studied in class.
  
- `Staff`
  - Create, update courses.
  - View all courses and their associated classes information.
  
<hr />
  
### In order to run the project
1. Make sure you have mssql service running on your localhost or if you're using authentication/remote db then edit the `ConnectionStrings` in `appsettings.json`.
2. Push the database migrations via `Update-Database` or `dotnet ef database update --project MyCampusUI`.

### Pre-created accounts for fast access
| Username | Password | Permissions |
| --- | --- | --- |
| demo1 | 123456789 | Student |
| demo2 | 123456789 | Lecturer |
| demo3 | 123456789 | Staff/Admin |