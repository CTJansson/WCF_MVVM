--CREATE DATABASE NewsApp
--USE NewsApp

CREATE TABLE "Authors"
(
	"Id" INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	"FirstName" NVARCHAR(MAX) NOT NULL,
	"LastName" NVARCHAR(MAX) NOT NULL,
	"Title" NVARCHAR(MAX) NOT NULL,
	"Email" NVARCHAR(MAX) NOT NULL,
)

INSERT INTO "Authors" VALUES ('Koji', 'Kondo', 'Composer', 'koji.kondo@nintendo.jp')
INSERT INTO "Authors" VALUES ('Gabe','Newell','Valve Founder','gabe.newell@valve.net')
INSERT INTO "Authors" VALUES ('Flandre','Scarlet','Devil','flandre.scarlet@mansion.jp')

CREATE TABLE "Accounts"
(
	"Id" INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	"Username" NVARCHAR(MAX) NOT NULL,
	"Password" NVARCHAR(MAX) NOT NULL,
	"AuthorId" INT NOT NULL FOREIGN KEY REFERENCES Authors(Id),
)

INSERT INTO "Accounts" VALUES ('koji.kondo', 'zeruda', '1')
INSERT INTO "Accounts" VALUES ('gaben','hl3','2')
INSERT INTO "Accounts" VALUES ('flandre.scarlet','un','3')

CREATE TABLE "Categories"
(
	"Id" INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	"CategoryName" NVARCHAR(MAX) NOT NULL,
)

INSERT INTO "Categories" VALUES ('National')
INSERT INTO "Categories" VALUES ('World')
INSERT INTO "Categories" VALUES ('Sport')
INSERT INTO "Categories" VALUES ('Technology')
INSERT INTO "Categories" VALUES ('Entertainment')

CREATE TABLE "SubscribedEmails"
(
	"Id" INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	"Email" NVARCHAR(MAX) NOT NULL,
)

CREATE TABLE "NewsPosts"
(
	"Id" INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	"Header" NVARCHAR(MAX) NOT NULL,
	"Content" NVARCHAR(MAX) NOT NULL,
	"CategoryId" INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	"AuthorId" INT NOT NULL FOREIGN KEY REFERENCES Authors(Id),
	"Tags" NVARCHAR(MAX) NOT NULL,
	"Date" DATETIME NOT NULL,
	"WrittenBy" NVARCHAR(MAX) NOT NULL,
)

INSERT INTO "NewsPosts" VALUES ('Half Life 2: Episode Two: Source 2','These things they take time','5','2','hl3,pc,steamos,gaben', '2007-10-30','Gabe Newell')
INSERT INTO "NewsPosts" VALUES ('Valve reveals Source 2','SHIIIIIIIIIIIIIIIIIIIIIT','4','2','source2,pc,hl3,steamos','2015-03-04','Gabe Newell')
INSERT INTO "NewsPosts" VALUES ('Doping culture in cycling still exists according to Circ report','Cycling continues to struggle with widespread doping, according to a landmark report into the sports troubled recent history.','3','2','wow, such, sport, very, athletes, many, jokes, wow','2015-03-09','Gabe Newell')
INSERT INTO "NewsPosts" VALUES ('Steam Machines','Steam Machine (or Steam Box) is a line of pre-built gaming computers that began being manufactured and distributed by a number of vendors using a range of different design specifications outlined by Valve Corporation. All Steam Machines will have either the Steam client or SteamOS version installed on them.','4','2','hl3,steammachines,steamos','2015-03-12','Gabe Newell')
INSERT INTO "NewsPosts" VALUES ('Half Life 3 to be released in 20X3','This deserves world news!','2','2','yes, world, hl3','2015-03-15','Gabe Newell')
--INSERT INTO "NewsPosts" VALUES ('東方紅魔郷','機体性能の異なる「博麗霊夢（巫女）」と「霧雨魔理沙（魔法使い）」からいずれかを自機として選択し、その後それぞれ2種類の武器タイプ（装備）からいずれかを選択する。敵や敵弾に当たるとミスとなり残機が1つ減った上でその場で復活する。全ての残機を失うとゲームオーバーとなるが、コンティニューすればその場で復活しゲームを続行可能。コンテニューしないで6面（最終面）のボスを倒すとエンディングになる。難易度Normal以上でコンティニューせずにクリアすれば、全1面のExtraステージが追加される。','2','3','touhou','2015-03-13')
INSERT INTO "NewsPosts" VALUES ('Zelda no Densetsu: Kamigami no Triforce','Players once again assume the role of archetypal hero Link, here a young boy living with his uncle south of Hyrule Castle. Princess Zelda, a descendant of the seven sages, is held captive in the castle dungeon by Agahnim, a treacherous wizard who has set forth a chain of events to unleash Ganon','5','1','zeruda, zelda, snes','2015-03-10','Koji Kondo')

--DROP TABLE Authors
--DROP TABLE Accounts
--DROP TABLE Categories
--DROP TABLE NewsPosts
--DROP TABLE SubscribedEmails
--DROP TABLE SubscribedPhones
