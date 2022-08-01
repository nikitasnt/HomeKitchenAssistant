# HomeKitchenAssistant
Coursework of the 2nd year of the university.
## Description
The application helps you decide on a recipe for cooking, according to the products available in the house. The functionality also supports the creation of users and families. The products of users who are in the same family will be shared. The database is currently being created and populated manually.
## Miscrosoft SQL Server Database creation
### Database and triggers
```sql
create table Users
(
        UserId int primary key identity,
        UserName nvarchar(70) not null,
        UserLogin varchar(15) unique not null,
        UserPassword varchar(30) not null,
        check(UserName != '' and UserLogin != '' and UserPassword != '')
);
 
create table Families
(
        FamilyId int primary key identity
);
 
create table Units
(
        UnitId int primary key identity,
        UnitName nvarchar(20) not null,
        check(UnitName != '')
);
 
create table Products
(
        ProductId int primary key identity,
        ProductName nvarchar(40) unique not null,
        UnitId int not null references Units(UnitId),
        check(ProductName != '')
);
 
create table Recipes
(
        RecipeId int primary key identity,
        RecipeName nvarchar(60) unique not null,
        RecipeDescription nvarchar(4000) not null default 'Не предоставлено.',
        check(RecipeName != '' and RecipeDescription != '')
);
 
create table UsersBelongToFamilies
(
        UserId int references Users(UserId) on delete cascade,
        FamilyId int references Families(FamilyId) on delete cascade,
        unique(UserId),
        primary key(UserId, FamilyId)
);
 
create table UsersHaveProducts
(
        UserId int references Users(UserId) on delete cascade,
        ProductId int references Products(ProductId) on delete cascade,
        Amount int not null,
        primary key(UserId, ProductId)
);
 
create table FamiliesHaveProducts
(
        FamilyId int references Families(FamilyId) on delete cascade,
        ProductId int references Products(ProductId) on delete cascade,
        Amount int not null,
        primary key(FamilyId, ProductId)
);
 
create table RecipesIncludeProducts
(
        RecipeId int references Recipes(RecipeId) on delete cascade,
        ProductId int references Products(ProductId) on delete cascade,
        Amount int not null,
        primary key(RecipeId, ProductId),
        check(Amount >= 1)
);
 
 
 
go
 
 
-- Удаление пустых семей
create trigger UsersBelongToFamilies_DELETE
on UsersBelongToFamilies
after delete
as
delete Families
where not exists
(
        select * from UsersBelongToFamilies as U
        where U.FamilyId = Families.FamilyId
);
 
go
 
-- Удаление рецептов, в которые не входит ни один продукт
create trigger RecipesIncludeProducts_DELETE
on RecipesIncludeProducts
after delete
as
delete Recipes
where not exists
(
        select * from RecipesIncludeProducts as R
        where R.RecipeId = Recipes.RecipeId
);
 
go
 
-- Удаление продуктов у пользователей, которых 0 или меньше
create trigger UsersHaveProducts_INSERT_UPDATE
on UsersHaveProducts
after insert, update
as
delete UsersHaveProducts
where Amount <= 0;
 
go
 
-- Удаление продуктов у семей, которых 0 или меньше
create trigger FamiliesHaveProducts_INSERT_UPDATE
on FamiliesHaveProducts
after insert, update
as
delete FamiliesHaveProducts
where Amount <= 0;
 
go
```
### Filling data example
```sql
insert into Recipes(RecipeName, RecipeDescription)
values
('Борщ с курицей',
'1. Курицу разморозить, разделить на части и поставить варить. Посолить бульон.
 
2. Когда вода закипит, добавить нарезанную картошку.
 
3. Свеклу (крупную), морковь натереть на терке. Лук мелко порезать. Раздавить чеснок. Обжарить в подсолнечном масле 5 минут. Вложить томатную пасту.
 
4. Капусту нашинковать и добавить в бульон.
 
5. Как только картошка стала мягкой, добавить заправку, оставить еще на 3–5 минут.
 
6. При подаче на стол добавить сметаны, можно украсить зеленью.');
 
go
 
insert into Products(ProductName, UnitId)
values
('Свекла', 3),
('Курица', 1),
('Картофель', 3),
('Белокочанная капуста', 1),
('Репчатый лук', 3),
('Морковь', 3),
('Чеснок', 3),
('Томатная паста', 1);
*/
go
 
insert into RecipesIncludeProducts(RecipeId, ProductId, Amount)
values
(
        (select RecipeId from Recipes where RecipeName = 'Борщ с курицей'),
        (select ProductId from Products where ProductName = 'Свекла'),
        1
),
(
        (select RecipeId from Recipes where RecipeName = 'Борщ с курицей'),
        (select ProductId from Products where ProductName = 'Курица'),
        600
),
(
        (select RecipeId from Recipes where RecipeName = 'Борщ с курицей'),
        (select ProductId from Products where ProductName = 'Картофель'),
        4
),
(
        (select RecipeId from Recipes where RecipeName = 'Борщ с курицей'),
        (select ProductId from Products where ProductName = 'Белокочанная капуста'),
        200
),
(
        (select RecipeId from Recipes where RecipeName = 'Борщ с курицей'),
        (select ProductId from Products where ProductName = 'Репчатый лук'),
        1
),
(
        (select RecipeId from Recipes where RecipeName = 'Борщ с курицей'),
        (select ProductId from Products where ProductName = 'Морковь'),
        2
),
(
        (select RecipeId from Recipes where RecipeName = 'Борщ с курицей'),
        (select ProductId from Products where ProductName = 'Чеснок'),
        1
),
(
        (select RecipeId from Recipes where RecipeName = 'Борщ с курицей'),
        (select ProductId from Products where ProductName = 'Томатная паста'),
        20
);
```
## Linking DB to compiled app
In the App.config file in the connectionStrings tag, enter your value in the connectionString attribute:
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <startup> 
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.2" />
    </startup>
  <connectionStrings>
    <add name="HomeKitchenAssistantDb" connectionString="Your connection string"/>
  </connectionStrings>
</configuration>
```
