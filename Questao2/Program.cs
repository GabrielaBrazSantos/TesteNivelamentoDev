using Newtonsoft.Json;
using Questao2.ViewModel;
using System.Text;

public class Program
{
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static int getTotalScoredGoals(string team, int year)
    {

        int page = 1;
        int totalpages = 1;
        int goals = 0;

        while (page <= totalpages)
        {
            var functionUrl = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}&team1={team}&page={page}";

            using (var httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage result = httpClient.GetAsync(functionUrl).Result;

                    if (result.IsSuccessStatusCode)
                    {
                        if (result.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var query = result.Content.ReadAsStringAsync();

                            var matches = JsonConvert.DeserializeObject<FootballViewModel.Root>(query.Result);
                            if (matches != null)
                            {
                                totalpages = matches.total_pages;
                                matches.data.ForEach(x =>
                                {
                                    goals += x.team1goals;
                                }
                                );
                            }                            

                        }                        
                    }                                        
                    
                }
                catch { }

                page++;
            }
        }
        return goals;
    }

}