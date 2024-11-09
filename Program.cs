bool debug = false;
if (debug) {
  Console.WriteLine("|==code==>");
}

// => Setup
if (debug) {
  Console.WriteLine("|==setup==>");
}

// ==> Systems
Random die = new Random();
int battleRound = 0;
int dullTurns = 0;

// ==> Typography
string lineGo = "======================";
string lineDiv = "----------------------";

// ==> Entities
// ===> Hero
string heroName = "Nameless Wanderer";

int heroRawLevel = 0;
int heroRawHealth = 10;
int heroRawBonus = 0;
int heroRawArmor = 0;

int dMinHero = 1;
int dMaxHero = 11;

// ===> NPC
string npcName = "";
string npcArticle = "";

int npcRawLevel = 0;
int npcRawHealth = 10;
int npcRawBonus = 0;
int npcRawArmor = 0;

int dMinNpc = 1;
int dMaxNpc = 11;

// ==> Structure
string phase0 = "bookend";
string phase1 = "gameStart";
string phase2 = "";
string phase3 = "";

bool gameRunning = true;

if (debug) {
  Console.WriteLine("==setup==|");
}

while (gameRunning) { //!! Game Starts
  if (debug) {
    Console.WriteLine("\n|==gameRunning==>");
  }

  while (phase0 == "bookend") {
    if (debug) {
      Console.WriteLine("\n|==bookend==>");
    }

    while (phase1 == "gameStart") //=> Title Screen
    {
      if (debug) {
        Console.WriteLine("\n|==bookend.gameStart==>");
      }

      // Console.Clear();
      
      Console.WriteLine($"======================");
      Console.WriteLine($"•• Quest for Agency ••");
      Console.WriteLine($"----------------------");
      Console.WriteLine($"PRESS ENTER TO START");
      Console.WriteLine($"======================");
      
      Console.ReadLine();
      // Console.Clear();

      phase0 = "system";
      phase1 = "heroCreate";

      if (debug) {
        Console.WriteLine("==bookend.gameStart==|");
      }
    }

    while (phase1 == "gameEnd") //=> Game Over
    {
      if (debug) {
        Console.WriteLine("\n|==bookend.gameEnd==>");
      }

      Console.WriteLine($"Game Over");
      Console.WriteLine($"Press enter to End");

      Console.ReadLine();

      gameRunning = false;
      phase0 = "";
      phase1 = "";

      if (debug) {
        Console.WriteLine("==bookend.gameEnd==|");
      }
    }
    
    if (debug) {
      Console.WriteLine("==bookend==|");
    }
  }

  while (phase0 == "system") {
    if (debug) {
      Console.WriteLine("\n|==system==>");
    }

    while (phase1 == "heroCreate") { //=> Character Creation
      if (debug) {
        Console.WriteLine("|==system.heroCreate==>");
      }

      string? readName;
      string? readSkill;

      Console.WriteLine("What is Your Name?");
      do {
          readName = Console.ReadLine();
      } while (readName == null);
      heroName = readName;

      Console.WriteLine("What is your greatest strength?");
      Console.WriteLine("1. I'm quick and skilful");
      Console.WriteLine("2. I never give up");
      do {
        Console.WriteLine("Type 1 or 2, then press enter");
        readSkill = Console.ReadLine();
      } while (readSkill == null || (readSkill != "1" && readSkill != "2"));
      
      if (readSkill == "1") {
        heroRawBonus++;
        Console.WriteLine($"You add {heroRawBonus} to your attack rolls");
      }
      else if (readSkill == "2") {
        heroRawArmor++;
        Console.WriteLine($"You block {heroRawArmor} of damage");
      }

      phase0 = "";
      phase1 = "";

      if (debug) {
        Console.WriteLine(">==system.heroCreate==|");
      }
    }

    while (phase1 == "battle") { //=> Battle
      if (debug) 
      {
        Console.WriteLine("\n|==system.battle==>");
      }

      /* Possible Battle States
        |  done |  won | Won     |
        | !done | !won | Ongoing |
        |  done | !won | Lost    |
        | !done |  won | Error   |
      */

      bool battleDone = false;
      bool battleWon = false;

      while (phase2 == "") { //==> Battle Setup
        if (debug) {
          Console.WriteLine("\n|==system.battle.setup==>");
        }

        battleRound = 0;
        dullTurns = 0;

        int rollName = die.Next(1, 7);
        int rollLevel = die.Next(1, 4);
        int rollBonus = die.Next(1, 3);
        
        switch (rollLevel) {
          case 1:
          case 2:
            npcRawLevel = heroRawLevel - 1;
            break;
          case 5:
          case 6:
            npcRawLevel = heroRawLevel + 1;
            break;
          default:
            npcRawLevel = heroRawLevel;
            break;
        }
        npcRawHealth += npcRawLevel;
        if (rollBonus == 1) {
          npcRawBonus += npcRawLevel;
        }
        else if (rollBonus == 2) {
          npcRawArmor += npcRawLevel;
        }
        
        string compare;
        if (npcRawLevel > heroRawLevel) {
          compare = "stronger than you";
        }
        else if (npcRawLevel < heroRawLevel) {
          compare = "weaker than you";
        }
        else {
          compare = "like a good match";
        }

        npcName = "Beast";
        npcArticle = "a";

        Console.WriteLine(lineGo);
        Console.WriteLine($"Suddenly, {npcArticle} {npcName} appears!");
        Console.WriteLine($"They seem {compare}...");
        Console.WriteLine($"Press enter to start battle");

        Console.ReadLine();
        // Console.Clear();
        
        phase2 = "loop";

        if (debug) {
          Console.WriteLine("==system.battle.setup==|");
        }
      }

      while (phase2 == "loop" && battleDone == false) { //==> Battle Loop
        if (debug) {
          Console.WriteLine("\n|==system.battle.loop==>");
        }

        phase3 = "";

        while (phase2 == "loop" && dullTurns < 6) { // Core Battle Loop
          if (debug) {
            Console.WriteLine("\n|==system.battle.loop(do)==>");
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
              Console.WriteLine("\n|==system.battle.loop(do).turnHero==>");
            }
            
            string heroStrLevel = $"Level {heroRawLevel}";
            string heroStrHealth = $"{heroRawHealth} HP";
            string heroStrBonus = $"";
            string heroStrArmor = $"";

            Console.WriteLine(lineDiv);
            Console.WriteLine($"{heroName}'s Turn");
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
            
            Console.WriteLine($"The {npcName} loses {damage} HP, leaving it with {(npcRawHealth > 0 ? npcRawHealth : 0)} HP"
            );

            lastAction = "hero";

            Console.WriteLine("Continue?");
            Console.ReadLine();

            phase3 = "checkHp";
          
            if (debug) {
              Console.WriteLine("\n==system.battle.loop(do).turnHero==|");
            }
          }

          while (phase3 == "turnNpc") { //===> NPC's Turn
            if (debug) {
              Console.WriteLine("\n|==system.battle.loop(do).turnNpc==>");
            }
            
            // string npcStrLevel = $"Level {npcRawLevel}";
            string npcStrHealth = $"{npcRawHealth} HP";
            string npcStrBonus = $"It adds {npcRawBonus} to its attacks.";
            string npcStrArmor = $"It can block {npcRawArmor}.";

            Console.WriteLine(lineDiv);
            Console.WriteLine($"{npcName}'s Turn");
            Console.WriteLine($"{npcStrHealth}");
            if (npcRawArmor > 0)
            {
              Console.WriteLine(npcStrArmor);
            }
            if (npcRawBonus > 0)
            {
              Console.WriteLine(npcStrBonus);
            }
            Console.WriteLine("Press enter to defend\n");

            Console.ReadLine();

            int roll = die.Next(dMinNpc, dMaxNpc);
            int attack = roll + npcRawBonus;
            int damage = attack - heroRawArmor;

            heroRawHealth -= damage;
            hpShift += attack;

            Console.WriteLine($"The {npcName} rolled {roll}");

            if (attack != roll)
            {
              Console.WriteLine($"Their skill of {npcRawBonus} boosts that to {attack}");
            }
            if (damage != attack)
            {
              Console.WriteLine($"You blocked {heroRawArmor}");
            }
            
            Console.WriteLine ($"You lose {damage} HP, leaving you with {(heroRawHealth > 0 ? heroRawHealth : 0)} HP"
            );

            lastAction = "npc";

            Console.WriteLine("Continue?");
            Console.ReadLine();

            phase3 = "checkHp";

            if (debug) {
              Console.WriteLine("==system.battle.loop(do).turnNpc==|");
            }
          }

          while (phase3 == "checkHp") { //===> Check HP
            if (debug) {
              Console.WriteLine("\n|==system.battle.loop(do).hpCheck==>");
            }
            
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
              Console.WriteLine("\n==system.battle.loop(do).hpCheck==|");
            }
          }

          while (phase3 == "checkDull") { //===> Check for Dull Combat
            if (debug) {
              Console.WriteLine("\n|==system.battle.loop(do).checkDull==>");
              Console.WriteLine($"Shift this round: {hpShift}");
            }

            if (hpShift == 0) dullTurns++;
            
            if (debug) {
              Console.WriteLine($"Null Turns: {dullTurns}.");
            }

            phase3 = "turnEnd";

            if (debug) {
              Console.WriteLine("\n==system.battle.loop(do).checkDull==|");
            }
          }

          while (phase3 == "turnEnd") { //===> Prepare for Next Round
            if (debug) {
              Console.WriteLine("\n|==system.battle.loop(do).turnEnd==>");
            }

            if (lastAction == "hero") {
              phase3 = "turnNpc";
            }
            else if (lastAction == "npc") {
              phase3 = "";
            }
            
            if (debug) {
              Console.WriteLine("\n==system.battle.loop(do).turnEnd==|");
            }
          }
        
          if (debug) {
            Console.WriteLine("==system.battle.loop(do)==|");
          }
        }

        phase2 = "result";
        phase3 = "";

        if (debug) {
          Console.WriteLine("==system.battle.loop==|");
        }
      }

      while (phase2 == "result") { //==> Battle Result
        if (debug) {
          Console.WriteLine("\n|==system.battle.result==>");
        }

        Console.WriteLine($"You {(battleWon ? "Won" : "Lost")}!");
        Console.WriteLine("Press enter to Continue");

        Console.ReadLine();
        // Console.Clear();

        phase2 = "end";
        phase3 = "";

        if (debug) {
          Console.WriteLine("==system.battle.result==|");
        }
      }

      while (phase2 == "end") { //==> End Battle
        if (debug) {
          Console.WriteLine("\n|==system.battle.end==>");
        }

        Console.WriteLine(lineDiv);
        Console.WriteLine("Press enter to Continue");

        Console.ReadLine();
        // Console.Clear();

        phase0 = "bookend";
        phase1 = "gameEnd";
        phase2 = "";
        phase3 = "";

        if (debug) {
          Console.WriteLine("==system.battle.end==|");
        }
      }
    
      if (debug) {
        Console.WriteLine("==system.battle==|");
      }
    }

    while (phase1 == "levelUp") { //=> Level Up
      if (debug) {
        Console.Write("|==system.levelUp==>");
      };

      if (debug) {
        Console.Write("==system.levelUp==|");
      };
    }
  
    if (debug) {
      Console.WriteLine("==system==|");
    }
  }

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

    if (!gameRunning)
      break;

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

  if (debug) {
    Console.WriteLine("==gameRunning==|");
  }
}

if (debug) {
  Console.WriteLine("==code==|");
}