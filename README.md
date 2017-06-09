# WarChess
Приложение для игры в шахматы и их различные вариации.
_Название проекта WarChess выбрано потому, что изначально была идея написать [военные шахматы](https://ru.wikipedia.org/wiki/%D0%91%D0%BE%D0%B5%D0%B2%D1%8B%D0%B5_%D1%88%D0%B0%D1%85%D0%BC%D0%B0%D1%82%D1%8B), которая постепенно перерасла в идею написания расширяемого приложения, позволяющего играть в разные игры_

Авторы: Смирнов Иван, Лесков Владимир, Липин Антон. (Группа ФТ-201)

#Черновой план презентации защиты:

## Описание сути проекта
Мы сделали приложение для игры в шахматы и некоторые их вариации.
На данный момент работают только шахматы.
В разработке находятся военные шахматы и магараджа.
Не понятно что из этого будет готово к защите проекта.

Точки расширения:
- Основная точка расширения - различные игры.
Архитектура уровня Domain написана так, чтобы создать новую игру было как можно проще.

- Можно создавать различные стили отображения фигур, шахматного поля.

- Возможно, к защите проекта будет готова точка расширения, позволяющая выбрать язык.

Владимир занимался уровнем Domain, Иван и Антон работали над уровнями UserInterface и Application.

## Описание точек расширения
### Разные виды щахматы
В основе логической составляющий лежит идея абстрактной игры с игровым полем, на котором есть позиции.
(папка AbstractGame, класс Game https://github.com/Tinsane/WarChess/blob/master/WarChess/Domain/AbstractGame/Game.cs)
Поднимаясь по иерархии интерфейсов, мы естественным и постепенным путем вводим шахматные правила.
Далее по иерархии наследования идут GridGame2D - *Вова напиши что это такое*
Далее идёт ChessAlikeGame - игра на шахматном поле n\*m, в которой каждая фигура имеет один из двух цветов - белый и чёрный и известно какие фигуры ходят в данный момент.
Ну и на последнем уровне абстракции - собственно ChessGame.

Чтобы сделать военные шахматы, достаточно:
На уровне логики:
- Создать наследника абстрактного класса
  (https://github.com/Tinsane/WarChess/blob/master/WarChess/Domain/ChessAlike/ChessAlikeGame.cs)
  В нём активно переиспользовать уже написанные шахматы.
  Единственное отличие - надо не показывать фигуры соперника.

На уровне Application:
  Реализовать класс
 (https://github.com/Tinsane/WarChess/blob/master/WarChess/Application/IChessAlikeApp.cs)
  В нём, опять же, можно переиспользовать логику из класса для обычных шахмат.
  Добавить необходимо логику с передачей компьютера противнику.
- 
На уровне визуализации:
- Реализовать интерфейс IGameForm
  (https://github.com/Tinsane/WarChess/blob/master/WarChess/UserInterface/IGameForm.cs)
  Для его реализации можно использовать ChessAlikeGameControl
  (https://github.com/Tinsane/WarChess/blob/master/WarChess/UserInterface/ChessAlikeGameControl.cs)
  Этот контрол, содержит всю логику для отображения IChessAlikeGame.
  Внутри формы также можно будет поместить какую-то дополнительную логику, спецефичную именно для данной игры.
  Для военных шахмат это, опять же, логика передачи хода.
  
### Разные текстуры
(Тут пока не написал)
  
3. Структура решения.
  - В Infrastructure реализованы методы для удобной работы с классом Bitmap, который мы использовали для визуализации игры.
  (https://github.com/Tinsane/WarChess/blob/master/WarChess/Infrastructure/BitmapUtils.cs)
  - Логика игры собрана в Domain. Здесь есть классы и интерфейсы различного уровня абстракции,
  от подходящего любой игре с "полем" и "ходами" AbstractGame до собственно шахмат Chess.
  (https://github.com/Tinsane/WarChess/tree/master/WarChess/Domain)
  - В Application находится, собственно, API.
  - Наконец, в UserInterface собраны все формы, контролы и прочая, необходимые для визуализации.
  
4. DI-КОНТЕЙНЕР.
  
5. У нас нет тестов, потому что мы самые умные тут *уходят в свой двор*.
