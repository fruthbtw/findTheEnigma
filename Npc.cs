using DGD203_2;
using System;

public class Npc
{
    #region REFERENCES

    private Game _theGame;
    public Player Player { get; private set; }

    public List<Enemy> Enemies { get; private set; }

    private Location _location;

    #endregion

    #region VARIABLES


    private bool _isOngoing;

    private bool _isExit=false;
    private bool _isWin = false;

    private string[] _answers = { "orchid", "rose","violet", "daisy", "tulip", "Exit Conversation"}; 

    private string _playerInput;

    #endregion

    #region CONSTRUCTOR

    public Npc(Game game, Location location)
    {
        _theGame = game;
        Player = game.Player;

        _isOngoing = false;

        _location = location;


        //Random rand = new Random();
        //int numberOfEnemies = rand.Next(1, maxNumberOfEnemies + 1);

        //Enemies = new List<Enemy>();
        //for (int i = 0; i < numberOfEnemies; i++)
        //{
        //    Enemy nextEnemy = new ShadowLord();
        //    Enemies.Add(nextEnemy);
        //}
    }

    #endregion


    #region METHODS

    #region Initialization & Loop

    public void StartConv()
    {
        _isOngoing = true;

        while (_isOngoing)
        {
            GetInput();
            ProcessInput();

            if (!_isOngoing) break;

            ProcessNpcActions();
        }
    }

    private void GetInput()
    {
        Console.WriteLine($"Which is the most beautiful flower in the world? There are {_answers.Length} answers.");
        for (int i = 0; i < _answers.Length; i++)
        {
            Console.WriteLine($"[{i + 1}]:  {_answers[i]}");
        }
        _playerInput = Console.ReadLine();
    }

    private void ProcessInput()
    {
        if (_playerInput == "" || _playerInput == null)
        {
            Console.WriteLine("You can't just stand still, You need to answer this question, come on!");
            return;
        }

        ProcessChoice(_playerInput);
    }


    private void ProcessChoice(string choice)
    {
        if (Int32.TryParse(choice, out int value)) // When the command is an integer
        {
            if (value > _answers.Length + 1)
            {
                Console.WriteLine("That is not a valid choice");
            }
            else
            {
                if (value == _answers.Length + 1)
                {
                    EndConv();
                }
                else
                {
                    CheckAnswer(value);
                }
            }
        }
        else // When the command is not an integer
        {
            Console.WriteLine("Stop chatting, answer this question quickly");
        }
    }

    private void EndConv()
    {
        _isOngoing = false;
        _location.EventHappened();
    }

    #endregion

    #region 

    //private void ExitConv()
    //{
    //    Random rand = new Random();
    //    double randomNumber = rand.NextDouble();

    //    if (randomNumber >= 0.5f)
    //    {
    //        Console.WriteLine("You flee! You are a coward maybe, but a live one!");
    //        EndCombat();
    //    }
    //    else
    //    {
    //        Console.WriteLine("You cannot flee because a Shadow Lord is in your way");
    //    }
    //}

    private void CheckAnswer(int index)
    {
        //int enemyIndex = index - 1;
        //int playerDamage = Player.Damage();

        switch (index)
        {
            case 1:
                Console.WriteLine("Not even close to the answer");

                break;
            case 2:
                Console.WriteLine("Absolutely correct answer. Congratulations!!!");
                _isWin = true;
                break;
            case 3:
                Console.WriteLine("I don't think you could have said anything worse.");
                break;
            case 4:
                Console.WriteLine("Try again next time");
                break;
            case 5:
                Console.WriteLine("Come on!! you can find it");
                break;
            case 6:
                _isExit = true; 
                Console.WriteLine("Better we talk next time");
                break;
        }

        //Enemies[enemyIndex].TakeDamage(playerDamage);
        //Console.WriteLine($"The Shadow Lord take {playerDamage} damage!");

        //if (Enemies[enemyIndex].Health <= 0)
        //{
        //    Console.WriteLine("This Shadow Lord is evaporated!");
        //    Enemies.RemoveAt(enemyIndex);
        //}
    }

    private void ProcessNpcActions()
    {
        if (_isWin == true)
        {
            Console.WriteLine("You are very clever boy. Thanks for the everything!");
            EndConv();
        }



        //for (int i = 0; i < Enemies.Count; i++)
        //{
        //    int sLordDamage = Enemies[i].Damage;
        //    Player.TakeDamage(sLordDamage);
        //}
    }



    #endregion

    #endregion

}
