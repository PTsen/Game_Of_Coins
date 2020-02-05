using System;
using System.Collections.Generic;

namespace GameOfCoins.model
{
	
/// <summary>
///  GameOfCoinsClass: Is the class that will be used for the game rules
/// </summary> 
    class Game
    {
        List<int> board = new List<int> { };
        List<Player> players = new List<Player> { };
        int nb_coins = 0;
        int nb_players = 0;
        int current_coin = 0;

        public Game(int nb_coins, int nb_players) {
            this.nb_coins = nb_coins;
            this.nb_players = nb_players;
            Start();
        }

        void Start() {
            this.board.Add(this.current_coin);
            CreatePlayers();
            PickCoin();
        }

        void CreatePlayers() {
            for (int i = 1; i < this.nb_players+1; i++) {
                Player p = new Player(i+"");
                this.players.Add(p);
            }
        }

        void PickCoin() {
            for (int i = 1; i < this.nb_coins+1; i++) {
                int p_index = (i-1) % this.nb_players;
                Player p = this.players[p_index];
                int index = this.board.IndexOf(this.current_coin);
                if (i % 13 == 0)
                {
                    Coin13(i, p, index);
                }
                else     
                {
                    int next_pos = index + 2;
                    if (next_pos > this.board.Count) {
                        next_pos = 1;
                    }
                    this.current_coin = i;
                    this.board.Insert(next_pos, this.current_coin);
                }
            }
        }

        void Coin13(int coin, Player p, int index) {
            p.SetScore(coin);
            for (int i = 0; i < 7; i++) {
                if (index > 0)
                {
                    index = index - 1;
                }
                else {
                    index = this.board.Count - 1;
                }
            }
            int next_pos = index + 1;
            if (next_pos > this.board.Count - 1) {
            next_pos = 0;
            }         
            this.current_coin = this.board[next_pos];
            p.SetScore(this.board[index]);
            this.board.RemoveAt(index);
        }

        public string Result() {
            string result = "";
            foreach (Player p in this.players){
                result += (" " + p.GetScore() + '\n');
            }
            return result;
        }
    }
}