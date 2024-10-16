using CardProjectAPI.game;
using CardProjectAPI.lib;
using CardProjectAPI.api;
using System.Data.SQLite;   // local .dll file
using System.Text.Json;
using System.IO.Pipelines;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO.Pipes;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;
using System.IO.IsolatedStorage;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

using System.Data.Common;

#pragma foreign_keys = ON;

Config GameConfig = await Game.GetGameConfig();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
//app.UseHttpsRedirection();


#region API Functions


app.MapGet("/UserLogin", async (context) => 
{
    UserGet UserDetails = await ParseToObjectFromJson<UserGet>(context);
    
    
    string Sql = $"SELECT * FROM Users WHERE Username == '{UserDetails.Username}' AND Password == '{UserDetails.Password}'";
    var Reader = Methods.ExecuteQuerySQL(Sql, Constants.DATADBDIR);

    if (!await Reader.ReadAsync())
    {
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        return;
    }

    UserPut CurrentUser = new UserPut
    {
        Forename = Reader.GetString(0),
        Surname = Reader.GetString(1),
        Username = Reader.GetString(2),
        Password = "(empty)",
        DateOfBirth = DateTime.Parse(Reader.GetString(4)),
        UserID = Reader.GetInt32(5)
    };

    string JsonString = ParseToJsonFromObject(CurrentUser);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(JsonString);
});


app.MapPost("/CreateUser", async (context) =>
{

    context.Request.EnableBuffering();
    int UserID;

    string t = string.Empty;
    t = await new StreamReader(context.Request.Body).ReadToEndAsync();

    GC.Collect();

    app.Logger.LogInformation("MapPost called");
    app.Logger.LogInformation($"context: {context.Request.ReadFormAsync()}");
    app.Logger.LogInformation($"t: {t}");

    UserPost tUser = JsonConvert.DeserializeObject<UserPost>(t);

    app.Logger.LogInformation($"tUser = {tUser.Username}, {tUser.Password}");

    string sql = $"SELECT Username FROM Users WHERE Username == '{tUser.Username}'";
    using (SQLiteDataReader reader = Methods.ExecuteQuerySQL(sql))
    {

        // If value with entered username found then inform the user and return
        if (reader.Read())
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            app.Logger.LogInformation("Conflict detected: username already exists in database");
            return;
        }
    };

    // Declare Reader outside of while loop - needed to be given a value
    SQLiteDataReader Reader = null;

    // Generate UserID if UserID already exists generate another one
    do
    {
        // UserID 0 reserved to admin account
        UserID = new Random().Next(1, int.MaxValue);

        sql = $"SELECT UserID FROM Users WHERE UserID == '{UserID}'";
        Reader = Methods.ExecuteQuerySQL(sql);
    } while (Reader.Read());

    Reader.DisposeAsync();

    // Add the user to the database
    Methods.CreateUser(tUser.Forename, tUser.Surname, tUser.Username, tUser.Password, DateOnly.FromDateTime(tUser.DateOfBirth), UserID);

    app.Logger.LogInformation("Added user successfully");


    context.Response.StatusCode = (int)HttpStatusCode.OK;
});

//Update user stuff
app.MapPut("/UpdateUser", async (context) =>
{
    UserPut tUser;
    UserPut CurrentUser;

    string Properties = await new StreamReader(context.Request.Body).ReadToEndAsync();
    app.Logger.LogInformation("UserPut request made");
    app.Logger.LogInformation($"Properties: {Properties}");

    GC.Collect();

    List<UserPut> UserDetails = JsonConvert.DeserializeObject<List<UserPut>>(Properties);

    tUser = UserDetails[0];
    CurrentUser = UserDetails[1];

    try
    {
        Methods.UpdateUser(tUser, CurrentUser);
    }
    catch (ArgumentException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.NotAcceptable;
        return;
    }

    context.Response.StatusCode = (int)HttpStatusCode.OK;
    /*
        app.Logger.LogInformation("Parsed JArray");
        app.Logger.LogInformation($"tUser.Username: {tUser.Username}\ttUser.Password: {tUser.Password}");
    */

});

//Delete a user account
app.MapDelete("/RemoveUser", async (context) =>
{

    GC.Collect();
    List<string> UserProperties = await ParseToObjectFromJson<List<string>>(context);

    app.Logger.LogInformation($"Map delete called for user: {UserProperties[0]}");

    Methods.DeleteUser(UserProperties[0], UserProperties[1]);
    GC.Collect();

    context.Response.StatusCode = (int)HttpStatusCode.OK;
});

// Add card to database
app.MapPost("/AddCard", async (context) =>
{
    string StrContext = await new StreamReader(context.Request.Body).ReadToEndAsync();

    AddCard NewCard = JsonConvert.DeserializeObject<AddCard>(StrContext);
    app.Logger.LogInformation($"tAddCard.CardName: {NewCard.CardName}");

    string sql = $"SELECT CardName FROM AvailableCardList WHERE CardName == '{NewCard.CardName}'";

    using (SQLiteDataReader reader = Methods.ExecuteQuerySQL(sql, Constants.AVAILABLECARDOPTIONSDBDIR))
    {

        // If CardName already exists then inform the user and return
        if (reader.Read())
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            app.Logger.LogInformation("Conflict detected: CardName already exists in database");
            return;
        }
    };

    await File.WriteAllBytesAsync($"{Constants.CARDDIR}/{NewCard.CardName}.png", NewCard.CardImage);

    sql = $"INSERT INTO AvailableCardList (CardName, CardRarity) values ('{NewCard.CardName}', '{NewCard.CardRarity}')";
    Methods.ExecuteNonQuerySQL(sql, Constants.AVAILABLECARDOPTIONSDBDIR);

    context.Response.StatusCode = (int)HttpStatusCode.OK;
});

// Add frame to the database
app.MapPost("/AddFrame", async (context) =>
{
    AddFrame NewFrame = await ParseToObjectFromJson<AddFrame>(context);

    string Sql = $"SELECT FrameName FROM AvailableFrameList WHERE FrameName == '{NewFrame.FrameName}'";
   
    using (SQLiteDataReader reader = Methods.ExecuteQuerySQL(Sql, Constants.AVAILABLECARDOPTIONSDBDIR))
    {

        // If FrameName already exists then inform the user and return
        if (reader.Read())
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            app.Logger.LogInformation("Conflict detected: FrameName already exists in database");
            return;
        }
    };

    await File.WriteAllBytesAsync($"{Constants.FRAMEDIR}/{NewFrame.FrameName}.png", NewFrame.FrameImage);

    Sql = $"INSERT INTO AvailableFrameList (FrameName) values ('{NewFrame.FrameName}')";
    Methods.ExecuteNonQuerySQL(Sql, Constants.AVAILABLECARDOPTIONSDBDIR);

    context.Response.StatusCode = (int)HttpStatusCode.OK;

});

app.MapPost("/AddRarity", async (context) =>
{
    string StrContext = await new StreamReader(context.Request.Body).ReadToEndAsync();

    string sql = $"SELECT CardRarity FROM AvailableCardRarityList WHERE CardRarity == '{StrContext}'";

    using (SQLiteDataReader reader = Methods.ExecuteQuerySQL(sql, Constants.AVAILABLECARDOPTIONSDBDIR))
    {

        // If CardRarity already exists then inform the user and return
        if (reader.Read())
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
            app.Logger.LogInformation("Conflict detected: CardRarity already exists in database");
            return;
        }
    };

    sql = $"INSERT INTO AvailableCardRarityList (CardRarity) values ('{StrContext}')";
    Methods.ExecuteNonQuerySQL(sql, Constants.AVAILABLECARDOPTIONSDBDIR);

    context.Response.StatusCode = (int)HttpStatusCode.OK;
});

