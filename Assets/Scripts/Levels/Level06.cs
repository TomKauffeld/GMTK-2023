using System.Collections;

public class Level06 : MyLevel
{

    public override IEnumerator LevelLayout()
    {
        StartPlaying();


        yield return WaitForEnd();

        if (Win)
            yield return ShowMessage("You finished the level :)", evenIfFinished: true);
        else
            yield return ShowMessage("The character didn't get to the end :(", evenIfFinished: true);
    }
}
