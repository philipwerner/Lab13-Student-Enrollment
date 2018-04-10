# Lab13 Student Enrollment

## MVC Movie App

https://studentenrollment.azurewebsites.net/

This is a student enrollment app that lets you create, edit, and delete both
courses and students. When there are either students or courses in the database,
while viewing the list on the index page you are able to select whether you 
want to edit or delete them.

## Tools Used
Microsoft Visual Studio Community Version 15.5.7

C#

ASP.Net Core

xUnit

Bootstrap

Azure

## Getting Started

Clone this repository to your local machine.
```
$ git clone 
```
Once downloaded, cd into the ```Lab13-Student-Enrollment``` directory.
```
$ cd Lab13-Student-Enrollment
```
The cd into ```StudentEnrollment``` directory.
```
$ cd StudentEnrollment
```
The cd into the second ```StudentEnrollment``` directory.
```
$ cd StudentEnrollment
```
Then run .NET build.
```
$ dotnet build
```
Once that is complete, run the program.
```
$ dotnet run
```

## Models

### Student

Required
```FirstName```: ```String```
Required
```LastName```: ```String```
Required
```Course```: ```String```

### Course

Required
```Name```: ```String```

Required
```Level```: ```Int```

Optional
```Instructor```: ```String```
