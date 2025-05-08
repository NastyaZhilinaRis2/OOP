using Microsoft.VisualBasic.Devices;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using static ООП15.MainForm;

namespace ООП15
{
    public partial class MainForm : Form
    {
        private Game game;
        public MainForm()
        {
            InitializeComponent();
            game = new Game();
        }
        private async void button_start_Click(object sender, EventArgs e)
        {
            // проверяем ввод количества команд
            if (!ValidInputInt(textBox__number_team, "количество команд", 2, 1000, out int teamCount))
            {
                return;
            }

            // проверяем ввод пула игроков
            if (!ValidInputInt(textBox__pool_fighters, "количество бойцов (пул)", 0, 1000, out int pool))
            {
                return;
            }
            textBox__number_team.Enabled = false;
            textBox__pool_fighters.Enabled = false;
            button_start.Enabled = false;
            game.StartGame(DGV_game_data, teamCount, pool);
        }

        private void button_finish_Click(object sender, EventArgs e)
        {
            game.StopGame();
        }
        public class Fighter { }
        public class Team
        {
            public string Name { get; private set; }
            public List<Fighter> Fighters { get; private set; }
            public int Wins { get; private set; }
            public int Losses { get; private set; }
            public ThreadPriority Priority { get; private set; }
            public Team(string name, ThreadPriority priority)
            {
                Name = name;
                Fighters = new List<Fighter>();
                Wins = 0;
                Losses = 0;
                Priority = priority;
            }
            public void AddWin(int count)
            {
                Wins += count;
            }
            public void AddLoss(int count)
            {
                Losses += count;
            }
            public void AddFighter(Fighter fighter)
            {
                Fighters.Add(fighter);
            }
            public void RemoveFighters(int count)
            {
                Fighters.RemoveRange(0, count);
            }

        }
        public class Game
        {
            public static int Pool { get; private set; }// общий ресурс
            public List<Team> Teams { get; private set; } = new List<Team>();
            bool IsRunning { get; set; }

            DataGridView? gameData;

            public object teamsLock = new object();
            public object poolLock = new object();
            public object fightersLock = new object();
            public object winsLock = new object();
            public object lossLock = new object();

            public CancellationTokenSource cts = new CancellationTokenSource();

            public Random random = Random.Shared;
            public List<Thread> TeamThreads { get; private set; } = new List<Thread>();