app.MapGet("/Drop", async (context) =>
{
    app.Logger.LogInformation("Drop request made");

    int NumberOfRows;
    int NumberOfRows_3;
    int FrameSelected;
    string NewFrameName;
    byte[] NewFrameImageData;
    int CardID;
    int NewFrameID;
    SQLiteDataReader NewReader;
    UserPut CurrentUser = await ParseToObjectFromJson<UserPut>(context);

    string sql = $"SELECT CoolDownDate FROM Users WHERE UserID == '{CurrentUser.UserID}'";

    using (var Reader = Methods.ExecuteQuerySQL(sql, Constants.DATADBDIR))
    {

        DateTime CoolDownDateTime;
        if (await Reader.ReadAsync())
        {
            if (!await Reader.IsDBNullAsync(0))
            {
                CoolDownDateTime = DateTime.Parse(Reader.GetString(0));

                if (DateTime.Now.CompareTo(CoolDownDateTime) < 0)
                {
                    TimeSpan CoolDownTimer = CoolDownDateTime - DateTime.Now;
                    string JsonString = ParseToJsonFromObject(CoolDownTimer);

                    context.Response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
                    await context.Response.WriteAsync(JsonString);
                    return;
                }
            }
        }
    }

    //GC.Collect();

    sql = $"SELECT COUNT(*) FROM AvailableCardList";

    // Get number of rows that AvailableCardList has
    using (SQLiteConnection dbConnection = Methods.GetDBConnection(Constants.AVAILABLECARDOPTIONSDBDIR))
    {
        dbConnection.Open();

        SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

        NumberOfRows = Convert.ToInt32(command.ExecuteScalar());
    }


    app.Logger.LogInformation($"Number of rows: {NumberOfRows}");


    List<CardDropCards> NewCardDropCards = new List<CardDropCards>();
    (List<string> CardNameString, List<string> CardRarityString) = APIMethods.GetRandomFromTableAsList(NumberOfRows);
    

    sql = $"SELECT COUNT(*) FROM AvailableFrameList";

    using (SQLiteConnection dbConnection = Methods.GetDBConnection(Constants.AVAILABLECARDOPTIONSDBDIR))
    {
        dbConnection.Open();

        SQLiteCommand command = new SQLiteCommand(sql, dbConnection);

        NumberOfRows_3 = Convert.ToInt32(command.ExecuteScalar());
        dbConnection.Close();
    }


    List<int> AllCardIDs = new List<int>();

    // Check CardID doesn't already exist
    for (int i = 0; i < 3; i++)
    {
        do
        {
            CardID = new Random().Next(1, int.MaxValue);

            sql = $"SELECT CardID FROM Cards WHERE CardID == '{CardID}'";
            NewReader = Methods.ExecuteQuerySQL(sql);
        } while (NewReader.Read());
        
        AllCardIDs.Add(CardID);
    }

    List<byte[]> CardImages = new List<byte[]>();

    // Converts images with same name as in table to byte array
    for (int i = 0; i < 3; i++)
    {
        CardImages.Add(await APIMethods.GetImageBinary($"{Constants.CARDDIR}/{CardNameString[i]}.png"));
    }

    for (int i = 0; i < 3; i++)
    {
        NewCardDropCards.Add(new CardDropCards(CardRarityString[i], CardNameString[i], CardImages[i], AllCardIDs[i]));
    }

    FrameSelected = new Random().Next(1, NumberOfRows_3 + 1);

    sql = $"SELECT FrameName FROM AvailableFrameList WHERE rowid == '{FrameSelected}'";
    var NewReader2 = Methods.ExecuteQuerySQL(sql, Constants.AVAILABLECARDOPTIONSDBDIR);

    await NewReader2.ReadAsync();
    NewFrameName = NewReader2.GetString(0);
    await NewReader2.DisposeAsync();

    NewFrameImageData = await APIMethods.GetImageBinary($"{Constants.FRAMEDIR}/{NewFrameName}.png");

    do
    {
        NewFrameID = new Random().Next(1, int.MaxValue);

        sql = $"SELECT FrameID FROM Frames WHERE FrameID == '{NewFrameID}'";
        NewReader = Methods.ExecuteQuerySQL(sql);
    } while (NewReader.Read());

    CardDropFrame NewFrame = new CardDropFrame
    {
        FrameName = NewFrameName,
        FrameImageData = NewFrameImageData,
        FrameID = NewFrameID
    };

    CardDrop NewCardDrop = new CardDrop
    {
        Cards = NewCardDropCards,
        Frame = NewFrame
    };

    foreach (var card in NewCardDrop.Cards)
        app.Logger.LogInformation($"Card: {card.CardID}");

    System.Text.Json.JsonSerializerOptions JOptions = new JsonSerializerOptions();
    JOptions.IncludeFields = true;

    string StrJson = ParseToJsonFromObject(NewCardDrop, JOptions: JOptions);

    // Prevents the database from locking
    GC.Collect();

    for (int i = 0; i < 3; i++)
    {
        sql = $"INSERT INTO Cards (UserID, CardID, CardName, CardHash, DateObtained) values ('{CurrentUser.UserID}', '{AllCardIDs[i]}', '{CardNameString[i]}', '{DataEncryption.Hash(AllCardIDs[i].ToString())}', '{DateTime.Now}')";
        Methods.ExecuteNonQuerySQL(sql, Constants.DATADBDIR);

        sql = $"INSERT INTO CardProperties (CardID, UserID, CardRarity, CardFrame, CardNickname) values ('{AllCardIDs[i]}', '{CurrentUser.UserID}', '{CardRarityString[i]}', '{null}', '{null}')";
        Methods.ExecuteNonQuerySQL(sql, Constants.DATADBDIR);
    }

    sql = $"INSERT INTO Frames (UserID, FrameID, FrameName, FrameHash, DateObtained) VALUES ('{CurrentUser.UserID}', '{NewFrame.FrameID}', '{NewFrame.FrameName}', '{DataEncryption.Hash(NewFrame.FrameID.ToString())}', '{DateTime.Now}')";
    Methods.ExecuteNonQuerySQL(sql);

    sql = $"UPDATE Users SET CoolDownDate = '{DateTime.Now + TimeSpan.FromSeconds(GameConfig.CardDropCooldown)}' WHERE UserID == '{CurrentUser.UserID}'";
    Methods.ExecuteNonQuerySQL(sql);

    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(StrJson);
});

app.MapGet("/GetCollections", async (context) =>
{
    string StringContext = await new StreamReader(context.Request.Body).ReadToEndAsync();
    UserPut CurrentUser = System.Text.Json.JsonSerializer.Deserialize<UserPut>(StringContext);
    string Sql;
    SQLiteDataReader? Reader = null;
    List<string> Collections = new List<string>();

    try
    {
        Sql = $"SELECT CollectionName FROM Collections WHERE UserID == '{CurrentUser.UserID}'";
        Reader = Methods.ExecuteQuerySQL(Sql, Constants.COLLECTIONDBDIR);
    }
    catch (SQLiteException)
    {
        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        return;
    }

    while (await Reader.ReadAsync())
        Collections.Add(Reader.GetString(0));

    await Reader.DisposeAsync();


    string CollectionsJson = JsonConvert.SerializeObject(Collections);

    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(CollectionsJson);
});

app.MapGet("/GetAllCollectionsWithCard", async (context) =>
{
    Card CurrentCard = await ParseToObjectFromJson<Card>(context);

    string Sql = $"SELECT Collections.CollectionID, Collections.CollectionName From Collections, CardsInCollection WHERE Collections.CollectionID == CardsInCollection.CollectionID AND CardsInCollection.CardID == '{CurrentCard.CardID}'";
    var Reader = Methods.ExecuteQuerySQL(Sql, Constants.COLLECTIONDBDIR);

    List<Collection> UserCollectionsWithCard = new List<Collection>();

    while (await Reader.ReadAsync())
    {
        UserCollectionsWithCard.Add(new Collection
        {
            CollectionID = Reader.GetInt32(0),
            CollectionName = Reader.GetString(1)
        });
    }

    foreach (var x in UserCollectionsWithCard)
        app.Logger.LogInformation($"x: {x.CollectionName}");

    string JsonString = ParseToJsonFromObject(UserCollectionsWithCard);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(JsonString);
});

