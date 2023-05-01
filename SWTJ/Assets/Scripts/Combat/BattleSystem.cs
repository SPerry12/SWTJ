using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    EnemyCombat playerUnit;
    EnemyCombat enemyUnit;

    public TextMeshProUGUI dialogueText;


    public BattleState state;
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        int loadedHealth = PlayerPrefs.GetInt("playerHealth");
        playerUnit.currentHP = loadedHealth;
    }

    IEnumerator SetupBattle() {
        GameObject playerGO = Instantiate(playerPrefab);
        playerUnit = playerGO.GetComponent<EnemyCombat>();
        
        GameObject enemyGO = Instantiate(enemyPrefab);
        enemyUnit = enemyGO.GetComponent<EnemyCombat>();

        dialogueText.text = enemyUnit.unitName + " approaches....";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack() {

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.healthText.text = "Health: " + enemyUnit.currentHP;
        dialogueText.text = "The attack is successful!";

        yield return new WaitForSeconds(2f);

        if(isDead) {
            state = BattleState.WON;
            StartCoroutine(EndBattle());
        } else {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }


    IEnumerator EnemyTurn() {
        dialogueText.text = enemyUnit.unitName + " attacks!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        playerHUD.healthText.text = "Health: " + playerUnit.currentHP;

        yield return new WaitForSeconds(1f);

        if(isDead) {
            state = BattleState.LOST;
            EndBattle();
        } else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator EndBattle() {

        if(state == BattleState.WON) {
            dialogueText.text = "You won the battle!";
            PlayerPrefs.SetString("battleResult", "win");
            PlayerPrefs.SetInt("playerHealth", playerUnit.currentHP);
            SceneManager.LoadScene("Main");
        } 
        else if(state == BattleState.LOST) {
            dialogueText.text = "You lost the battle!";
            PlayerPrefs.SetString("battleResult", "lost");
            SceneManager.LoadScene("GameOver");
        }
        
        yield return new WaitForSeconds(2f);
    }

    IEnumerator PlayerFlee() {
        int randomNum = Random.Range(1,8);

        if(randomNum <= 4) {
            dialogueText.text = "You fail to flee!";
            yield return new WaitForSeconds(3f);
        } else {
            dialogueText.text = "You manage to flee!";
            yield return new WaitForSeconds(1f);
            PlayerPrefs.SetInt("playerHealth", playerUnit.currentHP);
            PlayerPrefs.SetString("battleResult", "flee");
            SceneManager.LoadScene("Main");
        }

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    void PlayerTurn() {
        dialogueText.text ="Choose an action:";
    }

    public void OnAttackButton() {
        if (state != BattleState.PLAYERTURN) {
            return;
        }
        state = BattleState.ENEMYTURN;
        StartCoroutine(PlayerAttack());
    }

    public void OnFleeButton() {
        if (state != BattleState.PLAYERTURN) {
            return;
        }
        state = BattleState.ENEMYTURN;
        StartCoroutine(PlayerFlee());
    }
}
