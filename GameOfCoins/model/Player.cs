using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfCoins.model
{
    class Player
    {
        string name;
        int score;

        public Player(string name) {
            this.name = name;
            this.score = 0;
        }

        public void SetScore(int score) {
            this.score += score;
        }

        public int GetScore() {
            return this.score;
        }


        public String Represenation() {
            return ("Player " + this.name + "get : " + this.score);
        }

    }
}
