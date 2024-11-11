//=> Declare Variables
//==> App
string phase = "title";
string? readResult;
string menuSelection = "";

//===> Typography
string div2 = "\n|=====================================<••>=====================================|\n";
string div1 = "\n--------------------------------------<··>--------------------------------------\n";

//==> Pets
//===> Individual Pets
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

//===> Pet Array
int maxPets = 8;
string[,] ourAnimals = new string[maxPets, 6];

//=> Populate Array
for (int i = 0; i < maxPets; i++)
{
  switch (i)
  {
    case 0:
      animalSpecies = "dog";
      animalID = "d1";
      animalAge = "2";
      animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
      animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
      animalNickname = "lola";
      break;
    case 1:
      animalSpecies = "dog";
      animalID = "d2";
      animalAge = "9";
      animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
      animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
      animalNickname = "loki";
      break;
    case 2:
      animalSpecies = "cat";
      animalID = "c3";
      animalAge = "1";
      animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
      animalPersonalityDescription = "friendly";
      animalNickname = "Puss";
      break;
    case 3:
      animalSpecies = "cat";
      animalID = "c4";
      animalAge = "?";
      animalPhysicalDescription = "";
      animalPersonalityDescription = "";
      animalNickname = "";
      break;
    default:
      animalSpecies = "";
      animalID = "";
      animalAge = "";
      animalPhysicalDescription = "";
      animalPersonalityDescription = "";
      animalNickname = "";
      break;
  }

  ourAnimals[i, 0] = $"ID #: {animalID}";
  ourAnimals[i, 1] = $"Species: {animalSpecies}";
  ourAnimals[i, 2] = $"Age: {animalAge}";
  ourAnimals[i, 3] = $"Nickname: {animalNickname}";
  ourAnimals[i, 4] = $"Physical Description: {animalPhysicalDescription}";
  ourAnimals[i, 5] = $"Personality: {animalPersonalityDescription}";
}

while (phase == "title") //=> Title
{
  Console.Clear();
  Console.WriteLine("+------------------------------------------------------------------------------+");
  Console.WriteLine("| ██████╗ ██████╗ ███╗   ██╗████████╗ ██████╗ ███████╗ ██████╗                 |");
  Console.WriteLine("|██╔════╝██╔═══██╗████╗  ██║╚══██╔══╝██╔═══██╗██╔════╝██╔═══██╗                |");
  Console.WriteLine("|██║     ██║   ██║██╔██╗ ██║   ██║   ██║   ██║███████╗██║   ██║                |");
  Console.WriteLine("|██║     ██║   ██║██║╚██╗██║   ██║   ██║   ██║╚════██║██║   ██║                |");
  Console.WriteLine("|╚██████╗╚██████╔╝██║ ╚████║   ██║   ╚██████╔╝███████║╚██████╔╝                |");
  Console.WriteLine("| ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝   ╚═╝    ╚═════╝ ╚══════╝ ╚═════╝                 |");
  Console.WriteLine("|██████╗ ███████╗████████╗███████╗██████╗ ██╗███████╗███╗   ██╗██████╗ ███████╗|");
  Console.WriteLine("|██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗██║██╔════╝████╗  ██║██╔══██╗██╔════╝|");
  Console.WriteLine("|██████╔╝█████╗     ██║   █████╗  ██████╔╝██║█████╗  ██╔██╗ ██║██║  ██║███████╗|");
  Console.WriteLine("|██╔═══╝ ██╔══╝     ██║   ██╔══╝  ██╔══██╗██║██╔══╝  ██║╚██╗██║██║  ██║╚════██║|");
  Console.WriteLine("|██║     ███████╗   ██║   ██║     ██║  ██║██║███████╗██║ ╚████║██████╔╝███████║|");
  Console.WriteLine("|╚═╝     ╚══════╝   ╚═╝   ╚═╝     ╚═╝  ╚═╝╚═╝╚══════╝╚═╝  ╚═══╝╚═════╝ ╚══════╝|");
  Console.WriteLine("+------------------------------------------------------------------------------+");
  Console.WriteLine(div1);
  Console.WriteLine("Press the Enter key to continue");
  Console.ReadLine();

  phase = "menu";
};

