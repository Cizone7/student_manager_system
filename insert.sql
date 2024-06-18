USE xsxx


INSERT INTO Student VALUES('2112190101','李华','男');

INSERT  INTO  StudentUser VALUES ('2112190101',substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','As1')),3,32),'男','13812345678','2003-3-1',NULL);
INSERT  INTO  Administrator VALUES ('2018110',substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','As1')),3,32),'女','13812345687','1978-4-2',NULL);
INSERT  INTO  Administrator VALUES ('2018111',substring(sys.fn_sqlvarbasetostr(HashBytes('MD5','As1')),3,32),'女','13812655687','1987-5-11',NULL);


INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('1','数据库',NULL,4);
INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('2','数学',NULL,4);
INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('3','信息系统',NULL,4);
INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('4','操作系统',NULL,4);
INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('5','数据结构',NULL,4);
INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('6','数据处理',NULL,4);
INSERT  INTO Course(Cno,Cname,Cpno,Ccredit)	VALUES ('7','Pascal语言',NULL,4);

UPDATE Course SET Cpno = '5' WHERE Cno = '1' 
UPDATE Course SET Cpno = '1' WHERE Cno = '3' 
UPDATE Course SET Cpno = '6' WHERE Cno = '4' 
UPDATE Course SET Cpno = '7' WHERE Cno = '5' 
UPDATE Course SET Cpno = '6' WHERE Cno = '7' 

INSERT  INTO SC(Sno,Cno,Grade) VALUES ('2112190101 ','1',92);
INSERT  INTO SC(Sno,Cno,Grade) VALUES ('2112190101 ','2',85);
INSERT  INTO SC(Sno,Cno,Grade) VALUES ('2112190101 ','3',88);
INSERT  INTO SC(Sno,Cno,Grade) VALUES ('2112190101','6',90);
INSERT  INTO SC(Sno,Cno,Grade) VALUES ('2112190101 ','4',80);

INSERT INTO Ognaz(Sno,Scollege,Sdept,Sclass)VALUES('2112190101','计算机学院','计算机科学','2101')
INSERT INTO StatusM(Sno,Sstatus) VALUES('2112190101','正常')
select * from SC
select * from Student
select* from Ognaz
select * from StatusM
SELECT Student.Sno,Student.Sname,Student.Sex,Ognaz.Scollege,Ognaz.Sdept,Ognaz.Sclass FROM Student,Ognaz WHERE Student.Sno = Ognaz.Sno

SELECT Sno,AVG(Grade) AS avg FROM SC GROUP BY Sno
select * from SC
SELECT Cname  AS Cname,AVG(Grade) AS avg FROM SC,Course WHERE SC.Cno =Course.Cno GROUP BY Cname

SELECT SC.Sno AS Sno,Sname AS Sname,AVG(SC.Grade) AS avg FROM SC,Student WHERE SC.Sno =Student.Sno GROUP BY Sname,SC.Sno

SELECT SC.Sno AS Sno,Sname AS Sname,AVG(SC.Grade) AS avg 
      FROM SC,Student WHERE SC.Sno IN (SELECT SC.Sno FROM Ognaz where Scollege ='计算机学院' AND Sdept ='计算机科学' AND  SC.Sno =Ognaz.Sno)
	  and SC.Sno =Student.Sno AND SC.Sno LIKE '21%' 
	  GROUP BY Sname,SC.Sno 

SELECT Sno from Ognaz WHERE Sno LIKE '21%' 

SELECT * FROM Award
SELECT * FROM Award,Student WHERE Award.Sno 
IN(SELECT Award.Sno FROM Ognaz where Scollege ='计算机学院' AND Sdept ='计算机科学'
                AND  Award.Sno = Ognaz.Sno)and Award.Sno = Student.Sno AND Award.Sno LIKE '21%' 