// Get all frames
app.MapGet("/GetFrames", async (context) =>
{
    UserPut CurrentUser = await ParseToObjectFromJson<UserPut>(context);
    List<GetFrames> UserFrames = new List<GetFrames>();

    string Sql = $"SELECT FrameName, FrameID, CardID FROM Frames WHERE UserID == '{CurrentUser.UserID}'";
    var Reader = Methods.ExecuteQuerySQL(Sql, Constants.DATADBDIR);

    while (await Reader.ReadAsync())
    {
        UserFrames.Add(new GetFrames
        {
            FrameName = Reader.GetString(0),
            FrameID = Reader.GetInt32(1),
            CardID = await Reader.IsDBNullAsync(2) ? null : Reader.GetInt32(2)
        });
    }

    await Reader.DisposeAsync(); // Added this

    string FrameStrings = ParseToJsonFromObject(UserFrames);

    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(FrameStrings);
});

// Gets single user collection as well as all of the cards in the collection
app.MapGet("/GetSingleCollection", async (context) =>
{
    var StringContext = await new StreamReader(context.Request.Body).ReadToEndAsync();
    GetCollection CurrentCollection = System.Text.Json.JsonSerializer.Deserialize<GetCollection>(StringContext);

    string Sql = $"SELECT CollectionID, UserID, CollectionName, IsPublic, DateCreated FROM Collections WHERE CollectionName == '{CurrentCollection.CollectionName}' AND UserID == '{CurrentCollection.UserID}'";
    var Reader = Methods.ExecuteQuerySQL(Sql, Constants.COLLECTIONDBDIR);

    Collection UserCollection = new Collection();
    List<int> UserCardIDs = new List<int>();
    List<Card> UserCards = new List<Card>();

    if (await Reader.ReadAsync())
        UserCollection = new Collection
        {
            CollectionID = Reader.GetInt32(0),
            UserID = Reader.GetInt32(1),
            CollectionName = Reader.GetString(2),
            IsPublic = bool.Parse(Reader.GetString(3)),
            DateCreated = DateTime.Parse(Reader.GetString(4))
        };

    await Reader.DisposeAsync();

    if (UserCollection.UserID != CurrentCollection.UserID && UserCollection.CollectionName != CurrentCollection.CollectionName)
        throw new Exception();

    Sql = $"SELECT CardID FROM CardsInCollection WHERE CollectionID == '{UserCollection.CollectionID}' AND UserID == '{UserCollection.UserID}'";
    Reader = Methods.ExecuteQuerySQL(Sql, Constants.COLLECTIONDBDIR);

    while (await Reader.ReadAsync())
    {
        UserCardIDs.Add(Reader.GetInt32(0));
    }

    await Reader.DisposeAsync();
    
    app.Logger.LogInformation($"CardIDs: {string.Join(" ", UserCardIDs)}");


    string CardIDGroup = string.Join(", ", UserCardIDs);

    Sql = $"SELECT Cards.CardName, Cards.CardID, Cards.CardHash, Cards.DateObtained, CardProperties.CardRarity, CardProperties.CardFrame, CardProperties.CardNickname FROM Cards, CardProperties WHERE Cards.CardID IN ({CardIDGroup}) AND CardProperties.CardID == Cards.CardID";
    Reader = Methods.ExecuteQuerySQL(Sql, Constants.DATADBDIR);

    while (await Reader.ReadAsync())
        UserCards.Add(new Card
        {
            CardName = Reader.GetString(0),
            CardID = Reader.GetInt32(1),
            CardHash = Reader.GetString(2),
            DateObtained = DateTime.Parse(Reader.GetString(3)),
            Properties = new CardProperties
            {
                CardRarity = Reader.GetString(4),
                CardFrame = Reader.GetString(5),
                CardNickname = Reader.GetString(6)
            }
        });

    await Reader.DisposeAsync();

    UserCollection.Cards = UserCards;

    foreach (Card x in UserCards)
    {
        app.Logger.LogInformation($"CardID: {x.CardID}\tCardname: {x.CardName}");
    }

    string StringJson = System.Text.Json.JsonSerializer.Serialize(UserCollection);

    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(StringJson);

});

// Gets all of the cards that a user currently has
app.MapGet("/GetAllCards", async (context) =>
{
    string StringContext = await new StreamReader(context.Request.Body).ReadToEndAsync();
    app.Logger.LogInformation($"StringContext: {StringContext}");
    UserPut CurrentUser = JsonConvert.DeserializeObject<UserPut>(StringContext);
    List<Card> UserCards = new List<Card>();

    app.Logger.LogInformation($"GetCards request made for users: {CurrentUser.Username}");

    string Sql = $"SELECT Cards.CardID, Cards.CardName, Cards.CardHash, Cards.DateObtained, CardProperties.CardRarity, CardProperties.CardFrame, CardProperties.CardNickname FROM Cards, CardProperties WHERE Cards.CardID == CardProperties.CardID AND Cards.UserID == '{CurrentUser.UserID}'";
    var Reader = Methods.ExecuteQuerySQL(Sql, Constants.DATADBDIR);

    while (await Reader.ReadAsync())
        UserCards.Add(new Card
        {
            CardID = Reader.GetInt32(0),
            CardName = Reader.GetString(1),
            CardHash = Reader.GetString(2),
            DateObtained = DateTime.Parse(Reader.GetString(3)),
            UserID = CurrentUser.UserID,
            Properties = new CardProperties
            {
                CardRarity = Reader.GetString(4),
                CardFrame = Reader.GetString(5),
                CardNickname = Reader.GetString(6)
            }
        });

    await Reader.DisposeAsync(); // Added this
    

    foreach (Card x in UserCards)
        app.Logger.LogInformation($"Card: {x.CardName}");

    string UserCardsJson = JsonConvert.SerializeObject(UserCards);

    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(UserCardsJson);

    app.Logger.LogInformation("end");

});


// Gets all cards that the user creating the trade can create a trade with - i.e. not being used in another trade
app.MapGet("/GetUserFromTradeCards", async (context) =>
{
    UserPut CurrentUser = await ParseToObjectFromJson<UserPut>(context);
    List<Card> UserCards = new List<Card>();

    app.Logger.LogInformation($"GetUserFromTradeCards request made for user: {CurrentUser.Username}");


    List<int> CardIndexInTrades = new List<int>();
    string Sql = $"SELECT CardGivenID FROM TradeGive";

    var Reader = Methods.ExecuteQuerySQL(Sql, Constants.TRADEDBDIR);

    while (await Reader.ReadAsync())
        CardIndexInTrades.Add(Reader.GetInt32(0));

    await Reader.DisposeAsync(); // Added this


    Sql = $"SELECT Cards.CardID, Cards.CardName, Cards.CardHash, Cards.DateObtained, Cards.UserID, CardProperties.CardRarity, CardProperties.CardFrame, CardProperties.CardNickname FROM Cards, CardProperties WHERE Cards.UserID == '{CurrentUser.UserID}' AND Cards.CardID == CardProperties.CardID";

    Reader = Methods.ExecuteQuerySQL(Sql, Constants.DATADBDIR);

    app.Logger.LogInformation("after sql");


    while (await Reader.ReadAsync())
    {
        if (CardIndexInTrades.Contains(Reader.GetInt32(0)))
            continue;

        UserCards.Add(new Card
        {
            CardID = Reader.GetInt32(0),
            CardName = Reader.GetString(1),
            CardHash = Reader.GetString(2),
            DateObtained = DateTime.Parse(Reader.GetString(3)),
            UserID = Reader.GetInt32(4),
            Properties = new CardProperties
            {
                CardRarity = Reader.GetString(5),
                CardFrame = Reader.GetString(6),
                CardNickname = Reader.GetString(7),
            }
        });
    }

    await Reader.DisposeAsync(); // Added this


    foreach (Card x in UserCards)
        app.Logger.LogInformation($"Card: {x.CardName}");

    string UserCardsJson = ParseToJsonFromObject(UserCards);

    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(UserCardsJson);

    app.Logger.LogInformation("end");

});

