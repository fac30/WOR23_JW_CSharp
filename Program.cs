// => Dev Tools
bool debug = true;

// => Game Setup
string phase1 = "start";
string phase2 = "";

Random heroDice = new Random();
Random monsterDice = new Random();

int heroHealth = 10;
int heroBonus = 0;
int heroArmor = 0;
int heroLevel = 1;

int monsterHealth = 0;
int monsterBonus = 0;
int monsterArmor = 0;

int battleRound = 0;
int nullRounds = 0;

bool gameRunning = true;

while (gameRunning)
{
  // => Phase: Game Start
  while (phase1 == "start")
  {
    Console.Clear();
    
    Console.WriteLine($"======================");
    Console.WriteLine($"•• Quest for Agency ••");
    Console.WriteLine($"----------------------");
    Console.WriteLine($"PRESS KEY TO START");
    Console.WriteLine($"======================");
    
    Console.ReadLine();
    Console.Clear();

    phase1 = "";
  }

  // => Phase: Game End
  while (phase1 == "gameEnd")
  {
    Console.WriteLine($"Game Over");
    Console.WriteLine($"Press Key to End");
    Console.ReadLine();

    gameRunning = false;
  }
  
  // => Phase: Battle
  while (phase1 == "battle")
  {
    while (phase2 == "")
    {
      battleRound = 0;
      nullRounds = 0;
      
      monsterHealth = 10;
      monsterBonus = 0;
      monsterArmor = 0;

      // ==> Battle Information
      Console.WriteLine($"======================");
      Console.WriteLine($"Press key to start battle");
      Console.ReadLine();

      phase2 = "loop";
    }

    while (phase2 == "loop")
    {
      do
      {
        int shift = 0;
        
        // ===> Start Round
        battleRound++;
        Console.WriteLine($"Press key to start Round {battleRound}");
        Console.ReadLine();

        // ===> Hero Turn
        Console.WriteLine($"======================");
        Console.WriteLine($"Hero: Turn {battleRound}");
        Console.WriteLine($"Level {heroLevel} • {heroHealth} HP • Block {heroArmor} damage • +{heroBonus} to rolls");
        Console.WriteLine($"----------------------");
        Console.WriteLine($"Press key to attack");
        Console.ReadLine();

        int heroRoll = 0;
        shift += heroRoll;

        // ===> Monster Turn
        Console.WriteLine($"======================");
        Console.WriteLine($"Monster: Turn {battleRound}");
        Console.WriteLine($"{monsterHealth} HP • Block {monsterArmor} damage • +{monsterBonus} to rolls");
        Console.WriteLine($"----------------------");
        Console.WriteLine($"Press key to defend");
        Console.ReadLine();

        int monsterRoll = 0;
        shift += monsterRoll;

        // ===> Evaluate
        if (shift == 0)
        {
          nullRounds++;
          Console.WriteLine($"Null Rounds: {nullRounds}.");
          Console.WriteLine($"Continue?");
          Console.ReadLine();
          Console.Clear();
        }
      } while (nullRounds < 3);

      phase2 = "result";
    }

    while (phase2 == "result")
    {
      Console.WriteLine("todo: Result Screen");
      Console.WriteLine("Press Key to Continue");
      Console.ReadLine();
      Console.Clear();
      phase2 = "end";
    }

    while (phase2 == "end")
    {
      Console.WriteLine("todo: End Battle Screen");
      Console.WriteLine("Press Key to Continue");
      Console.ReadLine();
      Console.Clear();

      phase1 = "gameEnd";
      phase2 = "";
    }
  }

  // => Utility: Phase Selector
  while (phase1 == "")
  {
    if (debug) phase1 = "battle";
    phase2 = "";
  }
}

/* Sample
Monster was damaged and lost 1 health and now has 9 health.
Hero was damaged and lost 1 health and now has 9 health.
Monster was damaged and lost 7 health and now has 2 health.
Hero was damaged and lost 6 health and now has 3 health.
Monster was damaged and lost 9 health and now has -7 health.
Hero wins! */