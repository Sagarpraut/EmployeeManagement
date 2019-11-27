Create Table Employee(
EmployeeId BigInt Identity(1,1) Primary Key,
Name Varchar(100) Not Null,
Department Varchar(100),
JoinDate DateTime Default(GetDate()) Not null)

