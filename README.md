

# ResonateAPI
## Inleiding
Dit is het API gedeelte van de Resonate Applicatie. Deze code slaat alle data op van de gebruiker op in een MSSQL database.
Eveneens bevat dit de logica om mensen in contact te brengen met elkaar.

## Opstart process
Om het project te starten moeten we enkele dingen uitvoeren om het project goed te krijgen.

### Nodige installaties
Zorg ervoor dat volgende programma's geïnstalleerd zijn:
- Microsoft Visual Studio 2017
- MSSQL server (eventueel Docker als u niet in het bezit bent van een Windows machine)

### Opstarten
Zorg ervoor dat u het project lokaal hebt staan. Maak een bestand aan genaamd: appsettings.json en plak er volgende code in:
~~~~
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ResonateContext": ""
  }
}
	
~~~~

Voeg het pad naar uw local database in tussen de "" bij ResonateContext. Maak alvast een database aan genaamd ResonateDb.

Navigeer in Visual Studio naar de package manager en voer volgende commando's uit:
~~~~
dotnet ef migrations add Inital
dotnet ef database update
~~~~

Nu staat de resonate database lokaal op uw machine. U kan al starten met eventueel valse data in te voeren.

## API endpoints
### USER 
##### Vraag één user op
**URL** : `/api/user/{userId}`
**Methode** : `GET`
**Content:**
~~~~
{
    "id": "voorbeeld.voorbeeld",
    "country": "BE",
    "display_name": "Voorbeeld",
    "email": "voorbeeld@voorbeeld.be",
    "href": "https://api.spotify.com/v1/users/voorbeeld",
    "birthdate": "1969-06-21",
    "urlPf": "www.voorbeeld.be",
    "beschrijving": "Dit is een voorbeeld",
    "artists": [
        {
            "artistId": 9,
            "userId": "voorbeeld.voorbeeld",
            "artistName": "Artiest voorbeeld",
            "hrefSpotify": "https://api.spotify.com/v1/artists/voorbeeld",
            "urlPf": "https://i.scdn.co/image/voorbeeld
        }
        ],
"genres": [
        {
            "genreId": 1,
            "userId": "voorbeeld.voorbeeld",
            "genreName": "voorbeeld"
        },
}
~~~~
> Als de user null is zal men een 204 status terug krijgen
#### Registeren
Bij het registeren van een user moet men in de **body** de vorige JSON doorsturen naar de API. Door deze functie uit te voeren wordt automatische alle nieuwe artiesten en genres in de database geplaatst. Eveneens alle potentiële matches met andere users op basis van de meegegeven artiesten en genres.
**URL** : `/api/user/`
**Methode** : `POST`
**Content:**
~~~~
True
~~~~
> Als het registeren geslaagd is krijgt men een response met "True" terug. Als dit niet zou gelukt zijn zal er een "False" als response zijn.

#### ARTISTS
Vraag alle artiesten op die in de database aanwezig zijn.
**URL** : `/api/artist/`
**Methode** : `GET`
**Content:**
~~~~
[
    {
        "artistId": 1,
        "userId": "voorbeeld.voorbeeld",
        "artistName": "voorbeeld",
        "hrefSpotify": "https://api.spotify.com/v1/artists/voorbeeld",
        "urlPf": "https://i.scdn.co/image/voorbeeld"
    },
  ]
~~~~
> De artiesten zijn niet distinct op naam wel op user.

#### GENRES
Vraag alle genres op die in de database aanwezig zijn.
**URL** : `/api/genre/`
**Methode** : `GET`
**Content:**
~~~~
[
    "voorbeeld",
    "voorbeeld 2"
 ]
~~~~
> De genres zijn wel distinct.

#### MATCHES
##### Potentiële matches
Vraag alle potentiële matches op van één user.
**URL** : `/api/match/{userId}/{matchLevel}/{value}`
**Methode** : `GET`
**Uitleg variable :**
Match Level: kan 1 = Artiest of 2 = Genre zijn.
Value: de variabele van de artiest of genre naam.
~~~~
[{
    "id": "voorbeeld.voorbeeld",
    "country": "BE",
    "display_name": "Voorbeeld",
    "email": "voorbeeld@voorbeeld.be",
    "href": "https://api.spotify.com/v1/users/voorbeeld",
    "birthdate": "1969-06-21",
    "urlPf": "www.voorbeeld.be",
    "beschrijving": "Dit is een voorbeeld",
    "artists": [
        {
            "artistId": 9,
            "userId": "voorbeeld.voorbeeld",
            "artistName": "Artiest voorbeeld",
            "hrefSpotify": "https://api.spotify.com/v1/artists/voorbeeld",
            "urlPf": "https://i.scdn.co/image/voorbeeld
        }
        ],
"genres": [
        {
            "genreId": 1,
            "userId": "voorbeeld.voorbeeld",
            "genreName": "voorbeeld"
        },
}]
~~~~
> Men krijgt een lijst terug van alle eventuele matches die aan deze vereisten voldoen.

##### Add match
Leg een match tussen twee gebruikers
**URL** : `/api/match/{userId1}/{userId2}`
**Methode** : `POST`
**Content**
~~~~
{
    "id": "voorbeeld.voorbeeld",
    "country": "BE",
    "display_name": "Voorbeeld",
    "email": "voorbeeld@voorbeeld.be",
    "href": "https://api.spotify.com/v1/users/voorbeeld",
    "birthdate": "1969-06-21",
    "urlPf": "www.voorbeeld.be",
    "beschrijving": "Dit is een voorbeeld"
}
~~~~
> In de database zal nu de IsConfirmed variable gelijk zijn aan false. Als bij een volgende post de gebruikers zijn omgedraaid zal deze variable op True komen te staan. Dit betekent dat beide users elkaar leuk vinden.

> Als de IsConfirmed variable gelijk is aan null zal er een lege user worden terug gestuurd. Dit wil zeggen dat de gebruikers elkaar nog niet leuk vinden alleen maar één user.

##### Get Matches
Krijg alle matches met de parameter IsConfirmed terug
**URL** : `/api/match/{userId1}/`
**Methode** : `GET`
**Content**
~~~~
{
    [{
    "id": "voorbeeld.voorbeeld",
    "country": "BE",
    "display_name": "Voorbeeld",
    "email": "voorbeeld@voorbeeld.be",
    "href": "https://api.spotify.com/v1/users/voorbeeld",
    "birthdate": "1969-06-21",
    "urlPf": "www.voorbeeld.be",
    "beschrijving": "Dit is een voorbeeld",
    "artists": [
        {
            "artistId": 9,
            "userId": "voorbeeld.voorbeeld",
            "artistName": "Artiest voorbeeld",
            "hrefSpotify": "https://api.spotify.com/v1/artists/voorbeeld",
            "urlPf": "https://i.scdn.co/image/voorbeeld
        }
        ],
"genres": [
        {
            "genreId": 1,
            "userId": "voorbeeld.voorbeeld",
            "genreName": "voorbeeld"
        },
}]
~~~~
> Men krijgt een list van alle gebruikers de gematcht zijn met deze persoon.

> Als er geen elke matches zijn zal de response een 204 - NO CONTENT zijn.

## Mogelijke uitbreidingen
- Een betere beveiliging van de api, met een rate limit en user authenticatie.
- Potentiële matches performanter maken.
- Betere responses terug geven.
- Meer controle bij de requests zoals null exceptions.



