namespace TextAdventureDone
{
    class TextAdventure
    {
        private string playerName;
        private int lives = 3;
        private int currentObstacle = 0;
        private bool gameCompleted = false;
        private string scoresFilePath = "scores.txt";
        private List<ScoreEntry> highScores = new List<ScoreEntry>();

        public void Run()
        {
            LoadScores();
            StartGame();

            // Game loop
            while (lives > 0 && !gameCompleted)
            {
                Console.WriteLine($"\n{playerName}, you have {lives} lives remaining.");

                // Present different obstacles based on progress
                switch (currentObstacle)
                {
                    case 0:
                        PresentMainChoices();
                        break;
                    case 1:
                        if (CrossBridge())
                        {
                            currentObstacle++;
                        }
                        break;
                    case 2:
                        if (ExploreCave())
                        {
                            currentObstacle++;
                        }
                        break;
                    case 3:
                        if (ClimbMountain())
                        {
                            currentObstacle++;
                        }
                        break;
                    case 4:
                        if (FaceBossBattle())
                        {
                            CompleteGame();
                        }
                        break;
                }
            }

            if (lives <= 0)
            {
                Console.WriteLine("\nGame over! You've run out of lives.");
            }

            if (gameCompleted)
            {
                SaveScore();
            }

            Console.WriteLine("Would you like to play again? (yes/no)");
            string restart = Console.ReadLine().ToLower();
            if (restart == "yes" || restart == "y")
            {
                lives = 3;
                currentObstacle = 0;
                gameCompleted = false;
                Run();
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
            }
        }

        private void StartGame()
        {
            // Opening message
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("       WELCOME TO THE MYSTICAL ADVENTURE         ");
            Console.WriteLine("=================================================");
            Console.WriteLine("You find yourself in a mysterious land filled with");
            Console.WriteLine("danger and adventure. Your goal is to navigate through");
            Console.WriteLine("the perils, defeat the Ancient Guardian, and claim the legendary treasure.");
            Console.WriteLine("\nCommands: A/B/C to choose options, help, quit, restart");

            // Display high scores
            DisplayHighScores();

            // Ask for player's name if not already set
            if (string.IsNullOrEmpty(playerName))
            {
                Console.Write("\nEnter your adventurer's name: ");
                playerName = Console.ReadLine();
            }

            Console.WriteLine($"\nWelcome, {playerName}! Your adventure begins now.");
        }

        private void PresentMainChoices()
        {
            Console.WriteLine("\nYou stand at a crossroads. Which path will you take?");
            Console.WriteLine("A. Cross the rickety bridge.");
            Console.WriteLine("B. Explore the dark cave.");
            Console.WriteLine("C. Climb the towering mountain.");
            Console.WriteLine("Type 'help' for assistance or 'quit' to exit the game.");

            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "a":
                    currentObstacle = 1;
                    break;
                case "b":
                    currentObstacle = 2;
                    break;
                case "c":
                    currentObstacle = 3;
                    break;
                case "help":
                    DisplayHelp();
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                case "restart":
                    lives = 3;
                    currentObstacle = 0;
                    Console.WriteLine("Game restarted.");
                    break;
                default:
                    Console.WriteLine("Unknown command. Type 'help' for assistance.");
                    break;
            }
        }