app.MapGet("/GetAllTradeUserCards", async (context) =>
{
    UserPut CurrentUser = await ParseToObjectFromJson<UserPut>(context);
    List<Card> UserCards = new List<Card>();

    app.Logger.LogInformation($"GetTradeCards request made for users: {CurrentUser.Username}\tUserID: {CurrentUser.UserID}");

    
    // This works - not really
    string Sql = $"ATTACH '{Constants.COLLECTIONDBDIR}' as CollectionDB; ATTACH '{Constants.TRADEDBDIR}' as TradeDB;" +
                 $"SELECT CardsInCollection.CardID, Cards.CardName, Cards.CardHash, Cards.DateObtained, CardProperties.CardRarity, CardProperties.CardFrame, CardProperties.CardNickname FROM CollectionDB.Collections, CardsInCollection, Cards, CardProperties, TradeDB.TradeGive WHERE Collections.UserID == '{CurrentUser.UserID}' AND Collections.IsPublic == 'True' " +
                 $"AND Collections.CollectionID == CardsInCollection.CollectionID AND CardsInCollection.CardID == Cards.CardID " +
                 $"AND Cards.CardID == CardProperties.CardID";

    string Sql2 = $"ATTACH '{Constants.COLLECTIONDBDIR}' as CollectionDB; ATTACH '{Constants.TRADEDBDIR}' as TradeDB; ";


    string Sql04 = $"ATTACH '{Constants.COLLECTIONDBDIR}' as CollectionDB; ATTACH '{Constants.TRADEDBDIR}' as TradeDB;" +
    "SELECT CardsInCollection.CardID, Cards.CardName, Cards.CardHash, Cards.DateObtained, CardProperties.CardRarity, CardProperties.CardFrame, CardProperties.CardNickname " +
    "FROM (CollectionDB.Collections INNER JOIN((CardsInCollection INNER JOIN Cards ON CardsInCollection.CardID = Cards.CardID) INNER JOIN CardProperties ON Cards.CardID = CardProperties.CardID) ON CollectionDB.Collections.CollectionID = CardsInCollection.CollectionID) " +
    $"WHERE CollectionDB.Collections.IsPublic = 'True' AND CollectionDB.Collections.UserID = {CurrentUser.UserID}";

    List<int> CardIndexInTrades = new List<int>();
    Sql = $"SELECT CardReceivedID FROM TradeReceive";

    var Reader = Methods.ExecuteQuerySQL(Sql, Constants.TRADEDBDIR);

    while (await Reader.ReadAsync())
        CardIndexInTrades.Add(Reader.GetInt32(0));

    Reader = Methods.ExecuteQuerySQL(Sql04, Constants.DATADBDIR);

    while (await Reader.ReadAsync())
    {
        if (CardIndexInTrades.Contains(Reader.GetInt32(0)) || UserCards.Select(x => (int)x.CardID).ContainsElement(Reader.GetInt32(0)))
            continue;

        UserCards.Add(new Card
        {
            CardID = Reader.GetInt32(0),
            CardName = Reader.GetString(1),
            CardHash = Reader.GetString(2),
            DateObtained = string.IsNullOrWhiteSpace(Reader.GetString(3)) ? null : DateTime.Parse(Reader.GetString(3)),
            Properties = new CardProperties
            {
                CardRarity = Reader.GetString(4),
                CardFrame = Reader.GetString(5),
                CardNickname = Reader.GetString(6)
            }
        });
    }

    await Reader.DisposeAsync();

    foreach (Card x in UserCards)
        app.Logger.LogInformation($"Card: {x.CardName}");

    string UserCardsJson = ParseToJsonFromObject(UserCards);

    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(UserCardsJson);

    app.Logger.LogInformation("end");

});

app.MapGet("/GetThreeCardImages", async (context) =>
{
    string StringContext = await new StreamReader(context.Request.Body).ReadToEndAsync();
    string[] CardNames = JsonConvert.DeserializeObject<string[]>(StringContext);

    app.Logger.LogInformation($"GetThreeImages request made for cards:\n{string.Join("\n", CardNames)}");


    List<byte[]> CardImages = new List<byte[]>();

    for (int i = 0; i < 3; i++)
        CardImages.Add(await APIMethods.GetImageBinary($"{Constants.CARDDIR}/{CardNames[i]}.png"));

    string CardImagesJson = JsonConvert.SerializeObject(CardImages);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(CardImagesJson);
});

app.MapGet("/GetSingleCardImage", async (context) =>
{
    string StringContext = await new StreamReader(context.Request.Body).ReadToEndAsync();
    string CardName = JsonConvert.DeserializeObject<string>(StringContext);

    byte[] CardImage = await APIMethods.GetImageBinary($"{Constants.CARDDIR}/{CardName}.png");

    string CardImageJson = JsonConvert.SerializeObject(CardImage);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(CardImageJson);
});

app.MapGet("GetSingleFrameImage", async (context) =>
{
    string FrameName = await ParseToObjectFromJson<string>(context);

    byte[] FrameImage = await APIMethods.GetImageBinary($"{Constants.FRAMEDIR}/{FrameName}.png");

    string FrameImageJson = ParseToJsonFromObject(FrameImage);

    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(FrameImageJson);
});

app.MapPost("/CreateCollection", async (context) =>
{
    string StringContext = await new StreamReader(context.Request.Body).ReadToEndAsync();
    Collection NewCollection = System.Text.Json.JsonSerializer.Deserialize<Collection>(StringContext);


    GC.Collect();

    int NewCollectionID;
    string NewSql;
    SQLiteDataReader Reader = null;

    NewSql = $"SELECT CollectionName FROM COLLECTIONS WHERE UserID == '{NewCollection.UserID}' AND CollectionName == '{NewCollection.CollectionName}'";
    Reader = Methods.ExecuteQuerySQL(NewSql, Constants.COLLECTIONDBDIR);

    // Check to see if collection name is already used by user
    if (await Reader.ReadAsync())
    {
        context.Response.StatusCode = (int)HttpStatusCode.Conflict;
        return;
    }

    await Reader.DisposeAsync();


    do
    {
        NewCollectionID = new Random().Next(1, int.MaxValue);

        NewSql = $"SELECT CollectionID FROM Collections WHERE CollectionID == '{NewCollectionID}'";
        Reader = Methods.ExecuteQuerySQL(NewSql, Constants.COLLECTIONDBDIR);
    } while (Reader.Read());

    await Reader.DisposeAsync();

    NewCollection.CollectionID = NewCollectionID;

    string Sql = $"INSERT INTO Collections (CollectionID, CollectionName, UserID, IsPublic, DateCreated) values ('{NewCollection.CollectionID}', '{NewCollection.CollectionName}',  '{NewCollection.UserID}', '{NewCollection.IsPublic}', '{NewCollection.DateCreated}')";

    try
    {
        Methods.ExecuteNonQuerySQL(Sql, Constants.COLLECTIONDBDIR);
    }
    catch (SQLiteException ex)
    {
        context.Response.StatusCode = (int)HttpStatusCode.Conflict;
        return;
    }

    Sql = "INSERT INTO CardsInCollection (CollectionID, UserID, CardID) VALUES ";

    foreach (Card CurrentCard in NewCollection.Cards)
    {
        Sql += $"('{NewCollection.CollectionID}', '{NewCollection.UserID}', '{CurrentCard.CardID}'), ";
    }

    GC.Collect();

    // Remove ending comma and space
    Sql = Sql.Remove(Sql.Length - 2);
    Methods.ExecuteNonQuerySQL(Sql, Constants.COLLECTIONDBDIR);


    context.Response.StatusCode = (int)HttpStatusCode.OK;
});

