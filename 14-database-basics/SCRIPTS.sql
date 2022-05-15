
CREATE PROCEDURE GetUserRewards(@id INT) AS
	SELECT Users.FirstName, Users.LastName, Rewards.Title
	FROM Users JOIN UsersRewards ON Users.Id = UsersRewards.UserId
	JOIN Rewards ON UsersRewards.RewardId = Rewards.Id
	WHERE UserId = @id



CREATE PROCEDURE AddUser(@FirstName NVARCHAR(50), @LastName NVARCHAR(50), @Birthdate DATE) AS
	INSERT INTO Users(FirstName, LastName, Birthdate) VALUES (@FirstName, @LastName, @Birthdate)

CREATE PROCEDURE DeleteUser(@id INT) AS
	DELETE FROM UsersRewards WHERE UserId = @id
	DELETE FROM Users WHERE Id = @Id

CREATE PROCEDURE UpdateUser(@id INT, @FirstName NVARCHAR(50), @LastName NVARCHAR(50), @Birthdate DATE) AS
	UPDATE Users SET FirstName = @FirstName WHERE id = @id
	UPDATE Users SET LastName = @LastName WHERE id = @id
	UPDATE Users SET Birthdate = @Birthdate WHERE id = @id 



CREATE PROCEDURE AddReward(@Title NVARCHAR(50), @Description NVARCHAR(250)) AS
	INSERT INTO Rewards(Title, Description) VALUES (@Title, @Description)

CREATE PROCEDURE DeleteReward(@id INT) AS
	DELETE FROM UsersRewards WHERE RewardId = @Id
	DELETE FROM Rewards WHERE Id = @Id

CREATE PROCEDURE UpdateReward(@id INT, @Title NVARCHAR(50), @Description NVARCHAR(250)) AS
	UPDATE Rewards SET Title = @Title WHERE id = @id
	UPDATE Rewards SET Description = @Description WHERE id = @id

INSERT INTO UsersRewards(UserId, RewardId) VALUES (4, 1)


GetUserRewards @id = 2

UpdateUser @id = 2, @FirstName = 'Иван', @LastName = 'Бублин', @Birthdate = '19971222'
DeleteUser @id = 3
AddUser @FirstName = 'Степан',  @LastName = 'Шишкин', @Birthdate = '20060201'

UpdateReward @id = 2, @Title = 'Медаль', @Description = NULL
DeleteReward @id = 3
AddReward @Title = 'Новая премия', @Description = 'дескрипшн'

SELECT * FROM Users
SELECT * FROM Rewards
SELECT * FROM UsersRewards