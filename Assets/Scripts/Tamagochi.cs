using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Propriétés
{
    public class Tamagochi : MonoBehaviour
    {

        [Header ("Stat bars")]
        public Image HungerBar;
        public Image TirednessBar;
        public Image BoredomBar;
 

        public TextMeshProUGUI HungerText;
        public TextMeshProUGUI TirednessText;
        public TextMeshProUGUI BoredomText;
        public TextMeshProUGUI DeathText;

        public void TimeCount()
        {
            tama.Hunger --;
            if (tama.IsHungry == true)
            {
                tama.Health --;
                HungerText.text ="G FAIM";
            }
            if (tama.Hunger <=0)
            {
                tama.Health = 0;
            }
            tama.Tiredness -= 2;
            if (tama.Tiredness <=0)
            {
                tama.Health = 0;
            }
            if (tama.IsTired == true)
            {
                tama.Health --;  
                TirednessText.text = "VEUX DORMIR";  
            }
            tama.Boredom -= 3;
            if (tama.IsBored == true)
            {
                tama.Tiredness --;
                BoredomText.text = "M'ENNUIE";
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
            tama.Health = 100;
            //tama.Hunger = tama.MaxHunger;
            tama.Hunger = 100;
            //tama.Tiredness = tama.MaxTiredness;
            tama.Tiredness = 100;
            //tama.Boredom = tama.MaxBoredom;
            tama.Boredom = 100;

            InvokeRepeating ("TimeCount", 0f, 1f);

        }

        // Update is called once per frame
        void Update()
        { 

            if (tama.IsDead == true)
            {
                DeathText.text = "JSUI MOR";
                CancelInvoke("TimeCount");
                HungerText.text = "";
                TirednessText.text = "";
                BoredomText.text = "";

            }

            HungerBar.fillAmount = tama.Hunger /100f;
            TirednessBar.fillAmount = tama.Tiredness /100f;
            BoredomBar.fillAmount = tama.Boredom /100f;

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