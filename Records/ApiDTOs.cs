using System.Collections.Generic;

public record State(string id, string name);

public record Location(float latitude, float longitude);

public record GeoInformation(Location location);

public record Country(
    string id, 
    string name,
    string locale,
    string currency_id,
    string decimal_separator,
    string thousands_separator,
    string time_zone,
    GeoInformation geo_information,
    List<State> states
);
    
    
    
// Search


public record Seller(
    int id
);

public record Result(
    string id,
    string site_id,
    string title,
    decimal price,
    Seller seller,
    string permalink
);
  
public record Search(
    List<Result> results
);

public record Found(
    string id,
    string site_id,
    string title,
    decimal price,
    int seller_id,
    string permalink
);

// Currency

public class Currency
{
    public Currency() { }

    public Currency(
        string _id,
        string _symbol,
        string _description,
        int _decimal_places,
        decimal? _to_dolar)
    {
        this.id = _id;
        this.symbol = _symbol;
        this.description = _description;
        this.decimal_places = _decimal_places;
        this.to_dolar = _to_dolar;

    }
    
    public string id { get; set; }
    public string symbol { get; set; }
    public string description { get; set; }
    public int decimal_places { get; set; }
    public decimal? to_dolar { get; set; }

}

public record CurrencyConvertion(
    decimal ratio,
    decimal inv_rate
);