        private bool CrossBridge()
        {
            Console.WriteLine("\nYou come across a rickety bridge with an evil warrior blocking your way.");
            Console.WriteLine("How do you proceed?");
            Console.WriteLine("A. Fight with your sword");
            Console.WriteLine("B. Try to talk and reason with the warrior");
            Console.WriteLine("C. Jump into the river below");
            Console.WriteLine("D. Cut the bridge ropes");

            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "a":
                    Console.WriteLine("\nYou bravely fight the warrior! Your skill is impressive and after a fierce battle, you emerge victorious!");
                    Console.WriteLine("The warrior respects your courage and allows you to pass.");
                    return true;
                case "b":
                    Console.WriteLine("\nYou attempt to reason with the warrior, but they're not interested in conversation.");
                    Console.WriteLine("They attack, catching you off guard. You lose a life but manage to escape across the bridge.");
                    lives--;
                    return false;
                case "c":
                    Console.WriteLine("\nYou leap into the rushing river below, hoping to bypass the bridge entirely.");
                    Console.WriteLine("The current is too strong and you're battered against rocks. You lose a life.");
                    lives--;
                    return false;
                case "d":
                    Console.WriteLine("\nWith quick thinking, you cut the bridge ropes while the warrior is still on it!");
                    Console.WriteLine("The warrior falls into the chasm while you remain safely on your side. Clever solution!");
                    return true;
                case "help":
                    DisplayHelp();
                    return false;
                case "quit":
                    Environment.Exit(0);
                    return false;
                case "restart":
                    lives = 3;
                    currentObstacle = 0;
                    Console.WriteLine("Game restarted.");
                    return false;
                default:
                    Console.WriteLine("Unknown command. You hesitate and the warrior attacks. You lose a life.");
                    lives--;
                    return false;
            }
        }

        private bool ExploreCave()
        {
            Console.WriteLine("\nYou enter a dark cave. The passage narrows and you hear strange noises ahead.");
            Console.WriteLine("What do you do?");
            Console.WriteLine("A. Light a torch and proceed carefully");
            Console.WriteLine("B. Proceed quietly in the darkness");
            Console.WriteLine("C. Call out to see if anyone's there");
            Console.WriteLine("D. Turn back and choose another path");

            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "a":
                    Console.WriteLine("\nYou light a torch, illuminating the cave. You spot traps ahead and carefully avoid them.");
                    Console.WriteLine("The light also reveals a hidden passage leading forward. Well done!");
                    return true;
                case "b":
                    Console.WriteLine("\nMoving silently in the darkness, you rely on your other senses.");
                    Console.WriteLine("You successfully navigate through the cave using your keen hearing and touch. Impressive!");
                    return true;
                case "c":
                    Console.WriteLine("\nYou call out, and your voice echoes through the cave.");
                    Console.WriteLine("Something large and hungry awakens! You barely escape, but lose a life in the process.");
                    lives--;
                    return false;
                case "d":
                    Console.WriteLine("\nYou decide to retreat and find another way. As you turn, you trip on a rock and hurt yourself.");
                    Console.WriteLine("You lose a life and have to choose another path.");
                    lives--;
                    return false;
                case "help":
                    DisplayHelp();
                    return false;
                case "quit":
                    Environment.Exit(0);
                    return false;
                case "restart":
                    lives = 3;
                    currentObstacle = 0;
                    Console.WriteLine("Game restarted.");
                    return false;
                default:
                    Console.WriteLine("Unknown command. You stumble in the darkness and hurt yourself. You lose a life.");
                    lives--;
                    return false;
            }
        }

        private bool ClimbMountain()
        {
            Console.WriteLine("\nYou begin climbing the towering mountain. The path is steep and treacherous.");
            Console.WriteLine("What's your approach?");
            Console.WriteLine("A. Climb straight up the steepest part to save time");
            Console.WriteLine("B. Look for a safer, winding path to the top");
            Console.WriteLine("C. Use your rope to secure yourself as you climb");
            Console.WriteLine("D. Search for a cave or tunnel through the mountain");

            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "a":
                    Console.WriteLine("\nYou attempt the direct approach up the steepest section.");
                    Console.WriteLine("It's too difficult and you slip, falling a short distance. You lose a life.");
                    lives--;
                    return false;
                case "b":
                    Console.WriteLine("\nYou find a winding but safer path up the mountain.");
                    Console.WriteLine("Though it takes longer, you successfully reach the summit. Well done!");
                    return true;
                case "c":
                    Console.WriteLine("\nYou use your rope wisely, securing yourself at regular intervals.");
                    Console.WriteLine("Your caution pays off as you safely navigate to the top of the mountain!");
                    return true;
                case "d":
                    Console.WriteLine("\nYou search for a tunnel but find only a shallow cave with a dead end.");
                    Console.WriteLine("You've wasted valuable time and energy. You lose a life.");
                    lives--;
                    return false;
                case "help":
                    DisplayHelp();
                    return false;
                case "quit":
                    Environment.Exit(0);
                    return false;
                case "restart":
                    lives = 3;
                    currentObstacle = 0;
                    Console.WriteLine("Game restarted.");
                    return false;
                default:
                    Console.WriteLine("Unknown command. You make a poor decision and slip. You lose a life.");
                    lives--;
                    return false;
            }
        }

        private bool FaceBossBattle()
        {
            Console.WriteLine("\n=================================================");
            Console.WriteLine("                 BOSS BATTLE                     ");
            Console.WriteLine("=================================================");
            Console.WriteLine("At the summit of the mountain, you encounter the Ancient Guardian,");
            Console.WriteLine("a massive stone golem protecting the legendary treasure.");
            Console.WriteLine("The Guardian's eyes glow with ancient magic as it prepares to attack!");
            Console.WriteLine("\nHow will you confront this powerful foe?");
            Console.WriteLine("A. Attack it head-on with your weapon");
            Console.WriteLine("B. Look for a weakness in its stone body");
            Console.WriteLine("C. Use the environment to your advantage");
            Console.WriteLine("D. Flee and try to find another way (restart the game)");

            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                case "a":
                    Console.WriteLine("\nYou charge the Guardian with your weapon raised!");
                    Console.WriteLine("Its stone body is too tough for your attacks. It strikes back, knocking you down.");
                    Console.WriteLine("You lose a life but manage to get back up.");
                    lives--;
                    return false;
                case "b":
                    Console.WriteLine("\nYou carefully observe the Guardian and notice a glowing crystal in its chest.");
                    Console.WriteLine("You strike the crystal precisely, causing the Guardian to crumble!");
                    Console.WriteLine("Well done! You've defeated the Ancient Guardian!");
                    return true;
                case "c":
                    Console.WriteLine("\nYou notice loose boulders above the Guardian.");
                    Console.WriteLine("With clever maneuvering, you cause a rockslide that crushes the Guardian!");
                    Console.WriteLine("The path to the treasure is now clear!");
                    return true;
                case "d":
                    Console.WriteLine("\nYou decide the Guardian is too powerful and retreat down the mountain.");
                    Console.WriteLine("Your adventure will have to start anew.");
                    lives = 3;
                    currentObstacle = 0;
                    return false;
                case "help":
                    DisplayHelp();
                    return false;
                case "quit":
                    Environment.Exit(0);
                    return false;
                default:
                    Console.WriteLine("\nYou hesitate, giving the Guardian an opening to attack.");
                    Console.WriteLine("Its powerful blow knocks you down. You lose a life.");
                    lives--;
                    return false;
            }
        }

        private void CompleteGame()
        {
            Console.WriteLine("\n=================================================");
            Console.WriteLine("            CONGRATULATIONS, " + playerName.ToUpper() + "!");
            Console.WriteLine("=================================================");
            Console.WriteLine("You've defeated the Ancient Guardian and claimed the legendary treasure!");
            Console.WriteLine("The golden artifacts glimmer in the sunlight as you open the ancient chest.");
            Console.WriteLine("Your name will be remembered in the tales of adventurers for generations to come!");
            Console.WriteLine("\nYou completed the adventure with " + lives + " lives remaining.");
            gameCompleted = true;
        }

        private void DisplayHelp()
        {
            Console.WriteLine("\n=================================================");
            Console.WriteLine("                  HELP MENU                      ");
            Console.WriteLine("=================================================");
            Console.WriteLine("GAME OBJECTIVE:");
            Console.WriteLine("  Navigate through obstacles, defeat the Ancient Guardian,");
            Console.WriteLine("  and claim the legendary treasure with at least one life remaining.");
            Console.WriteLine("\nCOMMANDS:");
            Console.WriteLine("  A, B, C, D: Choose one of the available options");
            Console.WriteLine("  help: Display this help menu");
            Console.WriteLine("  quit: Exit the game");
            Console.WriteLine("  restart: Start the game from the beginning");
            Console.WriteLine("\nGAME MECHANICS:");
            Console.WriteLine("  - You start with 3 lives");
            Console.WriteLine("  - Wrong choices will cost you a life");
            Console.WriteLine("  - Find the correct path through each obstacle");
            Console.WriteLine("  - Each obstacle has multiple solutions");
            Console.WriteLine("  - The final boss battle requires strategic thinking");
            Console.WriteLine("  - Your score is based on remaining lives");
            Console.WriteLine("=================================================");
        }

        private void LoadScores()
        {
            highScores.Clear();

            // Add some default scores if we need to populate an empty list
            highScores.Add(new ScoreEntry("Hero", 3));
            highScores.Add(new ScoreEntry("Warrior", 2));
            highScores.Add(new ScoreEntry("Explorer", 1));

            try
            {
                if (File.Exists(scoresFilePath))
                {
                    string[] lines = File.ReadAllLines(scoresFilePath);
                    foreach (string line in lines)
                    {
                        if (!string.IsNullOrWhiteSpace(line) && line.Contains(":"))
                        {
                            string[] parts = line.Split(':');
                            if (parts.Length >= 2)
                            {
                                string name = parts[0].Trim();
                                if (int.TryParse(parts[1].Trim(), out int score))
                                {
                                    highScores.Add(new ScoreEntry(name, score));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading scores: {ex.Message}");
            }
        }

        private void SaveScore()
        {
            try
            {
                // Add current player's score
                highScores.Add(new ScoreEntry(playerName, lives));

                // Sort scores (highest first) and take top 5
                var topScores = highScores
                    .OrderByDescending(s => s.Score)
                    .Take(5)
                    .ToList();

                // Convert to lines for saving
                List<string> lines = new List<string>();
                foreach (var entry in topScores)
                {
                    lines.Add($"{entry.Name}: {entry.Score}");
                }

                // Save to file
                File.WriteAllLines(scoresFilePath, lines);

                Console.WriteLine("\nYour score has been saved!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving score: {ex.Message}");
            }
        }

        private void DisplayHighScores()
        {
            Console.WriteLine("\n=================================================");
            Console.WriteLine("                 HIGH SCORES                    ");
            Console.WriteLine("=================================================");

            var topScores = highScores
                .OrderByDescending(s => s.Score)
                .Take(5)
                .ToList();

            if (topScores.Count == 0)
            {
                Console.WriteLine("No high scores available yet.");
            }
            else
            {
                int rank = 1;
                foreach (var entry in topScores)
                {
                    Console.WriteLine($"{rank}. {entry.Name}: {entry.Score} lives");
                    rank++;
                }
            }

            Console.WriteLine("=================================================");
        }
    }
}