using System;

public class ShadowLord : Enemy
{

	private const int sLordHealth = 20;

	private const int sLordMinDamage = 3;
	private const int sLordMaxDamage = 5;


	//public int Damage(Enemy enemy)
	//{
	//	get
	//	{
	//		Random newRandom = new Random();
	//		return newRandom.Next(sLordMinDamage, sLordMaxDamage + 1);
	//	}
	//	protected set
	//	{
	//		Damage = value;
	//	}
	//}


	public ShadowLord()
	{
		Health = sLordHealth;
		Damage = sLordMaxDamage;
	}


}
