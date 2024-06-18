CREATE DATABASE xsxx;  

USE xsxx;

DROP TABLE IF EXISTS SC       /*�ɼ�*/
DROP TABLE IF EXISTS Student  /*ѧ����Ϣ*/
DROP TABLE IF EXISTS Course   /*�γ�*/
DROP TABLE IF EXISTS StudentUser  /*ѧ���û���Ϣ*/
DROP TABLE IF EXISTS Administrator  /*����Ա�û���Ϣ*/
DROP TABLE IF EXISTS SysLog   /*ע����־*/
DROP TABLE IF EXISTS SysLog1   /*��½��־*/

DROP TABLE IF EXISTS Ognaz
DROP TABLE IF EXISTS StatusM
DROP TABLE IF EXISTS Award
CREATE TABLE StudentUser          
 (	
 ID NCHAR(32) PRIMARY KEY,               /*ѧ��*/  
 PassWord NCHAR(32) ,					/*����*/
 Sex CHAR(2) ,							/*�Ա�*/
 UserMobile NCHAR(11),					/*�绰����*/
 StudentBirthday datetime,	    /*����*/
 UserPhoto image,						/*��Ƭ*/
 ); 
 CREATE TABLE Administrator          
 (	
 ID NCHAR(20) PRIMARY KEY,               /*����*/  
 PassWord NCHAR(32) ,             /*����*/
 Sex CHAR(2),							/*�Ա�*/
 UserMobile NCHAR(11),					/*�绰����*/
 AdiminBirthday datetime,
 UserPhoto image,						/*��Ƭ*/

 );

 CREATE TABLE SysLog          
 (	
 UserID NCHAR(20) ,  /*id*/
 dentity CHAR(20),  /*ѧ�������Ա*/
 DateAndTime datetime,  /*ע��ʱ��*/
 UserOperation NCHAR(200)  /*������ʽ*/
 ); 
CREATE TABLE SysLog1          
 (	
 UserID NCHAR(20) ,  /*id*/
 dentity CHAR(20),  /*ѧ�������Ա*/
 DateAndTime datetime,  /*��½ʱ��*/
 UserOperation NCHAR(200)  /*��½������ʽ*/
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
 Sdept CHAR(20)	,				/*רҵ*/
 Sclass CHAR(20)
);

alter table Ognaz
add constraint Scollege check (Scollege='�����ѧԺ'or Scollege='�ŵ�ѧԺ' )

alter table Ognaz
add constraint Sdept check ((Scollege='�����ѧԺ'and Sdept='�������ѧ')or (Scollege='�����ѧԺ'and Sdept='�������')or 
	(Scollege='�����ѧԺ'and Sdept='��Ϣ��ȫ')or (Scollege='�ŵ�ѧԺ'and Sdept='�ŵ�' ))


CREATE TABLE StatusM
(
Sno CHAR(10) PRIMARY KEY ,
Sstatus CHAR(10),
);
alter table StatusM
add constraint Sstatus check (Sstatus='����'or Sstatus='תרҵ' or Sstatus= '��ҵ' or Sstatus='��ת'or Sstatus='����' )

CREATE TABLE Award
(
Sno CHAR(10) PRIMARY KEY ,

INFOR CHAR(10),
);
alter table Award
add constraint INFOR check (INFOR='һ�Ƚ�'or INFOR='���Ƚ�' or INFOR='���Ƚ�' or INFOR='')