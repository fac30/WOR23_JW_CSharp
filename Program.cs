// todo Just started fixing an enless do loop in the battle loop section
// todo I just added the battleDone bool at the top of ==battle 

bool debug = false;
if (debug) Console.WriteLine("<CODE>");

// => Setup
if (debug) Console.WriteLine("<SETUP>");

// ==> Systems
Random die = new Random();
int battleRound = 0;
int dullTurns = 0;

// ==> Typography
string lineGo = "======================";
string lineDiv = "----------------------";

// ==> Entities
// ===> Hero
int heroRawLevel = 0;
int heroRawHealth = 10;
int heroRawBonus = 0;
int heroRawArmor = 0;
string heroStrLevel = $"Level {heroRawLevel}";
string heroStrHealth = $"{heroRawHealth} HP";
string heroStrBonus = $"";
string heroStrArmor = $"";
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
string phase0 = "bookend";
string phase1 = "gameStart";
string phase2 = "";
string phase3 = "";

bool gameRunning = true;

if (debug) Console.WriteLine("</SETUP>");

//==================================================

while (gameRunning) { //!! Game Starts
  if (debug) {
    Console.WriteLine("<GAME-RUNNING>");
  }

  //----- BOOKEND ----------------------------------

  while (phase0 == "bookend") {
    while (phase1 == "gameStart") //=> Title Screen
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

      phase0 = "";
      phase1 = "";

      if (debug) Console.WriteLine("==gameStart==|");
    }

    while (phase1 == "gameEnd") //=> Game Over
    {
      if (debug) Console.WriteLine("\n|==gameEnd==>");

      Console.WriteLine($"Game Over");
      Console.WriteLine($"Press enter to End");

      Console.ReadLine();

      gameRunning = false;
      phase1 = "";

      if (debug) Console.WriteLine("==gameEnd==|");
    }
  }

  //----- SYSTEMS ----------------------------------

  while (phase0 == "system") {
    while (phase1 == "battle") { //=> Battle
      if (debug) 
      {
        Console.WriteLine("\n|==battle==>");
      }

      bool battleDone = false;
      bool battleWon = false;

      /* Possible States
        |  done |  won | Won     |
        | !done | !won | Ongoing |
        |  done | !won | Lost    |
        | !done |  won | Error   |
      */

      while (phase2 == "") { //==> Battle Setup
        if (debug) {
          Console.WriteLine("\n|==battle.setup==>");
        }

        battleRound = 0;
        dullTurns = 0;
        
        npcRawLevel = heroRawLevel;
        npcRawHealth = 10 + npcRawLevel;

        Console.WriteLine(lineGo);
        Console.WriteLine($"A level {npcRawLevel} monster appears!");
        Console.WriteLine($"Press enter to start battle");

        Console.ReadLine();
        // Console.Clear();
        
        phase2 = "loop";

        if (debug) Console.WriteLine("==battle.setup==|");
      }

      while (phase2 == "loop" && battleDone == false) { //==> Battle Loop
        if (debug) {
          Console.WriteLine("\n|==battle.loop==>");
        }

        phase3 = "";

        while (phase2 == "loop" && dullTurns < 6) {
          if (debug) {
            Console.WriteLine("\n|==battle.loop(do)==>");
          }
          
          //===> Initialise 1-Round Variables
          string lastAction = "";
          int hpShift = 0;

          while (phase3 == "") { //===> Round Start
            if (debug) {
              Console.WriteLine("\n|==battle.loop(do).setup==>");
            }

            battleRound++;

            Console.WriteLine(lineGo);
            Console.WriteLine($"Press enter to start Round {battleRound}");

            Console.ReadLine();

            phase3 = "turnHero";
          }

          while (phase3 == "turnHero") { //===> Hero's Turn
            if (debug) {
              Console.WriteLine("\n|==battle.loop(do).turnHero==>");
            }
            
            Console.WriteLine(lineDiv);
            Console.WriteLine("Hero's Turn");
            Console.WriteLine($"{heroStrLevel} • {heroStrHealth}");
            if (heroRawArmor != 0)
            {
              Console.WriteLine(heroStrArmor);
            }
            if (heroRawBonus != 0)
            {
              Console.WriteLine(heroStrBonus);
            }
            Console.WriteLine("Press enter to attack\n");

            Console.ReadLine();

            int roll = die.Next(dMinHero, dMaxHero);
            int attack = roll + heroRawBonus;
            int damage = attack - npcRawArmor;

            npcRawHealth -= damage;
            hpShift += attack;

            Console.WriteLine($"You rolled {roll}");

            if (attack != roll)
            {
              Console.WriteLine($"Your skill of {heroRawBonus} boosts that to {attack}");
            }
            if (damage != attack)
            {
              Console.WriteLine($"The enemy blocked {npcRawArmor}");
            }
            
            Console.WriteLine /* Damage Taken by Enemy */
            (
              "The enemy loses " +
              damage +
              " HP, leaving it with " +
              (npcRawHealth > 0 ? npcRawHealth : 0) +
              " HP"
            );

            lastAction = "hero";

            Console.WriteLine("Continue?");
            Console.ReadLine();

            phase3 = "checkHp";
          
            if (debug) {
              Console.WriteLine("\n==battle.loop(do).turnHero==|");
            }
          }

          while (phase3 == "turnNpc") { //===> NPC's Turn
            if (debug) Console.WriteLine("\n|==battle.loop(do).turnNpc==>");
            
            Console.WriteLine(lineDiv);
            Console.WriteLine($"Enemy's Turn");
            Console.WriteLine($"{npcRawHealth} HP");
            Console.WriteLine("");
            Console.WriteLine($"Press enter to defend");
            
            Console.ReadLine();

            int attack = die.Next(dMinHero, dMaxHero);
            hpShift += attack;

            lastAction = "npc";

            phase3 = "checkHp";
          }

          while (phase3 == "checkHp") { //===> Check HP
            if (debug) {
              Console.WriteLine("\n|==battle.loop(do).heroCheck==>");
            }
            
            Console.WriteLine(lineDiv);
            
            if (heroRawHealth <= 0 || npcRawHealth <= 0) {
              if (debug) {
                Console.WriteLine("\n==battle.loop(do).heroCheck==X");
              }

              if (heroRawHealth > 0) { // Hero Wins
                battleWon = true;
              }
              else { // NPC Wins
                battleWon = false;
              }

              phase2 = "result";
              phase3 = "";
              break;
            }
            
            phase3 = "checkDull";

            if (debug) {
              Console.WriteLine("\n==battle.loop(do).heroCheck==|");
            }
          }

          while (phase3 == "checkDull") { //===> Check for Dull Combat
            if (debug) {
              Console.WriteLine("\n|==battle.loop(do).checkDull==>");
              Console.WriteLine($"Shift this round: {hpShift}");
            }

            if (hpShift == 0) dullTurns++;
            
            if (debug) {
              Console.WriteLine($"Null Turns: {dullTurns}.");
            }

            phase3 = "roundEnd";

            if (debug) {
              Console.WriteLine("\n==battle.loop(do).checkDull==|");
            }
          }

          while (phase3 == "roundEnd") { //===> Prepare for Next Round
            if (debug) {
              Console.WriteLine("\n|==battle.loop(do).roundEnd==>");
            }
            
            Console.WriteLine(lineDiv);
            Console.WriteLine($"Continue?");

            Console.ReadLine();

            if (lastAction == "hero") {
              phase3 = "turnNpc";
            }
            else if (lastAction == "npc") {
              phase3 = "";
            }
            
            if (debug) {
              Console.WriteLine("\n==battle.loop(do).roundEnd==|");
            }
          }
        
          if (debug) {
            Console.WriteLine("==battle.loop(do)==|");
          }
        }

        phase2 = "result";
        phase3 = "";

        if (debug) {
          Console.WriteLine("==battle.loop==|");
        }
      }

      while (phase2 == "result") { //==> Battle Result
        if (debug) {
          Console.WriteLine("\n|==battle.result==>");
        }

        Console.WriteLine($"You {(battleWon ? "Won" : "Lost")}!");
        Console.WriteLine("Press enter to Continue");

        Console.ReadLine();
        // Console.Clear();

        phase2 = "end";
        phase3 = "";

        if (debug) {
          Console.WriteLine("==battle.result==|");
        }
      }

      while (phase2 == "end") { //==> End Battle
        if (debug) {
          Console.WriteLine("\n|==battle.end==>");
        }

        Console.WriteLine(lineDiv);
        Console.WriteLine("Press enter to Continue");

        Console.ReadLine();
        // Console.Clear();

        phase1 = "gameEnd";
        phase2 = "";
        phase3 = "";

        if (debug) {
          Console.WriteLine("==battle.end==|");
        }
      }
    
      if (debug) {
        Console.WriteLine("==battle==|");
      }
    }

    while (phase1 == "levelUp") {} //=> LevelUp
  }
  //----- CATCH ------------------------------------

  while (phase0 == "") { //=> Phase Selector
    if (debug) {
      Console.WriteLine($"\n|==phaseSelector==>");
      
      Console.WriteLine($"\n|==phaseSelector.inputs==>");
      Console.WriteLine($"gameRunning: {gameRunning}");
      Console.WriteLine($"phase0: {phase0}");
      Console.WriteLine($"phase1: {phase1}");
      Console.WriteLine($"phase2: {phase2}");
      Console.WriteLine($"phase3: {phase3}");
      Console.WriteLine($"==phaseSelector.inputs==|");
    
      Console.WriteLine($"\n|==phaseSelector.logic==>");
      Console.WriteLine($"\n==phaseSelector.logic.gameRunning==>");
    }

    if (!gameRunning) break;

    if (debug) {
      Console.WriteLine($"==phaseSelector.logic.gameRunning==|");
      
      // ==> Phase 1
      if (debug) Console.WriteLine($"\n|==phaseSelector.logic.phase0==>");
    }

    phase0 = "system";

    if (debug) {
      Console.WriteLine($"==phaseSelector.logic.phase0==|");
      
      // ==> Phase 1
      if (debug) Console.WriteLine($"\n|==phaseSelector.logic.phase1==>");
    }
    
    phase1 = "battle";
    
    if (debug) {
      Console.WriteLine($"==phaseSelector.logic.phase1==|");
      
      Console.WriteLine($"\n|==phaseSelector.logic.phase2==>");
    }

    phase2 = "";

    if (debug) {
      Console.WriteLine($"==phaseSelector.logic.phase2==|");
      
      Console.WriteLine($"\n|==phaseSelector.logic.phase3==>");
    }

    phase3 = "";

    if (debug) {
      Console.WriteLine($"==phaseSelector.logic.phase3==|");
      Console.WriteLine($"==phaseSelector.logic==|");
    
      Console.WriteLine($"\n|==phaseSelector.outputs==>");
      Console.WriteLine($"gameRunning: {gameRunning}");
      Console.WriteLine($"phase0: {phase0}");
      Console.WriteLine($"phase1: {phase1}");
      Console.WriteLine($"phase2: {phase2}");
      Console.WriteLine($"phase3: {phase3}");
      Console.WriteLine($"==phaseSelector.outputs==|");

      Console.WriteLine("==phaseSelector==|");
    }
  }

  //-----------------------------------------------

  if (debug) {
    Console.WriteLine("</GAME-RUNNING>");
  }
}

if (debug) {
  Console.WriteLine("</CODE>");
}