app.MapPut("/UpdateCollection", async (context) =>
{
    string StringContext = await new StreamReader(context.Request.Body).ReadToEndAsync();
    UpdateCollection UpdateUserCollection = System.Text.Json.JsonSerializer.Deserialize<UpdateCollection>(StringContext);
    string Sql = $"UPDATE Collections SET ";

    bool UpdateName = false;


    if (UpdateUserCollection.NewCollectionName != null)
    {
        Sql += $"CollectionName = '{UpdateUserCollection.NewCollectionName}', ";
        UpdateName = true;
    }

    Sql += $"IsPublic = '{UpdateUserCollection.IsPublic}'";
    Sql += $"WHERE CollectionID = '{UpdateUserCollection.CollectionID}' ";

    Methods.ExecuteNonQuerySQL(Sql, Constants.COLLECTIONDBDIR);

    if (UpdateUserCollection.CardsRemoved != null && UpdateUserCollection.CardsRemoved.Count > 0)
    {
        List<int> CardIDsToRemove = new List<int>();
        foreach (Card CurrentCard in UpdateUserCollection.CardsRemoved)
        {
            CardIDsToRemove.Add((int)CurrentCard.CardID);
        }

        Sql = $"DELETE FROM CardsInCollection WHERE CardID IN ({string.Join(", ",CardIDsToRemove)}) AND CollectionID == '{UpdateUserCollection.CollectionID}'";

        Methods.ExecuteNonQuerySQL(Sql, Constants.COLLECTIONDBDIR);
    }

    context.Response.StatusCode = (int)HttpStatusCode.OK;
});

// Deletes a collection from a user and removes all cards from that collection
app.MapDelete("/DeleteCollection", async (context) =>
{
    Collection CollectionToDelete = await ParseToObjectFromJson<Collection>(context);

    string Sql = $"DELETE FROM CardsInCollection WHERE CollectionID == '{CollectionToDelete.CollectionID}'";
    Methods.ExecuteNonQuerySQL(Sql, Constants.COLLECTIONDBDIR);

    Sql = $"DELETE FROM Collections WHERE CollectionID == '{CollectionToDelete.CollectionID}'";
    Methods.ExecuteNonQuerySQL(Sql, Constants.COLLECTIONDBDIR);

    context.Response.StatusCode = (int)HttpStatusCode.OK;
});

// Handles user search request
app.MapGet("SearchRequest", async (context) =>
{
    NewSearch NewSearchRequest = await ParseToObjectFromJson<NewSearch>(context);
    List<UserSearchResults> USearchResults = new List<UserSearchResults>();
    List<Card> CardSearchResults = new List<Card>();
    List<CollectionSearchResults> NewCollectionSearchResults = new List<CollectionSearchResults>();

    string Sql;
    string JsonString = "<empty>";
    app.Logger.LogInformation($"Search request made of type: {NewSearchRequest.SearchType}");


    switch (NewSearchRequest.SearchType)
    {
        case SearchTypes.Users:
            if (NewSearchRequest.SearchKeyword == null)
                Sql = $"SELECT Username, DateOfBirth, UserID FROM Users";
            else
                Sql = $"SELECT Username, DateOfBirth, UserID FROM Users WHERE Username LIKE '%{NewSearchRequest.SearchKeyword}%'";

            var Reader = Methods.ExecuteQuerySQL(Sql, Constants.DATADBDIR);

            while (await Reader.ReadAsync())
            {
                // If UserID is 0 skip - UserID 0 is reserved for admin account
                // Also if UserID equals the current users id skip
                if (Reader.GetInt32(2) == 0 || Reader.GetInt32(2) == NewSearchRequest.UserID)
                    continue;

                USearchResults.Add(new UserSearchResults
                {
                    Username = Reader.GetString(0),
                    DateOfBirth = DateTime.Parse(Reader.GetString(1)),
                    UserID = Reader.GetInt32(2)
                });
            }

            await Reader.DisposeAsync();

            JsonString = ParseToJsonFromObject(USearchResults);

            break;
        case SearchTypes.Cards:
            if (NewSearchRequest?.SearchKeyword == null)
                Sql = $"SELECT Cards.CardID, Cards.CardName, Cards.CardHash, Cards.DateObtained, CardProperties.CardRarity, CardProperties.CardFrame, CardProperties.CardNickname FROM Cards, CardProperties WHERE Cards.UserID == '{NewSearchRequest.UserID}' AND Cards.CardID == CardProperties.CardID";
            else    
                Sql = $"SELECT Cards.CardID, Cards.CardName, Cards.CardHash, Cards.DateObtained, CardProperties.CardRarity, CardProperties.CardFrame, CardProperties.CardNickname FROM Cards, CardProperties WHERE Cards.UserID == '{NewSearchRequest.UserID}' AND Cards.CardID == CardProperties.CardID AND Cards.CardName LIKE '%{NewSearchRequest.SearchKeyword}%'";

            var Reader2 = Methods.ExecuteQuerySQL(Sql, Constants.DATADBDIR);

            while (await Reader2.ReadAsync())
            {
                CardSearchResults.Add(new Card
                {
                    CardID = Reader2.GetInt32(0),
                    CardName = Reader2.GetString(1),
                    CardHash = Reader2.GetString(2),
                    DateObtained = DateTime.Parse(Reader2.GetString(3)),
                    Properties = new CardProperties
                    {
                        CardRarity = Reader2.GetString(4),
                        CardFrame = Reader2.GetString(5),
                        CardNickname = Reader2.GetString(6),
                    }
                });
            }

            await Reader2.DisposeAsync();

            JsonString = ParseToJsonFromObject<List<Card>>(CardSearchResults);
            
            break;
        case SearchTypes.Collections:
            if (NewSearchRequest.SearchKeyword == null)
                Sql = $"SELECT CollectionID, CollectionName, IsPublic, DateCreated FROM Collections WHERE UserID == '{NewSearchRequest.UserID}'";
            else
                Sql = $"SELECT CollectionID, CollectionName, IsPublic, DateCreated FROM Collections WHERE UserID == '{NewSearchRequest.UserID}' AND CollectionName LIKE '%{NewSearchRequest.SearchKeyword}%'";

            var Reader3 = Methods.ExecuteQuerySQL(Sql, Constants.COLLECTIONDBDIR);

            while (await Reader3.ReadAsync())
            {
                NewCollectionSearchResults.Add(new CollectionSearchResults
                {
                    CollectionID = Reader3.GetInt32(0),
                    CollectionName = Reader3.GetString(1),
                    IsPublic = bool.Parse(Reader3.GetString(2)),
                    DateCreated = DateTime.Parse(Reader3.GetString(3))
                });
            }

            await Reader3.DisposeAsync();

            JsonString = ParseToJsonFromObject(NewCollectionSearchResults);

            break;
        case SearchTypes.TradesSent:
            if (NewSearchRequest.SearchKeyword == null)
                Sql = $"SELECT TradeName, UserFromID, UserToID, DateRequested, TradeID FROM Trades WHERE UserFromID == '{NewSearchRequest.UserID}'";
            else    
                Sql = $"SELECT TradeName, UserFromID, UserToID, DateRequested, TradeID FROM Trades WHERE UserFromID == '{NewSearchRequest.UserID}' AND TradeName LIKE '%{NewSearchRequest.SearchKeyword}%'";

            var Reader4 = Methods.ExecuteQuerySQL(Sql, Constants.TRADEDBDIR);

            List<TradeSearch> NewTradeSearch = new List<TradeSearch>();

            while (await Reader4.ReadAsync())
                NewTradeSearch.Add(new TradeSearch
                {
                    TradeName = Reader4.GetString(0),
                    UserFromID = Reader4.GetInt32(1),
                    UserToID = Reader4.GetInt32(2),
                    DateRequested = DateTime.Parse(Reader4.GetString(3)),
                    TradeID = Reader4.GetInt32(4)
                });

            await Reader4.DisposeAsync();

            JsonString = ParseToJsonFromObject(NewTradeSearch);

            break;
        case SearchTypes.IncomingTrades:
            if (NewSearchRequest.SearchKeyword == null)
                Sql = $"SELECT TradeName, UserFromID, UserToID, DateRequested, TradeID FROM Trades WHERE UserToID == '{NewSearchRequest.UserID}'";
            else
                Sql = $"SELECT TradeName, UserFromID, UserToID, DateRequested, TradeID FROM Trades WHERE UserToID == '{NewSearchRequest.UserID}' AND TradeName LIKE '%{NewSearchRequest.SearchKeyword}%'";

            var Reader5 = Methods.ExecuteQuerySQL(Sql, Constants.TRADEDBDIR);

            List<TradeSearch> NewTradeReceiveSearch = new List<TradeSearch>();

            // UserFromID and UserToID are swapped 
            while (await Reader5.ReadAsync())
                NewTradeReceiveSearch.Add(new TradeSearch
                {
                    TradeName = Reader5.GetString(0),
                    UserFromID = Reader5.GetInt32(1),
                    UserToID = Reader5.GetInt32(2),
                    DateRequested = DateTime.Parse(Reader5.GetString(3)),
                    TradeID = Reader5.GetInt32(4)
                });

            await Reader5.DisposeAsync();

            JsonString = ParseToJsonFromObject(NewTradeReceiveSearch);

            break;
        case SearchTypes.News:
            if (NewSearchRequest.SearchKeyword == null)
                Sql = $"SELECT Title, DateCreated FROM News ORDER BY DateCreated DESC";
            else
                Sql = $"SELECT Title, DateCreated FROM News WHERE Title LIKE '%{NewSearchRequest.SearchKeyword}%' ORDER BY DateCreated DESC ";

            Reader = Methods.ExecuteQuerySQL(Sql, Constants.NEWSDBDIR);

            List<News> AllNews = new List<News>();

            while (await Reader.ReadAsync())
                AllNews.Add(new News
                {
                    Title = Reader.GetString(0),
                    Content = "",
                    DateCreated = DateTime.Parse(Reader.GetString(1))
                });

            JsonString = ParseToJsonFromObject(AllNews);

            // Dispose reader object
            await Reader.DisposeAsync();

            break;
        case SearchTypes.AvailableCards:
            if (NewSearchRequest.SearchKeyword == null)
                Sql = $"SELECT CardName, CardRarity FROM AvailableCardList";
            else
                Sql = $"SELECT CardName, CardRarity FROM AvailableCardList WHERE CardName LIKE '%{NewSearchRequest.SearchKeyword}%'";

            Reader = Methods.ExecuteQuerySQL(Sql, Constants.AVAILABLECARDOPTIONSDBDIR);

            List<AvailableCardSearch> CurrentAvailableCardSearch = new List<AvailableCardSearch>();

            while (await Reader.ReadAsync())
                CurrentAvailableCardSearch.Add(new AvailableCardSearch
                {
                    CardName = Reader.GetString(0),
                    CardRarity = Reader.GetString(1)
                }) ;

            JsonString = ParseToJsonFromObject(CurrentAvailableCardSearch);

            await Reader.DisposeAsync();

            break;
        case SearchTypes.AvailableFrames:
            if (NewSearchRequest.SearchKeyword == null)
                Sql = $"SELECT FrameName FROM AvailableFrameList";
            else
                Sql = $"SELECT FrameName FROM AvailableFrameList WHERE FrameName LIKE '%{NewSearchRequest.SearchKeyword}%'";

            Reader = Methods.ExecuteQuerySQL(Sql, Constants.AVAILABLECARDOPTIONSDBDIR);

            List<string> Frames = new List<string>();

            while (await Reader.ReadAsync())
                Frames.Add(Reader.GetString(0));

            JsonString = ParseToJsonFromObject(Frames);

            await Reader.DisposeAsync();

            break;
    }

    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(JsonString);
});

