# WarChess
Приложение для игры в шахматы и их различные вариации.

_Название проекта WarChess выбрано потому, что изначально была идея написать [военные шахматы](https://ru.wikipedia.org/wiki/%D0%91%D0%BE%D0%B5%D0%B2%D1%8B%D0%B5_%D1%88%D0%B0%D1%85%D0%BC%D0%B0%D1%82%D1%8B), которая постепенно перерасла в идею написания расширяемого приложения, позволяющего играть в разные игры_

Авторы: Смирнов Иван, Лесков Владимир, Липин Антон. (Группа ФТ-201)

# Черновой план презентации защиты:

## Описание сути проекта
Мы сделали приложение для игры в шахматы и некоторые их вариации.
На данный момент работают только шахматы.
В разработке находятся военные шахматы.
На данный момент они как-то отрисовываются, но поиграть в них нельзя.

Точки расширения:
- Основная точка расширения - различные игры.
Архитектура уровня Domain написана так, чтобы создать новую игру было как можно проще.

- Можно создавать различные стили отображения фигур, шахматного поля.

- Возможно, к защите проекта будет готова точка расширения, позволяющая выбрать язык.

Владимир занимался уровнем Domain, Иван и Антон работали над уровнями UserInterface и Application.

## Описание точек расширения
### Разные виды щахмат
В основе абстракции лежит интерфейс [IGameForm](https://github.com/Tinsane/WarChess/blob/master/WarChess/UserInterface/IGameForm.cs).
Чтобы создать новую игру - нужно написать реализацию этого интерфейса.
Однако, если мы пишем не абсолютно новую игру, а игру как-то похожую на шахматы, то можно будет переиспользовать значительную часть логики более низких уровней.

Рассмотрим как можно реализовать военные шахматы:
На уровне логики:
- Реализовать интерфейс [IChessAlikeGame](https://github.com/Tinsane/WarChess/blob/master/WarChess/Domain/ChessAlikeApi/IChessAlikeGame.cs)
  В нём активно переиспользовать уже написанные шахматы.
  Отличие - надо не показывать фигуры соперника.
  Также нужно будет возвращать информацию о том, что пешка может рубить.

На уровне Application:
- Реализовать класс
 [IChessAlikeApp](https://github.com/Tinsane/WarChess/blob/master/WarChess/Application/IChessAlikeApp.cs)
  В нём, опять же, можно переиспользовать логику из класса для обычных шахмат.
  Добавить необходимо логику с передачей компьютера противнику.

На уровне визуализации:
- Реализовать интерфейс [IGameForm](https://github.com/Tinsane/WarChess/blob/master/WarChess/UserInterface/IGameForm.cs)
  Для его реализации можно использовать [ChessAlikeGameControl](https://github.com/Tinsane/WarChess/blob/master/WarChess/UserInterface/ChessAlikeGameControl.cs)
  Этот контрол, содержит всю логику для отображения [IChessAlikeGame](https://github.com/Tinsane/WarChess/blob/master/WarChess/Domain/ChessAlikeApi/IChessAlikeGame.cs).
  Внутри формы также можно будет поместить какую-то дополнительную логику, спецефичную именно для данной игры.
  Для военных шахмат это, опять же, логика передачи хода.
  
### Разные текстуры
Чтобы изменить текстуры шахмат - достаточно реализовать интерфейс IChessStyle и поменять настройки DI-Container-а.
Аналогично, чтобы поменять цветовую гамму поля - достаточно реализовать интерфейс IBoardStyle и поменять настройки DI-Container-а

## Структура решения.

  - В Infrastructure реализованы вспомогательные методы для работы с классом Bitmap, который мы использовали для визуализации игры.
  (https://github.com/Tinsane/WarChess/blob/master/WarChess/Infrastructure/BitmapUtils.cs)
  
  - Логика игры собрана в Domain. 
  Здесь есть классы и интерфейсы различного уровня абстракции,
  от подходящего любой игре с "полем" и "ходами" AbstractGame до собственно шахмат Chess.
  Самый низкий уровень абстракции - это класс [Game](https://github.com/Tinsane/WarChess/blob/master/WarChess/Domain/AbstractGame/Game.cs)
  Далее по иерархии наследования идёт [GridGame2D](https://github.com/Tinsane/WarChess/blob/master/WarChess/Domain/GridGame2D/GridGame2D.cs), данный класс сужает множество описываемых игр до игр, которые идут на конечной двумерной прямоугольной доске с квадратными клеточками.
  Далее идёт [ChessAlikeGame](https://github.com/Tinsane/WarChess/blob/master/WarChess/Domain/ChessAlike/ChessAlikeGame.cs) 
  Это игра на шахматном поле n\*m, в которой каждая фигура имеет один из двух цветов - белый и чёрный и известно какие фигуры ходят в данный момент.
  Ну и на последнем уровне абстракции - собственно ChessGame или какой-то другой класс, реализующий игру по конкретным правилам.
  Чтобы лучше понять архитектуру программы, рассмотрим класс ChessGame. Он наследуется от абстрактного класса ChessAlikeGame и реализует интерфейс IChessGame, поскольку является точкой соединения логики Domain и Application. Класс ChessGame является сервисом, который предоставляет интерфейс работы с сущностями ChessGameState и передает во "внешний мир" логику взаимодействия с игрой. Основной функцией для взаимодествия игры с "внешним миром" является функция TryMakeMove(ChessPosition from, ChessPosition to). Эта функция пытается подобрать подходящий ход для движения с позиции from, на позицию to, а потом пытается применить его к игре. Для индикации того, нашелся ли подходящий ход, данная функция возвращает булево значение. Ход же в свою очередь является просто функцией, которая принимает текущее состояние игры и другие опциональные аргументы и возвращает либо новое валидное состояние игры, если ход удался, либо null, если данный ход не может быть выполнен в данной ситуации. Сами же ходы все наследуются от DirectedMove из ChessAlike, который описывает ход, который совершается фигурой для перемещения.
  
  - В Application находятся классы-прослойки между классами уровня Domain и UserInterface.
    Они реализуют различную логику несвязанную напрямую с игрой.
	Например, класс [ChessAlikeApp](https://github.com/Tinsane/WarChess/blob/master/WarChess/Application/ChessAlikeApp.cs)
	реализует логику, связанную с выделением фигуры, которой будет производится ход.
	
  - Наконец, в UserInterface собраны все формы, контролы и прочие вещи, необходимые для визуализации.
    Во время реализации классов UserInterface мы старались делать Control-ы максимально глупыми.
	Это позволяет переиспользовать одни и те же контролы для разных игр.
	Например, контрол для шахматного поля [BoardControl](https://github.com/Tinsane/WarChess/blob/master/WarChess/UserInterface/BoardControl.cs) не знает ничего ни о каких шахматах. 
	Ему просто передают картинки и он их рисует.
	Также интересен [ChessAlikeGameControl](https://github.com/Tinsane/WarChess/blob/master/WarChess/UserInterface/ChessAlikeGameControl.cs), который принимает большое количество интерфейсов и реализует логику игры для произвольного IChessAlikeGame.
  
## DI-КОНТЕЙНЕР.
На данный момент точка расширения с добавлением новой [IChessAlikeGame](https://github.com/Tinsane/WarChess/blob/master/WarChess/Domain/ChessAlikeApi/IChessAlikeGame.cs) собирается при помощи конвенций.
Остальное - явным конфигурированием.
Синглтонами сделаны различные классы стилей.
Также синглтоном является класс QueenPawnTransformer, поскольку он ни от чего не зависит и его логика всегда одинакова.
Собственно, этот класс просто всегда говорит, что пешка превращается в ферзя, потому что логику выбора фигуры мы не написали (но её всегда можно будет добавить, реализовав интерфейс).

Также классы, соответствующие IChessAlikeGame явно сконфигурированы на повторное создание в случае их повторного запрашивания.
Это сделано для того, чтобы DI-Container не взял повторно уже сыгранную игру.

## Тесты
Тестами покрыта логика игры в шахматы.
Тестами покрыты все стандартные ходы фигур на доске. Особое внимание при тестировании уделено специальным ходам, вроде двойного хода пешки, взятия на проходе и рокировки. Также есть тесты, проверяющие невозможность хода "под шах". Также тестами покрыта небольшая часть кода, связывающая строковое и логическое представления позиции. Для тестирования использовалась библиотека NUnit.
Логика уровня приложения оказалась очень простой, поэтому тестами мы её решили не покрывать.
