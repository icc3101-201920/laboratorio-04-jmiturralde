using Laboratorio_3_OOP_201902.Cards;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Laboratorio_3_OOP_201902
{
    public class Game
    {
        //Atributos
        private Player[] players;
        private Player activePlayer;
        private List<Deck> decks;
        private Board boardGame;
        private bool endGame;

        //Constructor
        public Game()
        {

        }

        //Propiedades
        public Player[] Players
        {
            get
            {
                return this.players;
            }
        }
        public Player ActivePlayer
        {
            get
            {
                return this.activePlayer;
            }
            set
            {
                activePlayer = value;
            }
        }
        public List<Deck> Decks
        {
            get
            {
                return this.decks;
            }
        }
        public Board BoardGame
        {
            get
            {
                return this.boardGame;
            }
        }
        public bool EndGame
        {
            get
            {
                return this.endGame;
            }
            set
            {
                endGame = value;
            }
        }

        //Metodos
        public bool CheckIfEndGame()
        {
            if (players[0].LifePoints == 0 || players[1].LifePoints == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetWinner()
        {
            if (players[0].LifePoints == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void Play()
        {
            throw new NotImplementedException();
        }

        public void ReadDeck()
        {
            
            string s = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Files/Deck.txt");
            StreamReader reader = new StreamReader(s);
            List<Deck> playerCards = new List<Deck>(); // Lista cartas del jugador

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] characterParams = line.Split(',');
                Deck deckd = new Deck();

                if (characterParams[0]=="Start")
                    switch (characterParams[0])
                    {
                        case "CombatCard":
                            deckd.AddCard(new CombatCard(characterParams[1], characterParams[2], characterParams[3], int.Parse(characterParams[4]), bool.Parse(characterParams[4])));
                            break;
                        case "SpecialCard":
                            deckd.AddCard(new SpecialCard(characterParams[1], characterParams[2], characterParams[3]));
                            break;
                        case "END":
                            playerCards.Add(deckd);
                            break;
                        default:
                            break;

                    }
            }

        }
        public void ReadCaptain()
        {
            string s = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../Files/Captain.txt");
            StreamReader reader = new StreamReader(s);
            List<Deck> playerCaptain = new List<Deck>(); //Lista capitanes
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] characterParams = line.Split(',');
                Deck deckd = new Deck();
                switch (characterParams[0])
                {
                    case "SpecialCard":
                        deckd.AddCard(new SpecialCard(characterParams[1], characterParams[2], characterParams[3]));
                        playerCaptain.Add(deckd);
                        break;
                    default:
                        break;

                }
            }


        }
    }
}
