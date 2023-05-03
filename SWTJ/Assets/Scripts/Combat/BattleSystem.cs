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

    IEnumerator PlayerAttack(int attackValue) {
        bool isDead = false;
        if(attackValue == 1){
            isDead = enemyUnit.TakeDamage(playerUnit.normalDamage);
            dialogueText.text = "The attack is successful! You did " + playerUnit.normalDamage + " damage!";
        }
        else if(attackValue == 2){
            int randomNum = Random.Range(1,11);
            if(randomNum > 5) {
                isDead = enemyUnit.TakeDamage(playerUnit.phaserLaserDamage);
                dialogueText.text = "The attack is successful! You did " + playerUnit.phaserLaserDamage + " damage!";
            }
            else{
                dialogueText.text = "The attack is unsuccessful!";
            }
        }
        else if(attackValue == 3) {
            int randomNum = Random.Range(1,11);
            if(randomNum > 7) {
                isDead = enemyUnit.TakeDamage(playerUnit.hyperBeamDamage);
                dialogueText.text = "The attack is successful! You did " + playerUnit.hyperBeamDamage + " damage!";
            }
            else{
                dialogueText.text = "The attack is unsuccessful!";
            }
        }
        enemyHUD.healthText.text = "Health: " + enemyUnit.currentHP;
        

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
        
        int randomNum = Random.Range(1,11);
        if(randomNum < 9) {
            bool isDead = playerUnit.TakeDamage(enemyUnit.normalDamage);

            playerHUD.healthText.text = "Health: " + playerUnit.currentHP;
            

            if(isDead) {
                state = BattleState.LOST;
                StartCoroutine(EndBattle());
            }
            dialogueText.text = "The attack is successful! They did " + enemyUnit.normalDamage + " damage to you!";
            
            yield return new WaitForSeconds(2f);
            state = BattleState.PLAYERTURN;
            PlayerTurn();

        } else {
            dialogueText.text = "The attack is unsuccessful!";

            yield return new WaitForSeconds(2f);

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
       StartCoroutine(PlayerAttack(1));
    }

    public void OnPhaserLaserButton() {
        if (state != BattleState.PLAYERTURN) {
            return;
        }
        state = BattleState.ENEMYTURN;
        StartCoroutine(PlayerAttack(2));
    }

    public void OnHyperBeamButton() {
        if (state != BattleState.PLAYERTURN) {
            return;
        }
        state = BattleState.ENEMYTURN;
        StartCoroutine(PlayerAttack(3));
    }

    public void OnFleeButton() {
        if (state != BattleState.PLAYERTURN) {
            return;
        }
        state = BattleState.ENEMYTURN;
        StartCoroutine(PlayerFlee());
    }
}
