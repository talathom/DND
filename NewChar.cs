using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnD
{
    public partial class NewChar : Form
    {

        //STR, DEX, CON, INT, WIS, CHA
        static protected int[] bonuses = { 0, 0, 0, 0, 0, 0 };
        static protected int[] realStats = new int[6];
        static protected int[] modifiers = new int[6];
        static protected Label[] modifierLabels = new Label[6];
        static protected NumericUpDown[] editFields = new NumericUpDown[6];
        static protected Label[] finalLabels = new Label[6];
        static protected int pointsRemaining = 27;
        static protected Boolean pointBuy = false;
        public NewChar()
        {
            InitializeComponent();
            raceTab.Text = "Race";

            editFields[0] = strNUM;
            editFields[1] = dexNUM;
            editFields[2] = conNUM;
            editFields[3] = intNUM;
            editFields[4] = wisNUM;
            editFields[5] = chaNUM;
            finalLabels[0] = strFINAL;
            finalLabels[1] = dexFINAL;
            finalLabels[2] = conFINAL;
            finalLabels[3] = intFINAL;
            finalLabels[4] = wisFINAL;
            finalLabels[5] = chaFINAL;
            modifierLabels[0] = strmodLB;
            modifierLabels[1] = dexmodLB;
            modifierLabels[2] = conmodLB;
            modifierLabels[3] = intmodLB;
            modifierLabels[4] = wismodLB;
            modifierLabels[5] = chamodLB;


            foreach (NumericUpDown box in editFields)
            {
                box.ValueChanged += fieldChanged;
            }

            Timer updater = new Timer();
            updater.Interval = 1000;
            updater.Tick += new EventHandler(timer_Tick);
            updater.Start();

            ToolTip vadalisTT = new ToolTip();
            vadalisTT.SetToolTip(this.vadalisRB, "+1 DEX, +1 WIS\nWild Intuition Ability\nExpert Handling Ability\nAnimal Friendship Spell\nBeast Only Spells also affect Monstrosities with INT < 3");

            strNUM.Enabled = false;
            //strNUM.ReadOnly = true;

            dexNUM.Enabled = false;
            //dexNUM.ReadOnly = true;

            conNUM.Enabled = false;
            //conNUM.ReadOnly = true;

            intNUM.Enabled = false;
            //intNUM.ReadOnly = true;

            wisNUM.Enabled = false;
            //wisNUM.ReadOnly = true;

            chaNUM.Enabled = false;
            //chaNUM.ReadOnly = true;
        }

        private void humanLB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.dndbeyond.com/races/human");
        }

        private void vadalisRB_CheckedChanged(object sender, EventArgs e)
        {
            bonuses[1] = 1;
            bonuses[2] = 1;
        }

        private void randBUT_Click(object sender, EventArgs e)
        {
            hidePointBuy();
            Random random = new Random();
            for (int i = 0; i < realStats.Length; i++)
            {
                realStats[i] = random.Next(8, 18);
            }
            strNUM.Text = realStats[0].ToString();
            dexNUM.Text = realStats[1].ToString();
            conNUM.Text = realStats[2].ToString();
            intNUM.Text = realStats[3].ToString();
            wisNUM.Text = realStats[4].ToString();
            chaNUM.Text = realStats[5].ToString();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < editFields.Length; i++)
            {
                strbonusLB.Text = "+" + bonuses[0];
                dexbonusLB.Text = "+" + bonuses[1];
                conbonusLB.Text = "+" + bonuses[2];
                intbonusLB.Text = "+" + bonuses[3];
                wisbonusLB.Text = "+" + bonuses[4];
                chabonusLB.Text = "+" + bonuses[5];
                double stat = (double)editFields[i].Value + bonuses[i];
                finalLabels[i].Text = stat.ToString();
            }
            calculateModifiers();

        }

        private void buyBUT_Click(object sender, EventArgs e)
        {
            pointLB.Text = "Points Remaining: " + pointsRemaining;
            foreach (NumericUpDown box in editFields)
            {
                box.Enabled = true;
                box.ReadOnly = true;
                box.Value = 8;
                for (int i = 0; i < realStats.Length; i++)
                {
                    realStats[i] = 8;
                }
            }
            pointBuy = true;
        }

        private void fieldChanged(object sender, EventArgs e)
        {

            if (pointBuy)
            {
                int i;
                for (i = 0; i < editFields.Length; i++)
                {
                    if (sender.Equals(editFields[i]))
                    {
                        break;
                    }
                }

                if (editFields[i].Value > realStats[i])
                {
                    if (!(pointsRemaining - 1 < 0))
                    {
                        pointsRemaining--;
                    }
                    else
                    {
                        if (editFields[i].Value + 1 < editFields[i].Maximum)
                        {
                            editFields[i].Value = editFields[i].Value - 1;
                        }
                    }
                }
                if(editFields[i].Value < realStats[i])
                {
                    pointsRemaining++;
                }
                realStats[i] = (int)editFields[i].Value;
                pointLB.Text = "Points Remaining: " + pointsRemaining;
            }
        }

        public static void calculateModifiers()
        {
            for (int i = 0; i < 6; i++)
            {
                modifiers[i] = (Int16.Parse(finalLabels[i].Text) - 10) / 2;
                if (modifiers[i] > 0)
                {
                    modifierLabels[i].Text = "+" + modifiers[i].ToString();
                }
                else
                {
                    modifierLabels[i].Text = modifiers[i].ToString();
                }
            }
        }

        public void hidePointBuy()
        {
            if (pointBuy)
            {
                pointBuy = false;
                pointsRemaining = 27;
                pointLB.Text = "";
            }
        }

        private void rollBUT_Click(object sender, EventArgs e)
        {
            pointsRemaining = 0;
            DiceRoller roll = new DiceRoller(6, 6);
            List<int> numbers;
            pointBuy = true;
            for (int i = 0; i < 6; i++)
            {
                numbers = roll.roll();
                while (numbers.Count > 3)
                {

                    int index = numbers.Min();
                    numbers.Remove(index);
                }
                foreach (int number in numbers)
                {
                    pointsRemaining += number;
                }
                numbers.Clear();
            }
            foreach (NumericUpDown box in editFields)
            {
                box.Enabled = true;
                box.ReadOnly = true;
                box.Value = 1;
                for (int i = 0; i < realStats.Length; i++)
                {
                    realStats[i] = 1;
                }
            }
            pointLB.Text = "Points Remaining: " + pointsRemaining;
        }

        private void arrBUT_Click(object sender, EventArgs e)
        {
            pointsRemaining = 0;
            pointLB.Text = "Points Remaining: " + pointsRemaining;
            editFields[0].Value = 15;
            editFields[1].Value = 14;
            editFields[2].Value = 13;
            editFields[3].Value = 12;
            editFields[4].Value = 10;
            editFields[5].Value = 8;
            for(int i = 0; i < realStats.Length; i++)
            {
                realStats[i] = (int)editFields[i].Value;
            }
            foreach(NumericUpDown box in editFields)
            {
                box.Enabled = true;
                box.ReadOnly = true;
            }

            pointBuy = true;

        }
    }
}
