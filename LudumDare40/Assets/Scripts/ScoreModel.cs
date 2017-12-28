using Finegamedesign.Utils;

public sealed class ScoreModel
{
    private static ScoreModel s_ScoreModel;

    public static ScoreModel GetInstance()
    {
        if (s_ScoreModel == null)
        {
            s_ScoreModel = new ScoreModel();
        }
        return s_ScoreModel;
    }

    public Observable<int> score = new Observable<int>();
    public Observable<int> highScore = new Observable<int>();

    private ScoreModel()
    {
        score.onChanged -= UpdateHighScore;
        score.onChanged += UpdateHighScore;
    }

    ~ScoreModel()
    {
        score.onChanged -= UpdateHighScore;
    }

    private void UpdateHighScore(int nextScore)
    {
        if (nextScore <= highScore.value)
        {
            return;
        }
        highScore.value = nextScore;
        DebugUtil.Log("ScoreModel.UpdateHighScore: " + highScore.value);
    }
}
