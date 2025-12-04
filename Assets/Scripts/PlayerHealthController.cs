using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public PostProcessingEffect Effect;

    public float invLength = 0.5f; // Invincibility time
    private float invCounter;

    public int currentHealth, maxHealth;

    public int PlayerHurtSFXIndex = 8; // Index of the player hurt sound effect in the AudioManager
    public int HealthPickUpSFXIndex = 7; // Index of the health pick up sound effect in the AudioManager


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateHealthUI(currentHealth);
    }

    void Update()
    {
        if (invCounter > 0)
        {
            invCounter -= Time.deltaTime;
        }
    }

    public void HealPlayer(int healAmount)
    {
        Effect.StartCoroutine(Effect.Green());
        // Play health pick up sound
        if (AudioManagerBgmSound.instance != null)
        {
            AudioManagerBgmSound.instance.PlaySFX(HealthPickUpSFXIndex);
        }

        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthUI(currentHealth);
    }

    public void TakeDamage(int damage, bool attackPlayer)
    {
        if (!GameManager.instance.ending)
        {
            if (attackPlayer)
            {
                // Play playerhurt sound
                if (AudioManagerBgmSound.instance != null)
                {
                    AudioManagerBgmSound.instance.PlaySFX(PlayerHurtSFXIndex);
                }

                currentHealth -= damage;
                UIController.instance.UpdateHealthUI(currentHealth);

                if (currentHealth <= 0)
                {
                    gameObject.SetActive(false);
                    currentHealth = 0;
                    GameManager.instance.PlayerIsDead();
                }
                else
                {
                    Effect.StartCoroutine(Effect.Red());
                }

                invCounter = invLength; // Invincibility time
            }
        }
    }
}