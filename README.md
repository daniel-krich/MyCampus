# My campus
### My campus is a college managment system.
#### Tech stack consists of ASP.NET Core (Blazor-server framework) + Microsoft SQL server (EF Core code first approach).

### Core features
- `Login`
- `Register`
- `JWT sessions`

### Features
- `Courses managment`
- `Classes managment`
- `students managment`
- `Meetings`
- `Assignments`
- `Quizzes`
###### Note: Some of the features are not 100% implemented yet and still under development.

### Currently campus has 4 types of users
- `Unactivated`
  - Pretty much just exists and can't actually do anything until status changes.
  
- `Student`
  - View information about my profile, courses, classes, upcoming meetings, submitted assignments with feedback and quizzes.
  - Submit, update home assignments (Supports file attaching).
  - Submit quizzes and receive feedback immediately.
  
- `Lecturer`
  - Can create, update, delete and check submitted assignments of his students and hand out grades (Supports file attaching).
  - Can create quizzes for his students to test their knowledge based on subjects that were studied in class.
  
- `Staff`
  - Create, update courses.
  - View all courses and their associated classes information.
  