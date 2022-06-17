using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

static async Task<Root> getWeather(string customRequest)
{
    var client = new HttpClient();
    var request = new HttpRequestMessage
    {
        Method = HttpMethod.Get,
        RequestUri =
            new Uri(String.Format("https://api.openweathermap.org/data/2.5/weather?{0}&units=metric&appid=53471f3e4cd6be26d6efc764c128bb3c", customRequest)) // my key is: 53471f3e4cd6be26d6efc764c128bb3c
    };
    using (var response = await client.SendAsync(request))
    {
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        Root myDeserializedClass = JsonSerializer.Deserialize<Root>(body);
        return myDeserializedClass;
    }
}

Console.WriteLine("What’s the weather like in Morocco?");
try
{
    Root resultWeatherMarocco = await getWeather("q=Morocco");
    Console.WriteLine("The weather in Morocco is : " + resultWeatherMarocco.weather[0].main);
}
catch (Exception e)
{
    Console.Write("An error is produced in the API call");
    Console.WriteLine("{0} Exception caught.", e);
}
Console.WriteLine();


Console.WriteLine("When will the sun rise and set today in Oslo?");
try
{
    Root sunTimeOslo = await getWeather("q=Oslo");
    DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    dateTime = dateTime.AddSeconds(sunTimeOslo.sys.sunrise).ToLocalTime();
    Console.WriteLine("The sun in Oslo rise at : " + dateTime);

    DateTime dateOslo = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    dateOslo = dateOslo.AddSeconds(sunTimeOslo.sys.sunset).ToLocalTime();
    Console.WriteLine("The sun in Oslo set at : " + dateOslo);
    Console.WriteLine();
}
catch (Exception e)
{
    Console.Write("An error is produced in the API call");
    Console.WriteLine("{0} Exception caught.", e);
}


Console.WriteLine("What’s the temperature in Jakarta (in Celsius)?");
try
{
    Root temperatureJakarta = await getWeather("q=Jakarta");
    Console.WriteLine("The temperature in Jakarta is : " + temperatureJakarta.main.temp + " degrees Celsius");
}
catch (Exception e)
{
    Console.Write("An error is produced in the API call");
    Console.WriteLine("{0} Exception caught.", e);
}
Console.WriteLine();


Console.WriteLine("Where is it more windy? New-York, Tokyo or Paris?");
try
{
    Root NewYork = await getWeather("q=New%20York");
    Root Tokyo = await getWeather("q=Tokyo");
    Root Paris = await getWeather("q=Paris");

    if (NewYork.wind.speed >= Tokyo.wind.speed && NewYork.wind.speed >= Paris.wind.speed)
    {
        Console.WriteLine("The most windy city is New-York with a wind speed of : " + NewYork.wind.speed + " km/h");
    }
    else if (Tokyo.wind.speed >= NewYork.wind.speed && Tokyo.wind.speed >= Paris.wind.speed)
    {
        Console.WriteLine("The most windy city is Tokyo with a wind speed of : " + Tokyo.wind.speed + " km/h");
    }
    else
    {
        Console.WriteLine("The most windy city is Paris with a wind speed of : " + Paris.wind.speed + " km/h");
    }
}
catch (Exception e)
{
    Console.Write("An error is produced in the API call");
    Console.WriteLine("{0} Exception caught.", e);
}
Console.WriteLine();


Console.WriteLine("What is the humidity and pressure like in Kiev, Moscow and Berlin?");
try
{
    Root humidityPressureKiev = await getWeather("q=Kiev");
    Console.WriteLine("The humidity in Kiev is : " + humidityPressureKiev.main.humidity + " % and the pressure is : " + humidityPressureKiev.main.pressure + " hPa");

    Root humidityPressureMoscow = await getWeather("q=Moscow");
    Console.WriteLine("The humidity in Moscow is : " + humidityPressureMoscow.main.humidity + " % and the pressure is : " + humidityPressureMoscow.main.pressure + " hPa");

    Root humidityPressureBerlin = await getWeather("q=Berlin");
    Console.WriteLine("The humidity in Berlin is : " + humidityPressureBerlin.main.humidity + " % and the pressure is : " + humidityPressureBerlin.main.pressure + " hPa");
}
catch (Exception e)
{
    Console.Write("An error is produced in the API call");
    Console.WriteLine("{0} Exception caught.", e);
}
Console.ReadKey();

// to generate my classes, I use https://json2csharp.com/ and I convert Json file (see the example of an API response bellow) to csharp
// memarque : toutes les variables des classes ne sont pas utilisé, j'aurai pu trier mais je voulais montrer exactement ce que le convertisseur m'a renvoyé
public class Clouds
{
    public int all { get; set; }
}

public class Coord
{
    public double lon { get; set; }
    public double lat { get; set; }
}

public class Main
{
    public double temp { get; set; }
    public double feels_like { get; set; }
    public double temp_min { get; set; }
    public double temp_max { get; set; }
    public int pressure { get; set; }
    public int humidity { get; set; }
}

public class Root
{
    public Coord coord { get; set; }
    public List<Weather> weather { get; set; }
    public string @base { get; set; }
    public Main main { get; set; }
    public int visibility { get; set; }
    public Wind wind { get; set; }
    public Clouds clouds { get; set; }
    public int dt { get; set; }
    public Sys sys { get; set; }
    public int timezone { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public int cod { get; set; }
}

public class Sys
{
    public int type { get; set; }
    public int id { get; set; }
    public double message { get; set; }
    public string country { get; set; }
    public int sunrise { get; set; }
    public int sunset { get; set; }
}

public class Weather
{
    public int id { get; set; }
    public string main { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
}

public class Wind
{
    public double speed { get; set; }
    public int deg { get; set; }
}


/* EXAMPLE OF API RESPONSE
 *{
  "coord": {
    "lon": -122.08,
    "lat": 37.39
  },
  "weather": [
    {
      "id": 800,
      "main": "Clear",
      "description": "clear sky",
      "icon": "01d"
    }
  ],
  "base": "stations",
  "main": {
    "temp": 282.55,
    "feels_like": 281.86,
    "temp_min": 280.37,
    "temp_max": 284.26,
    "pressure": 1023,
    "humidity": 100
  },
  "visibility": 10000,
  "wind": {
    "speed": 1.5,
    "deg": 350
  },
  "clouds": {
    "all": 1
  },
  "dt": 1560350645,
  "sys": {
    "type": 1,
    "id": 5122,
    "message": 0.0139,
    "country": "US",
    "sunrise": 1560343627,
    "sunset": 1560396563
  },
  "timezone": -25200,
  "id": 420006353,
  "name": "Mountain View",
  "cod": 200
  }
 */