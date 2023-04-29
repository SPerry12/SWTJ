using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLoad : MonoBehaviour
{

    public Player player;
    
    private void Awake() {
        
        SaveSystem.Init();
    }

    public void Save() {
        int coinAmount = player.coinAmount;
        int fuelAmount = player.fuelAmount;
        int oreAmount = player.oreAmount;
        int luxuryAmount = player.luxuryAmount;
        int gemAmount = player.gemAmount;
        int playerHealth = player.health;
        int playerDebt = player.debtAmount;

        Vector3 playerPosition = player.getPlayerPosition();

        SaveObject saveObject = new SaveObject {
            coinAmount = coinAmount,
            fuelAmount = fuelAmount,
            oreAmount = oreAmount,
            luxuryAmount = luxuryAmount,
            gemAmount = gemAmount,
            playerHealth = playerHealth,
            playerDebt = playerDebt,
            playerPosition = playerPosition
        };
        string json = JsonUtility.ToJson(saveObject);
        SaveSystem.Save(json);
        
    }

    public void Load() {

        string saveString = SaveSystem.Load();
        if (saveString != null) {
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);

            player.setCoinAmount(saveObject.coinAmount);
            player.setFuelAmount(saveObject.fuelAmount);
            player.setOreAmount(saveObject.oreAmount);
            player.setLuxuryAmount(saveObject.luxuryAmount);
            player.setGemAmount(saveObject.gemAmount);
            player.setHealthAmount(saveObject.playerHealth);
            player.setDebtAmount(saveObject.playerDebt);
            player.setPlayerPosition(saveObject.playerPosition);
        }
    }


}

public class SaveObject {
    public int coinAmount;
    public int fuelAmount;
    public int oreAmount;
    public int luxuryAmount;
    public int gemAmount;
    public int playerHealth;
    public int playerDebt;
    public Vector3 playerPosition;

}
