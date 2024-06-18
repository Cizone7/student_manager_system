CREATE DATABASE xsxx;  

USE xsxx;

DROP TABLE IF EXISTS SC       /*成绩*/
DROP TABLE IF EXISTS Student  /*学生信息*/
DROP TABLE IF EXISTS Course   /*课程*/
DROP TABLE IF EXISTS StudentUser  /*学生用户信息*/
DROP TABLE IF EXISTS Administrator  /*管理员用户信息*/
DROP TABLE IF EXISTS SysLog   /*注册日志*/
DROP TABLE IF EXISTS SysLog1   /*登陆日志*/

DROP TABLE IF EXISTS Ognaz
DROP TABLE IF EXISTS StatusM
DROP TABLE IF EXISTS Award
CREATE TABLE StudentUser          
 (	
 ID NCHAR(32) PRIMARY KEY,               /*学号*/  
 PassWord NCHAR(32) ,					/*密码*/
 Sex CHAR(2) ,							/*性别*/
 UserMobile NCHAR(11),					/*电话号码*/
 StudentBirthday datetime,	    /*生日*/
 UserPhoto image,						/*照片*/
 ); 
 CREATE TABLE Administrator          
 (	
 ID NCHAR(20) PRIMARY KEY,               /*工号*/  
 PassWord NCHAR(32) ,             /*密码*/
 Sex CHAR(2),							/*性别*/
 UserMobile NCHAR(11),					/*电话号码*/
 AdiminBirthday datetime,
 UserPhoto image,						/*照片*/

 );

 CREATE TABLE SysLog          
 (	
 UserID NCHAR(20) ,  /*id*/
 dentity CHAR(20),  /*学生或管理员*/
 DateAndTime datetime,  /*注册时间*/
 UserOperation NCHAR(200)  /*操作方式*/
 ); 
CREATE TABLE SysLog1          
 (	
 UserID NCHAR(20) ,  /*id*/
 dentity CHAR(20),  /*学生或管理员*/
 DateAndTime datetime,  /*登陆时间*/
 UserOperation NCHAR(200)  /*登陆操作方式*/
 );

CREATE TABLE Student          
 (	
 Sno CHAR(10) PRIMARY KEY,                      
 Sname CHAR(20),
 Sex CHAR(2),	
 ); 
CREATE TABLE  Course
 (	
 Cno CHAR(4) PRIMARY KEY,
 Cname CHAR(40),            
 Cpno CHAR(4),               	                      
 Ccredit SMALLINT,
 FOREIGN KEY (Cpno) REFERENCES  Course(Cno) 
 ); 

CREATE TABLE  SC
 (
 Sno CHAR(10), 
 Cno CHAR(4),  
 Grade SMALLINT,
 PRIMARY KEY (Sno,Cno),                     
 FOREIGN KEY (Sno) REFERENCES Student(Sno),
 FOREIGN KEY (Cno)REFERENCES Course(Cno)    
 ); 

CREATE TABLE Ognaz
(
 Sno CHAR(10) PRIMARY KEY, 
 Scollege CHAR(20),
 Sdept CHAR(20)	,				/*专业*/
 Sclass CHAR(20)
);

alter table Ognaz
add constraint Scollege check (Scollege='计算机学院'or Scollege='信电学院' )

alter table Ognaz
add constraint Sdept check ((Scollege='计算机学院'and Sdept='计算机科学')or (Scollege='计算机学院'and Sdept='软件工程')or 
	(Scollege='计算机学院'and Sdept='信息安全')or (Scollege='信电学院'and Sdept='信电' ))


CREATE TABLE StatusM
(
Sno CHAR(10) PRIMARY KEY ,
Sstatus CHAR(10),
);
alter table StatusM
add constraint Sstatus check (Sstatus='留级'or Sstatus='转专业' or Sstatus= '毕业' or Sstatus='降转'or Sstatus='正常' )

CREATE TABLE Award
(
Sno CHAR(10) PRIMARY KEY ,

INFOR CHAR(10),
);
alter table Award
add constraint INFOR check (INFOR='一等奖'or INFOR='二等奖' or INFOR='三等奖' or INFOR='')