            public void StartGame(DataGridView gameData, int teamCount, int pool)
            {
                this.gameData = gameData;

                IsRunning = true;
                Pool = pool;

                CreatingTeams(teamCount);
                GameProcess();
            }
            public void CreatingTeams(int teamCount)
            {
                Parallel.For(1, teamCount + 1, (int number) =>
                {
                    string name = $"Команда {number}";

                    ThreadPriority randomPriority = (ThreadPriority)random.Next(0, 5);

                    lock (teamsLock)
                    {
                        Teams.Add(new Team(name, randomPriority));
                    }
                });;
            }
            public void GameProcess()
            {

                foreach (var team in Teams)
                {
                    var thread = new Thread(() => TeamAction(team, cts.Token))
                    {
                        Priority = team.Priority,
                        IsBackground = true
                    };
                    TeamThreads.Add(thread);
                    thread.Start();
                }

            }
            private void TeamAction(Team team, CancellationToken token)
            {
                DateTime lastUpdate = DateTime.MinValue;

                while (IsRunning && !token.IsCancellationRequested)
                {
                    if (team.Fighters.Count == 0)
                        RandomAddFighters(team, token);
                    else
                        Attack(team, token);

                    UpdateGameData(team);

                    lock (poolLock)
                    {
                        if (Pool == 0 && IsRunning)
                        {
                            CheckConditionStop(token);
                        }
                    }

                    Thread.Sleep(100);
                    UpdateGameData(team);
                }
            }
            public void CheckConditionStop(CancellationToken token)
            {
                if (token.IsCancellationRequested) return;

                lock (poolLock)
                {
                    if (Pool == 0 && IsRunning)
                    {
                        int colNotNull = Teams.Count(t => t.Fighters.Count != 0);
                        if (colNotNull == 1)
                        {
                            IsRunning = false;
                            gameData.BeginInvoke(new Action(() => 
                                MessageBox.Show("Игра завершилась! Все бойцы пула находятся у одной команды!")));
                        }
                    }
                }
            }
            public void  RandomAddFighters(Team team, CancellationToken token)
            {
                if (token.IsCancellationRequested) return;

                int randCountFighters;

                lock (poolLock)
                {
                    if (Pool <= 0 || token.IsCancellationRequested) return;

                    randCountFighters = random.Next(1, Pool + 1);
                    Pool -= randCountFighters;
                }

                lock (fightersLock)
                {
                    if (token.IsCancellationRequested) return;

                    for (int i = 0; i < randCountFighters; i++)
                    {
                        team.AddFighter(new Fighter());
                    }
                }
            }
            public void Attack(Team team, CancellationToken token)
            {
                if (token.IsCancellationRequested) return;

                Team opponent;
                int countKill;

                lock (fightersLock)
                {
                    if (Teams.Count < 2 || token.IsCancellationRequested) return;

                    // выбираем рандомного противника (исключая себя и команды без бойцов)
                    var possibleOpponents = Teams.Where(teamOpponents => teamOpponents != team && teamOpponents.Fighters.Count > 0).ToList();
                    if (possibleOpponents.Count == 0) return;

                    opponent = possibleOpponents[random.Next(0, possibleOpponents.Count)];
                    // максимум сколько можем убить - сколько есть у противника
                    countKill = random.Next(1, opponent.Fighters.Count + 1);
                    opponent.RemoveFighters(countKill);
                }

                // обновляем статистику - сколько убила команда, столько у нее побед и столько же у противника проигрышей
                lock (winsLock) 
                { 
                    team.AddWin(countKill); 
                }
                lock (lossLock) 
                { 
                    opponent.AddLoss(countKill); 
                }

                // возвращаем убитых в общий пул
                lock (poolLock)
                {
                    if (!token.IsCancellationRequested)
                    {
                        Pool += countKill;
                    }
                }
            }
            public void StopGame()
            {
                IsRunning = false;
                cts.Cancel();

                foreach (var thread in TeamThreads)
                {
                    thread.Join();
                }

                cts.Dispose();
                cts = new CancellationTokenSource();
            }
            private void UpdateGameData(Team team)
            {
                if (gameData == null || gameData.IsDisposed) return;

                if (gameData.InvokeRequired)
                {
                    gameData.BeginInvoke(new Action(() => UpdateGameData(team)));
                    return;
                }

                for (int i = gameData.Rows.Count - 1; i >= 0; i--)
                {
                    if (gameData.Rows[i].Cells[0].Value?.ToString() == team.Name)
                    {
                        gameData.Rows.RemoveAt(i);
                    }
                }

                gameData.Rows.Add(
                    team.Name,
                    team.Wins,
                    team.Losses,
                    team.Priority.ToString()
                );
            }
        }

        static bool ValidInputInt(Control control, string fieldName, int min, int max, out int rez)
        {
            bool isCorrect = false;
            int number;
            string input = control.Text;

            if (int.TryParse(input, out number))
            {
                if (number > max)
                {
                    MessageBox.Show($"Введите {fieldName} <= {max}");
                }
                else if (number < min)
                {
                    MessageBox.Show($"Введите {fieldName} >= {min}");
                }
                else
                    isCorrect = true;
            }
            else
            {
                if (input == "")
                {
                    MessageBox.Show($"Введите {fieldName}!");
                }
                else
                {
                    MessageBox.Show($"Введите корректные данные в строке {fieldName}!");
                }
            }
            if (!isCorrect)
            {
                control.Text = "";
            }
            rez = number;
            return isCorrect;
        }
    }
}
