# Levi9 Challenge
A Levi9 cloud hackathon. 

## Built using 

- &nbsp; <img src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRxo1QGx_G_1-2qBwh3RMPocLoKxD782w333Q&usqp=CAU" align="center" width="28" height="28"/> <a href="https://dotnet.microsoft.com/en-us/apps/aspnet"> ASP.NET 8 + Entity Framework 8 </a>

## Installation:

You can run the app using the `dotnet` CLI. You can download and install the dotnet SDK 8.0 for your operating system [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0). 
In case you already have it installed but are not sure of the version, run the 
`dotnet --list-sdks` command in your terminal to check.

## How to run:

### Clone the project 
   - `git clone https://github.com/Acile067/5_days_in_the_clouds_2023.git`
   - `cd 5_days_in_the_clouds_2023`
   - `cd Levi9_competition`
   - `cd Levi9_competition`

### Dotnet CLI:
   
 - Run the app on port **5220**: `dotnet run`

_(Optional)_ To set your own CSV file containing player data, simply replace the contents of the `/Data/Players.csv` file with your own (Must be named `Players.csv`).

_(Optional)_ Another way to do this is by setting the `CSV_PLAYER_DATA` environment variable to the path of
your file. For example:
- Linux Bash: `export CSV_PLAYER_DATA=~/Downloads/MyPlayerData.csv; dotnet run`
- Windows Powershell: `$env:CSV_PLAYER_DATA='C:/Downloads/MyPlayerData.csv'; dotnet run`

## CSV Data Format

The format of the data to provide in the CSV files is given in the following example:
```
PLAYER,POSITION,FTM,FTA,2PM,2PA,3PM,3PA,REB,BLK,AST,STL,TOV
Luyanda Yohance,PG,6,6,0,4,4,4,1,1,4,2,2
Jaysee Nkrumah,PF,0,4,2,2,2,4,2,1,2,0,1
Nkosinathi Cyprian,SF,2,6,3,9,0,4,4,2,1,0,2
```

## API

<b> Go to `http://localhost:5220/swagger/index.html` to test it with Swagger UI. </b>

The application will be available on `http://localhost:5220` with a endpoints `/stats/player` and `/stats/player/{playerFullName}`.

An example request for the player _Sifiso Abdalla_, using the provided CSV data loaded on application startup:

```http request
GET http://localhost:5220/stats/player/Sifiso Abdalla
```
```http request
HTTP/1.1 200 OK
        
{
  "playerName": "Sifiso Abdalla",
  "gamesPlayed": 3,
  "traditional": {
    "freeThrows": {
      "attempts": 4.7,
      "made": 3.3,
      "shootingPercentage": 71.4
    },
    "twoPoints": {
      "attempts": 4.7,
      "made": 3,
      "shootingPercentage": 64.3
    },
    "threePoints": {
      "attempts": 6.3,
      "made": 1,
      "shootingPercentage": 15.8
    },
    "points": 12.3,
    "rebounds": 5.7,
    "blocks": 1.7,
    "assists": 0.7,
    "steals": 1,
    "turnovers": 1.3
  },
  "advanced": {
    "valorization": 11.7,
    "effectiveFieldGoalPercentage": 40.9,
    "trueShootingPercentage": 46.7,
    "hollingerAssistRatio": 4.4
  }
}
```
An example request for a player that doesn't exist, returning `HTTP 404`:
```http request
GET http://localhost:5220/stats/player/Random Name
```
```http request
HTTP/1.1 404 Not Found

"Player not found"
```
