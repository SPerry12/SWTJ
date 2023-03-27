using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Player  {
    
    public int Fuel {get; set;}
    public int Ore {get; set;}
    public int LuxuryGoods {get; set;}
    public int Gems {get; set;}
    public int Capacity {get; set;}
    public int Currency {get; set;}
    public int PositionX {get; set;}
    public int PositionY {get; set;}

    public Player(int fuel, int ore, int luxuryGoods, int gems, int capacity, int currency, int positionX, int positionY) {
        this.Fuel = fuel;
        this.Ore = ore;
        this.LuxuryGoods = luxuryGoods;
        this.Gems = gems;
        this.Capacity = capacity;
        this.Currency = currency;
        this.PositionX = positionX;
        this.PositionY = positionY;
    }


}
