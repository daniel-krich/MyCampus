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
- `Meetings schedule`
- `Assignments`
- `Quizzes`
###### Note: Some of the features are not 100% implemented yet and still under development.
  
<hr />
  
### Currently campus has 4 types of users
- `Unactivated`
  - Pretty much just exists and can't actually do anything until status changes.
  
- `Student`
  - View information about my profile, courses, classes, meetings schedule, submitted assignments with feedback and quizzes.
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
  
  <hr />
  
### Screenshots for illustration
  
![s1](https://user-images.githubusercontent.com/87533517/193404337-7ca204db-a699-41d0-9f65-aaefbaa6741b.png)
  
  <hr />
  
![s2](https://user-images.githubusercontent.com/87533517/193404344-e184848a-2e15-4cf2-8fde-2cef95872503.png)
  
  <hr />
  
![s3](https://user-images.githubusercontent.com/87533517/193404345-0f127904-890f-4807-b7ad-a29b6cff177e.png)
  
  <hr />

![s5](https://user-images.githubusercontent.com/87533517/193404348-6763331b-05f8-4108-897a-3e6eb1cb9131.png)