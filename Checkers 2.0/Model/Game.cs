using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Checkers_2._0.Model
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Player1 { get; set; }
        [Required]
        public string Player2 { get; set; }
        [Required]
        public string Board { get; set; }
        [Required]
        public bool IsTurn { get; set; }    //true - player1
                                            //false - player2

        public GameState gameState { get; set; }
        public enum GameState
        {
            Running,
            Player1Win,
            Player2Win,
            Tie
        }


    }
}
