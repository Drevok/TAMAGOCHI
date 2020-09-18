using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Propriétés
{
    public class Tamagochi : MonoBehaviour
    {

        public TextMeshProUGUI EventText;

        public void TimeCount()
        {
            tama.Hunger --;
            if (tama.IsHungry == true)
            {
                tama.Health --;
                EventText.text ="G FAIM";
            }
            tama.Tiredness --;
            if (tama.IsTired == true)
            {
                tama.Health --;        
            }
            tama.Boredom --;
            if (tama.IsBored == true)
            {
                tama.Tiredness --;
            }

            Debug.Log("Il me reste" + tama.Health + "points de vie");
            Debug.Log("Il me reste " + tama.Hunger + "points de faim");
            Debug.Log("Il me reste " + tama.Tiredness + "points de fatigue");
            Debug.Log("Il me reste " + tama.Boredom + "points de fatigue");
        }

        public TAMA tama = new TAMA();
        void Start()
        {

            //tama.Health = tama.MaxHealth;
            tama.Health = 5;
            //tama.Hunger = tama.MaxHunger;
            tama.Hunger = 0;
            tama.Tiredness = tama.MaxTiredness;
            tama.Boredom = tama.MaxBoredom;

            InvokeRepeating ("TimeCount", 0f, 1f);

        }

        // Update is called once per frame
        void Update()
        { 

            if (tama.IsDead == true)
            {
                EventText.text == "JSUI MOR";
                CancelInvoke("TimeCount");
            }

        }
    }

    public class TAMA
    {
        private int _health;
        public int MaxHealth = 100;
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
        public int MaxHunger = 100;
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

                if (_hunger <= 0)
                {
                    IsDead = true;
                }
            }
        }

        private int _tiredness;
        public int MaxTiredness = 100;
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
        public int MaxBoredom = 100;
        public bool IsBored {get; private set;}

        public int Boredom
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