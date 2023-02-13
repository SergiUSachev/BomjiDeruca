//Создать 5 бойцов, пользователь выбирает 2 бойцов и они сражаются друг с другом до смерти.
//У каждого бойца могут быть свои статы.
//Каждый игрок должен иметь особую способность для атаки, 
//которая свойственна только его классу!
//Если можно выбрать одинаковых бойцов, то это не должна быть одна 
//и та же ссылка на одного бойца, чтобы он не атаковал сам себя.
//Пример, что может быть уникальное у бойцов. Кто-то каждый 3 удар наносит 
//удвоенный урон, другой имеет 30% увернуться от полученного урона, кто-то 
//при получении урона немного себя лечит.Будут новые поля у наследников.
//У кого-то может быть мана и это только его особенность.

namespace BomjiDeruca
{
	internal class Program
	{
		static void Main(string[] args)
		{
			
		}
	}

	abstract class Fighter
	{
		private string _name;
		private int _health;
		private int _maxHealth;
		private int _damage;
		private int _mana;
		private int _maxMana;
		private int _armor;

		public Fighter(string name, int maxHealth = 100, int damage = 10, int maxMana = 0, int armor = 0)
		{
			_name=name;
			_maxHealth=maxHealth;
			_health = maxHealth;
			_damage=damage;
			_maxMana=maxMana;
			_mana = maxMana;
			_armor=armor;
		}

		public void ShowStats()
		{
			Console.WriteLine($"Имя: {_name}, Здоровье: {_maxHealth}, Урон: {_damage}," +
				$" Мана: {_mana}, Защита: {_armor} ");
		}

		abstract public void ShowInfo();

		abstract public void DoHit();

		abstract public void TakeHit();

		abstract public void Skill();
	}


	class Warrior : Fighter
	{
		public Warrior(string name, int maxHealth, int damage, int armor)
		public override void ShowInfo()
		{
			Console.WriteLine($"{GetType().Name}, {_name}");
		}
	}
}