app.MapPut("/UpdateCard", async (context) =>
{
    UpdateCard NewCardUpdate = await ParseToObjectFromJson<UpdateCard>(context);

    GC.Collect();
    app.Logger.LogInformation($"CN: {NewCardUpdate.CardFrame}");

    string Sql = "Update CardProperties SET ";

    if (NewCardUpdate.CardNickname != null)
    {
        string NewSql = $"Update CardProperties SET CardNickname = '{NewCardUpdate.CardNickname}' WHERE UserID == '{NewCardUpdate.UserID}' AND CardID == '{NewCardUpdate.CardID}'";
        Methods.ExecuteNonQuerySQL(NewSql, Constants.DATADBDIR);

        Sql += $"CardNickname = '{NewCardUpdate.CardNickname}' ";

        if (NewCardUpdate.CardFrame != null)
            Sql += ", ";
    }

    if (NewCardUpdate.CardFrame != null)
    {
        app.Logger.LogInformation("Not null 12354134234213");
        string NewSql = $"SELECT CardID FROM Frames WHERE FrameID == '{NewCardUpdate.CardFrameID}'";
        var Reader = Methods.ExecuteQuerySQL(NewSql, Constants.DATADBDIR);

        if (await Reader.ReadAsync() && !await Reader.IsDBNullAsync(0) && Reader.GetInt32(0) != NewCardUpdate.CardID)
        {
            context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
            app.Logger.LogInformation("Returning");
            await Reader.DisposeAsync();
            return;
        }

        await Reader.DisposeAsync();

        NewSql = $"Update Frames SET CardID = null WHERE UserID == '{NewCardUpdate.UserID}' AND CardID == '{NewCardUpdate.CardID}';";
        NewSql += $"Update Frames SET CardID = '{NewCardUpdate.CardID}' WHERE UserID == '{NewCardUpdate.UserID}' AND FrameID == '{NewCardUpdate.CardFrameID}'";
        Methods.ExecuteNonQuerySQL(NewSql, Constants.DATADBDIR);

        app.Logger.LogInformation($"UserID: {NewCardUpdate.UserID}\tCardID: {NewCardUpdate.CardID}");

        NewSql = $"Update CardProperties SET CardFrame = '{NewCardUpdate.CardFrame}' WHERE UserID == '{NewCardUpdate.UserID}' AND CardID == '{NewCardUpdate.CardID}'";
        app.Logger.LogInformation($"N: {NewSql}");
        Methods.ExecuteNonQuerySQL(NewSql, Constants.DATADBDIR);

        Sql += $"CardFrame = '{NewCardUpdate.CardFrame}' ";
    }

    Sql += $"WHERE CardID == '{NewCardUpdate.CardID}'";
    app.Logger.LogInformation($"\n\nSQL :{Sql}\n\n");

    if ( !(string.IsNullOrWhiteSpace(NewCardUpdate.CardNickname) && string.IsNullOrWhiteSpace(NewCardUpdate.CardFrame)))
    Methods.ExecuteNonQuerySQL(Sql, Constants.DATADBDIR);

    // TODO: TEST THIS
    if (NewCardUpdate.AddToCollection != null)
    {
        Sql = $"SELECT CollectionID FROM Collections WHERE UserID == '{NewCardUpdate.UserID}' AND CollectionName == '{NewCardUpdate.AddToCollection}'";
        var Reader = Methods.ExecuteQuerySQL(Sql, Constants.COLLECTIONDBDIR);
        await Reader.ReadAsync();

        int AddToCollectionID = Reader.GetInt32(0);
        await Reader.DisposeAsync();

        Sql = $"INSERT INTO CardsInCollection (CollectionID, UserID, CardID) VALUES ('{AddToCollectionID}', '{NewCardUpdate.UserID}', '{NewCardUpdate.CardID}')";
        Methods.ExecuteNonQuerySQL(Sql, Constants.COLLECTIONDBDIR);
    }

    if (NewCardUpdate.RemoveFromCollection != null)
    {
        Sql = $"SELECT CollectionID FROM Collections WHERE UserID == '{NewCardUpdate.UserID}' AND CollectionName == '{NewCardUpdate.RemoveFromCollection}'";
        var Reader = Methods.ExecuteQuerySQL(Sql, Constants.COLLECTIONDBDIR);
        await Reader.ReadAsync();

        int RemoveFromCollectionID = Reader.GetInt32(0);
        await Reader.DisposeAsync();

        Sql = $"DELETE FROM CardsInCollection WHERE UserID == '{NewCardUpdate.UserID}' AND CollectionID == '{RemoveFromCollectionID}' AND CardID == '{NewCardUpdate.CardID}'";
        Methods.ExecuteNonQuerySQL(Sql, Constants.COLLECTIONDBDIR);
    }

});

