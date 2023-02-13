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

using System;

abstract class Fighter
{
	public string Name { get; }
	public int HP { get; set; }
	public int Attack { get; }
	public int Defense { get; }

	public Fighter(string name, int hp, int attack, int defense)
	{
		Name = name;
		HP = hp;
		Attack = attack;
		Defense = defense;
	}

	public abstract void SpecialAttack(Fighter other);
}

class Knight : Fighter
{
	public Knight(string name, int hp, int attack, int defense) : base(name, hp, attack, defense)
	{

	}

	public override void SpecialAttack(Fighter other)
	{
		int damage = Attack * 2 - other.Defense;
		other.HP -= damage;
		Console.WriteLine($"{Name} uses Double Strike and deals {damage} damage to {other.Name}.");
	}
}

class Archer : Fighter
{
	public Archer(string name, int hp, int attack, int defense) : base(name, hp, attack, defense)
	{

	}

	public override void SpecialAttack(Fighter other)
	{
		int damage = Attack + 3;
		other.HP -= damage;
		Console.WriteLine($"{Name} uses Poison Shot and deals {damage} damage to {other.Name}.");
	}
}

class Mage : Fighter
{
	public Mage(string name, int hp, int attack, int defense) : base(name, hp, attack, defense)
	{

	}

	public override void SpecialAttack(Fighter other)
	{
		int damage = Attack * 3 - other.Defense;
		other.HP -= damage;
		Console.WriteLine($"{Name} uses Fireball and deals {damage} damage to {other.Name}.");
	}
}
