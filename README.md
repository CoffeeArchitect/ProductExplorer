# ProductExplorer
Разработка тестового WinForms-приложения для управления товарами.

Этот проект представляет собой приложение для управления товарами в магазине одежды. Проект использует архитектуру MVP (Model-View-Presenter), паттерн репозиторий и внедрение зависимостей (Dependency Injection), что делает его более модульным и масштабируемым для добавления нового функционала.

SQL-скрипт на создание таблицы находится в папке проекта с названием DAL 

## Основные функциональные возможности
Загрузка товаров из базы данных: Приложение позволяет загрузить список товаров из базы данных. Товары отображаются в удобной таблице, где вы можете видеть основную информацию о каждом товаре.

Просмотр отдельного товара: Вы можете выбрать товар из списка и просмотреть подробную информацию о нем, включая название, цену, количество и другие характеристики.

Удаление товаров: При необходимости вы можете удалить товар из списка. Это может быть полезно, если товар больше не продается или информация о нем устарела.

Загрузка из внешних источников: Проект поддерживает загрузку данных о товарах из внешних источников, таких как файлы Excel. Это удобно для обновления списка товаров из внешних источников.

## Установка и запуск
Для установки и запуска проекта, выполните следующие шаги:

Клонируйте репозиторий: Склонируйте репозиторий на свой компьютер с помощью команды git clone.

Настройте базу данных: Для этого проекта база данных представлена в виде LocalDB SQL Server формата ProductDB.mdf. Файл базы данных всегда находится в структуре проекта и готов к использованию.

*Для выполнения операций CRUD (Create, Read, Update, Delete) в приложении используются хранимые процедуры. Все необходимые хранимые процедуры также находятся в LocalDB и готовы к использованию. Это обеспечивает надежное и удобное взаимодействие с базой данных приложения.*

Запустите приложение: Запустите приложение с помощью Visual Studio или вашей любимой IDE. Убедитесь, что все зависимости установлены.

Пользуйтесь приложением: Теперь вы можете начать использовать приложение для управления товарами в магазине одежды.