// Creates a new trade request
app.MapPost("/NewTradeRequest", async (context) =>
{
    Trade NewTradeRequest = await ParseToObjectFromJson<Trade>(context);
    int NewTradeID;

    // Check if user has another trade request with same name - return if one exists
    string Sql = $"SELECT TradeName FROM Trades WHERE UserFromID == '{NewTradeRequest.UserFromID}' AND TradeName == '{NewTradeRequest.TradeName}'";
    var Reader = Methods.ExecuteQuerySQL(Sql, Constants.TRADEDBDIR);

    if (await Reader.ReadAsync())
    {
        context.Response.StatusCode = (int)HttpStatusCode.Conflict;
        await Reader.DisposeAsync();
        return;
    }

    await Reader.DisposeAsync();

    app.Logger.LogInformation($"CardGivenID checked: {string.Join(", ", NewTradeRequest.CardsGiven.Select(x => x.CardID))}");

    // Check if card already exists in another trade request - return if card is already in another trade request
    Sql = $"SELECT * FROM TradeGive, TradeReceive WHERE TradeGive.CardGivenID IN ({string.Join(", ",NewTradeRequest.CardsGiven.Select(x => x.CardID))}) OR TradeReceive.CardReceivedID IN ({string.Join(", ", NewTradeRequest.CardsReceived.Select(x => x.CardID))})";
    Reader = Methods.ExecuteQuerySQL(Sql, Constants.TRADEDBDIR);

    if (await Reader.ReadAsync())
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        await Reader.DisposeAsync();
        return;
    }

    do
    {
        NewTradeID = new Random().Next(1, int.MaxValue);

        Sql = $"SELECT TradeID FROM Trades WHERE TradeID == '{NewTradeID}'";
        Reader = Methods.ExecuteQuerySQL(Sql, Constants.TRADEDBDIR);
    } while (Reader.Read());

    await Reader.DisposeAsync();

    Sql = $"INSERT INTO Trades (TradeName, UserFromID, TradeID, DateRequested, UserToID) VALUES ('{NewTradeRequest.TradeName}', '{NewTradeRequest.UserFromID}', '{NewTradeID}', '{DateTime.Now}', '{NewTradeRequest.UserToID}')";
    Methods.ExecuteNonQuerySQL(Sql, Constants.TRADEDBDIR);

    Sql = $"INSERT INTO TradeGive (TradeID, UserFromID, UserToID, CardGivenID) VALUES ";

    foreach (Card CurrentCard in NewTradeRequest.CardsGiven)
        Sql += $"('{NewTradeID}','{NewTradeRequest.UserFromID}' , '{NewTradeRequest.UserToID}', '{CurrentCard.CardID}'), ";

    Sql = Sql.Remove(Sql.Length - 2);
    Methods.ExecuteNonQuerySQL(Sql, Constants.TRADEDBDIR);

    Sql = $"INSERT INTO TradeReceive (TradeID, UserFromID, UserToID, CardReceivedID) VALUES ";

    foreach (Card CurrentCard in NewTradeRequest.CardsReceived)
        Sql += $"('{NewTradeID}', '{NewTradeRequest.UserFromID}', '{NewTradeRequest.UserToID}', '{CurrentCard.CardID}'), ";

    Sql = Sql.Remove(Sql.Length - 2);
    Methods.ExecuteNonQuerySQL(Sql, Constants.TRADEDBDIR);

    context.Response.StatusCode = (int)HttpStatusCode.OK;
});

// Gets cards in trade - trade sent
app.MapGet("/GetTradeSentCards", async (context) =>
{
    TradeSearch CurrentTradeSearch = await ParseToObjectFromJson<TradeSearch>(context);

    List<Card> CurrentCardsGiven = new List<Card>();

    string Sql = $"ATTACH '{Constants.TRADEDBDIR}' as TradeDB; " +
    $"SELECT Cards.CardID, Cards.CardName, Cards.CardHash, Cards.DateObtained, CardProperties.CardRarity, CardProperties.CardFrame, CardProperties.CardNickname " +
    $"From TradeDB.TradeGive, Cards, CardProperties " +
    $"WHERE TradeDB.TradeGive.CardGivenID == Cards.CardID AND Cards.CardID == CardProperties.CardID AND TradeDB.TradeGive.UserFromID == '{CurrentTradeSearch.UserFromID}'";

    var Reader = Methods.ExecuteQuerySQL(Sql, Constants.DATADBDIR);

    while (await Reader.ReadAsync())
        CurrentCardsGiven.Add(new Card
        {
            CardID = Reader.GetInt32(0),
            CardName = Reader.GetString(1),
            CardHash = Reader.GetString(2),
            DateObtained = DateTime.Parse(Reader.GetString(3)),
            Properties = new CardProperties
            {
                CardRarity = Reader.GetString(4),
                CardFrame = Reader.GetString(5),
                CardNickname = Reader.GetString(6)
            }
        });
    await Reader.DisposeAsync();

    foreach (Card x in CurrentCardsGiven)
        app.Logger.LogInformation($"x: {x.CardName}");

    List<Card> CurrentCardsReceived = new List<Card>();

    Sql = $"ATTACH '{Constants.TRADEDBDIR}' as TradeDB; " +
   $"SELECT Cards.CardID, Cards.CardName, Cards.CardHash, Cards.DateObtained, CardProperties.CardRarity, CardProperties.CardFrame, CardProperties.CardNickname " +
   $"From TradeDB.TradeReceive, Cards, CardProperties " +
   $"WHERE TradeDB.TradeReceive.CardReceivedID == Cards.CardID AND Cards.CardID == CardProperties.CardID AND TradeDB.TradeReceive.UserToID == '{CurrentTradeSearch.UserToID}'";

    Reader = Methods.ExecuteQuerySQL(Sql, Constants.DATADBDIR);

    app.Logger.LogInformation($"UserToID: {CurrentTradeSearch.UserToID}");

    while (await Reader.ReadAsync())
        CurrentCardsReceived.Add(new Card
        {
            CardID = Reader.GetInt32(0),
            CardName = Reader.GetString(1),
            CardHash = Reader.GetString(2),
            DateObtained = DateTime.Parse(Reader.GetString(3)),
            Properties = new CardProperties
            {
                CardRarity = Reader.GetString(4),
                CardFrame = Reader.GetString(5),
                CardNickname = Reader.GetString(6)
            }
        });
    await Reader.DisposeAsync();

    Trade CurrentTrade = new Trade
    {
        TradeName = CurrentTradeSearch.TradeName,
        DateRequested = CurrentTradeSearch.DateRequested,
        UserFromID = CurrentTradeSearch.UserFromID,
        UserToID = CurrentTradeSearch.UserToID,
        CardsGiven = CurrentCardsGiven,
        CardsReceived = CurrentCardsReceived
    };

    GC.Collect();

    string JsonString = ParseToJsonFromObject(CurrentTrade);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(JsonString);
});

// Deletes a trade request
app.MapDelete("/DeleteTradeRequest", async (context) =>
{
    TradeSearch CurrentTradeSearch = await ParseToObjectFromJson<TradeSearch>(context);

    Methods.DeleteTradeRequest(CurrentTradeSearch);

    context.Response.StatusCode = (int)HttpStatusCode.OK;

});


