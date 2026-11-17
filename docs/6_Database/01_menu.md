# 메뉴 (Menu) 
- 진행 상태: 진행 완료.
- 판매하는 메뉴의 정보를 저장한다.


## 1. 테이블
열 이름	        자료형	       역할
MenuId	        int	           상품 식별값
MenuName		nvarchar(100)  상품명
Price	        decimal(10,2)  상품 가격

→ int: 소수점이 없는 정수를 저장
→ nvarchar(100): 한글도 표현 가능, 최대 100자
→ decimal(10,2): 정확한 수 저장, 전체 10자리 2자리는 소수점 아래 자리

----- ----- ----- ----- ----- 
## 2. 제약 조건
[MenuId]
- PK
- IDENTITY(1,1)

[MenuName]
- NOT NULL

[Price]
- NOT NULL
- CHECK (Price >= 0)

----- ----- ----- ----- ----- 
## 3. SQL로 표현
[파일 저장 구조]
Kiosk
└─ Database
   ├─ 01_CreateDatabase.sql
   ├─ 02_CreateMenu.sql
   ├─ 03_InsertMenu.sql
   └─ 04_SelectMenu.sql

① 데이터베이스 생성
- 현재 SSMS 상태: 실행 후 파일 저장 
- 파일명: 01_CreateDatabase.sql
[쿼리]
create database KioskDB;
go;

② 테이블 생성
- 현재 SSMS 상태: 실행 후 파일 저장
- 파일명: 02_CreateMenu.sql
[쿼리]
USE KioskDB;
GO

CREATE TABLE dbo.Menu
(
    MenuId int IDENTITY(1,1)
        PRIMARY KEY,

    MenuName nvarchar(100) NOT NULL,

    Price decimal(10,2) NOT NULL,

    CONSTRAINT CK_Menu_Price
        CHECK (Price >= 0)
);

③ 데이터 삽입
- 현재 SSMS 상태: 실행 후 파일 저장
- 파일명: 03_InsertMenu.sql
use KioskDB;
go

insert into dbo.Menu (MenuName, Price)
values
(N'똥파리 슈렉', 1000),
(N'슈퍼맨 슈렉', 1000),
(N'코끼리 슈렉', 1000);

④ 데이터 조회
- 현재 SSMS 상태: 실행 후 파일 저장
- 파일명: 04_SelectMenu.sql
- 주의. 데이터 조회만 담당하는 파일임.
use KioskDB;
go

SELECT MenuId, MenuName, Price
FROM dbo.Menu;
