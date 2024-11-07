bool debug = true;

// => Setup
Random die = new Random();

// ==> Entities
// ===> Hero
int heroRawLevel = 0;
int heroRawHealth = 10;
int heroRawBonus = 0;
int heroRawArmor = 0;
string heroStatBonus = "";
string heroStatArmor = "";
int dMinHero = 1;
int dMaxHero = 11;

// ===> NPC
int npcRawLevel = 0;
int npcRawHealth = 10;
int npcRawBonus = 0;
int npcRawArmor = 0;
int dMinNpc = 1;
int dMaxNpc = 11;

// ==> Structure
string phase1 = "start";
string phase2 = "";
string phase3 = "";
int battleRound = 0;
int nullRounds = 0;
bool gameRunning = true;

while (gameRunning)
{
  while (phase1 == "start") //=> Game Start
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

  while (phase1 == "gameEnd") //=> Game End
  {
    Console.WriteLine($"Game Over");
    Console.WriteLine($"Press Key to End");

    Console.ReadLine();

    gameRunning = false;
    phase1 = "";
  }
  
  while (phase1 == "battle") //=> Battle
  {
    while (phase2 == "") //==> Battle Setup
    {
      battleRound = 0;
      nullRounds = 0;
      
      // todo Implement logic for varying enemy stats
      npcRawLevel = heroRawLevel;
      npcRawHealth = 10 + npcRawLevel;

      Console.WriteLine($"======================");
      Console.WriteLine($"A level {npcRawLevel} monster appears!");
      Console.WriteLine($"Press key to start battle");

      Console.ReadLine();
      Console.Clear();
      
      phase2 = "loop";
    }

    while (phase2 == "loop") //==> Battle Loop
    {
      phase3 = "";

      do
      {
        battleRound++;
        int hpShift = 0;

        while (phase3 == "") //===> Round Start
        {
          Console.WriteLine($"======================");

          Console.WriteLine($"Press key to start Round {battleRound}");
          Console.ReadLine();

          phase3 = "heroTurn";
        }

        while (phase3 == "heroTurn") //===> Hero's Turn
        {
          Console.WriteLine($"----------------------");
          Console.WriteLine($"Hero's Turn");
          Console.WriteLine($"Level {heroRawLevel} • {heroRawHealth} HP {heroStatArmor} {heroStatBonus}");
          Console.WriteLine("");
          Console.WriteLine($"Press key to attack");

          Console.ReadLine();

          int roll = die.Next(dMinHero, dMaxHero) + heroRawBonus;
          int attack = roll + heroRawBonus;
          int damage = attack - npcRawArmor;
          npcRawHealth -= damage;

          hpShift += attack;

          Console.WriteLine($"You rolled {roll}");
          if (attack != roll)
            Console.WriteLine($"Your skill of {heroRawBonus} boosts that to {attack}");
          if (damage != attack)
            Console.WriteLine($"The enemy blocked {npcRawArmor}");
          Console.WriteLine($"The enemy loses {damage} HP, leaving it with {(npcRawHealth > 0 ? npcRawHealth : 0)} HP");

          Console.Write("Continue?");
          Console.ReadLine();

          phase3 = "heroCheck";
        }

        while (phase3 == "heroCheck") //===> Check HP
        {
          if (heroRawHealth > 0 && npcRawHealth > 0)
            phase3 = "npcTurn";
          else
            phase2 = "result";
            phase3 = "cleanup";
        }

        while (phase3 == "npcTurn") //===> NPC's Turn
        {
          Console.WriteLine($"----------------------");
          Console.WriteLine($"Enemy'S Turn");
          Console.WriteLine($"{npcRawHealth} HP");
          Console.WriteLine("");
          Console.WriteLine($"Press key to defend");
          
          Console.ReadLine();

          int attack = die.Next(dMinHero, dMaxHero);
          hpShift += attack;

          phase3 = "check";
        }

        while (phase3 == "npcCheck") //===> Check HP
        {
          if (heroRawHealth > 0 && npcRawHealth > 0)
            phase3 = "nullCheck";
          else
            phase2 = "result";
            phase3 = "";
        }

        while (phase3 == "nullCheck") //===> Check for Dull Combat
        {
          Console.WriteLine($"Shift this round: {hpShift}");
          if (hpShift == 0) { nullRounds++;}
          {
            Console.WriteLine($"Null Rounds: {nullRounds}.");
          }

          phase3 = "cleanup";
        }

        while (phase3 == "cleanup") //===> Cleanup Round
        {
          Console.WriteLine($"Continue?");
          Console.ReadLine();

          phase3 = "heroTurn";
        }
      } while (phase2 == "loop" && nullRounds < 3);

      phase2 = "result";
      phase3 = "";
    }

    while (phase2 == "result") //==> Battle Result
    {
      Console.WriteLine("todo: Result Screen");
      Console.WriteLine("Press Key to Continue");

      Console.ReadLine();
      Console.Clear();

      phase2 = "end";
      phase3 = "";
    }

    while (phase2 == "end") //==> End Battle
    {
      Console.WriteLine("todo: End Battle Screen");
      Console.WriteLine("Press Key to Continue");

      Console.ReadLine();
      Console.Clear();

      phase1 = "gameEnd";
      phase2 = "";
      phase3 = "";
    }
  }

  //todo Level Up

  while (phase1 == "") //=> Phase Selector
  {
    if (!gameRunning)
      break;
    if (debug) phase1 = "battle";
    phase2 = "";
    phase3 = "";
  }
}