using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Character
    {
        private string _name;
        private float _health;
        private float _damage;
        private float _defense;
        private float _originalDefense;
        private float _stamina;
        private Weapon _currentWeapon;

        public Character(string name, float health, float damage, float defense, float stamina, Weapon weapon)
        {
            //Initialize all stats
            _name = name;
            _health = health;
            _damage = damage;
            _defense = defense; 
            _stamina = stamina;
            _currentWeapon = weapon;

        }
        //Print player and opponet stats
        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage + "+" + _currentWeapon.Damage);
            Console.WriteLine("Defense: " + _defense);
            Console.WriteLine("Stamina: " + _stamina);
            Console.WriteLine("Weapon: " + _currentWeapon.Name);
        }


        //Damage calculation function
        public void TakeDamage(float damage)
        {
            _health -= damage - _defense;
        }
        public float GetDamage()
        {
            return _damage;
        }
        public float GetHealth()
        {
            return _health;
        }
        public Weapon GetWeapon()
        {
            return _currentWeapon;
        }
        public string GetName()
        {
            return _name;
        }
        public void BoostDefense(float Boost)
        {
            _defense += Boost;
        }
        public void ResetDefense()
        {
            _defense -= _originalDefense;
        }
    }
}
