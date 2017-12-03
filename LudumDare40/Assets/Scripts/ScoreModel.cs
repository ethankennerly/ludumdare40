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
}