do //=> Main Loop
{
  while (phase == "menu") //==> Menu Options
  {
    Console.Clear();
    Console.WriteLine(div2);
    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(div1);
    Console.WriteLine("  1. List all of our current pet information");
    Console.WriteLine("  2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine("  3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine("  4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine("  5. Edit an animal’s age");
    Console.WriteLine("  6. Edit an animal’s personality description");
    Console.WriteLine("  7. Display all cats with a specified characteristic");
    Console.WriteLine("  8. Display all dogs with a specified characteristic");
    Console.WriteLine(div1);
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
      menuSelection = readResult.ToLower();
      if (readResult == "exit" || readResult == "1" || readResult == "2" || readResult == "3" || readResult == "4" || readResult == "5" || readResult == "6" || readResult == "7" || readResult == "8")
      {
        phase = "";
        if (readResult != "exit")
        {
          phase = "feature";
          Console.WriteLine($"You selected menu option {menuSelection}.");
          Console.WriteLine("Press the Enter key to continue");
          readResult = Console.ReadLine();
        }
      }
    }
  }
  
  while (phase =="feature") //==> Feature Loops
  {
    Console.Clear();
    Console.WriteLine(div2);

    switch (menuSelection)
    {
      case "1": //===> List all of our current pet information
        for (int i = 0; i < maxPets; i++)
        {
          if (ourAnimals[i, 0] != "ID #: ")
          {
            for (int j = 0; j < 6; j++)
            {
              Console.WriteLine(ourAnimals[i, j]);
            }
            Console.WriteLine(div1);
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
          }
        }
        Console.WriteLine("Press the Enter key to continue.");
        readResult = Console.ReadLine();
        phase = "menu";
        break;
      case "2": //===> Add a new animal friend to the ourAnimals array
        string anotherPet = "y";
        int petCount = 0;

        for (int i = 0; i < maxPets; i++)
        {
          if (ourAnimals[i, 0] != "ID #: ")
          {
            petCount++;
          }
        }

        if (petCount < maxPets) //===> Display # of pets
        {
          Console.WriteLine($"We currently have {petCount} pets that need homes.");
          Console.WriteLine($"We can manage {(maxPets - petCount)} more.");
        }

        /* Create Pet */ while (anotherPet == "y" && petCount < maxPets)
        {
          bool validEntry = false;
          /* Input Species */ do
          {
            Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
            readResult = Console.ReadLine();
            if (readResult != null)
              animalSpecies = readResult.ToLower();

            if (animalSpecies != "dog" && animalSpecies != "cat")
              validEntry = false;
            else
              validEntry = true;
          } while (validEntry == false);

          /* Derive ID */ animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

          /* Input Age */ do
          {
            int petAge;

            Console.WriteLine("Enter the pet's age or enter ? if unknown");
            readResult = Console.ReadLine();

            if (readResult != null)
              animalAge = readResult;

            if (animalAge != "?")
              //!! THIS LINE IS FUCKING CLEVER
              validEntry = int.TryParse(animalAge, out petAge);
            else
              validEntry = true;

          } while (validEntry == false);

          /* Input Appearance */ do
          {
            Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
              animalPhysicalDescription = readResult.ToLower();
              if (animalPhysicalDescription == "")
              {
                animalPhysicalDescription = "tbd";
              }
            }
          } while (animalPhysicalDescription == "");

          /* Input Personality */ do
          {
            Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
              animalPersonalityDescription = readResult.ToLower();
              if (animalPersonalityDescription == "")
              {
                animalPersonalityDescription = "tbd";
              }
            }
          } while (animalPersonalityDescription == "");
          
          /* Input Nickname */ do
          {
            Console.WriteLine("Enter a nickname for the pet");
            readResult = Console.ReadLine();
            if (readResult != null)
            {
              animalNickname = readResult.ToLower();
              if (animalNickname == "")
              {
                animalNickname = "tbd";
              }
            }
          } while (animalNickname == "");

          ourAnimals[petCount, 0] = "ID #: " + animalID;
          ourAnimals[petCount, 1] = "Species: " + animalSpecies;
          ourAnimals[petCount, 2] = "Age: " + animalAge;
          ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
          ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
          ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;

          petCount++;

          /* Add Another Pet? */ if (petCount < maxPets)
          {
            Console.WriteLine("Do you want to enter info for another pet (y/n)");
            do
            {
              readResult = Console.ReadLine();
              if (readResult != null)
                anotherPet = readResult.ToLower();
            } while (anotherPet != "y" && anotherPet != "n");
          }
        }
        
        /* Too many pets */ if (petCount >= maxPets)
        {
          Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
          Console.WriteLine("Press the Enter key to continue.");
          readResult = Console.ReadLine();
        }

        phase = "menu";
        break;
      case "3": //===> Ensure animal ages and physical descriptions are complete
        for (int i = 0; i < maxPets; i++) // Loop through ourAnimals
        {
          if (ourAnimals[i, 0] != "ID #: ") // Find pets with IDs
          {
            Console.WriteLine(div1);
            bool valid = false;
            bool validAge = false;
            bool validDesc = false;

            string iId = ourAnimals[i, 0].Substring(6);
            string iAge = ourAnimals[i, 2].Substring(5);
            string iDesc = ourAnimals[i, 4].Substring(22);

            do // Display status of animal data
            {
              if (iAge != "?" && int.TryParse(iAge, out int age) && age >= 0 && age <= 30)
                validAge = true;
              if (iDesc != null && iDesc != "tbd" && iDesc.Length != 0)
                validDesc = true;
              if (validAge && validDesc)
                valid = true;

              Console.WriteLine($"Pet #{iId} {(valid ? "is up to date" : "needs updates")}");

              while (valid == false) // Further Info on Invalid Data
              {
                int menuOption = 0;
                string optionAge = "";
                string optionDesc = "";
                string? optionChose = "";
                string updateCurrent = "";
                
                Console.WriteLine(div1);
                while (updateCurrent == "") // List Options
                {
                  Console.WriteLine($"Updates Required");
                  if (!validAge)
                  {
                    menuOption++;
                    optionAge = menuOption.ToString();
                    Console.WriteLine($"  {menuOption}. Age");
                  }
                  if (!validDesc)
                  {
                    menuOption++;
                    optionDesc = menuOption.ToString();
                    Console.WriteLine($"  {menuOption}. Physical Description");
                  }
                  
                  Console.WriteLine("Type a number to choose an option, then press Enter");

                  optionChose = Console.ReadLine();

                  if (optionChose == optionAge || optionChose == optionDesc)
                    updateCurrent = optionChose.ToLower();
                }

                if (updateCurrent == optionAge) // Update Age
                {
                  while (!validAge && updateCurrent == optionAge)
                  {
                    //todo animalAge: Ensure valid numeric value assigned for all animals in the ourAnimals with data.
                    //todo animalAge: Convert the value entered to numeric data type.
                  }
                  validAge = true;
                }
                else if (updateCurrent == optionDesc) // Update Description
                {
                  while (!validDesc && updateCurrent == optionDesc) {
                    //todo Ensure valid string assigned for all animals in ourAnimals with data.
                    //todo Values cannot be null
                    //todo Values cannot have zero characters
                    //todo Any further restriction is up to the developer
                    //todo Pause to inform the application user when all data requirements are met
                  }
                  validDesc = true;
                }
                
                if (validAge && validDesc) // Confirm info is valid
                {
                  valid = true;
                  Console.WriteLine("Pet is up to date");
                  Console.WriteLine("Press Enter to continue");
                  Console.ReadLine();
                }
              }
            } while (valid == false);
          }
        }
        Console.WriteLine("Press the Enter key to continue.");
        Console.ReadLine();
        phase = "menu";
        break;
      case "4": //===> Ensure animal nicknames and personality descriptions are complete
        Console.WriteLine("this app feature is coming soon - please check back to see progress.");
        Console.WriteLine("Press the Enter key to continue.");
        readResult = Console.ReadLine();
        break;
      case "5": //===> Edit an animal’s age
        Console.WriteLine("this app feature is coming soon - please check back to see progress.");
        Console.WriteLine("Press the Enter key to continue.");
        readResult = Console.ReadLine();
        break;
      case "6": //===> Edit an animal’s personality description
        Console.WriteLine("this app feature is coming soon - please check back to see progress.");
        Console.WriteLine("Press the Enter key to continue.");
        readResult = Console.ReadLine();
        break;
      case "7": //===> Display all cats with a specified characteristic
        Console.WriteLine("this app feature is coming soon - please check back to see progress.");
        Console.WriteLine("Press the Enter key to continue.");
        readResult = Console.ReadLine();
        break;
      case "8": //===> Display all dogs with a specified characteristic
        Console.WriteLine("this app feature is coming soon - please check back to see progress.");
        Console.WriteLine("Press the Enter key to continue.");
        readResult = Console.ReadLine();
        break;
      default:
        break;
    }
  }
  
} while (menuSelection != "exit");