// todo Just started fixing an enless do loop in the battle loop section
// todo I just added the battleDone bool at the top of ==battle 

bool debug = true;
if (debug) Console.WriteLine("<CODE>");

// => Setup
if (debug) Console.WriteLine("<SETUP>");

// ==> Systems
Random die = new Random();
int battleRound = 0;
int nullRounds = 0;

// ==> Entities
// ===> Hero
int heroRawLevel = 0;
int heroRawHealth = 10;
int heroRawBonus = 0;
// int heroRawArmor = 0;
string heroStatBonus = "";
string heroStatArmor = "";
int dMinHero = 1;
int dMaxHero = 11;

// ===> NPC
int npcRawLevel = 0;
int npcRawHealth = 10;
// int npcRawBonus = 0;
int npcRawArmor = 0;
// int dMinNpc = 1;
// int dMaxNpc = 11;

// ==> Structure
string phase1 = "gameStart";
string phase2 = "";
string phase3 = "";

bool gameRunning = true;

if (debug) Console.WriteLine("</SETUP>");

// =================================================

while (gameRunning)
{
  if (debug) Console.WriteLine("<GAME-RUNNING>");

  while (phase1 == "gameStart") //=> Game Start
  {
    if (debug) Console.WriteLine("\n|==gameStart==>");

    // Console.Clear();
    
    Console.WriteLine($"======================");
    Console.WriteLine($"•• Quest for Agency ••");
    Console.WriteLine($"----------------------");
    Console.WriteLine($"PRESS ENTER TO START");
    Console.WriteLine($"======================");
    
    Console.ReadLine();
    // Console.Clear();

    phase1 = "";

    if (debug) Console.WriteLine("==gameStart==|");
  }

  while (phase1 == "gameEnd") //=> Game End
  {
    if (debug) Console.WriteLine("\n|==gameEnd==>");

    Console.WriteLine($"Game Over");
    Console.WriteLine($"Press enter to End");

    Console.ReadLine();

    gameRunning = false;
    phase1 = "";

    if (debug) Console.WriteLine("==gameEnd==|");
  }
  
  // ----------------------------------------------

  while (phase1 == "battle") //=> Battle
  {
    if (debug) Console.WriteLine("\n|==battle==>");

    bool battleDone = false;

    while (phase2 == "") //==> Battle Setup
    {
      if (debug) Console.WriteLine("\n|==battle.setup==>");

      battleRound = 0;
      nullRounds = 0;
      
      // todo Implement logic for varying enemy stats
      npcRawLevel = heroRawLevel;
      npcRawHealth = 10 + npcRawLevel;

      Console.WriteLine($"======================");
      Console.WriteLine($"A level {npcRawLevel} monster appears!");
      Console.WriteLine($"Press enter to start battle");

      Console.ReadLine();
      // Console.Clear();
      
      phase2 = "loop";

      if (debug) Console.WriteLine("==battle.setup==|");
    }

    while (phase2 == "loop" && battleDone == false) //==> Battle Loop
    {
      if (debug) Console.WriteLine("\n|==battle.loop==>");

      phase3 = "";

      do
      {
        if (debug) Console.WriteLine("\n|==battle.loop(do)==>");
        
        battleRound++;
        int hpShift = 0;

        while (phase3 == "") //===> Round Start
        {
          if (debug) Console.WriteLine("\n|==battle.loop(do).setup==>");

          Console.WriteLine($"======================");

          Console.WriteLine($"Press enter to start Round {battleRound}");
          Console.ReadLine();

          phase3 = "heroTurn";
        }

        while (phase3 == "heroTurn") //===> Hero's Turn
        {
          if (debug) Console.WriteLine("\n|==battle.loop(do).heroTurn==>");
          
          Console.WriteLine($"----------------------");
          Console.WriteLine($"Hero's Turn");
          Console.WriteLine($"Level {heroRawLevel} • {heroRawHealth} HP {heroStatArmor} {heroStatBonus}");
          Console.WriteLine("");
          Console.WriteLine($"Press enter to attack");

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
          if (debug) Console.WriteLine("\n|==battle.loop(do).heroCheck==>");
          
          Console.WriteLine($"----------------------");
          
          if (heroRawHealth <= 0 || npcRawHealth <= 0)
          {
            phase2 = "result";
            phase3 = "cleanup";
            break;
          }
          
          phase3 = "npcTurn";
        }

        while (phase3 == "npcTurn") //===> NPC's Turn
        {
          if (debug) Console.WriteLine("\n|==battle.loop(do).npcTurn==>");
          
          Console.WriteLine($"----------------------");
          Console.WriteLine($"Enemy'S Turn");
          Console.WriteLine($"{npcRawHealth} HP");
          Console.WriteLine("");
          Console.WriteLine($"Press enter to defend");
          
          Console.ReadLine();

          int attack = die.Next(dMinHero, dMaxHero);
          hpShift += attack;

          phase3 = "check";
        }

        while (phase3 == "npcCheck") //===> Check HP
        {
          if (debug) Console.WriteLine("\n|==battle.loop(do).npcCheck==>");
          
          Console.WriteLine($"----------------------");
          
          if (heroRawHealth <= 0 || npcRawHealth <= 0) { phase3 = "cleanup"; }
          else { phase3 = "nullCheck"; }
        }

        while (phase3 == "nullCheck") //===> Check for Dull Combat
        {
          if (debug) Console.WriteLine("\n|==battle.loop(do).nullCheck==>");
          
          Console.WriteLine($"Shift this round: {hpShift}");

          if (hpShift == 0) { nullRounds++;}
            Console.WriteLine($"Null Rounds: {nullRounds}.");

          phase3 = "cleanup";
        }

        while (phase3 == "cleanup") //===> Cleanup Round
        {
          if (debug) Console.WriteLine("\n|==battle.loop(do).cleanup==>");
          
          Console.WriteLine($"Continue?");
          Console.ReadLine();

          phase3 = "heroTurn";
        }
      
        if (debug) Console.WriteLine("==battle.loop(do)==|");
      } while (phase2 == "loop" && nullRounds < 3);

      phase2 = "result";
      phase3 = "";

      if (debug) Console.WriteLine("==battle.loop==|");
    }

    while (phase2 == "result") //==> Battle Result
    {
      if (debug) Console.WriteLine("\n|==battle.result==>");

      Console.WriteLine("todo: Result Screen");
      Console.WriteLine("Press enter to Continue");

      Console.ReadLine();
      // Console.Clear();

      phase2 = "end";
      phase3 = "";

      if (debug) Console.WriteLine("==battle.result==|");
    }

    while (phase2 == "end") //==> End Battle
    {
      if (debug) Console.WriteLine("\n|==battle.end==>");

      Console.WriteLine("todo: End Battle Screen");
      Console.WriteLine("Press enter to Continue");

      Console.ReadLine();
      // Console.Clear();

      phase1 = "gameEnd";
      phase2 = "";
      phase3 = "";

      if (debug) Console.WriteLine("==battle.end==|");
    }
  
    if (debug) Console.WriteLine("==battle==|");
  }

  // ----------------------------------------------
  
  //todo Level Up

  // ----------------------------------------------
  
  while (phase1 == "") //=> Phase Selector
  {
    // ==> Dev Check
    if (debug) Console.WriteLine($"\n|==phaseSelector==>");

    if (debug) Console.WriteLine($"\n|==phaseSelector.inputs==>");
    if (debug) Console.WriteLine($"gameRunning: {gameRunning}");
    if (debug) Console.WriteLine($"phase1: {phase1}");
    if (debug) Console.WriteLine($"phase2: {phase2}");
    if (debug) Console.WriteLine($"phase3: {phase3}");
    if (debug) Console.WriteLine($"==phaseSelector.inputs==|");

    
    if (debug) Console.WriteLine($"\n|==phaseSelector.logic==>");
    // ==> Game Status
    if (debug) Console.WriteLine($"\n==phaseSelector.logic.gameRunning==>");
    if (!gameRunning)
      break;
    if (debug) Console.WriteLine($"==phaseSelector.logic.gameRunning==|");
    
    // ==> Phase 1
    if (debug) Console.WriteLine($"\n|==phaseSelector.logic.phase1==>");
    if (debug) phase1 = "battle";
    if (debug) Console.WriteLine($"==phaseSelector.logic.phase1==|");
    
    // ==> Phase 2
    if (debug) Console.WriteLine($"\n|==phaseSelector.logic.phase2==>");
    phase2 = "";
    if (debug) Console.WriteLine($"==phaseSelector.logic.phase2==|");
    
    // ==> Phase 3
    if (debug) Console.WriteLine($"\n|==phaseSelector.logic.phase3==>");
    phase3 = "";
    if (debug) Console.WriteLine($"==phaseSelector.logic.phase3==|");
    if (debug) Console.WriteLine($"==phaseSelector.logic==|");


    if (debug) Console.WriteLine($"\n|==phaseSelector.outputs==>");
    if (debug) Console.WriteLine($"gameRunning: {gameRunning}");
    if (debug) Console.WriteLine($"phase1: {phase1}");
    if (debug) Console.WriteLine($"phase2: {phase2}");
    if (debug) Console.WriteLine($"phase3: {phase3}");
    if (debug) Console.WriteLine($"==phaseSelector.outputs==|");

    if (debug) Console.WriteLine("==phaseSelector==|");
  }

  if (debug) Console.WriteLine("</GAME-RUNNING>");
}

if (debug) Console.WriteLine("</CODE>");