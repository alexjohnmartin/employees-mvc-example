create table JobTitles (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT); 
create table Employees (id INTEGER PRIMARY KEY AUTOINCREMENT, firstname TEXT, surname TEXT, JobTitleId INTEGER);