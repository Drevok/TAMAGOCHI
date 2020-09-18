using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Propriétés
{
    public class Tamagochi : MonoBehaviour
    {

        public float time;

        public TAMA tama = new TAMA();
        void Start()
        {
            time = 0;
        }

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;

            Debug.Log("Il s'est passé " + time + "secondes");
        }
    }

    public class TAMA
    {
        private int _health;
        public bool IsDead {get; private set;}

        public int Health
        {
            get
            {
                return _health;
            }

            set
            {
                _health = value;
                if (_health <= 0)
                {
                    IsDead = true;
                }
            }

        }

        private int _hunger;
        public bool IsHungry {get; private set;}

        public int Hunger
        {
            get
            {
                return _hunger;
            }

            set
            {
                _hunger = value;
                if (_hunger < 20)
                {
                    IsHungry = true;
                }
            }
        }

        private int _tiredness;
        public bool IsTired {get; private set;}

        public int Tiredness
        {
            get
            {
                return _tiredness;
            }

            set
            {
                _tiredness = value;
                if (_tiredness < 30)
                {
                    IsTired = true;
                }

            }
        }

        private int _boredom;
        public bool IsBored {get; private set;}

        public int _boredom
        {
            get
            {
                return _boredom;
            }

            set
            {
                _boredom = value;
                if (_boredom < 50)
                {
                    IsBored =true;
                }
            }
        }

    }

}