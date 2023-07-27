public class PlayerHealth : UnitHealth, IHealable
{
	public void Heal(int healValue)
	{
		if (health < 3)
			health += healValue;
		if(health > maxHealth)
			health = maxHealth;
		OnHealthChanged?.Invoke(health);
	}
}