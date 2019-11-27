CREATE TABLE EMPLOYEE
      (EMPNO       CHAR(10)         NOT NULL,
       FIRSTNME    VARCHAR(12)     NOT NULL,
       MIDDLE    VARCHAR(10)         NOT NULL,
       LASTNAME    VARCHAR(15)     NOT NULL,
       WORKDEPT    CHAR(30)                 ,
       PHONENO     CHAR(40)                 ,
       HIREDATE    DATE                    ,
       JOB         CHAR(8)                 ,
       BIRTHDATE   DATE                    ,
       SALARY      DECIMAL(9,2)            ,         
       PRIMARY KEY (EMPNO))
