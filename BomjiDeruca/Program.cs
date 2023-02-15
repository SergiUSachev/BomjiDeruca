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

using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Xml.Serialization;

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
		protected string name;
		protected int hp;
		protected int damage;
		protected int armor;

		public Fighter(string name, int hp, int damage, int armor)
		{
			this.name = name;
			this.hp = hp;
			this.damage = damage;
			this.armor = armor;
		}


		public string Name { get { return name; } private set { name = value; } }
		public int HP { get { return hp; } private set { hp = value; } }
		public int Damage { get { return damage; } private set { damage = value; } }
		public int Armor { get { return armor; } private set { armor = value; } }



		abstract public void ShowStats();
		//Console.WriteLine($"Имя: {Name}, Здоровье: {MaxHealth}, Урон: {Damage}," + " Защита: {Armor} ");

		abstract public void ShowInfo();

		abstract public void DoHit(Fighter other);

		public void TakeHit(int damage)
		{
			if(damage > armor)
			{
				hp = hp - damage;
			}
			else
			{
				hp -= 1;
			}
		}

		abstract public void SpecialSkill(Fighter other);
	}


	class Warrior : Fighter
	{
		public Warrior(string name, int hp, int attack, int defense) : base(name, hp, attack, defense)
		{
		}

		public override void DoHit(Fighter otherFighter)
		{
			if(otherFighter.HP < HP/3)
			{
				SpecialSkill(otherFighter);
			}
			else
			{
				otherFighter.TakeHit(Damage);
			}
		}

		public override void SpecialSkill(Fighter otherFighter)
		{
			Console.WriteLine("Удар превосходства!");
			Random random = new Random();
			int RandomNumber = random.Next(1,4);
			otherFighter.TakeHit(Damage*RandomNumber);
		}

		public override void ShowInfo()
		{
			Console.WriteLine($"{GetType().Name}, {Name}, Здоровье: {HP}");
		}

		public override void ShowStats()
		{
			Console.WriteLine($"Имя: {Name}, Здоровье: {HP}, Урон: {Damage}, Защита: {Armor} ");
		}
	}

	class Mage : Fighter
	{
		private const int FireballDamage = 50;
		private const int FireballManaCost = 50;

		private int _mana;

		public Mage(string name, int hp, int attack, int defense, int _mana) : base(name, hp, attack, defense)
		{
		}

		public override void DoHit(Fighter otherFighter)
		{
			if (_mana>=FireballManaCost)
			{
				SpecialSkill(otherFighter);
			}
			else
			{
				otherFighter.TakeHit(Damage);
			}
			_mana += 10;
		}

		public override void SpecialSkill(Fighter otherFighter)
		{
			Console.WriteLine("Фаирбол!!!");
			_mana -= 50;
			otherFighter.TakeHit(FireballDamage);
		}

		public override void ShowInfo()
		{
			Console.WriteLine($"{GetType().Name}, {Name}, Здоровье: {HP}, Мана: {_mana}");
		}

		public override void ShowStats()
		{
			Console.WriteLine($"Имя: {Name}, Здоровье: {HP}, Урон: {Damage}, Мана: {_mana} Защита: {Armor} ");
		}
	}

	class Rogue : Fighter
	{
		private const int CriticalHitRate = 3;

		private int atackCount = 0;

		public Rogue(string name, int hp, int attack, int defense) : base(name, hp, attack, defense)
		{
		}

		public override void DoHit(Fighter otherFighter)
		{
			atackCount++;

			if (atackCount % 3 == 0)
			{
				SpecialSkill(otherFighter);
			}
			else
			{
				otherFighter.TakeHit(Damage);
			}
		}

		public override void SpecialSkill(Fighter otherFighter)
		{
			Console.WriteLine("Сажаю на перо!!!");
			otherFighter.TakeHit(damage*CriticalHitRate);

		}

		public override void ShowInfo()
		{
			Console.WriteLine($"{GetType().Name}, {Name}, Здоровье: {HP}");
		}

		public override void ShowStats()
		{
			Console.WriteLine($"Имя: {Name}, Здоровье: {HP}, Урон: {Damage}, Защита: {Armor} ");
		}
	}
}