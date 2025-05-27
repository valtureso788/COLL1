
# Структура базы данных — College Management System

## 🗃 Описание

База данных построена с использованием **SQLite** и содержит информацию о студентах, преподавателях, группах, курсах, расписаниях и оценках.

## 📊 Таблицы и связи

### 1. `Persons`
- `Id` (PK) — уникальный идентификатор
- `Name` — имя пользователя
- `BirthDate` — дата рождения
- `Role` — роль: `Student` или `Teacher`

### 2. `Groups`
- `Id` (PK)
- `Name` — название группы

### 3. `Students`
- `PersonId` (PK, FK → Persons.Id)
- `GroupId` (FK → Groups.Id)

### 4. `Teachers`
- `PersonId` (PK, FK → Persons.Id)

### 5. `Courses`
- `Id` (PK)
- `Name` — название курса
- `TeacherId` (FK → Teachers.PersonId)

### 6. `ScheduleEntries`
- `Id` (PK)
- `GroupId` (FK → Groups.Id)
- `CourseId` (FK → Courses.Id)
- `Day`, `Time` — день недели и время

### 7. `Marks`
- `Id` (PK)
- `StudentId` (FK → Students.PersonId)
- `CourseId` (FK → Courses.Id)
- `Value` — оценка (целое число)

## 🔗 Типы связей

- Один ко многим: `Groups` → `Students`, `Courses` → `ScheduleEntries`
- Один к одному: `Persons` → `Teachers`, `Persons` → `Students`
- Многие ко многим (реализовано через `Marks`): `Students` ↔ `Courses`

## 🧾 SQL-дамп (schema.sql)

В проекте включён SQL-файл `schema.sql`, который создаёт все таблицы:

```sql
CREATE TABLE Persons (
    Id INTEGER PRIMARY KEY,
    Name TEXT,
    BirthDate TEXT,
    Role TEXT
);

-- и так далее ...
```

## 📦 Подключение к SQLite

Подключение осуществляется через строку:

```csharp
new SQLiteConnection("Data Source=college.db");
```

---

© 2025 College Management System — Database Documentation