// Processes user response to a trade request - whether they accept or deny the trade request
app.MapPut("/AcceptDenyTradeRequest", async (context) =>
{
    TradeAcceptDeny UserTrade = await ParseToObjectFromJson<TradeAcceptDeny>(context);
    SQLiteDataReader Reader;
    string Sql;
    app.Logger.LogInformation("Accept Trade request called");

    switch (UserTrade.TradeResponse)
    {
        case TradeResponseEnum.Accept:
            List<int> CardGivenID = new List<int>();
            List<int> CardReceivedID = new List<int>();

            Sql = $"SELECT CardGivenID From TradeGive WHERE TradeID == '{UserTrade.CurrentTradeSearch.TradeID}'";

            Reader = Methods.ExecuteQuerySQL(Sql, Constants.TRADEDBDIR);

            while (await Reader.ReadAsync())
                CardGivenID.Add(Reader.GetInt32(0));



            //await Reader.DisposeAsync();

            Sql = $"SELECT CardReceivedID From TradeReceive WHERE TradeID == '{UserTrade.CurrentTradeSearch.TradeID}'";
            Reader = Methods.ExecuteQuerySQL(Sql, Constants.TRADEDBDIR);

            while (await Reader.ReadAsync())
                CardReceivedID.Add(Reader.GetInt32(0));

            //await Reader.DisposeAsync();



            Sql = $"UPDATE Cards SET UserID == '{UserTrade.CurrentTradeSearch.UserToID}' WHERE CardID IN ({string.Join(", ", CardGivenID)});";

            Sql += $"UPDATE CardProperties SET UserID == '{UserTrade.CurrentTradeSearch.UserToID}' WHERE CardID IN ({string.Join(", ", CardGivenID)});";

            Sql += $"UPDATE Frames SET UserID == '{UserTrade.CurrentTradeSearch.UserToID}' WHERE CardID IN ({string.Join(", ", CardGivenID)});";

            Sql += $"UPDATE Cards SET UserID == '{UserTrade.CurrentTradeSearch.UserFromID}' WHERE CardID IN ({string.Join(", ", CardReceivedID)});";

            Sql += $"UPDATE CardProperties SET UserID == '{UserTrade.CurrentTradeSearch.UserFromID}' WHERE CardID IN ({string.Join(", ", CardReceivedID)});";

            Sql += $"UPDATE Frames SET UserID == '{UserTrade.CurrentTradeSearch.UserFromID}' WHERE CardID IN ({string.Join(", ", CardReceivedID)});";
            Methods.ExecuteNonQuerySQLNoDispose(Sql, Constants.DATADBDIR);
            GC.Collect();



            Sql = $"DELETE FROM CardsInCollection WHERE CardID IN ({string.Join(", ", CardReceivedID)}) OR CardID IN ({string.Join(", ", CardGivenID)});";
            Methods.ExecuteNonQuerySQLNoDispose(Sql, Constants.COLLECTIONDBDIR);

            Methods.DeleteTradeRequest(UserTrade.CurrentTradeSearch);

            break;
        case TradeResponseEnum.Deny:
            Methods.DeleteTradeRequest(UserTrade.CurrentTradeSearch);
            break;
    }

    context.Response.StatusCode = (int)HttpStatusCode.OK;
});

// Creates a new news post
app.MapPost("/CreateNewsPost", async (context) =>
{
    News NewNewsPost = await ParseToObjectFromJson<News>(context);

    string Sql = $"SELECT Title FROM News WHERE Title == '{NewNewsPost.Title}'";
    var Reader = Methods.ExecuteQuerySQL(Sql, Constants.NEWSDBDIR);

    if (await Reader.ReadAsync())
    {
        context.Response.StatusCode = (int)HttpStatusCode.Conflict;
        await Reader.DisposeAsync();
        return;
    }
    await Reader.DisposeAsync();

    Sql = $"INSERT INTO News (Title, Content, DateCreated) VALUES ('{NewNewsPost.Title}', '{NewNewsPost.Content}', '{DateTime.Now}')";
    Methods.ExecuteNonQuerySQL(Sql, Constants.NEWSDBDIR);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
});

app.MapGet("/GetNewsPost/{NewsPage}", async Task<object> (int NewsPage) =>
{
    string Sql = $"SELECT * FROM News ORDER BY DateCreated DESC LIMIT 1 OFFSET {NewsPage}";
    var Reader = Methods.ExecuteQuerySQL(Sql, Constants.NEWSDBDIR);
    app.Logger.LogInformation("GetNewsPost called");

    if (await Reader.ReadAsync())
    {

        News GetNews = new News
        {
            Title = Reader.GetString(0),
            Content = Reader.GetString(1),
            DateCreated = DateTime.Parse(Reader.GetString(2))
        };
        await Reader.DisposeAsync();
        string JsonString = ParseToJsonFromObject(GetNews);

        return Results.Ok(JsonString);
    }

    return Results.NoContent();
});

// Gets the most recent card the user has gotten alongisde frame
app.MapGet("/GetMostRecentCard", async (context) =>
{
    UserPut CurrentUser = await ParseToObjectFromJson<UserPut>(context);

    string Sql = $"SELECT Cards.CardID, Cards.CardName, Cards.CardHash, Cards.DateObtained, CardProperties.CardRarity, CardProperties.CardFrame, CardProperties.CardNickname FROM Cards, CardProperties WHERE Cards.CardID == CardProperties.CardID AND Cards.UserID == '{CurrentUser.UserID}' ORDER BY Cards.DateObtained DESC LIMIT 1";
    var Reader = Methods.ExecuteQuerySQL(Sql, Constants.DATADBDIR);

    if (!await Reader.ReadAsync())
    {
        context.Response.StatusCode = (int)HttpStatusCode.NoContent;
        return;
    }

    GetRecentCard RecentCard = new GetRecentCard
    {
        ThisCard = new Card
        {
            CardID = Reader.GetInt32(0),
            CardName = Reader.GetString(1),
            CardHash = Reader.GetString(2),
            DateObtained = DateTime.Parse(Reader.GetString(3)),
            Properties = new CardProperties
            {
                CardRarity = Reader.GetString(4),
                CardFrame = Reader.GetString(5),
                CardNickname = Reader.GetString(6)
            }
        }
    };

    RecentCard.ThisCardImage = await APIMethods.GetImageBinary($"{Constants.CARDDIR}/{RecentCard.ThisCard.CardName}.png");

    if (!string.IsNullOrWhiteSpace(RecentCard.ThisCard.Properties.CardFrame))
        RecentCard.ThisFrame = new AddFrame
        {
            FrameImage = await APIMethods.GetImageBinary($"{Constants.FRAMEDIR}/{RecentCard.ThisCard.Properties.CardFrame}.png"),
            FrameName = RecentCard.ThisCard.Properties.CardFrame
        };

    string JsonString = ParseToJsonFromObject(RecentCard);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(JsonString);
});

// Retrieves all rarities
app.MapGet("/GetAllRarities", async (context) =>
{
    string Sql = $"SELECT CardRarity FROM AvailableCardRarityList";
    using var Reader = Methods.ExecuteQuerySQL(Sql, Constants.AVAILABLECARDOPTIONSDBDIR);

    List<string> CardRarities = new List<string>();
    
    while(await Reader.ReadAsync())
        CardRarities.Add(Reader.GetString(0));

    if (CardRarities.Count == 0)
    {
        context.Response.StatusCode = (int)HttpStatusCode.NoContent;
        return;
    }

    string JsonString = ParseToJsonFromObject(CardRarities);
    context.Response.StatusCode = (int)HttpStatusCode.OK;
    await context.Response.WriteAsync(JsonString);
});

#endregion

app.Run();

#region Helper Functions

// Remove JOptions if problems
static async Task<T> ParseToObjectFromJson<T>(HttpContext Context, JsonSerializerOptions? JOptions = null)
{
    string StringContext = await new StreamReader(Context.Request.Body).ReadToEndAsync();
    return System.Text.Json.JsonSerializer.Deserialize<T>(StringContext, JOptions);
}

// Remove JOptions if problems
static string ParseToJsonFromObject<T>(T ObjectToParse, JsonSerializerOptions? JOptions = null)
{
    return System.Text.Json.JsonSerializer.Serialize<T>(ObjectToParse);
}


#endregion